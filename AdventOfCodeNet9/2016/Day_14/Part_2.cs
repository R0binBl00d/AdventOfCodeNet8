namespace AdventOfCodeNet9._2016.Day_14
{
  internal class Part_2 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2016/day/14
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