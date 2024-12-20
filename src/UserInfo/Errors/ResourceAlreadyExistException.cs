namespace UserInfo.Errors;

public class ResourceAlreadyExistException(string message) : 
    ServiceException(StatusCodes.Status409Conflict, message)
{
    
}