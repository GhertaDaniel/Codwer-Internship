using System;
namespace _1
{
	public class Client
	{
		public List<string> Inbox { get; } = new List<string>();
		public string Email { get; set; } = String.Empty;
		public Moneda Moneda { get; set; }
		public List<object> ProduseFavorite { get; set; }

		public bool Notifica(string mesaj)
		{
			if (mesaj.Length > 60)
			{
				return false;
			} else if(Inbox.Count > 10)
			{
				throw new OutOfMemoryException("Numarul maxim de mesaje a fost atins.");
			} else {
                Inbox.Add(mesaj);
                return true;
            }
		}
	}
}

