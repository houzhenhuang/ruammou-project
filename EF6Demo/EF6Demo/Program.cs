using EF6Demo.CodeFirstDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Demo
{
    [Table("Program")]
    class Program
    {
        static void Main(string[] args)
        {
            using (CodeFirstDBContext context = new CodeFirstDBContext())
            {
                Company company=context.Company.Find(1);
            }
        }
    }
}
