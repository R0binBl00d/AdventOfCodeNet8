namespace AdventOfCodeNet9._2016.Day_06
{
  internal class Part_2_2016_Day_06 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2016/day/6
    --- Day 6: Signals and Noise ---
    Something is jamming your communications with Santa. Fortunately, your signal is only partially jammed, and protocol in situations like this is to switch to a simple repetition code to get the message through.

    In this model, the same message is sent repeatedly. You've recorded the repeating message signal (your puzzle input), but the data seems quite corrupted - almost too badly to recover. Almost.

    All you need to do is figure out which character is most frequent for each position. For example, suppose you had recorded the following messages:

    eedadn
    drvtee
    eandsr
    raavrd
    atevrs
    tsrnev
    sdttsa
    rasrtv
    nssdts
    ntnada
    svetve
    tesnvt
    vntsnd
    vrdear
    dvrsen
    enarar
    The most common character in the first column is e; in the second, a; in the third, s, and so on. Combining these characters returns the error-corrected message, easter.

    Given the recording in your puzzle input, what is the error-corrected version of the message being sent?

    Your puzzle answer was qqqluigu.

    The first half of this puzzle is complete! It provides one gold star: *

    --- Part Two ---
    Of course, that would be the message - if you hadn't agreed to use a modified repetition code instead.

    In this modified code, the sender instead transmits what looks like random data, but for each character, 
    the character they actually want to send is slightly less likely than the others. 
    Even after signal-jamming noise, 
    you can look at the letter distributions in each column and choose the least common letter to 
    reconstruct the original message.

    In the above example, 
    the least common character in the first column is a; 
    in the second, d, and so on. 
    
    Repeating this process for the remaining characters produces the original message, advent.

    Given the recording in your puzzle input and this new decoding methodology, 
    what is the original message that Santa is trying to send?    
    */
    /// </summary>
    /// <returns>
    /// Your puzzle answer was lsoypmia.
    /// </returns>
    public override string Execute()
    {
      string result = "";

      List<List<char>> characters = new List<List<char>>();
      int lineLength = Lines[0].Length;

      char[] resultChars = new char[lineLength];

      for (int i = 0; i < lineLength; i++)
      {
        characters.Add(new List<char>());
      }

      foreach (var line in Lines)
      {
        for (int i = 0; i < lineLength; i++)
        {
          characters[i].Add(line[i]);
        }
      }

      for (int i = 0; i < lineLength; i++)
      {
        var distOrderedChars = characters[i]
          .Where(x => (int)x >= (int)'a' && (int)x <= (int)'z')
          .Distinct().OrderBy(c => (int)c);

        var list = new List<KeyValuePair<int, char>>();
        foreach (char c in distOrderedChars)
        {
          list.Add(new KeyValuePair<int, char>(characters[i].Count(x => x == c), c));
        }

        resultChars[i] = list.OrderBy(x => x.Key).First().Value;
      }

      result = new string(resultChars);
      return result;
    }
  }
}
