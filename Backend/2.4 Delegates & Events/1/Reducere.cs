using System;
namespace _1
{
	public class Reducere
	{
		public string Name { get; set; }
		public DateTime Data { get; set; }
		public Action<Produs> Aplica;
	}
}

