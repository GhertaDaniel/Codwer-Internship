using System;
namespace _4._Entity_Framework_Core.Controller
{
	public class ProductController
	{
		private readonly MagazinContext _dbContext;

		public ProductController(MagazinContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Produs> GetAllProducts()
        {
            var produse = _dbContext.Produse.ToList();
            return produse;
        }

        public Produs GetProductById(int id)
        {
            if (id != null)
            {
                Produs? produs = _dbContext.Produse.FirstOrDefault(p => p.ProdusID == id);
                return produs;
                
            }
            else throw new ArgumentNullException(nameof(id));
        }

        public void AddProduct(Produs produs)
        {
            if (produs != null)
            {
                _dbContext.Produse.Add(produs);
                _dbContext.SaveChanges();
            }
            else throw new ArgumentNullException(nameof(produs));
        }

        public bool DeleteProductById(int id)
        {
            
            if (id == null) throw new ArgumentNullException(nameof(id));

            Produs? produs = GetProductById(id);
            if (produs == null) return false;

            _dbContext.Produse.RemoveRange(_dbContext.Produse.Where(p => p.ProdusID == id));
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateProduct(int id, string numeProdus, decimal pret)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            Produs? produs = _dbContext.Produse.Find(id);

            if (produs == null) return false;

            produs.NumeProdus = numeProdus;
            produs.Pret = pret;
            _dbContext.SaveChanges();
            return true;
        }
	}
}

