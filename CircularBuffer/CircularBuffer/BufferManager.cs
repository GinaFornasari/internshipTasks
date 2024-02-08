using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CircularBuffer
{
    public class BufferManager
    {
        private int _capacity;
        private double[] _array;
        private int _startIndex;
        private int _endIndex;
        private SemaphoreSlim _semaphore;

        public BufferManager(int capacity)
        {
            _capacity = capacity;
            _array = new double[_capacity];
            _semaphore = new SemaphoreSlim(1);
        }
        public Task AddOrOverride(double item)
        {
            _semaphore.WaitAsync();
            try
            {
                if(_startIndex == _capacity)
                {
                    _startIndex = 0; 
                }
                _array[_startIndex] = item;
                _startIndex++; 
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public double GetAverage(int howMany)
        {
            _semaphore.WaitAsync();
            try
            {
                double sum = 0;
                for(int i=0; i<howMany; i++)
                {
                    int index = _startIndex - i;
                    if (index <0)
                    {
                        index += _capacity; 
                    }
                    sum += _array[index];
                }
                return (double) sum / howMany;
            }
            finally
            {
                _semaphore.Release();
            }
        }

    }
}
