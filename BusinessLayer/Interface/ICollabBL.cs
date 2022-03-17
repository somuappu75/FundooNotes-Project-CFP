using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public  interface ICollabBL
    {
        public Collaboration CollaborationAdd(CollabModel collabModel);
    }
}
