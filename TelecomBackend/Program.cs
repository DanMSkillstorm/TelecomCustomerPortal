using TelecomBackend.Services;

namespace TelecomBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IAccountsCosmosDbService>(o =>
                new AccountsCosmosDbService(o.GetRequiredService<IConfiguration>())
            );
            builder.Services.AddSingleton<IPlansCosmosDbService>(o =>
                new PlansCosmosDbService(o.GetRequiredService<IConfiguration>())
            );
            builder.Services.AddSingleton<IDevicesCosmosDbService>(o =>
                new DevicesCosmosDbService(o.GetRequiredService<IConfiguration>())
            );

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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