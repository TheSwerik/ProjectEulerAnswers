using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0054
    {
        public Problem0054()
        {
            string[] lines = File.ReadAllLines("main\\resources\\p054_poker.txt");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            foreach (string line in lines)
            {
                string[] player1 = sort(line.Substring(0, 15).Split(' '));
                string[] player2 = sort(line.Substring(15).Split(' '));

                int check = checkStraightFlush(player1, player2);
                if (check > 0) result++;
                if (check != 0) continue;

                check = checkFourOfAKind(player1, player2);
                if (check > 0) result++;
                if (check != 0) continue;

                check = checkFullHouse(player1, player2);
                if (check > 0) result++;
                if (check != 0) continue;

                check = checkFlush(player1, player2);
                if (check > 0) result++;
                if (check != 0) continue;

                check = checkStraight(player1, player2);
                if (check > 0) result++;
                if (check != 0) continue;

                check = checkThreeOfAKind(player1, player2);
                if (check > 0) result++;
                if (check != 0) continue;

                check = checkTwoTimesTwoOfAKind(player1, player2);
                if (check > 0) result++;
                if (check != 0) continue;

                check = checkTwoOfAKind(player1, player2);
                if (check > 0) result++;
                if (check != 0) continue;

                if (HighCard(player1, player2))
                {
                    result++;
                    continue;
                }
            }

            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(54, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private int checkTwoTimesTwoOfAKind(string[] player1, string[] player2)
        {
            if (TwoTimesTwoOfAKind(player1) || TwoTimesTwoOfAKind(player2))
            {
                if (TwoTimesTwoOfAKind(player1) && !TwoTimesTwoOfAKind(player2)) return 1;

                if (TwoTimesTwoOfAKind(player1) && TwoTimesTwoOfAKind(player2)
                                                && (player1[1][0] > player2[1][0] || player1[3][0] > player2[3][0]))
                    return 1;

                if (TwoTimesTwoOfAKind(player1) && TwoTimesTwoOfAKind(player2)
                                                && (player1[1][0] == player2[1][0] || player1[3][0] == player2[3][0]))
                    System.Console.WriteLine(player1[0] + "\t" + player1[1] + "\t" + player1[2] + "\t" + player1[3] +
                                             "\t" + player1[4] + "\t" + player2[0] + "\t" + player2[1] + "\t" +
                                             player2[2] + "\t" + player2[3] + "\t" + player2[4]);
            }
            else return 0;

            return -1;
        }

        private bool TwoTimesTwoOfAKind(string[] hand)
        {
            int index = 0;
            for (int i = 0; i < 2; i++)
            {
                if (hand[1 + i][0] == hand[i][0])
                {
                    index = i + 1;
                    break;
                }
            }

            if (index == 0) return false;

            for (int i = index; i < 4; i++)
            {
                if (hand[1 + i][0] == hand[i][0]) return true;
            }

            return false;
        }

        private bool HighCard(string[] player1, string[] player2)
        {
            int max1 = 0;
            for (int i = 4; i > 0; i--)
            {
                if (player1[i] == "") continue;
                int value = parse(player1[i][0]);
                if (value > max1)
                {
                    max1 = value;
                    break;
                }
            }

            int max2 = 0;
            for (int i = 4; i > 0; i--)
            {
                if (player2[i] == "") continue;
                int value = parse(player2[i][0]);
                if (value > max1)
                {
                    max2 = value;
                    break;
                }
            }

            return max1 > max2;
        }

        private int checkTwoOfAKind(string[] player1, string[] player2)
        {
            if (TwoOfAKind(player1) || TwoOfAKind(player1))
            {
                if (TwoOfAKind(player1) && !TwoOfAKind(player2)) return 1;

                if (TwoOfAKind(player1) && TwoOfAKind(player2))
                {
                    int pairValue1 = 0;
                    int pairValue2 = 0;
                    bool first = false;
                    bool second = false;
                    for (int i = 0, j = 0; i < 4 && j < 2; i++)
                    {
                        if (!first && player1[1 + i][0] == player1[i][0])
                        {
                            pairValue1 = parse(player1[i][0]);
                            player1[i] = player1[i + 1] = "";
                            first = true;
                        }

                        if (!second && player2[1 + i][0].Equals(player2[i][0]))
                        {
                            pairValue2 = parse(player2[i][0]);
                            player2[i] = player2[i + 1] = "";
                            second = true;
                        }
                    }

                    if (pairValue1 > pairValue2) return 1;
                    if (pairValue1 < pairValue2) return -1;

                    if (HighCard(player1, player2)) return 1;
                }
            }
            else return 0;

            return -1;
        }

        private int checkThreeOfAKind(string[] player1, string[] player2)
        {
            if (ThreeOfAKind(player1) || ThreeOfAKind(player1))
            {
                if (ThreeOfAKind(player1) && !ThreeOfAKind(player2)) return 1;

                if (ThreeOfAKind(player1) && ThreeOfAKind(player2) &&
                    parse(player1[2][0]) > parse(player2[2][0])) return 1;
            }
            else return 0;

            return -1;
        }

        private int checkFlush(string[] player1, string[] player2)
        {
            if (Flush(player1) || Flush(player1))
            {
                if (Flush(player1) && !Flush(player2)) return 1;

                if (Flush(player1) && Flush(player2) &&
                    HighCard(player1, player2)) return 1;
            }
            else return 0;

            return -1;
        }

        private int checkStraight(string[] player1, string[] player2)
        {
            if (Straight(player1) || Straight(player1))
            {
                if (Straight(player1) && !Straight(player2)) return 1;

                if (Straight(player1) && Straight(player2) &&
                    parse(player1[0][0]) > parse(player2[0][0])) return 1;
            }
            else return 0;

            return -1;
        }

        private int checkFullHouse(string[] player1, string[] player2)
        {
            if (FullHouse(player1) || FullHouse(player1))
            {
                if (FullHouse(player1) && !FullHouse(player2)) return 1;

                if (FullHouse(player1) && FullHouse(player2) &&
                    parse(player1[2][0]) > parse(player2[2][0])) return 1; //TODO
            }
            else return 0;

            return -1;
        }

        private int checkFourOfAKind(string[] player1, string[] player2)
        {
            if (FourOfAKind(player1) || FourOfAKind(player1))
            {
                if (FourOfAKind(player1) && !FourOfAKind(player2)) return 1;

                if (FourOfAKind(player1) && FourOfAKind(player2) &&
                    parse(player1[2][0]) > parse(player2[2][0])) return 1;
            }
            else return 0;

            return -1;
        }

        private int checkStraightFlush(string[] player1, string[] player2)
        {
            if (StraightFlush(player1) || StraightFlush(player1))
            {
                if (StraightFlush(player1) && !StraightFlush(player2))
                {
                    return 1;
                }

                if (StraightFlush(player1) && StraightFlush(player2) &&
                    parse(player1[0][0]) > parse(player2[0][0]))
                {
                    return 1;
                }
            }
            else return 0;

            return -1;
        }

        private int parse(char card)
        {
            if (card <= '9' && card >= '2') return card - 48;
            switch (card)
            {
                case 'T': return 10;
                case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                case 'A': return 14;
            }

            return 0;
        }

        private bool StraightFlush(string[] hand)
        {
            return Straight(hand) && Flush(hand);
        }

        private bool Straight(string[] hand)
        {
            return parse(hand[0][0]) + 1 == parse(hand[1][0]) &&
                   parse(hand[1][0]) + 1 == parse(hand[2][0]) &&
                   parse(hand[2][0]) + 1 == parse(hand[3][0]) &&
                   parse(hand[3][0]) + 1 == parse(hand[4][0]);
        }

        private bool Flush(string[] hand)
        {
            return hand[0][1] == hand[1][1] &&
                   hand[1][1] == hand[2][1] &&
                   hand[2][1] == hand[3][1] &&
                   hand[3][1] == hand[4][1];
        }

        private bool FourOfAKind(string[] hand)
        {
            for (int i = 0; i < 2; i++)
            {
                char c = hand[0 + i][0];
                if (hand[1 + i][0] == c && hand[2 + i][0] == c && hand[3 + i][0] == c) return true;
            }

            return false;
        }

        private bool ThreeOfAKind(string[] hand)
        {
            for (int i = 0; i < 3; i++)
            {
                char c = hand[0 + i][0];
                if (hand[1 + i][0] == c && hand[2 + i][0] == c) return true;
            }

            return false;
        }

        private bool FullHouse(string[] hand)
        {
            return ThreeOfAKind(hand) && TwoOfAKind(hand);
        }

        private bool TwoOfAKind(string[] hand)
        {
            for (int i = 0; i < 4; i++)
            {
                if (hand[1 + i][0] == hand[0 + i][0]) return true;
            }

            return false;
        }

        private string[] sort(string[] hand)
        {
            for (int i = 0; i < 5; i++)
            {
                int index = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (parse(hand[0][0]) > parse(hand[j][0])) index++;
                }

                string help = hand[index];
                hand[index] = hand[0];
                hand[0] = help;
            }

            return hand;
        }
    }
}