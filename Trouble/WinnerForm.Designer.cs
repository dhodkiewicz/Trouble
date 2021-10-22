//-----------------------------------------------------------------------
// <copyright file="WinnerForm.Designer.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Trouble
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Designer generated code for the winner form
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "reviewed")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "reviewed")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "*", Justification = "reviewed")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "*", Justification = "reviewed")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "*", Justification = "reviewed")]
    public partial class WinnerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFirst = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblThird = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirst.ForeColor = System.Drawing.Color.Gold;
            this.lblFirst.Location = new System.Drawing.Point(37, 24);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(0, 33);
            this.lblFirst.TabIndex = 0;
            this.lblFirst.Visible = false;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecond.ForeColor = System.Drawing.Color.SlateGray;
            this.lblSecond.Location = new System.Drawing.Point(37, 78);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(0, 33);
            this.lblSecond.TabIndex = 1;
            this.lblSecond.Visible = false;
            // 
            // lblThird
            // 
            this.lblThird.AutoSize = true;
            this.lblThird.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThird.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblThird.Location = new System.Drawing.Point(37, 138);
            this.lblThird.Name = "lblThird";
            this.lblThird.Size = new System.Drawing.Size(0, 33);
            this.lblThird.TabIndex = 2;
            this.lblThird.Visible = false;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(246, 204);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 3;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // WinnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(588, 239);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblThird);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblFirst);
            this.Name = "WinnerForm";
            this.Text = "Congratulations!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WinnerForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblFirst;
        public System.Windows.Forms.Label lblSecond;
        public System.Windows.Forms.Label lblThird;
        private System.Windows.Forms.Button btnNewGame;
    }
}