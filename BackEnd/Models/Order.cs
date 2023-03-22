using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class Order 
{
    [Key]
    public int Id {get; set;}
    public string OrderNumber {get; set;}
    public CartItem[] PurchasedItems {get; set;}
    public ShippingDetails ShippingDetails {get; set;}
    public int TotalPrice {get; set;}
    public string ShippingStatus {get; set;}

    public Order() {}
    public Order(OrderRequest request)
    {
        OrderNumber = Guid.NewGuid().ToString();
        PurchasedItems = request.PurchasedItems;
        ShippingDetails = request.ShippingDetails;
        //TotalPrice = request.PurchasedItems.Aggregate(0, (total, item) => total += item.TotalPrice);
        ShippingStatus = "Preparing for Shipment";
    }
}