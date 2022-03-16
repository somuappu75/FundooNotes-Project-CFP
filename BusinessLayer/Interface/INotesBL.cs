using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INotesBL
    {
        public NotesEntity CreateNote(NotesModel notesModel, long UserId);
        public NotesEntity UpdateNote(NotesModel notesModel, long noteId);
        public bool DeleteNote(long noteId);
        public IEnumerable<NotesEntity> RetrieveAllNotes(long noteId);
        public List<NotesEntity> GetAllNotes();
        public bool IsPinned(long noteId);
        public bool IsArchive(long noteId);
        public bool IsTrash(long noteId);
        public NotesEntity ChangeColor(long notesId, string color);
        public NotesEntity UploadImage(long noteId, long userId, IFormFile image);
    }
}
