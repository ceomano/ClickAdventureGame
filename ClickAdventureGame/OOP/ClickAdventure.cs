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
        public int positionWalked = 0; // Position counter for player
        private Reward _rewards; // reward object
        private Creatures.Creatures creature; // creature object
        private Combat combatMode; // combat object

        public ClickAdventureBase()

        {

            InitializeComponent();


            // Setting default value for player below
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

            // Starting mainbox text
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

            // if x click is % 4 an encounter will appear with monster.
            if (positionWalked % 4 == 0)
            {
                creature = new EasyMonster();
                combatMode = new Combat(creature, _player);
                RenderEnemyText();

                // show Attack & defend button
                attackButton.Visible = true;
                defendButton.Visible = true;


            }
            else
            {
                // if encounter is done hide buttons
                mainTextBox.Text = "";
                attackButton.Visible = false;
                defendButton.Visible = false;
            }
        }
        

        private void attackButton_Click(object sender, EventArgs e)
        {
            // attack function from combat object
            combatMode.Attack();
            
            int damageTaken = 0;
            // Math for damage taken, will also be updated in label
            if (creature.AttackDamage - _player.Armor > 0)
            {
                damageTaken = creature.AttackDamage - _player.Armor;
            }
            int damageGiven = 0;
            // Math for damage done, will also be updated in label
            if (_player.AttackDamage - creature.Armor > 0)
            {
                damageGiven -= _player.AttackDamage - creature.Armor;
            }

            //label update
            UpdateLabels();
            // comat label
            combatLabel.Text = "You smashed the monster for " + damageGiven.ToString() + "\n"
           + "The monster hit you for " + damageTaken.ToString();

        }
        // TODO
        private void defendButton_Click(object sender, EventArgs e)
        {
         
        }
        // update label method
        private void UpdateLabels()
        {
            
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();

            mainTextBox.Text = "You stumbled on a creature! Fight!" + "\n" + "\n" + "Monster HP: "
                   + creature.HealthPoints.ToString() + "\n"
                   + "Monster Armor: " + creature.Armor.ToString() + "\n"
                   + "Monster Damage: " + creature.AttackDamage.ToString();

            // check with checkvictory function if hp from creature is 0. Will also hide buttons
            string combatString = combatMode.CheckVictory();
            if (!combatString.Equals(""))
            {
                mainTextBox.Text = combatString;
                attackButton.Visible = false;
                defendButton.Visible = false;
            }
        }
        // Update of creatures HP
        private void RenderEnemyText()
        {
            mainTextBox.Text = "You stumbled on a creature! Fight!" + "\n" + "\n" + "Monster HP: "
                   + creature.HealthPoints.ToString() + "\n"
                   + "Monster Armor: " + creature.Armor.ToString() + "\n"
                   + "Monster Damage: " + creature.AttackDamage.ToString();
        }

    }
}