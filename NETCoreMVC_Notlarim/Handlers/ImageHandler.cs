using ImageMagick;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NETCoreMVC_Notlarim.Handlers
{
    public class ImageHandler
    {
        public RequestDelegate Handler(string filePath)
        {
            return async c =>
            {
                FileInfo fileInfo = new FileInfo($"{filePath}\\{c.Request.RouteValues["fileName"].ToString()}");
                using MagickImage magick = new(fileInfo); //fonksiyon gorevini bitirince imha edilecek.

                int width = magick.Width , height = magick.Height ;

                if (!string.IsNullOrEmpty(c.Request.Query["w"].ToString()))
                    width = int.Parse(c.Request.Query["w"].ToString());
                if (!string.IsNullOrEmpty(c.Request.Query["h"].ToString()))
                    height = int.Parse(c.Request.Query["h"].ToString());

                magick.Resize(width, height);

                var buffer = magick.ToByteArray();
                c.Response.Clear();
                c.Response.ContentType = string.Concat("image/", fileInfo.Extension.Replace(".", ""));

                await c.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                await c.Response.WriteAsync(filePath);
            };
        }
    }
}
