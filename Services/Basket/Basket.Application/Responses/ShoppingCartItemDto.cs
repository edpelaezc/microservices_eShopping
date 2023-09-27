namespace Basket.Application.Responses;

public record ShoppingCartItemDto
{
    public int Quantity { get; set; }
    public string? ImageFile { get; set; }
    public decimal Price { get; set; }
    public string? ProductId { get; set; }
    public string? ProductName { get; set; }
}