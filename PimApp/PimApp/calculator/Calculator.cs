using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PimApp
{
    public class Calculator
    {
        private readonly ICalculatorProcessor CalculatorService;
        public CalculatorData Data { get; }

        public Calculator(ICalculatorProcessor calculatorService)
        {
            CalculatorService = calculatorService;
            Data = new CalculatorData();
        }

        public void Calculate(ObservableCollection<float> rezult) {
            Data.Result = rezult.ToArray<float>();
            Data.Valuesrezult = CalculatorService.Process(rezult);
            float SredneeAll = Data.Valuesrezult.Sum() / Data.Valuesrezult.Length;
            Data.Avg = (float)Math.Round(SredneeAll, 2);
            Data.Sredneeqvadro = (float)Math.Round(CalculatorService.PostProcess(SredneeAll, Data.Valuesrezult), 2);
        }
    }
}
