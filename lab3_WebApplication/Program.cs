// начальные данные

using Azure;
using LabRab_3;
using System;
using System.Text.Json;

namespace lab3_WebApplication
{
    public class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.MapGet("/api/v", () =>
            {
                
            });

            app.MapGet("/api/m", () =>
            {
                Run run = new Run();
                return Results.Json(run);
            });

            app.MapGet("/api/d", () =>
            {
                ISerializable response = new DataSource();
                return Results.Json(response);
            });
           

            app.MapGet("/api/z", () =>
            {
                Data response = new Data();
                return Results.Json(response);
            });

            app.Run();
        }
    }
}

