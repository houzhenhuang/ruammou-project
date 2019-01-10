using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ExpressionTest.Show();
                ExpressionVisitorTest.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }
    }
}
