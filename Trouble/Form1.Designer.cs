//-----------------------------------------------------------------------
// <copyright file="Form1.Designer.cs" company="NWTC">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Trouble
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Documentation for the first part of the Form class.
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "reviewed")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "*", Justification = "reviewed")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "*", Justification = "reviewed")]
    [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "*", Justification = "reviewed")]

    public partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LblRoll = new System.Windows.Forms.Label();
            this.tlStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.player2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cb2player = new System.Windows.Forms.ToolStripComboBox();
            this.cb2playerDifficulty = new System.Windows.Forms.ToolStripComboBox();
            this.player2Start = new System.Windows.Forms.ToolStripMenuItem();
            this.player3ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cb3player = new System.Windows.Forms.ToolStripComboBox();
            this.cb3playerDifficulty = new System.Windows.Forms.ToolStripComboBox();
            this.player3Start = new System.Windows.Forms.ToolStripMenuItem();
            this.player4ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.cb4player = new System.Windows.Forms.ToolStripComboBox();
            this.cb4playerDifficulty = new System.Windows.Forms.ToolStripComboBox();
            this.player4Start = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelNameRed = new System.Windows.Forms.Label();
            this.labelNameGreen = new System.Windows.Forms.Label();
            this.labelNameBlue = new System.Windows.Forms.Label();
            this.labelNameYellow = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnYellow4 = new Trouble.CircularButton();
            this.btnYellow3 = new Trouble.CircularButton();
            this.btnYellow2 = new Trouble.CircularButton();
            this.btnYellow1 = new Trouble.CircularButton();
            this.btnBlue2 = new Trouble.CircularButton();
            this.btnBlue3 = new Trouble.CircularButton();
            this.btnBlue4 = new Trouble.CircularButton();
            this.btnBlue1 = new Trouble.CircularButton();
            this.btnGreen2 = new Trouble.CircularButton();
            this.btnGreen3 = new Trouble.CircularButton();
            this.btnGreen4 = new Trouble.CircularButton();
            this.btnGreen1 = new Trouble.CircularButton();
            this.btnRed4 = new Trouble.CircularButton();
            this.btnRed3 = new Trouble.CircularButton();
            this.btnRed2 = new Trouble.CircularButton();
            this.btnRed1 = new Trouble.CircularButton();
            this.lblShow = new System.Windows.Forms.Label();
            this.tlStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblRoll
            // 
            this.LblRoll.BackColor = System.Drawing.Color.White;
            this.LblRoll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblRoll.Enabled = false;
            this.LblRoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRoll.Location = new System.Drawing.Point(259, 266);
            this.LblRoll.Name = "LblRoll";
            this.LblRoll.Size = new System.Drawing.Size(45, 45);
            this.LblRoll.TabIndex = 20;
            this.LblRoll.Text = "1";
            this.LblRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblRoll.Click += new System.EventHandler(this.LabelRoll_Click);
            // 
            // tlStrip
            // 
            this.tlStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tlStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFile,
            this.toolStripDropDownButton1});
            this.tlStrip.Location = new System.Drawing.Point(0, 0);
            this.tlStrip.Name = "tlStrip";
            this.tlStrip.Size = new System.Drawing.Size(565, 25);
            this.tlStrip.TabIndex = 21;
            this.tlStrip.Text = "Help";
            // 
            // toolStripFile
            // 
            this.toolStripFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Size = new System.Drawing.Size(38, 22);
            this.toolStripFile.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.player2ToolStripMenuItem,
            this.player3ToolStripMenuItem1,
            this.player4ToolStripMenuItem2});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // player2ToolStripMenuItem
            // 
            this.player2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cb2player,
            this.cb2playerDifficulty,
            this.player2Start});
            this.player2ToolStripMenuItem.Name = "player2ToolStripMenuItem";
            this.player2ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.player2ToolStripMenuItem.Text = "2 Player";
            // 
            // cb2player
            // 
            this.cb2player.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cb2player.Name = "cb2player";
            this.cb2player.Size = new System.Drawing.Size(121, 23);
            this.cb2player.Text = "Number of AI";
            this.cb2player.SelectedIndexChanged += new System.EventHandler(this.Cb2player_SelectedIndexChanged);
            // 
            // cb2playerDifficulty
            // 
            this.cb2playerDifficulty.Enabled = false;
            this.cb2playerDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Insane"});
            this.cb2playerDifficulty.Name = "cb2playerDifficulty";
            this.cb2playerDifficulty.Size = new System.Drawing.Size(121, 23);
            this.cb2playerDifficulty.Text = "Difficulty";
            this.cb2playerDifficulty.SelectedIndexChanged += new System.EventHandler(this.Cb2playerDifficulty_SelectedIndexChanged);
            // 
            // player2Start
            // 
            this.player2Start.Enabled = false;
            this.player2Start.Name = "player2Start";
            this.player2Start.Size = new System.Drawing.Size(181, 22);
            this.player2Start.Text = "Start!";
            this.player2Start.Click += new System.EventHandler(this.Player2Start_Click);
            // 
            // player3ToolStripMenuItem1
            // 
            this.player3ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cb3player,
            this.cb3playerDifficulty,
            this.player3Start});
            this.player3ToolStripMenuItem1.Name = "player3ToolStripMenuItem1";
            this.player3ToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.player3ToolStripMenuItem1.Text = "3 Player";
            // 
            // cb3player
            // 
            this.cb3player.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cb3player.Name = "cb3player";
            this.cb3player.Size = new System.Drawing.Size(121, 23);
            this.cb3player.Text = "Number of AI";
            this.cb3player.SelectedIndexChanged += new System.EventHandler(this.Cb3player_SelectedIndexChanged);
            // 
            // cb3playerDifficulty
            // 
            this.cb3playerDifficulty.Enabled = false;
            this.cb3playerDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Insane"});
            this.cb3playerDifficulty.Name = "cb3playerDifficulty";
            this.cb3playerDifficulty.Size = new System.Drawing.Size(121, 23);
            this.cb3playerDifficulty.Text = "Difficulty";
            this.cb3playerDifficulty.SelectedIndexChanged += new System.EventHandler(this.Cb3playerDifficulty_SelectedIndexChanged);
            // 
            // player3Start
            // 
            this.player3Start.Enabled = false;
            this.player3Start.Name = "player3Start";
            this.player3Start.Size = new System.Drawing.Size(181, 22);
            this.player3Start.Text = "Start!";
            this.player3Start.Click += new System.EventHandler(this.Player3Start_Click);
            // 
            // player4ToolStripMenuItem2
            // 
            this.player4ToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cb4player,
            this.cb4playerDifficulty,
            this.player4Start});
            this.player4ToolStripMenuItem2.Name = "player4ToolStripMenuItem2";
            this.player4ToolStripMenuItem2.Size = new System.Drawing.Size(115, 22);
            this.player4ToolStripMenuItem2.Text = "4 Player";
            // 
            // cb4player
            // 
            this.cb4player.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cb4player.Name = "cb4player";
            this.cb4player.Size = new System.Drawing.Size(121, 23);
            this.cb4player.Text = "Number of AI";
            this.cb4player.SelectedIndexChanged += new System.EventHandler(this.Cb4player_SelectedIndexChanged);
            // 
            // cb4playerDifficulty
            // 
            this.cb4playerDifficulty.Enabled = false;
            this.cb4playerDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Insane"});
            this.cb4playerDifficulty.Name = "cb4playerDifficulty";
            this.cb4playerDifficulty.Size = new System.Drawing.Size(121, 23);
            this.cb4playerDifficulty.Text = "Difficulty";
            this.cb4playerDifficulty.SelectedIndexChanged += new System.EventHandler(this.Cb4playerDifficulty_SelectedIndexChanged);
            // 
            // player4Start
            // 
            this.player4Start.Enabled = false;
            this.player4Start.Name = "player4Start";
            this.player4Start.Size = new System.Drawing.Size(181, 22);
            this.player4Start.Text = "Start!";
            this.player4Start.Click += new System.EventHandler(this.Player4Start_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(41, 22);
            this.toolStripDropDownButton1.Text = "Info";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(318, 343);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 122);
            this.panel1.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Location = new System.Drawing.Point(206, 108);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(36, 125);
            this.panel3.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(101, 322);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(124, 39);
            this.panel2.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Location = new System.Drawing.Point(336, 211);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 33);
            this.panel4.TabIndex = 25;
            // 
            // labelNameRed
            // 
            this.labelNameRed.AutoSize = true;
            this.labelNameRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameRed.Location = new System.Drawing.Point(439, 538);
            this.labelNameRed.Name = "labelNameRed";
            this.labelNameRed.Size = new System.Drawing.Size(65, 20);
            this.labelNameRed.TabIndex = 0;
            this.labelNameRed.Tag = "Red";
            this.labelNameRed.Text = "Player 1";
            // 
            // labelNameGreen
            // 
            this.labelNameGreen.AutoSize = true;
            this.labelNameGreen.BackColor = System.Drawing.Color.Green;
            this.labelNameGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameGreen.Location = new System.Drawing.Point(465, 82);
            this.labelNameGreen.Name = "labelNameGreen";
            this.labelNameGreen.Size = new System.Drawing.Size(51, 20);
            this.labelNameGreen.TabIndex = 26;
            this.labelNameGreen.Tag = "Green";
            this.labelNameGreen.Text = "label1";
            this.labelNameGreen.Visible = false;
            // 
            // labelNameBlue
            // 
            this.labelNameBlue.AutoSize = true;
            this.labelNameBlue.BackColor = System.Drawing.Color.RoyalBlue;
            this.labelNameBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameBlue.Location = new System.Drawing.Point(19, 49);
            this.labelNameBlue.Name = "labelNameBlue";
            this.labelNameBlue.Size = new System.Drawing.Size(51, 20);
            this.labelNameBlue.TabIndex = 27;
            this.labelNameBlue.Tag = "Blue";
            this.labelNameBlue.Text = "label1";
            this.labelNameBlue.Visible = false;
            // 
            // labelNameYellow
            // 
            this.labelNameYellow.AutoSize = true;
            this.labelNameYellow.BackColor = System.Drawing.Color.Gold;
            this.labelNameYellow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameYellow.Location = new System.Drawing.Point(12, 476);
            this.labelNameYellow.Name = "labelNameYellow";
            this.labelNameYellow.Size = new System.Drawing.Size(51, 20);
            this.labelNameYellow.TabIndex = 28;
            this.labelNameYellow.Tag = "Yellow";
            this.labelNameYellow.Text = "label1";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // btnYellow4
            // 
            this.btnYellow4.BackColor = System.Drawing.Color.Gold;
            this.btnYellow4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYellow4.Enabled = false;
            this.btnYellow4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYellow4.HumanPeg = null;
            this.btnYellow4.Id = 0;
            this.btnYellow4.Location = new System.Drawing.Point(2, 343);
            this.btnYellow4.Name = "btnYellow4";
            this.btnYellow4.NotHome = false;
            this.btnYellow4.Origin = new System.Drawing.Point(0, 0);
            this.btnYellow4.Size = new System.Drawing.Size(45, 45);
            this.btnYellow4.TabIndex = 19;
            this.btnYellow4.Tag = "Yellow";
            this.btnYellow4.UseVisualStyleBackColor = false;
            this.btnYellow4.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnYellow3
            // 
            this.btnYellow3.BackColor = System.Drawing.Color.Gold;
            this.btnYellow3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYellow3.Enabled = false;
            this.btnYellow3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYellow3.HumanPeg = null;
            this.btnYellow3.Id = 0;
            this.btnYellow3.Location = new System.Drawing.Point(2, 295);
            this.btnYellow3.Name = "btnYellow3";
            this.btnYellow3.NotHome = false;
            this.btnYellow3.Origin = new System.Drawing.Point(0, 0);
            this.btnYellow3.Size = new System.Drawing.Size(45, 45);
            this.btnYellow3.TabIndex = 18;
            this.btnYellow3.Tag = "Yellow";
            this.btnYellow3.UseVisualStyleBackColor = false;
            this.btnYellow3.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnYellow2
            // 
            this.btnYellow2.BackColor = System.Drawing.Color.Gold;
            this.btnYellow2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYellow2.Enabled = false;
            this.btnYellow2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYellow2.HumanPeg = null;
            this.btnYellow2.Id = 0;
            this.btnYellow2.Location = new System.Drawing.Point(1, 247);
            this.btnYellow2.Name = "btnYellow2";
            this.btnYellow2.NotHome = false;
            this.btnYellow2.Origin = new System.Drawing.Point(0, 0);
            this.btnYellow2.Size = new System.Drawing.Size(45, 45);
            this.btnYellow2.TabIndex = 17;
            this.btnYellow2.Tag = "Yellow";
            this.btnYellow2.UseVisualStyleBackColor = false;
            this.btnYellow2.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnYellow1
            // 
            this.btnYellow1.BackColor = System.Drawing.Color.Gold;
            this.btnYellow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYellow1.Enabled = false;
            this.btnYellow1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYellow1.HumanPeg = null;
            this.btnYellow1.Id = 0;
            this.btnYellow1.Location = new System.Drawing.Point(2, 199);
            this.btnYellow1.Name = "btnYellow1";
            this.btnYellow1.NotHome = false;
            this.btnYellow1.Origin = new System.Drawing.Point(0, 0);
            this.btnYellow1.Size = new System.Drawing.Size(45, 45);
            this.btnYellow1.TabIndex = 16;
            this.btnYellow1.Tag = "Yellow";
            this.btnYellow1.UseVisualStyleBackColor = false;
            this.btnYellow1.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnBlue2
            // 
            this.btnBlue2.BackColor = System.Drawing.Color.MediumBlue;
            this.btnBlue2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBlue2.Enabled = false;
            this.btnBlue2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlue2.HumanPeg = null;
            this.btnBlue2.Id = 0;
            this.btnBlue2.Location = new System.Drawing.Point(282, 12);
            this.btnBlue2.Name = "btnBlue2";
            this.btnBlue2.NotHome = false;
            this.btnBlue2.Origin = new System.Drawing.Point(0, 0);
            this.btnBlue2.Size = new System.Drawing.Size(45, 45);
            this.btnBlue2.TabIndex = 15;
            this.btnBlue2.Tag = "Blue";
            this.btnBlue2.UseVisualStyleBackColor = false;
            this.btnBlue2.Visible = false;
            this.btnBlue2.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnBlue3
            // 
            this.btnBlue3.BackColor = System.Drawing.Color.MediumBlue;
            this.btnBlue3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBlue3.Enabled = false;
            this.btnBlue3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlue3.HumanPeg = null;
            this.btnBlue3.Id = 0;
            this.btnBlue3.Location = new System.Drawing.Point(231, 12);
            this.btnBlue3.Name = "btnBlue3";
            this.btnBlue3.NotHome = false;
            this.btnBlue3.Origin = new System.Drawing.Point(0, 0);
            this.btnBlue3.Size = new System.Drawing.Size(45, 45);
            this.btnBlue3.TabIndex = 14;
            this.btnBlue3.Tag = "Blue";
            this.btnBlue3.UseVisualStyleBackColor = false;
            this.btnBlue3.Visible = false;
            this.btnBlue3.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnBlue4
            // 
            this.btnBlue4.BackColor = System.Drawing.Color.MediumBlue;
            this.btnBlue4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBlue4.Enabled = false;
            this.btnBlue4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlue4.HumanPeg = null;
            this.btnBlue4.Id = 0;
            this.btnBlue4.Location = new System.Drawing.Point(180, 12);
            this.btnBlue4.Name = "btnBlue4";
            this.btnBlue4.NotHome = false;
            this.btnBlue4.Origin = new System.Drawing.Point(0, 0);
            this.btnBlue4.Size = new System.Drawing.Size(45, 45);
            this.btnBlue4.TabIndex = 13;
            this.btnBlue4.Tag = "Blue";
            this.btnBlue4.UseVisualStyleBackColor = false;
            this.btnBlue4.Visible = false;
            this.btnBlue4.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnBlue1
            // 
            this.btnBlue1.BackColor = System.Drawing.Color.MediumBlue;
            this.btnBlue1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBlue1.Enabled = false;
            this.btnBlue1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlue1.HumanPeg = null;
            this.btnBlue1.Id = 0;
            this.btnBlue1.Location = new System.Drawing.Point(333, 12);
            this.btnBlue1.Name = "btnBlue1";
            this.btnBlue1.NotHome = false;
            this.btnBlue1.Origin = new System.Drawing.Point(0, 0);
            this.btnBlue1.Size = new System.Drawing.Size(45, 45);
            this.btnBlue1.TabIndex = 12;
            this.btnBlue1.Tag = "Blue";
            this.btnBlue1.UseVisualStyleBackColor = false;
            this.btnBlue1.Visible = false;
            this.btnBlue1.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnGreen2
            // 
            this.btnGreen2.BackColor = System.Drawing.Color.Green;
            this.btnGreen2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGreen2.Enabled = false;
            this.btnGreen2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGreen2.HumanPeg = null;
            this.btnGreen2.Id = 0;
            this.btnGreen2.Location = new System.Drawing.Point(517, 292);
            this.btnGreen2.Name = "btnGreen2";
            this.btnGreen2.NotHome = false;
            this.btnGreen2.Origin = new System.Drawing.Point(0, 0);
            this.btnGreen2.Size = new System.Drawing.Size(45, 45);
            this.btnGreen2.TabIndex = 11;
            this.btnGreen2.Tag = "Green";
            this.btnGreen2.UseVisualStyleBackColor = false;
            this.btnGreen2.Visible = false;
            this.btnGreen2.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnGreen3
            // 
            this.btnGreen3.BackColor = System.Drawing.Color.Green;
            this.btnGreen3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGreen3.Enabled = false;
            this.btnGreen3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGreen3.HumanPeg = null;
            this.btnGreen3.Id = 0;
            this.btnGreen3.Location = new System.Drawing.Point(517, 241);
            this.btnGreen3.Name = "btnGreen3";
            this.btnGreen3.NotHome = false;
            this.btnGreen3.Origin = new System.Drawing.Point(0, 0);
            this.btnGreen3.Size = new System.Drawing.Size(45, 45);
            this.btnGreen3.TabIndex = 10;
            this.btnGreen3.Tag = "Green";
            this.btnGreen3.UseVisualStyleBackColor = false;
            this.btnGreen3.Visible = false;
            this.btnGreen3.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnGreen4
            // 
            this.btnGreen4.BackColor = System.Drawing.Color.Green;
            this.btnGreen4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGreen4.Enabled = false;
            this.btnGreen4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGreen4.HumanPeg = null;
            this.btnGreen4.Id = 0;
            this.btnGreen4.Location = new System.Drawing.Point(517, 190);
            this.btnGreen4.Name = "btnGreen4";
            this.btnGreen4.NotHome = false;
            this.btnGreen4.Origin = new System.Drawing.Point(0, 0);
            this.btnGreen4.Size = new System.Drawing.Size(45, 45);
            this.btnGreen4.TabIndex = 9;
            this.btnGreen4.Tag = "Green";
            this.btnGreen4.UseVisualStyleBackColor = false;
            this.btnGreen4.Visible = false;
            this.btnGreen4.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnGreen1
            // 
            this.btnGreen1.BackColor = System.Drawing.Color.Green;
            this.btnGreen1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGreen1.Enabled = false;
            this.btnGreen1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGreen1.HumanPeg = null;
            this.btnGreen1.Id = 0;
            this.btnGreen1.Location = new System.Drawing.Point(517, 343);
            this.btnGreen1.Name = "btnGreen1";
            this.btnGreen1.NotHome = false;
            this.btnGreen1.Origin = new System.Drawing.Point(0, 0);
            this.btnGreen1.Size = new System.Drawing.Size(45, 45);
            this.btnGreen1.TabIndex = 5;
            this.btnGreen1.Tag = "Green";
            this.btnGreen1.UseVisualStyleBackColor = false;
            this.btnGreen1.Visible = false;
            this.btnGreen1.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnRed4
            // 
            this.btnRed4.BackColor = System.Drawing.Color.Red;
            this.btnRed4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRed4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRed4.HumanPeg = null;
            this.btnRed4.Id = 0;
            this.btnRed4.Location = new System.Drawing.Point(333, 527);
            this.btnRed4.Name = "btnRed4";
            this.btnRed4.NotHome = false;
            this.btnRed4.Origin = new System.Drawing.Point(0, 0);
            this.btnRed4.Size = new System.Drawing.Size(45, 45);
            this.btnRed4.TabIndex = 4;
            this.btnRed4.Tag = "Red";
            this.btnRed4.UseVisualStyleBackColor = false;
            this.btnRed4.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnRed3
            // 
            this.btnRed3.BackColor = System.Drawing.Color.Red;
            this.btnRed3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRed3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRed3.HumanPeg = null;
            this.btnRed3.Id = 0;
            this.btnRed3.Location = new System.Drawing.Point(283, 526);
            this.btnRed3.Name = "btnRed3";
            this.btnRed3.NotHome = false;
            this.btnRed3.Origin = new System.Drawing.Point(0, 0);
            this.btnRed3.Size = new System.Drawing.Size(45, 45);
            this.btnRed3.TabIndex = 3;
            this.btnRed3.Tag = "Red";
            this.btnRed3.UseVisualStyleBackColor = false;
            this.btnRed3.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnRed2
            // 
            this.btnRed2.BackColor = System.Drawing.Color.Red;
            this.btnRed2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRed2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRed2.HumanPeg = null;
            this.btnRed2.Id = 0;
            this.btnRed2.Location = new System.Drawing.Point(233, 526);
            this.btnRed2.Name = "btnRed2";
            this.btnRed2.NotHome = false;
            this.btnRed2.Origin = new System.Drawing.Point(0, 0);
            this.btnRed2.Size = new System.Drawing.Size(45, 45);
            this.btnRed2.TabIndex = 2;
            this.btnRed2.Tag = "Red";
            this.btnRed2.UseVisualStyleBackColor = false;
            this.btnRed2.Click += new System.EventHandler(this.SelectPeg);
            // 
            // btnRed1
            // 
            this.btnRed1.BackColor = System.Drawing.Color.Red;
            this.btnRed1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRed1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRed1.HumanPeg = null;
            this.btnRed1.Id = 0;
            this.btnRed1.Location = new System.Drawing.Point(185, 526);
            this.btnRed1.Name = "btnRed1";
            this.btnRed1.NotHome = false;
            this.btnRed1.Origin = new System.Drawing.Point(0, 0);
            this.btnRed1.Size = new System.Drawing.Size(45, 45);
            this.btnRed1.TabIndex = 1;
            this.btnRed1.Tag = "Red";
            this.btnRed1.UseVisualStyleBackColor = false;
            this.btnRed1.Click += new System.EventHandler(this.SelectPeg);
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.BackColor = System.Drawing.SystemColors.Control;
            this.lblShow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblShow.Location = new System.Drawing.Point(12, 558);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(64, 13);
            this.lblShow.TabIndex = 29;
            this.lblShow.Text = "Show Menu";
            this.lblShow.MouseHover += new System.EventHandler(this.LblShow_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(565, 584);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.labelNameYellow);
            this.Controls.Add(this.labelNameBlue);
            this.Controls.Add(this.labelNameGreen);
            this.Controls.Add(this.labelNameRed);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tlStrip);
            this.Controls.Add(this.LblRoll);
            this.Controls.Add(this.btnYellow4);
            this.Controls.Add(this.btnYellow3);
            this.Controls.Add(this.btnYellow2);
            this.Controls.Add(this.btnYellow1);
            this.Controls.Add(this.btnBlue2);
            this.Controls.Add(this.btnBlue3);
            this.Controls.Add(this.btnBlue4);
            this.Controls.Add(this.btnBlue1);
            this.Controls.Add(this.btnGreen2);
            this.Controls.Add(this.btnGreen3);
            this.Controls.Add(this.btnGreen4);
            this.Controls.Add(this.btnGreen1);
            this.Controls.Add(this.btnRed4);
            this.Controls.Add(this.btnRed3);
            this.Controls.Add(this.btnRed2);
            this.Controls.Add(this.btnRed1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Trouble";
            this.tlStrip.ResumeLayout(false);
            this.tlStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label LblRoll;
        private CircularButton btnRed1;
        private CircularButton btnRed2;
        private CircularButton btnRed3;
        private CircularButton btnRed4;
        private CircularButton btnGreen1;
        private CircularButton btnGreen4;
        private CircularButton btnGreen3;
        private CircularButton btnGreen2;
        private CircularButton btnBlue1;
        private CircularButton btnBlue4;
        private CircularButton btnBlue3;
        private CircularButton btnBlue2;
        private CircularButton btnYellow1;
        private CircularButton btnYellow2;
        private CircularButton btnYellow3;
        private CircularButton btnYellow4;
        private System.Windows.Forms.ToolStrip tlStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripFile;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem player2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem player3ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem player4ToolStripMenuItem2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelNameRed;
        private System.Windows.Forms.Label labelNameGreen;
        private System.Windows.Forms.Label labelNameBlue;
        private System.Windows.Forms.Label labelNameYellow;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cb2player;
        private System.Windows.Forms.ToolStripComboBox cb3player;
        private System.Windows.Forms.ToolStripComboBox cb4player;
        private System.Windows.Forms.ToolStripComboBox cb2playerDifficulty;
        private System.Windows.Forms.ToolStripMenuItem player2Start;
        private System.Windows.Forms.ToolStripComboBox cb3playerDifficulty;
        private System.Windows.Forms.ToolStripComboBox cb4playerDifficulty;
        private System.Windows.Forms.ToolStripMenuItem player3Start;
        private System.Windows.Forms.ToolStripMenuItem player4Start;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblShow;
    }
}