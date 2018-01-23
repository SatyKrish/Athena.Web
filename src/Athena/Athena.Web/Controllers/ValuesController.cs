using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace Athena.Web.Controllers
{
    [Route("api/[action]")]
    public class ValuesController : Controller
    {
        static readonly Dictionary<int, long> _fibonacciTable = new Dictionary<int, long>();

        /// <summary>
        /// Returns the token.
        /// </summary>
        /// <returns>The token.</returns>
        /// <remarks>Returns the token.</remarks>
        // GET api/Token
        [HttpGet]
        public IActionResult Token()
        {
            return Ok("522f95d7-a841-4bfc-9f95-d4e39feec7a4");
        }

        /// <summary>
        /// Returns the nth fibonacci number. 
        /// </summary>
        /// <param name="n">The index.</param>
        /// <returns>The fibonacci number.</returns>
        /// <remarks>Returns the nth fibonacci number.</remarks>
        // POST api/Fibonacci
        [HttpGet]
        public IActionResult Fibonacci(int n)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "The request is invalid." });

            return Ok(GetFibonacci(n));
        }

        /// <summary>
        /// Returns the type of triangle given the lengths of its sides. 
        /// </summary>
        /// <param name="a">The length of side a.</param>
        /// <param name="b">The length of side b.</param>
        /// <param name="c">The length of side c.</param>
        /// <returns>The type of triangle.</returns>
        /// <remarks>Returns the type of triangle given the lengths of its sides.</remarks>
        // PUT api/TriangleType
        [HttpGet]
        public IActionResult TriangleType(int a, int b, int c)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "The request is invalid." });

            if (!IsValid(a, b, c))
                return Ok("Error");
            
            if ((a == b) && (a == c))
                return Ok("Equilateral");

            if ((a == b) || (a == c) || (b == c))
                return Ok("Isosceles");

            return Ok("Scalene");
        }

        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <param name="sentence">The sentence.</param>
        /// <returns>The reversed words.</returns>
        /// <remarks>Reverses the letters of each word in a sentence.</remarks>
        // GET api/ReverseWords
        [HttpGet]
        public IActionResult ReverseWords(string sentence)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "The request is invalid." });

            if (string.IsNullOrWhiteSpace(sentence))
                return Ok("Error");

            var regex = new Regex(@"\s+");
            var replacementStringBuilder = new StringBuilder(sentence);

            var words = regex.Split(sentence);
            if (words != null && words.Length == 0)
            {
                return Ok(sentence);
            }

            foreach (var word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    replacementStringBuilder.Replace(word, GetReversedWord(word));
                }
            }

            return Ok(replacementStringBuilder.ToString());
        }        

        /// <summary>
        /// Get the fibonacci number for the given index.
        /// </summary>
        /// <param name="n">The index.</param>
        /// <returns>The fibonacci number.</returns>
        private static long GetFibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;

            if (_fibonacciTable.ContainsKey(n))
                return _fibonacciTable[n];

            long fibNumber = 0;
            if (n < 0)
                fibNumber = GetNegafibonacci(n);
            else
                fibNumber = GetFibonacci(n - 1) + GetFibonacci(n - 2);

            _fibonacciTable.Add(n, fibNumber);
            return fibNumber;
        }

        /// <summary>
        /// Gets the negafibonacci number for the given index
        /// </summary>
        /// <param name="n">The index.</param>
        /// <returns>The negafibonacci number.</returns>
        private static long GetNegafibonacci(int n)
        {
            return GetFibonacci(n + 2) - GetFibonacci(n + 1);
        }

        /// <summary>
        /// Gets the reverse of a given word
        /// </summary>
        /// <param name="word">The input word.</param>
        /// <returns>The reversed word.</returns>
        private static string GetReversedWord(string word)
        {
            if (word.Length == 1)
            {
                return word;
            }
            return new string(word.ToCharArray().Reverse().ToArray());
        }

        /// <summary>
        /// Validates triangle inequivality given the length of each sides.
        /// </summary>
        /// <param name="a">The length of side a.</param>
        /// <param name="b">The length of side b.</param>
        /// <param name="c">The length of side c.</param>
        /// <returns><see cref="bool"/></returns>
        private static bool IsValid(long a, long b, long c)
        {
            if ((a <= 0 || b <= 0 || c <= 0))
                return false;

            return !((a >= b + c) || (b >= a + c) || (c >= a + b));
        }
    }
}
