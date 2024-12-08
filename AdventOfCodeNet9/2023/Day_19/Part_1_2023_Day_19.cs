namespace AdventOfCodeNet9._2023.Day_19
{
  internal class Part_1_2023_Day_19 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2023/day/19
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
      //   with the content of the Test-Example-Input_2023_Day_19.txt already stored in "Lines"
      //
      // Second -> THE REAL TEST !! <-
      // with the content of the Input_2023_Day_19.txt already stored in "Lines"
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
