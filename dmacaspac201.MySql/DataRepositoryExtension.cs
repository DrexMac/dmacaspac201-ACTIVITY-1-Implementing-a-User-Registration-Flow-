using dmacaspac201.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.MySql
{
    public static class DataRepositoryExtension
    {
        public static void AddDataRepositories(this IServiceCollection services)
            => services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
