using Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

var product = new Product(1, "Bread", 2, 50, new DateTime(2024, 2, 20));

var productJson = JsonConvert.SerializeObject(product);

var product2 = JsonConvert.DeserializeObject<Product>(productJson);

Console.WriteLine(product2);

var products = new[]
{
    product,
    new Product(2, "Cheese", 10.50, 20, new DateTime(2024, 3, 15))
};

var productsJson = JsonConvert.SerializeObject(products);

Console.WriteLine(productsJson);

var productsNew = JsonConvert.DeserializeObject<Product>(productsJson);

//Console.WriteLine(string.Join("\n\n", productsNew.ToString().Split('}')));



string connectionString = "Server=localhost;Database=Minions;Uid=newuser;Pwd=pass123";

using (var DBconnection = new MySqlConnection(connectionString))
{
    DBconnection.Open();
    var query = @"select * from Countries;";

    using (var command = new MySqlCommand(query, DBconnection))
    {
        command.Execute
    }




}