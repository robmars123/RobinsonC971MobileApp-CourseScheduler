﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinsonC971MobileApp.Models
{
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
