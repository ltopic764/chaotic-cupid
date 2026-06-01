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
        private readonly object _lock = new object();

        public RegisteredSinglesStore()
        {
            _registeredSingles = new List<SinglePerson>();
        }

        public IReadOnlyCollection<SinglePerson> GetAll()
        {
            lock (_lock)
            {
                return _registeredSingles.ToList().AsReadOnly();
            }
        }

        public bool UsernameExists(string username)
        {
            lock (_lock)
            {
                return _registeredSingles.Any(person => person.Username.Equals(username, System.StringComparison.OrdinalIgnoreCase));
            }
        }

        public void Add(SinglePerson person)
        {
            lock (_lock)
            {
                _registeredSingles.Add(person);
            }
        }

        public SinglePerson FindByUsername(string username)
        {
            lock (_lock)
            {
                return _registeredSingles.FirstOrDefault(person => person.Username.Equals(username, System.StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
