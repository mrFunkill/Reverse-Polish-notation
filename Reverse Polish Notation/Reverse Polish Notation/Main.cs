﻿using System;
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

            string menu = string.Empty;
            string expression = string.Empty;
            while (menu!="3")
            {
                Console.Clear();
                Console.WriteLine("Выберете один из следующих вариантов: \n 1. Обратная польская запись через стэк  \n 2. Обратная польская запись деревом \n 3. Закрыть программу");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Console.Clear();
                        if (FileReader.Read() != null) {
                            expression = AlgorithmStack.GetExpression(FileReader.Read());
                            Console.WriteLine("Обратная запись:" + expression);
                            Console.WriteLine("Результат вычисления:" + AlgorithmStack.Calculate(expression));
                        }
                        else Console.WriteLine("Файл пустой");
                        Console.WriteLine("Нажмите клавиши, чтобы продолжить...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        if (FileReader.Read() != null)
                        { 
                            Console.WriteLine("Обратная запись:" + AlgorithmTree.ConvertToReversePolishNotationString(FileReader.Read()));
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Файл пустой");
                        Console.WriteLine("Нажмите клавиши, чтобы продолжить...");
                        Console.ReadKey();
                        break;
                    case "3":
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