using System;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class EfCoreContext: DbContext
    {
        /// <summary>
        /// 创建数据库上下文
        /// </summary>
        /// <param name="options"></param>
        public EfCoreContext(DbContextOptions options): base(options)
        {
        }

        /// <summary>
        /// OnConfiguring()方法允许我们使用DbContextOptionsBuilder选择和配置要与上下文一起使用的数据源。在此处了解如何配置DbContext类。
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        /// <summary>
        /// OnModelCreating()方法允许我们使用ModelBuilder Fluent API配置模型。
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        #region 实体

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        #endregion
    }
}
