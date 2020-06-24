using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Model
{
    /// <summary>
    /// 接口实体类
    /// </summary>
    [Table("Module")]
    public partial class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 父菜单id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 接口名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderSort { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否是菜单
        /// </summary>
        public bool IsMenu { get; set; }

        /// <summary>
        /// 启用或禁用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 创建人id
        /// </summary>
        public int? CreateId { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreateName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改人id
        /// </summary>
        public int? UpdateId { get; set; }

        /// <summary>
        /// 修改人姓名
        /// </summary>
        public string UpdateName { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
