using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuceneProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LuceneTest.InitIndex();
                LuceneTest.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
