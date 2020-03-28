﻿using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Role
    {
        public int Id { get; set; }
        public bool? IsDelete { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int OrderSort { get; set; }
        public bool Enabled { get; set; }
        public int? CreateId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifyId { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
