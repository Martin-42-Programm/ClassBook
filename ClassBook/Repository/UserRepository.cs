using System;

namespace ClassBook.Repository
{
	public class UserRepository : IGenericRepository<User>
	{
        private ApplicationContext _context;

        public UserRepository(ApplicationContext dbContext)
		{
            _context = dbContext;
        }

        public bool Add(User item)
        {
            try
            {
                _context.Add<User>(item);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public bool Delete(User item)
        {
            throw new NotImplementedException();
        }

        public User Get(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

