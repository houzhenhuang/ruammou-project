namespace Ioc.EF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PerManagerContext : DbContext
    {
        public PerManagerContext()
            : base("name=PerManagerSystemDBEntities")
        {

        }

        public virtual DbSet<SysRole> SysRole { get; set; }

        public virtual DbSet<SysUser> SysUser { get; set; }

        public virtual DbSet<SysUserRole> SysUserRole { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
