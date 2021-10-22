//-----------------------------------------------------------------------
// <copyright file="Display.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Trouble
{
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Documentation for Display Class
    /// </summary>
    public class Display
    {
        /// <summary>
        /// sets the array of board locations
        /// </summary>
        private Point[] boardLocations = new Point[]
        {
            new Point { X = 213, Y = 476 }, // red start (0)
            new Point { X = 162, Y = 461 },
            new Point { X = 126, Y = 433 },
            new Point { X = 91, Y = 398 },
            new Point { X = 61, Y = 362 },
            new Point { X = 53, Y = 318 },
            new Point { X = 53, Y = 266 },
            new Point { X = 53, Y = 225 }, // yellow start  (7)
            new Point { X = 61, Y = 182 },
            new Point { X = 87, Y = 151 },
            new Point { X = 125, Y = 119 },
            new Point { X = 158, Y = 82 },
            new Point { X = 205, Y = 63 },
            new Point { X = 255, Y = 63 },
            new Point { X = 307, Y = 63 }, // blue start (14)
            new Point { X = 356, Y = 81 },
            new Point { X = 394, Y = 114 },
            new Point { X = 424, Y = 143 },
            new Point { X = 451, Y = 177 },
            new Point { X = 466, Y = 218 },
            new Point { X = 466, Y = 265 },
            new Point { X = 466, Y = 308 }, // green start (21)
            new Point { X = 466, Y = 353 },
            new Point { X = 433, Y = 392 },
            new Point { X = 394, Y = 429 },
            new Point { X = 355, Y = 454 },
            new Point { X = 312, Y = 473 },
            new Point { X = 261, Y = 476 }
        };

        /// <summary>
        /// the finish locations for the buttons
        /// </summary>
        private Point[] finishLocations = new Point[]
        {
            // red finish coordinates
            new Point { X = 256, Y = 421 },
            new Point { X = 258, Y = 382 },
            new Point { X = 260, Y = 343 },
            new Point { X = 218, Y = 343 },

            // yellow finish
            new Point { X = 99, Y = 270 },
            new Point { X = 142, Y = 268 },
            new Point { X = 180, Y = 270 },
            new Point { X = 180, Y = 229 },

            // blue finish
            new Point { X = 256, Y = 110 },
            new Point { X = 256, Y = 149 },
            new Point { X = 254, Y = 187 },
            new Point { X = 293, Y = 187 },

            // green finish
            new Point { X = 418, Y = 264 },
            new Point { X = 376, Y = 263 },
            new Point { X = 335, Y = 263 },
            new Point { X = 335, Y = 303 }
        };

        /// <summary>
        /// Gets the board location for the peg button
        /// </summary>
        public Point[] BoardLocations
        {
            get { return this.boardLocations; }
        }

        /// <summary>
        /// Gets the finish location for the peg button
        /// </summary>
        public Point[] FinishLocations
        {
            get { return this.finishLocations; }
        }

        /// <summary>
        /// Returns a point position
        /// </summary>
        /// <param name="x">passes the index for our board location array</param>
        /// <returns> Returns the new point</returns>
        public Point ReturnPoint(int x)
        {
            Point temp = new Point();
            temp = this.BoardLocations[x];
            return temp;
        }

        /// <summary>
        /// Gets the buttons that are not at finish locations
        /// </summary>
        /// <param name="buttons">passes the list of circular buttons</param>
        /// <returns>Returns a list of buttons not at finish positions</returns>
        public List<CircularButton> GetNotFinishButtons(List<CircularButton> buttons)
        {
            List<CircularButton> notFinishButtons = new List<CircularButton>();
            foreach (CircularButton b in buttons)
            {
                string name = b.Tag.ToString();

                if (!name.Contains("Finish"))
                {
                    notFinishButtons.Add(b); // add the button only if it's not home
                }
            }

            return notFinishButtons;
        }

        /// <summary>
        /// Gets the corresponding finish location for the players peg
        /// </summary>
        /// <param name="p"> reference to the player</param>
        /// <param name="x"> reference to the location</param>
        /// <returns>Returns the proper index for the finish position</returns>
        public int GetFinishLocation(Player p, int x)
        {
            int index = 0;
            if (p.Color == "Yellow")
            {
                index = 4;
            }

            if (p.Color == "Blue")
            {
                index = 8;
            }

            if (p.Color == "Green")
            {
                index = 12;
            }

            return x + index;
        }
    }
}
