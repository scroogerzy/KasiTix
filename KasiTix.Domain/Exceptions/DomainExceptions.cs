namespace KasiTix.Domain.Exceptions;

// Base exception
public abstract class DomainException : Exception
{
    protected DomainException(string message)
        : base(message)
    {
    }
}

// 404
public sealed class NotFoundException : DomainException
{
    public NotFoundException(string message)
        : base(message)
    {
    }
}

// 409
public sealed class ConflictException : DomainException
{
    public ConflictException(string message)
        : base(message)
    {
    }
}

// 422
public sealed class UnprocessableEntityException : DomainException
{
    public UnprocessableEntityException(string message)
        : base(message)
    {
    }
}