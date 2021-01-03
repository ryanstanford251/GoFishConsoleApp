using System;
using System.Collections.Generic;
using System.Text;


namespace GoFishConsoleApp
{
    static class CardGame
    {
        static public List<string> deckOfCards = new List<string>();
        static public List<string> yourCards { get; private set; } = new List<string>();
        static public List<string> computerCards { get; private set; } = new List<string>();
        static public List<string> Books = new List<string>();

        static Random random = new Random();
        

        


        static CardGame()
        {
            setUp();
            //dealCards(7, yourCards);
            //dealCards(7, computerCards);

            //test
            yourCards.Add("Two of Hearts");
            yourCards.Add("Ace of Hearts");
            yourCards.Add("Three of Clubs");
            yourCards.Add("Ace of Spades");
            yourCards.Add("Jack of Diamonds");
            yourCards.Add("Ace of Diamonds");
            yourCards.Add("Ace of Clubs");

            computerCards.Add("Two of Diamonds");
            computerCards.Add("King of Spades");
            computerCards.Add("Queen of Diamons");
            computerCards.Add("Two of Spades");
            computerCards.Add("Five of Clubs");
            computerCards.Add("Seven of Hearts");
            computerCards.Add("Four of clubs");
        }
        static public void setUp()
        {
            deckOfCards.Add("Ace of Hearts");
            deckOfCards.Add("Ace of Diamonds");
            deckOfCards.Add("Ace of Clubs");
            deckOfCards.Add("Ace of Spades");
            deckOfCards.Add("Two of Hearts");
            deckOfCards.Add("Two of Diamonds");
            deckOfCards.Add("Two of Clubs");
            deckOfCards.Add("Two of Spades");
            deckOfCards.Add("Three of Hearts");
            deckOfCards.Add("Three of Diamonds");
            deckOfCards.Add("Three of Clubs");
            deckOfCards.Add("Three of Spades");
            deckOfCards.Add("Four of Hearts");
            deckOfCards.Add("Four of Diamonds");
            deckOfCards.Add("Four of Clubs");
            deckOfCards.Add("Four of Spades");
            deckOfCards.Add("Five of Hearts");
            deckOfCards.Add("Five of Diamonds");
            deckOfCards.Add("Five of Clubs");
            deckOfCards.Add("Five of Spades");
            deckOfCards.Add("Six of Hearts");
            deckOfCards.Add("Six of Diamonds");
            deckOfCards.Add("Six of Clubs");
            deckOfCards.Add("Six of Spades");
            deckOfCards.Add("Seven of Hearts");
            deckOfCards.Add("Seven of Diamonds");
            deckOfCards.Add("Seven of Clubs");
            deckOfCards.Add("Seven of Spades");
            deckOfCards.Add("Eight of Hearts");
            deckOfCards.Add("Eight of Diamonds");
            deckOfCards.Add("Eight of Clubs");
            deckOfCards.Add("Eight of Spades");
            deckOfCards.Add("Nine of Hearts");
            deckOfCards.Add("Nine of Diamonds");
            deckOfCards.Add("Nine of Clubs");
            deckOfCards.Add("Nine of Spades");
            deckOfCards.Add("Ten of Hearts");
            deckOfCards.Add("Ten of Diamonds");
            deckOfCards.Add("Ten of Clubs");
            deckOfCards.Add("Ten of Spades");
            deckOfCards.Add("Jack of Hearts");
            deckOfCards.Add("Jack of Diamonds");
            deckOfCards.Add("Jack of Clubs");
            deckOfCards.Add("Jack of Spades");
            deckOfCards.Add("Queen of Hearts");
            deckOfCards.Add("Queen of Diamonds");
            deckOfCards.Add("Queen of Clubs");
            deckOfCards.Add("Queen of Spades");
            deckOfCards.Add("King of Hearts");
            deckOfCards.Add("King of Diamonds");
            deckOfCards.Add("King of Clubs");
            deckOfCards.Add("King of Spades");

            List<string> Ace = new List<string>();
            List<string> Two = new List<string>();
            List<string> Three = new List<string>();
            List<string> Four = new List<string>();
            List<string> Five = new List<string>();
            List<string> Six = new List<string>();
            List<string> Seven = new List<string>();
            List<string> Eight = new List<string>();
            List<string> Nine = new List<string>();
            List<string> Ten = new List<string>();
            List<string> Jack = new List<string>();
            List<string> Queen = new List<string>();
            List<string> King = new List<string>();

            Books.Add("Ace");
            Books.Add("Two");
            Books.Add("Three");
            Books.Add("Four");
            Books.Add("Five");
            Books.Add("Six");
            Books.Add("Seven");
            Books.Add("Eight");
            Books.Add("Nine");
            Books.Add("Ten");
            Books.Add("Jack");
            Books.Add("Queen");
            Books.Add("King");


            

        }
        static public string CoinFlip()
        {
            int flip = random.Next(0, 2);
            if (flip == 0)
            {
                return "player turn";
            }
            else if (flip == 1)
            {
                return "computer turn";
            }
            else
            {
                return string.Empty;
            }
        }

        static private void dealCards(int numberOfCards, List<string> player)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                int cardIndex = random.Next(1, deckOfCards.Count);
                player.Add(deckOfCards[cardIndex]);
                deckOfCards.Remove(deckOfCards[cardIndex]);
                
            }
        }

        static public void ShowHand(List<string> player)
        {
            foreach (var card in player)
            {
                Console.WriteLine(card);
            }
        }

        static public void DrawCard(List<string> player)
        {
            int index = random.Next(1, deckOfCards.Count);
            string cardDrawn = deckOfCards[index];
            player.Add(cardDrawn);
            deckOfCards.Remove(cardDrawn);
        }

        static public void DrawCard(List<string> player, int numberOfCards)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                int index = random.Next(1, deckOfCards.Count);
                string cardDrawn = deckOfCards[index];
                player.Add(cardDrawn);
                deckOfCards.Remove(cardDrawn);
            }

        }

    }
}
