using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NETCoreMVC_Notlarim.Services.Interfaces;

namespace NETCoreMVC_Notlarim.Services
{
    public class ConsoleLog : ILog
    {
        public ConsoleLog(int a)
        {
            Console.WriteLine("CONSOLEA LOGLAMA ISLEMI GERCEKLESTIRILDI");
        }
        public void Log()
        {
            
        }
    }
}
