using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

var department = departmentRepo.GetAllDepartments();

foreach (var departments in department)
{
    Console.WriteLine(departments.DepartmentID);
    Console.WriteLine(departments.Name);
    Console.WriteLine();
    Console.WriteLine();

}

