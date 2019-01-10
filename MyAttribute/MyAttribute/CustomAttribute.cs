using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute() { }
        public CustomAttribute(int id) { }
        public CustomAttribute(string name) { }
        public CustomAttribute(int id, string name) { }

        public string Remark { get; set; }

        public string Description = null;
    }
    public class CustomChildAttribute : CustomAttribute
    {

    }

    public class TableAttribute : Attribute
    {
        private string _tableName = null;

        public TableAttribute(string tableName)
        {
            this._tableName = tableName;
        }

        public string GetTableName()
        {
            return this._tableName;
        }
    }
}
