using CsvHelper;
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
			new List<int> { 97, 98, 39, 90, 26, 91, 148, 50, 60, 110, 100, 6, 102, 77, 106, 79, 99, 63, 134, 133, 95 }, // Eblan Area, Upper Babil (2 rounds)
			new List<int> { 119, 24, 18, 122, 116, 40, 103, 158, 143, 76, 70, 73, 75, 80, 92, 112, 120, 127, 142 }, // Cave Of Summons, other underground locations
			new List<int> { 140, 126, 85, 125, 96, 114, 152, 139, 147, 54, 141, 161, 144, 154, 131, 128, 107, 106, 112, 115, 127 }, // Bahamut Cave / Sylvan Cave / Lunar Overworld
			new List<int> { 138, 137, 111, 105, 146, 152, 139, 147, 54, 141, 161, 157, 156, 149, 82, 109 }, // Lunar Subterrane / Giant Of Babil
			new List<int> { 138, 137, 111, 105, 146, 152, 139, 147, 54, 141, 161, 157, 156, 149, 82, 141, 157, 111, 161, 160, 156, 145, 132, 189, 190, 155 }, // Lunar Subterrane Part 2 (2 rounds)
			new List<int> { 138, 137, 111, 105, 146, 152, 139, 147, 54, 141, 161, 157, 156, 149, 82, 141, 157, 111, 161, 160, 156, 145, 132, 189, 190, 155,
				162, 164, 165, 166, 167, 168, 171, 225, 175, 178, 179, 211, 185, 183, 184, 188, 189, 190, 193, 191, 192, 194, 198, 108, 150, 153, 159 } // Lunar Subterrane Part 2 (2 rounds)
		};

        readonly List<List<int>> monsterBosses = new()
        {
			new List<int> { 162, 31 }, // Outside Baron, Mist Cave, Mist/Kaipo
			new List<int> { 163, 31 }, // Underground Waterway / Damcyan
			new List<int> { 164, 165, 46 }, // Antlion Cave / Mt. Hobs / Fabul / Fabul Gauntlet
			new List<int> { 166, 167 }, // Mysidia, Mt. Ordeals
			new List<int> { 59, 168, 171, 173, 196 }, // Old Baron Waterway (or 173)
			new List<int> { }, // Magnes Cave
			new List<int> { 175, 178 }, // Troia / Zot Tower
			new List<int> { 179, 211, 185, 183, 184 }, // Dwarf Castle, Lower Babil
			new List<int> { }, // Eblan Area, Upper Babil (2 rounds)
			new List<int> { 188 }, // Eblan Area, Upper Babil (2 rounds)
			new List<int> { 189, 190, 193 }, // Cave Of Summons, other underground locations
			new List<int> { 189, 190, 193, 191 }, // Bahamut Cave / Sylvan Cave / Lunar Overworld
			new List<int> { 192, 194, 198 }, // Lunar Subterrane / Giant Of Babil
			new List<int> { 108, 150, 153, 159 }, // Lunar Subterrane Part 2  (2 rounds)
			new List<int> { 162, 164, 165, 166, 167, 168, 171, 225, 175, 178, 179, 211, 185, 183, 184, 188, 189, 190, 193, 191, 192, 194, 198, 108, 150, 153, 159 } // Lunar Subterrane Part 2  (2 rounds)
			// Final boss:  217
		};

        readonly List<int> allBosses = new()
        {
			162, 31, 164, 165, 46, 166, 167, 168, 171, 225, 175, 178, 179, 211, 185, 183, 184, 188, 189, 190, 193, 191, 192, 194, 198, 108, 150, 153, 159
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
			restrictedMonsters.Add(new limitedMonsters { id = 178, monsterLimit = 1, followUp = -1 }); // Barbariccia
			restrictedMonsters.Add(new limitedMonsters { id = 171, monsterLimit = 1, followUp = -1 }); // Cagnazzo
			restrictedMonsters.Add(new limitedMonsters { id = 173, monsterLimit = 1, followUp = -1 }); // Dark Elf
			restrictedMonsters.Add(new limitedMonsters { id = 153, monsterLimit = 1, followUp = -1 }); // Dark Bahamut - also put an HP percentage on that... Meganuke + HP percentage attack would be BRUTAL
			restrictedMonsters.Add(new limitedMonsters { id = 108, monsterLimit = 1, followUp = -1 }); // Plague
			restrictedMonsters.Add(new limitedMonsters { id = 156, monsterLimit = 2, followUp = -1 }); // Blue Dragon - 2 monster limit
			restrictedMonsters.Add(new limitedMonsters { id = 160, monsterLimit = 2, followUp = -1 }); // Red Dragon - 2 monster limit
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

			// Do not choose Mystery Eggs... they're going to softlock the game without some serious work. (224)
			// Do not also choose Golbez or the Shadow Dragons... that's just going to get screwy in a hurry. (177, 274, 181, 182)
			// No Zemus or Zeromus either for obvious reasons.  :) (200, 201, 202, 217)
			// No Dark Elves unless they transition to the Dark Dragon. (172, 225)
			// No Li'l Murderer's.  They wind up crashing the game with their mere existance, sadly. (33)
			// Let's avoid trap doors for now.  (124)
			// Remove the King and Queen of Eblan (186, 187)
			// Calcobrena cannot show up in a monster group.  (but the dolls can combine into Calcobrena) (180)
			// Do not include "character" fights (203, 204, 205, 206, 207)
			// Remove Barnabas-Z and Attack Node since they're worth 20 and 0 XP respectively; not appropriate for "non-area appropriate" flags. (212, 213)
			// Remove Zemus's Breath since they don't do anything except really slow down a battle.  (129)
			// Do not include the Edge Rubicante fight because it's scripted.  (226)
			List<int> badMonsters = new(){ 224, 177, 181, 274, 182, 200, 201, 202, 217, 172, 225, 33, 124, 186, 187, 180, 203, 204, 205, 206, 207, 212, 213, 129, 226 };

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
							else if (chosenMonster.id == 168 && monster.Count < 8) // If we see Baigan...
							{
								monster.Add(169); // Add the arms!
								monster.Add(170);
								xpLimit -= allMonsters.Where(c => c.id == 169).First().exp;
								xpLimit -= allMonsters.Where(c => c.id == 170).First().exp;
								lastMonster = -1;
								j += 2;
							}
							else if (chosenMonster.id == 175 && monster.Count < 8) // If we see Cindy...
							{
								monster.Add(174); // Add Sandy and Mindy!
								monster.Add(176);
								xpLimit -= allMonsters.Where(c => c.id == 176).First().exp;
								xpLimit -= allMonsters.Where(c => c.id == 174).First().exp;
								lastMonster = -1;
								j += 2;
							}
							else if (chosenMonster.id == 198 && monster.Count < 8) // If we see CPU...
							{
								monster.Add(199); // Add the attack and defense nodes!
								monster.Add(214);
								xpLimit -= allMonsters.Where(c => c.id == 199).First().exp;
								xpLimit -= allMonsters.Where(c => c.id == 214).First().exp;
								lastMonster = -1;
								j += 2;
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

								maxPercentHP += monsterLimit.hpPercentage;
								if (maxPercentHP > (difficulty <= 2 ? 50 : difficulty == 3 ? 60 : 75))
								{
									lastMonster = -1;
									continue;
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
				if (monster.Contains(30) || monster.Contains(31) || monster.Contains(45) || monster.Contains(46))
					newGroup.battle_bgm_asset_id = 1;
				else if (monster.Contains(165))
					// Mom Bomb music?
					newGroup.battle_bgm_asset_id = 13;
				else if (monster.Contains(183) || monster.Contains(184) || monster.Contains(185) || monster.Contains(213) || monster.Contains(180) || monster.Contains(179) || monster.Contains(211))
					// Lugae / Calcobrena music
					newGroup.battle_bgm_asset_id = 35;
				else if (monster.Contains(166) || monster.Contains(167) || monster.Contains(171) || monster.Contains(178) || monster.Contains(188) || monster.Contains(194) || monster.Contains(195) || monster.Contains(227) || monster.Contains(228))
					// Fiend music
					newGroup.battle_bgm_asset_id = 27;
				else if (monster.Contains(202)) // Zeromus - final battle
					newGroup.battle_bgm_asset_id = 42;
				else if ((i >= 141 && i <= 149) || i % 10 == 0) // Regular boss music
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

				// If Sandy is in this group, we'll want to swap her into monster 9.
				if (newGroup.monster1 == 174) { int temp = newGroup.monster9; newGroup.monster9 = 174; newGroup.monster1 = temp; }
				if (newGroup.monster2 == 174) { int temp = newGroup.monster9; newGroup.monster9 = 174; newGroup.monster2 = temp; }
				if (newGroup.monster3 == 174) { int temp = newGroup.monster9; newGroup.monster9 = 174; newGroup.monster3 = temp; }
				if (newGroup.monster4 == 174) { int temp = newGroup.monster9; newGroup.monster9 = 174; newGroup.monster4 = temp; }
				if (newGroup.monster5 == 174) { int temp = newGroup.monster9; newGroup.monster9 = 174; newGroup.monster5 = temp; }
				if (newGroup.monster6 == 174) { int temp = newGroup.monster9; newGroup.monster9 = 174; newGroup.monster6 = temp; }
				if (newGroup.monster7 == 174) { int temp = newGroup.monster9; newGroup.monster9 = 174; newGroup.monster7 = temp; }
				if (newGroup.monster8 == 174) { int temp = newGroup.monster9; newGroup.monster9 = 174; newGroup.monster8 = temp; }

				// If Cindy is in this group, we'll want to swap her into monster 6.
				if (newGroup.monster1 == 175) { int temp = newGroup.monster6; newGroup.monster6 = 175; newGroup.monster1 = temp; }
				if (newGroup.monster2 == 175) { int temp = newGroup.monster6; newGroup.monster6 = 175; newGroup.monster2 = temp; }
				if (newGroup.monster3 == 175) { int temp = newGroup.monster6; newGroup.monster6 = 175; newGroup.monster3 = temp; }
				if (newGroup.monster4 == 175) { int temp = newGroup.monster6; newGroup.monster6 = 175; newGroup.monster4 = temp; }
				if (newGroup.monster5 == 175) { int temp = newGroup.monster6; newGroup.monster6 = 175; newGroup.monster5 = temp; }
				if (newGroup.monster6 == 175) { int temp = newGroup.monster6; newGroup.monster6 = 175; newGroup.monster6 = temp; }
				if (newGroup.monster7 == 175) { int temp = newGroup.monster6; newGroup.monster6 = 175; newGroup.monster7 = temp; }
				if (newGroup.monster8 == 175) { int temp = newGroup.monster6; newGroup.monster6 = 175; newGroup.monster8 = temp; }

				// If Mindy is in this group, we'll want to swap her into monster 3.
				if (newGroup.monster1 == 176) { int temp = newGroup.monster3; newGroup.monster3 = 176; newGroup.monster1 = temp; }
				if (newGroup.monster2 == 176) { int temp = newGroup.monster3; newGroup.monster3 = 176; newGroup.monster2 = temp; }
				if (newGroup.monster3 == 176) { int temp = newGroup.monster3; newGroup.monster3 = 176; newGroup.monster3 = temp; }
				if (newGroup.monster4 == 176) { int temp = newGroup.monster3; newGroup.monster3 = 176; newGroup.monster4 = temp; }
				if (newGroup.monster5 == 176) { int temp = newGroup.monster3; newGroup.monster3 = 176; newGroup.monster5 = temp; }
				if (newGroup.monster6 == 176) { int temp = newGroup.monster3; newGroup.monster3 = 176; newGroup.monster6 = temp; }
				if (newGroup.monster7 == 176) { int temp = newGroup.monster3; newGroup.monster3 = 176; newGroup.monster7 = temp; }
				if (newGroup.monster8 == 176) { int temp = newGroup.monster3; newGroup.monster3 = 176; newGroup.monster8 = temp; }

				// If Scarmiglione I is in this group, we'll want to swap him into monster 9. (This has priority over Sandy.  If Scar is anywhere else, it becomes a "free battle".
				if (newGroup.monster1 == 166) { int temp = newGroup.monster9; newGroup.monster9 = 166; newGroup.monster1 = temp; }
				if (newGroup.monster2 == 166) { int temp = newGroup.monster9; newGroup.monster9 = 166; newGroup.monster2 = temp; }
				if (newGroup.monster3 == 166) { int temp = newGroup.monster9; newGroup.monster9 = 166; newGroup.monster3 = temp; }
				if (newGroup.monster4 == 166) { int temp = newGroup.monster9; newGroup.monster9 = 166; newGroup.monster4 = temp; }
				if (newGroup.monster5 == 166) { int temp = newGroup.monster9; newGroup.monster9 = 166; newGroup.monster5 = temp; }
				if (newGroup.monster6 == 166) { int temp = newGroup.monster9; newGroup.monster9 = 166; newGroup.monster6 = temp; }
				if (newGroup.monster7 == 166) { int temp = newGroup.monster9; newGroup.monster9 = 166; newGroup.monster7 = temp; }
				if (newGroup.monster8 == 166) { int temp = newGroup.monster9; newGroup.monster9 = 166; newGroup.monster8 = temp; }

				// Dark Bahamut needs to be in position 5, or he won't reflect Flares..
				if (newGroup.monster1 == 153) { int temp = newGroup.monster5; newGroup.monster5 = 153; newGroup.monster1 = temp; }
				if (newGroup.monster2 == 153) { int temp = newGroup.monster5; newGroup.monster5 = 153; newGroup.monster2 = temp; }
				if (newGroup.monster3 == 153) { int temp = newGroup.monster5; newGroup.monster5 = 153; newGroup.monster3 = temp; }
				if (newGroup.monster4 == 153) { int temp = newGroup.monster5; newGroup.monster5 = 153; newGroup.monster4 = temp; }
				if (newGroup.monster6 == 153) { int temp = newGroup.monster5; newGroup.monster5 = 153; newGroup.monster6 = temp; }
				if (newGroup.monster7 == 153) { int temp = newGroup.monster5; newGroup.monster5 = 153; newGroup.monster7 = temp; }
				if (newGroup.monster8 == 153) { int temp = newGroup.monster5; newGroup.monster5 = 153; newGroup.monster8 = temp; }
				if (newGroup.monster9 == 153) { int temp = newGroup.monster5; newGroup.monster5 = 153; newGroup.monster9 = temp; }

				// Move Zeromus to position 9.
				if (newGroup.monster5 == 202) { newGroup.monster5 = 0; newGroup.monster9 = 202; }

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
	}
}
