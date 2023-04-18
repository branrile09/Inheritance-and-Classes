using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_Classes
{
    internal class Archer:Player
    {

        public Archer()
        {
            ClassType = PlayerClass.Archer;
        }

        public Archer(string name, Stats newStats)
        {
            assignStats(newStats);
            this.name = name;
            ClassType = PlayerClass.Archer;
        }

        public Archer(float health, float stamina, string name, int strength, int intelligence, int defence)
        {
            this.health = health;
            this.stamina = stamina;
            this.name = name;
            this.strength = strength;
            this.defence = defence;
            this.intelligence = intelligence;
            ClassType = PlayerClass.Archer;
        }


    }
}
