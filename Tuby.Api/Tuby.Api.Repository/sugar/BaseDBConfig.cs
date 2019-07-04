using Blog.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tuby.Api.Repository.sugar
{
    public class BaseDBConfig
    {
        //正常格式是
       // public static string ConnectionString { get; set; }
        public static string ConnectionString = Appsettings.app(new string[] { "AppSettings", "RedisCaching", "ConnectionString" });//获取连接字符串
        //public static string ConnectionString = "server=.;uid=sa;pwd=sa;database=BlogDB"; 

        //原谅我用配置文件的形式，因为我直接调用的是我的服务器账号和密码，安全起见

    }
}
