using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Logic
{
    class Combat
    {

        // object
        private Player.Player player;
        private Creatures.Creatures creature;
        
        // overcourse, this is though necessary when dealing with alot of objects. Setting player object.
        public void setPlayer(Player.Player p)
        {
            this.player = p;
        }
        //Setting creature object
        public void setCreature(Creatures.Creatures c)
        {
            this.creature = c;
        }

        // Attackfunction, linear if statement.
        public void Attack()
        {
            // attack - armor > 0 (if true) attack - armor
            int attackDamage = this.player.AttackDamage - this.creature.Armor > 0 ? this.player.AttackDamage - this.creature.Armor : 0;
            this.creature.HealthPoints -= attackDamage;

            // creature hp > 0 , attackdamage - armor > 0 (if true) attack - armor
            if (this.creature.HealthPoints > 0)
            {
                attackDamage = this.creature.AttackDamage - this.player.Armor > 0 ? this.creature.AttackDamage - this.player.Armor : 0;
                this.player.CurrentHitPoints -= attackDamage; // decrement 
            }
        }

        public void Defend()
        {
            
        }

        // constructor, parameters object
        public Combat(Creatures.Creatures c, Player.Player p)
        {
            this.creature = c;
            this.player = p;
            


        }
        public Combat()
        {

        }

        // if player hp > 0 , creature hp less/equal 0 return labelupdate with win.
        public string CheckVictory()
        {
            if (this.player.CurrentHitPoints > 0 && this.creature.HealthPoints <= 0)
            {
                return "Congrats, you won.";
            }
            // labelupdate with loss
            else if (this.player.CurrentHitPoints <= 0)
            {
                return "You lost, ggwp.";
            }
            return ""; // Still going.
        }
        
    }
}