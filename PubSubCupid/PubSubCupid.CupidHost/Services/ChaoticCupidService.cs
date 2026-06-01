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
using System.Timers;
using PubSubCupid.Core.Matching;

namespace PubSubCupid.CupidHost.Services
{
    [ServiceBehavior(
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ChaoticCupidService : ICupidDesk
    {
        private readonly RegisteredSinglesStore _store;
        private readonly Timer _cupidTimer;

        public ChaoticCupidService()
        {
            _store = new RegisteredSinglesStore();

            _cupidTimer = new Timer();
            _cupidTimer.Interval = 10000; // 10000ms = 10sec // izmeniti
            _cupidTimer.Elapsed += CupidTimerElapsed; // dodaj dogadjaj

            _cupidTimer.Start();
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
            SinglePerson person = _store.FindByUsername(username);

            if (person == null)
            {
                Console.WriteLine($"Confirm failed. User {username} not found");
                return;
            }

            person.WaitingForConfirmation = false;
            Console.WriteLine($"{username} confirmed previous letter");
        }

        public bool BlockPerson(string username, string blockedUsername)
        {
            SinglePerson person = _store.FindByUsername(username);
            SinglePerson blockedPerson = _store.FindByUsername(blockedUsername);

            if (person == null || blockedPerson == null)
            {
                return false;
            }

            if (string.Equals(username, blockedUsername, System.StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{username} tried to block himself/herself");
                return false;
            }

            person.BlockedUsernames.Add(blockedUsername);
            Console.WriteLine($"{username} has blocked {blockedUsername}");
            return true;
        }

        private void CupidTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine();

            //Console.WriteLine("Cupid is looking for matches...");
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Cupid is looking for matches...");

            SendLettersToEveryone();
        }

        private string GetRandomCupidMessage()
        {
            string[] messages =
            {
                "Looking forward to our date!",
                "I want to meet!",
                "Not interested"
            };

            int index = PubSubCupid.Core.Randomness.SecureRandomPoints.Next(0, messages.Length);

            return messages[index];
        }

        private void SendLettersToEveryone()
        {
            foreach (SinglePerson person in _store.GetAll())
            {
                if (person.WaitingForConfirmation)
                {
                    continue;
                }

                MatchScore bestMatch = CupidMatchmaker.FindBestMatch(person, _store.GetAll());

                if (bestMatch == null)
                {
                    continue;
                }

                SinglePerson matchedPerson = bestMatch.Candidate;

                //Console.WriteLine($"DEBUG matched city: {matchedPerson.City}");

                string message = GetRandomCupidMessage(); // random poruka
                bool shouldHidePhone = message == "Not interested";

                LoveLetterDTO letter = new LoveLetterDTO
                {
                    FromUsername = matchedPerson.Username,
                    FromCity = matchedPerson.City,
                    FromAge = matchedPerson.Age,
                    FromPhonenumber = shouldHidePhone ? string.Empty : matchedPerson.Phonenumber,
                    CupidMessage = message
                };

                try
                {
                    person.Callback.ReceiveLoveLetter(letter);

                    person.WaitingForConfirmation = true;

                    Console.WriteLine($"Letter sent to {person.Username} from {matchedPerson.Username}. Score: {bestMatch.Score}");
                } catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send letter to {person.Username}: {ex.Message}");
                }
            }
        }

    }
}
