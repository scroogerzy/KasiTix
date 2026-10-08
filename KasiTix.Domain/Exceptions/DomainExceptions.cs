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
    { //throw new NotFoundException("Event not found");
    }
}

// 409
//duplicate ticket type
//not enough tickets
//buyer already has confirmed order
//concurrency collision
public sealed class ConflictException : DomainException
{
    public ConflictException(string message)
        : base(message)
    {
    }
}

// 422 Unprocessable Entity
public sealed class UnprocessableEntityException : DomainException
{
    public UnprocessableEntityException(string message)
        : base(message)
    {
    }
}
