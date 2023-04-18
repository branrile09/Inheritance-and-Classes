using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_Classes
{
    internal class Warrior:Player
    {

        public string LastName = "bob the barbarian";


        public Warrior()
        {
            ClassType = PlayerClass.Warrior;
        }

        public Warrior(string name, Stats newStats)
        {
            assignStats(newStats);
            this.name = name;
            ClassType = PlayerClass.Warrior;
        }

        public Warrior(float health, float stamina, string name, int strength, int intelligence, int defence)
        { 
            this.health = health;
            this.stamina = stamina;
            this.name = name;
            this.strength = strength;
            this.defence = defence;
            this.intelligence = intelligence;
            ClassType = PlayerClass.Warrior;
        }
        public override float DealDamage()
        {
            Random newRand = new();
            int attackingMove = newRand.Next(5);
            if (attackingMove > 3)
            {
                return HeavyAttack();
            }
            else
            {
                return strength * 0.5f;
            }

        }
        //self managed ability, combat scenario specific
        protected float HeavyAttack()
        {
            return strength * 1f;
        }



    }
}
