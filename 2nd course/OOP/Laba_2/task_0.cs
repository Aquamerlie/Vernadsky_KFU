using System;

namespace Laba_2._0
{

    class Silka
    {
        public int A { get; set; }

        public void Print()
        {
            Console.WriteLine("Ссылка работает: " + A);
        }
    }
    class Conv
    {
        // (5) Пользовательское преобразование типов Implicit, Exsplicit
        public int B { get; set; }
        // Неявное преобразование
        public static implicit operator Conv(int x)
        {
            return new Conv { B = x };
        }
        // Явное преобразование
        public static explicit operator int(Conv conv)
        {
            return conv.B;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   /*ТАБЛИЦА НЕЯВНЫЙ ПРЕОБРАЗОВАНИЙ
             *sbyte -> short,int,long,float,double,decimal,nint;
             *byte -> short,ushort,int,uint,long,ulong,float,double,decimal,nint,nuint;
             *short -> int,long,float,double,decimal,nint;
             *ushort -> int,uint,long,ulong,float,double,decimal,nint,nuint;
             *int -> long,float,double,decimal,nint;
             *uint -> long,ulong,float,double,decimal,nuint;
             *long -> float,double,decimal;
             *ulong -> float,double,decimal;
             *float -> double;
             *nint -> long,float,double,decimal;
             *nuint -> ulong,float,double,decimal;
            */
            // (1) Неявное преобразование простых типов
            byte a = 2;
            double b = a + 0.6;
            Console.WriteLine("Неявное простое: " + b);
            // (1) Неявное преобразование ссылочного типов
            object obj = new Silka { A = 7};
            

            /*ТАБЛИЦА ЯВНЫХ ПРЕОБРАЗОВАНИЙ
             *sbyte -> byte,ushort,uint,ulong,nuint;
             *byte -> sbyte;
             *short -> sbyte,byte,ushort,uint,ulong,nuint;
             *ushort -> sbyte,byte,short;
             *int -> sbyte,byte,short,ushort,uint,ulong,nuint;
             *uint -> sbyte,byte,short,ushort,int;
             *long -> sbyte,byte,short,ushort,int,uint,ulong,nint,nuint;
             *ulong -> sbyte,byte,short,ushort,int,uint,longn,nint,nuint;
             *float -> sbyte,byte,short,ushort,int,uint,long,ulong,decimal,nint,nuint;
             *double -> sbyte,byte,short,ushort,int,uint,long,ulong,float,decimal,nint,nuint;
             *decimal -> sbyte,byte,short,ushort,int,uint,long,ulong,float,double,nint,nuint;
             *nint -> sbyte,byte,short,ushort,int,uint,long,ulong,nuint;
             *nuint -> sbyte,byte,short,ushort,int,uint,long,ulong,nint;
             *
             */
            // (2) Явное преобразование простых типов
            double t = 3.8;
            int d = (int)t;
            Console.WriteLine("Явное простое:" + d);
            // (2) Явное преобразование ссылочного типов
            Silka silka = (Silka)obj;
            silka.Print();


            // (3) Вызвал и обработал исключение преобразования типов
            try
            {
                t = Convert.ToDouble("s");   
            }
            catch
            {
                Console.WriteLine("Исключение");
            }

            // (5) Пользовательское преобразование типов Implicit, Exsplicit
            Conv conv1 = new Conv { B = 9 };
            int x = (int)conv1;    // Явное
            Conv conv2 = x;    // Неявное


            /* (6) Преобрахование с помощью класса Convert и преобразование строки в число с помощью методов
                Parse,TryParse класса System.int32.*/
            string str = "7";
            int c = Convert.ToInt32(str);
            int C = c + 1;
            Console.WriteLine(C);
            

            int i = int.Parse(str);
            int I = i + 2;
            Console.WriteLine(I);
            
            int g;
            int.TryParse(str, out g);
            int G = g + 3;
            Console.WriteLine(g);

            //
            SafelyAS(obj);
            SafelyIS(obj);
        }   
        // (4) Безопасное приведение с помощью as
        static void SafelyAS(object obj)
        {
            Silka silka = obj as Silka;
            
            if (silka != null)
            {
                silka.Print();
            }
        }
        // (4) Безопасное приведение с помощью is
        static void SafelyIS(object obj)
        {
            if (obj is Silka)
            {
                Silka silka = (Silka)obj;
                silka.Print();
            }
        }
    }

}
