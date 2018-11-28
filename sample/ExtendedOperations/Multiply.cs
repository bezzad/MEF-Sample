using System.ComponentModel.Composition;
using SimpleCalculator.Extension;

namespace ExtendedOperations
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '*')]
    public class Multiply : IOperation
    {
        public double Operate(int left, int right)
        {
            return left * right;
        }
    }
}
