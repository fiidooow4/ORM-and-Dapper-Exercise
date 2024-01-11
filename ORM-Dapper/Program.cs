using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

public class Program
{
    private static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

        string connString = config.GetConnectionString("DefaultConnection");

        IDbConnection conn = new MySqlConnection(connString);

        #region DEPARTMENT    
        //var departmentRepo = new DapperDepartmentRepository(conn);

        //var department = departmentRepo.GetAllDepartments();

        //foreach (var departments in department)
        //{
        // Console.WriteLine(departments.DepartmentID);
        // Console.WriteLine(departments.Name);
        //Console.WriteLine();
        //Console.WriteLine();

        //}
        #endregion


        var ProductRepo = new DapperDepartmentRepository(conn);

        var products = ProductRepo.GetAllProduct();
        foreach (var product in products)
        {
            Console.WriteLine(product.ProductID);
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);
            Console.WriteLine(product.CategoryID);
            Console.WriteLine(product.OnSale);
            Console.WriteLine(product.StockLevel);
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();

        }
    }
}