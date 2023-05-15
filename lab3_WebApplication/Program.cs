// начальные данные
using LabRab_3;
using LabRab_3.Voronov;

namespace lab3_WebApplication
{
    // ќпределение класса "Program".
    public class Program
    {
        // ћетод "Main" €вл€етс€ точкой входа в приложение.
        public static void Main()
        {
            // —оздание нового экземпл€ра веб-приложени€.
            var builder = WebApplication.CreateBuilder();
            // —оздание экземпл€ра приложени€ на основе созданного билдера.
            var app = builder.Build();

            // »спользование методов "UseDefaultFiles" и "UseStaticFiles" дл€ обработки запросов на статические файлы.
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // ћетод "MapGet" создает маршрут дл€ обработки GET-запроса на указанный путь.
            // ¬ данном случае, метод создает маршрут дл€ запроса "/api/v", который возвращает JSON-объект.
            app.MapGet("/api/v", () =>
            {
                // —оздание экземпл€ра класса "Calculation", выполн€ющего некоторые вычислени€ и возвращающего результат.
                Calculation calculation = new Calculation();
                calculation.GetList();
                calculation.FindMaxDay();
                return Results.Json(calculation);
            });

            // —оздание маршрута дл€ запроса "/api/m", который также возвращает JSON-объект.
            app.MapGet("/api/m", () =>
            {
                // —оздание экземпл€ра класса "Run", который возвращает результат.
                Run run = new Run();
                return Results.Json(run);
            });

            // —оздание маршрута дл€ запроса "/api/d", который возвращает JSON-объект.
            app.MapGet("/api/d", () =>
            {
                // —оздание экземпл€ра класса "DataSource", который возвращает результат.
                ISerializable response = new DataSource();
                return Results.Json(response);
            });

            // —оздание маршрута дл€ запроса "/api/z", который возвращает JSON-объект.
            app.MapGet("/api/z", () =>
            {
                // —оздание экземпл€ра класса "Data", который возвращает результат.
                Data data = new Data();
                return Results.Json(data);
            });

            // «апуск приложени€.
            app.Run();
        }
    }
}

