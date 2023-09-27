namespace Basket.Application.Responses;

public record ShoppingCartDto
{
    public string UserName { get; set; }
    public List<ShoppingCartItemDto> Items { get; set; }

    public ShoppingCartDto(string userName)
    {
        UserName = userName;
    }

    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in Items)
            {
                totalPrice += item.Price * item.Quantity;
            }

            return totalPrice;
        }
    }
}