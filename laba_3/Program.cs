using laba_3;
using System;
using System.Diagnostics;

namespace laba_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch(); 
            Storage<Object> my_storage = new Storage<Object>(50); //создаем массив с типа Object с размером 50
            time.Start(); 
            for (int i = 0; i < 10; i++) // рассматриваем весь массив
            {
                Random rd = new Random(); //рандом
                Console.WriteLine("(1) - добавление объектов в хранилище");
                Console.WriteLine("(2) - вызов методов объектов");
                Console.WriteLine("(3) - рандомное удаление объекта");
                int value = Convert.ToInt32(Console.ReadLine()); //ожидание ввода текста
                switch (value)
                {
                    case 1: // Добавление объектов в хранилище
                        Console.WriteLine("Обьекты добавлены в хранилище");
                        for (int j = 0; j < 10; j++) //добавляет 10 обектов 
                        {
                            if (rd.Next() % 2 == 0) // вызывает рандомное число и проверяет на четность
                                my_storage.addObj(new Point()); 
                            else
                                my_storage.addObj(new Animal());
                        }
                        break;
                    case 2: // Вызов методов объектов
                        Console.WriteLine("Вызов методов объектов");
                        for (int j = 0; j < my_storage.Size; j++) //проход по всему массиву, вызов у каждого обьекта и его метода
                            if (my_storage.getObj(j) != null)
                            {
                                Console.Write(j); Console.Write(" - ");
                                my_storage.getObj(j).show_param();
                            }
                        break;
                    case 3: // Рандомное удаление объекта
                        Console.WriteLine("Рандомное удаление объекта");
                        int randi = rd.Next(my_storage.Count); // рандомит одно число от 0 до Count
                        if (my_storage.getObj(randi) != null) 
                        {
                            Console.WriteLine($"Удален объект {my_storage.getObj(randi)} по индексу {randi}");
                            my_storage.deleteObj(randi);
                        }
                        else
                            Console.WriteLine("По данному индексу объекта нет");
                        break;
                    default:
                        break;
                }
            }
            time.Stop();
            Console.WriteLine($"Время работы программы: {time.Elapsed}");
            Console.ReadKey();
        }
    }
}
