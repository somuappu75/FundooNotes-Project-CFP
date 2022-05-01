//-----------------------------------------------------------------------
// <copyright file="UserRL.cs" company="Bridgelabz">
//    Copyright © 2019 Company
// </copyright>
// <creator name="Somanath Havinal"/>
// -----------------------------------------------------------------------

namespace RepositoryLayer.Service
{
    using System;
    using CommonLayer.Model;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using RepositoryLayer.Contex;
    using RepositoryLayer.Entity;
    using RepositoryLayer.Interface;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    public class UserRL : IUserRL
    {
        /// <summary>
        /// FundooContext context.
        /// </summary>
        private readonly FundooContext fundooContext;
        private readonly IConfiguration _Toolsettings;
        public UserRL(FundooContext fundooContext, IConfiguration _Toolsettings)
        {
            this.fundooContext = fundooContext;
            this._Toolsettings = _Toolsettings;
        }
        /// <summary>
        /// registration oF New User
        /// </summary>
        /// <param name="User"></param>
        /// <returns>Registration userentity</returns>
        public UserEntity Registration(UserRegistration User)
        {
            try
            {
                var user = this.fundooContext.User.FirstOrDefault(u => u.Email == User.Email);
                if (user == null)
                {
                    UserEntity userEntity = new UserEntity();
                    userEntity.FirstName = User.FirstName;
                    userEntity.LastName = User.LastName;
                    userEntity.Email = User.Email;
                    userEntity.Password = this.PasswordEncrypt(User.Password);
                    fundooContext.Add(userEntity);
                    int result = fundooContext.SaveChanges();
                    if (result > 0)
                    {
                        return userEntity;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// login Using Token ANd DecyptedPassword
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>Login Successfull With Token</returns>
        public string Login(UserLogin userLogin)
        {
            try
            {
                // if Email and password is empty return null. 
                if (string.IsNullOrEmpty(userLogin.Email) || string.IsNullOrEmpty(userLogin.Password))
                {
                    return null;
                }
                var result = fundooContext.User.Where(x => x.Email == userLogin.Email).FirstOrDefault();
                string dcryptPass = this.PasswordDecrypt(result.Password);
                if (result != null && dcryptPass == userLogin.Password)
                {
                    string token = GenerateSecurityToken(result.Email, result.Id);
                    return token;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Generating Token For Login Users
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Id"></param>
        /// <returns>Validation Token take Place</returns>
        private string GenerateSecurityToken(string Email, long Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Toolsettings["Jwt:secretkey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Email,Email),
                new Claim("Id",Id.ToString())
            };
            var token = new JwtSecurityToken(_Toolsettings["Jwt:Issuer"],
              _Toolsettings["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //Adding ForgetPassword
        /// <summary>
        /// Add New Password
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Password Change With Token</returns>
        public string ForgetPassword(string email)
        {
            try
            {
                var user = fundooContext.User.Where(x => x.Email == email).FirstOrDefault();
                if (user != null)
                {
                    var token = GenerateSecurityToken(user.Email, user.Id);
                    new Msmq().Sender(token);
                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        ////adding Reset Password
        /// <summary>
        /// ResetPassword Using Email
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <param name="confirmPassword">confirmpassword</param>
        /// <returns>Password Changed</returns>
        public bool ResetPassword(string email, string password, string confirmPassword)

        {
            try
            {
                if (password.Equals(confirmPassword))
                {
                    var user = fundooContext.User.Where(x => x.Email == email).FirstOrDefault();
                    user.Password = confirmPassword;
                    fundooContext.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        ////Encryption And Decryption Of data
        /// <summary>
        /// Encrypt And Decrypt Data
        /// </summary>
        /// <param name="password">password</param>
        /// <returns>Encrypted Password String</returns>
       ////Decryption Of data
        public string PasswordEncrypt(string password)
        {
            try
            {
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                string encryptPass = Convert.ToBase64String(encode);
                return encryptPass;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// PasswordDecrypt decrypt.
        /// </summary>
        /// <param name="encodedPass">encodedPass</param>
        /// <returns>decrypted password</returns>
        public string PasswordDecrypt(string encodedPass)
        {
            try
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Decoder utf8Decode = encoder.GetDecoder();
                byte[] toDecodeByte = Convert.FromBase64String(encodedPass);
                int charCount = utf8Decode.GetCharCount(toDecodeByte, 0, toDecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(toDecodeByte, 0, toDecodeByte.Length, decodedChar, 0);
                string PassDecrypt = new string(decodedChar);
                return PassDecrypt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
