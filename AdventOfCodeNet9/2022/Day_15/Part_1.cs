namespace AdventOfCodeNet9._2022.Day_15
{
  internal class Part_1 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2022/day/15
    */
    /// </summary>
    /// <returns>
    /// 
    /// </returns>
    public override string Execute()
    {
      string result = "";
      int totalCount = 0;
      foreach (var line in Lines)
      {
        totalCount++;
      }
      result = totalCount.ToString();
      return result;
    }
  }
}