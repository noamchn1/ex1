using System;
using System.Collections.Generic;

namespace ex1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            FunctionsContainer funcList = new FunctionsContainer();
            // create functions
            funcList["Double"] = val => val * 2;
            funcList["Triple"] = val => val * 3;
            funcList["Square"] = val => val * val;
            funcList["Sqrt"] = val => Math.Sqrt(val);
            funcList["Plus2"] = val => val + 2;

            //print all available funcs
            funcList.PrintAvailableFunctions();

            // create missions
            ComposedMission mission1 = new ComposedMission("mission1").Add(funcList["Square"]).Add(funcList["Sqrt"]);
            ComposedMission mission2 = new ComposedMission("mission2").Add(funcList["Triple"]).Add(funcList["Plus2"]).Add(funcList["Square"]);
            SingleMission mission3 = new SingleMission(funcList["Double"], "mission3");
            ComposedMission mission4 = new ComposedMission("mission4").Add(funcList["Triple"]).Add(funcList["Stam"]).Add(funcList["Plus2"]);
            funcList["Stam"] = val => val + 100;
            SingleMission mission5 = new SingleMission(funcList["Stam"], "mission5");

            //print all available funcs
            funcList.PrintAvailableFunctions();

            // EventHandler which prints the mission details and the return value
            EventHandler<double> LogHandler = (sender, val) =>
            {
                IMission mission = sender as IMission;
                if (mission != null)
                {
                    Console.WriteLine($"Mission of Type: {mission.Type} with the Name {mission.Name} returned {val}");
                }
            };

            // EventHandler which creates list of Sqrt missions as long as the value is greater then 2
            EventHandler<double> SqrtHandler = (sender, val) =>
            {
                SingleMission sqrtMission = new SingleMission(funcList["Sqrt"], "SqrtMission");
                double newVal;
                do
                {
                    newVal = sqrtMission.Calculate(val); // getting the new Val
                    Console.WriteLine($"sqrt({val}) = {newVal}");
                    val = newVal; // Storing the new Val;
                } while (val > 2);
                Console.WriteLine("----------------------------------------");
            };
            
            // create list of IMissions
            var missionList = new List<IMission>() { mission1, mission2, mission3, mission4, mission5 };
            // conect the EventHandlers above to the missions
            foreach (var m in missionList)
            {
                m.OnCalculate += LogHandler;
                m.OnCalculate += SqrtHandler;
            }

            // add more IMissions
            missionList.Add(mission2);
            missionList.Add(mission1);
            missionList.Add(mission3);

            // run the missions
            RunMissions(missionList, 100);

            Console.ReadLine();
        }

        private static void RunMissions(List<IMission> missionList, double value)
        {
            foreach(IMission m in missionList)
            {
                m.Calculate(value);
            }
        }
    }
}
