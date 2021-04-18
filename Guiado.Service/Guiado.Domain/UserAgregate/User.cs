using Guiado.Domain.SeedWork;
using System;

namespace Guiado.Domain.UserAgregate
{
    public class User : Entity, IRootAgregate
    {
        public string Password { get; private set; }
        public string Email { get; protected set; }
        public string Phone { get; private set; }
        public UserType UserType { get; private set; }
        public User(int id, string name, string password, string phone, string email, UserType type) : base(id, name)
        {
            this.Password = password;
            this.Phone= phone;
            this.Email = email;
            this.UserType = type;
        }

        public void UpdateInfo(string name, string phone, UserType type)
        {
            if (this.CheckEmptyString(name) || this.CheckEmptyString(phone))
            {
                throw new Exception("must inform name and phone");
            }

            this.Name = name;
            this.Phone = phone;
            this.UserType = type;
        }

        public void ChangePassword(string newPassword)
        {
            //apply password rules
            if (this.CheckEmptyString(newPassword) || string.Equals(newPassword, this.Password))
            {
                throw new Exception("must inform a different password");
            }

            this.Password = newPassword;
        }

        public void ChangeEmail(string newEmail)
        {
            if(this.CheckEmptyString(newEmail))
            {
                throw new Exception("must inform a email");
            }

            this.Email = newEmail;
        }

        private bool CheckEmptyString(string property)
            => string.IsNullOrWhiteSpace(property);
    }
}
