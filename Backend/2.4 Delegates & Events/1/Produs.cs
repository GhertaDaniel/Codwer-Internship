using System;
namespace _1
{
	public class Produs
	{
		public Guid Id { get; set; }
		public string Nume { get; set; }
		public Pret Pret { get; set; }
		private int stoc;

		public int Stoc
		{
			get { return stoc; }
			set
			{
				if(value > 0)
				{
					stoc = value;
				}
				else
				{
					throw new ArgumentException("Stocul trebuie sa fie un numar pozitiv");
				}
			}
		}
		public Producator Producator { get; set; }

		public event EventHandler<Produs> stocChangeCompleted;

		public void startStocChanging(decimal newStocValue, Produs produs)
		{
			try
			{
				decimal oldStocValue = stoc;
				Console.WriteLine($"Valoarea stocului vechi: {oldStocValue}");
				stoc = (int)newStocValue;

				onStocValueChange(produs);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Eroare: {ex.Message}");
			}
		}

		protected virtual void onStocValueChange(Produs produs)
		{
			stocChangeCompleted?.Invoke(this, produs);
		}
	}
}

