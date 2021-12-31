using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static FF4FabulGauntlet.Common.Common;

namespace FF4FabulGauntlet.Inventory
{
	class Weapons
	{
		private class singleWeapon
		{
			public int id { get; set; }
			public string sort_id { get; set; }
			public int type_id { get; set; }
			public int category_type { get; set; }
			public int attribute_id { get; set; }
			public int attribute_group_id { get; set; }
			public int equip_job_group_id { get; set; }
			public int parts_group_id { get; set; }
			public int attack { get; set; }
			public int weight { get; set; }
			public int accuracy_rate { get; set; }
			public int evasion_rate { get; set; }
			public int ability_disturbed_rate { get; set; }
			public int destroy_rate { get; set; }
			public int magnetic_force { get; set; }
			public int throw_flag { get; set; }
			public int back_flag { get; set; }
			public int two_handed_flag { get; set; }
			public int invalid_reflection { get; set; }
			public int trigger_ability_id { get; set; }
			public int wear_function_group_id { get; set; }
			public int wear_condition_group_id { get; set; }
			public int weak_attribute { get; set; }
			public int effective_species { get; set; }
			public int additional_condition_group_id { get; set; }
			public int strength { get; set; }
			public int vitality  { get; set; }
			public int agility { get; set; }
			public int intelligence { get; set; }
			public int spirit { get; set; }
			public int magic { get; set; }
			public int critical_rate { get; set; }
			public int max_hp_up { get; set; }
			public int max_mp_up { get; set; }
			public int battle_equipment_asset_id { get; set; }
			public int battle_effect_asset_id { get; set; }
			public int guard_icon { get; set; }
			public int buy { get; set; }
			public int sell { get; set; }
			public int sales_not_possible { get; set; }
			public string process_prog { get; set; }
		}

		public const int darkSword = 128; // t1
		public const int shadowblade = 129; // t1
		public const int deathbringer = 130; // t2
		public const int legendSword = 131; // t3
		public const int lightSword = 132; // t6
		public const int excalibur = 133; // t7
		public const int ragnarok = 134; // t8
		public const int ancientSword = 135; // t3
		public const int bloodSword = 136; // t3
		public const int mythrilSword = 137; // t4
		public const int sleepBlade = 138; // t4
		public const int flameSword = 139; // t5
		public const int icebrand = 140; // t5
		public const int gorgonBlade = 141; // t5
		public const int avenger = 142; // t6
		public const int defender = 143; // t6
		public const int spear = 148; // t1
		public const int windSpear = 149; // t3
		public const int fireLance = 150; // t5
		public const int iceLance = 151; // t5
		public const int bloodLance = 152; // t4
		public const int gungnir = 153; // t6
		public const int wyvernLance = 154; // t7
		public const int holyLance = 155; // t7
		public const int mythrilKnife = 156; // t3
		public const int dancingDagger = 157; // t4
		public const int mageMasher = 158; // t5
		public const int knife = 159; // t9
		public const int dreamerHarp = 160; // t1
		public const int lamiaHarp = 161; // t2
		public const int fireClaw = 162; // t2
		public const int iceClaw = 163; // t2
		public const int thunderClaw = 164; // t2
		public const int fairyClaw = 165; // t4
		public const int hellClaw = 166; // t5
		public const int catClaw = 167; // t6
		public const int woodenHammer = 168; // t2
		public const int mythrilHammer = 169; // t3
		public const int gaiaHammer = 170; // t5
		public const int dwarfAxe = 171; // t5
		public const int ogreKiller = 172; // t6
		public const int poisonAxe = 173; // t6
		public const int runeAxe = 174; // t6
		public const int kunai = 175; // t4
		public const int ashura = 176; // t5
		public const int kotetsu = 177; // t5
		public const int kikuichimonji = 178; // t6
		public const int murasame = 179; // t8
		public const int masamune = 180; // t8
		public const int rod = 181; // t1
		public const int flameRod = 182; // t2
		public const int iceRod = 183; // t2
		public const int thunderRod = 184; // t2
		public const int lilithRod = 185; // t4
		public const int changeRod = 186; // t5
		public const int fairyRod = 187; // t6
		public const int stardustRod = 188; // t8
		public const int staff = 189; // t1
		public const int healingStaff = 190; // t2
		public const int mythrilStaff = 191; // t3
		public const int powerStaff = 192; // t5
		public const int kinesisStaff = 193; // t5
		public const int sageStaff = 194; // t7
		public const int runeStaff = 195; // t8
		public const int bow = 196; // t1
		public const int greatBow = 198; // t2
		public const int killerBow = 199; // t3
		public const int elvenBow = 200; // t4
		public const int yoichiBow = 201; // t6
		public const int artemisBow = 202; // t7
		public const int medusaArrow = 203; // t3
		public const int ironArrow = 204; // t1
		public const int holyArrow = 205; // t2
		public const int fireArrow = 206; // t4
		public const int iceArrow = 207; // t4
		public const int thunderArrow = 208; // t4
		public const int blindingArrow = 209; // t5
		public const int poisonArrow = 210; // t5
		public const int muteArrow = 211; // t6
		public const int angelArrow = 212; // t7
		public const int yoichiArrow = 213; // t7
		public const int artemisArrow = 214; // t8
		public const int whip = 215; // t4
		public const int chainWhip = 216; // t5
		public const int blitzWhip = 217; // t6
		public const int flameWhip = 218; // t7
		public const int dragonWhisker = 219; // t8
		public const int boomerang = 220; // t5
		public const int moonringBlade = 221; // t6
		public const int shuriken = 222; // t5
		public const int fumaShuriken = 223; // t7

		public const int excalipoor = 799; // t2
		public const int flandango = 800; // t4
		public const int lightbringer = 801; // t9
		public const int piggyStick = 802; // t6
		public const int abelsLance = 803; // t9
		public const int gigantAxe = 804; // t9
		public const int perseusBow = 805; // t9
		public const int perseusArrow = 806; // t9
		public const int mysticWhip = 807; // t8
		public const int tritonDagger = 808; // t8
		public const int assassinDagger = 809; // t9
		public const int sasukeKatana = 810; // t9
		public const int mutsunokami = 811; // t9
		public const int scrapMetal = 812; // t2
		public const int risingSun = 813; // t8
		public const int tigerFangs = 814; // t7
		public const int dragonClaws = 815; // t8
		public const int godhand = 816; // t9
		public const int thorHammer = 817; // t8
		public const int fieryHammer = 818; // t9
		public const int asuraRod = 819; // t9
		public const int seraphimMace = 820; // t8
		public const int nirvana = 821; // t9
		public const int apolloHarp = 822; // t6
		public const int requiemHarp = 823; // t8
		public const int lokiHarp = 824; // t9

		public List<List<int>> tiers = new List<List<int>>
			{ new List<int> { darkSword, shadowblade, spear, dreamerHarp, rod, staff, bow, ironArrow },
			  new List<int> { deathbringer, lamiaHarp, fireClaw, iceClaw, thunderClaw, woodenHammer, flameRod, iceRod, thunderRod, healingStaff, greatBow, holyArrow, excalipoor, scrapMetal },
			  new List<int> { legendSword, ancientSword, bloodSword, windSpear, mythrilKnife, mythrilHammer, mythrilStaff, killerBow, medusaArrow },
			  new List<int> { mythrilSword, sleepBlade, bloodLance, dancingDagger, fairyClaw, kunai, lilithRod, elvenBow, fireArrow, iceArrow, thunderArrow, whip, flandango },
			  new List<int> { flameSword, icebrand, gorgonBlade, fireLance, iceLance, mageMasher, hellClaw, gaiaHammer, dwarfAxe, ashura, kotetsu,
				changeRod, powerStaff, kinesisStaff, blindingArrow, poisonArrow, chainWhip, boomerang, shuriken },
			  new List<int> { lightSword, avenger, defender, gungnir, catClaw, ogreKiller, poisonAxe, runeAxe, kikuichimonji, fairyRod, yoichiBow, muteArrow, blitzWhip, moonringBlade, piggyStick, apolloHarp },
			  new List<int> { excalibur, wyvernLance, holyLance, sageStaff, artemisBow, angelArrow, yoichiArrow, flameWhip, fumaShuriken, tigerFangs },
			  new List<int> { ragnarok, murasame, masamune, stardustRod, runeStaff, artemisArrow, dragonWhisker, mysticWhip, tritonDagger, risingSun, dragonClaws, thorHammer, seraphimMace, requiemHarp },
			  new List<int> { ragnarok, murasame, masamune, stardustRod, runeStaff, artemisArrow, dragonWhisker, mysticWhip, tritonDagger, risingSun, dragonClaws, thorHammer, seraphimMace, requiemHarp, knife,
				lightbringer, abelsLance, gigantAxe, perseusBow, perseusArrow, assassinDagger, sasukeKatana, mutsunokami, godhand, fieryHammer, asuraRod, nirvana, lokiHarp }
		};

		public List<int> bonusWeapons = new List<int>
		{
			excalipoor, flandango, lightbringer, piggyStick, abelsLance, gigantAxe, perseusArrow, perseusBow, mysticWhip, tritonDagger, assassinDagger, sasukeKatana, mutsunokami,
			scrapMetal, risingSun, tigerFangs, dragonClaws, godhand, thorHammer, fieryHammer, asuraRod, seraphimMace, nirvana, apolloHarp, requiemHarp, lokiHarp
		};

		public void adjustPrices(string directory, int multiplier, int divisor)
		{
			List<singleWeapon> records;

			using (StreamReader reader = new StreamReader(Path.Combine("csv", "weapon.csv")))
			using (CsvReader csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
				records = csv.GetRecords<singleWeapon>().ToList();

			foreach (singleWeapon item in records)
			{
				item.buy *= multiplier;
				item.buy /= divisor;
				item.sell *= Math.Min(multiplier, 4);
				item.sell /= divisor;

				item.buy = item.buy > 99999 ? 99999 : item.buy < 1 ? 1 : item.buy;
				item.sell = item.sell > 99999 ? 99999 : item.sell < 1 ? 1 : item.sell;
			}

			using (StreamWriter writer = new StreamWriter(Path.Combine(directory, "weapon.csv")))
			using (CsvWriter csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(records);
			}
		}

		public int selectItem(Random r1, int minTier, int maxTier, bool highTierReduction, bool includeBonus)
		{
			List<int> selection = new List<int>();
			for (int i = minTier - 1; i <= maxTier - 1; i++)
			{
				int repetition = highTierReduction ? maxTier - i : 1;
				for (int j = 0; j < repetition; j++)
					selection.AddRange(tiers[i]);
			}
			bool bad = true;
			int finalSelection = -1;
			while (bad)
			{
				finalSelection = selection[r1.Next() % selection.Count];
				if (includeBonus || !bonusWeapons.Contains(finalSelection))
					bad = false;
			}
			return finalSelection;
		}
	}
}
