using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using PubSubCupid.Contracts.ServiceContracts;
using PubSubCupid.Contracts.TransferObjects;
using PubSubCupid.Core.Models;
using PubSubCupid.Core.State;

namespace PubSubCupid.CupidHost.Services
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ChaoticCupidService : ICupidDesk
    {
        private readonly RegisteredSinglesStore _store;

        public ChaoticCupidService()
        {
            _store = new RegisteredSinglesStore();
        }


        public bool InitSinglePerson(ProfileDTO profile)
        {
            if (_store.UsernameExists(profile.Username))
            {
                return false;
            }

            ISinglePersonCallback callback = OperationContext.Current.GetCallbackChannel<ISinglePersonCallback>();

            SinglePerson person = SinglePerson.FromDTO(profile, callback);

            _store.Add(person);

            return true;
        }

        public void ConfirmPreviousLetter(string username)
        {
            throw new NotImplementedException();
        }
        public void BlockPerson(string username, string blockedUsername)
        {
            throw new NotImplementedException();
        }

    }
}
