//-----------------------------------------------------------------------
// <copyright file="FundooContext.cs" company="Bridgelabz">
//    Copyright © 2019 Company
// </copyright>
// <creator name="Somanath Havinal"/>
// -----------------------------------------------------------------------
namespace RepositoryLayer.Contex
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using RepositoryLayer.Entity;
    /// <summary>
    ///FundooContext implemetation class.
    /// </summary>
    public class FundooContext : DbContext
    {
            public FundooContext(DbContextOptions options) : base(options)
            {
            }
            public DbSet<UserEntity> User { get; set; }
        public DbSet<NotesEntity> Notes { get; set; }
      public DbSet<CollaboratorEntity> Collaborate { get; set; }
        public DbSet<LabelEntity> Label { get; set; }


    }
}

