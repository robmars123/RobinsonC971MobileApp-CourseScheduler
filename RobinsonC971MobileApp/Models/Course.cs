using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinsonC971MobileApp.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string InstructorName { get; set; }
        public string InstructorPhoneNumber { get; set; }
        public string InstructorEmailAddress { get; set; }
        public int Notifications { get; set; }
        public string Notes { get; set; }
        public int TermId { get; set; }
    }
}
