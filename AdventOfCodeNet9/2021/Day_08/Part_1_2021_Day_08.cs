namespace AdventOfCodeNet9._2021.Day_08
{
  internal class Part_1_2021_Day_08 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2021/day/8
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
      //   with the content of the Test-Example-Input_2021_Day_08.txt already stored in "Lines"
      //
      // Second -> THE REAL TEST !! <-
      // with the content of the Input_2021_Day_08.txt already stored in "Lines"
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
