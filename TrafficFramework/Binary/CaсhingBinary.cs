using System;
using System.Collections.Generic;
using System.IO;
using TrafficFramework.DataResponse;

namespace TrafficFramework.Binary
{
	public class CaсhingBinary
	{
		private readonly static string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + "TestProgram\\";

        public static string SaveInfo(string data)
        {
			if(!Directory.Exists(FilePath))
			{
				Directory.CreateDirectory(FilePath);
			}
			var filename = $@"binary_{DateTime.Now.Ticks}.dat";
			using(BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(FilePath, filename), FileMode.CreateNew)))
			{
				writer.Write(data);
			}
			return filename;
		}

		public static void DeleteAll()
		{
			if(Directory.Exists(FilePath))
			{
				var files = Directory.GetFiles(FilePath);
				foreach(var item in files)
				{
					File.Delete(item);
				}
			}
		}

		public static string[] ReadInfo()
		{
			if(Directory.Exists(FilePath))
			{
				var files = Directory.GetFiles(FilePath);
				List<string> list = new List<string>();
				foreach(var file in files)
				{
					using(BinaryReader reader = new BinaryReader(File.Open(Path.Combine(FilePath, file), FileMode.Open)))
					{
						list.Add(reader.ReadString());
					}
				}
				return list.ToArray();
			}
			return null;
		}
	}
}
