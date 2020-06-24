using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace Models
{
    public partial class EfCoreContext : DbContext
    {
        public EfCoreContext()
        {
        }

        /// <summary>
        /// 创建数据库上下文
        /// </summary>
        /// <param name="options"></param>
        public EfCoreContext(DbContextOptions<EfCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleMenu> ModuleMenu { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleModuleMenu> RoleModuleMenu { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        /// <summary>
        /// OnConfiguring()方法允许我们使用DbContextOptionsBuilder选择和配置要与上下文一起使用的数据源。在此处了解如何配置DbContext类。
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // 如果在appsettings.json文件中未配置数据库链接字符串，则这里可以直接连接数据库
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=CoreNotes.AutoFac;Trusted_Connection=True;");
            }
        }

        /// <summary>
        /// OnModelCreating()方法允许我们使用ModelBuilder Fluent API配置模型。
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.Action).IsUnicode(false);

                entity.Property(e => e.Area).IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Controller).IsUnicode(false);

                entity.Property(e => e.CreateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModuleMenu>(entity =>
            {
                entity.Property(e => e.CreateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.CreateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId).HasComment("接口id");

                entity.Property(e => e.UpdateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.CreateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleModuleMenu>(entity =>
            {
                entity.Property(e => e.CreateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Grade).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.LastErrTime).HasColumnType("datetime");

                entity.Property(e => e.LoginName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TrueName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Remark).IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.CreateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdateName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
