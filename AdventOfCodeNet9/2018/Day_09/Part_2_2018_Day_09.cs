namespace AdventOfCodeNet9._2018.Day_09
{
  internal class Part_2_2018_Day_09 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2018/day/9
    */
    /// </summary>
    /// <returns>
    /// 
    /// </returns>
    public override string Execute()
    {
      string result = "";
      int totalCount = 0;

      //
      // Automatically imported Text !!
      //
      // This code is running twice:
      //
      // First (is a try run, no-one really cares if it works)
      //   with the content of the Test-Example-Input_2018_Day_09.txt already stored in "Lines"
      //
      // Second -> THE REAL TEST !! <-
      // with the content of the Input_2018_Day_09.txt already stored in "Lines"
      //
      foreach (var line in Lines)
      {
        totalCount++;
      }
      result = totalCount.ToString();
      return result;
    }
  }
}
