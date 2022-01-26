using FF4FabulGauntlet.Inventory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF4FabulGauntlet.Randomize
{
	public class Treasure
	{
		public Treasure(Random r1, int randoLevel, string directory, bool noJItems, bool noSuper, bool includeBonus)
		{
			List<string> treasureDirectories = new()
			{
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
				Path.Combine(directory, "Map_30251")
			};

			List<int> stdMaxTier = new()
			{
				3, 3, 4, 3, 4, 
				4, 3, 4, 4, 4, 
				4, 5, 5, 6, 6, 
				6, 6, 7, 7, 7, 
				8
			};

			List<int> proMaxTier = new()
			{
				2, 2, 3, 2, 3,
				3, 2, 3, 3, 3, 
				3, 4, 4, 5, 5, 
				5, 6, 6, 6, 6, 
				7
			};

			List<string> Booster1 = new()
			{
				"Map_20071_4",
				"Map_30021_2",
				"Map_30121_1"
			};

			int i = 0;

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
								// No super-items unless you're in the Lunar Subterranne
								trMaxTier = Math.Min(!noSuper ? 9 : 8, trMaxTier);
								trMinTier = Math.Min(8, trMinTier);
								int trType = gold ? 0 : r1.Next() % 12;
								int finalType = 0;
								if (monster) // Only weapons and armor in monster chests
									finalType = (r1.Next() % 2) + 2;
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
										prop.value = new Weapons().selectItem(r1, trMinTier, trMaxTier, false, includeBonus);
									foreach (var prop in sObject.properties.Where(c => c.name == "content_num"))
										prop.value = 1;
									foreach (var prop in sObject.properties.Where(c => c.name == "message_key"))
										prop.value = "S0005_999_a_02";
								}
								else
								{
									foreach (var prop in sObject.properties.Where(c => c.name == "content_id"))
										prop.value = new Armor().selectItem(r1, trMinTier, trMaxTier, false);
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
		}
	}
}