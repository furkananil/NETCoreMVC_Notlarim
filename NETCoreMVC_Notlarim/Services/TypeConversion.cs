using System.Reflection;

namespace NETCoreMVC_Notlarim.Services
{
    public static class TypeConversion
    {
        //REFLECTION ILE DONUSTURME
        public static TResult Conversion<T, TResult>(T model) where TResult : class,new()
        {
            TResult result = new TResult();
            typeof(T).GetProperties().ToList().ForEach(p => 
            {
                PropertyInfo propInfo = typeof(TResult).GetProperty(p.Name);
                propInfo.SetValue(result,p.GetValue(model));
            });
            return result;
        }
    }
}
