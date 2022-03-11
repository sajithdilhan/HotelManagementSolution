using CoreLibrary.Data;
using CoreLibrary.DataProviders;
using CoreLibrary.Entities;
using CoreLibrary.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HotelManagementSolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelManagementSolution", Version = "v1" });
            });

            services.AddDbContext<HotelDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("HotelDBConnection"),
                    assembly => assembly.MigrationsAssembly(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name));
            });

            services.AddScoped<IHotelRoomsDataProvider, HotelRoomsDataProvider>()
           .AddScoped<IHotelRoomDataService, HotelRoomDataService>()
           .AddScoped<IHotelRoom, HotelRoom>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelManagementSolution v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
