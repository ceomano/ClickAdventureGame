using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Logic
{
    class Combat
    {
        private Player.Player player;
        private Creatures.Creatures creature;
        

        public void setPlayer(Player.Player p)
        {
            this.player = p;
        }
        public void setCreature(Creatures.Creatures c)
        {
            this.creature = c;
        }

        public void Attack()
        {
            int attackDamage = this.player.AttackDamage - this.creature.Armor > 0 ? this.player.AttackDamage - this.creature.Armor : 0;
            this.creature.HealthPoints -= attackDamage;

            if (this.creature.HealthPoints > 0)
            {
                attackDamage = this.creature.AttackDamage - this.player.Armor > 0 ? this.creature.AttackDamage - this.player.Armor : 0;
                this.player.CurrentHitPoints -= attackDamage;
            }
        }

        public void Defend()
        {
            
        }

        public Combat(Creatures.Creatures c, Player.Player p)
        {
            this.creature = c;
            this.player = p;
            


        }
        public Combat()
        {

        }

        public string CheckVictory()
        {
            if (this.player.CurrentHitPoints > 0 && this.creature.HealthPoints <= 0)
            {
                return "Congrats, you won.";
            }
            else if (this.player.CurrentHitPoints <= 0)
            {
                return "You lost, ggwp.";
            }
            return ""; // Still going.
        }
        // Doot - jora
    }
}