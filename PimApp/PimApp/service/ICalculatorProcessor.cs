using System.Collections.ObjectModel;

namespace PimApp
{
    public interface ICalculatorProcessor
    {
        float[] Process(ObservableCollection<float> data);

        float PostProcess(float srednee, float[] data);
    }
}
