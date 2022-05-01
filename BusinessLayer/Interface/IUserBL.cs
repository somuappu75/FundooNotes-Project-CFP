//-----------------------------------------------------------------------
// <copyright file="IUserBL.cs" company="Bridgelabz">
//    Copyright © 2019 Company
// </copyright>
// <creator name="Somanath Havinal"/>
// -----------------------------------------------------------------------
namespace BusinessLayer.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CommonLayer.Model;
    using RepositoryLayer.Entity;
    /// <summary>
    /// IuserRL class
    /// </summary>
    public interface IUserBL
    {
        public UserEntity Registration(UserRegistration User);
        public string Login(UserLogin userLogin);
        public string ForgetPassword(string email);
        bool ResetPassword(string email, string password, string confirmPassword);
       
    }
}
