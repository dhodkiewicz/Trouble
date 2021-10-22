//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Trouble
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Linq;
    using System.Speech.Synthesis;
    using System.Threading;
    using System.Windows.Forms;
    using WMPLib;

    /// <summary>
    /// Documentation for the first part of the Form class.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "reviewed")]
    public partial class Form1 : Form
    {
        /// <summary>
        /// holds an instance of the game
        /// </summary>
        private Game trouble;

        /// <summary>
        /// holds an instance of the display
        /// </summary>
        private Display display;

        /// <summary>
        /// holds an instance of the windows media player
        /// </summary>
        private WindowsMediaPlayer wmp;

        /// <summary>
        /// sets a new instance of our speech synth
        /// </summary>
        private SpeechSynthesizer talkBot = new SpeechSynthesizer();

        /// <summary>
        /// boolean for whether or not the game is over
        /// </summary>
        private bool gameOver;

        /// <summary>
        /// holds an instance of stopwatch
        /// </summary>
        private Stopwatch myStopwatch;

        /// <summary>
        /// Initializes a new instance of the Form1 class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // start at the center of the screen
            this.wmp = new WindowsMediaPlayer(); // allows for sound
            this.talkBot.SelectVoiceByHints(VoiceGender.Female);
            this.MaximizeBox = false;
        }

        /// <summary>
        /// Gets or sets the instance of the game
        /// </summary>
        public Game Trouble
        {
            get { return this.trouble; }
            set { this.trouble = value; }
        }

        /// <summary>
        /// Gets or sets the display
        /// </summary>
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        /// <summary>
        /// Gets or sets the WindowsMediaPlayer instance
        /// </summary>
        public WindowsMediaPlayer Wmp
        {
            get { return this.wmp; }
            set { this.wmp = value; }
        }

        /// <summary>
        /// When the label is clicked
        /// </summary>
        /// <param name="sender">Pass reference to the control or dice</param>
        /// <param name="e">Pass the associated event</param>
        private void LabelRoll_Click(object sender, EventArgs e)
        {
            this.LabelRoll();
        }

        /// <summary>
        /// Checks to see what the status of the game is, what the roll value is, and where the players pegs are
        /// Enables the appropriate pegs based upon the roll value, who's turn, and peg/button positions
        /// </summary>
        public void LabelRoll()
        {
            if (this.gameOver)
            {
                this.EndGame();
            }

            this.TimerTick();           
            this.LblRoll.Enabled = false;

            if (this.LblRoll.Text != "6")
            {
                if (this.NoPegsInPlay(this.Trouble.Players[this.Trouble.Turn]))
                {
                    this.Trouble.Dice.PreviousRoll = this.Trouble.Dice.RollValue;
                    this.Trouble.Turn++;
                    this.ChangePanel(this.Trouble.Players[this.Trouble.Turn].Color);
                    this.myStopwatch = new Stopwatch();
                    this.myStopwatch.Start();
                    while (this.myStopwatch.Elapsed.Seconds < 0.5)
                    {
                        Application.DoEvents();
                    }

                    this.myStopwatch.Stop();
                    this.IsComputer(this.Trouble.Players[this.Trouble.Turn]);
                    this.LblRoll.Enabled = true;
                    Application.DoEvents();
                }
                else
                {
                    Application.DoEvents();
                    this.EnableBoardPegs(this.Trouble.Players[this.Trouble.Turn].Color, true);
                    this.LblRoll.Enabled = false;
                }
            }
            else
            {
                // if the player rolls a 6 but has  peg at the start position already
                if (this.PlayerPegAtStart(this.Trouble.Players[this.Trouble.Turn]))
                {
                    this.EnableBoardPegs(this.Trouble.Players[this.Trouble.Turn].Color, true);
                }
                else
                {
                    // if they don't have a peg at the start position
                    this.EnablePegs(this.Trouble.Players[this.Trouble.Turn].Color, true);
                }
            }

            if (this.Trouble.Players.Count != 0)
            {
                this.ChangePanel(this.Trouble.Players[this.Trouble.Turn].Color);
                int count = 0;
                foreach (CircularButton button in this.Controls.OfType<CircularButton>())
                {
                    if (button.Tag == this.Trouble.Players[this.Trouble.Turn].Color + "Finish")
                    {
                        button.Location =
                            this.Display.FinishLocations[this.Display.GetFinishLocation(this.Trouble.Players[this.Trouble.Turn], count)];
                        count++;
                    }
                }
            }
        }

        /// <summary>
        /// Show the pegs of the players color
        /// </summary>
        /// <param name="color">passes the players color</param>
        public void ShowPegs(string color)
        {
            foreach (Control c in this.Controls)
            {
                if (c.Tag == color)
                {
                    c.Visible = true;
                }
            }
        }

        /// <summary>
        /// Enables the pegs or disables
        /// </summary>
        /// <param name="color">passes player color</param>
        /// <param name="b">enable or disable / true or false</param>
        public void EnablePegs(string color, bool b)
        {
            foreach (CircularButton c in this.Controls.OfType<CircularButton>())
            {
                if (c.Tag == color)
                {
                    c.Enabled = b;
                }
            }
        }

        /// <summary>
        /// enables the boards buttons/pegs
        /// </summary>
        /// <param name="color">passes the color of the player</param>
        /// <param name="b"> passes whether or not to activate/deactivate</param>
        public void EnableBoardPegs(string color, bool b)
        {
            foreach (CircularButton c in this.Controls.OfType<CircularButton>())
            {
                bool isHuman = this.Trouble.Players[this.Trouble.Turn] is Computer;

                if (c.Tag == color)
                {
                    if (!isHuman)
                    {
                        if (c.HumanPeg.NumSpaces > -1 && c.HumanPeg.NumSpaces < 28)
                        {
                            c.Enabled = true;
                            if (this.WillPegLandOnAnother(c))
                            {
                                c.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// selects the peg via the button clicked
        /// </summary>
        /// <param name="sender">refers to the instance of button</param>
        /// <param name="e">the associated event</param>
        public void SelectPeg(object sender, EventArgs e)
        {
            bool isAI = this.Trouble.Players[this.Trouble.Turn] is Computer;
            int turn = this.Trouble.Turn;
            CircularButton clickedPeg = sender as CircularButton;
            this.EnablePegs(this.Trouble.Players[this.Trouble.Turn].Color, false);
            if (this.NoPegsInPlay(this.Trouble.Players[this.Trouble.Turn]) && (this.Trouble.Dice.RollValue != 6))
            {
                MessageBox.Show("You must roll a 6 to move to start");
                return;
            }

           bool didHumanMove = this.Trouble.MovePegs(this.Trouble.Players[turn], clickedPeg.HumanPeg);

            this.UpdateAllButtons(); // update the computers buttons

            if (this.Trouble.Dice.RollValue != 6)
            {
                this.Trouble.Turn++;
            }

            if (this.Trouble.Dice.RollValue == 6 && this.Trouble.Dice.PreviousRoll == 6)
            {
                this.Trouble.Turn++;
                this.Trouble.Dice.RollValue = 0;
            }

            this.IsTurnOverCountLimit(this.Trouble.Turn);
            this.ChangePanel(this.Trouble.Players[this.Trouble.Turn].Color);

            this.LblRoll.Text = string.Empty;
            this.LblRoll.Enabled = true;
            this.IsHuman(isAI, didHumanMove);
            this.IsComputer(this.Trouble.Players[this.Trouble.Turn]);
        }

        /// <summary>
        /// helps us decide if it's okay to enable the human's buttons
        /// </summary>
        /// <param name="isAI"> passes the boolean whether or not it's ai</param>
        /// <param name="didHumanMove"> has the human already clicked a button, if so don't enable</param>
        private void IsHuman(bool isAI, bool didHumanMove)
        {
            if (!isAI && !didHumanMove)
            {
                foreach (Peg p in this.Trouble.Players[this.Trouble.Turn].Pegs)
                {
                    if (p.NumSpaces > -1 && p.NumSpaces < 28)
                    {
                        p.CircularBtn.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// This method actually moves the selected peg
        /// </summary>
        /// <param name="selectedPeg"> passes the selected peg</param>
        public void SelectPeg(Peg selectedPeg)
        {
            int turn = this.Trouble.Turn;
            this.EnablePegs(this.Trouble.Players[this.Trouble.Turn].Color, false);
            this.Trouble.MovePegs(this.Trouble.Players[turn], selectedPeg);
            if (this.CheckForWinner(this.Trouble.Players))
            {
                this.EndGame();
                this.Trouble.Turn = -1;
                return;
            }

            this.UpdateAllButtons(); // update the computers buttons
            this.myStopwatch = new Stopwatch();
            this.myStopwatch.Start();
            while (this.myStopwatch.Elapsed.Seconds < 1)
            {
                Application.DoEvents();
            }

            this.myStopwatch.Stop();

            if (this.Trouble.Dice.RollValue != 6)
            {
                this.Trouble.Turn++;
            }

            if (this.Trouble.Dice.RollValue == 6 && this.Trouble.Dice.PreviousRoll == 6)
            {
                this.Trouble.Turn++;
                this.Trouble.Dice.RollValue = 0;
            }

            this.IsTurnOverCountLimit(this.Trouble.Turn);
            this.ChangePanel(this.Trouble.Players[this.Trouble.Turn].Color);
            this.LblRoll.Text = string.Empty;
            this.LblRoll.Enabled = true;
            this.IsComputer(this.Trouble.Players[this.Trouble.Turn]);
        }

        /// <summary>
        /// Gets the Ai's Peg selection if it's not a 6
        /// </summary>
        /// <param name="p">passes the player</param>
        /// <returns> the peg selection</returns>
        public Peg AiPeg(Player p)
        {
            bool isHardMode = false;

            if (p is Computer)
            {
                var a = (Computer)p;
                isHardMode = a.IsHardMode;
            }

            if (this.CheckForWinner(this.Trouble.Players))
            {
                this.EndGame();
            }

            int count = 0;
            Peg pegChoice = new Peg();
            foreach (Peg peg in p.Pegs)
            {
                if (peg.NumSpaces == -1)
                {
                    count++;
                }
            }

            if (this.Trouble.Dice.RollValue == 6)
            {
                if (count == p.Pegs.Count)
                {
                    pegChoice = p.Pegs[0];
                }
                else
                {
                    pegChoice = this.AIPegChoice6(p, count, isHardMode);
                }
            }
            else
            {
                pegChoice = this.AIPegChoice(p, isHardMode);
            }

            return pegChoice;
        }

        /// <summary>
        /// Gets the AIPegChoice when it's not a 6
        /// </summary>
        /// <param name="p">passes the player</param>
        /// <param name="isHardMode">bool whether it's hard mode or not</param>
        /// <returns>returns the AI peg choice</returns>
        public Peg AIPegChoice(Player p, bool isHardMode)
        {
            Peg piece = new Peg();

            if (isHardMode)
            {
                 piece = this.Trouble.InsaneModePegSel(p, this.Trouble.Dice.RollValue);
                if (this.Trouble.IsSameColorPieceAtPosition(p, piece, this.Trouble.Dice.RollValue))
                {
                    foreach (Peg peg in p.Pegs)
                    {
                        if (peg.NumSpaces != -1)
                        {
                            if (!this.Trouble.IsSameColorPieceAtPosition(p, peg, this.Trouble.Dice.RollValue))
                            {
                                piece = peg;
                            }
                        }
                    }
                }

                return piece;
            }

            foreach (Peg peg in p.Pegs)
            {
                if (peg.NumSpaces != -1)
                { 
                    if (!this.Trouble.IsSameColorPieceAtPosition(p, peg, this.Trouble.Dice.RollValue))
                    {
                        piece = peg;
                    }
                }
            }

           return piece;
        }

        /// <summary>
        /// gets the peg choice if a 6 is rolled
        /// </summary>
        /// <param name="p">passes the ai</param>
        /// <param name="count">passes the count of pegs at home</param>
        /// <param name="isHardmode">whether it's insane mode or not</param>
        /// <returns>returns the peg choice if a 6 is rolled</returns>
        public Peg AIPegChoice6(Player p, int count, bool isHardmode)
        {
            bool noPegAtStart = !this.Trouble.IsSameColorPieceNotAtPositionStart(p);
            if (noPegAtStart)
            {
                Peg temp = p.Pegs[0];
                if (count == 0)
                {
                    if (isHardmode)
                    {
                        temp = this.Trouble.InsaneModePegSel(p, this.Trouble.Dice.RollValue);
                    }

                   foreach (Peg peg in p.Pegs)
                    {
                        if (peg.NumSpaces > temp.NumSpaces)
                        {
                            temp = peg;
                        }
                    }

                    return temp;
                }
                else
                {
                    if (isHardmode)
                    {
                        if ((p.Pegs.Count - count) > 1)
                        {
                            temp = this.Trouble.InsaneModePegSel(p, this.Trouble.Dice.RollValue);
                            return temp;
                        }
                    }

                    return this.PegAtNumSpaces(p, -1);
                }
            }
            else
            {
                return this.PegAtNumSpaces(p, 0);
            }
        }
     
        /// <summary>
        /// Gets a peg if it's distance is equal to one of the following
        /// </summary>
        /// <param name="p">passes reference to the player</param>
        /// <param name="pos"> reference to the distance traveled we want</param>
        /// <returns> the particular peg selection from the player</returns>
        public Peg PegAtNumSpaces(Player p, int pos)
        {
            Peg piece = new Peg();
            foreach (Peg peg in p.Pegs)
            {
                if (peg.NumSpaces == pos)
                {
                    piece = peg;
                    return piece;
                }
            }

            return piece;
        }                  

        /// <summary>
        /// method handles the AI players turn
        /// </summary>
        /// <param name="p">passes reference to the player(ai)</param>
        public void AiTurn(Player p)
        {
            if (this.gameOver)
            {
                this.gameOver = false;
                WinnerForm wf = new WinnerForm(this.Trouble.Winners);
                wf.Owner = this;
                wf.StartPosition = FormStartPosition.CenterParent;
                wf.ShowDialog();
                if (wf.Over)
                {
                    wf.Close();
                    this.ResetAll();
                }
            }

            Peg selection = this.AiPeg(p);
            this.SelectPeg(selection);
        }

        /// <summary>
        /// Checks to see if any pegs are in play
        /// </summary>
        /// <param name="p">reference to the player</param>
        /// <returns> true if all pegs are at home/and/or at finish</returns>
        public bool NoPegsInPlay(Player p)
        {
            int count = 0;
            foreach (Peg t in p.Pegs)
            {
                if (t.NumSpaces == -1)
                {
                    count++;
                }
            }

            if (count == p.Pegs.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks to see if a peg is at the players home location
        /// </summary>
        /// <param name="p">Accepts a player instance</param>
        /// <returns>Returns true if any player's peg is at home</returns>
        public bool PlayerPegAtStart(Player p) 
        {
            foreach (Peg t in p.Pegs)
            {
                if (t.NumSpaces == 0)
                {
                    return true;
                }
            }

                return false;
        }

        /// <summary>
        /// Changes the panel based upon the players color
        /// </summary>
        /// <param name="color"> the color passed</param>
        public void ChangePanel(string color)
        {
            this.ResetPanels();
            if (color == "Red")
            {
                this.panel1.BackColor = Color.Red;
            }

            if (color == "Yellow")
            {
                this.panel2.BackColor = Color.Yellow;
            }

            if (color == "Blue")
            {
                this.panel3.BackColor = Color.Blue;
            }

            if (color == "Green")
            {
                this.panel4.BackColor = Color.Green;
            }
        }

        /// <summary>
        /// Resets the panels colors
        /// </summary>
        public void ResetPanels()
        {
            this.panel1.BackColor = Color.Transparent;
            this.panel2.BackColor = Color.Transparent;
            this.panel3.BackColor = Color.Transparent;
            this.panel4.BackColor = Color.Transparent;
        }
        
        /// <summary>
        /// Sets the origin of the circular button (it's position)
        /// </summary>
        public void SetOrigin()
        {
            foreach (CircularButton pegButton in this.Controls.OfType<CircularButton>())
            {
                System.Drawing.Point xy = new Point(); // establish a new point variable
                xy = pegButton.Location; // set the new variable to the original circularButton location
                pegButton.Origin = xy; // set it's origin to our temp variable which holds the origin
            }
        }

        /// <summary>
        /// updates the name labels based upon their name's
        /// </summary>
        public void UpdateNameLabels()
        {
            this.labelNameRed.Text = this.Trouble.Players[0].Name;
            this.labelNameYellow.Text = this.Trouble.Players[1].Name;

            for (int i = 2; i < this.Trouble.Players.Count; i++)
            {
                if (i == 2)
                {
                    this.labelNameBlue.Text = this.Trouble.Players[2].Name;
                    this.labelNameBlue.Visible = true;
                }

                if (i == 3)
                {
                    this.labelNameGreen.Text = this.Trouble.Players[3].Name;
                    this.labelNameGreen.Visible = true;
                }
            }
        }

        /// <summary>
        /// Checks to see if there's a winner
        /// </summary>
        /// <param name="players">passes the list of players</param>
        /// <returns> returns whether or not their is a winner</returns>
        public bool CheckForWinner(List<Player> players)
        {
            int winnersCount = this.Trouble.Winners.Count;
            bool flag = players.Count <= 2 && this.Trouble.Winners.Count == 0;
            if (flag && winnersCount == 0)
            {
                foreach (Player p in players)
                {
                    if (p.FinishPegs.Count == 4)
                    {
                        this.DisplayFinishButtons(p);
                        this.wmp.URL = "Winner.mp3";
                        string winner = p.Name + " is the Winner!";
                        this.talkBot.Speak(winner);
                        this.Trouble.Winners.Add(p);
                        this.Trouble.Players.Remove(p);
                        return true;
                    }
                }
            }
            else
            {
                foreach (Player p in players)
                {
                    if (p.FinishPegs.Count == 4)
                    {
                        if (this.Trouble.Winners.Count == 0)
                        {
                            this.wmp.URL = "Winner.mp3";
                            string winner = "Winner! \n" + (winnersCount + 1) + "st place goes to " + p.Name;
                            this.talkBot.Speak(winner);
                            this.Trouble.Winners.Add(p);
                            this.Trouble.Players.Remove(p);
                            return false;
                        }

                        if (this.Trouble.Winners.Count == 1)
                        {
                            string winner = "Winner! \n" + (winnersCount + 1) + "nd place goes to " + p.Name;
                            this.talkBot.Speak(winner);
                            this.Trouble.Winners.Add(p);
                            this.Trouble.Players.Remove(p);

                            if (this.Trouble.Players.Count == 1)
                            {
                                return true;
                            }

                            return false;
                        }

                        if (this.Trouble.Winners.Count == 2 || this.Trouble.Players.Count == 1)
                        {
                            this.Trouble.Winners.Add(p);
                            this.Trouble.Players.Remove(p);
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// method ends the game
        /// </summary>
        public void EndGame()
        {
            WinnerForm wf = new WinnerForm(this.Trouble.Winners);
            wf.Owner = this;
            wf.StartPosition = FormStartPosition.CenterParent;
            wf.ShowDialog();
            if (wf.Over)
            {
                wf.Close();
                this.ResetAll();
            }
        }

        /// <summary>
        /// if the turn is over the count limit set back to 0
        /// </summary>
        /// <param name="turn">passes the current turn</param>
        public void IsTurnOverCountLimit(int turn)
        {
            if (turn >= this.Trouble.Players.Count)
            {
                this.Trouble.Turn = 0; // then set the turn to 0
            }
        }

        /// <summary>
        /// resets the game
        /// </summary>
        public void ResetAll()
        {
            try
            {
                // run the program again and close this one
                Process.Start(Application.StartupPath + "\\Trouble.exe");

                // close this one
                System.Windows.Forms.Application.Exit();
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Reset button event on reset click
        /// </summary>
        /// <param name="sender">passes the button clicked</param>
        /// <param name="e">passes the associated event</param>
        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = MessageBox.Show("Are you sure you want to reset?", "Confirm Reset", MessageBoxButtons.YesNo);
            if (this.DialogResult == DialogResult.Yes)
            {
                this.ResetAll();
            }
        }

        /// <summary>
        /// The exit button method
        /// </summary>
        /// <param name="sender"> passes the button clicked</param>
        /// <param name="e"> passes the associated event</param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = MessageBox.Show("Are you sure you want Exit?", "Are You Sure?", MessageBoxButtons.YesNo);
            if (this.DialogResult == DialogResult.Yes)
            {
                this.talkBot.Speak("Goodbye");
                this.Close(); // close the game
            }
        }

        /// <summary>
        /// welcomes the players to the game
        /// </summary>
        private void WelcomeNames()
        {
            foreach (Player p in this.Trouble.Players)
            {
                if (p.Name != "Batman")
                {
                    this.talkBot.Speak(p.Name);
                }
                else
                {
                    this.talkBot.Speak("bat man");
                }
            }

            this.myStopwatch = new Stopwatch();
            this.myStopwatch.Start();
            while (this.myStopwatch.Elapsed.TotalSeconds < 2)
            {
                Application.DoEvents();
            }

            this.myStopwatch.Stop();
        }

        /// <summary>
        /// Animates the label roll
        /// </summary>
        private void AnimateRoll()
        {
            this.wmp.controls.play(); // play the dice roll sound
           Random rand = new Random();
            int r = rand.Next(10, 35);
           Point point = new Point();
           point = this.LblRoll.Location;
           int t, x, y;
           x = point.X;
           y = point.Y;

            for (int i = 0; i < 3; i++)
            {
                int e = rand.Next(0, 2);
                if (i % 2 == 0)
                {
                    if (e == 0)
                    {
                        this.LblRoll.Location = new Point(x + r, y);
                        t = rand.Next(1, 7);
                        this.LblRoll.Text = t.ToString();
                    }
                    else
                    {
                        this.LblRoll.Location = new Point(x - r, y);
                        t = rand.Next(1, 7);
                        this.LblRoll.Text = t.ToString();
                    }
                }
                else
                {
                    if (e == 0)
                    {
                        this.LblRoll.Location = new Point(x, y + r);
                        t = rand.Next(1, 7);
                        this.LblRoll.Text = t.ToString();
                    }
                    else
                    {
                        this.LblRoll.Location = new Point(x, y - r);
                        t = rand.Next(1, 7);
                        this.LblRoll.Text = t.ToString();
                    }
                }

                this.LblRoll.Invalidate();
                this.LblRoll.Update();
                Thread.Sleep(200);
            }

            this.LblRoll.Location = new Point(x, y);
            this.Trouble.Pop();
        }

        /// <summary>
        /// Displays information about the creators of the game
        /// </summary>
        /// <param name="sender">passes the reference to control</param>
        /// <param name="e">the associated event</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Trouble Design By:" + "\n" + "\n" +
                "Dalton Hodkiewicz," + "\n" +
                "Julie Johannes-Frohliger," + "\n" +
                "and Travis Lambert" + "\n" + "\n" + "© 2018",
                "Informational",
                MessageBoxButtons.OK);
        }

        /// <summary>
        /// is the player a computer or not
        /// </summary>
        /// <param name="p">passes reference to the player</param>
        private void IsComputer(Player p)
        {
            Application.DoEvents();

            if (p is Computer)
            {
                this.ChangePanel(p.Color);
                int tempturn = this.Trouble.Turn;
                this.LabelRoll();
                if (tempturn == this.Trouble.Turn)
                {
                    this.AiTurn(p);
                }
            }
        }

        /// <summary>
        /// Instantiates the game and display
        /// </summary>
        /// <param name="total">total number of players</param>
        /// <param name="computer">the number of computers</param>
        /// <param name="isHardMode">if they are insane mode</param>
        private void GetPlayers(int total, int computer, bool isHardMode)
        {
            this.Display = new Display();
            this.Trouble = new Game(total, this.LblRoll, this, computer, isHardMode, this.myStopwatch, this.talkBot);
            this.SetPegButtons();
            if (total > 2)
            {
                this.ShowPegs("Blue");
            }

            if (total > 3)
            {
                this.ShowPegs("Green");
            }

            this.LblRoll.Enabled = true;
            this.ChangePanel(this.Trouble.Players[this.Trouble.Turn].Color);
            this.SetOrigin();
            this.UpdateNameLabels();
            this.wmp.URL = "Welcome.mp3";
            this.wmp.controls.play();
            this.WelcomeNames();
            Application.DoEvents();
            this.IsComputer(this.Trouble.Players[this.Trouble.Turn]);
        }

        /// <summary>
        /// For a two player game on start click
        /// </summary>
        /// <param name="sender">passes reference to the control</param>
        /// <param name="e">the associated event</param>
        private void Player2Start_Click(object sender, EventArgs e)
        {
            bool isHard = this.cb2playerDifficulty.SelectedIndex == 1;

            bool valid = (this.cb2player.SelectedIndex == 0 && this.cb2playerDifficulty.SelectedIndex == -1) || (this.cb2player.SelectedIndex > 0 && this.cb2playerDifficulty.SelectedIndex >= 0);

            if (valid)
            {
                this.HideMenu();
                this.GetPlayers(2, this.cb2player.SelectedIndex, isHard);
            }
            else
            {
                MessageBox.Show("You must select the number of AI players first!");
            }
        }

        /// <summary>
        /// A three player game
        /// </summary>
        /// <param name="sender">reference to the control</param>
        /// <param name="e">reference to the event</param>
        private void Player3Start_Click(object sender, EventArgs e)
        {
            bool isHard = this.cb3playerDifficulty.SelectedIndex == 1;
            bool valid = (this.cb3player.SelectedIndex == 0 && this.cb3playerDifficulty.SelectedIndex == -1) || (this.cb3player.SelectedIndex > 0 && this.cb3playerDifficulty.SelectedIndex >= 0);
            if (valid)
            {
                this.HideMenu();
                this.GetPlayers(3, this.cb3player.SelectedIndex, isHard);
            }
            else
            {
                MessageBox.Show("You must select the number of AI players first!");
            }

            this.tlStrip.Hide();
            this.lblShow.Show();
        }

        /// <summary>
        /// A four player game
        /// </summary>
        /// <param name="sender">reference to the control</param>
        /// <param name="e">reference to the event</param>
        private void Player4Start_Click(object sender, EventArgs e)
        {
            bool isHard = this.cb4playerDifficulty.SelectedIndex == 1;
            bool valid = (this.cb4player.SelectedIndex == 0 && this.cb4playerDifficulty.SelectedIndex == -1) || (this.cb4player.SelectedIndex > 0 && this.cb4playerDifficulty.SelectedIndex >= 0);
            if (valid)
            {
                this.HideMenu();
                this.GetPlayers(4, this.cb4player.SelectedIndex, isHard);
            }
            else
            {
                MessageBox.Show("You must select the number of AI players first!");
            }
        }

        /// <summary>
        /// if the selected index changed for 2 player
        /// </summary>
        /// <param name="sender">reference to the control</param>
        /// <param name="e">reference to the event</param>
        private void Cb2player_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb2player.SelectedIndex != 0)
            {
                this.player2Start.Enabled = false;
                this.cb2playerDifficulty.Enabled = true;
            }
            else
            {
                this.player2Start.Enabled = true;
            }
        }

        /// <summary>
        /// if the selected index changed for 3 player
        /// </summary>
        /// <param name="sender">reference to the control</param>
        /// <param name="e">reference to the event</param>
        private void Cb3player_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb3player.SelectedIndex != 0)
            {
                this.player3Start.Enabled = false;
                this.cb3playerDifficulty.Enabled = true;
            }
            else
            {
                this.player3Start.Enabled = true;
            }
        }

        /// <summary>
        /// if the selected index changed for 4 player
        /// </summary>
        /// <param name="sender">reference to the control</param>
        /// <param name="e">reference to the event</param>
        private void Cb4player_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb4player.SelectedIndex != 0)
            {
                this.player4Start.Enabled = false;
                this.cb4playerDifficulty.Enabled = true;            
            }
            else
            {
                this.player4Start.Enabled = true;
            }
        }

        /// <summary>
        /// if the index changed enabled the start
        /// </summary>
        /// <param name="sender">reference to the control</param>
        /// <param name="e">the associated event</param>
        private void Cb2playerDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.player2Start.Enabled = true;
        }

        /// <summary>
        /// if the index changed enabled the start
        /// </summary>
        /// <param name="sender">reference to the control</param>
        /// <param name="e">the associated event</param>
        private void Cb3playerDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.player3Start.Enabled = true;
        }

        /// <summary>
        /// if the index changed enabled the start
        /// </summary>
        /// <param name="sender">reference to the control</param>
        /// <param name="e">the associated event</param>
        private void Cb4playerDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.player4Start.Enabled = true;
        }

        /// <summary>
        /// plays our shake sound animation
        /// </summary>
        private void TimerTick()
        {
            this.wmp.URL = "Shake.mp3";
            this.wmp.controls.play();
            this.timer.Start();
            this.AnimateRoll();
            this.timer.Stop();
        }

        /// <summary>
        /// Method that will set the players buttons to their pegs
        /// </summary>
        private void SetPegButtons()
        {
            int v = 0;
            bool isThree = this.Trouble.Players.Count > 2;
            bool isFour = this.Trouble.Players.Count > 3;

            foreach (CircularButton cb in this.Controls.OfType<CircularButton>())
            {
                    if (cb.Name.Contains("Red"))
                    {
                        foreach (char c in cb.Name)
                        {
                            if (char.IsDigit(c))
                            {
                                v = c - '0';
                                v = v - 1;
                                this.Trouble.Players[0].Pegs[v].CircularBtn = cb;
                            }
                        }
                    }

                    if (cb.Name.Contains("Yellow"))
                    {
                        foreach (char c in cb.Name)
                        {
                            if (char.IsDigit(c))
                            {
                                v = c - '0';
                                v = v - 1;
                                this.Trouble.Players[1].Pegs[v].CircularBtn = cb;
                            }
                        }
                    }

                    if (cb.Name.Contains("Blue") && isThree)
                    {
                        foreach (char c in cb.Name)
                        {
                            if (char.IsDigit(c))
                            {
                                v = c - '0';
                                v = v - 1;
                                this.Trouble.Players[2].Pegs[v].CircularBtn = cb;
                            }
                        }
                    }

                    if (cb.Name.Contains("Green") && isFour)
                    {
                        foreach (char c in cb.Name)
                        {
                            if (char.IsDigit(c))
                            {
                                v = c - '0';
                                v = v - 1;
                                this.Trouble.Players[3].Pegs[v].CircularBtn = cb;
                            }
                        }
                    }

                    cb.Origin = cb.Location;              
            }
        }

        /// <summary>
        /// updates the position of all the buttons on the board
        /// </summary>
        private void UpdateAllButtons()
        {
            foreach (Player p in this.Trouble.Players)
            {
                foreach (Peg peg in p.Pegs)
                {
                    if (peg.NumSpaces == -1)
                    {
                       Point temp = new Point();
                        temp = peg.CircularBtn.Origin;
                        peg.CircularBtn.Location = temp; // if numspaces are -1 set back to origin
                    }

                    if (peg.NumSpaces > -1 && peg.NumSpaces < 28)
                    {
                        int position = peg.AbsolutePosition;
                        peg.CircularBtn.Location = Display.ReturnPoint(position);
                    }
                }

                if (p.FinishPegs.Count > 0)
                {
                    this.DisplayFinishButtons(p);
                }
            }
        }

        /// <summary>
        /// displays the finish buttons
        /// </summary>
        /// <param name="p">references the player</param>
        private void DisplayFinishButtons(Player p)
        {
            int count = 0;
            foreach (Peg peg in p.FinishPegs)
            {
                peg.CircularBtn.Location = Display.FinishLocations[Display.GetFinishLocation(p, count)];
                count++;
            }

            if (this.Trouble.Winners.Count > 0)
            {
                foreach (var winner in this.Trouble.Winners)
                {
                    count = 0;
                    foreach (Peg peg in winner.FinishPegs)
                    {
                        peg.CircularBtn.Location = Display.FinishLocations[Display.GetFinishLocation(winner, count)];
                        count++;
                    }
                }
            }
        }

        /// <summary>
        /// flag variable to indicate whether a peg could land on another
        /// </summary>
        /// <param name="c">Accepts a CircularButton</param>
        /// <returns> Returns true if a players peg will land on another</returns>
        private bool WillPegLandOnAnother(CircularButton c)
        {
            foreach (Peg p in this.Trouble.Players[this.Trouble.Turn].Pegs)
            {
                if (c.HumanPeg.NumSpaces + this.Trouble.Dice.RollValue == p.NumSpaces)
                {
                    if (c.HumanPeg.Id != p.Id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Show the tool strip on Mouse over
        /// </summary>
        /// <param name="sender">passes the control</param>
        /// <param name="e">passes the associated event</param>
        private void LblShow_MouseHover(object sender, EventArgs e)
        {
            this.tlStrip.Show();
        }

        /// <summary>
        /// hides the menu and shows the label for showing the menu
        /// </summary>
        private void HideMenu()
        {
            this.tlStrip.Hide();
            this.lblShow.Show();
        }
    }
}
