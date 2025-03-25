using System; // 원래는 System.Console.WriteLine

namespace NestedClass // 그룹화
{
	class Configuration
	{
		List<ItemValue> listConfig = new List<ItemValue>();

		public void SetConfig(string item, string value) // 읽기
		{
			ItemValue iv = new ItemValue();
			iv.SetValue(this, item, value); // this = Configuration "config"
        }

		public string GetConfig(string item) // 쓰기(write), return
		{
			foreach (ItemValue iv in listConfig)
			{
				if (iv.GetItem() == item)
				{
					return iv.GetValue();
				}
			}

			return "";
		}

		private class ItemValue
		{
			private string item;
			private string value;

			public void SetValue(Configuration config, string item, string value)
			{
				this.item = item;
				this.value = value;

				bool found = false;
				for (int i = 0; i < config.listConfig.Count; i++)
				{
					if (config.listConfig[i].item == item)
					{
						config.listConfig[i] = this;
						found = true;
						break;
					}
				}

				if (found == false)
				{
					config.listConfig.Add(this);
				}
			}

			public string GetItem()
			{
				return item;
			}

			public string GetValue()
			{
				return value;
			}
		}
	}

	class MainApp
	{
		static void Main(string[] args)
		{
			Configuration config = new Configuration();
			config.SetConfig("Version", "V 5.0"); // item, value
            config.SetConfig("Size", "655,324 KB"); // item, value

            Console.WriteLine(config.GetConfig("Version"));
            Console.WriteLine(config.GetConfig("Size"));
        }
	}
}