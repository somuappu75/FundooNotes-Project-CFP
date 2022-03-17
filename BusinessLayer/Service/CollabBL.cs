using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class CollabBL : ICollabBL
    {
        private readonly ICollabRL collabRL;

        public CollabBL(ICollabRL collabRL)
        {
            this.collabRL = collabRL;
        }
        //AddCollaboartion Method Reference
        public Collaboration CollaborationAdd(CollabModel collabModel)
        {
            try
            {
                return this.collabRL.CollaborationAdd(collabModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
