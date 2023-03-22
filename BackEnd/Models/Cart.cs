using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Cart
{
    [Key]
    public int Id {get; set;}
    public string CartNumber {get; set;}
    public CartItem[] Items {get; set;}

    public Cart() {}
    public Cart(CartItem[] items)
    {
        CartNumber = Guid.NewGuid().ToString();
        Items = items;
    }
}