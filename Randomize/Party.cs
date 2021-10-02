using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF4FabulGauntlet.Common;
using FF4FabulGauntlet.Inventory;
using Newtonsoft.Json;

namespace FF4FabulGauntlet.Randomize
{
	public class Party
	{
		const int dkCecil = 0;
		const int cecil = 1;
		const int kain = 2;
		const int rydia = 3;
		const int tellah = 4;
		const int edward = 5;
		const int rosa = 6;
		const int yang = 7;
		const int palom = 8;
		const int porom = 9;
		const int cid = 10;
		const int edge = 11;
		const int fusoya = 12;

		public Party(Random r1, string directory, int numberOfBattles)
		{
			List<int> characters = new List<int> { kain, rydia, tellah, edward, rosa, yang, palom, porom, cid, edge, fusoya };
			characters.Shuffle(r1);

			// Remove the last seven characters off the list.
			while (characters.Count() > 4)
				characters.RemoveAt(4);

			string json = File.ReadAllText(Path.Combine(directory, "Map_10010", "Map_10010", "sc_e_0001.json"));
			EventJSON jEvents = JsonConvert.DeserializeObject<EventJSON>(json);
			int j = 0;
			foreach (var singleScript in jEvents.Mnemonics)
			{
				if (singleScript.mnemonic == "Wait" || singleScript.mnemonic == "SysCall")
				{
					if (j >= 4)
					{
						singleScript.mnemonic = "Wait";
						singleScript.operands.rValues[0] = 0.1f;
						singleScript.operands.sValues[0] = "";
					}
					else
					{
						switch (characters[j])
						{
							case kain:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "カイン加入"; // Add Kain
									break;
								}
							case rydia:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "リディア加入"; // Add Rydia
									break;
								}
							case edward:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "ギルバート加入"; // Add Edward/Gilbert
									break;
								}
							case rosa:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "ローザ加入"; // Add Rosa
									break;
								}
							case yang:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "ヤン加入"; // Add Yang
									break;
								}
							case palom:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "パロム加入"; // Add Palom
									break;
								}
							case porom:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "ポロム加入"; // Add Porom
									break;
								}
							case cid:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "シド加入"; // Add Cid
									break;
								}
							case edge:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "エッジ加入"; // Add Edge
									break;
								}
							case fusoya:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "フースーヤ加入"; // Add Fusoya
									break;
								}
							case tellah:
								{
									singleScript.mnemonic = "SysCall";
									singleScript.operands.rValues[0] = 0;
									singleScript.operands.sValues[0] = "テラ加入"; // Add Terra / Tellah
									break;
								}
							default:
								singleScript.mnemonic = "Wait";
								singleScript.operands.rValues[0] = 0.1f;
								singleScript.operands.sValues[0] = "";
								break;
						}
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

			string json2 = File.ReadAllText(Path.Combine(directory, "Map_30110", "Map_30110", "sc_e_0029.json"));
			EventJSON jEvents2 = JsonConvert.DeserializeObject<EventJSON>(json2);
			int k = 0;
			foreach (var singleScript in jEvents2.Mnemonics)
			{
				if (singleScript.mnemonic == "Wait" || singleScript.mnemonic == "SysCall")
				{
					if (k == 0) {
						// Characters always contain Cecil... for now...

						//if (characters.Contains(cecil))
						//{
							singleScript.mnemonic = "SysCall";
							singleScript.operands.rValues[0] = 0;
							singleScript.operands.sValues[0] = "セシル転職"; // Cecil promotion
						//}
						//else
						//{
						//	singleScript.mnemonic = "Wait";
						//	singleScript.operands.rValues[0] = 0.1f;
						//	singleScript.operands.sValues[0] = "";
						//}
					}
					else if (k == 1)
					{
						if (characters.Contains(tellah))
						{
							singleScript.mnemonic = "SysCall";
							singleScript.operands.rValues[0] = 0;
							singleScript.operands.sValues[0] = "テラが魔法思い出す"; // Tellah remembers magic
						} else
						{
							singleScript.mnemonic = "Wait";
							singleScript.operands.rValues[0] = 0.1f;
							singleScript.operands.sValues[0] = "";
						}
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


			// Version 1 - Whenever we can somehow fix the loading script to load non-Cecil parties.

			//int reserveChar = characters[5];

			//bool tellahJoin = false;
			//bool tellahUsed1 = false;
			//bool tellahUsed2 = false;

			//	List<int> characters = new List<int> { dkCecil, cecil, kain, rydia, tellah, edward, rosa, yang, palom, porom, cid, edge, fusoya };
			//characters.Shuffle(r1);

			//int reserveChar = characters[5];

			//bool tellahJoin = false;
			//bool tellahUsed1 = false;
			//bool tellahUsed2 = false;
			//// Remove the last seven characters off the list.
			//while (characters.Count() > 5)
			//	characters.RemoveAt(5);

			//// Bring back the sixth selected character if both Cecils were selected.  Remove a Cecil randomly in this case.
			//if (characters.Contains(cecil) && characters.Contains(dkCecil))
			//{
			//	characters.Remove(r1.Next() % 2);
			//	characters.Add(reserveChar);
			//}
			//// Things will get screwy if Cecil is the first character.  (Mainly the opening script will not run, locking the game)
			//if (characters[0] == cecil || characters[0] == dkCecil)
			//{
			//	reserveChar = characters[0];
			//	characters.RemoveAt(0);
			//	characters.Add(reserveChar);
			//}
			//// Things will get screwy if Cecil is the first character.  (Mainly the opening script will not run, locking the game)
			//if (!characters.Contains(cecil) && !characters.Contains(dkCecil))
			//{
			//	tellahJoin = true;
			//}

			//string json = File.ReadAllText(fileName);
			//EventJSON jEvents = JsonConvert.DeserializeObject<EventJSON>(json);
			//int j = 0;
			//foreach (var singleScript in jEvents.Mnemonics)
			//{
			//	if (singleScript.mnemonic == "Wait" || singleScript.mnemonic == "SysCall")
			//	{
			//		if (tellahJoin && !tellahUsed1 && j == 0)
			//		{
			//			singleScript.mnemonic = "SysCall";
			//			singleScript.operands.rValues[0] = 0;
			//			singleScript.operands.sValues[0] = "テラ加入"; // Add Terra / Tellah
			//			tellahUsed1 = true;
			//			j--;
			//		}
			//		else if (tellahJoin && tellahUsed1 && !tellahUsed2 && j == 0)
			//		{
			//			singleScript.mnemonic = "SysCall";
			//			singleScript.operands.rValues[0] = 0;
			//			singleScript.operands.sValues[0] = "テラvs吟遊詩人戦パーティ"; // Change party to Tellah only
			//			tellahUsed2 = true;
			//			j--;
			//		}
			//		else if (!characters.Contains(tellah) && j >= 3 && tellahUsed2)
			//		{
			//			singleScript.mnemonic = "SysCall";
			//			singleScript.operands.rValues[0] = 0;
			//			singleScript.operands.sValues[0] = "テラ離脱"; // Remove Tellah
			//			tellahUsed2 = false;
			//			j--;
			//		}
			//		else if (j >= 5)
			//		{
			//			singleScript.mnemonic = "Wait";
			//			singleScript.operands.rValues[0] = 0.1f;
			//			singleScript.operands.sValues[0] = "";
			//		} 
			//		else
			//		{
			//			switch (characters[j])
			//			{
			//				case cecil:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "セシル転職"; // Cecil Change to Paladin
			//						break;
			//					}
			//				case kain:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "カイン加入"; // Add Kain
			//						break;
			//					}
			//				case rydia:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "リディア加入"; // Add Rydia
			//						break;
			//					}
			//				case edward:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "ギルバート加入"; // Add Edward/Gilbert
			//						break;
			//					}
			//				case rosa:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "ローザ加入"; // Add Rosa
			//						break;
			//					}
			//				case yang:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "ヤン加入"; // Add Yang
			//						break;
			//					}
			//				case palom:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "パロム加入"; // Add Palom
			//						break;
			//					}
			//				case porom:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "ポロム加入"; // Add Porom
			//						break;
			//					}
			//				case cid:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "シド加入"; // Add Cid
			//						break;
			//					}
			//				case edge:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "エッジ加入"; // Add Edge
			//						break;
			//					}
			//				case fusoya:
			//					{
			//						singleScript.mnemonic = "SysCall";
			//						singleScript.operands.rValues[0] = 0;
			//						singleScript.operands.sValues[0] = "フースーヤ加入"; // Add Fusoya
			//						break;
			//					}
			//				case tellah:
			//					{
			//						// Only do this if Cecil is in the party.  We do something different, above, if Cecil is not in the party.
			//						if (characters.Contains(cecil) || characters.Contains(dkCecil))
			//						{
			//							singleScript.mnemonic = "SysCall";
			//							singleScript.operands.rValues[0] = 0;
			//							singleScript.operands.sValues[0] = "テラ加入"; // Add Terra / Tellah
			//						}
			//						break;
			//					}
			//				default:
			//					singleScript.mnemonic = "Wait";
			//					singleScript.operands.rValues[0] = 0.1f;
			//					singleScript.operands.sValues[0] = "";
			//					break;
			//			}
			//		}
			//		j++;
			//	}
			//}
		}
	}
}
