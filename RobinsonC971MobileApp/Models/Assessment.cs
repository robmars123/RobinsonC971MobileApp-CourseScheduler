using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinsonC971MobileApp.Models
{
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Notifications { get; set; }
        public int CourseID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AssessmentType { get; set; }

    }
}
