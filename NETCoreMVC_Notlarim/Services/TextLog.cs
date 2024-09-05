using NETCoreMVC_Notlarim.Services.Interfaces;

namespace NETCoreMVC_Notlarim.Services
{
    public class TextLog : ILog
    {
        public void Log()
        {
            Console.WriteLine("TEXTE LOGLAMA ISLEMI GERCEKLESTIRILDI");
        }
    }
}
