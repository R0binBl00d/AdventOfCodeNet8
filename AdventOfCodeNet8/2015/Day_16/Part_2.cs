﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCodeNet8._2015.Day_16
{
  internal class Part_2 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2015/day/16
--- Day 16: Aunt Sue ---
Your Aunt Sue has given you a wonderful gift, and you'd like to send her a thank you card. However, there's a small problem: she signed it "From, Aunt Sue".

You have 500 Aunts named "Sue".

So, to avoid sending the card to the wrong person, you need to figure out which Aunt Sue (which you conveniently number 1 to 500, for sanity) gave you the gift. You open the present and, as luck would have it, good ol' Aunt Sue got you a My First Crime Scene Analysis Machine! Just what you wanted. Or needed, as the case may be.

The My First Crime Scene Analysis Machine (MFCSAM for short) can detect a few specific compounds in a given sample, as well as how many distinct kinds of those compounds there are. According to the instructions, these are what the MFCSAM can detect:

children, by human DNA age analysis.
cats. It doesn't differentiate individual breeds.
Several seemingly random breeds of dog: samoyeds, pomeranians, akitas, and vizslas.
goldfish. No other kinds of fish.
trees, all in one group.
cars, presumably by exhaust or gasoline or something.
perfumes, which is handy, since many of your Aunts Sue wear a few kinds.
In fact, many of your Aunts Sue have many of these. You put the wrapping from the gift into the MFCSAM. It beeps inquisitively at you a few times and then prints out a message on ticker tape:

children: 3
cats: 7
samoyeds: 2
pomeranians: 3
akitas: 0
vizslas: 0
goldfish: 5
trees: 3
cars: 2
perfumes: 1
You make a list of the things you can remember about each Aunt Sue. Things missing from your list aren't zero - you simply don't remember the value.

What is the number of the Sue that got you the gift?

Your puzzle answer was 40.

The first half of this puzzle is complete! It provides one gold star: *

--- Part Two ---
As you're about to send the thank you note, something in the MFCSAM's instructions catches your eye. Apparently, it has an outdated retroencabulator, and so the output from the machine isn't exact values - some of them indicate ranges.

In particular, the cats and trees readings indicates that there are greater than that many (due to the unpredictable nuclear decay of cat dander and tree pollen), while the pomeranians and goldfish readings indicate that there are fewer than that many (due to the modial interaction of magnetoreluctance).

What is the number of the real Aunt Sue?
    */
    /// </summary>
    /// <returns>
    /// Your puzzle answer was 241.
    /// </returns>
    public override string Execute()
    {
      string result = "";

      var SueProperties = new Dictionary<int, Dictionary<string, int>>();

      foreach (string line in Lines)
      {
        string tempLine = line;
        tempLine = tempLine.Replace(":", "");
        tempLine = tempLine.Replace(",", "");
        var chunks = tempLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> properties = new Dictionary<string, int>()
        {
          { chunks[2], Int32.Parse(chunks[3]) },
          { chunks[4], Int32.Parse(chunks[5]) },
          { chunks[6], Int32.Parse(chunks[7]) }
        };

        SueProperties.Add(Int32.Parse(chunks[1]), properties);
      }

      var GiftProperties = new Dictionary<string, int>()
      {
        { "children", 3 },
        { "cats", 7 },
        { "samoyeds", 2 },
        { "pomeranians", 3 },
        { "akitas", 0 },
        { "vizslas", 0 },
        { "goldfish", 5 },
        { "trees", 3 },
        { "cars", 2 },
        { "perfumes", 1 }
      };

      var Scores = new Dictionary<int, int>();

      foreach (var sp in SueProperties)
      {
        int totalScore = 0;
        foreach (var kvp in sp.Value)
        {
          switch (kvp.Key)
          {
            case "cats":
            case "trees":
              if (GiftProperties[kvp.Key] < kvp.Value) totalScore++;
              break;
            case "pomeranians":
            case "goldfish":
              if (GiftProperties[kvp.Key] > kvp.Value) totalScore++;
              break;
            default:
              if (GiftProperties[kvp.Key] == kvp.Value) totalScore++;
              break;
          }
        }
        Scores.Add(sp.Key, totalScore);
      }

      var WinnerAunt =
        from s in Scores
        where s.Value == 3
        select s.Key;

      Console.WriteLine("" + WinnerAunt.Count());
      result = WinnerAunt.First().ToString();

      return result;
    }
  }
}