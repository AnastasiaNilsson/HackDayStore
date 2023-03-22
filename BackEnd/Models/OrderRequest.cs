using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class OrderRequest
{
    public CartItem[] PurchasedItems {get; set;}
    public ShippingDetails ShippingDetails {get; set;}
}