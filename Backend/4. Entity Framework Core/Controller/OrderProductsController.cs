using System;
namespace _4._Entity_Framework_Core.Controller
{
	public class OrderProductsController
	{
		private readonly MagazinContext _dbContext;
		public OrderProductsController(MagazinContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<ComandaProdus> GetAllOrdersWithProducts()
		{
			var orderWithProducts = _dbContext.ComenziProduse.ToList();
			return orderWithProducts;
		}

		public ComandaProdus GetOrderWithProductsById(int id)
		{
            if (id != null)
            {
                ComandaProdus? orderWithProducts = _dbContext.ComenziProduse.FirstOrDefault(p => p.ComandaID == id);
                return orderWithProducts;

            } else throw new ArgumentNullException(nameof(id));
        }

        public void AddOrderWithProducts(ComandaProdus comandaProdus)
        {
            if (comandaProdus != null)
            {
                _dbContext.ComenziProduse.Add(comandaProdus);
                _dbContext.SaveChanges();
            } else throw new ArgumentNullException(nameof(comandaProdus));
        }

        public bool DeleteOrderWithProductsById(int id)
        {

            if (id == null) throw new ArgumentNullException(nameof(id));

            ComandaProdus? comandaProdus = GetOrderWithProductsById(id);
            if (comandaProdus == null) return false;

            _dbContext.ComenziProduse.RemoveRange(_dbContext.ComenziProduse.Where(p => p.ComandaID == id));
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateOrderWithProducts(int comandaId, int produsId, int cantitate)
        {
            if (comandaId == null) throw new ArgumentNullException(nameof(comandaId));

            ComandaProdus? comandaProdus = _dbContext.ComenziProduse.Find(comandaId, produsId);

            if (comandaProdus == null) return false;

            comandaProdus.ComandaID = comandaId;
            comandaProdus.ProdusID = produsId;
            comandaProdus.Cantitate = cantitate;
            _dbContext.SaveChanges();
            return true;
        }
    }
}

