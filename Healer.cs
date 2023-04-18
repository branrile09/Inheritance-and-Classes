using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_Classes
{
    internal class Healer:Warrior
    {
        private List<Player> Team;

        public Healer()
        {
            ClassType = PlayerClass.Healer;
        }


        public Healer(float health, float stamina, string name, int strength, int intelligence, int defence, List<Player> Team)
        {
            this.health = health;
            this.stamina = stamina;
            this.name = name;
            this.strength = strength;
            this.defence = defence;
            this.intelligence = intelligence;
            ClassType = PlayerClass.Healer;
            this.Team = Team;
        }

        public Healer(string name,Stats newStats, List<Player> Team)
        {
            assignStats(newStats);
            this.name = name;            
            ClassType = PlayerClass.Healer;
            this.Team = Team;
        }


        private float HealAlly(float AllyHealth)
        {
            if (health < 100.0f)
            { //healer self heals when healing allys
                health += AllyHealth * 0.08f;            
            }
            return AllyHealth * 0.12f;        
        }

        public override float DealDamage()
        { 
            Random random = new Random();

            if (random.Next(1) == 0)
            {
                HealAlly();
                return 0;
            }
            else
            {
                return strength * 0.5f;
            }        
        
        }


        public bool HealAlly()
        {
            bool healedAlly = false;
            for (int i = 0; i < Team.Count; i++)
            {
                if (this.name == Team[i].getName())
                {
                    continue;                
                }
                float playerHealth = Team[i].getHealth();
                if (playerHealth < 90.0f  && playerHealth > 0.0f)
                {
                    Team[i].receiveHealing(HealAlly(playerHealth));
                    healedAlly = true;
                    break;
                }
            }

            if (healedAlly)
            { return true; }
            else
            { return false; }


        }

    }


}
