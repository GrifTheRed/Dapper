
using DapperClass;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperDepartmentRepository(conn);

var departments = repo.GetAllDepartments();

foreach (var dept in departments)
{
    Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
}