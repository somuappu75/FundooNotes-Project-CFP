using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes_Project_CFP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesBL notesBL;
        public NotesController(INotesBL notesBL)
        {
            this.notesBL = notesBL;

        }
        //Create Note
        [HttpPost("createNote")]
        public IActionResult CreateNote(NotesModel notesModel)
        {
            try
            {
                //Id of login user
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var result = notesBL.CreateNote(notesModel, userId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "note created Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "failed to create note" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Update Note
        [HttpPut("Update")]
        public IActionResult UpdateNote(NotesModel notesModel, long noteId)
        {
            try
            {
                var notes = this.notesBL.UpdateNote(notesModel, noteId);
                if (notes != null)
                {
                    return this.Ok(new { Success = true, message = " Note Updated successfully ", data = notes });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unsuccess failed to update note" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Delete Note
        [HttpDelete("Delete")]
        public IActionResult DeleteNote(long noteId)
        {
            try
            {
                var notes = this.notesBL.DeleteNote(noteId);
                if (!notes)
                {
                    return this.BadRequest(new { Success = false, message = "UnSuccess Failed to Delete note" });
                }
                else
                {
                    return this.Ok(new { Success = true, message = " Note Deleted successfully ", data = notes });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //RetirveNote
        [HttpGet("Retrieve")]
        public IActionResult RetrieveAllNotes(long noteId)
        {
            try
            {
                var result = notesBL.RetrieveAllNotes(noteId);
                if (result != null)
                    return this.Ok(new { Success = true, message = "Retrieve Data successful", data = notesBL.RetrieveAllNotes(noteId) });
                else
                    return this.BadRequest(new { Success = false, message = "Failed To Retrive Data " });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, Message = e.Message });
            }
        }
        //GetAllNotes
        [HttpGet("GetAllNotes")]
        public List<NotesEntity> GetAllNotes()
        {
            try
            {
                var result = this.notesBL.GetAllNotes();
                if (result != null)
                {
                    return result;
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
