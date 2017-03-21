using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP.Player;
using OOP.Logic;
using OOP.Creatures;

namespace OOP
{
    public partial class ClickAdventureBase : Form
    {

        // Properties


        private Player.Player _player; //  Player Object
        public int positionWalked = 0;
        private Reward _rewards; // reward object
        private Creatures.Creatures creature;
        private Combat combatMode;

        public ClickAdventureBase()

        {

            InitializeComponent();


            // Setting default value
            _player = new Player.Player();
            _player.CurrentHitPoints = 50;
            _player.MaximumHitPoints = 50;
            _player.Gold = 20;
            _player.ExperienceHitPoints = 0;
            _player.Level = 1;
            _player.WalkedAmount = "Current position: Starting Zone";
            _player.Armor = 5;
            _player.AttackDamage = 10;
            _player.LevelCap = 100;

            // label values
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperienceHitPoints.ToString();
            lblLevel.Text = _player.Level.ToString();
            lblWalk.Text = _player.WalkedAmount.ToString();

            mainTextBox.Text = "Welcome to the ultimate experience in Click Adventure RPG" + "\n"
                + "This is how you play:" + "\n"
                + "- Click" + "\n"
                + "-  Win";

        }

        //Walkbutton
        private void button1_Click(object sender, EventArgs e)
        {
            //int questHack = positionWalked - 1;
            combatLabel.Text = "";
            // questGiver;
            // questText;
            // questName;
            // questId;

            lblWalk.Text = "You moved to position: " + ++positionWalked;
            Console.WriteLine(positionWalked);
            //if (questHack < Quest.quests.Count)
            //{
            //    mainTextBox.Text = Quest.quests[questHack].questText;
            //}


            if (positionWalked % 4 == 0)
            {
                creature = new EasyMonster();
                combatMode = new Combat(creature, _player);
                RenderEnemyText();
                //UpdateLabels();

                attackButton.Visible = true;
                defendButton.Visible = true;


            }
            else
            {
                mainTextBox.Text = "";
                attackButton.Visible = false;
                defendButton.Visible = false;
            }
        }
        

        private void attackButton_Click(object sender, EventArgs e)
        {
            combatMode.Attack();

            //int damageTaken = creature.AttackDamage - _player.Armor + 1 > 0 ? creature.AttackDamage - _player.Armor : 0;
            //int damageGiven = _player.AttackDamage - creature.Armor > 0 ? _player.AttackDamage - creature.Armor : 0;

            int damageTaken = 0;
            if (creature.AttackDamage - _player.Armor > 0)
            {
                damageTaken = creature.AttackDamage - _player.Armor;
            }
            int damageGiven = 0;
            if (_player.AttackDamage - creature.Armor > 0)
            {
                damageGiven -= _player.AttackDamage - creature.Armor;
            }

            UpdateLabels();

            combatLabel.Text = "You smashed the monster for " + damageGiven.ToString() + "\n"
           + "The monster hit you for " + damageTaken.ToString();

        }

        private void defendButton_Click(object sender, EventArgs e)
        {
         
        }

        private void UpdateLabels()
        {
            
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();

            mainTextBox.Text = "You stumbled on a creature! Fight!" + "\n" + "\n" + "Monster HP: "
                   + creature.HealthPoints.ToString() + "\n"
                   + "Monster Armor: " + creature.Armor.ToString() + "\n"
                   + "Monster Damage: " + creature.AttackDamage.ToString();


            string combatString = combatMode.CheckVictory();
            if (!combatString.Equals(""))
            {
                mainTextBox.Text = combatString;
                attackButton.Visible = false;
                defendButton.Visible = false;
            }
        }

        private void RenderEnemyText()
        {
            mainTextBox.Text = "You stumbled on a creature! Fight!" + "\n" + "\n" + "Monster HP: "
                   + creature.HealthPoints.ToString() + "\n"
                   + "Monster Armor: " + creature.Armor.ToString() + "\n"
                   + "Monster Damage: " + creature.AttackDamage.ToString();
        }

    }
}