﻿namespace AdventOfCodeNet9._2022.Day_17
{
  internal class Part_2 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2022/day/17
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