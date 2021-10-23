using System;
using System.IO;
using TrafficFramework.DataResponse;

namespace TrafficFramework.Binary
{
	public class BinarySaver
	{
		private static string FilePath = @"D:\";

		private static string FileName = $@"binary_{DateTime.Now.Ticks}.dat";

        public static void SaveInfo(FullInfo fullInfo)
        {
			using(BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(FilePath, FileName), FileMode.Create)))
			{
				writer.Write(fullInfo.ToString());
			}
		}
    }
}
