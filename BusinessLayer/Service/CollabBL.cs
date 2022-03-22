using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
   public  class CollabBL:ICollabBL
    {

        private readonly ICollabRL collabRL;

        public CollabBL(ICollabRL collabRL)
        {
            this.collabRL = collabRL;
        }
        //Add COllab Method Reference
        public CollaboratorEntity AddCollab(CollaboratorModel collaboratorModel)
        {
            try
            {
                return this.collabRL.AddCollab(collaboratorModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //GEtCollab Method Reference
        public IEnumerable<CollaboratorEntity> GetByNoteId(long noteId, long userId)
        {
            try
            {
                return this.collabRL.GetByNoteId(noteId, userId);
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
                return this.collabRL.GetAllCollab();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //RemoveCOllab Method Reference
        public CollaboratorEntity RemoveCollab(long userId, long collabId)
        {
            try
            {
                return this.collabRL.RemoveCollab(userId, collabId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
