namespace AdventOfCodeNet9._2018.Day_16
{
  internal class Part_2 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2018/day/16
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