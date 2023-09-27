namespace Basket.Core.Entities.Exceptions;

public class BasketNotFoundException : NotFoundException
{
    public BasketNotFoundException(string userName) : base($"The basket for user: {userName}, was not found.")
    {
    }
}