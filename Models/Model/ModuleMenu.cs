using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Model
{
    [Table("ModuleMenu")]
    public partial class ModuleMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool? IsDelete { get; set; }

        /// <summary>
        /// 接口id
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// 菜单id
        /// </summary>
        public int MenuId { get; set; }
        public int? CreateId { get; set; }
        public string CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? UpdateId { get; set; }
        public string UpdateName { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
