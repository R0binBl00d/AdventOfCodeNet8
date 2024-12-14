using AdventOfCodeNet9.Extensions;
using System.Diagnostics;

namespace AdventOfCodeNet9._2024.Day_14
{
  internal class Part_2_2024_Day_14 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2024/day/14

        --- Part Two ---
    During the bathroom break, someone notices that these robots seem awfully
    similar to ones built and used at the North Pole. If they're the same type of
    robots, they should have a hard-coded Easter egg: very rarely, most of the
    robots should arrange themselves into a picture of a Christmas tree.
    
    What is the fewest number of seconds that must elapse for the robots to display
    the Easter egg?

    */
    /// </summary>
    /// <returns>
    /// 
    /// </returns>
    public override string Execute()
    {
      string result = "";
      long totalCount = 0;

      //Real(x,y) = (101,103)
      //100 sec -> multiply quadrants

      point testGrid = new point(11, 7);
      point grid = new point(101, 103);

      //Test(x,y) = (11,7)
      if (Lines.Count < 15) return "Skip Test"; // grid = testGrid;

      var robots = new List<(point pos, point vel)>();

      foreach (var line in Lines)
      {
        var chunks = line.Split(new[] { ' ', ',', '=' }, StringSplitOptions.RemoveEmptyEntries);
        robots.Add((
          new point(Int64.Parse(chunks[1]), Int64.Parse(chunks[2])),
          new point(Int64.Parse(chunks[4]), Int64.Parse(chunks[5]))
        ));
      }

      long i = 0;
      do
      {
        //Advance Robots
        foreach (var robot in robots)
        {
          robot.pos.x += robot.vel.x;
          robot.pos.y += robot.vel.y;

          if (robot.pos.x < 0) robot.pos.x += grid.x;
          if (robot.pos.x >= grid.x) robot.pos.x -= grid.x;
          if (robot.pos.y < 0) robot.pos.y += grid.y;
          if (robot.pos.y >= grid.y) robot.pos.y -= grid.y;
        }

        i++;
      } while (NotAllConnected(ref robots));
      totalCount = i;

      DebugDrawMap(ref robots, ref grid);

      result = totalCount.ToString();
      return result;
    }

    private bool NotAllConnected(ref List<(point pos, point vel)> robots)
    {
      foreach (var robot in robots)
      {
        if ( // this guy has a neigbour, good chance this is a xmas tree after all ??
          robots.Exists(x => x.pos.x == robot.pos.x + 1 && x.pos.y == robot.pos.y /*right*/) ||
          robots.Exists(x => x.pos.x == robot.pos.x - 1 && x.pos.y == robot.pos.y /*right*/) ||
          robots.Exists(x => x.pos.x == robot.pos.x && x.pos.y + 1 == robot.pos.y /*right*/) ||
          robots.Exists(x => x.pos.x == robot.pos.x && x.pos.y - 1 == robot.pos.y /*right*/))
        {
          continue;
        }
        else
        {
          return true; // NOT all connected
        }
      }

      return false;
    }

    private void DebugDrawMap(ref List<(point pos, point vel)> robots, ref point grid)
    {
      Debug.WriteLine("");
      Debug.WriteLine("");
      for (int y = 0; y < grid.y; y++)
      {
        for (int x = 0; x < grid.x; x++)
        {
          int count = robots.Where(r => r.pos.x == x && r.pos.y == y).Count();
          Debug.Write((count > 0) ? $"{count}" : ".");
        }

        Debug.WriteLine("");
      }

      Debug.WriteLine("");
      Debug.WriteLine("");
    }
  }
}