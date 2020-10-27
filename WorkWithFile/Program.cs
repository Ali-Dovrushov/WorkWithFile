using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Person
    {
        public int Client_ID { get; set; }
        public string Client_DOC { get; set; }
        public double Client_AMOUNT { get; set; }
        public Person(int a, string b, double c)
        {
            Client_ID = a;
            Client_DOC = b;
            Client_AMOUNT = c;
        }
        public string Metod()
        {
            return ($"{Client_ID} {Client_DOC} {Client_AMOUNT}");
        }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            //Перезаписанные данные.
            Person client1 = new Person(1, "AZE12345671", 600.35);
            Person client2 = new Person(2, "AZE12345672", 1300.15);
            Person client3 = new Person(3, "AZE12345673", 450.75);
            Person client4 = new Person(4, "AZE12345674", 860.25);

            //Создаем папку.
            string path = @"C:\Dovrushov3";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            //Первоначальная запись.
            string text = "1 AZE12345671 500.35\n2 AZE12345672 1000.15\n3 AZE12345673 350.75\n4 AZE12345674 800.25";

            //Создаём первый текстовый редактор.
            string path2 = @"C:\Dovrushov3\note4.txt";
            FileInfo fileInfo = new FileInfo(path2);
            if (!fileInfo.Exists)
            {
                //Записываем данные в первый текстовый редактор.
                try
                {
                    using (StreamWriter writer1 = new StreamWriter(path2, false, System.Text.Encoding.Default))
                    {
                        Console.WriteLine("Начальная запись.\n");
                        writer1.WriteLine(text);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //fileInfo.Create();
            }

            //Идёт чтение.
            try
            {
                using (StreamReader writer1 = new StreamReader(path2))
                {
                    Console.WriteLine(writer1.ReadToEnd());
                    writer1.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string writePath = @"C:\Dovrushov3\note5.txt";

            //Идёт перезапись.
            try
            {
                using (StreamWriter writer = File.CreateText(writePath))
                {
                    Console.WriteLine("Идёт перезапись...");
                    writer.WriteLine(client1.Metod());
                    writer.WriteLine(client2.Metod());
                    writer.WriteLine(client3.Metod());
                    writer.WriteLine(client4.Metod());
                    Console.WriteLine("\nПерезапись выполнена.\n");
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Идёт чтение перезаписи.
            try
            {
                using (StreamReader sr = new StreamReader(writePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Have good day!!!");
            Console.ReadKey();
        }
    }
}
