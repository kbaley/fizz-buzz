using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzer
{
    public class FizzBuzzer : IFizzBuzzer
    {
        private readonly Dictionary<int, string> rules = new Dictionary<int, string>( );

        public string GetFizzBuzz( int number ) {
            var result = "";
            foreach ( var rule in rules ) {
                if ( number % rule.Key == 0 ) {
                    result += rule.Value;
                }
            }
            return string.IsNullOrWhiteSpace( result ) ? number.ToString( ) : result;
        }

        public IEnumerable<string> GetFizzBuzz( int start, int end ) {
            return Enumerable.Range( start, end - start + 1 )
                .Select( x => GetFizzBuzz( x ) );
        }

        public void AddRule( int number, string output ) {
            if ( rules.ContainsKey( number ) ) {
                rules[number] = output;
            }
            else {
                rules.Add( number, output );
            }
        }
    }
}