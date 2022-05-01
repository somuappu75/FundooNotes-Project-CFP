//-----------------------------------------------------------------------
// <copyright file="IUserRL.cs" company="Bridgelabz">
//    Copyright © 2019 Company
// </copyright>
// <creator name="Somanath Havinal"/>
// -----------------------------------------------------------------------
namespace RepositoryLayer.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommonLayer.Model;
    using RepositoryLayer.Entity;
    /// <summary>
    ///IUserRL
    /// </summary>
    public interface IUserRL
    {
        public UserEntity Registration(UserRegistration User);
        public string Login(UserLogin userLogin);
        public string ForgetPassword(string email);
        bool ResetPassword(string email, string password, string confirmPassword);
       


    }
}
