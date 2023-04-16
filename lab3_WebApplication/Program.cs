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


            app.MapGet("/api/voronov", (string id) =>
            {

            });

            app.MapGet("/api/miagkov", (string id) =>
            {

            });

            app.MapGet("/api/dmitrichenko", (string id) =>
            {
                ISerializable response = new DataSource();
                return Results.Json(response);
            });
           

            app.MapGet("/api/", (string id) =>
            {

            });

            app.Run();
        }
    }
}

