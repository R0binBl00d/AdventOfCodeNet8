using System.Diagnostics;

namespace AdventOfCodeNet9._2023.Day_07
{
  internal class Part_1_2023_Day_07 : Days
  {
    /// <summary>
    /*
    https://adventofcode.com/2023/day/7
    --- Day 7: Camel Cards ---
    Your all-expenses-paid trip turns out to be a one-way, five-minute ride in an
    airship. (At least it's a cool airship!) It drops you off at the edge of a vast
    desert and descends back to Island Island.
    
    "Did you bring the parts?"
    
    You turn around to see an Elf completely covered in white clothing, wearing
    goggles, and riding a large camel.
    
    "Did you bring the parts?" she asks again, louder this time. You aren't sure
    what parts she's looking for; you're here to figure out why the sand stopped.
    
    "The parts! For the sand, yes! Come with me; I will show you." She beckons you
    onto the camel.
    
    After riding a bit across the sands of Desert Island, you can see what look
    like very large rocks covering half of the horizon. The Elf explains that the
    rocks are all along the part of Desert Island that is directly above Island
    Island, making it hard to even get there. Normally, they use big machines to
    move the rocks and filter the sand, but the machines have broken down because
    Desert Island recently stopped receiving the parts they need to fix the
    machines.
    
    You've already assumed it'll be your job to figure out why the parts stopped
    when she asks if you can help. You agree automatically.
    
    Because the journey will take a few days, she offers to teach you the game of
    Camel Cards. Camel Cards is sort of similar to poker except it's designed to be
    easier to play while riding a camel.
    
    In Camel Cards, you get a list of hands, and your goal is to order them based
    on the strength of each hand. A hand consists of five cards labeled one of A,
    K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, or 2. The relative strength of each card
    follows this order, where A is the highest and 2 is the lowest.
    
    Every hand is exactly one type. From strongest to weakest, they are:
    
    Five of a kind, where all five cards have the same label: AAAAA
    Four of a kind, where four cards have the same label and one card has a
    different label: AA8AA
    Full house, where three cards have the same label, and the remaining two cards
    share a different label: 23332
    Three of a kind, where three cards have the same label, and the remaining two
    cards are each different from any other card in the hand: TTT98
    Two pair, where two cards share one label, two other cards share a second
    label, and the remaining card has a third label: 23432
    One pair, where two cards share one label, and the other three cards have a
    different label from the pair and each other: A23A4
    High card, where all cards' labels are distinct: 23456
    Hands are primarily ordered based on type; for example, every full house is
    stronger than any three of a kind.
    
    If two hands have the same type, a second ordering rule takes effect. Start by
    comparing the first card in each hand. If these cards are different, the hand
    with the stronger first card is considered stronger. If the first card in each
    hand have the same label, however, then move on to considering the second card
    in each hand. If they differ, the hand with the higher second card wins;
    otherwise, continue with the third card in each hand, then the fourth, then the
    fifth.
    
    So, 33332 and 2AAAA are both four of a kind hands, but 33332 is stronger
    because its first card is stronger. Similarly, 77888 and 77788 are both a full
    house, but 77888 is stronger because its third card is stronger (and both hands
    have the same first and second card).
    
    To play Camel Cards, you are given a list of hands and their corresponding bid
    (your puzzle input). For example:
    
    32T3K 765
    T55J5 684
    KK677 28
    KTJJT 220
    QQQJA 483
    This example shows five hands; each hand is followed by its bid amount. Each
    hand wins an amount equal to its bid multiplied by its rank, where the weakest
    hand gets rank 1, the second-weakest hand gets rank 2, and so on up to the
    strongest hand. Because there are five hands in this example, the strongest
    hand will have rank 5 and its bid will be multiplied by 5.
    
    So, the first step is to put the hands in order of strength:
    
    32T3K is the only one pair and the other hands are all a stronger type, so it
    gets rank 1.
    KK677 and KTJJT are both two pair. Their first cards both have the same label,
    but the second card of KK677 is stronger (K vs T), so KTJJT gets rank 2 and
    KK677 gets rank 3.
    T55J5 and QQQJA are both three of a kind. QQQJA has a stronger first card, so
    it gets rank 5 and T55J5 gets rank 4.
    Now, you can determine the total winnings of this set of hands by adding up the
    result of multiplying each hand's bid with its rank (765 * 1 + 220 * 2 + 28 * 3
    + 684 * 4 + 483 * 5). So the total winnings in this example are 6440.
    
    Find the rank of every hand in your set. What are the total winnings?

    */
    /// </summary>
    /// <returns>
    /// 248217452
    /// </returns>
    public override string Execute()
    {
      string result = "";

      var cards = new SortedDictionary<int, Hand>();

      foreach (var line in Lines)
      {
        var chunks = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var hand = new Hand(chunks[0].Trim(), Int32.Parse(chunks[1]));

        if (cards.ContainsKey(hand.Score))
        {
          Debugger.Break();
        }
        else
        {
          cards.Add(hand.Score, hand);
        }
      }

      int totalWin = 0;

      int rank = 1;
      foreach (var game in cards)
      //  Parallel.ForEach(cards, (game) =>
      {
        game.Value.Rank = rank++;
        totalWin += game.Value.Rank * game.Value.Bid;
      }
      //  );

      result = totalWin.ToString();
      return result;
    }

    static Dictionary<char, int> cardScores = new Dictionary<char, int>
    {
        { 'A', 14 }, { 'K', 13 }, { 'Q', 12 }, { 'J', 11 }, { 'T', 10 },
        { '9', 9 }, { '8', 8 }, { '7', 7 }, { '6', 6 }, { '5', 5 },
        { '4', 4 }, { '3', 3 }, { '2', 2 }
    };

    private class Hand
    {
      public string Cards { get; private set; }
      public string HandType { get; private set; }
      public int Score { get; private set; }
      public int Bid { get; private set; }
      public int Rank { get; set; }

      public Hand(string hand, int bid)
      {
        Cards = hand;
        Bid = bid;
        // HandType is done in CalcPokerHand 
        Score = CalcPokerHand(hand);

        // Rank .. tbd
      }

      private int CalcPokerHand(string hand)
      {
        var counts = hand.GroupBy(c => c)
                         .Select(group => new { Card = group.Key, Count = group.Count() })
                         .OrderByDescending(c => c.Count);

        int handScore = GetCardScore(hand);
        int score = 0;

        if (counts.Any(c => c.Count == 5))
        {
          HandType = "Five of a Kind";
          score = 0x600000 + handScore;
        }
        else if (counts.Any(c => c.Count == 4))
        {
          HandType = "Quad";
          score = 0x500000 + handScore;
        }
        else if (counts.Any(c => c.Count == 3) && counts.Any(c => c.Count == 2))
        {
          HandType = "Full House";
          score = 0x400000 + handScore;
        }
        else if (counts.Any(c => c.Count == 3))
        {
          HandType = "Three of a Kind";
          score = 0x300000 + handScore;
        }
        else if (counts.Count(c => c.Count == 2) == 2)
        {
          HandType = "Two Pairs";
          score = 0x200000 + handScore;
        }
        else if (counts.Any(c => c.Count == 2))
        {
          HandType = "One Pair";
          score = 0x100000 + handScore;
        }
        else
        {
          HandType = "High Card";
          score = handScore;
        }

        Debugger.Log(1, "card", String.Format("\nScore of '{0:X6}' Cards:'{1}' HandType '{2}'\n", score, hand, HandType));
        return score;
      }

      private int GetCardScore(string hand)
      {
        int score = 0;
        int pow = 0;
        for (int i = hand.Length - 1; i >= 0; i--)
        {
          score += cardScores[hand[i]] * (int)Math.Pow(16, pow++);
        }
        return score;
      }
    }
  }
}
