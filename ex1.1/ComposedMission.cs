using System;
using System.Collections.Generic;
using System.Text;

namespace ex1._1
{
    class ComposedMission : IMission
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

        public void Add(FunctionsContainer.del f)
        {
            functions.Add(f);
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
