using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()
            {
new Computer() { Code=1, Brand="Acer", CPU="i3", CpuFrequency=3600, RAM=8, SSD=512, MemoryGPU=4, Price=48, Available=30 },
new Computer() { Code=2, Brand="HP", CPU="Ryzen 3", CpuFrequency=4000, RAM=8, SSD=512, MemoryGPU=4, Price=56, Available=6 },
new Computer() { Code=3, Brand="ASUS", CPU="i5", CpuFrequency=2600, RAM=16, SSD=512, MemoryGPU=12, Price=120, Available=2 },
new Computer() { Code=4, Brand="Lenovo", CPU="i3", CpuFrequency=3600, RAM=8, SSD=512, MemoryGPU=4, Price=55, Available=3 },
new Computer() { Code=5, Brand="Dell", CPU="i7", CpuFrequency=2500, RAM=16, SSD=1000, MemoryGPU=16, Price=250, Available=1 },
new Computer() { Code=6, Brand="MSI", CPU="i5", CpuFrequency=2600, RAM=16, SSD=256, MemoryGPU=6, Price=80, Available=1 }

            };
            // все компьютеры с указанным процессором
            Console.WriteLine("Название процессора:");
            string cpuInput = Console.ReadLine();
            List<Computer> computers = listComputer
                .Where(c => c.CPU == cpuInput)
                .ToList();
            foreach (Computer c in computers)
                Console.WriteLine($"{c.Code} {c.Brand}");
            Console.WriteLine();

            //все компьютеры с объемом ОЗУ не ниже, чем указано
            Console.WriteLine("Объем ОЗУ от:");
            int RamInput = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = listComputer
.Where(c => c.RAM >= RamInput)
.ToList();
            foreach (Computer c in computers)
                Console.WriteLine($"{c.Code} {c.Brand}");
            Console.WriteLine();

            //список, отсортированный по увеличению стоимости
            Console.WriteLine("Cписок, отсортированный по увеличению стоимости");
            List<Computer> computers3 = listComputer
                .OrderBy(c => c.Price)
                .ToList();
            foreach (Computer c in computers3)
                Console.WriteLine($"{c.Code} {c.Brand} {c.Price}");
            Console.WriteLine();

            //список, сгруппированный по типу процессора
            Console.WriteLine("Cписок, сгруппированный по типу процессора");
            var computers4 = listComputer.GroupBy(c => c.CPU);
            foreach (IGrouping<string, Computer> g in computers4)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                    Console.WriteLine(t.Brand);
                Console.WriteLine();
            }

            //самый дорогой и самый бюджетный компьютер

            Computer computers5 = listComputer
                .OrderByDescending(c => c.Price)
                .First();

            Console.WriteLine($"Самый дорогой компьютер {computers5.Code} {computers5.Brand} {computers5.Price}");
            Console.WriteLine();

            Computer computers6 = listComputer
                .OrderByDescending(c => c.Price)
                .Last();

            Console.WriteLine($"Самый бюджетный компьютер {computers6.Code} {computers6.Brand} {computers6.Price}");
            Console.WriteLine();
            

            //один компьютер в количестве не менее 30 штук
            bool result1 = computers3.Any(c => c.Available >= 30);
            if (result1)
            {
                Console.WriteLine("Есть хотя бы один компьютер в количестве не менее 30 штук");
            }
            else
            {
                Console.WriteLine("Нет ни одного компьютера в количестве не менее 30 штук");
            }

            Console.ReadKey();
        }
    }

    class Computer
    {
        public int Code { get; set; }
        public string Brand { get; set; }
        public string CPU { get; set; }
        public int CpuFrequency { get; set; }
        public int RAM { get; set; }
        public int SSD { get; set; }
        public int MemoryGPU { get; set; }
        public int Price { get; set; }
        public int Available { get; set; }
        public bool Key { get; internal set; }
    }
}
