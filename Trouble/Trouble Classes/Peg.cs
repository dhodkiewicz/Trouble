//-----------------------------------------------------------------------
// <copyright file="Peg.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Trouble
{
    /// <summary>
    /// Documentation for Peg class
    /// </summary>
    public class Peg
    {
        /// <summary>
        /// Positional Tracking on the Board
        /// </summary>
        private int numSpaces;

        /// <summary>
        /// the absolute position on the board
        /// </summary>
        private int absolutePosition;

        /// <summary>
        /// the pegs id
        /// </summary>
        private int id;

        /// <summary>
        /// the circular button associated with the peg 1:1 ratio
        /// </summary>
        private CircularButton circularBtn;

        /// <summary>
        /// Initializes a new instance of the <see cref="Peg"></see> class
        /// </summary>
        public Peg()
        {
            this.numSpaces = -1;
            this.absolutePosition = -1;
        }

        /// <summary>
        /// Gets or sets the absolute position
        /// </summary>
        public int AbsolutePosition
        {
            get { return this.absolutePosition; }
            set { this.absolutePosition = value; }
        }

        /// <summary>
        /// Gets or sets the number of peg spaces the peg has traveled
        /// </summary>
        public int NumSpaces
        {
            get
            {
                return this.numSpaces;
            }

            set
            {
                    this.numSpaces = value;
            }
        }

        /// <summary>
        /// Gets or sets the Id of the peg
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets the associated button
        /// </summary>
        public CircularButton CircularBtn
        {
            get { return this.circularBtn; }
            set { this.circularBtn = value; }
        }
    }
}
