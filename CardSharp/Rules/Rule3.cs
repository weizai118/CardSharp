﻿using System.Collections.Generic;
using System.Linq;

namespace CardSharp.Rules
{
    public class Rule3 : RuleBase
    {
        public override bool IsMatch(List<CardGroup> cards, List<CardGroup> lastCards)
        {
            if (cards.Count != 1) return false;
            var first = cards.First();
            return first.Count == 3 && (lastCards == null || lastCards.First().Amount < first.Amount);
        }

        public override string ToString()
        {
            return "3带0";
        }
    }
}