namespace NETCoreMVC_Notlarim.Handlers
{
    public class ExampleHandler
    {
        public RequestDelegate Handler()
        {
            return async c => 
            {
                await c.Response.WriteAsync("HELLO WORLD");
            };
        }
    }
}
