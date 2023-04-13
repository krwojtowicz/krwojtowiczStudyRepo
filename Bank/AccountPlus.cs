using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class AccountPlus : Account, IAccountWithLimit
    {
        private decimal _oneTimeDebtLimit;
        private decimal _avalibleFounds;
        public decimal OneTimeDebetLimit 
        {
            get => _oneTimeDebtLimit;
            set
            {
                if(value < 0) { }
                else if(base.IsBlocked == false)
                {
                    _oneTimeDebtLimit = Math.Round(value, 4);
                    AvaibleFounds = base.Balance + _oneTimeDebtLimit;
                }
                
            } 
        }
        public decimal AvaibleFounds 
        {
            get => _avalibleFounds;
            private set => _avalibleFounds = Math.Round(value, 4); 
        }

        public AccountPlus (string name, decimal initialLimit = 100, decimal initialBalance = 0) : base(name, initialBalance)
        {
            OneTimeDebetLimit = initialLimit;
            AvaibleFounds = OneTimeDebetLimit + initialBalance;
        }

        public new bool Withdrawal(decimal amount)
        {
            if (amount <= 0 || base.IsBlocked || amount > AvaibleFounds) return false;
            if (amount < base.Balance)
            {
                AvaibleFounds -= amount;
                return base.Withdrawal(amount);
            }
            else
            {
                AvaibleFounds -= amount;
                base.Withdrawal(base.Balance);
                base.Block();
                return true;
            }
        }

        public new bool Deposit(decimal amount)
        {
            if (base.IsBlocked)
            {
                if(amount <= 0) return false;
                AvaibleFounds += amount;
                if(AvaibleFounds >= OneTimeDebetLimit)
                {
                    base.Unblock();
                    base.Deposit(AvaibleFounds - OneTimeDebetLimit);
                    return true;
                }
                else
                {
                    AvaibleFounds += amount;
                    return true;
                }
            }
            else
            {
                return base.Deposit(amount);
            }     
        }


        public new void Block()
        {
            base.Block();
        }
        public new void Unblock()
        {
            if(AvaibleFounds >= OneTimeDebetLimit) base.Unblock();
        }

        public override string ToString() => !IsBlocked ? $"Account name: {Name}, balance: {Balance:F2}, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}" :
            $"Account name: {Name}, balance: {Balance:F2}, blocked, avaible founds: {AvaibleFounds:F2}, limit: {OneTimeDebetLimit:F2}";
       

    }
}
