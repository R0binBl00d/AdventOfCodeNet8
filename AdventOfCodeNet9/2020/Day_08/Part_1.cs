﻿namespace AdventOfCodeNet9._2020.Day_08
{
  internal class Part_1 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2020/day/8
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