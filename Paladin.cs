using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_Classes
{
    internal class Paladin:Warrior
    {
        private float FocusBuff = 1.0f;
        private bool currentBuff = false;
        private int buffPhasesLeft = 0;


        public Paladin()
        {
            ClassType = PlayerClass.Paladin;
        }


        public Paladin(float health, float stamina, string name, int strength, int intelligence, int defence)
        {
            this.health = health;
            this.stamina = stamina;
            this.name = name;
            this.strength = strength;
            this.defence = defence;
            this.intelligence = intelligence;
            ClassType = PlayerClass.Paladin;
        }

        public Paladin(string name, Stats newStats)
        {
            assignStats(newStats);
            this.name = name;
            ClassType = PlayerClass.Paladin;
        }

        public override float DealDamage()
        {
            Random newRand = new();
            int attackingMove = newRand.Next(10);
            if (currentBuff)
            {
                buffPhasesLeft--;
                if (buffPhasesLeft == 0)
                {
                    currentBuff = false;
                    FocusBuff = 1.0f;
                }
                                            
            }

            if (attackingMove > 8)
            {
                Focus();
                return 0;
            }
            else if (attackingMove > 3)
            {
                return HeavyAttack() * FocusBuff;
            }
            else
            {
                return strength * 0.5f*FocusBuff;
            }

        }

        protected void Focus()
        {
           // Console.WriteLine($"{name} has enabled Focus Buff");
            FocusBuff = 1 + (stamina/100 * (strength*defence/100));
            currentBuff = true;
            buffPhasesLeft = 3;
        }

        public override void ReceiveDamage(float damage)
        {
            if (currentBuff)
            {
                health -= damage / FocusBuff;            
            }
            else 
            {
                health -= damage;
            }
        }


    }
}
