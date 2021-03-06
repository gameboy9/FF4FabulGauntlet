using FF4FabulGauntlet.Randomize;
using FF4FabulGauntlet.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Security.Cryptography;

namespace FF4FabulGauntlet
{
	public partial class FF4FabulGauntlet : Form
	{
		bool loading = true;
		Random r1;

		public FF4FabulGauntlet()
		{
			InitializeComponent();
		}

		public void DetermineFlags(object sender, EventArgs e)
		{
			if (loading) return;

			string flags = "";
			flags += convertIntToChar(checkboxesToNumber(new CheckBox[] { monsterAreaAppropriate, shopNoJ, shopNoSuper, treasureNoJ, treasureNoSuper, dupCharactersAllowed }));
			//// Combo boxes time...
			flags += convertIntToChar(encounterRate.SelectedIndex + (8 * numRounds.SelectedIndex));
			flags += convertIntToChar(shopItemQty.SelectedIndex + (8 * shopBuyPrice.SelectedIndex));
			flags += convertIntToChar(shopItemTypes.SelectedIndex + (8 * treasureTypes.SelectedIndex));
			flags += convertIntToChar(xpMultiplier.SelectedIndex + (8 * xpBoost.SelectedIndex));
			flags += convertIntToChar(gpMultiplier.SelectedIndex + (8 * gpBoost.SelectedIndex));
			flags += convertIntToChar(monsterDifficulty.SelectedIndex + (8 * numHeroes.SelectedIndex));
			flags += convertIntToChar(checkboxesToNumber(new CheckBox[] { removeBonusItems, exCecil, exCid, exEdge, exEdward, exFusoya }));
			flags += convertIntToChar(firstHero.SelectedIndex);
			flags += convertIntToChar(checkboxesToNumber(new CheckBox[] { exKain, exPalom, exPorom, exRosa, exRydia, exTellah }));
			flags += convertIntToChar(checkboxesToNumber(new CheckBox[] { exYang, requireSirens, randomEscape, removeFGExclusiveItems, exPaladinCecil }));
			RandoFlags.Text = flags;

			//flags = "";
			//flags += convertIntToChar(checkboxesToNumber(new CheckBox[] { CuteHats }));
			//VisualFlags.Text = flags;
		}

		private void determineChecks(object sender, EventArgs e)
		{
			if (loading && RandoFlags.Text.Length < 11)
				RandoFlags.Text = "1OQ15520000"; // Default flags here
			else if (RandoFlags.Text.Length < 11)
				return;

			//if (loading && VisualFlags.Text.Length < 1)
			//	VisualFlags.Text = "0";
			//else if (VisualFlags.Text.Length < 1)
			//	return;

			loading = true;

			string flags = RandoFlags.Text;
			numberToCheckboxes(convertChartoInt(Convert.ToChar(flags.Substring(0, 1))), new CheckBox[] { monsterAreaAppropriate, shopNoJ, shopNoSuper, treasureNoJ, treasureNoSuper, dupCharactersAllowed });
			encounterRate.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(1, 1))) % 8;
			numRounds.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(1, 1))) / 8;
			shopItemQty.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(2, 1))) % 8;
			shopBuyPrice.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(2, 1))) / 8;
			shopItemTypes.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(3, 1))) % 8;
			treasureTypes.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(3, 1))) / 8;
			xpMultiplier.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(4, 1))) % 8;
			xpBoost.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(4, 1))) / 8;
			gpMultiplier.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(5, 1))) % 8;
			gpBoost.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(5, 1))) / 8;
			monsterDifficulty.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(6, 1))) % 8;
			numHeroes.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(6, 1))) / 8;
			numberToCheckboxes(convertChartoInt(Convert.ToChar(flags.Substring(7, 1))), new CheckBox[] { removeBonusItems, exCecil, exCid, exEdge, exEdward, exFusoya });
			firstHero.SelectedIndex = convertChartoInt(Convert.ToChar(flags.Substring(8, 1))) % 16;
			numberToCheckboxes(convertChartoInt(Convert.ToChar(flags.Substring(9, 1))), new CheckBox[] { exKain, exPalom, exPorom, exRosa, exRydia, exTellah });
			numberToCheckboxes(convertChartoInt(Convert.ToChar(flags.Substring(10, 1))), new CheckBox[] { exYang, requireSirens, randomEscape, removeFGExclusiveItems, exPaladinCecil });

			//flags = VisualFlags.Text;
			//numberToCheckboxes(convertChartoInt(Convert.ToChar(flags.Substring(0, 1))), new CheckBox[] { CuteHats });

			loading = false;
		}

		private int checkboxesToNumber(CheckBox[] boxes)
		{
			int number = 0;
			for (int lnI = 0; lnI < Math.Min(boxes.Length, 6); lnI++)
				number += boxes[lnI].Checked ? (int)Math.Pow(2, lnI) : 0;

			return number;
		}

		private int numberToCheckboxes(int number, CheckBox[] boxes)
		{
			for (int lnI = 0; lnI < Math.Min(boxes.Length, 6); lnI++)
				boxes[lnI].Checked = number % ((int)Math.Pow(2, lnI + 1)) >= (int)Math.Pow(2, lnI);

			return number;
		}

		private string convertIntToChar(int number)
		{
			if (number >= 0 && number <= 9)
				return number.ToString();
			if (number >= 10 && number <= 35)
				return Convert.ToChar(55 + number).ToString();
			if (number >= 36 && number <= 61)
				return Convert.ToChar(61 + number).ToString();
			if (number == 62) return "!";
			if (number == 63) return "@";
			return "";
		}

		private int convertChartoInt(char character)
		{
			if (character >= Convert.ToChar("0") && character <= Convert.ToChar("9"))
				return character - 48;
			if (character >= Convert.ToChar("A") && character <= Convert.ToChar("Z"))
				return character - 55;
			if (character >= Convert.ToChar("a") && character <= Convert.ToChar("z"))
				return character - 61;
			if (character == Convert.ToChar("!")) return 62;
			if (character == Convert.ToChar("@")) return 63;
			return 0;
		}

		private void FF4FabulGauntlet_Load(object sender, EventArgs e)
		{
			RandoSeed.Text = (DateTime.Now.Ticks % 2147483647).ToString();

			hpAdjustTooltip.SetToolTip(hpBoost, "HP Boosts for Tellah, Edward, and DK Cecil, HP penalty for Fusoya pre-level 50  (good for limited hero runs)");

			try
			{
				using (TextReader reader = File.OpenText("lastFF4FG.txt"))
				{
					FF4PRFolder.Text = reader.ReadLine();
					RandoSeed.Text = reader.ReadLine();
					RandoFlags.Text = reader.ReadLine();
					gameAssetsFile.Text = reader.ReadLine();
					//VisualFlags.Text = reader.ReadLine();
					determineChecks(null, null);

					loading = false;
				}
			}
			catch
			{
				// Default flags here
				RandoFlags.Text = "1OQ15520000";
				//VisualFlags.Text = "0";
				// ignore error
				loading = false;
				determineChecks(null, null);
			}

		}

		private void NewSeed_Click(object sender, EventArgs e)
		{
			RandoSeed.Text = (DateTime.Now.Ticks % 2147483647).ToString();
		}

		private void Randomize_Click(object sender, EventArgs e)
		{
			if (!File.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.dll")) || !File.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.pdb"))
				|| !File.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx", "config", "Memoria.ffpr.cfg")) || !Directory.Exists(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets")))
			{
				MessageBox.Show("Randomizer assets have not been extracted.  Please extract, then try randomization again.");
				return;
			}

			int included = (exCecil.Checked ? 0 : 1) +
				(exCid.Checked ? 0 : 1) +
				(exEdge.Checked ? 0 : 1) +
				(exEdward.Checked ? 0 : 1) +
				(exFusoya.Checked ? 0 : 1) +
				(exKain.Checked ? 0 : 1) +
				(exPalom.Checked ? 0 : 1) +
				(exPorom.Checked ? 0 : 1) +
				(exRosa.Checked ? 0 : 1) +
				(exRydia.Checked ? 0 : 1) +
				(exTellah.Checked ? 0 : 1) +
				(exYang.Checked ? 0 : 1) + 
				(exPaladinCecil.Checked ? 0 : 1);

			if (included < Convert.ToInt32(numHeroes.SelectedItem) && !dupCharactersAllowed.Checked)
            {
				MessageBox.Show("Included heroes exceed number of heroes and duplicate heroes is not checked.  Please try again.");
				return;
			}

			update();
			int[] party = randomizeParty();
			randomizeShops(party);
			randomizeTreasures(party);
			priceAdjustment();
			randomizeMonstersWithBoost();
			new Inventory.Map(r1, Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Data", "Master"),
					encounterRate.SelectedIndex == 1 || encounterRate.SelectedIndex == 4 ? 2 :
					encounterRate.SelectedIndex == 3 || encounterRate.SelectedIndex == 5 ? 4 :
					encounterRate.SelectedIndex == 6 ? 8 : 1,
					encounterRate.SelectedIndex == 0 ? 2 :
					encounterRate.SelectedIndex == 1 || encounterRate.SelectedIndex == 3 ? 3 : 1,
				encounterRate.SelectedIndex == 7);

			try
			{
				using (var sha1Crypto = SHA1.Create())
				{
					using (var stream = File.OpenRead(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Data", "Master", "monster_party.csv")))
					{
						string checkSum = BitConverter.ToString(sha1Crypto.ComputeHash(stream)).ToLower().Replace("-", "").Substring(0, 16);
						Clipboard.SetText(checkSum);
						NewChecksum.Text = "COMPLETE - checksum " + checkSum + " (copied to clipboard)";
					}
				}
			}
			catch (Exception ex)
			{
				NewChecksum.Text = "COMPLETE - checksum ????????????????";
			}
		}

		private void update()
		{
			new Inventory.Updater(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial"));
		}

		// Currently not in use...
		private void establishAreas()
		{
			new Inventory.Areas(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Res", "Map"), 11);
		}

		private int[] randomizeParty()
		{
			int battles = numRounds.SelectedIndex == 0 ? 10 :
				numRounds.SelectedIndex == 1 ? 8 :
				numRounds.SelectedIndex == 2 ? 6 :
				numRounds.SelectedIndex == 3 ? 5 :
				numRounds.SelectedIndex == 4 ? 4 :
				numRounds.SelectedIndex == 5 ? 3 :
				numRounds.SelectedIndex == 6 ? 2 : 1;
			r1 = new Random(Convert.ToInt32(RandoSeed.Text));
			Randomize.Party party = new Randomize.Party(r1, Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Res", "Map"), battles, dupCharactersAllowed.Checked, Convert.ToInt32(numHeroes.SelectedItem), exPaladinCecil.Checked,
				new bool[] { exCecil.Checked, exKain.Checked, exRydia.Checked, exTellah.Checked, exEdward.Checked, exRosa.Checked, exYang.Checked, exPalom.Checked, exPorom.Checked, exCid.Checked, exEdge.Checked, exFusoya.Checked, exPaladinCecil.Checked });
			return party.getParty();
		}

		private void randomizeShops(int[] party)
		{
			// RandoShop.SelectedIndex
			Shops randoShops = new Shops(r1, shopItemTypes.SelectedIndex, shopItemQty.SelectedIndex, shopNoJ.Checked, shopNoSuper.Checked, 
				Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Data", "Master", "product.csv"), !removeBonusItems.Checked, requireSirens.Checked, !removeFGExclusiveItems.Checked, party);
		}

		private void randomizeTreasures(int[] party)
		{
			new Randomize.Treasure(r1, treasureTypes.SelectedIndex, Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Res", "Map"),
				Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Data", "Message"),
				treasureNoJ.Checked, treasureNoSuper.Checked, !removeBonusItems.Checked, !removeFGExclusiveItems.Checked, party);
		}

		private void randomizeMonstersWithBoost()
		{
			double xpMulti = xpMultiplier.SelectedIndex == 0 ? 0.5 :
				xpMultiplier.SelectedIndex == 1 ? 0.75 :
				xpMultiplier.SelectedIndex == 2 ? 1.0 :
				xpMultiplier.SelectedIndex == 3 ? 1.5 :
				xpMultiplier.SelectedIndex == 4 ? 2.0 :
				xpMultiplier.SelectedIndex == 5 ? 3.0 :
				xpMultiplier.SelectedIndex == 6 ? 4.0 : 5.0;
			int xpBoostInt = xpBoost.SelectedIndex == 0 ? 0 :
				xpBoost.SelectedIndex == 1 ? 50 :
				xpBoost.SelectedIndex == 2 ? 100 :
				xpBoost.SelectedIndex == 3 ? 200 :
				xpBoost.SelectedIndex == 4 ? 300 :
				xpBoost.SelectedIndex == 5 ? 400 :
				xpBoost.SelectedIndex == 6 ? 500 : 1000;
			double gpMulti = gpMultiplier.SelectedIndex == 0 ? 0.5 :
				gpMultiplier.SelectedIndex == 1 ? 0.75 :
				gpMultiplier.SelectedIndex == 2 ? 1.0 :
				gpMultiplier.SelectedIndex == 3 ? 1.5 :
				gpMultiplier.SelectedIndex == 4 ? 2.0 :
				gpMultiplier.SelectedIndex == 5 ? 3.0 :
				gpMultiplier.SelectedIndex == 6 ? 4.0 : 5.0;
			int gpBoostInt = gpBoost.SelectedIndex == 0 ? 0 :
				gpBoost.SelectedIndex == 2 ? 50 :
				gpBoost.SelectedIndex == 2 ? 100 :
				gpBoost.SelectedIndex == 3 ? 200 :
				gpBoost.SelectedIndex == 4 ? 300 :
				gpBoost.SelectedIndex == 5 ? 400 :
				gpBoost.SelectedIndex == 6 ? 500 : 1000;
			new Monster(r1, Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Data", "Master"), xpMulti, xpBoostInt, gpMulti, gpBoostInt, 5, monsterDifficulty.SelectedIndex, monsterAreaAppropriate.Checked, Convert.ToInt32(numHeroes.SelectedItem));
			new MonsterSet().escapeAdjust(randomEscape.Checked, Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Data", "Master"));
		}

		private void priceAdjustment()
		{
			int buyMultiplier = shopBuyPrice.SelectedIndex == 0 ? 0 : shopBuyPrice.SelectedIndex == 1 ? 1 : shopBuyPrice.SelectedIndex == 2 ? 2 : shopBuyPrice.SelectedIndex == 3 ? 4 : shopBuyPrice.SelectedIndex == 4 ? 8 : 20;
			new Weapons().adjustPrices(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Data", "Master"), buyMultiplier, 20);
			new Items().adjustPrices(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Data", "Master"), buyMultiplier, 20, shopItemTypes.SelectedIndex);
			new Armor().adjustPrices(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets", "Serial", "Data", "Master"), buyMultiplier, 20);
		}

		private void FF4FabulGauntlet_FormClosing(object sender, FormClosingEventArgs e)
		{
			using (StreamWriter writer = File.CreateText("lastFF4FG.txt"))
			{
				writer.WriteLine(FF4PRFolder.Text);
				writer.WriteLine(RandoSeed.Text);
				writer.WriteLine(RandoFlags.Text);
				writer.WriteLine(gameAssetsFile.Text);
				//writer.WriteLine(VisualFlags.Text);
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
					FF4PRFolder.Text = fbd.SelectedPath;
			}
		}

		private void extractGameAssets_Click(object sender, EventArgs e)
		{
			try
			{
				if (!File.Exists(gameAssetsFile.Text))
				{
					MessageBox.Show("Cannot extract - game assets file listed does not exist...");
					NewChecksum.Text = "Extraction failed...";
					return;
				}
				NewChecksum.Text = "Extracting...";
				if (!Directory.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx")))
					ZipFile.ExtractToDirectory(Path.Combine("install", "BepInEx.zip"), Path.Combine(FF4PRFolder.Text), true);

				if (!File.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.dll")))
					File.Copy(Path.Combine("install", "Memoria.FF4.dll"), Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.dll"));
				if (!File.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.pdb")))
					File.Copy(Path.Combine("install", "Memoria.FF4.pdb"), Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.pdb"));
				if (!File.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx", "config", "Memoria.ffpr.cfg")))
					File.Copy(Path.Combine("install", "Memoria.ffpr.cfg"), Path.Combine(FF4PRFolder.Text, "BepInEx", "config", "Memoria.ffpr.cfg"));
				if (!Directory.Exists(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets", "GameAssets")))
					ZipFile.ExtractToDirectory(gameAssetsFile.Text, Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets"));
				NewChecksum.Text = "Extraction complete!";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to extract - " + ex.Message);
				NewChecksum.Text = "Extraction failed...";
			}
		}

		private void revertToDefault_click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to revert Final Fantasy IV back to vanilla?", "Final Fantasy IV: Fabul Gauntlet", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				try
				{
					NewChecksum.Text = "Reverting...";
					if (File.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.dll")))
						File.Delete(Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.dll"));
					if (File.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.pdb")))
						File.Delete(Path.Combine(FF4PRFolder.Text, "BepInEx", "plugins", "Memoria.FF4.pdb"));
					if (File.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx", "config", "Memoria.ffpr.cfg")))
						File.Delete(Path.Combine(FF4PRFolder.Text, "BepInEx", "config", "Memoria.ffpr.cfg"));
					if (Directory.Exists(Path.Combine(FF4PRFolder.Text, "BepInEx")))
						Directory.Delete(Path.Combine(FF4PRFolder.Text, "BepInEx"), true);
					if (Directory.Exists(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets")))
						Directory.Delete(Path.Combine(FF4PRFolder.Text, "FINAL FANTASY IV_Data", "StreamingAssets", "Assets"), true);
					NewChecksum.Text = "Revert complete!";
				}
				catch (Exception ex)
				{
					MessageBox.Show("Unable to revert - " + ex.Message);
					NewChecksum.Text = "Revert failed...";
				}
			}
		}

		private void BrowseForGameAssets_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = @"C:\";
			openFileDialog1.Filter = "zip files (*.zip)|*.zip|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 2;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				gameAssetsFile.Text = openFileDialog1.FileName;
			}
		}
    }
}
