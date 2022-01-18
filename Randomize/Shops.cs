using FF4FabulGauntlet.Inventory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static FF4FabulGauntlet.Common.Common;

namespace FF4FabulGauntlet.Randomize
{
	public class Shops
	{
		// Let's const the stores
		const int baron1 = 1;
		const int baron2 = 2;
		const int baron3 = 3;
		const int mist1 = 4;
		const int mist2 = 5;
		const int mist3 = 6;
		const int undergroundWaterway1 = 7;
		const int undergroundWaterway2 = 8;
		const int undergroundWaterway3 = 9;
		const int hobs1 = 10;
		const int hobs2 = 11;
		const int hobs3 = 12;
		const int ordeals1 = 13;
		const int ordeals2 = 14;
		const int ordeals3 = 15;
		const int baronWaterway1 = 16;
		const int baronWaterway2 = 17;
		const int baronWaterway3 = 18;
		const int magnes1 = 19;
		const int magnes2 = 20;
		const int magnes3 = 21;
		const int dwarfCastle1 = 22;
		const int dwarfCastle2 = 23;
		const int dwarfCastle3 = 24;
		const int dwarfCastle4 = 34;
		const int eblanCave1 = 25;
		const int eblanCave2 = 26;
		const int eblanCave3 = 27;
		const int upperBabil1 = 28;
		const int upperBabil2 = 29;
		const int upperBabil3 = 30;
		const int crystalPalace1 = 31;
		const int crystalPalace2 = 32;
		const int crystalPalace3 = 33;

		List<int> allStores = new List<int>
		{
			baron1, baron2, baron3, mist1, mist2, mist3, undergroundWaterway1, undergroundWaterway2, undergroundWaterway3,
			hobs1, hobs2, hobs3, ordeals1, ordeals2, ordeals3, baronWaterway1, baronWaterway2, baronWaterway3,
			magnes1, magnes2, magnes3, dwarfCastle1, dwarfCastle2, dwarfCastle3, dwarfCastle4, eblanCave1, eblanCave2, eblanCave3, 
			upperBabil1, upperBabil2, upperBabil3, crystalPalace1, crystalPalace2, crystalPalace3
		};
		List<int> stdMinTier = new List<int>
		{
			1, 1, 1, 
			1, 1, 1, 
			1, 1, 1,
			2, 2, 2, 
			3, 3, 3, 
			3, 3, 3, 
			3, 3, 3, 
			3, 3, 3, 
			4, 4, 4, 
			5, 5, 5,
			5, 5, 5,
			1
		};
		List<int> stdMaxTier = new List<int>
		{
			1, 1, 1,
			2, 2, 2, 
			3, 3, 3, 
			3, 3, 3,
			4, 4, 4,
			5, 5, 5,
			5, 5, 5,
			6, 6, 6,
			6, 6, 6,
			7, 7, 7,
			8, 8, 8,
			8
		};

		List<int> proMinTier = new List<int>
		{
			1, 1, 1,
			1, 1, 1,
			1, 1, 1,
			1, 1, 1,
			2, 2, 2,
			2, 2, 2,
			2, 2, 2,
			3, 3, 3,
			3, 3, 3,
			4, 4, 4,
			4, 4, 4,
			1
		};
		List<int> proMaxTier = new List<int>
		{
			1, 1, 1,
			2, 2, 2,
			2, 2, 2,
			3, 3, 3,
			3, 3, 3,
			4, 4, 4,
			4, 4, 4,
			5, 5, 5,
			5, 5, 5,
			6, 6, 6,
			7, 7, 7,
			8
		};

		private class shopItem 
		{
			public int id;
			public int content_id; // Item
			public int group_id; // Store #
			public int coefficient = 0; // Inn/House of Healing cost
			public int purchase_limit = 0; // 0 = unlimited
		}

		List<shopItem> productList = new List<shopItem>();

		private List<shopItem> determineItems(List<int> items, List<int> stores, Random r1)
		{
			List<shopItem> shopDB = new List<shopItem>();

			List<int> storeNumItems = new List<int>();
			bool duplicates = true;
			while (duplicates)
			{
				storeNumItems.Clear();
				for (int lnI = 0; lnI < stores.Count - 1; lnI++)
					storeNumItems.Add(r1.Next() % items.Count);
				storeNumItems.Add(items.Count);
				duplicates = storeNumItems.AreAnyDuplicates();
			}
			storeNumItems.Sort();
			for (int lnI = 0; lnI < items.Count; lnI++)
			{
				shopItem newItem = new shopItem();
				newItem.id = 0;
				newItem.group_id = stores[storeNumItems.Select((elem, index) => new { elem, index }).First(p => p.elem > lnI).index];
				newItem.content_id = items[lnI];
				shopDB.Add(newItem);
			}

			return shopDB;
		}

		public Shops(Random r1, int randoLevel, int freqLevel, bool noJ, bool noSuper, string fileName, bool includeBonus)
		{
			List<shopItem> shopDB = new List<shopItem>();
			List<shopItem> shopWorking = new List<shopItem>();
			int id = 1;

			for (int i = 0; i < allStores.Count; i++)
			{
				shopWorking = new List<shopItem>();
				// Alternate between weapons, armor, and item stores, so each place has at least one of each.
				int itemType = allStores[i] % 3;
				int freq = (freqLevel == 0 ? 4 : freqLevel == 1 ? 8 : freqLevel == 2 ? 12 : freqLevel == 3 ? 16 : 20);
				for (int j = 0; j <= freq; j++)
				{
					shopItem newItem = new shopItem();
					newItem.group_id = allStores[i];
					newItem.id = id;
					int minTier = randoLevel <= 1 ? stdMinTier[i] : randoLevel == 2 ? proMinTier[i] : 1;
					int maxTier = randoLevel == 0 ? stdMaxTier[i] + 1 : randoLevel == 1 ? stdMaxTier[i] : randoLevel == 2 ? proMaxTier[i] : noSuper ? 8 : 9;

					// Alternate between weapons, armor, and item stores, so each place has at least one of each.
					switch (itemType)
					{
						case 0:
							newItem.content_id = new Inventory.Armor().selectItem(r1, minTier, maxTier, true);
							break;
						case 1:
							newItem.content_id = new Inventory.Weapons().selectItem(r1, minTier, maxTier, true, includeBonus);
							break;
						case 2:
							newItem.content_id = new Inventory.Items().selectItem(r1, minTier, maxTier, true, noJ);
							break;
					}

					// Do not add if it's a duplicate.
					if (shopWorking.Where(c => c.content_id == newItem.content_id).Count() == 0)
					{
						shopWorking.Add(newItem);
						id++;
					}
				}
				// The store after Upper Babil must have a hi-Potion(in case there are no white mages in the party) and a tent(in case you are forced to grind between gauntlets). (damage floors)
				if (allStores[i] == upperBabil2 && shopWorking.Where(c => c.id == Inventory.Items.hiPotion).Count() == 0)
				{
					shopItem newItem = new shopItem();
					newItem.group_id = allStores[i];
					newItem.id = id;
					newItem.content_id = Inventory.Items.hiPotion;
					shopWorking.Add(newItem);
					id++;
				}
				if (allStores[i] == crystalPalace2 && shopWorking.Where(c => c.id == Inventory.Items.tent).Count() == 0)
				{
					shopItem newItem = new shopItem();
					newItem.group_id = allStores[i];
					newItem.id = id;
					newItem.content_id = Inventory.Items.tent;
					shopWorking.Add(newItem);
					id++;
				}
				// The Crystal Palace must have an X-Potion(in case there are no white mages in the party), a Cottage(in case you are forced to grind between gauntlets) (Zeromus), and a Light Curtain (in case of Meganuke fights). 
				if (allStores[i] == crystalPalace2 && shopWorking.Where(c => c.id == Inventory.Items.xPotion).Count() == 0) 
				{
					shopItem newItem = new shopItem();
					newItem.group_id = allStores[i];
					newItem.id = id;
					newItem.content_id = Inventory.Items.xPotion;
					shopWorking.Add(newItem);
					id++;
				}
				if (allStores[i] == crystalPalace2 && shopWorking.Where(c => c.id == Inventory.Items.cottage).Count() == 0)
				{
					shopItem newItem = new shopItem();
					newItem.group_id = allStores[i];
					newItem.id = id;
					newItem.content_id = Inventory.Items.cottage;
					shopWorking.Add(newItem);
					id++;
				}
				if (allStores[i] == crystalPalace2 && shopWorking.Where(c => c.id == Inventory.Items.lightCurtain).Count() == 0)
				{
					shopItem newItem = new shopItem();
					newItem.group_id = allStores[i];
					newItem.id = id;
					newItem.content_id = Inventory.Items.lightCurtain;
					shopWorking.Add(newItem);
					id++;
				}
				shopDB.AddRange(shopWorking.OrderBy(c => c.content_id));
			}

			using (StreamWriter sw = new StreamWriter(fileName))
			{
				sw.WriteLine("id,content_id,group_id,coefficient,purchase_limit");
				int finalID = 0;
				foreach (shopItem si in shopDB)
				{
					finalID++;
					sw.WriteLine(finalID + "," + si.content_id + "," + si.group_id + "," + si.coefficient + "," + si.purchase_limit);
				}
				finalID++;
				// Inn prices
				sw.WriteLine(finalID + ",0,101,10,0");  finalID++;
				sw.WriteLine(finalID + ",0,102,10,0");  finalID++;
				sw.WriteLine(finalID + ",0,103,10,0");  finalID++;
				sw.WriteLine(finalID + ",0,104,20,0");  finalID++;
				sw.WriteLine(finalID + ",0,105,40,0");  finalID++;
				sw.WriteLine(finalID + ",0,106,10,0");  finalID++;
				sw.WriteLine(finalID + ",0,107,100,0"); finalID++;
				sw.WriteLine(finalID + ",0,108,80,0");  finalID++;
				sw.WriteLine(finalID + ",0,109,100,0"); finalID++;
				sw.WriteLine(finalID + ",0,110,100,0"); finalID++;
				sw.WriteLine(finalID + ",0,111,60,0");  finalID++;
				sw.WriteLine(finalID + ",0,112,200,0"); finalID++;
			}
		}
	}
}
