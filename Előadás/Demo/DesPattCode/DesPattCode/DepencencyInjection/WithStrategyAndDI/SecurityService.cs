using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.DepencencyInjection.WithStrategyAndDI
{
    // Végső megoldás.
    // Interfészként hivatkozik a UserRepository implementációra,
    // és az implementációt is kívülről kapja meg (dependency injection),
    // jelen példában konstruktor paraméterként.
    // Minden korábbi problémától megszabadultunk, a kódot nézzük át, sehol
    // nem szerepel benne egyik IUserRepository implementáció sem.
    // Így bármelyik implementációval is akarjuk használni, a SecurityService
    // kódját nem kell módosítani. Az osztály használatára a DemoSecurityService
    // mutat példát.
    class SecurityService
    {
        // Interfészként hivatkozunk a user repository implementációra
        IUserRepository userRepository;

        // Konstruktor paraméterként kap egy  IUserRepository implementációt

        public SecurityService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void SetUserRepository(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

    // A userId azonosítójú felhasználó jelszavát megváltoztatja
    // newPassword-re (ha teljesíti a validációs szabályokat)
    // Visszatérési értékben jelzi, hogy sikerült-e a jelszó megfelel-e
    // a validálási szabályoknak.
    public bool ChangePassword(int userId, string newPassword)
        {
            // Adatbázisból régi jelszó lekérdezése userRepository segítségével
            var oldPassword = userRepository.GetUserPassword(userId);

            // Jelszó validálás
            bool isValid = isPasswordValid(newPassword, oldPassword);
            if (!isValid)
                return false;

            // Adatbázisból jelszó módosítása userRepository segítségével
            userRepository.UpdateUserPassword(userId, newPassword);

            return true; // ha minden stimmel
        }

        // Ellenőrzi, hogy a jelszó megfelel-e a validációs szabályoknak.
        // A gyakorlatban ezt a logikát is illene kiszerverzni egy másik
        // osztályba (pl. PasswordValidator) - SRP elv és könnyebb unit tesztelhetőség!
        public bool isPasswordValid(string newPassword, string oldPassword)
        {
            // A régi jelszó lehet null és min 10 hossz
            if (string.IsNullOrWhiteSpace(oldPassword)
                || oldPassword.Length < MinPasswordLength)
                return false;
            // Az új jelszó nem egyezhet a régivel
            if (string.Equals(newPassword, oldPassword))
                return false;
            return true;
        }

        const int MinPasswordLength = 10;

        public bool Login(string userName, string password)
        {
            // userRepository tag segítségével felhasználó adatok (username, password)
            // beolvasása adatbázisból és ellenőrzése
            throw new NotImplementedException();
        }
    }
}
