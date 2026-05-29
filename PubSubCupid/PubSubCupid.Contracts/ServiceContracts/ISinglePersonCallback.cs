using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using PubSubCupid.Contracts.TransferObjects;

namespace PubSubCupid.Contracts.ServiceContracts
{
    // Callback ugovor
    // callback se koristi za duplex komunikaciju
    // tj. ideja je da server poziva klijenta
    // kupidon salje osobi pismo sam od sebe
    public interface ISinglePersonCallback
    {
        // Server salje pismo i ne ceka odgovor
        [OperationContract(IsOneWay = true)]
        void ReceiveLoveLetter(LoveLetterDTO letter);
    }
}
