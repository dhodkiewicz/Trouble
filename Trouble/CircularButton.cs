//-----------------------------------------------------------------------
// <copyright file="CircularButton.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Trouble
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Creates a derived class of Button, and allows it to become circular
    /// </summary>
    public class CircularButton : Button
    {
        /// <summary>
        /// holds the id of the button
        /// </summary>
        private int id;

        /// <summary>
        /// the original position of the button
        /// </summary>
        private System.Drawing.Point origin;

        /// <summary>
        /// indicates whether the button is home or not
        /// </summary>
        private bool notHome;

        /// <summary>
        /// Gets or sets the correlating peg
        /// </summary>
        public Peg HumanPeg { get; set; }

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether away from home
        /// </summary>
        public bool NotHome
        {
            get { return this.notHome; }
            set { this.notHome = value; }
        }

        /// <summary>
        /// Gets or sets the origin of the control when the board is initialized
        /// </summary>
        public System.Drawing.Point Origin
        {
            get { return this.origin; }
            set { this.origin = value; }
        }

        /// <summary>
        /// overrides the normal graphics path, this allows it to be circular
        /// </summary>
        /// <param name="prevent"> passes the paint event</param>
        protected override void OnPaint(PaintEventArgs prevent)
        {
            GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(graphPath);
            base.OnPaint(prevent);
        }
    }
}
