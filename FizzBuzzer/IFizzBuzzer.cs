using System.Collections.Generic;

namespace FizzBuzzer
{
    public interface IFizzBuzzer
    {
        string GetFizzBuzz( int number );
        IEnumerable<string> GetFizzBuzz( int start, int end );
        void AddRule( int number, string output );
    }
}