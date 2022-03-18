using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
   public class LabelBL:ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        //AddLabel Method Reference
        public LabelEntity AddLabel(long userID, long noteID, string labelName)
        {
            try
            {
                return labelRL.AddLabel(userID, noteID, labelName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //UpdateLAbel Method Reference
        public IEnumerable<LabelEntity> UpdateLabel(long userID, string oldLabelName, string labelName)
        {
            try
            {
                return labelRL.UpdateLabel(userID, oldLabelName, labelName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Retrieve Label Method refernce
        public bool RetrieveLableByNoteID(long userID, long noteID, string labelName)
        {
            try
            {
                return labelRL.RetrieveLableByNoteID(userID, noteID, labelName);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //DeleteBynOteId
        public bool DeleteLabel(long userID, string labelName)
        {
            try
            {
                return labelRL.DeleteLabel(userID, labelName);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }


    }


