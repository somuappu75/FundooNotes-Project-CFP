using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface ILabelBL
    {
        public LabelEntity AddLabel(long userID, long noteID, string labelName);
        public IEnumerable<LabelEntity> UpdateLabel(long userID, string oldLabelName, string labelName);
        public bool RetrieveLableByNoteID(long userID, long noteID, string labelName);
        public bool DeleteLabel(long userID, string labelName);
        public IEnumerable<LabelEntity> GetAllLabels();
    }
}
