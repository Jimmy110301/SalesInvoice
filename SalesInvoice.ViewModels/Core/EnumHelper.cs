namespace SalesInvoice.ViewModels.Core
{
    public static class EnumHelper
    {
        private static readonly Random _random = new();

        public static string GetPaymentMethod(int paymentModeId)
        {
            return paymentModeId switch
            {
                (int)PaymentType.Cash => "Cash",
                (int)PaymentType.Card => "Card",
                (int)PaymentType.UPI => "UPI",
                (int)PaymentType.Other => "Other",
                _ => string.Empty,
            };
        }

        public static string GenerateRandomText(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(1, length)
                .Select(_ => chars[_random.Next(chars.Length)]).ToArray());
        }
    }
}
