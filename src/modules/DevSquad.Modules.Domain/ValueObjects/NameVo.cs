﻿using Flunt.Notifications;
using Flunt.Validations;

namespace DevSquad.Modules.Domain.ValueObjects
{
    public class NameVo : Notifiable, IValidatable
    {
        public NameVo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Validate();
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(FirstName, 3, "FirstName", "First name deve conter pelo menos 3 caracteres")
            .HasMaxLen(FirstName, 20, "FirstName", "First name deve conter no máximo 20 caracteres")
            .HasMinLen(LastName, 3, "FirstName", "First name deve conter pelo menos 3 caracteres")
            .HasMaxLen(LastName, 20, "FirstName", "First name deve conter no máximo 20 caracteres"));
        }
    }

}
