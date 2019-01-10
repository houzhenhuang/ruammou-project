using MyAbstract.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstract
{
    public class People 
    {
        public int Id { get;set;}
        public string Name { get; set; }
    }
    public class Student:People
    {
        private int Tall { get; set; }
        public void PlayLumia(Lumia lumia) 
        {
            Console.WriteLine("");
        }

    }
}
