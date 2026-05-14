using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _10._04._2026__practice_1_
{
    public abstract class AbstractModule
    {
        protected Coord position;
        protected int fuel;
        private int fuelUsedThisTurn = 0;

        protected AbstractModule(Coord startPos, int initialFuel)
        {
            position = startPos;
            fuel = initialFuel;
        }

        public Coord Position => position;
        public int Fuel => fuel;

        public abstract void Act();

        public virtual void ConsumeFuel(int amount)
        {
            if (amount <= 0) return;
            int canSpend = Math.Min(amount, fuel);
            fuel -= canSpend;
            fuelUsedThisTurn += canSpend;
        }

        // Этот метод нужен движку
        public int GetSpentFuelAndReset()
        {
            int spent = fuelUsedThisTurn;
            fuelUsedThisTurn = 0;
            return spent;
        }

        // Этот метод нужен для ShiftMapCoords
        public void ShiftPosition(Coord offset)
        {
            position += offset;  // использует перегруженный оператор +
        }
    }
}