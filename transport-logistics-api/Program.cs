using Microsoft.EntityFrameworkCore;
using TransportLogistics.Repositories.Data;
using TransportLogistics.Repositories.Implementation;
using TransportLogistics.Repositories.Interfaces;
using TransportLogistics.Services.Implementation;
using TransportLogistics.Services.Interfaces;
using TransportLogistics.Services.Mappings;

namespace transport_logistics_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<TransportLogicDB>(option =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                option.UseSqlServer(connectionString);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var serviceAssembly = typeof(MappingProfile).Assembly;

            builder.Services.AddAutoMapper(typeof(Program).Assembly, serviceAssembly);

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));

            builder.Services.AddScoped<IDriverService, DriverService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ITripLogService, TripLogService>();
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();

            builder.Services.AddScoped<IDriverRepository, DriverRepository>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
