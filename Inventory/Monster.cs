﻿using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF4FabulGauntlet.Inventory
{
	public class Monster
	{
		private class singleMonster
		{
			public int id { get; set; }
			public string mes_id_name { get; set; }
			public int cursor_x_position { get; set; }
			public int cursor_y_position { get; set; }
			public int in_type_id { get; set; }
			public int disappear_type_id { get; set; }
			public int species { get; set; }
			public int resistance_attribute { get; set; }
			public int resistance_condition { get; set; }
			public int initial_condition { get; set; }
			public int lv { get; set; }
			public int hp { get; set; }
			public int mp { get; set; }
			public int exp { get; set; }
			public int gill { get; set; }
			public int attack_count { get; set; }
			public int attack_plus { get; set; }
			public int attack_plus_group { get; set; }
			public int attack_attribute { get; set; }
			public int strength { get; set; }
			public int vitality { get; set; }
			public int agility { get; set; }
			public int intelligence { get; set; }
			public int spirit { get; set; }
			public int magic { get; set; }
			public int attack { get; set; }
			public int ability_attack { get; set; }
			public int defense { get; set; }
			public int ability_defense { get; set; }
			public int ability_defense_rate { get; set; }
			public int accuracy_rate { get; set; }
			public int dodge_times { get; set; }
			public int evasion_rate { get; set; }
			public int magic_evasion_rate { get; set; }
			public int ability_disturbed_rate { get; set; }
			public int critical_rate { get; set; }
			public int luck { get; set; }
			public int weight { get; set; }
			public int boss { get; set; }
			public int monster_flag_group_id { get; set; }
			public int drop_rate { get; set; }
			public int drop_content_id1 { get; set; }
			public int drop_content_id1_value { get; set; }
			public int drop_content_id2 { get; set; }
			public int drop_content_id2_value { get; set; }
			public int drop_content_id3 { get; set; }
			public int drop_content_id3_value { get; set; }
			public int drop_content_id4 { get; set; }
			public int drop_content_id4_value { get; set; }
			public int drop_content_id5 { get; set; }
			public int drop_content_id5_value { get; set; }
			public int drop_content_id6 { get; set; }
			public int drop_content_id6_value { get; set; }
			public int drop_content_id7 { get; set; }
			public int drop_content_id7_value { get; set; }
			public int drop_content_id8 { get; set; }
			public int drop_content_id8_value { get; set; }
			public int steal_content_id1 { get; set; }
			public int steal_content_id2 { get; set; }
			public int steal_content_id3 { get; set; }
			public int steal_content_id4 { get; set; }
			public int script_id { get; set; }
			public int monster_asset_id { get; set; }
			public int battle_effect_asset_id { get; set; }
			public int p_use_ability_random_group_id { get; set; }
			public int command_group_type { get; set; }
			public int release_ability_random_group_id { get; set; }
			public int rage_ability_random_group_id { get; set; }
		}

		private class singleGroup
		{
			public int id { get; set; }
			public int battle_background_asset_id { get; set; }
			public int battle_bgm_asset_id { get; set; }
			public int appearance_production { get; set; }
			public int script_name { get; set; }
			public int battle_pattern1 { get; set; }
			public int battle_pattern2 { get; set; }
			public int battle_pattern3 { get; set; }
			public int battle_pattern4 { get; set; }
			public int battle_pattern5 { get; set; }
			public int battle_pattern6 { get; set; }
			public int not_escape { get; set; }
			public int battle_flag_group_id { get; set; }
			public int get_value { get; set; }
			public int get_ap { get; set; }
			public int monster1 { get; set; }
			public int monster1_x_position { get; set; }
			public int monster1_y_position { get; set; }
			public int monster1_group { get; set; }
			public int monster2 { get; set; }
			public int monster2_x_position { get; set; }
			public int monster2_y_position { get; set; }
			public int monster2_group { get; set; }
			public int monster3 { get; set; }
			public int monster3_x_position { get; set; }
			public int monster3_y_position { get; set; }
			public int monster3_group { get; set; }
			public int monster4 { get; set; }
			public int monster4_x_position { get; set; }
			public int monster4_y_position { get; set; }
			public int monster4_group { get; set; }
			public int monster5 { get; set; }
			public int monster5_x_position { get; set; }
			public int monster5_y_position { get; set; }
			public int monster5_group { get; set; }
			public int monster6 { get; set; }
			public int monster6_x_position { get; set; }
			public int monster6_y_position { get; set; }
			public int monster6_group { get; set; }
			public int monster7 { get; set; }
			public int monster7_x_position { get; set; }
			public int monster7_y_position { get; set; }
			public int monster7_group { get; set; }
			public int monster8 { get; set; }
			public int monster8_x_position { get; set; }
			public int monster8_y_position { get; set; }
			public int monster8_group { get; set; }
			public int monster9 { get; set; }
			public int monster9_x_position { get; set; }
			public int monster9_y_position { get; set; }
			public int monster9_group { get; set; }
		}

        readonly List<List<int>> monsterTiers = new()
        { 
			new List<int> { 1, 3, 4, 8, 5, 11, 10, 12, 13 }, // Outside Baron, Mist Cave, Mist/Kaipo
			new List<int> { 43, 42, 13, 14, 1, 17, 20, 22, 8, 9, 19, 16, 12, 13, 28 }, // Underground Waterway / Damcyan
			new List<int> { 27, 2, 28, 1, 23, 21, 36, 35, 37, 48, 38, 86, 87, 22, 32 }, // Antlion Cave / Mt. Hobs / Fabul / Fabul Gauntlet
			new List<int> { 1, 8, 28, 9, 32, 37, 41, 35, 47, 48, 49, 51, 94, 36, 16 }, // Mysidia, Mt. Ordeals
			new List<int> { 43, 74, 55, 58, 15, 56, 44, 57 }, // Old Baron Waterway
			new List<int> { 67, 6, 62, 64, 61, 66, 52, 43, 74, 55, 58, 15, 56, 44, 57, 1, 8, 28, 9, 32, 37, 41, 35, 47, 48, 49, 51, 53, 94, 36, 16 }, // Magnes Cave - Include easier zones from Old Baron and Mysidia
			new List<int> { 61, 62, 67, 7, 34, 71, 72, 29, 118, 89, 121, 68, 69, 123, 113, 78 }, // Troia / Zot Tower
			new List<int> { 25, 83, 77, 26, 71, 65, 101, 104, 91, 88, 130, 93, 81, 117 }, // Dwarf Castle, Lower Babil
			new List<int> { 97, 98, 39, 90, 26, 91, 148, 50, 60, 110, 100, 6, 102, 77, 106, 79, 99, 63, 134, 133 }, // Eblan Area, Upper Babil (2 rounds)
			new List<int> { 97, 98, 39, 90, 26, 91, 148, 50, 60, 110, 100, 6, 102, 77, 106, 79, 99, 63, 134, 133, 95, 182 }, // Eblan Area, Upper Babil (2 rounds)
			new List<int> { 119, 24, 18, 122, 116, 40, 103, 158, 143, 76, 70, 73, 75, 80, 92, 112, 120, 127, 142 }, // Cave Of Summons, other underground locations
			new List<int> { 140, 126, 85, 125, 96, 114, 152, 139, 147, 54, 141, 161, 144, 154, 131, 128, 107, 106, 112, 115, 127 }, // Bahamut Cave / Sylvan Cave / Lunar Overworld
			new List<int> { 138, 137, 111, 105, 146, 152, 139, 147, 54, 141, 161, 157, 156, 149, 82, 109, 182 }, // Lunar Subterrane / Giant Of Babil
			new List<int> { 138, 137, 111, 105, 146, 152, 139, 147, 54, 141, 161, 157, 156, 149, 82, 141, 157, 111, 161, 160, 156, 145, 129, 132, 189, 190, 155, 182 }, // Lunar Subterrane Part 2 (2 rounds)
			new List<int> { 138, 137, 111, 105, 146, 152, 139, 147, 54, 141, 161, 157, 156, 149, 82, 141, 157, 111, 161, 160, 156, 145, 129, 132, 189, 190, 155,
				162, 164, 165, 166, 167, 206, 168, 171, 205, 225, 175, 178, 179, 211, 185, 183, 184, 188, 181, 182, 189, 190, 193, 191, 192, 194, 198, 108, 150, 153, 159 } // Lunar Subterrane Part 2 (2 rounds)
		};

        readonly List<List<int>> monsterBosses = new()
        {
			new List<int> { 162, 31 }, // Outside Baron, Mist Cave, Mist/Kaipo
			new List<int> { 163, 31 }, // Underground Waterway / Damcyan
			new List<int> { 164, 165, 46 }, // Antlion Cave / Mt. Hobs / Fabul / Fabul Gauntlet
			new List<int> { 166, 167, 206 }, // Mysidia, Mt. Ordeals
			new List<int> { 59, 168, 171, 173, 196, 205 }, // Old Baron Waterway (or 173)
			new List<int> { }, // Magnes Cave
			new List<int> { 175, 178 }, // Troia / Zot Tower
			new List<int> { 179, 211, 185, 183, 184 }, // Dwarf Castle, Lower Babil
			new List<int> { 182 }, // Eblan Area, Upper Babil (2 rounds)
			new List<int> { 188, 181 }, // Eblan Area, Upper Babil (2 rounds)
			new List<int> { 189, 190, 193 }, // Cave Of Summons, other underground locations
			new List<int> { 189, 190, 193, 191 }, // Bahamut Cave / Sylvan Cave / Lunar Overworld
			new List<int> { 192, 194, 198 }, // Lunar Subterrane / Giant Of Babil
			new List<int> { 108, 150, 153, 159 }, // Lunar Subterrane Part 2  (2 rounds)
			new List<int> { 162, 164, 165, 166, 167, 206, 168, 171, 205, 225, 175, 178, 179, 211, 185, 183, 184, 188, 181, 189, 190, 193, 191, 192, 194, 198, 108, 150, 153, 159 } // Lunar Subterrane Part 2  (2 rounds)
			// Final boss:  217
		};

        readonly List<int> allBosses = new()
        {
			162, 31, 164, 165, 46, 166, 167, 168, 171, 173, 196, 205, 225, 175, 178, 179, 211, 185, 183, 184, 188, 181, 189, 190, 193, 191, 192, 194, 198, 108, 150, 153, 159, // Actual bosses...
			156, 160, 161, 145, 129, 132 // ... and Lunar Subteranne Core monsters - Blue Dragon, Red Dragon, Zemus's Breath and Mind, Behemoths, and Wicked Masks.
		};

        readonly List<List<int>> xpLimits = new()
        {
			new List<int> { 100, 125, 150, 175, 200, 225, 250, 275, 300, 900 }, // Outside Baron, Mist Cave, Mist/Kaipo
			new List<int> { 300, 350, 400, 450, 500, 550, 600, 700, 800, 1400 }, // Underground Waterway / Damcyan
			new List<int> { 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 2500 }, // Antlion Cave / Mt. Hobs / Fabul / Fabul Gauntlet
			new List<int> { 600, 800, 1000, 1200, 1400, 1600, 1800, 2000, 2200, 4500 }, // Mysidia, Mt. Ordeals
			new List<int> { 500, 750, 1000, 1250, 1500, 1750, 2000, 2250, 2500, 6000 }, // Old Baron Waterway (or 173)
			new List<int> { 300, 450, 600, 750, 900, 1050, 1200, 1350, 1500, 1800 }, // Magnes Cave
			new List<int> { 700, 1000, 1300, 1600, 1900, 2200, 2500, 2800, 3100, 10000 }, // Troia / Zot Tower
			new List<int> { 2000, 2400, 2800, 3200, 3600, 4000, 4400, 4800, 5200, 15000 }, // Dwarf Castle, Lower Babil
			new List<int> { 1200, 1600, 2000, 2400, 2800, 3200, 3600, 4000, 4400, 4800 }, // Eblan Area, Upper Babil (2 rounds)
			new List<int> { 1500, 2000, 2500, 3000, 3500, 4000, 4500, 5000, 5500, 20000 }, // Eblan Area, Upper Babil (2 rounds)
			new List<int> { 2000, 2500, 3000, 3500, 4000, 4500, 5000, 6000, 7000, 30000 }, // Cave Of Summons, other underground locations
			new List<int> { 2500, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 40000 }, // Bahamut Cave / Sylvan Cave / Lunar Overworld
			new List<int> { 10000, 12000, 15000, 17500, 20000, 22500, 25000, 27500, 30000, 60000 }, // Lunar Subterrane / Giant Of Babil
			new List<int> { 20000, 25000, 30000, 35000, 40000, 45000, 50000, 55000, 60000, 100000 }, // Lunar Subterrane Part 2  (2 rounds)
			new List<int> { 50000, 60000, 70000, 80000, 90000, 100000, 125000, 150000, 200000, 0 }, // Lunar Subterrane Part 2  (2 rounds)
			new List<int> { 5000, 5000, 6000, 7000, 8000, 8000, 10000, 12000, 15000, 20000 }, // Monster in a box, part 1
			new List<int> { 30000, 40000, 50000, 75000, 100000, 125000, 150000, 0, 0, 0 }, // Monster in a box, part 2
			new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } // Extra battles
		};

		class limitedMonsters
		{
			public int id;
			public int hpPercentage = 0;
			public int monsterLimit = 9;
			public int followUp = 0;
		}

		public Monster(Random r1, string directory, double xpMultiplier, int xpBoost, double gpMultiplier, int gpBoost, int gpDivisor, int difficulty, bool areaAppropriate)
		{
			List<singleMonster> allMonsters;

			using (StreamReader reader = new(Path.Combine("csv", "monster.csv")))
			using (CsvReader csv = new(reader, System.Globalization.CultureInfo.InvariantCulture))
				allMonsters = csv.GetRecords<singleMonster>().ToList();

			List<limitedMonsters> restrictedMonsters = new();
			restrictedMonsters.Add(new limitedMonsters { id = 31, monsterLimit = 1, followUp = 30 }); // General -> Baron Soldier
			restrictedMonsters.Add(new limitedMonsters { id = 46, monsterLimit = 1, followUp = 45 }); // Captain -> Baron Warrior
			restrictedMonsters.Add(new limitedMonsters { id = 163, monsterLimit = 1, followUp = -1 }); // Octomammoth
			restrictedMonsters.Add(new limitedMonsters { id = 165, monsterLimit = 1, followUp = -1 }); // Mom Bomb
			restrictedMonsters.Add(new limitedMonsters { id = 166, monsterLimit = 1, followUp = 212 }); // Milon -> Skullnant
			restrictedMonsters.Add(new limitedMonsters { id = 174, monsterLimit = 1, followUp = -1 }); // Sandy, Cindy, Mindy
			restrictedMonsters.Add(new limitedMonsters { id = 175, monsterLimit = 1, followUp = -1 });
			restrictedMonsters.Add(new limitedMonsters { id = 176, monsterLimit = 1, followUp = -1 });
			restrictedMonsters.Add(new limitedMonsters { id = 188, monsterLimit = 1, followUp = -1 }); // Rubicante
			restrictedMonsters.Add(new limitedMonsters { id = 182, monsterLimit = 1, followUp = -1 }); // Shadow Dragon
			restrictedMonsters.Add(new limitedMonsters { id = 178, monsterLimit = 1, followUp = -1 }); // Barbariccia
			restrictedMonsters.Add(new limitedMonsters { id = 171, monsterLimit = 1, followUp = -1 }); // Cagnazzo
			restrictedMonsters.Add(new limitedMonsters { id = 173, monsterLimit = 1, followUp = -1 }); // Dark Elf
			restrictedMonsters.Add(new limitedMonsters { id = 153, monsterLimit = 1, followUp = -1, hpPercentage = 50 }); // Dark Bahamut - also put an HP percentage on that... Meganuke + HP percentage attack would be BRUTAL
			restrictedMonsters.Add(new limitedMonsters { id = 108, monsterLimit = 1, followUp = -1 }); // Plague
			restrictedMonsters.Add(new limitedMonsters { id = 194, monsterLimit = 1, followUp = -1 }); // Elemental Lord (Only 1 target mutates in a 2 Lord situation)
			// Chimera, Mech Dragon, Silver Dragon, and Lunasaurs all have a 20% HP to all characters attack (Blaze typically)
			restrictedMonsters.Add(new limitedMonsters { id = 88, hpPercentage = 20 });
			restrictedMonsters.Add(new limitedMonsters { id = 111, hpPercentage = 20 });
			restrictedMonsters.Add(new limitedMonsters { id = 141, hpPercentage = 20 });
			restrictedMonsters.Add(new limitedMonsters { id = 150, hpPercentage = 20 });
			// Leviathan and Ogopogo both have big wave.  The latter casts it twice in succession.
			restrictedMonsters.Add(new limitedMonsters { id = 190, hpPercentage = 25 });
			restrictedMonsters.Add(new limitedMonsters { id = 155, hpPercentage = 50 });
			// The Attack Node (from the CPU) deals 10% HP to all / turn
			restrictedMonsters.Add(new limitedMonsters { id = 214, hpPercentage = 10 });

			randomizeZemusBreath(r1, allMonsters, restrictedMonsters, directory);

			// Do not choose Mystery Eggs... they're going to softlock the game without some serious work. (224)
			// Do not also choose Golbez or the Shadow Dragons... that's just going to get screwy in a hurry. (177, 274)
			// No Zemus or Zeromus either for obvious reasons.  :) (200, 201, 202, 217)
			// No Dark Elves unless they transition to the Dark Dragon. (172, 225)
			// No Li'l Murderer's.  They wind up crashing the game with their mere existance, sadly. (33)
			// Let's avoid trap doors for now.  (124)
			// Remove the King and Queen of Eblan (186, 187)
			// Calcobrena cannot show up in a monster group.  (but the dolls can combine into Calcobrena) (180)
			// Do not include "character" fights except Dark Knight since we fixed that. (203, 204, 206, 207)
			// Remove Barnabas-Z and Attack Node since they're worth 20 and 0 XP respectively; not appropriate for "non-area appropriate" flags. (212, 213)
			// Do not include the Edge Rubicante fight because it's scripted.  (226)
			// Do not include Elemental Lords except the first phase.  (195, 227, 228)
			// Let's remove "follow up monsters"... Cindy... Mindy... Nodes... Arms... etc. (199, 214, 169, 170, 175, 176)
			List<int> badMonsters = new(){ 224, 177, 274, 200, 201, 202, 217, 172, 225, 33, 124, 186, 187, 180, 203, 204, 207, 212, 213, 226, 195, 227, 228, 199, 214, 169, 170, 175, 176 };

			List<singleGroup> groups = new();

			List<int> monster = new();
			int lastMonster;
			int maxPercentHP;
			bool valid;

			for (int i = 1; i <= 174; i++)
			{
				int j = 0;
				int origXpLimit = xpLimits[(i - 1) / 10][(i - 1) % 10] * (difficulty == 3 ? 3 : difficulty == 4 ? 5 : 2) / 2;
				int xpLimit = xpLimits[(i - 1) / 10][(i - 1) % 10] * (difficulty == 3 ? 3 : difficulty == 4 ? 5 : 2) / 2;
				int lastXP = 0;
				maxPercentHP = 0;
				valid = i < 168;
				lastMonster = -1;
				// Repeat this check 100 times before moving onto the next monster group.
				int loops = 100;

				monster = new List<int>();
				// Limit monster count to 3 in very easy, 5 in easy, 7 in normal, and 9 in hard and very hard difficulties.
				while (valid && monster.Count < (difficulty == 0 ? 3 : difficulty == 1 ? 5 : difficulty == 2 ? 7 : 9) && loops > 0)
				{
					loops--;
					if (lastMonster == -1 || r1.Next() % 2 == 0)
					{
						List<singleMonster> iMonsterList;
						if (i <= 149 && areaAppropriate)
						{
							List<singleMonster> iMonsterList2;
							// Combine bosses and monsters if we're in the last battle of a segment.
							if (i % 10 == 0)
								iMonsterList2 = allMonsters.Where(c => monsterTiers[(i - 1) / 10].Contains(c.id) || monsterBosses[(i - 1) / 10].Contains(c.id)).ToList();
							else
								iMonsterList2 = allMonsters.Where(c => monsterTiers[(i - 1) / 10].Contains(c.id)).ToList();

							// Must have a boss to start if a boss exists in that zone
							if (i % 10 == 0 && j == 0 && monsterBosses[(i - 1) / 10].Count > 0) 
								iMonsterList = iMonsterList2.Where(c => c.exp < xpLimit && monsterBosses[(i - 1) / 10].Contains(c.id)).ToList();
							else
								iMonsterList = iMonsterList2.Where(c => c.exp < xpLimit).ToList();
						}
						else
						{
							if (i % 10 == 0 && j == 0)
								iMonsterList = allMonsters.Where(c => allBosses.Contains(c.id) && c.exp < xpLimit && c.exp >= Math.Pow(xpLimits[(i - 1) / 10][i % 10], .7)).ToList();
							else
								iMonsterList = allMonsters.Where(c => c.exp < xpLimit && c.exp >= Math.Pow(xpLimits[(i - 1) / 10][i % 10], .7)).ToList();
						}

						iMonsterList = iMonsterList.Where(c => !badMonsters.Contains(c.id)).ToList();

						if (iMonsterList.Count >= 1)
						{
							singleMonster chosenMonster;
							chosenMonster = iMonsterList[r1.Next() % iMonsterList.Count];

							// See above comment regarding monsters we don't want chosen for various reasons.
							if (badMonsters.Contains(chosenMonster.id))
							{
								lastMonster = -1;
								continue;
							}
							// Do not include the Elemental Lords if there is a Captain or General included.
							if ((monster.Contains(31) || monster.Contains(46)) && (chosenMonster.id == 194 || chosenMonster.id == 195 || chosenMonster.id == 227 || chosenMonster.id == 228))
							{
								lastMonster = -1;
								continue;
							}
							// ... or vice versa
							if ((monster.Contains(194) || monster.Contains(195) || monster.Contains(227) || monster.Contains(228)) && (chosenMonster.id == 31 || chosenMonster.id == 46))
							{
								lastMonster = -1;
								continue;
							}
							// Cagnazzo can't be with Rubicante; it breaks the latter's script.
							if ((monster.Contains(188) && chosenMonster.id == 171) || (monster.Contains(171) && chosenMonster.id == 188))
							{
								lastMonster = -1;
								continue;
							}
							// Do not allow Calco nor Brena to appear unless the original XP limit exceeds 8000.
							// If we don't include this prohibition, these bosses would appear in the Mist Cave in hard or higher difficulty.
							// There's hard... and then there's unfair...
							if ((chosenMonster.id == 179 || chosenMonster.id == 211) && origXpLimit < 8000)
                            {
								lastMonster = -1;
								continue;
                            }								

							limitedMonsters monsterLimit = restrictedMonsters.Where(c => c.id == chosenMonster.id).FirstOrDefault();
							if (monsterLimit != null)
							{
								if (monsterLimit.monsterLimit >= 1 && monster.Where(c => c == chosenMonster.id).Count() >= monsterLimit.monsterLimit)
								{
									// If there is "no follow-up", just redraw.
									if (monsterLimit.followUp == -1)
									{
										lastMonster = -1;
										continue;
									}
									chosenMonster = allMonsters.Where(c => c.id == monsterLimit.followUp).Single();
								}

								maxPercentHP += monsterLimit.hpPercentage;
								if (maxPercentHP > (difficulty <= 2 ? 50 : difficulty == 3 ? 60 : 75))
								{
									lastMonster = -1;
									continue;
								}
							}

							lastMonster = chosenMonster.id;
							lastXP = chosenMonster.exp;
							monster.Add(chosenMonster.id);
							j++;
							xpLimit -= lastXP;

							if (chosenMonster.id == 31 && monster.Count < 9) // If we see a General...
							{
								monster.Add(30); // Add a Baron Soldier
								xpLimit -= allMonsters.Where(c => c.id == 30).First().exp;
								lastMonster = 30;
								j++;
							}
							else if (chosenMonster.id == 46 && monster.Count < 9) // If we see a Captain...
							{
								monster.Add(45); // Add a Baron Warrior
								xpLimit -= allMonsters.Where(c => c.id == 45).First().exp;
								lastMonster = 45;
								j++;
							}
							else if (chosenMonster.id == 166 && monster.Count < 9) // If we see a Scarmiglione I...
							{
								monster.Add(212); // Add a Skullnant
								xpLimit -= allMonsters.Where(c => c.id == 212).First().exp;
								lastMonster = 212;
								j++;
							}
							else if (chosenMonster.id == 168) // If we see Baigan...
							{
								if (monster.Count < 8)
                                {
									monster.Add(169); // Add the arms!
									monster.Add(170);
									xpLimit -= allMonsters.Where(c => c.id == 169).First().exp;
									xpLimit -= allMonsters.Where(c => c.id == 170).First().exp;
									lastMonster = -1;
									j += 2;
								}
								else
								{
									lastMonster = -1;
									continue;
								}
							}
							else if (chosenMonster.id == 175) // If we see Cindy...
							{
								if (monster.Count < 8)
                                {
									monster.Add(174); // Add Sandy and Mindy!
									monster.Add(176);
									xpLimit -= allMonsters.Where(c => c.id == 176).First().exp;
									xpLimit -= allMonsters.Where(c => c.id == 174).First().exp;
									lastMonster = -1;
									j += 2;
								} 
								else
                                {
									lastMonster = -1;
									continue;
                                }
							}
							else if (chosenMonster.id == 181) // If we see Golbez...
							{
								if (monster.Count < 9)
								{
									monster.Add(182); // Add a Shadow Dragon
									xpLimit -= allMonsters.Where(c => c.id == 182).First().exp;
									lastMonster = -1;
									j += 1;
								}
								else
								{
									lastMonster = -1;
									continue;
								}
							}
							else if (chosenMonster.id == 198 && monster.Count < 8) // If we see CPU...
							{
								if (monster.Count < 8)
                                {
									monster.Add(199); // Add the attack and defense nodes!
									monster.Add(214);
									xpLimit -= allMonsters.Where(c => c.id == 199).First().exp;
									xpLimit -= allMonsters.Where(c => c.id == 214).First().exp;
									lastMonster = -1;
									j += 2;
								} else
                                {
									lastMonster = -1;
									continue;
                                }
							}
							else if (chosenMonster.id == 179 && monster.Count < 9) // If we see Calco...
							{
								monster.Add(211); // Add Brina!
								xpLimit -= allMonsters.Where(c => c.id == 211).First().exp;
								j++;
							}
							else if (chosenMonster.id == 211 && monster.Count < 9) // And if we see Brina...
							{
								monster.Add(179); // Add Calco!
								xpLimit -= allMonsters.Where(c => c.id == 179).First().exp;
								j++;
							}
							else if (chosenMonster.id == 150 && monster.Count < 9 && monster.Where(c => c == 150).Count() == 1) // If we see a Lunarsaur and it's the first one...
							{
								monster.Add(150); // Add another one!
								lastMonster = 150; // ... and allow the possibility of more.
								xpLimit -= allMonsters.Where(c => c.id == 150).First().exp;
								j++;
							}
							// Do not add 50/50 chance of duplicating a boss unless addressed above.  This will avoid something like 7 Odins or 7 Evil Walls.
							// ... unless you're in very hard difficulty... in which case you're on your own.  :P
							else if (allBosses.Contains(chosenMonster.id) && difficulty < 4)
							{
								lastMonster = -1;
							}
						}
						else
						{
							// No monsters left... usually because the xpLimit has gone below 0.  Invalidate the loop and move onto the next group.
							valid = false;
						}
					} else
					{
						bool normalDup = false;
						// Do not further duplicate monsters in easy, or very easy difficulty.
						if (xpLimit < 0 && difficulty < 2)
                        {
							valid = false;
							continue;
                        }
						// Allow one duplication of a monster in normal difficulty.
						if (xpLimit < 0 && difficulty == 2)
							normalDup = true;

						bool veryHard = true;
						while (veryHard)
                        {
							limitedMonsters monsterLimit = restrictedMonsters.Where(c => c.id == lastMonster).FirstOrDefault();
							if (monsterLimit != null)
							{
								if (monsterLimit.monsterLimit == 1)
									lastMonster = monsterLimit.followUp;
								if (lastMonster == -1)
									break;

								maxPercentHP += monsterLimit.hpPercentage;
								if (maxPercentHP > (difficulty <= 2 ? 50 : difficulty == 3 ? 60 : 75))
								{
									lastMonster = -1;
									break;
								}
							}

							monster.Add(lastMonster);
							j++;
							xpLimit -= lastXP;

							// If the XP remaining goes under zero, but you're in very hard difficulty,
							// keep repeating the monster until you reach 9 monsters,
							// unless we had to terminate via HP percentage monsters or had to follow up with a "-1" monster.
							if (xpLimit > 0 || difficulty < 4 || monster.Count >= 9 || lastMonster == -1)
								veryHard = false;
						}

						// In normal difficulty, now complete the group after the single duplication.
						if (normalDup)
							valid = false;
					}

					// Remove Scarmiglione if there's a monster stronger than that.
					if (monster.Contains(166) && allMonsters.Where(c => monster.Contains(c.id) && c.exp > 3000 && c.id != 166).Any())
					{
						monster.Remove(166);
						xpLimit += 3200;
					}
					// Remove Octomammoth if there's a monster stronger than that.
					if (monster.Contains(163) && allMonsters.Where(c => monster.Contains(c.id) && c.exp > 1200 && c.id != 163).Any())
                    {
						monster.Remove(163);
						xpLimit += 1200;
					}
					// CPU > Baigan
					if (monster.Contains(198) && monster.Contains(169))	{ monster.Remove(169); xpLimit += 10; }
					if (monster.Contains(198) && monster.Contains(168)) { monster.Remove(168); xpLimit += 4800; }
					if (monster.Contains(198) && monster.Contains(170)) { monster.Remove(170); xpLimit += 10; }
					// Dr. Lugae/Barnabas > Cindy/Mindy/Sandy > Scarmiglione
					if (monster.Contains(183) && monster.Contains(174))	{ monster.Remove(174); xpLimit += 2500; }
					if (monster.Contains(183) && monster.Contains(175))	{ monster.Remove(175); xpLimit += 2500; }
					if (monster.Contains(183) && monster.Contains(176))	{ monster.Remove(176); xpLimit += 2500; }
					if (monster.Contains(183) && monster.Contains(166))	{ monster.Remove(166); xpLimit += 3200; }
					if (monster.Contains(174) && monster.Contains(166))	{ monster.Remove(166); xpLimit += 3200; }
				}

				if (i == 150)
					monster = new List<int>() { 202 };

				if (i == 168)
					monster = new List<int>() { 87, 86, 87, 86, 87, 86 };
				if (i == 169)
					monster = new List<int>() { 196 };
				if (i == 170)
					monster = new List<int>() { 213 };
				if (i == 171)
					monster = new List<int>() { 195 };
				if (i == 172)
					monster = new List<int>() { 227 };
				if (i == 173)
					monster = new List<int>() { 228 };
				if (i == 174)
					monster = new List<int>() { 180 };

				singleGroup newGroup = new();
				newGroup.id = i == 151 ? 452
					: i == 152 ? 291
					: i == 153 ? 288
					: i == 154 ? 289
					: i == 155 ? 290
					: i == 156 ? 455
					: i == 157 ? 229
					: i == 158 ? 485
					: i == 159 ? 390
					: i == 160 ? 494
					: i == 161 ? 493
					: i == 162 ? 497
					: i == 163 ? 495
					: i == 164 ? 498
					: i == 165 ? 499
					: i == 166 ? 252
					: i == 167 ? 230
					: i == 168 ? 536
					: i == 169 ? 537
					: i == 170 ? 539
					: i == 171 ? 541
					: i == 172 ? 540
					: i == 173 ? 542
					: i == 174 ? 538 : i;
				newGroup.battle_background_asset_id = 1 + r1.Next() % 23;
				while (newGroup.battle_background_asset_id == 15)
					newGroup.battle_background_asset_id = 1 + r1.Next() % 23;
				// Baron Captain/General = Baron music
				if (monster.Contains(30) || monster.Contains(31) || monster.Contains(45) || monster.Contains(46) || monster.Contains(206))
					newGroup.battle_bgm_asset_id = 1;
				else if (monster.Contains(192)) // Demon Wall
					newGroup.battle_bgm_asset_id = 20;
				else if (monster.Contains(183) || monster.Contains(184) || monster.Contains(185) || monster.Contains(213) || monster.Contains(180) || monster.Contains(179) || monster.Contains(211))
					// Lugae / Calcobrena music
					newGroup.battle_bgm_asset_id = 35;
				else if (monster.Contains(181)) // Golbez
					newGroup.battle_bgm_asset_id = 22;
				else if (monster.Contains(173)) // Dark Elf
					newGroup.battle_bgm_asset_id = 17;
				else if (monster.Contains(205)) // Yang
					newGroup.battle_bgm_asset_id = 19;
				else if (monster.Contains(166) || monster.Contains(167) || monster.Contains(171) || monster.Contains(178) || monster.Contains(188) || monster.Contains(194) || monster.Contains(195) || monster.Contains(227) || monster.Contains(228))
					// Fiend music
					newGroup.battle_bgm_asset_id = 27;
				else if (monster.Contains(202)) // Zeromus - final battle
					newGroup.battle_bgm_asset_id = 42;
				else if ((i >= 141 && i <= 149) || i % 10 == 0 || allBosses.Where(c => monster.Contains(c)).Any()) // Regular boss music
					newGroup.battle_bgm_asset_id = 12;
				else // Regular battle music
					newGroup.battle_bgm_asset_id = 7;

				newGroup.appearance_production = 1;
				newGroup.script_name = 0;
				int attackMode = r1.Next() % 10;
				// Mandatory neutral fight if XP is greater than or equal to 100000/150000/250000...
				if (origXpLimit - xpLimit >= (difficulty <= 2 ? 100000 : difficulty == 3 ? 150000 : 250000)
					// ... or the HP percentage attacks of monsters exceed 20/35/50%...
					|| maxPercentHP > (difficulty <= 2 ? 20 : difficulty == 3 ? 35 : 50)
					// ... or it's the Zeromus fight
					|| monster.Contains(202))
					attackMode = 0;
				newGroup.battle_pattern1 = attackMode < 7 ? 1 : 0;
				newGroup.battle_pattern2 = attackMode == 7 ? 1 : 0; // Back Attack
				newGroup.battle_pattern3 = 0;
				newGroup.battle_pattern4 = 0;
				newGroup.battle_pattern5 = attackMode == 8 ? 1 : 0; // Preemptive fight
				newGroup.battle_pattern6 = attackMode == 9 ? 1 : 0; // Ambush
				newGroup.not_escape = 1;
				newGroup.battle_flag_group_id = monster.Contains(202) ? 7 : 0; // I think that will skip the XP gain screen in the final fight
				newGroup.get_value = 0;
				newGroup.get_ap = 0;

				if (monster.Count == 1) newGroup.monster5 = monster[0];
				else if (monster.Count == 4)
				{
					if (i % 10 == 0)
						newGroup.monster5 = monster[0];
					else
						newGroup.monster1 = monster[0];
					newGroup.monster9 = monster[1];
					newGroup.monster7 = monster[2];
					newGroup.monster3 = monster[3];
				}
				else
				{
					if (i % 10 == 0)
						newGroup.monster5 = monster[0];
					else
						newGroup.monster1 = monster[0];
					newGroup.monster9 = monster.Count >= 2 ? monster[1] : 0;
					if (i % 10 == 0)
						newGroup.monster1 = monster.Count >= 3 ? monster[2] : 0;
					else
						newGroup.monster5 = monster.Count >= 3 ? monster[2] : 0;
					newGroup.monster3 = monster.Count >= 4 ? monster[3] : 0;
					newGroup.monster7 = monster.Count >= 5 ? monster[4] : 0;
					newGroup.monster2 = monster.Count >= 6 ? monster[5] : 0;
					newGroup.monster4 = monster.Count >= 7 ? monster[6] : 0;
					newGroup.monster6 = monster.Count >= 8 ? monster[7] : 0;
					newGroup.monster8 = monster.Count >= 9 ? monster[8] : 0;
				}

				// Move Dark Elf to position 1; Dark Elf won't transform otherwise.  (in vanilla it would have to be position 5; an AI change moves it to position 1)
				monsterSwap(newGroup, 173, 1);

				// Move Octomammoth to position 4; it won't be defeated otherwise.  (in vanilla it would have to be position 5; an AI change moves it to position 4)
				monsterSwap(newGroup, 163, 4);

				// If Sandy/Cindy/Mindy is in this group, we'll want to swap them into monster 9/6/3.
				monsterSwap(newGroup, 174, 9);
				monsterSwap(newGroup, 175, 6);
				monsterSwap(newGroup, 176, 3);

				// If Scarmiglione I is in this group, we'll want to swap him into monster 9. (This has priority over Sandy.  If Scar is anywhere else, it becomes a "free battle".)
				monsterSwap(newGroup, 166, 9);

				// Dark Bahamut needs to be in position 5, or he won't reflect Flares..
				monsterSwap(newGroup, 153, 5);

				// If Baigan is in this group, we'll want to swap them into monster 8/5/2.
				monsterSwap(newGroup, 169, 8);
				monsterSwap(newGroup, 168, 5);
				monsterSwap(newGroup, 170, 2);

				// If Dr. Lugae/Balnab is in this group, we'll want to swap them into monster 9/6.
				monsterSwap(newGroup, 183, 9);
				monsterSwap(newGroup, 184, 6);

				// If CPU/Attack/Defense is in this group, we'll want to swap her into monster 8/5/2.
				monsterSwap(newGroup, 198, 8);
				monsterSwap(newGroup, 199, 5);
				monsterSwap(newGroup, 214, 2);

				newGroup.monster1_group = newGroup.monster2_group = newGroup.monster3_group = newGroup.monster4_group = newGroup.monster5_group = 
					newGroup.monster6_group = newGroup.monster7_group = newGroup.monster8_group = newGroup.monster9_group = 1;
				newGroup.monster1_x_position = 60;
				newGroup.monster2_x_position = 55;
				newGroup.monster3_x_position = 50;
				newGroup.monster4_x_position = 35;
				newGroup.monster5_x_position = 30;
				newGroup.monster6_x_position = 25;
				newGroup.monster7_x_position = 10;
				newGroup.monster8_x_position = 5;
				newGroup.monster9_x_position = 0;
				newGroup.monster1_y_position = newGroup.monster2_y_position = newGroup.monster3_y_position = newGroup.monster4_y_position = newGroup.monster5_y_position = 
					newGroup.monster6_y_position = newGroup.monster7_y_position = newGroup.monster8_y_position = newGroup.monster9_y_position = 0;

				if (newGroup.monster5 == 202)
                {
					newGroup.monster5_x_position = 0;
					newGroup.monster5_y_position = -10;
                }
				groups.Add(newGroup);
			}

			using (StreamWriter writer = new(Path.Combine(directory, "monster_party.csv")))
			using (CsvWriter csv = new(writer, System.Globalization.CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(groups);
			}

			foreach (singleMonster iMonster in allMonsters)
			{
				iMonster.exp = (int)(iMonster.exp * xpMultiplier);
				iMonster.exp += xpBoost;
				iMonster.gill = (int)(iMonster.gill * gpMultiplier / gpDivisor);
				iMonster.gill += gpBoost;
			}

			using (StreamWriter writer = new(Path.Combine(directory, "monster.csv")))
			using (CsvWriter csv = new(writer, System.Globalization.CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(allMonsters);
			}
		}

		private singleGroup monsterSwap(singleGroup newGroup, int monsterID, int newPosition)
        {
			int temp = 0;
			int oldPosition = 0;

			if (newGroup.monster1 == monsterID) oldPosition = 1;
			else if (newGroup.monster2 == monsterID) oldPosition = 2;
			else if (newGroup.monster3 == monsterID) oldPosition = 3;
			else if (newGroup.monster4 == monsterID) oldPosition = 4;
			else if (newGroup.monster5 == monsterID) oldPosition = 5;
			else if (newGroup.monster6 == monsterID) oldPosition = 6;
			else if (newGroup.monster7 == monsterID) oldPosition = 7;
			else if (newGroup.monster8 == monsterID) oldPosition = 8;
			else if (newGroup.monster9 == monsterID) oldPosition = 9;

			if (oldPosition != 0)
            {
				switch (newPosition)
				{
					case 1: temp = newGroup.monster1; newGroup.monster1 = monsterID; break;
					case 2: temp = newGroup.monster2; newGroup.monster2 = monsterID; break;
					case 3: temp = newGroup.monster3; newGroup.monster3 = monsterID; break;
					case 4: temp = newGroup.monster4; newGroup.monster4 = monsterID; break;
					case 5: temp = newGroup.monster5; newGroup.monster5 = monsterID; break;
					case 6: temp = newGroup.monster6; newGroup.monster6 = monsterID; break;
					case 7: temp = newGroup.monster7; newGroup.monster7 = monsterID; break;
					case 8: temp = newGroup.monster8; newGroup.monster8 = monsterID; break;
					case 9:	temp = newGroup.monster9; newGroup.monster9 = monsterID; break;
				}

				switch (oldPosition)
                {
					case 1: newGroup.monster1 = temp; break;
					case 2: newGroup.monster2 = temp; break;
					case 3: newGroup.monster3 = temp; break;
					case 4: newGroup.monster4 = temp; break;
					case 5: newGroup.monster5 = temp; break;
					case 6: newGroup.monster6 = temp; break;
					case 7: newGroup.monster7 = temp; break;
					case 8: newGroup.monster8 = temp; break;
					case 9: newGroup.monster9 = temp; break;
                }
			}

			return newGroup;
		}

		private bool randomizeZemusBreath(Random r1, List<singleMonster> allMonsters, List<limitedMonsters> restrictedMonsters, string directory)
        {
			// 24, 25, 76, 98, 106, 114, 116
			// 109, 113, 124, 125, 126, 133, 137
			int[] eligibleActions = new int[] 
				{ 1, 23, 33, 34, 35, 36, 37, 38, 39, 40, 41, 
					47, 48, 49, 51, 52, 54, 55, 56, 57, 
					58, 59, 61, 65, 66, 67, 68, 69, 71, 73, 
					75, 85, 86, 87, 88, 94, 95, 96, 99, 100, 
					101, 103, 106, 109, 111, 113, 114, 116, 118, 120, 
					122, 124, 125, 126, 127, 128, 133, 134, 135, 137, 138, 139,
					142, 144, 145, 148, 149, 150, 156, 163, 164, 165, 215, 233, 
					301, 302, 303, 347, 348, 352, 297, 442 };
			int[] magicPower = new int[]
				{ 99, 9, 99, 48, 12, 99, 48, 12, 99, 48, 12,
					99, 24, 99, 99, 5, 1, 8, 99, 13,
					8, 25, 99, 99, 25, 25, 25, 13, 51, 7,
					4, 13, 9, 7, 99, 5, 5, 99, 5, 99,
					99, 99, 99, 99, 99, 99, 99, 99, 99, 99,
					99, 99, 99, 99, 99, 51, 99, 51, 2, 99, 99, 99,
					3, 6, 13, 99, 1, 5, 17, 76, 99, 51, 99, 6,
					17, 17, 17, 8, 4, 8, 99, 99 };

			string json = File.ReadAllText(Path.Combine("Res", "Battle", "MonsterAI", "sc_ai_129_Zemus'sBreath.json"));
			MonsterAiJSON zemusBreath = JsonConvert.DeserializeObject<MonsterAiJSON>(json);
			foreach(var ev in zemusBreath.Mnemonics)
            {
				if (ev.mnemonic == "Act")
				{
					int i = r1.Next() % eligibleActions.Length;
					ev.operands.iValues[0] = eligibleActions[i];

					allMonsters[127].magic = magicPower[i];
					allMonsters[127].spirit = magicPower[i];
					allMonsters[127].intelligence = magicPower[i];

					if (new int[] { 113, 124, 125, 126, 133, 137 }.Contains(eligibleActions[i]))
						restrictedMonsters.Add(new limitedMonsters { id = 129, monsterLimit = 1, followUp = -1, hpPercentage = 50 });
					else
						restrictedMonsters.Add(new limitedMonsters { id = 129, monsterLimit = 1, followUp = -1 });
				}
			}

			JsonSerializer serializer = new();

			using StreamWriter sw = new(Path.Combine(directory, "..", "..", "Res", "Battle", "MonsterAI", "sc_ai_129_Zemus'sBreath.json"));
			using JsonWriter writer = new JsonTextWriter(sw);
			serializer.Serialize(writer, zemusBreath);

			return true;
        }
	}
}
