namespace Toll_Payment.Models;
public enum PaymentStatus
{
    PROCESSING,
    FAILED,
    SUCCESS,
}

public static class PaymentStatusParser
    {
        public static string ParseStatus(PaymentStatus status)
        {
        return status switch
        {
            PaymentStatus.PROCESSING => "Processing",
            PaymentStatus.FAILED => "Failed",
            PaymentStatus.SUCCESS => "Success",
            _ => throw new ArgumentException("Invalid payment status"),
        };
    }
    }