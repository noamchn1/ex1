﻿using System;

namespace ex1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            FunctionsContainer funcList = new FunctionsContainer();
            funcList["Double"] = val => val * 2;
            funcList["Triple"] = val => val * 3;
            funcList["Square"] = val => val * val;
            funcList["Sqrt"] = val => Math.Sqrt(val);
            funcList["Plus2"] = val => val + 2;
            ComposedMission mission1 = new ComposedMission("mission1").Add(funcList["Square"]).Add(funcList["Sqrt"]);
            ComposedMission mission2 = new ComposedMission("mission2").Add(funcList["Triple"]).Add(funcList["Plus2"]).Add(funcList["Square"]);
            SingleMission mission3 = new SingleMission(funcList["Double"], "mission3");

            //print the funcs
            Console.WriteLine("All Available Functions");
            funcList.PrintAllMissions();
            Console.ReadLine();
        }
    }
}
