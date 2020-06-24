using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Model
{
    public partial class RoleModuleMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int? MenuId { get; set; }
        public int? CreateId { get; set; }
        public string CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? UpdateId { get; set; }
        public string UpdateName { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
