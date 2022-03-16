using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;
        public NotesRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this.configuration = configuration;
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
        //IsPinned Api Method 
        public bool IsPinned(long noteId)
        {
            try
            {
                var notes = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId);

                if (notes != null)
                {
                    if (notes.IsPinned == true)
                    {
                        notes.IsPinned = false;
                    }
                    else if (notes.IsPinned == false)
                    {
                        notes.IsPinned = true;
                    }
                    notes.modifiedAt = DateTime.Now;
                }
                int changes = fundooContext.SaveChanges();

                if (changes > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //IsArchieve Api MethoD ro Retieve Vice-versa
        public bool IsArchive(long noteId)
        {
            try
            {
                var notes = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId);

                if (notes != null)
                {
                    if (notes.IsArchive == true)
                    {
                        notes.IsArchive = false;
                    }
                    else if (notes.IsArchive == false)
                    {
                        notes.IsArchive = true;
                    }
                    notes.modifiedAt = DateTime.Now;
                }
                int changes = fundooContext.SaveChanges();

                if (changes > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //IsTrash Api Method
        public bool IsTrash(long noteId)
        {
            try
            {
                var notes = fundooContext.Notes.FirstOrDefault(e => e.NotesId == noteId);

                if (notes != null)
                {
                    if (notes.IsTrash == true)
                    {
                        notes.IsTrash = false;
                    }
                    else if (notes.IsTrash == false)
                    {
                        notes.IsTrash = true;
                    }
                    notes.modifiedAt = DateTime.Now;
                }
                int changes = fundooContext.SaveChanges();

                if (changes > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }

        }
        //Change COlor Api Method
        public NotesEntity ChangeColor(long notesId, string color)
        {
            try
            {
                NotesEntity note = this.fundooContext.Notes.FirstOrDefault(e => e.NotesId == notesId);
                if (note != null)
                {
                    note.Color = color;
                    fundooContext.Notes.Update(note);
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
        //Image Adding Api Method
        public NotesEntity UploadImage(long noteId, long userId, IFormFile image)
        {
            try
            {
                // Fetch All the details with the given noteId and userId
                var note = this.fundooContext.Notes.FirstOrDefault(n => n.NotesId == noteId && n.Id == userId);
                if (note != null)
                {
                    Account acc = new Account(configuration["Cloudinary:CloudName"], configuration["Cloudinary:ApiKey"], configuration["Cloudinary:ApiSecret"]);
                    Cloudinary cloud = new Cloudinary(acc);
                    var imagePath = image.OpenReadStream();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, imagePath),
                    };
                    var uploadResult = cloud.Upload(uploadParams);
                    note.Image = image.FileName;
                    this.fundooContext.Notes.Update(note);
                    int upload = this.fundooContext.SaveChanges();
                    if (upload > 0)
                    {
                        return note;
                    }
                    else
                    {
                        return null;
                    }
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
   
