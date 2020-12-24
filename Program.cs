﻿using System;
using System.Collections.Generic;

namespace GoFishConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CardGame newGame = new CardGame();
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

            int matched = 0;

            foreach (var book in newGame.Books)
            {
                while (matched != 4)
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
                                    
                                    }
                                }
                            }
                        }
                    }
                }
            }




            for (int i = 0; i < newGame.Books.Count; i++)
            {
                Console.WriteLine(newGame.Books[i]);
            }




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



            Console.WriteLine($"Books Ace count: {newGame.Ace.Count}");
            Console.WriteLine($"yourCards count: {newGame.yourCards.Count}");
            foreach (var card in newGame.yourCards)
            {
                Console.WriteLine(card);
            }

            

        }
    }
}
