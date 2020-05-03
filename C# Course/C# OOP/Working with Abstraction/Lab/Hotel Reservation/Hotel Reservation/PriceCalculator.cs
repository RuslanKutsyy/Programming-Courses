namespace Hotel_Reservation
{
    enum Seasons
    {
        Autumn = 1,
        Spring,
        Winter,
        Summer
    }

    enum Discounts
    {
        VIP = 20,
        SecondVisit = 10,
        None = 0
    }

    class PriceCalculator
    {
        public static double GetTotalPrice(string[] reservation)
        {
            double pricePerDay = double.Parse(reservation[0]);
            int numberOfDays = int.Parse(reservation[1]);
            int seasonMultiplication = 0;
            double discountType = 0;
            string season = reservation[2];
            double totalPrice = 0;

            if (season == Seasons.Autumn.ToString())
            {
                seasonMultiplication = (int)Seasons.Autumn;
            }
            else if (season == Seasons.Spring.ToString())
            {
                seasonMultiplication = (int)Seasons.Spring;
            }
            else if (season == Seasons.Summer.ToString())
            {
                seasonMultiplication = (int)Seasons.Summer;
            }
            else if (season == Seasons.Winter.ToString())
            {
                seasonMultiplication = (int)Seasons.Winter;
            }

            if (reservation.Length == 3)
            {
                discountType = (double)Discounts.None / 100;
            }
            else
            {
                string type = reservation[3];
                if (type == Discounts.VIP.ToString())
                {
                    discountType = (double)Discounts.VIP / 100;
                }
                else if (type == Discounts.SecondVisit.ToString())
                {
                    discountType = (double)Discounts.SecondVisit / 100;
                }
                else if (type == Discounts.None.ToString())
                {
                    discountType = (double)Discounts.None;
                }
            }

            totalPrice = seasonMultiplication * (pricePerDay * numberOfDays) * (1 - discountType);

            return totalPrice;
        }


    }


}
