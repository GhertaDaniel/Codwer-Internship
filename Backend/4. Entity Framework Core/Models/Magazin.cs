using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4._Entity_Framework_Core
{
	public class Persoana : BaseEntity
	{
		[Key]
		public int PersoanaID { get; set; }
		public string Nume { get; set; }
		public string Adresa { get; set; }
	}

	public class Comanda : BaseEntity
    {
		[Key]
		public int ComandaID { get; set; }
		public string Descriere { get; set; }
		[ForeignKey("Persoana")]
		public int PersoanaID { get; set; }
    }

	public class Produs : BaseEntity
    {
		public int ProdusID { get; set; }
		public string NumeProdus { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal Pret { get; set; }

		//public Produs(string nume, decimal pret)
		//{
		//	NumeProdus = nume;
		//	Pret = pret;
		//}
    }

	public class ComandaProdus : BaseEntity
    {
		[ForeignKey("Comanda")]
		public int ComandaID { get; set; }
		[ForeignKey("Produs")]
		public int ProdusID { get; set; }
		public int Cantitate { get; set; }
    }

	public abstract class BaseEntity
	{
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
    }
}

