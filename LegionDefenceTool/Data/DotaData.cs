using KVLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegionDefenceTool.Data
{
	public class DotaData
	{
		[JsonIgnore]
		public KeyValue HeroesKV;

		[JsonIgnore]
		public KeyValue GameItemsKV;

		public static DotaData ActiveData { get; private set; }

		const string HEROES_FILE = "data/dota/npc_heroes.txt";
		const string UNITS_FILE = "data/dota/npc_units.txt";
		const string ITEMS_FILE = "data/dota/items_game.txt";

		#region Loading

		public void Load()
		{
			HeroesKV = LoadValveKVFile(HEROES_FILE);
			GameItemsKV = LoadValveKVFile(ITEMS_FILE);

			ActiveData = this;
        }
		
		KeyValue LoadValveKVFile(string Path)
		{
			if (File.Exists(Path))
			{
				TextReader Reader = new StreamReader(Path, Encoding.UTF8);
				string KVData = Reader.ReadToEnd();
				Reader.Close();

				KVLib.KeyValues.PenguinParser Parser = new KVLib.KeyValues.PenguinParser();
				KeyValue[] data = Parser.ParseAll(KVData);
				return data[0];
			}
			return null;
		}

		#endregion

		public KeyValue GetHeroData(string HeroName)
		{
			return HeroesKV?.Children.FirstOrDefault(x => x.Key == HeroName);
        }

		public KeyValue[] GetDefaultWearablesForHero(string HeroName)
		{
			if (GameItemsKV != null)
			{
				var ItemsKV = GameItemsKV["items"];
				var KVs = ItemsKV.Children.Where(x =>
					x["prefab"]?.GetString() == "default_item" &&
					x["used_by_heroes"].Children.Any(y => y.Key == HeroName)
				)?.ToArray();
				return KVs;
            }
			return null;
		}

	}
}
