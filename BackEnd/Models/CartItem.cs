using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class CartItem
{
    [Key]
    public int Id {get; set;}
    public Product Product {get; set;}
    public int Quantity {get; set;}
}