using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Объявить матрицу сонара char[,] sonar размером 5x7.
            char[,] sonar = new char[5, 7];

            int rows = sonar.GetLength(0);
            int cols = sonar.GetLength(1);

            // 2. Заполнить матрицу символом спокойной толщи воды ~.
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sonar[i, j] = '~';
                }
            }

            // 3. Создать целочисленную матрицу depthMap 5x7 со значениями глубин (от 2000 до 6000 метров).
            Random rnd = new Random();

            int[,] depthMap = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    depthMap[i, j] = rnd.Next(2000, 6001);

                    Console.Write(depthMap[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // 4. Разместить батискаф S в центре карты [2, 3], а по периметру расставить 4 подводные скалы ^.
            sonar[2, 3] = 'S';

            sonar[0, 0] = '^';
            sonar[0, 6] = '^';
            sonar[4, 0] = '^';
            sonar[4, 6] = '^';

            // 5. Вывести карту сонара в консоль с форматированными отступами между столбцами.
            for (int i = 0; i < sonar.GetLength(0); i++)
            {
                for (int j = 0; j < sonar.GetLength(1); j++)
                {
                    if (sonar[i, j] == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(sonar[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(sonar[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }

            // 6. Найти минимальную глубину (мельчайшую точку рельефа) и вывести ее координаты.
            int mindepthMap = depthMap[0, 0];
            int minRow = 0;
            int minCol = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (depthMap[i, j] < mindepthMap)
                    {
                        mindepthMap = depthMap[i, j];
                        minRow = i;
                        minCol = j;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Минимальная глубина равна {mindepthMap}, а её местоположение [{minRow}, {minCol}]");

            // 7. Подсчитать среднюю глубину исследуемой акватории.
            // сначала сумма
            int SummdepthMap = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    SummdepthMap = SummdepthMap + depthMap[i, j];
                }
            }

            double DivDepth = (double)SummdepthMap / (rows * cols);

            Console.WriteLine($"Средняя глубина исследуемой акватории: {DivDepth:F2}");

            // 8. Подсчитать число препятствий ^ в крайних столбцах матрицы (столбцы 0 и 6).
            int summbarrier = 0;

            for (int i = 0; i < rows; i++)
            {
                if (sonar[i, 0] == '^')
                {
                    summbarrier++;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                if (sonar[i, 6] == '^')
                {
                    summbarrier++;
                }
            }
            Console.WriteLine($"Количество препятствий в крайних столбцах: {summbarrier}");
            Console.WriteLine();

            // 9. Реализовать пуск зонда: пользователь вводит координаты, программа меняет символ воды на * (сигнал эхолота).
            Console.Write("Введите номер строки от 0 до 4: ");
            bool pointRow = int.TryParse(Console.ReadLine(), out int row);

            Console.Write("Введите номер строки от 0 до 6: ");
            bool pointCol = int.TryParse(Console.ReadLine(), out int col);

            if (pointRow && pointCol)
            {
                if (row >= 0 && row < rows && col >= 0 && col < cols)
                {
                    sonar[row, col] = '*';
                }
            }

            for (int i = 0; i < sonar.GetLength(0); i++)
            {
                for (int j = 0; j < sonar.GetLength(1); j++)
                {
                    if (sonar[i, j] == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(sonar[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if (sonar[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(sonar[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(sonar[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine();

            // 10. Заполнить побочную диагональ матрицы символами рифа ^.
            Console.WriteLine("Заполнение побочной диагонали матрицы рифа ^.");

            for (int i = 0; i < rows; i++)
            {
                int j = cols - 1 - i;
                sonar[i, j] = '^';
            }

            for (int i = 0; i < sonar.GetLength(0); i++)
            {
                for (int j = 0; j < sonar.GetLength(1); j++)
                {
                    if (sonar[i, j] == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (sonar[i, j] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (sonar[i, j] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(sonar[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

        }
    }
}