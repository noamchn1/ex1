﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ex1._1
{

    class FunctionsContainer
    {
        public delegate double del(double i);
        private Dictionary<string, del> funcs = new Dictionary<string, del>();

        public del this[string funcName]
        {
            set
            {
                funcs.Add(funcName, value);
            }
            get
            {
                // if funcs doesn't contain the key of funcName, don't change the value
                if (!funcs.ContainsKey(funcName))
                {
                    funcs[funcName] = i => i;
                }
                return funcs[funcName];
            }
        }

        public void PrintAllMissions()
        {
            foreach(KeyValuePair<string, del> keyValue in funcs)
            {
                Console.WriteLine("All Available Functions");
                Console.WriteLine(keyValue.Key);
                Console.WriteLine("####################################");
            }
        }
    }
}
