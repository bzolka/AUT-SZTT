using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.DepencencyInjection.Initial
{
    // Felhasználókhoz kapcsolódó biztonsági szolgáltatásokat biztosít,
    // mint például jelszó megváltoztatása, jelszó ellenőrzés beléptetéskor, stb.
    // A felhasználókat valamilyen adatbázisban tároljuk.
    // Arra figyeltünk, hogy a felhasználók adatainak lekérdezése, módosítása
    // (perzisztencia) le van választva egy UserRepositry osztályba,
    // hiszen az egy másik felelősségi kör (SRP elv).
    // Probléma1: a ChangePassword-be a UserRepository implementáció be van égetve.
    // Rugalmatlan, csak adott adatbázis alapú felhasználó tárolással tud dolgozni.
    // Ha más implementációt szeretnénk, var userRepository = new UserRepository()
    // sorokat mind át kell írni, ráadásul számos helyen.
    // Probléma2: Az előző problémából adódóan a ChangePassword nem unit tesztelhető.
    // A ChangePassword tesztelésénén NEM akarjuk tesztelni az adatbázis alapú
    // perszisztenciát végző kódot, hanem csak a SecurityService-ben levő logikát.
    // Ezen túl az adatbázis alapú perszitencia nagyban fejeslegesen lassítja a unit
    // teszt futását.
    // Továbbfejlesztés a megoldás irányába: alkalmazzuk a Strategy patternt,
    // vezessünk be egy IUserRepository  interfészt több lehetséges
    // implementációval (adatbázis alapú az éles működéshez, memória alapú a unit
    // teszteléshez), a SecurityService pedig interfészként hivatkozzon rá.
    // Lásd WithStrategy mappa...
    class SecurityService
    {
        // A userId azonosítójú felhasználó jelszavát megváltoztatja
        // newPassword-re (ha teljesíti a validációs szabályokat)
        // Visszatérési értékben jelzi, hogy sikerült-e a jelszó megfelel-e
        // a validálási szabályoknak.
        public bool ChangePassword(int userId, string newPassword)
        {
            var userRepository = new UserRepository();
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
            // UserRepository létrehozás
            var userRepository = new UserRepository();
            // userRepository segítségével felhasználó adatok (username, password)
            // beolvasása adatbázisból és ellenőrzése
            throw new NotImplementedException();
        }

        // ...
    }
}
