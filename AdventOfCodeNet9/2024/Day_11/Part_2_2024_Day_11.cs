using System.Diagnostics;
using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using AdventOfCodeNet9.Extensions;

namespace AdventOfCodeNet9._2024.Day_11
{
  internal class Part_2_2024_Day_11 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2024/day/11
    --- Day 11: Plutonian Pebbles ---
    The ancient civilization on Pluto was known for its ability to manipulate
    spacetime, and while The Historians explore their infinite corridors, you've
    noticed a strange set of physics-defying stones.
    
    At first glance, they seem like normal stones: they're arranged in a perfectly
    straight line, and each stone has a number engraved on it.
    
    The strange part is that every time you blink, the stones change.
    
    Sometimes, the number engraved on a stone changes. Other times, a stone might
    split in two, causing all the other stones to shift over a bit to make room in
    their perfectly straight line.
    
    As you observe them for a while, you find that the stones have a consistent
    behavior. Every time you blink, the stones each simultaneously change according
    to the first applicable rule in this list:
    
    If the stone is engraved with the number 0, it is replaced by a stone engraved
    with the number 1.
    If the stone is engraved with a number that has an even number of digits, it is
    replaced by two stones. The left half of the digits are engraved on the new
    left stone, and the right half of the digits are engraved on the new right
    stone. (The new numbers don't keep extra leading zeroes: 1000 would become
    stones 10 and 0.)
    If none of the other rules apply, the stone is replaced by a new stone; the old
    stone's number multiplied by 2024 is engraved on the new stone.
    No matter how the stones change, their order is preserved, and they stay on
    their perfectly straight line.
    
    How will the stones evolve if you keep blinking at them? You take a note of the
    number engraved on each stone in the line (your puzzle input).
    
    If you have an arrangement of five stones engraved with the numbers 0 1 10 99
    999 and you blink once, the stones transform as follows:
    
    The first stone, 0, becomes a stone marked 1.
    The second stone, 1, is multiplied by 2024 to become 2024.
    The third stone, 10, is split into a stone marked 1 followed by a stone marked
    0.
    The fourth stone, 99, is split into two stones marked 9.
    The fifth stone, 999, is replaced by a stone marked 2021976.
    So, after blinking once, your five stones would become an arrangement of seven
    stones engraved with the numbers 1 2024 1 0 9 9 2021976.
    
    Here is a longer example:
    
    Initial arrangement:
    125 17
    
    After 1 blink:
    253000 1 7
    
    After 2 blinks:
    253 0 2024 14168
    
    After 3 blinks:
    512072 1 20 24 28676032
    
    After 4 blinks:
    512 72 2024 2 0 2 4 2867 6032
    
    After 5 blinks:
    1036288 7 2 20 24 4048 1 4048 8096 28 67 60 32
    
    After 6 blinks:
    2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2
    In this example, after blinking six times, you would have 22 stones. After
    blinking 25 times, you would have 55312 stones!
    
    Consider the arrangement of stones in front of you. How many stones will you
    have after blinking 25 times?
    
    Your puzzle answer was 203228.
    
    The first half of this puzzle is complete! It provides one gold star: *
    
    --- Part Two ---
    The Historians sure are taking a long time. To be fair, the infinite corridors
    are very large.
    
    How many stones would you have after blinking a total of 75 times?

    */
    /// </summary>
    /// <returns>
    /// (test) 6=> 22
    /// (test) 25=> 55312
    /// 3134 <= 15
    /// 203228 <= 25
    /// 
    /// </returns>
    public override string Execute()
    {
      string result = "";
      long totalCount = 0;

      var stones = Lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).AsInt64List();

      #region skip test

      //int blinkTimes = 6;
     // if (stones.Count < 3) return "Test skipped";

      #endregion
      int blinkTimes = 75;
      int split = 40;

      totalCount = RunSeveralIteration(0, blinkTimes, split, ref stones);

      result = totalCount.ToString();
      return result;
    }

    Int64 RunSeveralIteration(int start, int end, int split, ref List<long> stones)
    {
      int i = 0;
      for (i = start; i < start + split; i++)
      {

        if (i == end)
          break;
        else if (i < split)
        {
          Debug.WriteLine($"Base - Iteration {i}");
        }

        List<long> newStones = new List<long>();

        //for (int sIndex = 0; sIndex < stones.Count; sIndex++)
        //Parallel.ForEach(stones, stone =>
        foreach (var stone in stones)
        {
          if (stone == 0) newStones.Add(1);
          else if (stone.ToString().Length % 2 == 0)
          {
            string strStone = stone.ToString();
            int length = strStone.Length / 2;

            newStones.Add(Int64.Parse(strStone.Substring(0, length)));
            newStones.Add(Int64.Parse(strStone.Substring(length)));
          }
          else
          {
            newStones.Add(2024 * stone);
          }
          //});
        }

        stones.Clear();
        stones = newStones;
        //});
      }

      long totalCount = 0;

      if (i == end)
      {
        totalCount = stones.LongCount();
        stones.Clear();
        //GC.Collect();
        return totalCount;
      }
      else if (i == split)
      {
        while (stones.Count > 0)
        {
          Debug.WriteLine($"{stones.Count}");
          List<long> tempList;
          if (stones.Count > 5)
          {
            tempList = stones[..5];
          }
          else
          {
            tempList = new List<long>(stones);
          }

          totalCount += RunSeveralIteration(split, end, split, ref tempList);
          if (stones.Count > 5) stones.RemoveRange(0, 5);
          else stones.Clear();
        }
        //GC.Collect();
        return totalCount;
      }
      else
      {
        // we should never get here
        Debugger.Break();
        return 0L;
      }
    }
  }
}
