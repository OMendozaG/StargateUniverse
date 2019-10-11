using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace StargateService {
	static class SystemInfo {

		static PerformanceCounter cpuPerformance = new PerformanceCounter("Processor", "% Processor Time", "_Total");


		static public double GetDiskUsagePercent(string letter) { try {
			DriveInfo drive = new DriveInfo(letter.ToUpper());
			return 100 - (100 * (double)drive.TotalFreeSpace / drive.TotalSize);
		} catch { return 0; } }

		static public double GetRamUsagePercent() { try {
			var wmiObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

			var memoryValues = wmiObject.Get().Cast<ManagementObject>().Select(mo => new {
				FreePhysicalMemory = Double.Parse(mo["FreePhysicalMemory"].ToString()),
				TotalVisibleMemorySize = Double.Parse(mo["TotalVisibleMemorySize"].ToString())
			}).FirstOrDefault();

			if (memoryValues != null) {
				return ((memoryValues.TotalVisibleMemorySize - memoryValues.FreePhysicalMemory) / memoryValues.TotalVisibleMemorySize) * 100;
			}

			return 0;
		} catch { return 0; } }

		static public double GetCPUUsagePercent() { try {
			return cpuPerformance.NextValue();
		} catch { return 0; } }

	}
}
