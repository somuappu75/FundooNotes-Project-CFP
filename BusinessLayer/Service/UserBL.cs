//-----------------------------------------------------------------------
// <copyright file="UserBL.cs" company="Bridgelabz">
//    Copyright © 2019 Company
// </copyright>
// <creator name="Somanath Havinal"/>
// -----------------------------------------------------------------------
namespace BusinessLayer.Service
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BusinessLayer.Interface;
    using CommonLayer.Model;
    using RepositoryLayer.Entity;
    using RepositoryLayer.Interface;
    /// <summary>
    /// Iuserl Class
    /// </summary>
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;

        }

        public string Login(UserLogin userLogin)
        {
            try
            {
                return userRL.Login(userLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }
        ////user registration
        public UserEntity Registration(UserRegistration User)
        {
            try
            {
                return userRL.Registration(User);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //forgot passsword
        public string ForgetPassword(string email)
        {
            try
            {
                return userRL.ForgetPassword(email);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ResetPassword(string email, string password, string confirmPassword)
            {
                try
                {
                    return userRL.ResetPassword(email, password, confirmPassword);
                }
                catch (Exception)
                {

                    throw;
                }

            }
        ////encrypt and decrypt
     
     
        }
    }
