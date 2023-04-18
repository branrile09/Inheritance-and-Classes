using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_Classes
{
    internal class Druid: Mage
    {

        public Druid()
        {
            ClassType = PlayerClass.Druid;
        }

        public Druid(string name, Stats newStats)
        {
            assignStats(newStats);
            this.name = name;
            ClassType = PlayerClass.Druid;
        }


        public Druid(float health, float stamina, string name, int strength, int intelligence, int defence)
        {
            this.health = health;
            this.stamina = stamina;
            this.name = name;
            this.strength = strength;
            this.defence = defence;
            this.intelligence = intelligence;
            ClassType = PlayerClass.Druid;
        }
    }






}
