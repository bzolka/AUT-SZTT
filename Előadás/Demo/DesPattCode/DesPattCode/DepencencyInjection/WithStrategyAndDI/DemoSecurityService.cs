using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.DepencencyInjection.WithStrategyAndDI
{
    class DemoSecurityService
    {
        public void Demo()
        {
            // Éles alkalmazásban a DbUserRepository-val használjuk a SecurityService-t
            var securityService = new SecurityService( new DbUserRepository() );
            securityService.ChangePassword(111, "abrakadabra");

            // Unit teszt esetében a gyors MemUserRepository-val használjuk a SecurityService-t
            var securityService2 = new SecurityService( new MemUserRepository() );
            // ... teszt előkészítés ...
            // tesztelendő kód futtatás
            bool wasValid = securityService2.ChangePassword(111, "abrakadabra");
            //  ... teszt validálás ...
        }
    }
}
