﻿namespace AAA
{
    public class Account
    {
        public Account()
        {
            // Balance = 200m;
        }
        public void AddTransaction(decimal amount)
        {
            Balance += amount;
        }

        public decimal Balance
        {
            get;
            private set;
        }

        public int RewardPoints
        {
            get;
            private set;
        }

        public int CalculateReqardPoints(decimal amount)
        {
            int points;
            switch (type)
            {
                case AccountType.Silver:
                    points = (int)decimal.Floor(amount / SilverTransactionCostPerPoint);
                    break;
                case AccountType.Gold:
                    points = (int)decimal.Floor((Balance / GoldBalanceCostPerPoint) + 
                                                (amount / GoldTransactionCostPerPoint));
                    break;
                case AccountType.Platinum:
                    points = (int)decimal.Ceiling((Balance / PlatinumBalanceCostPerPoint) + 
                                                    (amount / PlatinumTransactionCostPerPoint));
                    break;
                default:
                    points = 0;
                    break;
            }
            return System.Math.Max(points, 0);
        }

        private readonly AccountType type;
        private const int SilverTransactionCostPerPoint = 10;
        private const int GoldTransactionCostPerPoint = 5;
        private const int PlatinumTransactionCostPerPoint = 2;

        private const int GoldBalanceCostPerPoint = 2000;
        private const int PlatinumBalanceCostPerPoint = 1000;

    }
}