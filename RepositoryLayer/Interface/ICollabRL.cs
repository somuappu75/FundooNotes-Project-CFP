﻿using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
  public   interface ICollabRL
    {
        public CollaboratorEntity AddCollab(CollaboratorModel collaboratorModel);
        public CollaboratorEntity RemoveCollab(long userId, long collabId);

        public IEnumerable<CollaboratorEntity> GetByNoteId(long noteId, long userId);

    }
}
