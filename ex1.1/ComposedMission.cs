﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private string name;
        private string type;
        private List<FunctionsContainer.del> functions;

        public ComposedMission(string n)
        {
            name = n;
            type = "Composed";
            functions = new List<FunctionsContainer.del>();
        }

        public string Name => name;
        public string Type => type;

        public event EventHandler<double> OnCalculate;

        internal ComposedMission Add(FunctionsContainer.del f)
        {
            functions.Add(f);
            return this;
        }

        public double Calculate(double value)
        {
            double res = value;
            foreach (FunctionsContainer.del f in functions)
            {
                res = f.Invoke(res);
            }
            if(OnCalculate != null)
            {
                OnCalculate.Invoke(this, res);
            }
            return res;
        }
    }
}
