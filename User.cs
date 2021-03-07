using System;

public class User
{
    public virtual Guid Id { get; protected set; }
    public virtual string FirstName { get; protected set; }
    public virtual string LastName { get; protected set; }
    public virtual string Email { get; protected set; }
    public virtual string Password { get; protected set; }

    public virtual void ChangeEmail(string email)
    {
    }

    public static Customer Create(string firstname, string lastname, string email)
    {
    }

}
