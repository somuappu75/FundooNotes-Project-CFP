//-----------------------------------------------------------------------
// <copyright file="UserEntity.cs" company="Bridgelabz">
//    Copyright © 2019 Company
// </copyright>
// <creator name="Somanath Havinal"/>
// -----------------------------------------------------------------------
namespace RepositoryLayer.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    /// <summary>
    /// UserEntity
    /// </summary>
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifierAt { get; set; }
    }
}
