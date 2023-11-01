using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_CA
{
    internal class Betting
    {
        public enum Result { BlackJack, Win, Draw, Loss } //Enum for each scenario in BlackJack
        
        private double _bettingChips;
        private string _name;
        public double BetValue 
        { 
            get;
            set; 
        }
        public double BettingChips
        {
      
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public Betting()
        {

        }
        //Way of getting the remaing chips after inputting the BetValue.
        public double BetCalc() //Calculate 
        {
            if (BetValue >= BettingChips) //To avoid going into negative chips
            {
                BetValue = BettingChips;
                BettingChips = 0;
            }
            else if (BetValue < BettingChips)
            {
                BettingChips = BettingChips - BetValue;
            }
            return BettingChips;
        }
        public void BetWinning(Result match)
        {
            if (match == Result.BlackJack) //Scenario when player gets BlackJack
            {
                BetValue = BetValue * 2.5;
                BettingChips = BettingChips + BetValue;
            }
            else if (match == Result.Win) //Scenario when player wins
            {
                BetValue = BetValue * 2;
                BettingChips = BettingChips + BetValue;
            }
            else if (match == Result.Draw) //Scenario when player draws
            {
                BettingChips += BetValue;
            }
            else if (match == Result.Loss) //Scenario when player loses or busts
            {
                BettingChips -= BetValue;
            }
        }
        public string GetName() //Gets the username of the player
        {
            Console.Write("Enter Name: ");
            _name = Console.ReadLine();
            return _name;
        }
        public double GetTotalBettingChips() //Gets the total amount of chips
        {
            Console.Write("Enter the amount of betting chips you want to have: ");
            _bettingChips = double.Parse(Console.ReadLine());
            return _bettingChips;
        }
        public override string ToString() //Test to see if the fields have values
        {
            return _name + " your total betting chips is " + _bettingChips;
        }
    }
}
