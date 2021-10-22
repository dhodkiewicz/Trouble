//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Trouble
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Documentation for Player class.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// the name of the player
        /// </summary>
        private string name;

        /// <summary>
        /// the color of the  player
        /// </summary>
        private string color;

        /// <summary>
        /// the players date time object
        /// </summary>
        private DateTime dob;

        /// <summary>
        /// their list of pegs in play
        /// </summary>
        private List<Peg> pegs;

        /// <summary>
        /// the finish pegs list
        /// </summary>
        private List<Peg> finishPegs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"></see> class
        /// </summary>
        public Player()
        {
            this.DOB = new DateTime();
            this.pegs = new List<Peg>();
            this.FinishPegs = new List<Peg>();
            this.CreatePegs();
        }

        /// <summary>
        /// Gets or sets the players name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the players Color
        /// </summary>
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        /// <summary>
        /// Gets or sets the players date time object
        /// </summary>
        public DateTime DOB
        {
           get { return this.dob; }
           set { this.dob = value; }
        }

        /// <summary>
        /// Gets or sets their list of pegs
        /// </summary>
        public List<Peg> Pegs
        {
            get { return this.pegs; }
            set { this.pegs = value; }
        }

        /// <summary>
        /// Gets or sets the list of finish pegs
        /// </summary>
        public List<Peg> FinishPegs
        {
            get { return this.finishPegs; }
            set { this.finishPegs = value; }
        }

        /// <summary>
        /// Creates the players pegs
        /// </summary>
        public void CreatePegs()
        {
            for (int p = 0; p < 4; p++)
            {
                Peg playerPeg = new Peg();
                playerPeg.Id = p + 1;
                this.pegs.Add(playerPeg);
            }
        }
    }
}
