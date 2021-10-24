using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.Data
{
	public class PhasePart
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("start")]
		public DateTime TimeStart { get; set; }

		[JsonProperty("end")]
		public DateTime TimeEnd { get; set; }

		[JsonProperty("interval")]
		public TimeSpan TimeInterval { get; private set; }

		/// <summary>Предел апроксимации.</summary>
		public float ApraxDelta { get; private set; }

		private float _limitAprax = 1f;

		public bool HasMaxAprax { get; private set; }

		public void UpdateInterval(float time)
		{
			TimeInterval = new TimeSpan(0,0,(int)time);
		}

		public void UpdateInterval()
		{
			var interval = TimeEnd - TimeStart;
			ApraxDelta = (float)(TimeInterval.TotalSeconds - interval.TotalSeconds);
			if(TimeInterval.TotalSeconds < interval.TotalSeconds)
			{

				if(_limitAprax > ApraxDelta)
				{
					HasMaxAprax = true;
				}
				TimeInterval = interval;
			}
			else
			{
				TimeInterval = TimeInterval.Add(new TimeSpan(0,0, -(int)(ApraxDelta / 4)));
			}
		}
	}
}
