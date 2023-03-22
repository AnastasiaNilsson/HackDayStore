using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;

public class ShippingDetails
{
    [Key]
    public int Id {get; set;}
    public string Name {get; set;}
    public string StreetAddress {get; set;}
    public string Postcode {get; set;}
    public string City {get; set;}
    public string Email {get; set;}
}