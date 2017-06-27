using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public class SampleService : ISampleInterface
    {
        private Random _random;
        private int _current;
        public SampleService()
        {
            _random = new Random();
            _current = _random.Next();
        }

        public int GetNumber()
        {
            return _current;
        }
    }
}
