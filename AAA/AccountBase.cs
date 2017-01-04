using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA
{
    public abstract class AccountBase
    {
        // facotryメソッド
        // pros-1, staticメソッドであるため、クライアントがこのメソッドを直接呼び出すことができる
        // prps-2, 戻り値の型を基底クラスにすることで派生クラスを隠蔽できる
        public static AccountBase CreateAccount(AccountType type)
        {
            AccountBase account = null;
            switch (type)
            {
                case AccountType.Silver:
                    account = new SilverAccount();
                    break;
                case AccountType.Gold:
                    account = new GoldAccount();
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount();
                    break;
            }
            return account;
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

        public void AddTransaction(decimal amount)
        {
            RewardPoints += CalculateRewardPoints(amount);
            Balance += amount;
        }

        public abstract int CalculateRewardPoints(decimal amount);
    }
}
