namespace Ioc.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SysUser
    {
        [Table("SysUser")]
        public SysUser()
        {
            this.SysUserRole = new HashSet<SysUserRole>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TrueName { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public string QQ { get; set; }
        public string OtherContact { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }
        public Nullable<bool> State { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Marital { get; set; }
        public string Political { get; set; }
        public string Nationality { get; set; }
        public string School { get; set; }
        public string Professional { get; set; }
        public string Degree { get; set; }
        public int DepartmentId { get; set; }
        public int PostId { get; set; }
        public string JobState { get; set; }
        public string Photo { get; set; }
        public string Attach { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<int> Creator { get; set; }

        public virtual ICollection<SysUserRole> SysUserRole { get; set; }
    }
}

