namespace AdventOfCodeNet9._2021.Day_23
{
  internal class Part_1 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2021/day/23
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