//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();

//var app = builder.Build();

//// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//app.MapControllers();

//app.Run();

using Anton.Live.Api.Models;
using Anton.Live.Api.Services;

ProductReader reader = new ProductReader();

Console.WriteLine("Введите ID товара:");
int.TryParse(Console.ReadLine(), out int searchId);

Product foundProduct = reader.GetProductById(searchId);

if (foundProduct != null)
{
    Console.WriteLine("Название: " + foundProduct.Name);
    Console.WriteLine("Цена: " + foundProduct.Price + " руб.");
}
else
{
    Console.WriteLine("Товар с таким ID не найден.");
}
