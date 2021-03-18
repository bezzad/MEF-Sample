using SimpleCalculator.Extension;
using System.ComponentModel.Composition;

namespace FactorialOperation
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '!')]
    public class Factorial : IOperation
    {
        public double Operate(int left, int right)
        {
            return Fact(left);
        }

        private long Fact(int num)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }

            return num * Fact(num - 1);
        }
    }
}
