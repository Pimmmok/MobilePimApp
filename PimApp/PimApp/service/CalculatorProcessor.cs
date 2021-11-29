using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PimApp
{
    public class CalculatorProcessor : ICalculatorProcessor
    {
        public float PostProcess(float avg, float[] data)
        {
            double sum = 0;
            if (data.Max() == data.Min())
            {
                return 0;
            }
            else
            {
                foreach (float i in data)
                {
                    sum += Math.Pow(i - avg, 2);
                }
                return (float)Math.Sqrt(sum / (data.Length - 1));
            }
        }

        public float[] Process(ObservableCollection<float> data)
        {
            List<float> result = new List<float>();
            if (data.Max() == data.Min())
            {
                result.Add(data[0]);
            }
            else
            {
                foreach (float i in data)
                {
                    if (i != data.Max() && i != data.Min())
                    {
                        result.Add(i);
                    }
                }
            }
            return result.ToArray();
        }
    }
}
