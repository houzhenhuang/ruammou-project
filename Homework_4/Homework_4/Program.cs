using Factory.Abstract;
using Factory.FactoryMethod;
using Factory.SimpleFactory;
using Homework_4.Common.Serialize;
using Homework_4.IMenu;
using Homework_4.Menu.Service;
using Homework_4.OrderSystem.AbstractHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region 普通方法
                Console.WriteLine("*******************普通方法************************");
                {
                    PoHuPangYuTou menu = new PoHuPangYuTou();
                    menu.Show();
                }
                #endregion
                #region 简单工厂
                Console.WriteLine("*******************简单工厂************************");
                {
                    //Console.WriteLine("说明:请输入1-4:1、鄱湖胖鱼头 2、庐山石鸡 3、四星望月 4、藜蒿炒腊肉");
                    //while (true)
                    //{
                    //    Console.WriteLine("请点菜:");
                    //    int type = int.Parse(Console.ReadLine());
                    //    IMenuName menu = ObjectFactory.CreateInstance((MenuType)type);
                    //    menu.Show();
                    //    Console.WriteLine("是否继续点菜?(是：y,否：n)");
                    //    string str = Console.ReadLine();
                    //    if (str=="y")
                    //    {
                    //        continue;
                    //    }
                    //    else if (str=="n")
                    //    {
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("指令无效");
                    //    }
                    //}
                }
                #endregion
                #region 简单工厂+反射+配置文件
                Console.WriteLine("*******************简单工厂+反射+配置文件************************");
                {
                    IMenuName menuName = ObjectFactory.CreateInstance();
                    menuName.Show();
                }
                #endregion
                #region 工厂方法
                Console.WriteLine("*******************工厂方法************************");
                {
                    Factory.FactoryMethod.IMenu menu1 = new LiHaoChaoLaRouFactory();
                    IMenuName menuName1 = menu1.CreateInstance();
                    menuName1.Show();

                    Factory.FactoryMethod.IMenu menu2 = new SiXingWangYueFactory();
                    IMenuName menuName2 = menu2.CreateInstance();
                    menuName2.Show();
                }
                #endregion
                #region 抽象工厂
                Console.WriteLine("*******************抽象工厂************************");
                {
                    AbstractFactory factory = new AHunanCuisineFactory();
                    IMenuName menuName_1 = factory.CreateMenu_1();
                    menuName_1.Show();
                    IMenuName menuName_2 = factory.CreateMenu_2();
                    menuName_2.Show();
                    IMenuName menuName_3 = factory.CreateMenu_3();
                    menuName_3.Show();
                    ISapleFood sapleFood = factory.CreateSapleFood();
                    sapleFood.Show();
                    ISoup soup = factory.CreateSoup();
                    soup.Show();

                }
                #endregion
                #region 点菜系统
                Console.WriteLine("*******************点菜系统************************");
                {
                    //List<AbstractFood> foodList = new List<AbstractFood>() { 
                    //new Homework_4.OrderSystem.Service.LiHaoChaoLaRou(){Id=1,Name="藜蒿炒腊肉",Price=23,Desc="江西鄱阳特产"},
                    //new Homework_4.OrderSystem.Service.LuShanShiJi(){Id=2,Name="庐山石鸡",Price=23,Desc="江西鄱阳特产"},
                    //new Homework_4.OrderSystem.Service.PoHuPangYuTou(){Id=3,Name="鄱湖胖鱼头",Price=23,Desc="江西鄱阳特产"}
                    //};
                    //string jsonData = JsonHelper.ObjectToJson(foodList);
                }
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
