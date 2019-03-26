using System;
using System.Collections.Generic;
using System.Text;

namespace Excercise_1
{

    class FunctionsContainer
    {
        public delegate double del(double i);
        private Dictionary<string, del> funcs = new Dictionary<string, del>();

        public del this[string funcName]
        {
            set
            {
                funcs[funcName] = value;
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

        public List<string> getAllMissions()
        {
            List<string> missions = new List<string>();
            foreach (KeyValuePair<string, del> keyValue in funcs)
            {
                missions.Add(keyValue.Key);
            }
            return missions;
        }
    }
}
