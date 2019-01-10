using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decorator
{
    public class StudentDesignDecorator : BaseStudentDecorator
    {
        public StudentDesignDecorator(AbstractStudent student)
            : base(student)
        {

        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("{0}在学习框架设计", base.Name);
        }
    }
}
