namespace Aleksandr.Live.Api.Domains
{
    public class UserAccount
    {


        private decimal _balance;

        protected bool Deposit(decimal deposit)
        {
            _balance += deposit;
            return true;
        }

        protected bool TryWidthdraw(decimal widthdraw)
        {

            if (widthdraw > 0 && _balance > widthdraw)
            {
                _balance -= widthdraw;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}}
