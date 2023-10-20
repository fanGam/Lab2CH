namespace Lab2CH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Основной кусок истории
            Console.WriteLine("Вот Гоша сходил с друзьями в кино и они пошли гулять.\n" +
                "Пока они гуляли решили зайти в магазин за продуктами (и не только),\n" +
                "но есть проблема, Паше сложно даётся математика и ему нужна помощь посчитать.\n" +
                "В этот раз будем считать денюжки!");
            Console.WriteLine("Введите бюджет Гоши!");
            Money Gosha;
            Gosha = new Money(Console.ReadLine());
            Console.WriteLine($"Итого у Гоши есть {Gosha}\n" +
                $"Ему нужно купить немного вкусняшек чтобы угостить его друзей\n" +
                $"Вот список того что ему нужно купить:\n" +
                $"1) Колу\n" +
                $"2) Чипсы\n" +
                $"3) Шоколадку\n" +
                $"Напишите ценник продуктов!");

            Console.WriteLine("----------------------------------");

            //Покупка колы в магазине
            Console.WriteLine($"Цена колы:");
            Money Cola = new Money(Console.ReadLine());
            if (Gosha >= Cola)
            {
                if (Cola.GetAmount() == 0)
                {
                    Console.WriteLine("Видимо в магазине акция и кола бесплатная!");
                }
            }
            if (Gosha > Cola)
            {
                Gosha.PriceChange((-Cola.GetAmount()));
                Console.WriteLine($"Гоша купил колу себе и друзьям!" +
                    $"У него осталось!");
                Console.WriteLine($"{Gosha}");
            }
            else
            {
                Console.WriteLine("У Гоши не хватает денег для покупки Колы! :(");
            }

            //Находка копейки на полу
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Пока Гоша шёл за Чипсами он нашёл копеечку на полу и забрал её себе!");
            Console.WriteLine($"Теперь у него {++Gosha}");

            Console.WriteLine("----------------------------------");

            //Покупка чипсов
            Console.WriteLine("Цена чипсов:");
            Money Chips = new Money(Console.ReadLine());
            if (Gosha >= Chips)
            {
                if (Chips.GetAmount() == 0)
                {
                    Console.WriteLine("Видимо в магазине акция и чипсы бесплатные!");
                }
            }
            if (Gosha > Chips)
            {
                Gosha.PriceChange((-Chips.GetAmount()));
                Console.WriteLine($"Гоша купил чипсы себе и друзьям!\n" +
                    $"У него осталось!");
                Console.WriteLine($"{Gosha}");
            }
            else
            {
                Console.WriteLine("У Гоши не хватает денег для покупки Чипсов! :(");
            }

            Console.WriteLine("----------------------------------");

            //Помощь Гоше если у него нет денег
            if (Gosha.GetAmount() > 0.01)
            {
                Console.WriteLine("Пока Гоша шёл за шоколадкой он обронил найденную монетку\n" +
                    "Вот такой круговорот монет в магазине");
                Console.WriteLine($"Теперь у него {--Gosha}");
            }
            else
            {
                Console.WriteLine("Так как у Гоши не осталось денег то Паша решил ему помочь\n" +
                    "Сколько денег Паша дал Гоше");
                Money Pasha = new Money(Console.ReadLine());
                Gosha = Gosha + Pasha;
                Console.WriteLine($"Теперь у Гоши {Gosha}");
            }

            Console.WriteLine("----------------------------------");

            //Покупка шоколадки
            Console.WriteLine("Цена шоколадки:");
            Money Chokolate = new Money(Console.ReadLine());
            if (Gosha >= Chokolate)
            {
                if (Chokolate.GetAmount() == 0)
                {
                    Console.WriteLine("Видимо в магазине акция и шоколадка бесплатная!");
                }
            }
            if (Gosha >= Chokolate)
            {
                Gosha.PriceChange((-Chokolate.GetAmount()));
                Console.WriteLine($"Гоша купил шоколадку себе и друзьям!\n" +
                    $"У него осталось!");
                Console.WriteLine($"{Gosha}");
            }
            else
            {
                Console.WriteLine("У Гоши не хватает денег для покупки шоколадки! :(");
            }

            Console.WriteLine("----------------------------------");

            //Результат похода
            if (Gosha)
            {
                Console.WriteLine("После всей траты у Гоши ещё остались денюжки!");
                Console.WriteLine($"{Gosha}");
            }
            else
            {
                Console.WriteLine("Ну всё, Гоша остался без денег...");
                Console.WriteLine($"{Gosha}");
            }
        }
    }
}