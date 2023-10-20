using System.ComponentModel;
using System.Data.Common;

namespace Lab2CH
{
    public class Money
    {
        //Закрытые поля нужных типов
        private uint rubles;
        private byte kopeiki;
        //Свойства которые дают только чтение
        public uint ruble
        {
            get { return rubles; }
        }

        public byte kopeika
        {
            get { return kopeiki; }
        }
        //Базовый конструктор
        public Money()
        {
            rubles = 0;
            kopeiki = 0;
        }
        //Конструктор копии
        public Money(Money obj)
        {
            this.rubles = obj.ruble;
            this.kopeiki = obj.kopeika;
        }
        //Конструктор если пользователь ввёл рубли и копейки отдельно
        public Money(int a, int b) : this()
        {
            rubles = (uint)Math.Abs(a + (b / 100));
            kopeiki = (byte)(Math.Abs(b) % 100);
        }
        //Конструктор если пользователь ввёл числом типа double
        public Money(double a) : this()
        {
            rubles = (uint)Math.Abs(a);
            kopeiki = (byte)(Math.Abs(a * 100) % 100);
        }
        //Конструктор если пользователь ввёл текстом (основной)
        public Money(string a) : this()
        {
            if (a == "")
            {
                kopeiki = 0;
                rubles = 0;
            }
            else
            {
                a = a.Replace('.', ',');
                try
                {
                    int b;
                    b = (int)(double.Parse(a) * 100);
                    if (kopeiki + b < 0)
                    {
                        kopeiki = 0;
                        rubles = 0;
                    }
                    else
                    {
                        rubles = (uint)(b) / 100;
                        kopeiki = (byte)(b % 100);
                    }
                }
                catch (System.FormatException)
                {
                    ConsoleColor tmp1 = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nКажется кто-то не умеет писать циферки :(");
                    Console.ForegroundColor = tmp1;
                }
            }
        }
        //Фукция которая возвращает баланс кошелька в типе double
        public double GetAmount()
        {
            return (rubles + (double)kopeiki / 100);
        }
        //Метод изменения цены при входных типа <string>
        public void PriceChange(string a)
        {
            if (a != "")
            {
                a = a.Replace('.', ',');
                try
                {
                    int b, c;
                    b = (int)(double.Parse(a) * 100);
                    c = (int)(rubles * 100 + kopeiki);
                    if (kopeiki + b < 0)
                    {
                        kopeiki = 0;
                        rubles = 0;
                    }
                    else
                    {
                        rubles = (uint)(kopeiki + b) / 100;
                        kopeiki = (byte)((c + b) % 100);
                    }
                }
                catch (System.FormatException)
                {
                    ConsoleColor tmp1 = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nКажется кто-то не умеет писать циферки :(");
                    Console.ForegroundColor = tmp1;
                    rubles = 0;
                    kopeiki = 0;
                }
            }
        }
        //Метод изменения цены при входных типа <double>
        public void PriceChange(double a)
        {
            double b = rubles + (double)kopeiki / 100;
            if (b + a < 0)
            {
                kopeiki = 0;
                rubles = 0;
            }
            else
            {
                rubles = (uint)(b + a);
                kopeiki = (byte)(((b + a) * 100) % 100);
            }
        }
        //Переопределение операторов ++, --, +, -, >, <, >=, <=, ==, !=.
        public static Money operator ++(Money obj)
        {
            obj.PriceChange(0.01);
            return obj;
        }
        public static Money operator --(Money obj)
        {
            obj.PriceChange(-0.01);
            return obj;
        }
        public static Money operator +(Money obj1, Money obj2)
        {
            Money obj3 = new Money(obj1);
            obj3.PriceChange(obj2.GetAmount().ToString());
            return obj3;
        }
        public static Money operator -(Money obj1, Money obj2)
        {
            Money obj3 = new Money(obj1);
            obj3.PriceChange(obj2.GetAmount().ToString());
            return obj3;
        }
        public static bool operator <(Money obj1, Money obj2)
        {
            return (obj1.GetAmount() < obj2.GetAmount());
        }
        public static bool operator >(Money obj1, Money obj2)
        {
            return (obj1.GetAmount() > obj2.GetAmount());
        }
        public static bool operator <=(Money obj1, Money obj2)
        {
            return (obj1.GetAmount() <= obj2.GetAmount());
        }
        public static bool operator >=(Money obj1, Money obj2)
        {
            return (obj1.GetAmount() >= obj2.GetAmount());
        }
        public static bool operator ==(Money obj1, Money obj2)
        {
            return (obj1.GetAmount() == obj2.GetAmount());
        }
        public static bool operator !=(Money obj1, Money obj2)
        {
            return (obj1.GetAmount() != obj2.GetAmount());
        }
        //Операции приведения типа uint для копеек и bool для баланса
        public static explicit operator uint(Money obj)
        {
            return obj.kopeika;
        }
        public static implicit operator bool(Money obj)
        {
            return obj.GetAmount() != 0;
        }
        //Переопределение метода ToString()
        public override string ToString()
        {
            return $"{rubles} рублей и {kopeiki} копеек";
        }
    }
}
