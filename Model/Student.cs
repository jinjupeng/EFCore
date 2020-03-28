using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Grade { get; set; }
        public int? Age { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string CreateUserId { get; set; }
        public string UpdateUserId { get; set; }
    }
}
