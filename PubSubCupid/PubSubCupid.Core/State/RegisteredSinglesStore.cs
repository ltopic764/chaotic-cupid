using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using PubSubCupid.Core.Models;

namespace PubSubCupid.Core.State
{
    public class RegisteredSinglesStore
    {
        // Sve trenutno prijavljene osobe
        private readonly List<SinglePerson> _registeredSingles;

        public RegisteredSinglesStore()
        {
            _registeredSingles = new List<SinglePerson>();
        }

        public IReadOnlyCollection<SinglePerson> GetAll()
        {
            return _registeredSingles.AsReadOnly();
        }

        public bool UsernameExists(string username)
        {
            return _registeredSingles.Any(person => person.Username.Equals(username, System.StringComparison.OrdinalIgnoreCase));
        }

        public void Add(SinglePerson person)
        {
            _registeredSingles.Add(person);
        }

        public SinglePerson FindByUsername(string username)
        {
            return _registeredSingles.FirstOrDefault(person => person.Username.Equals(username, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
