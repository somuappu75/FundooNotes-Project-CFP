using CommonLayer.Model;
using RepositoryLayer.Contex;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class NotesRL : INotesRL
    {
        public readonly FundooContext fundooContext;
        public NotesRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public NotesEntity CreateNote(NotesModel notesModel, long UserId)
        {
            try
            {
                NotesEntity notes = new NotesEntity()
                {
                    Title = notesModel.Title,
                    Description = notesModel.Description,
                    Reminder = notesModel.Reminder,
                    Color = notesModel.Color,
                    Image = notesModel.Image,
                    IsTrash = notesModel.IsTrash,
                    IsArchive = notesModel.IsArchive,
                    IsPinned = notesModel.IsPinned,
                    createdAt = notesModel.createdAt,
                    modifiedAt = notesModel.modifiedAt,
                    Id = UserId
                };
                this.fundooContext.Notes.Add(notes);

                // Save Changes Made in the database
                int result = this.fundooContext.SaveChanges();
                if (result > 0)
                {
                    return notes;
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
        //Update Method Modify The Details
        public NotesEntity UpdateNote(NotesModel notesModel, long noteId)
        {
            try
            {
                // Fetch All the details with the given noteId.
                var note = this.fundooContext.Notes.Where(u => u.NotesId == noteId).FirstOrDefault();
                if (note != null)
                {
                    note.Title = notesModel.Title;
                    note.Description = notesModel.Description;
                    note.Color = notesModel.Color;
                    note.Image = notesModel.Image;
                    note.modifiedAt = notesModel.modifiedAt;

                    // Update database for given NoteId.
                    this.fundooContext.Notes.Update(note);

                    // Save Changes Made in the database
                    this.fundooContext.SaveChanges();
                    return note;
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
        //Delete Method To Delete Note
        public bool DeleteNote(long noteId)
        {
            try
            {
                // Fetch details with the given noteId.
                var note = this.fundooContext.Notes.Where(n => n.NotesId == noteId).FirstOrDefault();
                if (note != null)
                {
                    // Remove Note details from database
                    this.fundooContext.Notes.Remove(note);

                    // Save Changes Made in the database
                    this.fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Retieve data From NotesId
        public IEnumerable<NotesEntity> RetrieveAllNotes(long noteId)
        {
            try
            {
                var note = fundooContext.Notes.Where(e => e.Id == noteId).ToList();
                if (note != null)
                {

                    return note;
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

        public List<NotesEntity> GetAllNotes()
        {
            try
            {
                // Fetch All the details from database
                var notes = this.fundooContext.Notes.ToList();
                if (notes != null)
                {
                    return notes;
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
