using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrarys;
using System.Text.Json;

namespace _2_JsonGet
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = string.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                inputString = sr.ReadToEnd();
            }
            //Console.WriteLine(inputString); // выводится, ОК
            //Console.ReadKey();
            Product[] arrayProduct = JsonSerializer.Deserialize<Product[]>(inputString);

            Product maxCostProduct = arrayProduct[0];
            Console.WriteLine("\t Элементы массива:\nID\tНазвание\tСтоимость\n");
            foreach (Product i in arrayProduct)
            {
                if (i.Cost > maxCostProduct.Cost)
                    maxCostProduct = i;
                Console.WriteLine($"{i.Id,2}{i.Name,15}\t{i.Cost}");
            }
            Console.WriteLine($"\nСамый дорогой продукт {maxCostProduct.Name}, стоимость: {maxCostProduct.Cost}");
            Console.ReadKey();
        }
    }
}
