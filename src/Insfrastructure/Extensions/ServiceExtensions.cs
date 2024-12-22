using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;
public static class ServiceExtensions
{
    public static void AddDBContexts(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("MongoDB:ConnectionString").Value
         ?? throw new ArgumentNullException("MongoDB Connection", "Can not get connection string from enviroment");

        var database = configuration.GetSection("MongoDB:Database").Value
            ?? throw new ArgumentNullException("MongoDB Database", "Can not get database name from enviroment");


        services.AddDbContext<MongoDbContext>(
                   opt => opt
                   .UseMongoDB(connectionString, database));
    }
}
