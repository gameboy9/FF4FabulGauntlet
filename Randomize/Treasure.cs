using FF4FabulGauntlet.Inventory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace FF4FabulGauntlet.Randomize
{
	public class Treasure
	{
		private class message
		{
			[Index(0)]
			public string id { get; set; }
			[Index(1)]
			public string msgString { get; set; }
		}

		public Treasure(Random r1, int randoLevel, string directory, string csvDirectory, bool noJItems, bool noSuper, bool includeBonus, bool includeFGExclusive, int[] party)
		{
			List<string> treasureDirectories = new()
			{
				Path.Combine(directory, "Map_20020"),
				Path.Combine(directory, "Map_20021"),
				Path.Combine(directory, "Map_30011"),
				Path.Combine(directory, "Map_20071"),
				Path.Combine(directory, "Map_20070"),
				Path.Combine(directory, "Map_30021"), //
				Path.Combine(directory, "Map_30050"),
				Path.Combine(directory, "Map_30060"),
				Path.Combine(directory, "Map_30080"),
				Path.Combine(directory, "Map_30100"),
				Path.Combine(directory, "Map_30121"), //
				Path.Combine(directory, "Map_20011"),
				Path.Combine(directory, "Map_30131"),
				Path.Combine(directory, "Map_30141"),
				Path.Combine(directory, "Map_20151"),
				Path.Combine(directory, "Map_30151"), //
				Path.Combine(directory, "Map_30161"),
				Path.Combine(directory, "Map_20131"),
				Path.Combine(directory, "Map_30171"),
				Path.Combine(directory, "Map_30191"),
				Path.Combine(directory, "Map_30221"), //
				Path.Combine(directory, "Map_30251"),
				Path.Combine(directory, "Map_20111")
			};

			List<int> stdMaxTier = new()
			{
				2,
				3,
				3,
				4,
				3,
				4, //
				4,
				3,
				4,
				4,
				4, //
				4,
				5,
				5,
				6,
				6, //
				6,
				6,
				7,
				7,
				7, //
				8,
				-1
			};

			List<int> proMaxTier = new()
			{
				1,
				2,
				2,
				3,
				2,
				3, //
				3,
				2,
				3,
				3,
				3, //
				3,
				4,
				4,
				5,
				5, //
				5,
				6,
				6,
				6,
				6, //
				7,
				-1
			};

			List<string> Booster1 = new()
			{
				"Map_20071_4",
				"Map_30021_2",
				"Map_30121_1"
			};

			int i = 0;

			int rttType = 0;
			int rttTier = RateThatTreasury(r1, ref rttType);

			foreach (string tDir in treasureDirectories)
			{
				foreach (string fileName in Directory.EnumerateFiles(tDir, "entity_default.json", SearchOption.AllDirectories))
				{
					string json = File.ReadAllText(fileName);
					EntityJSON jEvents = JsonConvert.DeserializeObject<EntityJSON>(json);
					foreach (var layer in jEvents.layers)
						foreach (var sObject in layer.objects)
						{
							bool process = sObject.properties.Where(c => c.name == "action_id" && (long)c.value == 6).Any();
							bool monster = sObject.properties.Where(c => c.name == "script_id" && (long)c.value != 0).Any();
							bool gold = false;
							if (fileName.Contains("Map_20021_7"))
								gold = sObject.properties.Where(c => c.name == "content_id" && (long)c.value == 1).Any();
							if (process)
							{
								int trMaxTier = (randoLevel == 0 ? stdMaxTier[i] :
												randoLevel == 1 ? proMaxTier[i] :
												noSuper ? 8 : 9) + (monster ? 2 : 0);
								trMaxTier += fileName.Contains(Booster1[0]) ? 1 : 0;
								trMaxTier += fileName.Contains(Booster1[1]) ? 1 : 0;
								trMaxTier += fileName.Contains(Booster1[2]) ? 1 : 0;

								int trMinTier = Math.Max(1, randoLevel == 2 ? 1 : trMaxTier - 2);
								trMaxTier = Math.Min(!noSuper ? 9 : 8, trMaxTier);
								trMinTier = Math.Min(8, trMinTier);

								if (fileName.Contains("Map_30251_17"))
								{
									trMaxTier = trMinTier = 9;
									monster = true;
								}

								if (fileName.Contains("Map_20111"))
                                {
									trMaxTier = rttTier;
									trMinTier = trMaxTier == 9 ? 8 : rttTier;
                                }

								int trType = gold ? 0 : r1.Next() % 12;
								int finalType = 0;
								if (monster) // Only weapons and armor in monster chests
									finalType = (r1.Next() % 2) + 2;
								else if (fileName.Contains("Map_20111") && rttType != 4)
									finalType = rttType;
								else
									finalType = trType == 0 ? 0 : trType >= 1 && trType <= 5 ? 1 : trType >= 6 && trType <= 8 ? 2 : 3;

								if (finalType == 0)
								{
									foreach (var prop in sObject.properties.Where(c => c.name == "content_id"))
										prop.value = 1;
									foreach (var prop in sObject.properties.Where(c => c.name == "content_num"))
										prop.value = (r1.Next() % (500 * trMaxTier)) + (500 * Math.Max(0, trMaxTier - 4)) + (gold ? 500 : 0);
									foreach (var prop in sObject.properties.Where(c => c.name == "message_key"))
										prop.value = "S0005_999_a_03";
								}
								else if (finalType == 1)
								{
									foreach (var prop in sObject.properties.Where(c => c.name == "content_id"))
										prop.value = new Items().selectItem(r1, trMinTier, trMaxTier, false, noJItems);
									foreach (var prop in sObject.properties.Where(c => c.name == "content_num"))
										prop.value = 1;
									foreach (var prop in sObject.properties.Where(c => c.name == "message_key"))
										prop.value = "S0005_999_a_02";
								}
								else if (finalType == 2)
								{
									foreach (var prop in sObject.properties.Where(c => c.name == "content_id"))
										prop.value = new Weapons().selectItem(r1, trMinTier, trMaxTier, false, includeBonus, includeFGExclusive, party);
									foreach (var prop in sObject.properties.Where(c => c.name == "content_num"))
										prop.value = 1;
									foreach (var prop in sObject.properties.Where(c => c.name == "message_key"))
										prop.value = "S0005_999_a_02";
								}
								else
								{
									foreach (var prop in sObject.properties.Where(c => c.name == "content_id"))
										prop.value = new Armor().selectItem(r1, trMinTier, trMaxTier, false, includeBonus, includeFGExclusive, party);
									foreach (var prop in sObject.properties.Where(c => c.name == "content_num"))
										prop.value = 1;
									foreach (var prop in sObject.properties.Where(c => c.name == "message_key"))
										prop.value = "S0005_999_a_02";
								}
							}
						}

					JsonSerializer serializer = new();

					using StreamWriter sw = new(fileName);
					using JsonWriter writer = new JsonTextWriter(sw);
					serializer.Serialize(writer, jEvents);
				}
				i++;
			}

			string[] CSVs = new string[] { "story_mes_de.txt", "story_mes_en.txt", "story_mes_es.txt", "story_mes_fr.txt", "story_mes_it.txt", "story_mes_ja.txt", "story_mes_ko.txt", "story_mes_pt.txt", "story_mes_ru.txt", "story_mes_th.txt", "story_mes_zhc.txt", "story_mes_zht.txt" };
			List<int> finalItems = new List<int>();

			// Now we need to cycle through the four super item scripts and place treasures in there.  We also will have to update the text accordingly.
			string[] scripts = new string[] { "Map_30251_18\\sc_e_0115_1.json", "Map_30251_16\\sc_e_0114_1.json", "Map_30251_7\\sc_e_0117_1.json", "Map_30251_3\\sc_e_0116_1.json" };
			foreach (string script in scripts)
			{
				string json = File.ReadAllText(Path.Combine(directory, "Map_30251", script));
				EventJSON jEvents = JsonConvert.DeserializeObject<EventJSON>(json);
				foreach (var singleScript in jEvents.Mnemonics)
				{
					if (singleScript.mnemonic == "GetItem")
					{
						int finalType = (r1.Next() % 2) + 2;
						int finalItem = -1;

						if (finalType == 2)
						{
							finalItem = new Weapons().selectItem(r1, 9, 9, false, includeBonus, includeFGExclusive, party);
						}
						else
						{
							finalItem = new Armor().selectItem(r1, 9, 9, false, includeBonus, includeFGExclusive, party);
						}
						singleScript.operands.iValues[0] = finalItem;
						singleScript.operands.iValues[1] = 1;
						finalItems.Add(finalItem);
					}
				}

				JsonSerializer serializer = new JsonSerializer();

				using (StreamWriter sw = new StreamWriter(Path.Combine(directory, "Map_30251", script)))
				using (JsonWriter writer = new JsonTextWriter(sw))
				{
					serializer.Serialize(writer, jEvents);
				}
			}


			foreach (string CSV in CSVs)
			{
				List<message> records = new List<message>();
				using (StreamReader reader = new StreamReader(Path.Combine("Data", "Message", CSV)))
				{
					CsvHelper.Configuration.CsvConfiguration config = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
					config.Delimiter = "\t";
					config.HasHeaderRecord = false;
					config.BadDataFound = null;

					using (CsvReader csv = new CsvReader(reader, config))
						records = csv.GetRecords<message>().ToList();
				}

				foreach (string script in scripts)
                {
					message record;
					int finalItem;
					if (script == "Map_30251_3\\sc_e_0116_1.json")
                    {
						record = records.Where(c => c.id == "E0116_01_298_a_01").Single();
						finalItem = finalItems[3];
					}
					else if (script == "Map_30251_7\\sc_e_0117_1.json")
                    {
						record = records.Where(c => c.id == "E0117_01_302_a_01").Single();
						finalItem = finalItems[2];
					}
					else if (script == "Map_30251_16\\sc_e_0114_1.json")
                    {
						record = records.Where(c => c.id == "E0114_01_311_a_01").Single();
						finalItem = finalItems[1];
					}
					else
                    {
						record = records.Where(c => c.id == "E0115_00_313_a_02").Single();
						finalItem = finalItems[0];
					}

					record.msgString = "You found " + itemLookup(finalItem) + "!";
				}

				using (StreamWriter writer = new StreamWriter(Path.Combine(csvDirectory, CSV)))
				{
					CsvHelper.Configuration.CsvConfiguration config = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
					config.Delimiter = "\t";
					config.HasHeaderRecord = false;

					using (CsvWriter csv = new CsvWriter(writer, config))
						csv.WriteRecords(records);
				}
			}
		}

		private int RateThatTreasury(Random r1, ref int type)
        {
			type = r1.Next() % 8;
			if (type >= 4) type = 4;
			int rnd = r1.Next() % 511;
			return (rnd == 0 ? 9 :
					rnd <= 2 ? 8 :
					rnd <= 6 ? 7 :
					rnd <= 14 ? 6 :
					rnd <= 30 ? 5 :
					rnd <= 62 ? 4 :
					rnd <= 126 ? 3 :
					rnd <= 254 ? 2 : 1);
        }

		private string itemLookup(int finalItem)
		{
			if (finalItem == 159) return "Knife";
			else if (finalItem == 801) return "Lightbringer";
			else if (finalItem == 803) return "Abel's Lance";
			else if (finalItem == 804) return "Gigant Axe";
			else if (finalItem == 805) return "Perseus Bow";
			else if (finalItem == 806) return "Perseus Arrow";
			else if (finalItem == 809) return "Assassin Dagger";
			else if (finalItem == 810) return "Sasuke's Katana";
			else if (finalItem == 811) return "Mutsunokami";
			else if (finalItem == 816) return "Godhand";
			else if (finalItem == 818) return "Fiery Hammer";
			else if (finalItem == 819) return "Asura Rod";
			else if (finalItem == 821) return "Nirvana";
			else if (finalItem == 823) return "Requiem Harp";
			else if (finalItem == 824) return "Loki Harp";
			else if (finalItem == 828) return "Megido Sword";
			else if (finalItem == 865) return "Vampire Spear";

			else if (finalItem == 288) return "Adamant Armor";
			else if (finalItem == 832) return "Caesar's Plate";
			else if (finalItem == 833) return "Maximillian";
			else if (finalItem == 838) return "Battle Gear";
			else if (finalItem == 839) return "Assassin Vest";
			else if (finalItem == 840) return "Vishnu Vest";
			else if (finalItem == 841) return "Sage Robe";
			else if (finalItem == 842) return "Robe Of Lords";
			else if (finalItem == 843) return "Rainbow Robe";
			else if (finalItem == 844) return "White Dress";
			else if (finalItem == 845) return "Hero Shield";
			else if (finalItem == 851) return "Rabbit-Ear Hood";
			else if (finalItem == 852) return "Augustine Tiara";
			else if (finalItem == 853) return "Star of Kami Kazari";
			else if (finalItem == 854) return "Royal Crown";
			else if (finalItem == 855) return "Dual Mask";
			else if (finalItem == 856) return "Demon Hat";
			else if (finalItem == 857) return "Philosopher's Hat";
			else if (finalItem == 858) return "Grand Helm";
			else if (finalItem == 859) return "Caesar Helm";
			else if (finalItem == 860) return "Dragoon Helm";
			else if (finalItem == 861) return "Edge Demon Helm";
			else if (finalItem == 862) return "Safety Met";

			return "";
		}
	}
}