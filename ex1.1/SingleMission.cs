using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    class SingleMission : IMission
    {
        private string name;
        private string type;
        private FunctionsContainer.del function;

        public SingleMission(FunctionsContainer.del f, string n)
        {
            name = n;
            type = "Single";
            function = f;
        }

        public string Name => name;
        public string Type => type;

        public event EventHandler<double> OnCalculate;

        public double Calculate(double value)
        {
            double res = function.Invoke(value);
            if (OnCalculate != null)
            {
                OnCalculate.Invoke(this, res);
            }
            return res;
        }
    }
}