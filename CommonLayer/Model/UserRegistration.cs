//-----------------------------------------------------------------------
// <copyright file="UserRegistration.cs" company="Bridgelabz">
//    Copyright © 2019 Company
// </copyright>
// <creator name="Somanath Havinal"/>
// -----------------------------------------------------------------------
namespace CommonLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class UserRegistration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
