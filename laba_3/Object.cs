using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_3
{
    abstract public class Object //абстрактный класс
    {
        public Object() { }
        virtual public void show_param()
        {
            Console.WriteLine("Элемент не найден");
        }

        ~Object() { } //деструктор
    }


    public class Animal : Object
    {
        private string sound;

        public Animal()
        {
            sound = "grrrr";
        }

        public Animal(string sound)
        {
            this.sound = sound;
        }

        override public void show_param()
        {
            Console.WriteLine("This is a animal");
        }

        ~Animal() { }
    }

    public class Point : Object
    {
        private int x;
        private int y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void add_point(int dx, int dy)
        {
            x = x + dx;
            y = y + dx;
        }

        public override void show_param()
        {
            Console.WriteLine("This is a point");
        }

        ~Point() { }
    }
}
