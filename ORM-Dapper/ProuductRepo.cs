using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ORM_Dapper
{
  public class ProductRepo : IProductRepository
    
{
    private readonly IDbConnection _conn;

    public ProductRepo(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM products");
    }

    public void InsertProduct(string name)
    {
        _conn.Execute("INSERT INTO products (Name) VALUES (@Name)", new { Name = name });
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
        _conn.Execute("UPDATE products" +
            " SET Name = @name," +
            " Price = @price," +
            " CategoryID = @catID," +
            " OnSale = @onSale," +
            " StockLevel = @stock" +
            " WHERE ProductID = @id;",
            new
            {
                id = product.ProductID,
                name = product.Name,
                price = product.Price,
                catID = product.CategoryID,
                onSale = product.OnSale,
                stock = product.StockLevel
            });
    }

    public void DeleteProduct(Product product)
    {
       
        throw new NotImplementedException();
    }
}

}