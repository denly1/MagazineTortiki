using System;
using System.Collections.Generic;
using System.IO;

namespace Tortiki
{
    public class CakeOrder
    {
        private string form;
        private string size;
        private string flavor;
        private int quantity;
        private string glaze;
        private string decor;
        private decimal price;

        public void MakeOrder()
        {
            Console.WriteLine("Приветствую вас в магазине тортиков");

            do
            {
                Console.Clear();
                Console.WriteLine(" Главное меню:");
                Console.WriteLine("   Выбрать форму торта");
                Console.WriteLine("   Выбрать размер торта");
                Console.WriteLine("   Выбрать вкус торта");
                Console.WriteLine("   Ввести количество");
                Console.WriteLine("   Выбрать глазурь");
                Console.WriteLine("   Выбрать украшение");
                Console.WriteLine("   Завершить заказ");
                Console.WriteLine("   Выход");

                int choice = Strelki.GetChoice(1, 8);

                switch (choice)
                {
                    case 1:
                        form = ChooseForm();
                        break;
                    case 2:
                        size = ChooseSize();
                        break;
                    case 3:
                        flavor = ChooseFlavor();
                        break;
                    case 4:
                        quantity = EnterQuantity();
                        break;
                    case 5:
                        glaze = ChooseGlaze();
                        break;
                    case 6:
                        decor = ChooseDecor();
                        break;
                    case 7:
                        price = CalculatePrice();
                        SaveOrder();
                        ShowSummary();
                        break;
                    case 8:
                        return;
                }
            } while (true);
        }

        private string ChooseForm()
        {
            Console.Clear();
            Console.WriteLine("Выберите форму торта:");
            Console.WriteLine("  Круглая - 500");
            Console.WriteLine("  Квадратная - 500");
            Console.WriteLine("  В форме сердца - 500");

            int choice = Strelki.GetChoice(1, 3);

            switch (choice)
            {
                case 1:
                    return "Круглая";
                case 2:
                    return "Квадратная";
                case 3:
                    return "В форме сердца";
                default:
                    return "";
            }
        }

        private string ChooseSize()
        {
            Console.Clear();
            Console.WriteLine("Выберите размер торта:");
            Console.WriteLine("   Маленький - 200");
            Console.WriteLine("   Средний - 350");
            Console.WriteLine("   Большой - 500");

            int choice = Strelki.GetChoice(1, 3);

            switch (choice)
            {
                case 1:
                    return "Маленький";
                case 2:
                    return "Средний";
                case 3:
                    return "Большой";
                default:
                    return "";
            }
        }

        private string ChooseFlavor()
        {
            Console.Clear();
            Console.WriteLine("Выберите вкус торта:");
            Console.WriteLine("   Шоколадный - 100");
            Console.WriteLine("   Ванильный - 100");
            Console.WriteLine("   Клубничный - 100");

        int choice = Strelki.GetChoice(1, 3);

            switch (choice)
            {
                case 1:
                    return "Шоколадный";
                case 2:
                    return "Ванильный";
                case 3:
                    return "Клубничный";
                default:
                    return "";
            }
        }

            private int EnterQuantity()
            {
                Console.Clear();
                Console.Write("Введите количество: ");
                string quantityInput = Console.ReadLine();

                int quantity;
                while (!int.TryParse(quantityInput, out quantity))
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите действительное количество.");
                    Console.Write("Введите количество: ");
                    quantityInput = Console.ReadLine();
                }

                return quantity;
            }

            private string ChooseGlaze()
            {
                Console.Clear();
            Console.WriteLine("Выберите глазурь:");
            Console.WriteLine("   Шоколад - 100");
            Console.WriteLine("   Ванильный - 100");
            Console.WriteLine("   Фруктовая - 100");

            int choice = Strelki.GetChoice(1, 3);

                switch (choice)
                {
                    case 1:
                        return "Шоколад";
                    case 2:
                        return "Ваниль";
                    case 3:
                        return "Фрукты";
                    default:
                        return "";
            }
        }

        private string ChooseDecor()
        {
            Console.Clear();
            Console.WriteLine("Выберите декор:");
            Console.WriteLine("   Посыпка - 50");
            Console.WriteLine("   Фрукты 50");
            Console.WriteLine("   Цветы - 50");

            int выбор = Strelki.GetChoice(1, 3);

            switch (выбор)
            {
                case 1:
                    return "Посыпка";
                case 2:
                    return "Фрукты";
                case 3:
                    return "Цветы";
                default:
                    return "";
            }
        }

        private decimal CalculatePrice()
        {

            int formPrice = 500; int sizePrice = 450; int glazePrice = 300; int decorPrice = 50; int flavorPrice = 100;
            decimal totalPrice = (formPrice + sizePrice + glazePrice + decorPrice + flavorPrice) * quantity;

            return totalPrice;
        }

        private void SaveOrder()
        {
            string orderDetails = $"Form: {form}\nSize: {size}\nFlavor: {flavor}\nQuantity: {quantity}\nGlaze: {glaze}\nDecor: {decor}\nPrice: {price}";

            using (StreamWriter writer = new StreamWriter("orderHistory.txt", true))
            {
                writer.WriteLine(orderDetails);
            }
        }

        private void ShowSummary()
        {
            Console.Clear();
            Console.WriteLine("Краткое описание заказа:");
            Console.WriteLine($"Форма: {form}");
            Console.WriteLine($"Размер: {size}");
            Console.WriteLine($"Вкус: {flavor}");
            Console.WriteLine($"Количество: {quantity}");
            Console.WriteLine($"Глазурь: {glaze}");
            Console.WriteLine($"Декор: {decor}");
            Console.WriteLine($"Цена: {price}");
            Console.WriteLine("Спасибо за ваш заказ!");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");

            Console.ReadKey();
        }
    }



    public class Strelki
    {
        public static int GetChoice(int min, int max)
        {
            int pos = 1;
            ConsoleKeyInfo key;

            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                key = Console.ReadKey();
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != min)
                {
                    pos--;
                }
                if (key.Key == ConsoleKey.DownArrow && pos != max)
                {
                    pos++;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }
            } while (key.Key != ConsoleKey.Enter);

            return pos;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CakeOrder cakeOrder = new CakeOrder();
            cakeOrder.MakeOrder();
        }
    }
}
