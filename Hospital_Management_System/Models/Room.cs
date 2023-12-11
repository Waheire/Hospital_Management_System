using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Models
{
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; } = Guid.NewGuid();
        public int RoomNumber { get; set; } = 0;
        public string RoomType { get; set; } = string.Empty;
        public List<Patient> patient { get; set; } = new List<Patient>();
    }
}
