namespace Org.Codecop.Dependencies.ExtractAndOverrideCall
{
    public class Checkout
    {
        public Receipt CreateReceipt(Money amount)
        {
            var receipt = new Receipt();
            receipt.Amount = amount;
            receipt.Tax = amount.Percentage(20);
            receipt.Total = receipt.Amount.Add(receipt.Tax);
            Store(receipt);

            return receipt;
        }

        protected virtual void Store(Receipt receipt)
        {
            ReceiptRepository.Store(receipt);
        }
    }
}
