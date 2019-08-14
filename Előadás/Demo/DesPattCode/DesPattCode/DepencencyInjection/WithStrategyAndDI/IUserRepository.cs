using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.DepencencyInjection.WithStrategyAndDI
{
    // UserRespository interfész
    interface IUserRepository
    {
        // Kivételt dob (Exception), ha nem találja a felhasználót.
        // Gyakorlatban célszerű dedikált kivételt bevezetni rá.
        string GetUserPassword(int userId);
        void UpdateUserPassword(int userId, string password);
        // ...
    }
}
