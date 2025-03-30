namespace MyRecipeBook.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : MyRecipeBookException
{
    IList<string> ErrorMessages { get; set; }

    public ErrorOnValidationException(IList<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
