using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_19
{
    /*Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой  работы  процессора,  
     *объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров, 
     *имеющихся в наличии. Создать список, содержащий 6-10 записей с различным набором значений характеристик.
      Определить:
        - все компьютеры с указанным процессором. Название процессора запросить у пользователя;
        - все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
        - вывести весь список, отсортированный по увеличению стоимости;
        - вывести весь список, сгруппированный по типу процессора;
        - найти самый дорогой и самый бюджетный компьютер;
        - есть ли хотя бы один компьютер в количестве не менее 30 штук?*/
    class Program
    {
        static void Main(string[] args)
        {
            List<PC> listPC = new List<PC>
            {
                new PC(){Id = 1, Name = "Lenovo", ProcType = "Intel", ProcFreq = 2.3, Ram = 16, Hdd = 512, Video = 4, Cost = 40000, Qty = 10},
                new PC(){Id = 2, Name = "HP", ProcType = "Intel", ProcFreq = 3.6, Ram = 32, Hdd = 1024, Video = 8, Cost = 50000, Qty = 15},
                new PC(){Id = 3, Name = "Apple", ProcType = "Intel", ProcFreq = 2.3, Ram = 8, Hdd = 1024, Video = 4, Cost = 100000, Qty = 5},
                new PC(){Id = 4, Name = "HP", ProcType = "AMD", ProcFreq = 3.3, Ram = 32, Hdd = 512, Video = 16, Cost = 110000, Qty = 7},
                new PC(){Id = 5, Name = "Lenovo", ProcType = "AMD", ProcFreq = 3.2, Ram = 32, Hdd = 1024, Video = 8, Cost = 60000, Qty = 20},
                new PC(){Id = 6, Name = "Lenovo", ProcType = "Intel", ProcFreq = 2.8, Ram = 16, Hdd = 1024, Video = 4, Cost = 80000, Qty = 30}
            };
            //Список по типу процессоров:
            Console.WriteLine("Введите наименование типа процессора:");
            string type = Console.ReadLine();
            List<PC> compProcTypes = listPC.Where(t => t.ProcType == type).ToList();
            Console.WriteLine("Компьютеры с указанным типом процессора:");
            foreach (PC p in compProcTypes)
            {
                Console.WriteLine($"{p.Id} {p.Name} {p.ProcType} {p.ProcFreq} {p.Ram} {p.Hdd} {p.Video} {p.Cost} {p.Qty}");
            }
            Console.WriteLine();

            //Список по объёму ОЗУ:
            Console.WriteLine("Введите объём ОЗУ:");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<PC> compRam = listPC.Where(r => r.Ram >= ram).ToList();
            Console.WriteLine("Компьютеры с ОЗУ не ниже, чем задано:");
            foreach (PC p in compRam)
            {
                Console.WriteLine($"{p.Id} {p.Name} {p.ProcType} {p.ProcFreq} {p.Ram} {p.Hdd} {p.Video} {p.Cost} {p.Qty}");
            }
            Console.WriteLine();

            //Отсортированный по стоимости список:
            List<PC> listSorted = listPC.OrderBy(c => c.Cost).ToList();
            Console.WriteLine("Список компьютеров в порядке увеличения стоимости:");
            foreach (PC p in listSorted)
            {
                Console.WriteLine($"{p.Id} {p.Name} {p.ProcType} {p.ProcFreq} {p.Ram} {p.Hdd} {p.Video} {p.Cost} {p.Qty}");
            }
            Console.WriteLine();

            //Сгруппированный по типу процессоров список:
            IEnumerable<IGrouping<string, PC>> listGrouped = listPC.GroupBy(t => t.ProcType);
            Console.WriteLine("Список компьютеров, сгруппированный по типу процессоров:");
            foreach (IGrouping<string, PC> group in listGrouped)
            {
                Console.WriteLine(group.Key);
                foreach (PC p in group)
                {
                    Console.WriteLine($"{p.Id} {p.Name} {p.ProcFreq} {p.Ram} {p.Hdd} {p.Video} {p.Cost} {p.Qty}");
                }
            }
            Console.WriteLine();

            //Самый дорогой и самый дешёвый компьютер:
            PC maxCost = listPC.OrderBy(c => c.Cost).LastOrDefault();
            PC minCost = listPC.OrderBy(c => c.Cost).FirstOrDefault();
            Console.WriteLine("Самый дорогой компьютер:");
            Console.WriteLine($"{maxCost.Id} {maxCost.Name} {maxCost.ProcType} {maxCost.ProcFreq} {maxCost.Ram} {maxCost.Hdd} {maxCost.Video} {maxCost.Cost} {maxCost.Qty}");
            Console.WriteLine();
            Console.WriteLine("Самый бюджетный компьютер:");
            Console.WriteLine($"{minCost.Id} {minCost.Name} {minCost.ProcType} {minCost.ProcFreq} {minCost.Ram} {minCost.Hdd} {minCost.Video} {minCost.Cost} {minCost.Qty}");
            Console.WriteLine();

            //Есть ли хотя бы один компьютер в количестве не менее 30 штук?
            if (listPC.Any(a => a.Qty >= 30))
                Console.WriteLine("В наличии есть компьютеры в количестве не менее 30 штук.");
            else
                Console.WriteLine("В наличии нет компьютеров в количестве не менее 30 штук.");
            Console.ReadKey();
        }
    }
}
