using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_Classes
{
    internal class Mage:Player
    {
       

        public Mage()
        {
            PlayerClass ClassType = PlayerClass.Mage;
        }

        public Mage(float health, float stamina, string name, int strength, int intelligence, int defence)
        {
            this.health = health;
            this.stamina = stamina;
            this.name = name;
            this.strength = strength;
            this.defence = defence;
            this.intelligence = intelligence;
            PlayerClass ClassType = PlayerClass.Mage;
        }

        public Mage(string name, Stats newStats)
        {
            assignStats(newStats);
            this.name = name;
            ClassType = PlayerClass.Mage;
        }

        public override float DealDamage()
        {
            Random newRand = new();
            int attackingMove = newRand.Next(5);
            if (attackingMove > 3)
            {
                return Fireball();
            }
            else
            {
                return strength * 0.5f;
            }

        }

        protected float Fireball()
        {
            return intelligence * 1f;
        }



    }
}
