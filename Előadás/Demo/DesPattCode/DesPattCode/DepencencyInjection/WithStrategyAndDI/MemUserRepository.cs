using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.DepencencyInjection.WithStrategyAndDI
{
    // A felhasználók adatainak memória alapú perzisztálására szolgál.
    // Gyors, unit teszteléshez
    class MemUserRepository: IUserRepository
    {
        string password = "u3T7Y2lC9,";

        public string GetUserPassword(int userId)
        {
            // Azt is tudjuk szimulálni unit tesztekhez, hogy a kód
            // kivátelt dob, ha nem találja a felhasználót.
            if (userId == 10)
                throw new Exception("User not found");
            // Egyszerűen visszadjuk az tagváltozóban tárolt jelszót.
            return password;
        }

        public void UpdateUserPassword(int userId, string password)
        {
            // Adatbázisban adott felhasználó jelszavának módosítása
            // Azt is tudjuk szimulálni unit tesztekhez, hogy a kód
            // kivátelt dob, ha nem találja a felhasználót.
            if (userId == 10)
                throw new Exception("User not found");
            this.password = password;
        }

        // További műveletek felhasználók tárolására, módosítására, törlésére
        // ...
    }
}
