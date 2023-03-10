using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALoRa.Library;
using Parser;
using Elsys.Decoder;




namespace ConsoleApp.Lora
{
    public class Program
    {
        private static bool CONTAINER = false;
        static void Main(string[] args)
        {
            Console.WriteLine("\nALoRa ConsoleApp - A The Things Network C# Library\n");

            string TTN_APP_ID = "####";
            string TTN_ACCESS_KEY = "####";
            string TTN_REGION = "####";

            using (var app = new TTNApplication(TTN_APP_ID, TTN_ACCESS_KEY, TTN_REGION))
            {
                app.MessageReceived += App_MessageReceived;

                if (CONTAINER)
                {
                    // use for testing when running as container
                    Thread.Sleep(Timeout.Infinite);
                }
                else
                {
                    Console.WriteLine("Press return to exit!");
                    Console.ReadLine();
                    Console.WriteLine("\nAloha, Goodbye, Vaarwel!");
                    Thread.Sleep(1000);
                }
                app.Dispose();
            }
        }

        private static void App_MessageReceived(TTNMessage obj)
        {
            var data = obj.Payload != null ? BitConverter.ToString(obj.Payload) : string.Empty;
            var ttnId = obj.DeviceID;
            Console.WriteLine($"Message Timestamp: {obj.Timestamp}, Device: {obj.DeviceID}, Topic: {obj.Topic}, Payload: {data}");

            var pld = data.Replace("-", "");

            var cleanData = Elsys.Decoder.Decoder.Decode(pld);

            DisplayMessage(ttnId, cleanData);

        }


        public static void DisplayMessage(string deviceId, Data sensorData)
        {
            if(deviceId.EndsWith("a4") || deviceId.EndsWith("a5")){
                Console.WriteLine($"Decoded message: Co2 {sensorData.Co2}, Humidity {sensorData.Humidity}, Light {sensorData.Light}, Motion {sensorData.Motion}, Temperature {sensorData.Temperature}, Vdd {sensorData.Vdd}");
            }
            if (deviceId.EndsWith("fd") || deviceId.EndsWith("fe")){
                Console.WriteLine($"Decoded message: AccMotion {sensorData.AccMotion}, ExternalTemperature {sensorData.ExternalTemperature}, Humidity {sensorData.Humidity}, Pressure {sensorData.Pressure}, Temperature {sensorData.Temperature}, Vdd {sensorData.Vdd}, X {sensorData.X}, Y {sensorData.Y}, Z {sensorData.Z}");
            }
        }
    }
}
