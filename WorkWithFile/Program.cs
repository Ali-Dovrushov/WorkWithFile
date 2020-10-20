using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

namespace WorkWithFile
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
            Person client1 = new Person(1, "AZE12345671", 500.35);
            Person client2 = new Person(2, "AZE12345672", 1000.15);
            Person client3 = new Person(3, "AZE12345673", 350.75);
            Person client4 = new Person(4, "AZE12345674", 800.25);

            //Создаем папку.
            string path = @"C:\Dovrushov3";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            //Создаём первый текстовый редактор.
            string path2 = @"C:\Dovrushov3\note4.txt";
            FileInfo fileInfo = new FileInfo(path2);
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
            }


            string writePath = @"C:\Dovrushov3\note5.txt";

            //Идет читание.
            try
            {
                using (StreamReader sr = new StreamReader(path2))
                {
                    Console.WriteLine(sr.ReadToEnd());
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Идет перезапись.
            try
            {
                using (StreamWriter writer = File.CreateText(writePath))
                {

                    Console.WriteLine("\nИдёт перезапись...");
                    writer.WriteLine(client1.Metod());
                    writer.WriteLine(client2.Metod());
                    writer.WriteLine(client3.Metod());
                    writer.WriteLine(client4.Metod());
                    Console.WriteLine("\nПерезапись выполнена.");
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Идет читание перезаписи.
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