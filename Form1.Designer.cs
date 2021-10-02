
namespace FF4FabulGauntlet
{
	partial class FF4FabulGauntlet
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Randomize = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.FF4PRFolder = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.RandoFlags = new System.Windows.Forms.TextBox();
			this.NewChecksum = new System.Windows.Forms.Label();
			this.RandoSeed = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.NewSeed = new System.Windows.Forms.Button();
			this.BrowseForFolder = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.monsterAreaAppropriate = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.shopItemQty = new System.Windows.Forms.ComboBox();
			this.shopBuyPrice = new System.Windows.Forms.ComboBox();
			this.numAreas = new System.Windows.Forms.ComboBox();
			this.numRounds = new System.Windows.Forms.ComboBox();
			this.monsterDifficulty = new System.Windows.Forms.ComboBox();
			this.xpMultiplier = new System.Windows.Forms.ComboBox();
			this.gpMultiplier = new System.Windows.Forms.ComboBox();
			this.xpBoost = new System.Windows.Forms.ComboBox();
			this.gpBoost = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.shopItemTypes = new System.Windows.Forms.ComboBox();
			this.treasureTypes = new System.Windows.Forms.ComboBox();
			this.shopNoJ = new System.Windows.Forms.CheckBox();
			this.treasureNoJ = new System.Windows.Forms.CheckBox();
			this.shopNoSuper = new System.Windows.Forms.CheckBox();
			this.treasureNoSuper = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.gameAssetsFile = new System.Windows.Forms.TextBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.extractGameAssets = new System.Windows.Forms.Button();
			this.BrowseForGameAssets = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Randomize
			// 
			this.Randomize.Location = new System.Drawing.Point(668, 409);
			this.Randomize.Name = "Randomize";
			this.Randomize.Size = new System.Drawing.Size(120, 29);
			this.Randomize.TabIndex = 0;
			this.Randomize.Text = "Randomize!";
			this.Randomize.UseVisualStyleBackColor = true;
			this.Randomize.Click += new System.EventHandler(this.Randomize_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "FF4 PR Folder";
			// 
			// FF4PRFolder
			// 
			this.FF4PRFolder.Location = new System.Drawing.Point(138, 6);
			this.FF4PRFolder.Name = "FF4PRFolder";
			this.FF4PRFolder.Size = new System.Drawing.Size(502, 27);
			this.FF4PRFolder.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Rando Flags";
			// 
			// RandoFlags
			// 
			this.RandoFlags.Location = new System.Drawing.Point(138, 47);
			this.RandoFlags.Name = "RandoFlags";
			this.RandoFlags.Size = new System.Drawing.Size(346, 27);
			this.RandoFlags.TabIndex = 7;
			this.RandoFlags.Leave += new System.EventHandler(this.determineChecks);
			// 
			// NewChecksum
			// 
			this.NewChecksum.AutoSize = true;
			this.NewChecksum.Location = new System.Drawing.Point(12, 413);
			this.NewChecksum.Name = "NewChecksum";
			this.NewChecksum.Size = new System.Drawing.Size(267, 20);
			this.NewChecksum.TabIndex = 8;
			this.NewChecksum.Text = "New Checksum:  (Not Randomized Yet)";
			// 
			// RandoSeed
			// 
			this.RandoSeed.Location = new System.Drawing.Point(554, 44);
			this.RandoSeed.Name = "RandoSeed";
			this.RandoSeed.Size = new System.Drawing.Size(160, 27);
			this.RandoSeed.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(506, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "Seed";
			// 
			// NewSeed
			// 
			this.NewSeed.Location = new System.Drawing.Point(729, 43);
			this.NewSeed.Name = "NewSeed";
			this.NewSeed.Size = new System.Drawing.Size(59, 29);
			this.NewSeed.TabIndex = 11;
			this.NewSeed.Text = "New";
			this.NewSeed.UseVisualStyleBackColor = true;
			this.NewSeed.Click += new System.EventHandler(this.NewSeed_Click);
			// 
			// BrowseForFolder
			// 
			this.BrowseForFolder.Location = new System.Drawing.Point(693, 6);
			this.BrowseForFolder.Name = "BrowseForFolder";
			this.BrowseForFolder.Size = new System.Drawing.Size(95, 28);
			this.BrowseForFolder.TabIndex = 14;
			this.BrowseForFolder.Text = "Browse";
			this.BrowseForFolder.UseVisualStyleBackColor = true;
			this.BrowseForFolder.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 175);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(130, 20);
			this.label5.TabIndex = 15;
			this.label5.Text = "# of Battles / Area";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 140);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 20);
			this.label6.TabIndex = 16;
			this.label6.Text = "# of Areas";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 210);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(127, 20);
			this.label7.TabIndex = 17;
			this.label7.Text = "Monster Difficulty";
			// 
			// monsterAreaAppropriate
			// 
			this.monsterAreaAppropriate.AutoSize = true;
			this.monsterAreaAppropriate.Location = new System.Drawing.Point(331, 208);
			this.monsterAreaAppropriate.Name = "monsterAreaAppropriate";
			this.monsterAreaAppropriate.Size = new System.Drawing.Size(338, 24);
			this.monsterAreaAppropriate.TabIndex = 18;
			this.monsterAreaAppropriate.Text = "Involve only monsters associated with the area";
			this.monsterAreaAppropriate.UseVisualStyleBackColor = true;
			this.monsterAreaAppropriate.CheckedChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 245);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(94, 20);
			this.label8.TabIndex = 19;
			this.label8.Text = "XP Multiplier";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 280);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(95, 20);
			this.label9.TabIndex = 20;
			this.label9.Text = "GP Multiplier";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(331, 280);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(47, 20);
			this.label10.TabIndex = 21;
			this.label10.Text = "Boost";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(331, 245);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(47, 20);
			this.label11.TabIndex = 22;
			this.label11.Text = "Boost";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(331, 140);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(137, 20);
			this.label12.TabIndex = 23;
			this.label12.Text = "Shop Item Quantity";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(331, 175);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(141, 20);
			this.label13.TabIndex = 24;
			this.label13.Text = "Shop Purchase Price";
			// 
			// shopItemQty
			// 
			this.shopItemQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shopItemQty.FormattingEnabled = true;
			this.shopItemQty.Items.AddRange(new object[] {
            "Very Sparse",
            "Sparse",
            "Normal",
            "Plentiful",
            "Very Plentiful"});
			this.shopItemQty.Location = new System.Drawing.Point(506, 136);
			this.shopItemQty.Name = "shopItemQty";
			this.shopItemQty.Size = new System.Drawing.Size(151, 28);
			this.shopItemQty.TabIndex = 25;
			this.shopItemQty.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// shopBuyPrice
			// 
			this.shopBuyPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shopBuyPrice.FormattingEnabled = true;
			this.shopBuyPrice.Items.AddRange(new object[] {
            "1 Gold",
            "Very Cheap",
            "Cheap",
            "Normal",
            "Expensive",
            "Very Expensive"});
			this.shopBuyPrice.Location = new System.Drawing.Point(506, 171);
			this.shopBuyPrice.Name = "shopBuyPrice";
			this.shopBuyPrice.Size = new System.Drawing.Size(151, 28);
			this.shopBuyPrice.TabIndex = 26;
			this.shopBuyPrice.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// numAreas
			// 
			this.numAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.numAreas.FormattingEnabled = true;
			this.numAreas.Items.AddRange(new object[] {
            "11"});
			this.numAreas.Location = new System.Drawing.Point(162, 136);
			this.numAreas.Name = "numAreas";
			this.numAreas.Size = new System.Drawing.Size(148, 28);
			this.numAreas.TabIndex = 27;
			this.numAreas.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// numRounds
			// 
			this.numRounds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.numRounds.FormattingEnabled = true;
			this.numRounds.Items.AddRange(new object[] {
            "10",
            "8",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1"});
			this.numRounds.Location = new System.Drawing.Point(162, 171);
			this.numRounds.Name = "numRounds";
			this.numRounds.Size = new System.Drawing.Size(148, 28);
			this.numRounds.TabIndex = 28;
			this.numRounds.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// monsterDifficulty
			// 
			this.monsterDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.monsterDifficulty.FormattingEnabled = true;
			this.monsterDifficulty.Items.AddRange(new object[] {
            "Very Easy",
            "Easy",
            "Normal",
            "Hard",
            "Very Hard"});
			this.monsterDifficulty.Location = new System.Drawing.Point(162, 206);
			this.monsterDifficulty.Name = "monsterDifficulty";
			this.monsterDifficulty.Size = new System.Drawing.Size(148, 28);
			this.monsterDifficulty.TabIndex = 29;
			this.monsterDifficulty.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// xpMultiplier
			// 
			this.xpMultiplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.xpMultiplier.FormattingEnabled = true;
			this.xpMultiplier.Items.AddRange(new object[] {
            "0.5x",
            "0.75x",
            "1x",
            "1.25x",
            "1.5x",
            "2.0x",
            "3.0x",
            "4.0x"});
			this.xpMultiplier.Location = new System.Drawing.Point(162, 241);
			this.xpMultiplier.Name = "xpMultiplier";
			this.xpMultiplier.Size = new System.Drawing.Size(148, 28);
			this.xpMultiplier.TabIndex = 30;
			this.xpMultiplier.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// gpMultiplier
			// 
			this.gpMultiplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gpMultiplier.FormattingEnabled = true;
			this.gpMultiplier.Items.AddRange(new object[] {
            "0.5x",
            "0.75x",
            "1x",
            "1.25x",
            "1.5x",
            "2.0x",
            "3.0x",
            "4.0x"});
			this.gpMultiplier.Location = new System.Drawing.Point(162, 276);
			this.gpMultiplier.Name = "gpMultiplier";
			this.gpMultiplier.Size = new System.Drawing.Size(148, 28);
			this.gpMultiplier.TabIndex = 31;
			this.gpMultiplier.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// xpBoost
			// 
			this.xpBoost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.xpBoost.FormattingEnabled = true;
			this.xpBoost.Items.AddRange(new object[] {
            "+0",
            "+25",
            "+50",
            "+100",
            "+150",
            "+200",
            "+300",
            "+400"});
			this.xpBoost.Location = new System.Drawing.Point(396, 241);
			this.xpBoost.Name = "xpBoost";
			this.xpBoost.Size = new System.Drawing.Size(151, 28);
			this.xpBoost.TabIndex = 32;
			this.xpBoost.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// gpBoost
			// 
			this.gpBoost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gpBoost.FormattingEnabled = true;
			this.gpBoost.Items.AddRange(new object[] {
            "+0",
            "+25",
            "+50",
            "+100",
            "+150",
            "+200",
            "+300",
            "+400"});
			this.gpBoost.Location = new System.Drawing.Point(396, 276);
			this.gpBoost.Name = "gpBoost";
			this.gpBoost.Size = new System.Drawing.Size(151, 28);
			this.gpBoost.TabIndex = 33;
			this.gpBoost.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 315);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(118, 20);
			this.label4.TabIndex = 34;
			this.label4.Text = "Shop Item Types";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(12, 350);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(105, 20);
			this.label14.TabIndex = 35;
			this.label14.Text = "Treasure Types";
			// 
			// shopItemTypes
			// 
			this.shopItemTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shopItemTypes.FormattingEnabled = true;
			this.shopItemTypes.Items.AddRange(new object[] {
            "Standard",
            "Pro",
            "Wild"});
			this.shopItemTypes.Location = new System.Drawing.Point(162, 311);
			this.shopItemTypes.Name = "shopItemTypes";
			this.shopItemTypes.Size = new System.Drawing.Size(148, 28);
			this.shopItemTypes.TabIndex = 36;
			this.shopItemTypes.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// treasureTypes
			// 
			this.treasureTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.treasureTypes.FormattingEnabled = true;
			this.treasureTypes.Items.AddRange(new object[] {
            "Standard",
            "Pro",
            "Wild"});
			this.treasureTypes.Location = new System.Drawing.Point(162, 346);
			this.treasureTypes.Name = "treasureTypes";
			this.treasureTypes.Size = new System.Drawing.Size(148, 28);
			this.treasureTypes.TabIndex = 37;
			this.treasureTypes.SelectedIndexChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// shopNoJ
			// 
			this.shopNoJ.AutoSize = true;
			this.shopNoJ.Location = new System.Drawing.Point(331, 313);
			this.shopNoJ.Name = "shopNoJ";
			this.shopNoJ.Size = new System.Drawing.Size(114, 24);
			this.shopNoJ.TabIndex = 38;
			this.shopNoJ.Text = "No \"J-items\"";
			this.shopNoJ.UseVisualStyleBackColor = true;
			this.shopNoJ.CheckedChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// treasureNoJ
			// 
			this.treasureNoJ.AutoSize = true;
			this.treasureNoJ.Location = new System.Drawing.Point(331, 348);
			this.treasureNoJ.Name = "treasureNoJ";
			this.treasureNoJ.Size = new System.Drawing.Size(114, 24);
			this.treasureNoJ.TabIndex = 39;
			this.treasureNoJ.Text = "No \"J-items\"";
			this.treasureNoJ.UseVisualStyleBackColor = true;
			this.treasureNoJ.CheckedChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// shopNoSuper
			// 
			this.shopNoSuper.AutoSize = true;
			this.shopNoSuper.Location = new System.Drawing.Point(465, 313);
			this.shopNoSuper.Name = "shopNoSuper";
			this.shopNoSuper.Size = new System.Drawing.Size(131, 24);
			this.shopNoSuper.TabIndex = 40;
			this.shopNoSuper.Text = "No super items";
			this.shopNoSuper.UseVisualStyleBackColor = true;
			this.shopNoSuper.CheckedChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// treasureNoSuper
			// 
			this.treasureNoSuper.AutoSize = true;
			this.treasureNoSuper.Location = new System.Drawing.Point(465, 348);
			this.treasureNoSuper.Name = "treasureNoSuper";
			this.treasureNoSuper.Size = new System.Drawing.Size(262, 24);
			this.treasureNoSuper.TabIndex = 41;
			this.treasureNoSuper.Text = "No super items (except in trapped)";
			this.treasureNoSuper.UseVisualStyleBackColor = true;
			this.treasureNoSuper.CheckedChanged += new System.EventHandler(this.DetermineFlags);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(478, 409);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(140, 29);
			this.button1.TabIndex = 42;
			this.button1.Text = "Revert to default";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.revertToDefault_click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(12, 92);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(120, 20);
			this.label15.TabIndex = 43;
			this.label15.Text = "Game Assets File";
			// 
			// gameAssetsFile
			// 
			this.gameAssetsFile.Location = new System.Drawing.Point(138, 89);
			this.gameAssetsFile.Name = "gameAssetsFile";
			this.gameAssetsFile.Size = new System.Drawing.Size(346, 27);
			this.gameAssetsFile.TabIndex = 44;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(710, 92);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(78, 20);
			this.linkLabel1.TabIndex = 45;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Download";
			// 
			// extractGameAssets
			// 
			this.extractGameAssets.Location = new System.Drawing.Point(595, 88);
			this.extractGameAssets.Name = "extractGameAssets";
			this.extractGameAssets.Size = new System.Drawing.Size(95, 28);
			this.extractGameAssets.TabIndex = 46;
			this.extractGameAssets.Text = "Extract";
			this.extractGameAssets.UseVisualStyleBackColor = true;
			this.extractGameAssets.Click += new System.EventHandler(this.extractGameAssets_Click);
			// 
			// BrowseForGameAssets
			// 
			this.BrowseForGameAssets.Location = new System.Drawing.Point(494, 89);
			this.BrowseForGameAssets.Name = "BrowseForGameAssets";
			this.BrowseForGameAssets.Size = new System.Drawing.Size(95, 28);
			this.BrowseForGameAssets.TabIndex = 47;
			this.BrowseForGameAssets.Text = "Browse";
			this.BrowseForGameAssets.UseVisualStyleBackColor = true;
			this.BrowseForGameAssets.Click += new System.EventHandler(this.BrowseForGameAssets_Click);
			// 
			// FF4FabulGauntlet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.BrowseForGameAssets);
			this.Controls.Add(this.extractGameAssets);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.gameAssetsFile);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.treasureNoSuper);
			this.Controls.Add(this.shopNoSuper);
			this.Controls.Add(this.treasureNoJ);
			this.Controls.Add(this.shopNoJ);
			this.Controls.Add(this.treasureTypes);
			this.Controls.Add(this.shopItemTypes);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.gpBoost);
			this.Controls.Add(this.xpBoost);
			this.Controls.Add(this.gpMultiplier);
			this.Controls.Add(this.xpMultiplier);
			this.Controls.Add(this.monsterDifficulty);
			this.Controls.Add(this.numRounds);
			this.Controls.Add(this.numAreas);
			this.Controls.Add(this.shopBuyPrice);
			this.Controls.Add(this.shopItemQty);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.monsterAreaAppropriate);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.BrowseForFolder);
			this.Controls.Add(this.NewSeed);
			this.Controls.Add(this.RandoSeed);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.NewChecksum);
			this.Controls.Add(this.RandoFlags);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FF4PRFolder);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Randomize);
			this.Name = "FF4FabulGauntlet";
			this.Text = "Final Fantasy 4 Fabul Gauntlet";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FF4FabulGauntlet_FormClosing);
			this.Load += new System.EventHandler(this.FF4FabulGauntlet_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Randomize;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox FF4PRFolder;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox RandoFlags;
		private System.Windows.Forms.Label NewChecksum;
		private System.Windows.Forms.TextBox RandoSeed;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button NewSeed;
		private System.Windows.Forms.Button BrowseForFolder;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox monsterAreaAppropriate;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox shopItemQty;
		private System.Windows.Forms.ComboBox shopBuyPrice;
		private System.Windows.Forms.ComboBox numAreas;
		private System.Windows.Forms.ComboBox numRounds;
		private System.Windows.Forms.ComboBox monsterDifficulty;
		private System.Windows.Forms.ComboBox xpMultiplier;
		private System.Windows.Forms.ComboBox gpMultiplier;
		private System.Windows.Forms.ComboBox xpBoost;
		private System.Windows.Forms.ComboBox gpBoost;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox shopItemTypes;
		private System.Windows.Forms.ComboBox treasureTypes;
		private System.Windows.Forms.CheckBox shopNoJ;
		private System.Windows.Forms.CheckBox treasureNoJ;
		private System.Windows.Forms.CheckBox shopNoSuper;
		private System.Windows.Forms.CheckBox treasureNoSuper;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox gameAssetsFile;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button extractGameAssets;
		private System.Windows.Forms.Button BrowseForGameAssets;
	}
}

