﻿using System;
using System.Collections.Generic;
using static Cards.CardGame;

namespace GoFishConsoleApp
{
    class Program
    {
        static int yourPoints = 0;
        static int computerPoints = 0;


        static void Main(string[] args)
        {
            do
            {

                //string turn = CoinFlip();

                //test code
                string turn = "player turn";
                DealCards(7, yourCards);
                DealCards(7, computerCards);

                

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
                            if (yourCards.Count == 0 && deckOfCards.Count == 0)
                            {
                                turn = "computer turn";
                            }
                            else if (yourCards.Count == 0)
                            {
                                DrawCard(yourCards);
                                turn = "computer turn";
                            }
                            else
                            {
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
                            }

                            yourPoints = applyPoints(yourCards, yourPoints);
                            displayPoints(yourPoints, "Player");
                            displayPoints(computerPoints, "Computer");
                            Console.WriteLine("\n\nClosed Books:");
                            showClosedBooks();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case "computer turn":
                            Console.WriteLine("Computer's turn\n");
                            if (computerCards.Count == 0 && deckOfCards.Count == 0)
                            {
                                turn = "player turn";
                            }
                            else if (computerCards.Count == 0)
                            {
                                DrawCard(computerCards);
                                turn = "player turn";
                            }
                            else
                            {
                                //test
                                Console.WriteLine("Computer Cards\n");
                                ShowHand(computerCards);
                                Console.WriteLine();


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
                            }
                            computerPoints = applyPoints(computerCards, computerPoints);
                            displayPoints(yourPoints, "Player");
                            displayPoints(computerPoints, "Computer");
                            Console.WriteLine("\n\nClosed Books:");
                            showClosedBooks();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        default:
                            break;
                    }
                } while (deckOfCards.Count > 0 || yourCards.Count > 0 || computerCards.Count > 0);

                chooseWinner();

            } while (playAgain());








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
                                        player.Remove(player[x]);
                                        x--;
                                    }
                                }
                                Books.Remove(book);
                                closedBooks.Add(book);
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
                    return points += 0;
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
                        if (card.ToLower().StartsWith(cardGuessed) && cardGuessed != "")
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

            static void showClosedBooks()
            {
                closedBooks.Sort();
                foreach (var book in closedBooks)
                {
                    Console.WriteLine(book);
                }
            }




        }
    }
}
