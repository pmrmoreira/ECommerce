using ECommerce.Domain.Common;
using ECommerce.Domain.Exceptions;

namespace ECommerce.Domain.Entities;

public class User : BaseEntity
{
    
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    public User(string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new DomainException("Email is required.");
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new DomainException("PasswordHash is required.");
        Email = email;
        PasswordHash = passwordHash;
    }
    private User() { }
}
