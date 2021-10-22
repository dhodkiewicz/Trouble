//-----------------------------------------------------------------------
// <copyright file="PopOMatic.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Trouble
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;

    /// <summary>
    /// Documentation for PopOMatic class
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    public class PopOMatic
    {
        /// <summary>
        /// Private field to hold previous roll in cases of multiple sixes
        /// </summary>
        private int previousRoll;

        /// <summary>
        /// Random generator for dice rolls
        /// </summary>
        private Random pop = new Random();

        /// <summary>
        /// Field used for current roll of player
        /// </summary>
        private int rollValue = 0;

        /// <summary>
        /// the label for the roll
        /// </summary>
        private Label rollLbl;

        /// <summary>
        /// Initializes a new instance of the <see cref="PopOMatic"></see> class
        /// </summary>
        /// <param name="lbl"> the lbl from the form</param>
        public PopOMatic(Label lbl)
        {
            this.rollLbl = new Label();
            this.rollLbl = lbl;
        }

        /// <summary>
        /// Gets or sets the previous roll
        /// </summary>
        public int PreviousRoll
        {
            get { return this.previousRoll; }
            set { this.previousRoll = value; }
        }

        /// <summary>
        /// Gets or sets the current roll
        /// </summary>
        public int RollValue
        {
            get { return this.rollValue; }
            set { this.rollValue = value; }
        }

        /// <summary>
        /// Gets the random roll value 1-6
        /// </summary>
        /// <returns>Returns the roll value</returns>
        public int Roll()
        {
            this.rollValue = this.pop.Next(1, 7);
            this.rollLbl.Text = this.RollValue.ToString();
            return this.rollValue;
        }
    }
}
