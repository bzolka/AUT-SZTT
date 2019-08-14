using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.DepencencyInjection.Initial
{
    // A felhasználók adatainak adatbázis alapú perzisztálására szolgál.
    class UserRepository
    {
        public string GetUserPassword(int userId)
        {
            // Adatbázisból adott felhasználó jelszavának felolvasása
            // Az egyszerűség kedvéért egy fix szöveggel térünk vissza
            // A gyakorlatban pl. kivételt dobnénk, ha az adott felhasználó nem létezik.
            return "u3T7Y2lC9,";
        }

        public void UpdateUserPassword(int userId, string password)
        {
            // Adatbázisban adott felhasználó jelszavának módosítása
            // ...
        }

        // További műveletek felhasználók tárolására, módosítására, törlésére
        // ...


    }
}
