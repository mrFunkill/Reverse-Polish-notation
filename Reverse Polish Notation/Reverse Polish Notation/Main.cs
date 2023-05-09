using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
 
namespace Reverse_Polish_Notation
{
    class Menu
    {
        public static int Main(string[] args)//создание основного консольного меню программы с выбором действий
        {
            int menu = 0;
            
            while (menu!=2)
            {
                Console.Clear();
                Console.WriteLine("Выберете один из следующих вариантов: \n 1. Ввод данных  \n 2. Закрыть программу");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Введите выражение:");
                        string expression = Console.ReadLine();
                        Console.WriteLine(Algorithm.GetExpression(expression));
                        Console.WriteLine("Нажмите клавиши, чтобы продолжить...");
                        Console.ReadKey();
                        break;
                    case 2:
                        break;
                    default:
                        Console.Write("Неправильный ввод");
                        Console.ReadKey();
                        break;
                }
            }
            return 0;
        }
            


    }
}