using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularBuffer
{
    public  class NumberGenerator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(NumberGenerator));

        private Random _random; 
        private double _minValue = 0.0;
        private double _maxValue = 100.0;
        public NumberGenerator() {}
        public double GenerateRandomNumber()
        {
            _random = new Random();
            double ans = _minValue + (_random.NextDouble() * (_maxValue - _minValue));
            return ans;
        }


    }
}
