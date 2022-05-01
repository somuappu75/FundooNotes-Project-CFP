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
    public class CollabRL : ICollabRL
    {
        private readonly FundooContext fundooContext;

        public CollabRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }
        //AddCollaborator Api Method
        public CollaboratorEntity AddCollab(CollaboratorModel collaboratorModel)
        {
            try
            {
                CollaboratorEntity collaboration = new CollaboratorEntity();
                var user = fundooContext.User.Where(e => e.Email == collaboratorModel.CollabEmail).FirstOrDefault();
                var notes = fundooContext.Notes.Where(e => e.NotesId == collaboratorModel.NoteID && e.Id == collaboratorModel.Id).FirstOrDefault();
                if (notes != null && user != null)
                {
                    collaboration.NotesId = collaboratorModel.NoteID;
                    collaboration.CollabEmail = collaboratorModel.CollabEmail;
                    collaboration.Id = collaboratorModel.Id;
                    fundooContext.Collaborate.Add(collaboration);
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
        //Delete Collab APi Methos
        public CollaboratorEntity RemoveCollab(long userId, long collabId)
        {
            try
            {
                // Fetch All the details from Collab Table by user id and collab id.

                var data = this.fundooContext.Collaborate.FirstOrDefault(d => d.Id == userId && d.CollabId == collabId);
                if (data != null)
                {
                    this.fundooContext.Collaborate.Remove(data);
                    this.fundooContext.SaveChanges();
                    return data;
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
        //GetBy NOte ID Api Method
        public IEnumerable<CollaboratorEntity> GetByNoteId(long noteId, long userId)
        {
            try
            {
                // Fetch All the details from Collab Table by note id.
                var data = this.fundooContext.Collaborate.Where(c => c.NotesId == noteId && c.Id == userId).ToList();
                if (data != null)
                {
                    return data;
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
        public IEnumerable<CollaboratorEntity> GetAllCollab()
        {
            try
            {
                // Fetch All the details from Collab Table
                var collabs = this.fundooContext.Collaborate.ToList();
                if (collabs != null)
                {
                    return collabs;
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
