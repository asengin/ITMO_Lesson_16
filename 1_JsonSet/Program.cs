using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrarys;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace _1_JsonSet
{
    class Program
    {
        /* Решение задачи:
         * Создан класс Product отдельной dll, прикручен к проекту.
         * В цикле заполняем массив продуктов arrayProduct из экземпляров класса Product через конструктор.
         * В блоке ввода данных реализована обработка исключений.
         * Сериализация массива arraProduct с опциями красивого отображения и кириллическими символами.
         * Сохранение json файла в корневой каталог решения.
         */

        static void Main(string[] args)
        {
            const sbyte count = 5;
            Product[] arrayProduct = new Product[count];
            Console.WriteLine("\t Ввод элементов товаров");
            try
            {
                for (int i = 0; i < count; i++) //формирование массива товаров
                {
                    Console.Write($"Введите ID {i + 1}-го товара: ");
                    uint id = Convert.ToUInt32(Console.ReadLine());
                    Console.Write($"Введите наименование {i + 1}-го товара: ");
                    string name = Console.ReadLine();
                    Console.Write($"Введите стоимость {i + 1}-го товара: ");
                    double cost = Convert.ToDouble(Console.ReadLine());
                    arrayProduct[i] = new Product(id, name, cost);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка ввода: {ex.Message}");
                Console.ReadKey();
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,         //Подключаем опцию pretty print
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };  //и кириллические символы
            string outputString = JsonSerializer.Serialize(arrayProduct, options);

            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(outputString);
            }
        }
    }
}
