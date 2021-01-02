using System;
using System.Collections.Generic;
using static GoFishConsoleApp.CardGame;

namespace GoFishConsoleApp
{
    class Program
    {
        static int matched = 0;
        static int playerPoints = 0;
        static int computerPoints = 0;
        
        static void Main(string[] args)
        {
            //string turn = CoinFlip();
            string turn = "player turn";

            do
            {
                switch (turn)
                {

                    case "player turn":
                        Console.WriteLine("Your turn");
                        Console.Write("Press Enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Your cards: \n");
                        ShowHand(yourCards);
                        Console.Write("\n\n\nPick a card: ");
                        if (guess(computerCards, yourCards))
                        {
                            turn = "player turn";
                        }
                        else
                        {
                            Console.WriteLine("Go Fish");
                            turn = "computer turn";
                        }
                        applyPoints(yourCards, playerPoints);
                        Console.WriteLine($"You have {playerPoints} points.");
                        break;

                    case "computer turn":
                        Console.WriteLine("Computer's turn");
                        if (guess(yourCards, computerCards))
                        {
                            turn = "computer turn";
                        }
                        else
                        {
                            Console.WriteLine("Your turn");
                            turn = "player turn";
                        }
                        break;

                    default:
                        break;
                }
            } while (true);


            


            #region Unused Code Ideas

            //v1
            //Determine if a book should be closed i.e. a player has collected all four cards in a book


            /*           foreach (var book in newGame.Books)
                       {
                               matched = 0;
                               for (int i = 0; i < newGame.yourCards.Count; i++)
                               {
                                   if (newGame.yourCards[i].StartsWith(book[0]))
                                   {
                                       matched++;
                                       if (matched == 4)
                                       {
                                           for (int x = 0; x < newGame.yourCards.Count; x++)
                                           {
                                               string whichCard = newGame.yourCards[x];
                                               if (newGame.yourCards[x].StartsWith(book[0]))
                                               {
                                                   book.Add(newGame.yourCards[x]);
                                                   newGame.yourCards.Remove(newGame.yourCards[x]);
                                                   x--;
                                                   matched++;
                                               }
                                               if (matched == 8)
                                               {
                                                   break;
                                               }
                                           }
                                       }
                                       if (matched == 8)
                                       {
                                           break;
                                       }
                                   }
                               }
                           if (matched == 8)
                           {
                               break;
                           }
                       }
           */


            //write content of a list of lists with a for loop

            /*            for (int i = 0; i < newGame.Books.Count; i++)
                        {
                            var book = newGame.Books[i];
                            Console.WriteLine(book[0]);
                        }*/




            //v2
            //Determine if a book should be closed i.e. a player has collected all four cards in a book

            /*for (int i = 0; i < newGame.yourCards.Count; i++)
            {
                string[] cardSplit = newGame.yourCards[i].Split(' ');
                foreach (var book in newGame.Books)
                {
                    if (book.Contains(cardSplit[0]))
                    { 
                        book.Add(newGame.yourCards[i]);
                        newGame.yourCards.RemoveAt(i);
                        i--;
                    }
                }

            }
            foreach (var book in newGame.Books)
            {
                int index = 1;
                if (book.Count < 5 && book.Count > 1)
                {
                    do
                    {
                        newGame.yourCards.Add(book[index]);
                        book.RemoveAt(index);
                    } while (book.Count > 1);
                }
            }*/

            #endregion

            //Test
            //Console.WriteLine($"Books Ace count: {Ace.Count}");
            Console.WriteLine($"yourCards count: {yourCards.Count}");
            foreach (var card in yourCards)
            {
                Console.WriteLine(card);
            }
        }




        static bool checkForPoints(List<string> player)
        {
            foreach (var book in Books)
            {
                matched = 0;
                for (int i = 0; i < player.Count; i++)
                {
                    if (player[i].StartsWith(book[0]))
                    {
                        matched++;

                        if (matched == 4)
                        {
                            for (int x = 0; x < player.Count; x++)
                            {
                                if (player[x].StartsWith(book[0]))
                                {
                                    book.Add(player[x]);
                                    player.Remove(player[x]);
                                    x--;
                                }
                            }
                            Console.WriteLine($"{book[0]} book is closed");
                            return true;
                        } 
                    }
                }
            }
            return false;
        }

        static int applyPoints(List<string> player, int points)
        {
            if (checkForPoints(player) == true)
            {
                return points += 1;
            }
            else
            {
                return 0;
            }
        }

        static bool guess(List<string> player, List<string> guessingPlayer)
        {
            string cardGuessed = Console.ReadLine().ToLower();
            bool isSuccessful = false;
            
            foreach (var book in Books)
            {
                if (cardGuessed == book[0].ToLower())
                {
                    for (int i = 0; i < player.Count; i++)
                    {
                        if (player[i].ToLower().StartsWith(cardGuessed))
                        {
                            guessingPlayer.Add(player[i]);
                            player.RemoveAt(i);
                            i--;
                            isSuccessful = true;        
                        }
                    }
                }
            }
            if (isSuccessful)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        


    }
}
