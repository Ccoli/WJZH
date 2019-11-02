using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Tuby.Api.AOP;
using Tuby.Api.AuthHelper;
using Tuby.Api.Common;
using Tuby.Api.Common.HttpContextUser;
using Tuby.Api.Common.LogHelper;
using Tuby.Api.Common.MemoryCache;
using Tuby.Api.Filter;
using Tuby.Api.Hubs;
using Tuby.Api.Middlewares;

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

            #region 初始化DB
            services.AddScoped<Tuby.Api.Model.Seed.DBSeed>();
            services.AddScoped< Tuby.Api.Model.Seed.MyContext>();
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

                #region Token绑定到ConfigureServices

                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();

                // 发行人
                var IssuerName = (Configuration.GetSection("Audience"))["Issuer"];
                var security = new Dictionary<string, IEnumerable<string>> { { IssuerName, new string[] { } }, };
                c.AddSecurityRequirement(security);

                //方案名称“Tuby.Api”可自定义，上下一致即可
                c.AddSecurityDefinition(IssuerName, new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });
                #endregion
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
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(options =>
            {
                //配置大小写问题，默认是首字母小写
                //options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                //配置序列化时时间格式为yyyy-MM-dd HH:mm:ss
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });;
            #endregion


            #region Httpcontext

            // Httpcontext 注入
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            #endregion

            #region SignalR 通讯
            services.AddSignalR();
            #endregion

            #region Authorize 权限认证三步走

            //使用说明：

            //1、如果你只是简单的基于角色授权的，仅仅在 api 上配置，第一步：【1/2 简单角色授权】，第二步：配置【统一认证服务】，第三步：开启中间件

            //2、如果你是用的复杂的基于策略授权，配置权限在数据库，第一步：【3复杂策略授权】，第二步：配置【统一认证服务】，第三步：开启中间件app.UseAuthentication();

            //3、综上所述，设置权限，必须要三步走，授权 + 配置认证服务 + 开启授权中间件，只不过自定义的中间件不能验证过期时间，所以我都是用官方的。

            #region 【第一步：授权】

            #region 1、基于角色的API授权 

            // 1【授权】、这个很简单，其他什么都不用做， 只需要在API层的controller上边，增加特性即可，注意，只能是角色的:
            // [Authorize(Roles = "Admin,System")]


            #endregion

            #region 2、基于策略的授权（简单版）

            // 1【授权】、这个和上边的异曲同工，好处就是不用在controller中，写多个 roles 。
            // 然后这么写 [Authorize(Policy = "Admin")]
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin", policy => policy.RequireRole("Admin", "System"));
            });


            #endregion

            #region 【3、复杂策略授权】

            #region 参数
            //读取配置文件
            var audienceConfig = Configuration.GetSection("Audience");
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);


            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // 如果要数据库动态绑定，这里先留个空，后边处理器里动态赋值
            var permission = new List<PermissionItem>();

            // 角色与接口的权限要求参数
            var permissionRequirement = new PermissionRequirement(
                "/api/denied",// 拒绝授权的跳转地址（目前无用）
                permission,
                ClaimTypes.Role,//基于角色的授权
                audienceConfig["Issuer"],//发行人
                audienceConfig["Audience"],//听众
                signingCredentials,//签名凭据
                expiration: TimeSpan.FromSeconds(7 * 24 * 60 * 60)//接口的过期时间
                );
            #endregion

            //【授权】
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Permissions.Name,
                         policy => policy.Requirements.Add(permissionRequirement));
            });


            #endregion


            #endregion





            #region 【第二步：配置认证服务】
            // 令牌验证参数
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Issuer"],//发行人
                ValidateAudience = true,
                ValidAudience = audienceConfig["Audience"],//订阅人
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30),
                RequireExpirationTime = true,
            };

            //2.1【认证】、core自带官方JWT认证
            // 开启Bearer认证
            services.AddAuthentication("Bearer")
             // 添加JwtBearer服务
             .AddJwtBearer(o =>
             {
                 o.TokenValidationParameters = tokenValidationParameters;
                 o.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         // 如果过期，则把<是否过期>添加到，返回头信息中
                         if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                         {
                             context.Response.Headers.Add("Token-Expired", "true");
                         }
                         return Task.CompletedTask;
                     }
                 };
             });


            //2.2【认证】、IdentityServer4 认证 (暂时忽略)
            //services.AddAuthentication("Bearer")
            //  .AddIdentityServerAuthentication(options =>
            //  {
            //      options.Authority = "http://localhost:5002";
            //      options.RequireHttpsMetadata = false;
            //      options.ApiName = "blog.core.api";
            //  });
            // 注入权限处理器

            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            services.AddSingleton(permissionRequirement);
            #endregion

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
                      .InterceptedBy(cacheType.ToArray());//允许将拦截器服务的列表分配给注册。 
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

            #region 第三步：开启认证中间件

            //此授权认证方法已经放弃，请使用下边的官方验证方法。但是如果你还想传User的全局变量，还是可以继续使用中间件，第二种写法//app.UseMiddleware<JwtTokenAuth>(); 
            app.UseJwtTokenAuth();

            //如果你想使用官方认证，必须在上边ConfigureService 中，配置JWT的认证服务 (.AddAuthentication 和 .AddJwtBearer 二者缺一不可)
            app.UseAuthentication();
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

            app.UseSignalR(routes =>
            {
                //这里要说下，为啥地址要写 /api/xxx 
                //因为我前后端分离了，而且使用的是代理模式，所以如果你不用/api/xxx的这个规则的话，会出现跨域问题，毕竟这个不是我的controller的路由，而且自己定义的路由
                routes.MapHub<ChatHub>("/api2/chatHub");
            });
        }
    }
}
