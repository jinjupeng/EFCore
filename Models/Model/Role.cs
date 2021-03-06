﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Model
{
    public partial class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int OrderSort { get; set; }
        public bool Enabled { get; set; }
        public int? CreateId { get; set; }
        public string CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? UpdateId { get; set; }
        public string UpdateName { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
