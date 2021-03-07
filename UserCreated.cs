using System;

public class UserCreated : DomainEvent
{
	public User User { get; set; }
}
