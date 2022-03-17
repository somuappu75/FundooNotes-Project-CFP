using CommonLayer.Model;
using RepositoryLayer.Contex;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class CollabRL:ICollabRL
    {
        private FundooContext fundooContext;
        Collaboration collaboration = new Collaboration();

        public CollabRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public Collaboration CollaborationAdd(CollabModel collabModel)
        {
            try
            {
                Collaboration collaboration = new Collaboration();
                var user = fundooContext.User.Where(e => e.Email == collabModel.CollabEmail).FirstOrDefault();

                var notes = fundooContext.Notes.Where(e => e.NotesId == collabModel.NotesID && e.Id == collabModel.Id).FirstOrDefault();
                if (notes != null && user != null)
                {
                    collaboration.NotesId = collabModel.NotesID;
                    collaboration.CollabEmail = collabModel.CollabEmail;
                    collaboration.Id = collabModel.Id;
                    fundooContext.Collab.Add(collaboration);
                    var result = fundooContext.SaveChanges();
                    return collaboration;
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

    }
}
