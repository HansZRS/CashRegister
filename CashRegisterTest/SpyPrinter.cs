namespace CashRegister
{
    public class SpyPrinter : Printer
	{
		public string Printcontent { get; set; }
		public bool HasPrinter { get; set; }
		public override void Print(string content)
		{

			base.Print(content);
			HasPrinter = true;
			// send message to a real printer
		}
	}
}
