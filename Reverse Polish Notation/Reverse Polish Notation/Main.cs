using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Reverse_Polish_Notation
{
    class Menu
    {
        public static int Main(string[] args)//создание основного консольного меню программы с выбором действий
        {
            int menu = 0;
            Algorithm algorithm;
            Console.WriteLine("Выберете один из следующих вариантов: \n 1. Ввод данных вручную \n 2. Считывание из файла  \n 3. Закрыть программу");
            while (menu!=3)
            {
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        string val = Console.ReadLine();
                        algorithm = new(val);
                        Console.WriteLine("Постфиксная форма: " + algorithm.postfixExpr);
                        Console.WriteLine("Итого: " + algorithm.Calc());
                        break;
                    case 2:
                        break;
                    case 3:
                        break;

                }
            }
            return 0;
        }
            


    }
}