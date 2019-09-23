using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotMe_.Models
{
    public class FakeRepository : IExcerciserRepository
    {
        public IQueryable<Excerciser> Excercisers => new List<Excerciser>
        {
            new Excerciser {excerciserID = 1, firstName = "Jose", lastName = "Gonzalez", email = "jg@gmail.com", userName = "Speedy", passWord = "123"},
            new Excerciser {excerciserID = 2, firstName = "Chad", lastName = "Smith", email = "c#@gmail.com", userName = "Brad", passWord = "321"},
            new Excerciser {excerciserID = 3, firstName = "Brad", lastName = "Johnson", email = "jb@gmail.com", userName = "Chad", passWord = "000"},
            new Excerciser {excerciserID = 4, firstName = "Jennifer", lastName = "Sanchez", email = "ds@gmail.com", userName = "Fefe", passWord = "876"}
        }.AsQueryable<Excerciser>();
    }
}
