namespace Catalog.Core.Entities.Exceptions;

public class ResourceCreationBadRequestException : BadRequestException
{
    public ResourceCreationBadRequestException(string resource) : base($"there is an issue with mapping while creating {resource}")
    {
    }
}