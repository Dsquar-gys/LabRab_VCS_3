// начальные данные
using LabRab_3;
using LabRab_3.Voronov;

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
                Calculation calculation = new Calculation();
                calculation.GetList();
                calculation.FindMaxDay();
                return Results.Json(calculation);
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
                Data data = new Data();
                return Results.Json(data);
            });

            app.Run();
        }
    }
}

