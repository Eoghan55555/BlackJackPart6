using System.Security.Cryptography.X509Certificates;

namespace BlackJack_CA
{
    internal class Program
    {
        static Card Player1 = new Card(); 
        static Card Dealer = new Card();
        static Betting _Player1 = new Betting();
        static int p_num_ofcards = 0;//Count the num of cards a player would have
        static int d_num_ofcards = 0;//Count the num of cards a dealer would have
        static void Main(string[] args)
        {


            //string card = Player1.GetCard();
            //Player1.GetCardValue(card);
            //_Player1.GetName();
            //_Player1.GetTotalBettingChips();
            //Console.WriteLine(_Player1.ToString());
            
            Player1.DeckReshuffle();//Shuffles Deck

            //_Player1.GetName();//Start of the Final Draft
            //_Player1.GetTotalBettingChips();
            int playerhandvalue=PlayBlackJack();
            int dealerhandvalue =DealerPlays();
            GetResult(playerhandvalue, dealerhandvalue);
        }
        static int PlayBlackJack()
        {
            //Variables
            string input = "";
            string lowercaseinput="";

            int TotalHandValue = 0;
;
            //First Draw
            string card = Player1.GetCard();//Gets the card as a string
            int cardValue = Player1.GetCardValue(card);//Turns the string value into a number
            p_num_ofcards++;
            Console.WriteLine($"\nYou have drawn {card} which is worth {cardValue}");

            TotalHandValue += cardValue;
            
            while (lowercaseinput != "stay")
            {
                card= Player1.GetCard();
                cardValue = Player1.GetCardValue(card);
                p_num_ofcards++;
                Console.WriteLine($"\nYou have drawn {card} which is worth {cardValue}");
                
                TotalHandValue+= cardValue;
                Console.WriteLine($"Total is now {TotalHandValue}\n");

                if (TotalHandValue >= 21)
                {
                    break;
                }

                Console.Write("Do you want to stay or hit: ");
                input=Console.ReadLine();
                lowercaseinput = input.ToLower();


            } 
            
            return TotalHandValue;
        }

        static int DealerPlays()
        {
            int totalHandValue = 0;

            while (totalHandValue < 17)
            {
                string card = Dealer.GetCard();//Gets the card as a string
                int cardValue = Dealer.GetCardValue(card);//Turns the string value into a number
                d_num_ofcards++;
                Console.WriteLine($"\nDealer has drawn {card} which is worth {cardValue}");
                totalHandValue+= cardValue;
                Console.WriteLine($"Dealer's Total is now {totalHandValue}\n");
            }
            return totalHandValue;
        }
        static void GetResult(int playerhand,int dealerhand)
        {
            //Loss Scenarios
            if (playerhand > 21) //Player Busts
            {
                _Player1.BetWinning(Betting.Result.Loss); 
            }
            else if (playerhand < dealerhand && dealerhand >= 21) //Dealer is below 22 and has more than the player
            {
                _Player1.BetWinning(Betting.Result.Loss);
            }
            //Win Scenarios
            else if (dealerhand > 21) //Player is Below 22 and Dealer Busts
            {
                _Player1.BetWinning(Betting.Result.Win);
            }
            else if (playerhand > dealerhand) //Player has more than Dealer
            {
                _Player1.BetWinning(Betting.Result.Win);
            }
            //Draw Scenarios
            else if (playerhand == dealerhand) //Player and Dealer has the same amount
            {
                _Player1.BetWinning(Betting.Result.Draw);
            }
            //Player gets BlackJack
            else if (playerhand == 21) //Player gets a natural 21
            {
                _Player1.BetWinning(Betting.Result.BlackJack);
            }
        }
    }
}