// ��������� ������
using LabRab_3;
using LabRab_3.Voronov;

namespace lab3_WebApplication
{
    // ����������� ������ "Program".
    public class Program
    {
        // ����� "Main" �������� ������ ����� � ����������.
        public static void Main()
        {
            // �������� ������ ���������� ���-����������.
            var builder = WebApplication.CreateBuilder();
            // �������� ���������� ���������� �� ������ ���������� �������.
            var app = builder.Build();

            // ������������� ������� "UseDefaultFiles" � "UseStaticFiles" ��� ��������� �������� �� ����������� �����.
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // ����� "MapGet" ������� ������� ��� ��������� GET-������� �� ��������� ����.
            // � ������ ������, ����� ������� ������� ��� ������� "/api/v", ������� ���������� JSON-������.
            app.MapGet("/api/v", () =>
            {
                // �������� ���������� ������ "Calculation", ������������ ��������� ���������� � ������������� ���������.
                Calculation calculation = new Calculation();
                calculation.GetList();
                calculation.FindMaxDay();
                return Results.Json(calculation);
            });

            // �������� �������� ��� ������� "/api/m", ������� ����� ���������� JSON-������.
            app.MapGet("/api/m", () =>
            {
                // �������� ���������� ������ "Run", ������� ���������� ���������.
                Run run = new Run();
                return Results.Json(run);
            });

            // �������� �������� ��� ������� "/api/d", ������� ���������� JSON-������.
            app.MapGet("/api/d", () =>
            {
                // �������� ���������� ������ "DataSource", ������� ���������� ���������.
                ISerializable response = new DataSource();
                return Results.Json(response);
            });

            // �������� �������� ��� ������� "/api/z", ������� ���������� JSON-������.
            app.MapGet("/api/z", () =>
            {
                // �������� ���������� ������ "Data", ������� ���������� ���������.
                Data data = new Data();
                return Results.Json(data);
            });

            // ������ ����������.
            app.Run();
        }
    }
}

