using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.SingletonThreadSafe
{
    // Nem képezi a tárgy anyagát.
    // A WindowManager egy singleton
    // Olyan implementáció, mely több szál esetén is használható.
    class WindowManager
    {
        // Tárolja az egyetlen példányt
        // Itt inicializáljuk, ez szálbiztos
        private static WindowManager instance = new WindowManager();
        // Glogális hozzáférést biztosító statikus property
        public static WindowManager Instance
        {
            get
            {
                return instance;
            }
        }
        // Védett konstruktor
        protected WindowManager() { }

        // Az osztály egyik művelete
        public void DoSomething() { /*...*/}
    }
}
