using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Telephony
{
    class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string webSite)
        {
            if (SiteIsValid(webSite))
            {
                Console.WriteLine($"Browsing: {webSite}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }

        public void Call(string phone)
        {
            if (PhoneIsValid(phone))
            {
                Console.WriteLine($"Calling... {phone}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        private bool PhoneIsValid(string phone)
        {
            foreach (var num in phone)
            {
                if (!char.IsDigit(num))
                {
                    return false;
                }
            }
            return true;
        }

        private bool SiteIsValid(string site)
        {
            foreach (var @char in site)
            {
                if (char.IsDigit(@char))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
