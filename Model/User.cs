﻿using System;
using System.Collections.Generic;

namespace Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Pwd { get; set; }
        public string RealName { get; set; }
        public int Status { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime LastErrTime { get; set; }
        public int ErrorCount { get; set; }
        public int? Sex { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public bool? IsDelete { get; set; }
    }
}
