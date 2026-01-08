using System;
using System.Collections.Generic;
using System.Linq;

namespace main2
{
    class Program2
    {
        public static void Main()
        {
            int CountAttempts = 0;
            List<int> historyNum = new List<int>();
            
            Random rnd = new Random();
            int rnd2 = rnd.Next(1, 101);
            bool isGameWon = false;
            int maxAttempts = 10;

            while (CountAttempts < maxAttempts && !isGameWon)
            {
                CountAttempts++;

                Console.Write("Предположительное число: ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    historyNum.Add(num);

                    int difference = Math.Abs(rnd2 - num);

                    if(num == rnd2)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"ПОБЕДА! Угадал за {CountAttempts} попыток!");
                        ShowHistory(historyNum);
                        isGameWon = true;
                        return;
                    }
                    else if (difference <= 5)
                    {
                        Console.WriteLine("Кипит! Почти угадал!");
                    }
                    else if (difference <= 15)
                    {
                        Console.WriteLine("Горячо! Уже близко!");
                    }
                    else if (difference <= 30)
                    {
                        Console.WriteLine("Тепло! Далёковато");
                    }
                    else
                    {
                        Console.WriteLine("Холодно! Совсем мимо");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка!! Введите число");
                }
            }
            if (!isGameWon)
            {
                Console.WriteLine("Закончились попытки");
                Console.WriteLine($"Загаданное число было: {rnd2}");
                ShowHistory(historyNum);
            }
        }

        public static void ShowHistory(List<int> historyNum)
        {
            Console.WriteLine("====История попыток====");
            for(int i = 0; i < historyNum.Count; i++)
            {
                Console.WriteLine($"Попытка №{i}: {historyNum[i]}");
            }
        }
    }
}