using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW5
{
    public class Program
    {
        public static async Task<string> ReadHello()
        {
            return await File.ReadAllTextAsync("Hello.txt");
        }

        public static async Task<string> ReadWorld()
        {
            return await File.ReadAllTextAsync("World.txt");
        }

        public static async Task<string> Concat()
        {
            var taskList = new List<Task<string>>();
            taskList.Add(ReadHello());
            taskList.Add(ReadWorld());
            return string.Join(' ', await Task.WhenAll(taskList));
        }

        public static void Main(string[] args)
        {
            var str = Concat().GetAwaiter().GetResult();
            Console.WriteLine("Main:");
            Console.WriteLine(str);
        }
    }
}
