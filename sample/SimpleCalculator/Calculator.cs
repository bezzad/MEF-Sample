﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using SimpleCalculator.Extension;

namespace SimpleCalculator
{
    [Export(typeof(ICalculator))]
    class Calculator : ICalculator
    {
        [ImportMany]
        IEnumerable<Lazy<IOperation, IOperationData>> _operations;

        public string Calculate(string input)
        {
            input = input.Replace(" ", "");
            int left;
            int right;
            var fn = FindFirstNonDigit(input); //finds the operator
            if (fn < 0) return "Could not parse command.";

            try
            {
                //separate out the operands
                left = int.Parse(input.Substring(0, fn));
                right = int.Parse(input.Substring(fn + 1));
            }
            catch
            {
                return "Could not parse command.";
            }

            var operation = input[fn];

            foreach (var i in _operations)
            {
                if (i.Metadata.Symbol.Equals(operation))
                    return i.Value.Operate(left, right).ToString(CultureInfo.InvariantCulture);
            }
            return "Operation Not Found!";
        }

        private int FindFirstNonDigit(string s)
        {

            for (var i = 0; i < s.Length; i++)
            {
                if (!(char.IsDigit(s[i]))) return i;
            }
            return -1;
        }
    }
}