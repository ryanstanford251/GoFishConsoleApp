using System;
using System.Collections.Generic;
using static GoFishConsoleApp.CardGame;

namespace GoFishConsoleApp
{
    class Program
    {
        static int matched = 0;
        static int points = 0;
        
        static void Main(string[] args)
        {

            //setUp();

            applyPoints();
            Console.WriteLine(points);


            /*Console.WriteLine("Player1 Cards:\n");
            newGame.ShowHand(newGame.yourCards);
            Console.WriteLine("\n\nPlayer2 Cards:\n");
            newGame.ShowHand(newGame.computerCards);

            Console.WriteLine("\n\n\ndeckOfCards count");
            Console.WriteLine(newGame.deckOfCards.Count);

            newGame.DrawCard(newGame.yourCards);

            Console.WriteLine("\n\n\ndeckOfCards count");
            Console.WriteLine(newGame.deckOfCards.Count);

            Console.WriteLine("\n\n\nyourCards count");
            Console.WriteLine(newGame.yourCards.Count);*/




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




        static bool checkForPoints()
        {
            foreach (var book in Books)
            {
                matched = 0;
                for (int i = 0; i < yourCards.Count; i++)
                {
                    if (yourCards[i].StartsWith(book[0]))
                    {
                        matched++;

                        if (matched == 4)
                        {
                            for (int x = 0; x < yourCards.Count; x++)
                            {
                                if (yourCards[x].StartsWith(book[0]))
                                {
                                    book.Add(yourCards[x]);
                                    yourCards.Remove(yourCards[x]);
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

        static int applyPoints()
        {
            if (checkForPoints() == true)
            {
                return points += 1;
            }
            else
            {
                return 0;
            }
        }

        


    }
}
