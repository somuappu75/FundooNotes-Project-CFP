using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class NotesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NotesId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Reminder { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public bool IsTrash { get; set; }
        public bool IsArchive { get; set; }
        public bool IsPinned { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? modifiedAt { get; set; }

        [ForeignKey("user")]
        public long Id { get; set; }
        public UserEntity user { get; set; }
    }
}
