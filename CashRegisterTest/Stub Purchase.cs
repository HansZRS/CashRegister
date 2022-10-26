using System;

namespace CashRegister
{
	public class StubPurchase : Purchase
	{
		private readonly string content;

		public override string AsString()
		{
			return content;
		}
	}
}