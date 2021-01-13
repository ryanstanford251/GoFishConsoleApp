using System;
using System.Collections.Generic;
using static GoFishConsoleApp.CardGame;

namespace GoFishConsoleApp
{
    class Program
    {
        static int yourPoints = 0;
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
                        if (yourCards.Count > 0)
                        {
                            Console.WriteLine("Your cards: \n");
                        }
                        else
                        {
                            DrawCard(yourCards);
                        }
                            ShowHand(yourCards);
                        Console.Write("\n\n\nPick a card: ");
                        if (guess(computerCards, yourCards))
                        {
                            Console.WriteLine("Good guess");
                            Console.ReadLine();
                            Console.Clear();
                            turn = "player turn";
                        }
                        else
                        {
                            Console.WriteLine("Go Fish");
                            DrawCard(yourCards);
                            showCardDrawn();
                            turn = "computer turn";
                            Console.ReadLine();
                            Console.Clear();
                        }
                        yourPoints += applyPoints(yourCards, yourPoints);

                        displayPoints(yourPoints, "Player");
                        displayPoints(computerPoints, "Computer");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "computer turn":
                        Console.WriteLine("Computer's turn");
                        if (computerCards.Count < 1)
                        {
                            DrawCard(computerCards);
                        }
                        //test
                        Console.WriteLine("Computer Cards");
                        ShowHand(computerCards);


                        if (computerGuess())
                        {
                            Console.WriteLine("Computer guess successful");
                            turn = "computer turn";
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Computer guessed incorrectly. \n");
                            Console.ReadLine();
                            Console.Clear();
                            DrawCard(computerCards);
                            turn = "player turn";
                        }
                        computerPoints += applyPoints(computerCards, computerPoints);
                        displayPoints(yourPoints, "Player");
                        displayPoints(computerPoints, "Computer");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            } while (deckOfCards.Count > 0 && yourCards.Count > 0 && computerCards.Count > 0);


            playAgain();


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


            //Test
            //Console.WriteLine($"Books Ace count: {Ace.Count}");
            Console.WriteLine($"yourCards count: {yourCards.Count}");
            foreach (var card in yourCards)
            {
                Console.WriteLine(card);
            }
        }

            #endregion



        static bool checkForPoints(List<string> player)
        {
            foreach (var book in Books)
            {
                int matched = 0;
                for (int i = 0; i < player.Count; i++)
                {
                    if (player[i].StartsWith(book))
                    {
                        matched++;

                        if (matched == 4)
                        {
                            for (int x = 0; x < player.Count; x++)
                            {
                                if (player[x].StartsWith(book))
                                {
                                    //Books.Add(player[x]);
                                    Books.Remove(book);
                                    player.Remove(player[x]);
                                    x--;
                                }
                            }
                            Console.WriteLine($"{book} book is closed");
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

        static string validateGuess()
        {
            bool cardInHand = false;

            while (!cardInHand)
            {
                string cardGuessed = Console.ReadLine().ToLower();
                Console.WriteLine();

                foreach (var card in yourCards)
                {
                    if (card.ToLower().StartsWith(cardGuessed))
                    {
                        cardInHand = true;
                        return cardGuessed;
                    }   
                }

                Console.Write("Card not in hand. \nPick another card: ");
            }
            return null;


        }

        static bool guess(List<string> player, List<string> guessingPlayer)
        {
            bool isSuccessful = false;
            string cardGuessed = validateGuess();

            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].ToLower().StartsWith(cardGuessed))
                {
                    Console.WriteLine($"Card added: {player[i]}");
                    guessingPlayer.Add(player[i]);
                    player.RemoveAt(i);
                    i--;
                    isSuccessful = true;        
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


        static bool computerGuess()
        {
            bool isSuccessful = false;
            Random random = new Random();
            int randomCard = random.Next(0, computerCards.Count);
            string[] pickedCard = computerCards[randomCard].Split(" ");

            Console.WriteLine($"computer guess: {pickedCard[0]}");

            for (int i = 0; i < yourCards.Count; i++)
            {
                if (yourCards[i].StartsWith(pickedCard[0]))
                {
                    isSuccessful = true;
                    computerCards.Add(yourCards[i]);
                    yourCards.RemoveAt(i);
                    i--;
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


        static void displayPoints(int points, string player)
        {
            if (points == 1)
            {
                Console.WriteLine($"{player} has {points} point.");
            }
            else
            {
                Console.WriteLine($"{player} has {points} points.");
            }
        }

        static void showCardDrawn()
        {
            int cardCount = yourCards.Count;
            Console.WriteLine($"You drew a: {yourCards[cardCount - 1]}");
        }

        static void chooseWinner()
        {
            if (yourPoints > computerPoints)
            {
                Console.WriteLine("YOU WIN!!!");
            }
            else
            {
                Console.WriteLine("You Lose...");
            }
        }

        


    }
}
