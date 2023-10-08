using System;
namespace _1
{
	public class Client
	{
		private string[] Inbox { get; } = new string[10];
		public string Email { get; set; } = String.Empty;
		public Moneda Moneda { get; set; }
		public List<bool> ProduseFavorite { get; set; }

		public bool Notifica(string mesaj)
		{
			if (mesaj.Length > 60)
			{
				return false;
			}

			int emptyIndex = Array.IndexOf(Inbox, null);
			if(emptyIndex == -1)
			{
				throw new OutOfMemoryException("Numarul maxim de mesaje a fost atins.");
			}

			Inbox[emptyIndex] = mesaj;

			return true;
		}
	}
}

