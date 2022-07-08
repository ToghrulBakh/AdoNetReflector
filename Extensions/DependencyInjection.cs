using AdoNetReflector.Abstract;
using AdoNetReflector.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace AdoNetReflector.Extensions
{
    public static partial class Extension
    {
        public static void AddAdoNetOrm(this IServiceCollection service, DBSettings settings) 
        {
            service.AddScoped<IAdoNetService>(x=>new AdoNetService(settings));
        }
    }
}
