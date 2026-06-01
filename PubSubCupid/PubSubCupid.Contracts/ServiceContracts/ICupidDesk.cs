using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using PubSubCupid.Contracts.TransferObjects;

namespace PubSubCupid.Contracts.ServiceContracts
{
    // ovaj servis moze nazad da pozove metode iz onog u typeof(...)
    [ServiceContract(CallbackContract = typeof(ISinglePersonCallback))]
    public interface ICupidDesk
    {

        // Korisnik se prijavljuje da nadje partnera
        [OperationContract]
        bool InitSinglePerson(ProfileDTO profile);

        // Korisnik mora da potvrdi da je dobio prethodno pismo da bi mogao da prima druga
        [OperationContract]
        void ConfirmPreviousLetter(string username);

        // Korisnik moze da blokira drugog korisnika
        [OperationContract]
        bool BlockPerson(string username, string blockedUsername);
    }
}
