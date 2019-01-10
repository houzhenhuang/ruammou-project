using DecoratorPattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AbstractStudent student = new StudentVip()
                {
                    Id = "1001",
                    Name = "tom"
                };
                {
                    //student.Show();
                }
                {
                    student = new BaseStudentDecorator(student);
                    student = new StudentCoreDecorator(student);
                    student = new StudentDesignDecorator(student);
                    student.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
