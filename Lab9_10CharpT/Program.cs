using System;
using System.Collections;
using System.IO;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
       
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Лабораторна робота №9: Колекції ===");
                Console.WriteLine("1. Завдання 1.4 (Stack: Перевірка зворотності рядків)");
                Console.WriteLine("2. Завдання 2.4 (Queue: Позитивні та негативні числа)");
                Console.WriteLine("3. Завдання 3 (ArrayList: Переробка завдань 1 та 2)");
                Console.WriteLine("4. Завдання 4 (Hashtable: Музичний каталог)");
                Console.WriteLine("0. Вихід");
                Console.Write("\nОберіть номер завдання: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1_4();
                        break;
                    case "2":
                        Task2_4();
                        break;
                    case "3":
                        Task3();
                        break;
                    case "4":
                        Task4();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }

        // --- Завдання 1.4: Стек ---
        static void Task1_4()
        {
            Console.WriteLine("\n--- Виконання завдання 1.4 (Stack) ---");
            Console.Write("Введіть рядок s1: ");
            string s1 = Console.ReadLine();
            Console.Write("Введіть рядок s2: ");
            string s2 = Console.ReadLine();

            if (s1.Length != s2.Length)
            {
                Console.WriteLine("Результат: s2 НЕ є зворотною s1 (різна довжина).");
                return;
            }

            Stack stack = new Stack();
            foreach (char c in s1) stack.Push(c);

            bool isReverse = true;
            foreach (char c in s2)
            {
                if (!c.Equals(stack.Pop()))
                {
                    isReverse = false;
                    break;
                }
            }

            Console.WriteLine(isReverse ? "Результат: s2 є зворотною s1." : "Результат: s2 НЕ є зворотною s1.");
        }

        // --- Завдання 2.4: Черга ---
        static void Task2_4()
        {
            Console.WriteLine("\n--- Виконання завдання 2.4 (Queue) ---");
            string path = "numbers.txt";
            File.WriteAllText(path, "12 -7 5 -3 0 18 -10");

            Queue negatives = new Queue();
            try
            {
                string[] numbers = File.ReadAllText(path).Split(' ');
                Console.Write("Позитивні (в порядку появи): ");
                foreach (string s in numbers)
                {
                    int n = int.Parse(s);
                    if (n >= 0) Console.Write(n + " ");
                    else negatives.Enqueue(n);
                }

                Console.Write("\nНегативні (в порядку появи): ");
                while (negatives.Count > 0)
                {
                    Console.Write(negatives.Dequeue() + " ");
                }
                Console.WriteLine();
            }
            catch (Exception ex) { Console.WriteLine("Помилка файлу: " + ex.Message); }
        }

        // --- Завдання 3: ArrayList ---
        static void Task3()
        {
            Console.WriteLine("\n--- Виконання завдання 3 (ArrayList) ---");

            ArrayList list = new ArrayList();
            string s1 = "level";
            foreach (char c in s1) list.Add(c);
            list.Reverse();
            string s2 = "";
            foreach (char c in list) s2 += c;
            Console.WriteLine($"Рядок '{s1}' у зворотному порядку через ArrayList: {s2}");

           
            ArrayList allNumbers = new ArrayList { 5, -2, 10, -8, 3 };
            Console.Write("Спочатку позитивні, потім негативні: ");
            foreach (int n in allNumbers) if (n >= 0) Console.Write(n + " ");
            foreach (int n in allNumbers) if (n < 0) Console.Write(n + " ");
            Console.WriteLine();
        }

        // --- Завдання 4: Хеш-таблиця (Каталог) ---
        static void Task4()
        {
            Console.WriteLine("\n--- Виконання завдання 4 (Hashtable) ---");
            Hashtable catalog = new Hashtable();

            catalog["Classic Rock"] = new ArrayList { "Bohemian Rhapsody", "Stairway to Heaven" };
            catalog["Jazz Hits"] = new ArrayList { "Take Five", "Summertime" };

            Console.WriteLine("Вміст каталогу:");
            foreach (DictionaryEntry de in catalog)
            {
                Console.WriteLine($"Диск: {de.Key}");
                foreach (string song in (ArrayList)de.Value)
                    Console.WriteLine($"  - {song}");
            }

           
            string search = "Jazz Hits";
            if (catalog.Contains(search))
                Console.WriteLine($"\nДиск '{search}' знайдено в каталозі.");
        }
    }
}