//-----------------------------------------------------------------------
// <copyright file="WinnerForm.cs" company="NWTC">
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
    /// Provides a form that displays the winner(s)
    /// </summary>
    public partial class WinnerForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WinnerForm"></see> class
        /// </summary>
        public WinnerForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WinnerForm"></see> class
        /// </summary>
        /// <param name="winners">passes the list of winners</param>
        public WinnerForm(List<Player> winners)
        {
            this.InitializeComponent();
            if (winners.Count == 1)
            {
                this.lblFirst.Visible = true;
                this.lblFirst.Text = winners[0].Name + " Wins First Place!";
            }

            if (winners.Count == 2)
            {
                this.lblFirst.Visible = true;
                this.lblSecond.Visible = true;
                this.lblFirst.Text = winners[0].Name + " Wins First Place!";
                this.lblSecond.Text = winners[1].Name + " Wins Second Place!";
            }

            if (winners.Count == 3)
            {
                this.lblFirst.Visible = true;
                this.lblSecond.Visible = true;
                this.lblThird.Visible = true;
                this.lblFirst.Text = winners[0].Name + " Wins First Place!";
                this.lblSecond.Text = winners[1].Name + " Wins Second Place!";
                this.lblThird.Text = winners[2].Name + " Wins Third Place!";
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the game is over
        /// </summary>
        public bool Over { get; set; }

        /// <summary>
        /// when this form is closed
        /// </summary>
        /// <param name="sender">passes reference to the form</param>
        /// <param name="e"> the associated form closed event</param>
        private void WinnerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Over = true;
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        /// <param name="sender">the associated button</param>
        /// <param name="e">the associated event</param>
        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            this.Over = true;
            this.Close();
        }
    }
}
