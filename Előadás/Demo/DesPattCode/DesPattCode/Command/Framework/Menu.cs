using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Command.Framework
{
    // Egy több menüelemből álló menüt reprezentál.
    class Menu
    {
        // Ebben tárolja a menüelemeket.
        List<MenuItem> menuItems = new List<MenuItem>();

        // Új menüelemet vesz fel, paraméterben a menü szövege és
        // a menüelemen való kattintáskor futtatandó parancs adható
        // meg. A parancs objektumot eltáolja a menüelemmel:
        // a menüelem a rajta való kattintásjor futtatja a parancsot.
        public void AddNewMenuItem(string text, ICommand command)
        {
            var nenuItem = new MenuItem(text, command);
            menuItems.Add(nenuItem);
        }

        public void SimulateUserMenuClick(int menuIndex)
        {
            menuItems[menuIndex].Click();
        }
    }
}
