using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.DepencencyInjection.WithStrategy
{
    // Az eredeti (Initial) SecurityService továbbfejlesztése.
    // Interfészként hivatkozik a UserRepository implementációra:
    // Ha más implementációt szeretnénk, akkor a műveleteket, pl. 
    // a ChangePassword-öt nem kell megváltoztatni:
    // Még mindig maradt egy probléma, a konstruktorban a new-val 
    // a példányosítás! A new után csak konkrét implementációt adhatunk meg.
    // így ha át szeretnénk térni egy másik implementációra, akkor a
    // SecurityService kódját még mindig módosítani kell (igaz, már csak 
    // egy helyen, a konstruktorban), ez sérti az Open/Closed elvet
    // (meg kell nyitni az osztályt módosításra).
    // Megoldás: Dependency Injection (DI) alkalmazása, konstruktor, vagy esetleg
    // metódus paraméterben adjuk át az implementációt a SecurityService
    // osztálynak. Lásd WithStrategyAndDI mappa.
    class SecurityService
    {
        // Interfészként hivatkozunk a user repository implementációra
        IUserRepository userRepository;

        // Konstruktor paraméterként kap egy  IUserRepository implementációt
        public SecurityService()
        {
            userRepository = new DbUserRepository();
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
