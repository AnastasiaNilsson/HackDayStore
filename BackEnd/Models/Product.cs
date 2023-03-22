
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Bogus;


namespace BackEnd.Models;

public class Product 
{
    [Key]
    public int Id {get; set;}
    public string Name {get; set;}
    public string Category {get; set;}
    public string Picture {get; set;}
    public string Description {get; set;}
    public int Price {get; set;}

    public static Product Randomize()
    {
        var product = new Faker<Product>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Category, f => f.PickRandom(categories))
            .RuleFor(p => p.Picture, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
            .RuleFor(p => p.Price, f => f.Random.Int(99, 2999));

        return product.Generate();
    }

    static string[] categories = new[] { "Nice Stuff", "Hot Stuff", "Cool Stuff", "Awesome Stuff"};
}