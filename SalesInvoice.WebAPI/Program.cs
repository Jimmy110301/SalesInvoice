using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using SalesInvoice.WebAPI.Extensions;

namespace SalesInvoice.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Sales Invoice API", Version = "v1" });
            });

            builder.Services.AddDataLayer(builder.Configuration);
            builder.Services.AddRepositoryLayer();
            builder.Services.AddServiceLayer();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"./v1/swagger.json", "Sales Invoice API V1");
            });

            app.UseHttpsRedirection();
            app.UseExceptionHandler(options =>
            {
                options.Run(async (context) =>
                {
                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerPathFeature != null)
                    {
                        var errorresponse = new
                        {
                            StatusCode = (int)System.Net.HttpStatusCode.NotFound,
                            ErrorMessage = "Unable to process request due to unhandled exception",
                            Details = exceptionHandlerPathFeature?.Error?.Message
                        };
                        await context.Response.WriteAsJsonAsync(errorresponse);
                    }
                });
            });
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
