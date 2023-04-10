using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinsonC971MobileApp.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Content { get; set; }
        public int CourseID { get; set; }
    }
}
