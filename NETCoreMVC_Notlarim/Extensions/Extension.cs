using NETCoreMVC_Notlarim.Middlewares;

namespace NETCoreMVC_Notlarim.Extensions
{
    static public class Extension
    {
        public static IApplicationBuilder UseHello(this IApplicationBuilder app) 
        { 
            return app.UseMiddleware<HelloMiddleware>();
        }
    }
}
