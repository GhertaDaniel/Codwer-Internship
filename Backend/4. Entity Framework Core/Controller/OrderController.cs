using System;
namespace _4._Entity_Framework_Core.Controller
{
	public class OrderController
	{
		private readonly MagazinContext _dbContext;

		public OrderController(MagazinContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Comanda> GetAllOrders()
		{
			var orders = _dbContext.Comenzi.ToList();
			return orders;
		}

        public Comanda GetOrderById(int id)
        {
            if (id != null)
            {
                Comanda? comanda = _dbContext.Comenzi.FirstOrDefault(p => p.ComandaID == id);
                return comanda;

            }
            else throw new ArgumentNullException(nameof(id));
        }

		public void AddOrder(Comanda comanda)
		{
			if (comanda != null)
			{
				_dbContext.Comenzi.Add(comanda);
				_dbContext.SaveChanges();
			}
			else throw new ArgumentNullException(nameof(comanda));
		}

        public bool DeleteOrderById(int id)
        {

            if (id == null) throw new ArgumentNullException(nameof(id));

            Comanda? comanda = GetOrderById(id);
            if (comanda  == null) return false;

            _dbContext.Comenzi.RemoveRange(_dbContext.Comenzi.Where(p => p.ComandaID == id));
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateProduct(int id, int persoanaId, string descriere)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            Comanda? comanda = _dbContext.Comenzi.Find(id);

            if (comanda == null) return false;

            comanda.PersoanaID= persoanaId;
            comanda.Descriere = descriere;
            _dbContext.SaveChanges();
            return true;
        }
    }
}

