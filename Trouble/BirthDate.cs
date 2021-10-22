//-----------------------------------------------------------------------
// <copyright file="BirthDate.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Trouble
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Provides a form for the human's birth date to be entered, this is used to sort players by age
    /// The youngest players will go first in order
    /// </summary>
    public partial class BirthDate : Form
    {
        /// <summary>
        /// holds the name of the player
        /// </summary>
        private string name;

        /// <summary>
        /// holds the game instance
        /// </summary>
        private Game game;

        /// <summary>
        /// holds a player instance
        /// </summary>
        private Player person;

        /// <summary>
        /// Initializes a new instance of the <see cref="BirthDate"/> class
        /// The constructor for the BirthDate form
        /// </summary>
        /// <param name="player">Accepts an instance of player</param>
        /// <param name="trouble">Accepts the instance of the Game</param>
        public BirthDate(int player, Game trouble)
        {
            this.InitializeComponent();
            this.textBoxEnterName.Focus();
            this.Text = "Player " + player;
            this.Person = new Player();
            this.game = trouble;
        }

        /// <summary>
        /// Gets or sets the players name
        /// </summary>
        public new string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets an instance of game
        /// </summary>
        public Game Game
        {
            get { return this.game; }
            set { this.game = value; }
        }

        /// <summary>
        /// Gets or sets an instance of player
        /// </summary>
        public Player Person
        {
            get { return this.person; }
            set { this.person = value; }
        }

        /// <summary>
        /// The method for when the submit button is clicked
        /// </summary>
        /// <param name="sender"> the button itself</param>
        /// <param name="e"> the event that is firing</param>
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (this.CheckName())
            {
                this.Person.DOB = this.dobPicker.Value;
                this.Person.Name = this.textBoxEnterName.Text;
                this.Game.Players.Add(this.person);               
                this.Close();
            }
        }

        /// <summary>
        /// When the picker value has been changed enable the submit button
        /// </summary>
        /// <param name="sender">passes the control or reference to</param>
        /// <param name="e">passes the event data</param>
        private void DobPicker_ValueChanged(object sender, EventArgs e)
        {
            this.btnSubmit.ForeColor = Color.Black;
            this.btnSubmit.Enabled = true;
        }

        /// <summary>
        /// Tells us if the player is entering a name
        /// </summary>
        /// <returns>Returns true if a name has been entered</returns>
        private bool CheckName()
        {
            if (this.textBoxEnterName.Text == string.Empty)
            {
                MessageBox.Show("You must enter a name!");
                this.textBoxEnterName.Focus();
                return false;
            }
            else
            {
                this.name = this.textBoxEnterName.Text;
                return true;
            }
        }
    }
}
