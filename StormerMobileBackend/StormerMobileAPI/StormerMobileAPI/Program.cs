using Microsoft.AspNetCore.Builder;
//using StormerMobileAPI.Context;
using StormerMobileAPI.Models;
using StormerMobileAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using StormerMobileAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
using System.Reflection;

namespace StormerMobileAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //await AccountsCosmosController.CreateNewAccount();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddSingleton<IOperationSingleton, Operation>();

            //builder.Services.AddSingleton<ICosmosDbService, CosmosDbService>();

            builder.Services.AddSingleton<ICosmosDbService>(o =>
                new CosmosDbService(o.GetRequiredService<IConfiguration>())
            );

            //// setting up default schemes and handlers
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "cookie";
            //    options.DefaultChallengeScheme = "oidc";
            //})
            //    .AddCookie("cookie", options =>
            //    {
            //        options.Cookie.Name = "web";

            //        // automatically revoke refresh token at signout time
            //        options.Events.OnSigningOut = async e => { await e.HttpContext.RevokeRefreshTokenAsync(); };
            //    })
            //    .AddOpenIdConnect("oidc", options =>
            //    {
            //        options.Authority = "https://sts.company.com";

            //        options.ClientId = "webapp";
            //        options.ClientSecret = "secret";

            //        options.ResponseType = "code";
            //        options.ResponseMode = "query";

            //        options.Scope.Clear();

            //        // OIDC related scopes
            //        options.Scope.Add("openid");
            //        options.Scope.Add("profile");
            //        options.Scope.Add("email");

            //        // API scopes
            //        options.Scope.Add("invoice");
            //        options.Scope.Add("customer");

            //        // requests a refresh token
            //        options.Scope.Add("offline_access");

            //        options.GetClaimsFromUserInfoEndpoint = true;
            //        options.MapInboundClaims = false;

            //        // important! this store the access and refresh token in the authentication session
            //        // this is needed to the standard token store to manage the artefacts
            //        options.SaveTokens = true;

            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            NameClaimType = "name",
            //            RoleClaimType = "role"
            //        };
            //    });

            //// adds services for token management
            //builder.Services.AddOpenIdConnectAccessTokenManagement();



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

        //private static async Task<CosmosDbService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        //{
        //    string databaseName = configurationSection.GetSection("DatabaseName").Value;
        //    string containerName = configurationSection.GetSection("ContainerName").Value;
        //    string account = configurationSection.GetSection("Account").Value;
        //    string key = configurationSection.GetSection("Key").Value;

        //    CosmosClient client = new CosmosClient(account, key);
        //    CosmosDbService cosmosDbService = new CosmosDbService(client, databaseName, containerName);
        //    DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);

        //    await database.Database.CreateContainerIfNotExistsAsync(containerName, "/Id");

        //    return cosmosDbService;
        //}

    }

}





