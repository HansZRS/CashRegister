namespace CashRegisterTest
{
	using CashRegister;
    using Moq;
    using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
			//given
			var spyprinter = new SpyPrinter();

			var cashRegister = new CashRegister(spyprinter);

			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			Assert.True(spyprinter.HasPrinter);
		}

		[Fact]
		public void Should_process_execute_printing_validate_call()
		{
			//given
			var printer = new Mock<Printer>();

			var cashRegister = new CashRegister(printer.Object);

			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			printer.Verify(_ => _.Print(It.IsAny<string>()));
		}

		[Fact]
		public void Should_process_execute_printing_print_content()
		{
			//given
			var spyprinter = new Mock<Printer>();

			var cashRegister = new CashRegister(spyprinter.Object);

			var stubpurchase = new Mock<Purchase>();

			stubpurchase.Setup(_ => _.AsString()).Returns("Content");
			//when
			cashRegister.Process(stubpurchase.Object);
			//then
			//verify that cashRegister.process will trigger print
			spyprinter.Verify(_ => _.Print("Content"));
		}

		[Fact]
		public void Should_process_execute_printing_throw_error()
		{
			//given
			var stubprinter = new Mock<Printer>();
			stubprinter.Setup(_ => _.Print(It.IsAny<string>())).Throws(new PrinterOutOfPaperException());

			var cashRegister = new CashRegister(stubprinter.Object);

			Assert.Throws<HardwareException>(() => cashRegister.Process(new Purchase()));
		}
	}
}
