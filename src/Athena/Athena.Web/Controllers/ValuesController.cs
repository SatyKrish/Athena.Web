using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;

namespace Athena.Web.Controllers
{
    [Route("api/[action]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Returns the token.
        /// </summary>
        /// <returns>The token.</returns>
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
        // POST api/Fibonacci
        [HttpGet]
        public IActionResult Fibonacci(int n)
        {
            if (n <= 0)
                return BadRequest("Error");

            return Ok(GetFibonacci(n));
        }

        /// <summary>
        /// Returns the type of triangle given the lengths of its sides. 
        /// </summary>
        /// <param name="a">The length of side a.</param>
        /// <param name="b">The length of side b.</param>
        /// <param name="c">The length of side c.</param>
        /// <returns>The type of triangle.</returns>
        // PUT api/TriangleType
        [HttpGet]
        public IActionResult TriangleType(int a, int b, int c)
        {
            if ((a <= 0 || b <= 0 || c <= 0))
                return BadRequest("Error");
            if ((a == b) && (a == c))
                return Ok("Equilateral");
            else if ((a == b) || (a == c) || (b == c))
                return Ok("Isosceles");
            else
                return Ok("Scalene");
        }

        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <param name="sentence">The sentence.</param>
        /// <returns>The reversed words.</returns>
        // GET api/ReverseWords
        [HttpGet]
        public IActionResult ReverseWords(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                return BadRequest("Error");
            }

            var regex = new Regex(@"\s+");
            var words = regex.Split(sentence);
            var reversedWords = words.Select(x => GetReversedWord(x));
            return Ok(string.Join(" ", reversedWords));
        }        

        /// <summary>
        /// Get the fibonacci number for a given index.
        /// </summary>
        /// <param name="n">The index.</param>
        /// <returns>The fibonacci number.</returns>
        private static int GetFibonacci(int n)
        {
            if (n <= 1)
                return n;

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }

        /// <summary>
        /// Gets the reverse of a given word
        /// </summary>
        /// <param name="word">The input word.</param>
        /// <returns>The reversed word.</returns>
        private static string GetReversedWord(string word)
        {
            return new string(word.ToCharArray().Reverse().ToArray());
        }
    }
}
