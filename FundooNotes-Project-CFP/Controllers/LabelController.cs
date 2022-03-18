using BusinessLayer.Interface;
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
    public class LabelController : ControllerBase
    {
        ILabelBL labelBL;
        public LabelController(ILabelBL labelBL)
        {
            this.labelBL = labelBL;
        }
        [HttpPost("Add")]
        public IActionResult AddLabel(string labelName, long noteID)
        {
            try
            {
                long userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = labelBL.AddLabel(userID, noteID, labelName);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "successfully Added Label", Response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unsuccessfull Adding" });
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPut("Update")]
        public IActionResult UpdateLabel(string lableName, string newLabelName)
        {
            try
            {
                long userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                var result = labelBL.UpdateLabel(userID, lableName, newLabelName);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "successfully Label Upadted", Response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unsuccessfull Updation" });
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        [Authorize]
        [HttpDelete("RetrieveLabelBynoteId")]
        public IActionResult DeleteLabel(long noteID, string lableName)
        {
            try
            {
                long userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (labelBL.DeleteLabel( noteID, lableName))
                {
                    return this.Ok(new { success = true, message = "successfully Retrieved " });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unsuccessfull Check User" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteLabel(string lableName)
        {
            try
            {
                long userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "Id").Value);
                if (labelBL.DeleteLabel(userID, lableName))
                {
                    return this.Ok(new { success = true, message = "successfully Label Deleted" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Unsuccessfull Check User" });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
