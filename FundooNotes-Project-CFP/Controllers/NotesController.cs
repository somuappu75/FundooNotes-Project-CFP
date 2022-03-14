using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes_Project_CFP.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class NotesController : ControllerBase
        {
            private readonly INotesBL notesBL;
            public NotesController(INotesBL notesBL)
            {
                this.notesBL = notesBL;

            }

            [Authorize]
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

        }
}
