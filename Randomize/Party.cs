using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using FF4FabulGauntlet.Common;
using FF4FabulGauntlet.Inventory;
using Newtonsoft.Json;

namespace FF4FabulGauntlet.Randomize
{
	public class Party
	{
		private class character : ICloneable
		{
			public int id { get; set; }
			public int gender { get; set; }
			public int dominant_arm { get; set; }
			public int lv { get; set; }
			public int exp { get; set; }
			public int growth_curve_group_id { get; set; }
			public int job_id { get; set; }
			public string mes_id_name { get; set; }
			public int in_type_id { get; set; }
			public int hp { get; set; }
			public int mp { get; set; }
			public int magical_times1 { get; set; }
			public int magical_times2 { get; set; }
			public int magical_times3 { get; set; }
			public int magical_times4 { get; set; }
			public int magical_times5 { get; set; }
			public int magical_times6 { get; set; }
			public int magical_times7 { get; set; }
			public int magical_times8 { get; set; }
			public int strength { get; set; }
			public int vitality { get; set; }
			public int agility { get; set; }
			public int intelligence { get; set; }
			public int spirit { get; set; }
			public int magic { get; set; }
			public int luck { get; set; }
			public int attack { get; set; }
			public int defense { get; set; }
			public int accuracy_rate { get; set; }
			public int dodge_times { get; set; }
			public int evasion_rate { get; set; }
			public int ability_defense { get; set; }
			public int magic_evasion_rate { get; set; }
			public int corps { get; set; }
			public int command_id1 { get; set; } // Fight
			public int command_id2 { get; set; }
			public int command_id3 { get; set; }
			public int command_id4 { get; set; }
			public int command_id5 { get; set; }
			public int command_id6 { get; set; }
			public int content_id1 { get; set; }
			public int content_id2 { get; set; }
			public int content_id3 { get; set; }
			public int content_id4 { get; set; }
			public int content_id5 { get; set; }
			public int content_id6 { get; set; }
			public int ability_random_group_id { get; set; }
			public int initial_condition_group { get; set; }
			public int character_asset_id { get; set; }

			public object Clone()
			{
				return this.MemberwiseClone();
			}
		}

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

		public Party(Random r1, string directory, int numberOfBattles, bool duplicates, int numHeroes, bool noPromote, bool[] exclude)
		{
			List<character> records;

			using (StreamReader reader = new StreamReader(Path.Combine("csv", "character_status.csv")))
			using (CsvReader csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
				records = csv.GetRecords<character>().ToList();

			List<int> characters = new List<int>();
			if (duplicates)
			{
				for (int i = 0; i < 12; i++)
				{
					int charID = r1.Next() % 12 + 1; // Do not include "[paladin] cecil", ID 13
					if ((charID == dkCecil && !exclude[0]) ||
						(charID == kain && !exclude[1]) ||
						(charID == rydia && !exclude[2]) ||
						(charID == tellah && !exclude[3]) ||
						(charID == edward && !exclude[4]) ||
						(charID == rosa && !exclude[5]) ||
						(charID == yang && !exclude[6]) ||
						(charID == palom && !exclude[7]) ||
						(charID == porom && !exclude[8]) ||
						(charID == cid && !exclude[9]) ||
						(charID == edge && !exclude[10]) ||
						(charID == fusoya && !exclude[11]))
							characters.Add(charID);
					else 
						i--;  // redraw if a character is checked as excluded
				}
			} else
			{
				characters = new List<int> { dkCecil, kain, rydia, tellah, edward, rosa, yang, palom, porom, cid, edge, fusoya };
				if (exclude[0])	characters.Remove(dkCecil);
				if (exclude[1])	characters.Remove(kain);
				if (exclude[2])	characters.Remove(rydia);
				if (exclude[3])	characters.Remove(tellah);
				if (exclude[4])	characters.Remove(edward);
				if (exclude[5])	characters.Remove(rosa);
				if (exclude[6])	characters.Remove(yang);
				if (exclude[7])	characters.Remove(palom);
				if (exclude[8])	characters.Remove(porom);
				if (exclude[9])	characters.Remove(cid);
				if (exclude[10]) characters.Remove(edge);
				if (exclude[11]) characters.Remove(fusoya);
				characters.Shuffle(r1);
				while (characters.Count < 12)
					characters.Add(cecil);
			}
			// In case of Cecil promotions
			characters.Add(cecil); // Add this to make it the "13th character" - otherwise the "Cecil Career Change" SysCall doesn't work.
			characters[5] = characters[6] = characters[7] = characters[8] = cecil;

			int id = 1;
			List<character> newRecords = new List<character>();
			foreach (int singleChar in characters)
			{
				// Next two lines:  Prevents changes done to the single object as well as the list.
				var oldRecord = records.Where(c => c.id == singleChar).ToList()[0];
				var newRecord = (character)oldRecord.Clone();
				newRecord.id = id;
				newRecord.growth_curve_group_id = id;
				newRecords.Add(newRecord);
				id++;
			}

			using (StreamWriter writer = new StreamWriter(Path.Combine(directory, "..", "..", "Data", "Master", "character_status.csv")))
			using (CsvWriter csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(newRecords);
			}

			using (StreamWriter writer = new StreamWriter(Path.Combine(directory, "..", "..", "Data", "Master", "intermediate_growth_curve.csv")))
			{
				writer.WriteLine("id,character_id,job_id,growth_curve_group_id,exp_table_group_id");
				id = 1;
				int growthID;
				foreach (character record in newRecords)
				{
					growthID = record.job_id == 6 ? 1 : record.job_id == 3 ? 2 : record.job_id == 2 ? 3 : record.job_id == 7 ? 4 : record.job_id == 10 ? 5 :
						record.job_id == 8 ? 6 : record.job_id == 9 ? 7 : record.job_id == 11 ? 8 : record.job_id == 12 ? 9 : record.job_id == 13 ? 10 :
						record.job_id == 5 ? 11 : record.job_id == 14 ? 12 : record.job_id == 1 ? 13 : 4;
					writer.WriteLine(id.ToString().Trim() + "," + id.ToString().Trim() + "," + record.job_id.ToString().Trim() + "," + growthID.ToString().Trim() + "," + growthID.ToString().Trim());
					id++;
				}
			}

			string json = File.ReadAllText(Path.Combine(directory, "Map_10010", "Map_10010", "sc_e_0001.json"));
			EventJSON jEvents = JsonConvert.DeserializeObject<EventJSON>(json);
			int j = 0;
			foreach (var singleScript in jEvents.Mnemonics)
			{
				if (singleScript.mnemonic == "Wait" || singleScript.mnemonic == "SysCall")
				{
					switch (j)
					{
						case 0:
							if (numHeroes >= 2)
                            {
								singleScript.mnemonic = "SysCall";
								singleScript.operands.rValues[0] = 0;
								singleScript.operands.sValues[0] = "カイン加入"; // Add Kain (ID 2)
							} 
							else
                            {
								singleScript.mnemonic = "Wait";
								singleScript.operands.rValues[0] = 0.1f;
								singleScript.operands.sValues[0] = "";
							}
							break;
						case 1:
							if (numHeroes >= 3)
							{
								singleScript.mnemonic = "SysCall";
								singleScript.operands.rValues[0] = 0;
								singleScript.operands.sValues[0] = "ローザ加入"; // Add Rosa (ID 3)
							}
							else
							{
								singleScript.mnemonic = "Wait";
								singleScript.operands.rValues[0] = 0.1f;
								singleScript.operands.sValues[0] = "";
							}
							break;
						case 2:
							if (numHeroes >= 4)
							{
								singleScript.mnemonic = "SysCall";
								singleScript.operands.rValues[0] = 0;
								singleScript.operands.sValues[0] = "リディア加入"; // Add Rydia (ID 4)
							}
							else
							{
								singleScript.mnemonic = "Wait";
								singleScript.operands.rValues[0] = 0.1f;
								singleScript.operands.sValues[0] = "";
							}
							break;
						case 3:
							if (numHeroes == 5)
							{
								singleScript.mnemonic = "SysCall";
								singleScript.operands.rValues[0] = 0;
								singleScript.operands.sValues[0] = "シド加入"; // Add Cid (ID 5)
							}
							else
							{
								singleScript.mnemonic = "Wait";
								singleScript.operands.rValues[0] = 0.1f;
								singleScript.operands.sValues[0] = "";
							}
							break;
						default:
							singleScript.mnemonic = "Wait";
							singleScript.operands.rValues[0] = 0.1f;
							singleScript.operands.sValues[0] = "";
							break;
					}

					j++;
				}
				else if (singleScript.mnemonic == "SetFlag" || singleScript.mnemonic == "ResetFlag")
				{
					// Set initial flags
					if (singleScript.operands.iValues[0] == 1001)
						singleScript.mnemonic = numberOfBattles <= 5 ? "SetFlag" : "ResetFlag";
					if (singleScript.operands.iValues[0] == 1002)
						singleScript.mnemonic = numberOfBattles <= 7 ? "SetFlag" : "ResetFlag";
					if (singleScript.operands.iValues[0] == 1003)
						singleScript.mnemonic = numberOfBattles <= 9 ? "SetFlag" : "ResetFlag";
					if (singleScript.operands.iValues[0] == 1004)
						singleScript.mnemonic = numberOfBattles <= 3 ? "SetFlag" : "ResetFlag";
					if (singleScript.operands.iValues[0] == 1005)
						singleScript.mnemonic = numberOfBattles <= 1 ? "SetFlag" : "ResetFlag";
					if (singleScript.operands.iValues[0] == 1006)
						singleScript.mnemonic = numberOfBattles <= 6 ? "SetFlag" : "ResetFlag";
					if (singleScript.operands.iValues[0] == 1007)
						singleScript.mnemonic = numberOfBattles <= 8 ? "SetFlag" : "ResetFlag";
					if (singleScript.operands.iValues[0] == 1008)
						singleScript.mnemonic = numberOfBattles <= 4 ? "SetFlag" : "ResetFlag";
					if (singleScript.operands.iValues[0] == 1009)
						singleScript.mnemonic = numberOfBattles <= 2 ? "SetFlag" : "ResetFlag";
				}
			}

			JsonSerializer serializer = new JsonSerializer();

			using (StreamWriter sw = new StreamWriter(Path.Combine(directory, "Map_10010", "Map_10010", "sc_e_0001.json")))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, jEvents);
			}


			// Then we're going to need to revert the ResetFlags to SetFlags for all of the encounters
			List<string> battleScripts = new List<string>
				{
					Path.Combine(directory, "Map_20011", "Map_20011_1", "sc_e_0001_8.json"),
					Path.Combine(directory, "Map_20011", "Map_20011_5", "sc_e_0002.json"),
					Path.Combine(directory, "Map_30011", "Map_30011_1", "sc_e_0007.json"),
					Path.Combine(directory, "Map_30011", "Map_30011_1", "sc_e_0007_1.json"),
					Path.Combine(directory, "Map_30021", "Map_30021_10", "sc_e_0014_1.json"),
					Path.Combine(directory, "Map_30060", "Map_30060", "sc_e_0020.json"),
					Path.Combine(directory, "Map_30110", "Map_30110", "sc_e_0027.json"),
					Path.Combine(directory, "Map_30131", "Map_30131_1", "sc_e_0036.json"),
					Path.Combine(directory, "Map_30141", "Map_30141_5", "sc_e_0041_1.json"),
					Path.Combine(directory, "Map_30151", "Map_30151_16", "sc_e_0051.json"),
					Path.Combine(directory, "Map_30161", "Map_30161_3", "sc_e_0055.json"),
					Path.Combine(directory, "Map_30171", "Map_30171_6", "sc_e_0056.json"),
					Path.Combine(directory, "Map_30191", "Map_30191_1", "sc_e_0119.json"),
					Path.Combine(directory, "Map_30221", "Map_30221_2", "sc_e_0122.json"),
					Path.Combine(directory, "Map_30251", "Map_30251_22", "sc_e_0074_1.json"),
					Path.Combine(directory, "Map_30251", "Map_30251_22", "sc_e_0074_2.json"),
					Path.Combine(directory, "Map_30251", "Map_30251_22", "sc_e_0074_4.json")
				};

			foreach (string script in battleScripts)
			{
				string json3 = File.ReadAllText(script);
				EventJSON jEvents3 = JsonConvert.DeserializeObject<EventJSON>(json3);
				int l = 0;
				foreach (var singleScript in jEvents3.Mnemonics)
				{
					if ((singleScript.mnemonic == "SetFlag" || singleScript.mnemonic == "ResetFlag") && l >= 50)
					{
						// Set initial flags
						if (singleScript.operands.iValues[0] == 1001)
							singleScript.mnemonic = numberOfBattles > 5 ? "ResetFlag" : "SetFlag";
						if (singleScript.operands.iValues[0] == 1002)
							singleScript.mnemonic = numberOfBattles > 7 ? "ResetFlag" : "SetFlag";
						if (singleScript.operands.iValues[0] == 1003)
							singleScript.mnemonic = numberOfBattles > 9 ? "ResetFlag" : "SetFlag";
						if (singleScript.operands.iValues[0] == 1004)
							singleScript.mnemonic = numberOfBattles > 3 ? "ResetFlag" : "SetFlag";
						if (singleScript.operands.iValues[0] == 1005)
							singleScript.mnemonic = numberOfBattles > 1 ? "ResetFlag" : "SetFlag";
						if (singleScript.operands.iValues[0] == 1006)
							singleScript.mnemonic = numberOfBattles > 6 ? "ResetFlag" : "SetFlag";
						if (singleScript.operands.iValues[0] == 1007)
							singleScript.mnemonic = numberOfBattles > 8 ? "ResetFlag" : "SetFlag";
						if (singleScript.operands.iValues[0] == 1008)
							singleScript.mnemonic = numberOfBattles > 4 ? "ResetFlag" : "SetFlag";
						if (singleScript.operands.iValues[0] == 1009)
							singleScript.mnemonic = numberOfBattles > 2 ? "ResetFlag" : "SetFlag";
					}
					l++;
				}

				JsonSerializer serializer3 = new JsonSerializer();

				using (StreamWriter sw = new StreamWriter(script))
				using (JsonWriter writer = new JsonTextWriter(sw))
				{
					serializer3.Serialize(writer, jEvents3);
				}
			}

			// Mt. Ordeals - promote all Cecils to Paladins
			string json2 = File.ReadAllText(Path.Combine(directory, "Map_30110", "Map_30110", "sc_e_0029.json"));
			EventJSON jEvents2 = JsonConvert.DeserializeObject<EventJSON>(json2);
			int k = 0;
			foreach (var singleScript in jEvents2.Mnemonics)
			{
				if (singleScript.mnemonic == "Wait" || singleScript.mnemonic == "SysCall")
				{
					switch (k)
					{
						case 0:
							singleScript.mnemonic = characters[0] == dkCecil && !noPromote ? "SysCall" : "Wait";
							singleScript.operands.rValues[0] = characters[0] == dkCecil && !noPromote ? 0.0f : 0.1f;
							singleScript.operands.sValues[0] = characters[0] == dkCecil && !noPromote ? "セシル転職" : ""; // Cecil promotion
							break;
						case 1:
							singleScript.mnemonic = characters[1] == dkCecil && !noPromote && numHeroes >= 2 ? "SysCall" : "Wait";
							singleScript.operands.rValues[0] = characters[1] == dkCecil && !noPromote && numHeroes >= 2 ? 0.0f : 0.1f;
							singleScript.operands.sValues[0] = characters[1] == dkCecil && !noPromote && numHeroes >= 2 ? "カイン離脱" : ""; // Drop "Kain"
							break;
						case 2:
							singleScript.mnemonic = characters[1] == dkCecil && !noPromote && numHeroes >= 2 ? "SysCall" : "Wait";
							singleScript.operands.rValues[0] = characters[1] == dkCecil && !noPromote && numHeroes >= 2 ? 0.0f : 0.1f;
							singleScript.operands.sValues[0] = characters[1] == dkCecil && !noPromote && numHeroes >= 2 ? "テラ加入" : ""; // Add "Tellah"
							break;
						case 3:
							singleScript.mnemonic = characters[2] == dkCecil && !noPromote && numHeroes >= 3 ? "SysCall" : "Wait";
							singleScript.operands.rValues[0] = characters[2] == dkCecil && !noPromote && numHeroes >= 3 ? 0.0f : 0.1f;
							singleScript.operands.sValues[0] = characters[2] == dkCecil && !noPromote && numHeroes >= 3 ? "ローザ離脱" : ""; // Drop "Rosa"
							break;
						case 4:
							singleScript.mnemonic = characters[2] == dkCecil && !noPromote && numHeroes >= 3 ? "SysCall" : "Wait";
							singleScript.operands.rValues[0] = characters[2] == dkCecil && !noPromote && numHeroes >= 3 ? 0.0f : 0.1f;
							singleScript.operands.sValues[0] = characters[2] == dkCecil && !noPromote && numHeroes >= 3 ? "ギルバート加入" : ""; // Add "Edward"
							break;
						case 5:
							singleScript.mnemonic = characters[3] == dkCecil && !noPromote && numHeroes >= 4 ? "SysCall" : "Wait";
							singleScript.operands.rValues[0] = characters[3] == dkCecil && !noPromote && numHeroes >= 4 ? 0.0f : 0.1f;
							singleScript.operands.sValues[0] = characters[3] == dkCecil && !noPromote && numHeroes >= 4 ? "リディア離脱" : ""; // Drop "Rydia"
							break;
						case 6:
							singleScript.mnemonic = characters[3] == dkCecil && !noPromote && numHeroes >= 4 ? "SysCall" : "Wait";
							singleScript.operands.rValues[0] = characters[3] == dkCecil && !noPromote && numHeroes >= 4 ? 0.0f : 0.1f;
							singleScript.operands.sValues[0] = characters[3] == dkCecil && !noPromote && numHeroes >= 4 ? "ヤン加入" : ""; // Add "Yang"
							break;
						case 7:
							singleScript.mnemonic = characters[4] == dkCecil && !noPromote && numHeroes == 5 ? "SysCall" : "Wait";
							singleScript.operands.rValues[0] = characters[4] == dkCecil && !noPromote && numHeroes == 5 ? 0.0f : 0.1f;
							singleScript.operands.sValues[0] = characters[4] == dkCecil && !noPromote && numHeroes == 5 ? "シド離脱" : ""; // Drop "Cid"
							break;
						case 8:
							singleScript.mnemonic = characters[4] == dkCecil && !noPromote && numHeroes == 5 ? "SysCall" : "Wait";
							singleScript.operands.rValues[0] = characters[4] == dkCecil && !noPromote && numHeroes == 5 ? 0.0f : 0.1f;
							singleScript.operands.sValues[0] = characters[4] == dkCecil && !noPromote && numHeroes == 5 ? "パロム加入" : ""; // Add "Palom"
							break;
					}
					k++;
				}
			}

			serializer = new JsonSerializer();

			using (StreamWriter sw = new StreamWriter(Path.Combine(directory, "Map_30110", "Map_30110", "sc_e_0029.json")))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, jEvents2);
			}
		}
	}
}
