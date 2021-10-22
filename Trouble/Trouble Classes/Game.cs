//-----------------------------------------------------------------------
// <copyright file="Game.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Trouble
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Speech.Synthesis;
    using System.Windows.Forms;

    /// <summary>
    /// Documentation for Game class
    /// </summary>
    public class Game
    {
        /// <summary>
        /// the games list of players
        /// </summary>
        private List<Player> players;

        /// <summary>
        /// the games list of winners
        /// </summary>
        private List<Player> winners;

        /// <summary>
        /// the current turn
        /// </summary>
        private int turn;

        /// <summary>
        /// the current instance of dice
        /// </summary>
        private PopOMatic dice;

        /// <summary>
        /// the roll label
        /// </summary>
        private Label roll;

        /// <summary>
        /// the instance of form
        /// </summary>
        private Form1 form;

        /// <summary>
        /// the stopwatch from form
        /// </summary>
        private Stopwatch stopWatch;

        /// <summary>
        /// the passed speech synthesizer instance or set instance
        /// </summary>
        private SpeechSynthesizer talkBot; // an object for speaking

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"></see> class
        /// </summary>
        /// <param name="totalPlayers">accepts the number of players</param>
        /// <param name="roll"> accepts the label</param>
        /// <param name="f">accepts the form</param>
        /// <param name="numComputers">for the number of computers</param>
        /// <param name="isHardMode">whether or not it's insane mode</param>
        /// <param name="stopWatch">the stop watch</param>
        /// <param name="talkBot">the synthesizer from form</param>
        public Game(int totalPlayers, Label roll, Form1 f, int numComputers, bool isHardMode, Stopwatch stopWatch, SpeechSynthesizer talkBot)
        {
            this.talkBot = talkBot;
            this.roll = roll;
            int p;
            this.players = new List<Player>();
            this.winners = new List<Player>();
            BirthDate bd;
            for (p = 1; p <= totalPlayers - numComputers; p++)
            {
                bd = new BirthDate(p, this);
                bd.Owner = f;
                bd.StartPosition = FormStartPosition.CenterParent;
                bd.ShowDialog();
            }

            if (numComputers > 0)
            {
                this.CreateComputers(numComputers, isHardMode);
            }

            this.SortPlayers();
            this.SetPegToButton(f);
            this.turn = 0;
            this.form = f;
            this.dice = new PopOMatic(roll);
            this.stopWatch = stopWatch;
        }

        /// <summary>
        /// Gets the list of players
        /// </summary>
        public List<Player> Players
        {
            get { return this.players; }
        }

        /// <summary>
        /// Gets or sets the current turn
        /// </summary>
        public int Turn
        {
            get
            {
                return this.turn;
            }

            set
            {
                if (this.turn >= this.players.Count - 1)
                {
                    this.turn = 0;
                }
                else
                {
                    this.turn = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the current dice
        /// </summary>
        public PopOMatic Dice
        {
            get { return this.dice; }
            set { this.dice = value; }
        }

        /// <summary>
        /// Gets or sets the current list of winners
        /// </summary>
        public List<Player> Winners
        {
            get { return this.winners; }
            set { this.winners = value; }
        }

        /// <summary>
        /// Gets the dice roll, but also sets the previous
        /// </summary>
        /// <returns> the dice roll</returns>
        public int Pop()
        {
            this.dice.PreviousRoll = this.dice.RollValue;
            return this.dice.Roll();
        }

        /// <summary>
        /// Moves the peg to a finishing location
        /// </summary>
        /// <param name="player">reference to player</param>
        /// <param name="p">reference to their peg</param>
        /// <returns>returns the count of the finish position pegs the player has</returns>
        public int MovePegToFinish(Player player, Peg p)
        {
            int count = player.FinishPegs.Count;
            p.AbsolutePosition = 28 + count;
            player.FinishPegs.Add(p); // add to the finish list
            player.Pegs.Remove(p);
            this.form.Wmp.URL = "lucky.mp3";
            this.form.Wmp.controls.play();
            this.stopWatch = new Stopwatch();
            this.stopWatch.Start();
            while (this.stopWatch.Elapsed.Seconds < 2)
            {
                Application.DoEvents();
            }

            this.stopWatch.Stop();
            return player.FinishPegs.Count - 1;
        }

        /// <summary>
        /// This enforces the players pegs to stay in bounds
        /// </summary>
        /// <param name="coordinate"> the coordinate before adjustment</param>
        /// <returns> returns the proper board location</returns>
        public int AmountOverXCoordinate(int coordinate)
        {
            const int BOARD_MAX = 28;
            int amountOverMax = coordinate - BOARD_MAX;
            return amountOverMax;
        }

        /// <summary>
        /// Sends a peg home if one is landed on
        /// </summary>
        /// <param name="p">the players peg</param>
        /// <param name="players">list of games players</param>
        /// <param name="p1"> the player</param>
        public void SendPegHome(Peg p, List<Player> players, Player p1)
        {
            // step through the players
            foreach (Player x in players)
            {   // step through the players pegs
                if (x != p1)
                {
                    foreach (var peg in x.Pegs)
                    {
                        if (peg.AbsolutePosition != -1)
                        {
                            // if this pegs board position equals another players
                            if (p.AbsolutePosition == peg.AbsolutePosition)
                            {
                                peg.AbsolutePosition = -1;
                                peg.NumSpaces = -1;
                                peg.CircularBtn.Location = peg.CircularBtn.Origin;
                                this.stopWatch = new Stopwatch();
                                this.form.Wmp.URL = "Cena.mp3";
                                this.form.Wmp.settings.volume = 65;
                                this.form.Wmp.controls.play();
                                this.stopWatch.Start();
                                while (this.stopWatch.Elapsed.TotalSeconds < 3)
                                {
                                    Application.DoEvents();
                                }

                                this.stopWatch.Stop();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// checks to see if a same colored peg is at position
        /// </summary>
        /// <param name="p">the player</param>
        /// <param name="peg">the peg</param>
        /// <param name="diceroll"> the value of the dice roll</param>
        /// <returns>whether or not it will land on it's own peg</returns>
        public bool IsSameColorPieceAtPosition(Player p, Peg peg, int diceroll)
        {
            foreach (Peg x in p.Pegs)
            {
                if (peg.NumSpaces + diceroll == x.NumSpaces && x.NumSpaces < 28)
                {
                    this.form.Wmp.URL = "ahaha.mp3";
                    this.form.Wmp.controls.play();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// gets the selection for Insane mode
        /// </summary>
        /// <param name="p">passes the ai</param>
        /// <param name="diceroll">takes in the current dice roll value</param>
        /// <returns> a peg selection based upon deeper logic, if it can land on a peg it will, and it will take the furthest one if there's multiple</returns>
        public Peg InsaneModePegSel(Player p, int diceroll)
        {
            Peg tempPeg = new Peg();

            foreach (Peg peg in p.Pegs)
            {
                if (peg.NumSpaces > tempPeg.NumSpaces)
                {
                    tempPeg = peg;
                }
            }

            foreach (Player player in this.Players)
            {
                if (player != p)
                {
                    foreach (Peg x in p.Pegs)
                    {
                        if (x.NumSpaces != -1)
                        {
                            foreach (Peg enemyPeg in player.Pegs)
                            {
                                if (x.AbsolutePosition + diceroll == enemyPeg.AbsolutePosition)
                                {
                                    tempPeg = x;
                                    if (tempPeg.NumSpaces < x.NumSpaces + diceroll)
                                    {
                                        tempPeg = x;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return tempPeg;
        }

        /// <summary>
        /// checks to see if the same color peg is at the start position
        /// </summary>
        /// <param name="p">passes the player</param>
        /// <returns>returns true if start position isn't occupied by own piece</returns>
        public bool IsSameColorPieceNotAtPositionStart(Player p)
        {
            foreach (Peg x in p.Pegs)
            {
                if (x.NumSpaces == 0)
                {
                    this.roll.Enabled = false;
                    bool check = p is Computer;
                    if (!check)
                    {
                        this.form.Wmp.URL = "ahaha.mp3";
                        this.form.Wmp.controls.play();
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// gets the board location
        /// </summary>
        /// <param name="color">the players color</param>
        /// <param name="x">the current distance traveled by the peg</param>
        /// <returns>the proper board location offset by color</returns>
        public int GetBoardLocation(string color, int x)
        {
            if (color == "Yellow")
            {
                x += 7;
            }

            if (color == "Blue")
            {
                x += 14;
            }

            if (color == "Green")
            {
                x += 21;
            }

            if (x >= 28)
            {
                x = this.AmountOverXCoordinate(x);
            }

            return x;
        }

        /// <summary>
        /// sorts the games players based on age
        /// </summary>
        public void SortPlayers()
        {
            List<Player> tempPlayers = new List<Player>();
            tempPlayers = this.players.OrderByDescending(o => o.DOB).ToList();
            this.players = tempPlayers;

            for (int i = 0; i < this.players.Count; i++)
            {
                if (i == 0)
                {
                    this.players[i].Color = "Red";
                }
                else if (i == 1)
                {
                    this.players[i].Color = "Yellow";
                }
                else if (i == 2)
                {
                    this.players[i].Color = "Blue";
                }
                else
                {
                    this.players[i].Color = "Green";
                }
            }
        }

        /// <summary>
        /// creates the computers players
        /// </summary>
        /// <param name="x">the number of AI</param>
        /// <param name="isHardMode">whether or not it's insane mode</param>
        public void CreateComputers(int x, bool isHardMode)
        {
            Computer ai;
            for (int i = 1; i <= x; i++)
            {
                ai = new Computer();
                ai.Name = this.CompName(i);
                ai.DOB = this.CompDob(i);
                ai.IsHardMode = isHardMode;
                this.players.Add(ai);
            }
        }

        /// <summary>
        /// sets our computers names
        /// </summary>
        /// <param name="x">Based on the number of computers</param>
        /// <returns>returns the name of our computer</returns>
        public string CompName(int x)
        {
            if (x == 1)
            {
                return "Wonder Woman";
            }

            if (x == 2)
            {
                return "Batman";
            }

            if (x == 3)
            {
                return "Iron Man";
            }

            if (x == 4)
            {
                return "Thanos";
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Sets the date of birth for our computer
        /// </summary>
        /// <param name="x">the number of the player</param>
        /// <returns>the date time object</returns>
        public DateTime CompDob(int x)
        {
            DateTime dob;
            if (x == 1)
            {
                return dob = new DateTime(1992, 1, 24);
            }

            if (x == 2)
            {
                return dob = new DateTime(1987, 1, 24);
            }

            if (x == 3)
            {
                return dob = new DateTime(2017, 7, 24);
            }

            if (x == 4)
            {
                return dob = new DateTime(1800, 7, 24);
            }

             return new DateTime();
        }

        /// <summary>
        /// Moves the players pegs whether human or AI
        /// </summary>
        /// <param name="player">Accepts the current player that's moving</param>
        /// <param name="p">Accepts a players peg selection</param>
        /// <returns> Only returns true if this is a humans turn</returns>
        public bool MovePegs(Player player, Peg p)
        {
            bool flag = false;
            bool isComp = player.Equals(typeof(Computer));

            Application.DoEvents();

            if (this.dice.RollValue == 6)
            {
                this.stopWatch = new Stopwatch();
                this.stopWatch.Start();
                this.talkBot.Speak(this.RandomGratz());
                while (this.stopWatch.Elapsed.TotalSeconds < 1)
                {
                    Application.DoEvents();
                }

                this.stopWatch.Stop();

                if (p.NumSpaces == -1)
                {
                    if (!this.IsSameColorPieceNotAtPositionStart(player))
                    {
                        p.NumSpaces = 0; // move to starting position
                        if (!isComp)
                        {
                            flag = true;
                        }
                    }
                }
                else
                {
                    p.NumSpaces += this.dice.RollValue;
                    if (!isComp)
                    {
                        flag = true;
                    }

                    if (this.Dice.PreviousRoll == 6)
                    {
                        this.Dice.RollValue = 0;
                    }
                }
            }
            else
            {
                if (p.NumSpaces != -1)
                {
                    p.NumSpaces += this.dice.RollValue;
                    if (!isComp)
                    {
                        flag = true;
                    }
                }
            }

            if (p.NumSpaces > 27)
            {
                this.MovePegToFinish(player, p);
                player.Pegs.Remove(p);
                if (!isComp)
                {
                    return true;
                }

                return false;
            }

            p.AbsolutePosition = this.GetBoardLocation(player.Color, p.NumSpaces);
            this.SendPegHome(p, this.Players, player); // if this peg lands on another
            return flag;
        }

        /// <summary>
        /// provides a random congratulations to the player
        /// </summary>
        /// <returns> Returns a random string (catchphrase) </returns>
        private string RandomGratz()
        {
            string[] myphrases =
            {
                "Great Job" + this.Players[this.Turn].Name, "Way to Go", "Super", "Like a Boss", "Excellent", "Too Easy", "You're the sauce", "You've got the luck", "Woo Hoo!"
            };
            List<string> words = new List<string>();
            words.AddRange(myphrases);
            Random randomWord = new Random();
            int rand = randomWord.Next(0, words.Count);
            return words[rand];
        }

        /// <summary>
        /// set the human pegs to a button
        /// </summary>
        /// <param name="f">pass the form to get it's controls</param>
        private void SetPegToButton(Form f)
        {
            bool isHuman;
            int v = 0;
            foreach (Player p in this.Players)
            {
                isHuman = p is Computer;
                if (!isHuman)
                {
                    foreach (CircularButton cb in f.Controls.OfType<CircularButton>())
                    {
                        if (cb.Tag.ToString() == p.Color)
                        {
                            foreach (char c in cb.Name)
                            {
                                if (char.IsDigit(c))
                                {
                                    v = c - '0';
                                    v = v - 1;
                                    cb.HumanPeg = p.Pegs[v];
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
