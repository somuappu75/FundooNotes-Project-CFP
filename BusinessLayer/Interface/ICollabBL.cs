using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICollabBL
    {
        public CollaboratorEntity AddCollab(CollaboratorModel collaboratorModel);
        public CollaboratorEntity RemoveCollab(long userId, long collabId);

        public IEnumerable<CollaboratorEntity> GetByNoteId(long noteId, long userId);

    }
}
