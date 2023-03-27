using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_3
{
    public class Storage<T> // Т - шаблон, который будет иметь тип, который мы укажем
    {
        private T[] arr; // массив типа Т
        private int size; //размер массива
        private int count; //кол-во занятых в массиве обьектов

        public Storage()
        {
            size = 0;
            arr = new T[size];
            count = 0;
        }

        public Storage(int size)
        {
            this.size = size;
            arr = new T[size];
            count = 0;
        }

        public T getObj(int pl) // возращает обьект под индексом
        {
            if (arr[pl] != null) // если в массиве данный обьект есть, то возращает его
            {
                return arr[pl];
            }
            else { return default(T); } // иначе NULL
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
        public int Size
        {
            get
            {
                return size;
            }
        }

        public void resize(int new_size) //увеличивает размер массива 
        {
            T[] tmp_arr = new T[size]; //создаем новый массив с изначальным размером
            for (int i = 0; i < size; i++) // копирует из старого в новый
            {
                tmp_arr[i] = arr[i];
            }
            arr = new T[new_size]; //создаем увеличенный массив, в то время, как старый обьект удалился, но сохранили в tmp_arr
            for (int i = 0; i < size; i++)
            {
                arr[i] = tmp_arr[i]; //копируем в него новый массив
            }
            size = new_size; 
        }

        public void addObj(T obj) //добавление в массив обьект
        {
            int i;
            for (i = 0; i < size; i++)
            {
                if (arr[i] == null) //если в массиве по индексу i нет обьекта, то мы его туда добавляет
                {
                    arr[i] = obj;
                    count++;
                    break;
                }
            }
            if (i == size) //если прошли до конца массива, то увеличиваем его размер и помещаем туда обьект
            {
                resize(size + 10);
                setObj(i + 1, obj);
            }
        }

        private void setObj(int i, T Obj) //добавление обьекта по индексу
        {
            count++;
            arr[i] = Obj;
        }

        public void deleteObj(int index) // удаление обькта по индексу 
        {
            if (size > 0) //чтобы не выходил за границу массива
            {
                if (index <= size)
                {
                    count--;
                   T[] tmp_arr = new T[size]; //создаем пустой массив с типом Т
                    for (int i = 0, j = 0; i < count + 1; i++) // 
                    {
                        if (i != index) //если индекс исходного массива не равен переданному ижексу(который нужно удалить)
                        {
                            tmp_arr[j] = arr[i]; // помещаем в массив обьект из исходного массива
                            j++; //увелмчивает индекс для массива tmp_arr
                        }
                    }
                    arr = tmp_arr;
                }
                else
                    Console.WriteLine("Индекс больше чем размер хранилища");
            }
            else Console.WriteLine("В хранилище больше нет объектов");
        }

    }
}
