using PhoneBase.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBase.DAL
{
    public class DataGenerator
    {
        private readonly PhoneDbContext _context;

        public DataGenerator(PhoneDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Users.AddRange(
                new User
                {
                    LastName = "Testowy",
                    Name = "Jan",
                    Phones = new List<Phone>
                    {
                        new Phone
                        {
                            PhoneNumber = "+48123456789"
                        }
                    }
                },
                new User
                {
                    LastName = "Przykladowy",
                    Name = "Przemek",
                    Phones = new List<Phone>
                    {
                        new Phone
                        {
                            PhoneNumber = "+56123131231"
                        },
                        new Phone
                        {
                            PhoneNumber = "+4823456761"
                        }
                    }
                });

            _context.SaveChanges();
        }
    }
}
