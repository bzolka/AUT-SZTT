using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Singleton2
{
    // A WindowManager egy singleton
    // Olyan implementáció, ahol az egy példányhoz egy statikus
    // property segítségével férünk hozzá.
    class WindowManager
    {
        // Tárolja az egyetlen példányt, kezdetben null.
        private static WindowManager instance = null;
        // Glogális hozzáférést biztosító statikus property
        public static WindowManager Instance
        {
            get
            {
                // Az egy példányt az első hozzáférés alkalmával
                // hozzuk létre
                if (instance == null)
                    instance = new WindowManager();
                return instance;
            }
        }
        // Védett konstruktor
        protected WindowManager() { }

        // Az osztály egyik művelete
        public void DoSomething() { /*...*/}
        
    }
}
