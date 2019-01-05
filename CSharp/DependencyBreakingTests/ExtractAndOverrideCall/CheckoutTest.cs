using Org.Codecop.Dependencies.ExtractAndOverrideCall;
using Xunit;

namespace Org.Codecop.Dependencies.ExtractAndOverrideCall.Tests
{
    public class CheckoutTest
    {
        private class TestCheckout : Checkout
        {
            private int storeCallCount = 0;

            public bool[] WasCalled { get; } = new bool[] { false };

            protected override void Store(Receipt receipt)
            {
                WasCalled[storeCallCount++] = true;
            }
        }
        [Fact]
        public void ReceiptContainsPriceTaxAndTotal()
        {
            var checkout = new TestCheckout();

            Receipt receipt = checkout.CreateReceipt(new Money(147));

            Assert.Contains("Item 1 ... 147,00", receipt.Format());
            Assert.Contains("Tax    ... 29,40", receipt.Format());
            Assert.Contains("Total  ... 176,40", receipt.Format());
        }

        [Fact]
        public void ReceiptIsStored()
        {
            var checkout = new TestCheckout();
            var receipt = checkout.CreateReceipt(new Money(147));
            Assert.Contains("Item 1 ... 147,00", receipt.Format());
            Assert.Contains("Tax    ... 29,40", receipt.Format());
            Assert.Contains("Total  ... 176,40", receipt.Format());

            Assert.True(checkout.WasCalled[0], "receipt not stored");
        }
    }
}
