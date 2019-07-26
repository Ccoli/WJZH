using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Tuby.Api.AOP;
using Tuby.Api.Common;
using Tuby.Api.Common.LogHelper;
using Tuby.Api.Common.MemoryCache;
using Tuby.Api.Filter;

namespace Tuby.Api
{
    public class Startup
    {
        /// <summary>
        /// log4net 仓储库
        /// </summary>
        public static ILoggerRepository Repository { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //log4net
            Repository = LogManager.CreateRepository(Configuration["Logging:Log4Net:Name"]);
            //指定配置文件
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
        }

        public IConfiguration Configuration { get; }

        //实现允许跨域的地址的可配置化
        private static string RequestsConnection = Appsettings.app(new string[] { "LimitRequests", "url" });
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            #region 部分服务注入-netcore自带方法
            // 缓存注入
            services.AddScoped<ICaching, MemoryCaching>();
            //log日志注入
            services.AddSingleton<ILoggerHelper, LogHelper>();
            #endregion

            #region Swagger
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v0.1.0",
                    Title = "Tuby API",
                    Description = "框架说明文档",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Tuby.Api", Email = "", Url = "https://www..com" }
                });

                var xmlPath = Path.Combine(basePath, "Tuby.Api.xml");//这个就是刚刚配置的xml文件名
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改

                var xmlModelPath = Path.Combine(basePath, "Tuby.Api.Model.xml");//这个就是Model层的xml文件名

                c.IncludeXmlComments(xmlModelPath);
            });

            #endregion

            #region 数据库配置
            services.AddScoped<Tuby.Api.Model.Seed.MyContext>();
            //BaseDBConfig.ConnectionString = Configuration.GetSection("AppSettings:MySqlConnection").Value;
            #endregion

            #region Automapper
            services.AddAutoMapper(typeof(Startup));
            #endregion

            #region CORS
            //跨域第二种方法，声明策略，记得下边app中配置
            services.AddCors(c =>
            {
                //↓↓↓↓↓↓↓注意正式环境不要使用这种全开放的处理↓↓↓↓↓↓↓↓↓↓
                c.AddPolicy("AllRequests", policy =>
                {
                    policy
                    .AllowAnyOrigin()//允许任何源
                    .AllowAnyMethod()//允许任何方式
                    .AllowAnyHeader()//允许任何头
                    .AllowCredentials();//允许cookie
                });
                //↑↑↑↑↑↑↑注意正式环境不要使用这种全开放的处理↑↑↑↑↑↑↑↑↑↑

                //一般采用这种方法
                c.AddPolicy("LimitRequests", policy =>
                {
                    policy
                     .WithOrigins(RequestsConnection)
                    //.WithOrigins("http://127.0.0.1:8013", "http://localhost:8013", "http://localhost:8012", "http://127.0.0.1:8013", "http://localhost:32100", "http://192.168.18.123:8012")//支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                    .AllowAnyHeader()//Ensures that the policy allows any header.
                    .AllowAnyMethod();
                });
            });

            //跨域第一种办法，注意下边 Configure 中进行配置
            //services.AddCors();
            #endregion

            #region MVC + GlobalExceptions
            //注入全局异常捕获
            services.AddMvc(o =>
            {
                // 全局异常过滤
                o.Filters.Add(typeof(GlobalExceptionsFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #endregion

            #region AutoFac

            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();

            //注册要通过反射创建的组件
            // builder.RegisterType<a_data_access_typeServices>().As<Ia_data_access_typeServices>();
            builder.RegisterType<ApiCacheAOP>();//可以直接替换其他拦截器！一定要把拦截器进行注册

            #region 带有接口层的服务注入

            #region Service.dll 注入，有对应接口
            //var assemblysServices = Assembly.Load("Tuby.Api.Services");
            //builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();//指定已扫描程序集中的类型注册为提供所有其实现的接口。
            //var assemblysRepository = Assembly.Load("Tuby.Api.Repository");//模式是 Load(解决方案名)
            //builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();

            var servicesDllFile = Path.Combine(basePath, "Tuby.Api.Services.dll");//获取注入项目绝对路径
            var assemblysServices = Assembly.LoadFile(servicesDllFile);//直接采用加载文件的方法
                                                                       //builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();//指定已扫描程序集中的类型注册为提供所有其实现的接口。


            // AOP 开关，如果想要打开指定的功能，只需要在 appsettigns.json 对应对应 true 就行。
            var cacheType = new List<Type>();
            //if (Appsettings.app(new string[] { "AppSettings", "RedisCaching", "Enabled" }).ObjToBool())
            //{
            //    cacheType.Add(typeof(ApiRedisCacheAOP));
            //}
            if (Appsettings.app(new string[] { "AppSettings", "MemoryCachingAOP", "Enabled" }).ObjToBool())
            {
                cacheType.Add(typeof(ApiCacheAOP));
            }
            //if (Appsettings.app(new string[] { "AppSettings", "LogAOP", "Enabled" }).ObjToBool())
            //{
            //    cacheType.Add(typeof(ApiLogAOP));
            //}

            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope()
                      .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
                                                    // 如果你想注入两个，就这么写  InterceptedBy(typeof(ApiCacheAOP), typeof(ApiLogAOP));
                                                    // 如果想使用Redis缓存，请必须开启 redis 服务，端口号我的是6319，如果不一样还是无效，否则请使用memory缓存 ApiCacheAOP
                      .InterceptedBy(typeof(ApiCacheAOP));//允许将拦截器服务的列表分配给注册。 
            #endregion

            #region Repository.dll 注入，有对应接口
            var repositoryDllFile = Path.Combine(basePath, "Tuby.Api.Repository.dll");
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
            #endregion
            #endregion

            //将services填充到Autofac容器生成器中
            builder.Populate(services);

            //使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();

            #endregion

            

            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                c.RoutePrefix = "";//路径配置，设置为空，表示直接访问该文件，
                                   //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，
                                   //这个时候去launchSettings.json中把"launchUrl": "swagger/index.html"去掉， 然后直接访问localhost:8001/index.html即可
            });
            #endregion


            #region CORS
            //跨域第二种方法，使用策略，详细策略信息在ConfigureService中
            app.UseCors("AllRequests");//将 CORS 中间件添加到 web 应用程序管线中, 以允许跨域请求。


            #region 跨域第一种版本
            //跨域第一种版本，请要ConfigureService中配置服务 services.AddCors();
            //    app.UseCors(options => options.WithOrigins("http://localhost:8021").AllowAnyHeader()
            //.AllowAnyMethod());  
            #endregion

            #endregion

            // 跳转https
            //app.UseHttpsRedirection();
            // 使用静态文件
            app.UseStaticFiles();
            // 使用cookie
            app.UseCookiePolicy();
            // 返回错误码
            app.UseStatusCodePages();//把错误码返回前台，比如是404

            app.UseMvc();
        }
    }
}
