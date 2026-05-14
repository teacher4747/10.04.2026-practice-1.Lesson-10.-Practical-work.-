using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace _10._04._2026__practice_1_
{
    public static class SimulationEngine
    {
        
        /// Выполняет один ход: заставляет каждый модуль на карте выполнить Act().
    
        /// <param name="map">Зубчатый массив модулей (null = пустая клетка).
        /// <param name="turnNumber">Номер хода (in – только для чтения).
        /// <param name="processedCount">Сколько модулей сработало (out).
        /// <param name="totalFuel">Общий расход топлива (ref – можем менять).
        /// <returns>True, если всё прошло успешно (карта не null).
        public static bool TryStep(AbstractModule[][] map, in int turnNumber,
                                   out int processedCount, ref int totalFuel)
        {
            processedCount = 0;

            if (map == null) return false;

            // Проходим по всем ячейкам карты (зубчатый массив)
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == null) continue; // строка может быть null
                for (int j = 0; j < map[i].Length; j++)
                {
                    var module = map[i][j];
                    if (module != null)
                    {
                        // Выполняем действие модуля
                        module.Act();
                        processedCount++;
                        // Добавляем потраченное топливо к общему счётчику
                        totalFuel += module.GetSpentFuelAndReset();
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Сдвигает все модули на карте на указанное смещение.
        /// </summary>
        public static void ShiftMapCoords(AbstractModule[][] map, in Coord offset)
        {
            if (map == null) return;

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == null) continue;
                for (int j = 0; j < map[i].Length; j++)
                {
                    map[i][j]?.ShiftPosition(offset);
                }
            }
        }
    }
}