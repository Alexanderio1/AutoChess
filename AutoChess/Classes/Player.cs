using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChess.Classes
{
    public class Player
    {
        public string Name { get; }
        public List<Unit> Units { get; }
        
        public Player(string name = "default")
        {
            Name = name;
            Units = new List<Unit>();
        }
        public void AddUnit(Unit unit)
        {
            Units.Add(unit);
        }
        public bool HasAliveUnits() 
        { 
            return Units.Any(unit => unit.Health > 0);
        }
    }
}
