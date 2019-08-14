using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Singleton
{
    class SingletoDemo
    {
        public void DemoSingletonUse()
        {
            // Itt férünk hozzá a WindowManager singleton példányhoz
            // A példányt a WindowManager.GetInstance() hozza létre
            // (az első hívás alkalmával) és adja vissza
            WindowManager.GetInstance().DoSomething();

            // A későbbi hívások ugyanazt a példányt adják vissza
            WindowManager.GetInstance().DoSomething2();
        }
    }
}
