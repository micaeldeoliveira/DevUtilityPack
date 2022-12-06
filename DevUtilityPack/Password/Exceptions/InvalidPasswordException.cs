namespace DevUtilityPack.Password.Exceptions;

public class InvalidPasswordException : Exception
{
    public InvalidPasswordException(string message = "Senha inválida") : base(message)
    {
    }
}
