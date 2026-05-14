using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _10._04._2026__practice_1_
{
    public sealed class CargoModule : AbstractModule
    {
        public CargoModule(Coord startPos, int initialFuel) : base(startPos, initialFuel) { }

        public override void Act()
        {
            // Перемещение на (-1,0)
            position += new Coord(-1, 0);
            // Тратим 2 единицы топлива
            ConsumeFuel(2);
        }
    }
}
