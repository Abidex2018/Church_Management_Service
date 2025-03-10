using Church_Management_Service.DAO;
using Church_Management_Service.DAO.Implementation;
using Church_Management_Service.Services;
using Church_Management_Service.Services.ServiceImplementation;

namespace Church_Management_Service
{
    public static class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration.GetConnectionString("SQLiteConnection");
            services.AddSingleton<SQLiteContext>();

            services.AddScoped<IMembershipDAO, MembershipDAO>();
            services.AddScoped<IAttendanceDAO, AttendanceDAO>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IMembershipService, MembershipService>();

            services.AddHttpClient();
            
            services.AddScoped(typeof(HttpClientFactoryService<>));
        }
    }
}
