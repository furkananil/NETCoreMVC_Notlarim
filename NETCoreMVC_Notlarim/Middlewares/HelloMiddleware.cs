namespace NETCoreMVC_Notlarim.Middlewares
{
    public class HelloMiddleware
    {
        RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next) 
        { 
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            //CUSTOM OPERASYON
            Console.WriteLine("SELAMUN ALEYKUM");
            await _next.Invoke(httpContext);
            Console.WriteLine("ALEYKUM SELAM");
        }
    }
}
