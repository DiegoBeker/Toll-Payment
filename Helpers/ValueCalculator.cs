namespace Toll_Payment.Helpers;

public class ValueCalculator
{
    private static readonly int MININUM_TICKETS_FOR_DISCOUNT = 10;
    private static readonly double INCREMENTAL_DISCOUNT_RATE = 0.05;
    private static readonly double MAXIMUM_DISCOUNT = 0.8;

    public static int CalculateValueToPay(int tickets, int fee)
    {
        if (tickets < 10) return fee;

        int multiplier = tickets - MININUM_TICKETS_FOR_DISCOUNT + 1;
        var discount = INCREMENTAL_DISCOUNT_RATE * multiplier;

        if (discount >= MAXIMUM_DISCOUNT)
        {
            return (int)Math.Ceiling(fee * (1 - MAXIMUM_DISCOUNT));
        }
        else
        {
            return (int)Math.Ceiling(fee * (1 - discount));
        }
    }
}