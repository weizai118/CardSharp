﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardSharp
{
    public static class StringExtensions
    {
        public static string AddNewLine(this string source)
        {
            source += Environment.NewLine;
            return source;
        }

        public static bool IsValidCardString(this string source)
        {
            return Regex.IsMatch(source, "([2-9]|10|A|王|鬼)*");
        }

        public static IEnumerable<Card> ToCards(this string source)
        {
            const int px = 3;
            for (var index = 0; index < source.Length; index++) {
                var chara = source[index];
                if (int.TryParse(chara.ToString(), out var num)) {
                    if (num >= 3 && num <= 9) {
                        yield return new Card(num - px);
                        continue;

                    } else if (num == 1) {
                        index++;
                        yield return new Card(Constants.Cards.C10);
                        continue;
                    }
                }

                switch (chara) {
                    case 'J':
                        yield return new Card(Constants.Cards.CJ);
                        continue;
                    case 'Q':
                        yield return new Card(Constants.Cards.CQ);
                        continue;
                    case 'K':
                        yield return new Card(Constants.Cards.CK);
                        continue;
                    case 'A':
                        yield return new Card(Constants.Cards.CA);
                        continue;
                    case '2':
                        yield return new Card(Constants.Cards.C2);
                        continue;
                    case '鬼':
                        yield return new Card(Constants.Cards.CGhost);
                        continue;
                    case '王':
                        yield return new Card(Constants.Cards.CKing);
                        continue;
                }
            }
        }
    }
}
