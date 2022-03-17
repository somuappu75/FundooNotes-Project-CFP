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
    [Authorize]
    public class CollabController : Controller
    {
        private readonly ICollabBL collabBL;

        public CollabController(ICollabBL collabBL)
        {
            this.collabBL = collabBL;
        }
        //CollaboratoR Controller
        [HttpPost("Add")]
        public IActionResult AddCollab(string email, long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                CollabModel collabModel = new CollabModel();
                //getting id from collab model
                collabModel.Id = userId;
                collabModel.NotesID = noteId;
                collabModel.CollabEmail = email;
                var result = collabBL.CollaborationAdd(collabModel);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "Successfully Collaborator Added", data = result });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Unsuccessfull Collaboration Check User!!!" });
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
