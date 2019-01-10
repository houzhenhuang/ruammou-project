using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Decorator
{
    public class BaseStudentDecorator:AbstractStudent
    {  
        private AbstractStudent _student = null;
        public BaseStudentDecorator(AbstractStudent student) 
        {
            this._student = student;
            this.Name = _student.Name;
        }
        public override void Show()
        {
            this._student.Show();
        }
    }
}
