using log4net;
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
        private static readonly ILog log = LogManager.GetLogger(typeof(BufferManager)); 

        private int _capacity;
        private double[] _array;
        private int _startIndex;
        private int _endIndex;
        private SemaphoreSlim _semaphore;
        private bool _full; 

        public BufferManager(int capacity)
        {
            _capacity = capacity;
            _array = new double[_capacity];
            _semaphore = new SemaphoreSlim(1);
            _startIndex = 0;
            _full = false; 
        }
        public async Task AddOrOverride(double item)
        {
            await _semaphore.WaitAsync();
            try
            {
                if(_startIndex == _capacity)
                {
                    _full = true;
                    log.Info("buffer full"); 
                    _startIndex = 0; 
                }
                _array[_startIndex] = item;
                _startIndex++;
            }
            catch (Exception)
            {
                log.Error("Could not add or overwrite");
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<double> GetAverage(int howMany)
        {
            await _semaphore.WaitAsync();
            try
            {
                log.Info("getting average"); 
                if (!_full)
                {
                    return 0; 
                }        
                double sum = 0;
                for(int i=1; i<=howMany; i++)
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
            catch (Exception ex)
            {
                log.Error("Could not get average");
                return 0;
            }
            finally
            {
                _semaphore.Release();
            }
        }

    }
}
