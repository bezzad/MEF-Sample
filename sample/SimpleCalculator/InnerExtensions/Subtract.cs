using System.ComponentModel.Composition;
using SimpleCalculator.Extension;

namespace SimpleCalculator.InnerExtensions
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '-')]
    class Subtract : IOperation
    {
        public double Operate(int left, int right)
        {
            return left - right;
        }
    }
}