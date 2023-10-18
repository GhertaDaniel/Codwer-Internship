using System;
namespace _4._Entity_Framework_Core.Controller
{
	public class PersonController
	{
		private readonly MagazinContext _dbContext;
		public PersonController(MagazinContext dbContext)
		{
			_dbContext = dbContext;
		}

		public List<Persoana> GetAllPersons()
		{
			var persoane = _dbContext.Persoane.ToList();
			return persoane;
		}

		public Persoana GetPersoanaById(int id)
		{
			if (id == null) throw new ArgumentNullException(nameof(id));

			Persoana? persoana = _dbContext.Persoane.FirstOrDefault(pers => pers.PersoanaID == id);
			return persoana;
		}

		public void AddPerson(Persoana person)
		{
			if (person != null)
			{
				_dbContext.Persoane.Add(person);
				_dbContext.SaveChanges();
			}
			else throw new ArgumentNullException(nameof(person));
		}

		public bool DeletePersonById(int id)
		{
            if (id == null) throw new ArgumentNullException(nameof(id));

            Persoana? person = GetPersoanaById(id);
            if (person == null) return false;

            _dbContext.Persoane.RemoveRange(_dbContext.Persoane.Where(p => p.PersoanaID == id));
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdatePerson(int id, string numePersoana, string adresa)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            Persoana? persoana = _dbContext.Persoane.Find(id);

            if (persoana == null) return false;

            persoana.Nume = numePersoana;
            persoana.Adresa = adresa;
            _dbContext.SaveChanges();
            return true;
        }
    }
}

