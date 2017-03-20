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
        private EasyMonster ezMonster = new EasyMonster();
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
            Console.WriteLine(positionWalked);
            int questHack = positionWalked - 1;
            // questGiver;
            // questText;
            // questName;
            // questId;

            lblWalk.Text = "You moved to position: " + ++positionWalked;
            //if (questHack < Quest.quests.Count)
            //{
            //    mainTextBox.Text = Quest.quests[questHack].questText;
            //}


            if (positionWalked % 4 == 0)
            {
                combatMode = new Combat(ezMonster, _player);
                mainTextBox.Text = "You stumbled on a creature! Fight!" + "\n" + "\n" + "Monster HP: "
                    + ezMonster.HealthPoints.ToString() + "\n"
                    + "Monster Armor: " + ezMonster.Armor.ToString() + "\n"
                    + "Monster Damage: " + ezMonster.AttackDamage.ToString();

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
            if (positionWalked % 4 == 0)
            {
                int damageTaken = 0;
                if (ezMonster.AttackDamage - _player.Armor > 0)
                {
                    damageTaken = ezMonster.AttackDamage - _player.Armor;
                }

                combatLabel.Text = "You smashed the monster for " + (_player.AttackDamage - ezMonster.Armor).ToString() + "\n"
                + "The monster hit you for " + damageTaken.ToString();
                combatMode.Attack();
                lblHitPoints.Text = (_player.CurrentHitPoints - damageTaken).ToString();
                mainTextBox.Text = "Monster HP: "
                    + ezMonster.HealthPoints.ToString() + "\n"
                    + "Monster Armor: " + ezMonster.Armor.ToString() + "\n"
                    + "Monster Damage: " + ezMonster.AttackDamage.ToString();

                //if (ezMonster.HealthPoints <= 0)
                //{
                //    combatLabel.Text = "Congrats You won!" + "\n"
                //        + _rewards.goldReward + " added " + " and" + _rewards.expReward + " added ";
                //}
                int damageGiven = 0;
                if (_player.AttackDamage - ezMonster.Armor > 0)
                {
                    damageGiven = _player.AttackDamage - ezMonster.Armor;
                }
                // combatLabel.Text = damageGiven.ToString(); fungerar, visar korrekt dmg.


            }
        }


        private void defendButton_Click(object sender, EventArgs e)
        {

        }
    }
}

