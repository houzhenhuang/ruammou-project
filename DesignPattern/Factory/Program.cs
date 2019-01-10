using Factory.Abstract;
using Factory.FactoryMethod;
using Factory.SimpleFactory;
using FactoryPattern.AskAvenue.Interface;
using FactoryPattern.AskAvenue.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("****************************简单工厂*********************************");
                #region 简单工厂
                {
                    //Gold gold=new Gold ();
                    //gold.Show();//这种方式也可以，但是没有遵循依赖倒置原则，使得我们的上端依赖于细节
                }
                {
                    //IFactions gold =new Gold//我们的上端不能依赖详细，所以我们可以把右边创建对象的操作分离出去
                    //gold.Show();
                }
                {
                    IFactions gold = ObjectFactory.CreateInstance(ObjectFactory.FactionsType.Wood);//我们的上端不能依赖详细，所以我们可以把右边创建对象的操作分离出去
                    gold.Show();
                }
                #endregion
                Console.WriteLine("****************************工厂方法*********************************");
                #region 工厂方法
                //从简单工厂我们可以看到，虽然我们上端遵循了依赖倒置原则，但是工厂内部严重违背了单一职责原则和开闭原则
                //这时我们就想到了工厂方法(顾名思义，将简单工厂创建对象进行分离)
                {
                    IFactoryMethod factoryMethod = new WaterFactory();
                    IFactions water = factoryMethod.CreateInstance();
                    water.Show();
                }



                #endregion
                Console.WriteLine("****************************抽象工厂*********************************");
                #region 抽象工厂
                {
                    AbstractFactory goldFactory = new AGoldFactory();
                    IAuxiliarySkill auxiliarySkill= goldFactory.CreateAuxiliarySkill();
                    auxiliarySkill.ShowAllSkill();
                    IObstacleSkill obstacleSkill = goldFactory.CreateObstacleSkill();
                    obstacleSkill.ShowAllSkill();
                }
                {
                    AbstractFactory woodFactory = new AWoodFactory();
                    IAuxiliarySkill auxiliarySkill = woodFactory.CreateAuxiliarySkill();
                    auxiliarySkill.ShowAllSkill();
                    IObstacleSkill obstacleSkill = woodFactory.CreateObstacleSkill();
                    obstacleSkill.ShowAllSkill();
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
