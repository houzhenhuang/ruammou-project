using MyAttribute.AOPWay;
using MyAttribute.AttributeExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //People people = new People();
                //people.Id = 1;


                UserModel user = new UserModel();
                string name=user.TableName<UserModel>();
                Console.WriteLine(name);

                Console.WriteLine(CommonEnum.UserState.Normal.GetRemark());

                UnityAOP.Show();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
