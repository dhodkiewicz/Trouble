//-----------------------------------------------------------------------
// <copyright file="Computer.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Trouble
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A derived class of player that is an AI
    /// </summary>
    public class Computer : Player
    {
        /// <summary>
        /// whether or not the computer is hard mode
        /// </summary>
        private bool isHardMode;

        /// <summary>
        /// Gets or sets a value indicating whether the computer is insane
        /// </summary>
        public bool IsHardMode
        {
            get { return this.isHardMode; }
            set { this.isHardMode = value; }
        }
    }
}
