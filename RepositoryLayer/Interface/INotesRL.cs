using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public  interface INotesRL
    {
        public NotesEntity CreateNote(NotesModel notesModel, long UserId);
        public NotesEntity UpdateNote(NotesModel notesModel, long noteId);
        public bool DeleteNote(long noteId);
        public IEnumerable<NotesEntity> RetrieveAllNotes(long noteId);
        public List<NotesEntity> GetAllNotes();
    }
}
