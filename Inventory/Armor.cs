﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static FF4FabulGauntlet.Common.Common;

namespace FF4FabulGauntlet.Inventory
{
	class Armor
	{
		private class singleArmor
		{
			public int id { get; set; }
			public int sort_id { get; set; }
			public int type_id { get; set; }
			public int equip_job_group_id { get; set; }
			public int parts_group_id { get; set; }
			public int defense { get; set; }
			public int ability_defense { get; set; }
			public int weight { get; set; }
			public int evasion_rate { get; set; }
			public int ability_evasion_rate { get; set; }
			public int ability_disturbed_rate { get; set; }
			public int destroy_rate { get; set; }
			public int magnetic_force { get; set; }
			public int invalid_reflection { get; set; }
			public int trigger_ability_id { get; set; }
			public int wear_function_group_id { get; set; }
			public int wear_condition_group_id { get; set; }
			public int resistance_attribute { get; set; }
			public int resistance_condition { get; set; }
			public int resistance_species { get; set; }
			public int strength { get; set; }
			public int vitality { get; set; }
			public int agility { get; set; }
			public int intelligence { get; set; }
			public int spirit { get; set; }
			public int magic { get; set; }
			public int max_hp_up { get; set; }
			public int max_mp_up { get; set; }
			public int battle_effect_asset_id { get; set; }
			public int guard_icon { get; set; }
			public int se_asset_id { get; set; }
			public int buy { get; set; }
			public int sell { get; set; }
			public int sales_not_possible { get; set; }
			public string process_prog { get; set; }
		}

		public const int ironShield = 228; // t1
		public const int darkShield = 229; // t1
		public const int demonShield = 230; // t2
		public const int lightShield = 231; // t3
		public const int mythrilShield = 232; // t4
		public const int flameShield = 233; // t5
		public const int iceShield = 234; // t5
		public const int diamondShield = 235; // t6
		public const int aegisShield = 236; // t7
		public const int genjiShield = 237; // t7
		public const int dragonShield = 238; // t7
		public const int crystalShield = 239; // t8
		public const int leatherCap = 241; // t1
		public const int headband = 242; // t3
		public const int featherCap = 243; // t2
		public const int ironHelm = 244; // t1
		public const int wizardHat = 245; // t4
		public const int greenBeret = 246; // t4
		public const int darkHelm = 247; // t2
		public const int hadesHelm = 248; // t3
		public const int sageMiter = 249; // t6
		public const int blackCowl = 250; // t6
		public const int demonHelm = 251; // t4
		public const int lightHelm = 252; // t6
		public const int goldHairpin = 253; // t6
		public const int mythrilHelm = 254; // t5
		public const int diamondHelm = 255; // t7
		public const int ribbon = 256; // t8
		public const int genjiHelm = 257; // t7
		public const int dragonHelm = 258; // t7
		public const int crystalHelm = 259; // t8
		public const int glassMask = 260; // t8
		public const int clothes = 262; // t1
		public const int prisonerCloth = 263; // t1
		public const int leatherGarb = 264; // t1
		public const int bardTunic = 265; // t1
		public const int gaiaGear = 266; // t3
		public const int ironArmor = 267; // t1
		public const int darkArmor = 268; // t1
		public const int sageSurplice = 269; // t4
		public const int kenpoGi = 270; // t4
		public const int hadesArmor = 271; // t2
		public const int blackRobe = 272; // t4
		public const int demonArmor = 273; // t3
		public const int blackBeltGi = 274; // t6
		public const int knightArmor = 275; // t3
		public const int lightRobe = 276; // t4
		public const int mythrilArmor = 277; // t4
		public const int flameMail = 278; // t5
		public const int powerSash = 279; // t6
		public const int iceArmor = 280; // t5
		public const int whiteRobe = 281; // t7
		public const int diamondArmor = 282; // t6
		public const int minervaBustier = 283; // t7
		public const int genjiArmor = 284; // t7
		public const int dragonMail = 285; // t7
		public const int blackGarb = 286; // t7
		public const int crystalMail = 287; // t8
		public const int adamantArmor = 288; // t9
		public const int rubyRing = 290; // t1
		public const int cursedRing = 291; // t3
		public const int ironGloves = 292; // t1
		public const int darkGloves = 293; // t1
		public const int ironArmlet = 294; // t1
		public const int powerArmlet = 295; // t4
		public const int hadesGloves = 296; // t2
		public const int demonGloves = 297; // t3
		public const int silverArmlet = 298; // t3
		public const int gauntlets = 299; // t7
		public const int runeArmlet = 300; // t5
		public const int mythrilGloves = 301; // t4
		public const int diamondArmlet = 302; // t6
		public const int diamondGloves = 303; // t5
		public const int genjiGloves = 304; // t7
		public const int dragonGloves = 305; // t7
		public const int giantGloves = 306; // t7
		public const int crystalGloves = 307; // t8
		public const int protectRing = 308; // t8
		public const int crystalRing = 309; // t7

		public const int grandArmor = 830; // t8
		public const int dragoonPlate = 831; // t8
		public const int caesarsPlate = 832; // t9
		public const int maximiillian = 833; // t9
		public const int redJacket = 834; // t7
		public const int braveSuit = 835; // t8
		public const int chocoboSuit = 836; // t8
		public const int tabbySuit = 837; // t8
		public const int battleGear = 838; // t9
		public const int assassinVest = 839; // t9
		public const int vishnuVest = 840; // t9
		public const int sageRobe = 841; // t9
		public const int robeOfLords = 842; // t9
		public const int rainbowRobe = 843; // t9
		public const int whiteDress = 844; // t9
		public const int heroShield = 845; // t9
		public const int chocoboShield = 846; // t7
		public const int hypnocrown = 847; // t7
		public const int catearHood = 848; // t7
		public const int whiteTigerMask = 849; // t7
		public const int redCap = 850; // t8
		public const int rabbitearHood = 851; // t9
		public const int augustineTiara = 852; // t9
		public const int starOfKamiKazari = 853; // t9
		public const int royalCrown = 854; // t9
		public const int dualMask = 855; // t9
		public const int demonHat = 856; // t9
		public const int philosopherHat = 857; // t9
		public const int grandHelm = 858; // t9
		public const int caesarHelm = 859; // t9
		public const int dragoonHelm = 860; // t9
		public const int edgeDemonHelm = 861; // t9
		public const int safetyMet = 862; // t9
		public const int erdrickArmor = 863; // t8
		public const int silverShield = 864; // t8

		public List<List<int>> tiers = new List<List<int>>
			{ new List<int> { ironShield, darkShield, leatherCap, ironHelm, clothes, prisonerCloth, leatherGarb, bardTunic, ironArmor, darkArmor, rubyRing, ironGloves, darkGloves, ironArmlet },
			  new List<int> { demonShield, featherCap, darkHelm, hadesArmor, hadesGloves },
			  new List<int> { lightShield, headband, hadesHelm, gaiaGear, demonArmor, knightArmor, cursedRing, demonGloves, silverArmlet },
			  new List<int> { mythrilShield, wizardHat, greenBeret, demonHelm, sageSurplice, kenpoGi, blackRobe, lightRobe, mythrilArmor, powerArmlet, mythrilGloves },
			  new List<int> { flameShield, iceShield, mythrilHelm, flameMail, iceArmor, runeArmlet, diamondGloves },
			  new List<int> { diamondShield, sageMiter, blackCowl, lightHelm, goldHairpin, blackBeltGi, powerSash, diamondArmor, diamondArmlet },
			  new List<int> { aegisShield, genjiShield, dragonShield, diamondHelm, genjiHelm, dragonHelm, whiteRobe, minervaBustier, genjiArmor,
				dragonMail, blackGarb, gauntlets, genjiGloves, dragonGloves, giantGloves, crystalRing, redJacket, chocoboShield, hypnocrown, catearHood, whiteTigerMask },
			  new List<int> { crystalShield, ribbon, crystalHelm, glassMask, crystalMail, crystalGloves, protectRing, grandArmor, dragoonPlate, braveSuit, chocoboSuit, tabbySuit, redCap, erdrickArmor, silverShield },
			  new List<int> { adamantArmor, caesarsPlate, maximiillian, battleGear, assassinVest, vishnuVest, sageRobe, robeOfLords, rainbowRobe, whiteDress, heroShield, 
				  rabbitearHood, augustineTiara, starOfKamiKazari, royalCrown, dualMask, demonHat, philosopherHat, grandHelm, caesarHelm, dragonHelm, safetyMet, edgeDemonHelm }
		};

		public List<int> bonusArmor = new List<int> { grandArmor, dragoonPlate, caesarsPlate, maximiillian, redJacket, braveSuit, chocoboSuit, tabbySuit, battleGear, assassinVest, vishnuVest, 
			sageRobe, robeOfLords, rainbowRobe, whiteDress, heroShield, chocoboShield, hypnocrown, catearHood, whiteTigerMask, redCap, rabbitearHood, augustineTiara, starOfKamiKazari, royalCrown, 
			dualMask, demonHat, philosopherHat, grandHelm, caesarHelm, dragoonHelm, edgeDemonHelm, safetyMet, erdrickArmor, silverShield };

		public List<int> fgExclusiveArmor = new List<int> { erdrickArmor, silverShield };

		public List<int> dkCecilOnly = new List<int> { darkHelm, hadesHelm, demonHelm, darkShield, demonShield, darkArmor, hadesArmor, demonArmor, darkGloves, hadesGloves, demonGloves };
		public List<int> pallyCecilOnly = new List<int> { knightArmor, crystalMail, caesarsPlate, lightShield, crystalShield, lightHelm, crystalHelm, caesarHelm, gauntlets };
		public List<int> kainOnly = new List<int> { dragoonPlate, dragonHelm };
		public List<int> rosaOnly = new List<int> { whiteDress, augustineTiara };
		public List<int> rydiaOnly = new List<int> { rainbowRobe, starOfKamiKazari };
		public List<int> cidOnly = new List<int> { grandArmor, maximiillian, safetyMet };
		public List<int> edwardOnly = new List<int> { redJacket, vishnuVest, redCap, royalCrown };
		public List<int> yangOnly = new List<int> { braveSuit, battleGear, whiteTigerMask, dualMask };
		public List<int> palomOnly = new List<int> { chocoboSuit, sageRobe, hypnocrown, demonHat };
		public List<int> poromOnly = new List<int> { tabbySuit, robeOfLords, catearHood, philosopherHat };
		public List<int> edgeOnly = new List<int> { assassinVest, edgeDemonHelm };
		public List<int> cecilKainCid = new List<int> { ironArmor, mythrilArmor, flameMail, iceArmor, diamondArmor, dragonMail, ironShield, mythrilShield, flameShield, iceShield, diamondShield, aegisShield, genjiShield, dragonShield, ironHelm, mythrilHelm, diamondHelm, dragonHelm, diamondGloves, dragonGloves };
		public List<int> cecilKainCidEdge = new List<int> { genjiArmor, ironGloves, mythrilGloves, genjiGloves };
		public List<int> rydiaRosaPorom = new List<int> { minervaBustier, goldHairpin };

		const int dkCecil = 1;
		const int cecil = 13;
		const int kain = 2;
		const int rosa = 3;
		const int rydia = 4;
		const int cid = 5;
		const int tellah = 6;
		const int edward = 7;
		const int yang = 8;
		const int palom = 9;
		const int porom = 10;
		const int edge = 11;
		const int fusoya = 12;

		public void adjustPrices(string directory, int multiplier, int divisor)
		{
			List<singleArmor> records;

			using (StreamReader reader = new StreamReader(Path.Combine("csv", "armor.csv")))
			using (CsvReader csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
				records = csv.GetRecords<singleArmor>().ToList();

			foreach (singleArmor item in records)
			{
				item.buy *= multiplier;
				item.buy /= divisor;
				item.sell *= Math.Min(multiplier, 4);
				item.sell /= divisor;

				item.buy = item.buy > 99999 ? 99999 : item.buy < 1 ? 1 : item.buy;
				item.sell = item.sell > 99999 ? 99999 : item.sell < 1 ? 1 : item.sell;
			}

			using (StreamWriter writer = new StreamWriter(Path.Combine(directory, "armor.csv")))
			using (CsvWriter csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(records);
			}
		}

		public int selectItem(Random r1, int minTier, int maxTier, bool highTierReduction, bool includeBonus, bool includeExclusive, int[] party)
		{
			List<int> selection = new List<int>();
			for (int i = minTier - 1; i <= maxTier - 1; i++)
			{
				int repetition = highTierReduction ? maxTier - i : 1;
				for (int j = 0; j < repetition; j++)
					selection.AddRange(tiers[i]);

				if (!party.Contains(dkCecil)) selection = selection.Where(c => !dkCecilOnly.Contains(c)).ToList();
				if (!party.Contains(cecil)) selection = selection.Where(c => !pallyCecilOnly.Contains(c)).ToList();
				if (!party.Contains(kain)) selection = selection.Where(c => !kainOnly.Contains(c)).ToList();
				if (!party.Contains(rosa)) selection = selection.Where(c => !rosaOnly.Contains(c)).ToList();
				if (!party.Contains(rydia)) selection = selection.Where(c => !rydiaOnly.Contains(c)).ToList();
				if (!party.Contains(cid)) selection = selection.Where(c => !cidOnly.Contains(c)).ToList();
				if (!party.Contains(edward)) selection = selection.Where(c => !edwardOnly.Contains(c)).ToList();
				if (!party.Contains(yang)) selection = selection.Where(c => !yangOnly.Contains(c)).ToList();
				if (!party.Contains(palom)) selection = selection.Where(c => !palomOnly.Contains(c)).ToList();
				if (!party.Contains(porom)) selection = selection.Where(c => !poromOnly.Contains(c)).ToList();
				if (!party.Contains(edge)) selection = selection.Where(c => !edgeOnly.Contains(c)).ToList();
				if (!party.Contains(cecil) && !party.Contains(kain) && !party.Contains(cid)) selection = selection.Where(c => !cecilKainCid.Contains(c)).ToList();
				if (!party.Contains(edge) && !party.Contains(kain) && !party.Contains(cid) && !party.Contains(edge)) selection = selection.Where(c => !cecilKainCidEdge.Contains(c)).ToList();
				if (!party.Contains(rydia) && !party.Contains(rosa) && !party.Contains(porom)) selection = selection.Where(c => !rydiaRosaPorom.Contains(c)).ToList();
			}

			bool bad = true;
			int finalSelection = -1;
			while (bad)
			{
				finalSelection = selection[r1.Next() % selection.Count];
				if (includeBonus || !bonusArmor.Contains(finalSelection)) bad = false;
				if (includeExclusive || !fgExclusiveArmor.Contains(finalSelection)) bad = false;
			}

			return selection[r1.Next() % selection.Count];
		}
	}
}
