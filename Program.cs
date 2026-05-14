using System;

namespace _10._04._2026__practice_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Симулятор автономных модулей ===\n");

            // Создаём зубчатую карту
            AbstractModule[][] map = new AbstractModule[3][];
            map[0] = new AbstractModule[2];
            map[1] = new AbstractModule[3];
            map[2] = new AbstractModule[1];

            // Размещаем модули
            map[0][0] = new ScoutModule(new Coord(0, 0), 5);
            map[0][1] = new CargoModule(new Coord(10, 5), 8);
            map[1][0] = new ScoutModule(new Coord(2, 3), 3);
            map[1][2] = new CargoModule(new Coord(-1, 7), 6);
            map[2][0] = new ScoutModule(new Coord(100, 50), 2);

            Console.WriteLine("Начальное состояние карты:");
            PrintMap(map);

            int totalFuel = 0;

            // Выполняем 3 хода
            for (int turn = 1; turn <= 3; turn++)
            {
                bool ok = SimulationEngine.TryStep(map, in turn, out int processed, ref totalFuel);
                Console.WriteLine($"\n--- Ход {turn} ---");
                Console.WriteLine($"Обработано модулей: {processed}, Общий расход топлива: {totalFuel}");
                PrintMap(map);
            }

            // Сдвигаем все координаты
            Console.WriteLine("\n=== Сдвиг карты на (5, -3) ===");
            SimulationEngine.ShiftMapCoords(map, new Coord(5, -3));
            PrintMap(map);

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void PrintMap(AbstractModule[][] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    var m = map[i][j];
                    if (m != null)
                    {
                        string type = m is ScoutModule ? "Разведчик" : "Грузовой";
                        Console.WriteLine($"  [{i},{j}] {type}: {m.Position}, топливо: {m.Fuel}");
                    }
                    else
                    {
                        Console.WriteLine($"  [{i},{j}] пусто");
                    }
                }
            }
        }
    }
}