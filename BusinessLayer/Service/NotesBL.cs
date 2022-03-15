using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
   public class NotesBL : INotesBL
    {
      
            private readonly INotesRL notesRL;
            public NotesBL(INotesRL notesRL)
            {
                this.notesRL = notesRL;
            }
            public NotesEntity CreateNote(NotesModel notesModel, long UserId)
            {
                try
                {
                    return notesRL.CreateNote(notesModel, UserId);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        //Upadte MethoD Reference
        public NotesEntity UpdateNote(NotesModel notesModel, long noteId)
        {
            try
            {
                return notesRL.UpdateNote(notesModel, noteId);
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Delete Method Reference
        public bool DeleteNote(long noteId)
        {
            try
            {
                return notesRL.DeleteNote(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Retrive Method Reference
        public IEnumerable<NotesEntity> RetrieveAllNotes(long noteId)
        {
            try
            {

                return notesRL.RetrieveAllNotes(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<NotesEntity> GetAllNotes()
        {
            try
            {
                return notesRL.GetAllNotes();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
