using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes_Project_CFP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabelController : ControllerBase
    {
        ILabelBL labelBL;
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;
        public LabelController(ILabelBL labelBL,IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.labelBL = labelBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;

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
        [HttpDelete("Retrieve")]
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
        [HttpGet("GetAll")]
        public IEnumerable<LabelEntity> GetAllLabels()
        {
            try
            {
                var result = this.labelBL.GetAllLabels();
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
        [HttpGet("redis/GetAll")]
        public async Task<IActionResult> GetAllLabesUsingRedisCache()
        {
            var cacheKey = "labelList";
            string serializedLabelList;
            var labelsList = new List<LabelEntity>();
            var redisLabelList = await distributedCache.GetAsync(cacheKey);
            if (redisLabelList != null)
            {
                serializedLabelList = Encoding.UTF8.GetString(redisLabelList);
                labelsList = JsonConvert.DeserializeObject<List<LabelEntity>>(serializedLabelList);
            }
            else
            {
                labelsList = (List<LabelEntity>)this.labelBL.GetAllLabels();
                serializedLabelList = JsonConvert.SerializeObject(labelsList);
                redisLabelList = Encoding.UTF8.GetBytes(serializedLabelList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(15))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redisLabelList, options);
            }

            return this.Ok(labelsList);
        }
    }
}
