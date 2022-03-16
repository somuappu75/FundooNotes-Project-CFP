using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
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
        //GetAllNotes Method Reference
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
        //IsPinned Method Reference
        public bool IsPinned(long noteId)
        {
            try
            {
                return notesRL.IsPinned(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //IsArchieve Method Reference
        public bool IsArchive(long noteId)
        {
            try
            {
                return notesRL.IsArchive(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //IsTrash Method Reference
        public bool IsTrash(long noteId)
        {
            try
            {
                return notesRL.IsTrash(noteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //ChangeColor Method reference
        public NotesEntity ChangeColor(long notesId, string color)
        {
            try
            {

                return notesRL.ChangeColor(notesId,color);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Adding Image Method Reference
        public NotesEntity UploadImage(long noteId, long userId, IFormFile image)
        {
            try
            {
                return this.notesRL.UploadImage(noteId, userId, image);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
