namespace Basket.Core.Entities;

public class ShoppingCart
{
    public string UserName { get; set; }
    public decimal TotalPrice { get; set; } 
    
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

    public ShoppingCart(string userName)
    {
        UserName = userName;
    }
}