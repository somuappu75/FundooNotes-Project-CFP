using Microsoft.Extensions.Configuration;
using RepositoryLayer.Contex;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class LabelRL : ILabelRL
    {
        FundooContext fundoocontext;
        private readonly IConfiguration configuration;
        public LabelRL(FundooContext fundoocontext, IConfiguration config)
        {
            this.fundoocontext = fundoocontext;
            this.configuration = config;//
        }
        //CreateLabele Api
        public LabelEntity AddLabel(long userID, long noteID, string labelName)
        {
            try
            {
                LabelEntity labelEntity = new LabelEntity
                {
                    LabelName = labelName,
                    Id = userID,
                    NoteId = noteID
                };
                this.fundoocontext.Label.Add(labelEntity);
                int result = this.fundoocontext.SaveChanges();
                if (result > 0)
                {
                    return labelEntity;
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
        //Upadte Lable Api
        public IEnumerable<LabelEntity> UpdateLabel(long userID, string oldLabelName, string labelName)
        {
            IEnumerable<LabelEntity> labels;
            labels = fundoocontext.Label.Where(e => e.Id == userID && e.LabelName == oldLabelName).ToList();
            if (labels != null)
            {
                foreach (var label in labels)
                {
                    label.LabelName = labelName;
                }
                fundoocontext.SaveChanges();
                return labels;
            }
            else
            {
                return null;
            }

        }
        public bool RetrieveLableByNoteID(long userID, long noteID, string labelName)
        {
            var label = fundoocontext.Label.Where(e => e.Id == userID && e.LabelName == labelName && e.NoteId == noteID).FirstOrDefault();
            if (label != null)
            {
                fundoocontext.Label.Remove(label);
                fundoocontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //deletelabel
        public bool DeleteLabel(long userID, string labelName)
        {
            IEnumerable<LabelEntity> labels;
            labels = fundoocontext.Label.Where(e => e.Id == userID && e.LabelName == labelName).ToList();
            if (labels != null)
            {
                foreach (var label in labels)
                {
                    fundoocontext.Label.Remove(label);
                }
                fundoocontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public IEnumerable<LabelEntity> GetAllLabels()
        {
            try
            {
                // Fetch All the details from Labels Table
                var labels = this.fundoocontext.Label.ToList();
                if (labels != null)
                {
                    return labels;
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
