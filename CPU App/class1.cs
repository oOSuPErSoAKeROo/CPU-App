using System.Management;
using System.Windows;

namespace CPU_App
{
    internal class Class1
    {
        string Prozessor;
        public Class1()

        {
            
        }
        public uint GetProcessorSpeed()
        {
            // Win32_Processor-Instanz für den ersten Prozessor erzeugen und die
            // Geschwindigkeit abfragen
            ManagementObject mo = new ManagementObject(
                "Win32_Processor.DeviceID='CPU0'");

            uint currentClockSpeed = 0;
            try
            {
                currentClockSpeed = (uint)(mo["CurrentClockSpeed"]);
            }
            catch { }
            // Speicher des WMI-Objekts freigeben
            mo.Dispose();
            return currentClockSpeed;
        }
        public void GetProcessorname()
        {
            
            ManagementObjectSearcher cpu = new ManagementObjectSearcher("SELECT * FROM Win32_processor");
            ManagementObjectCollection queryCollection1 = cpu.Get();
            foreach (ManagementObject mo in queryCollection1)
            {
                Prozessor = mo["caption"].ToString();
            }
            MessageBox.Show(Prozessor);
        }
    }
        
            
 }
        
    
