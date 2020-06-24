using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Model
{
    public partial class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }

        public string Salt { get; set; }
        public string TrueName { get; set; }

        public string RoleName { get; set; }

        public int RoleId { get; set; }
        public int Status { get; set; }

        public string Token { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime LastErrTime { get; set; }
        public int ErrorCount { get; set; }
        public int? Sex { get; set; }
        public int? Age { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Address { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
