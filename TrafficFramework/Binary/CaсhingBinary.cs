using System;
using System.IO;
using TrafficFramework.DataResponse;

namespace TrafficFramework.Binary
{
	public class CaсhingBinary
	{
		private readonly static string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

		private static string FileName = $@"binary_{DateTime.Now.Ticks}.dat";

        public static void SaveInfo(FullInfo fullInfo, Status status, string strick)
        {
			using(BinaryWriter writer = new BinaryWriter(File.Open(Path.Combine(FilePath, FileName), FileMode.Create)))
			{
				writer.Write(fullInfo.ToString());
				writer.Write(status.ToString());
			}
		}
    }
}
