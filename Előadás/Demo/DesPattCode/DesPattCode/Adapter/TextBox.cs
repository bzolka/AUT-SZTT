using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Adapter
{
    // Szerkeszthető szövegdoboz.
    // Egy olyan osztályt reprezentál, melynek egy gyakorlati
    // esetben nem lenne meg a forráskódja, mert pl. be van
    // építve a kereterendszerbe (pl. UWP TextBox). A gyakorlaban
    // ez egy nagyon komplex, sok ezer soros osztály lenne.
    // Ennek a kódját szerenénk felhasználni az alkalmazásunkban
    // Shape-ként hivatkozni rá a DrawingEditor osztályban, de
    // nem származik a Shape osztályból, és ezt nem is tudjuk
    // akarjuk megváltoztatni.
    class TextBox
    {
        string text; // Aktuális szövegtartalom
        int x, y, w, h; // Befoglaló téglalap

        public TextBox(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public Rect GetExtent()
        {
            return new Rect(x, y, w, h);
        }

        public string GetText() { return text; }

        public void Draw() {  /* ....*/ }

        // Sok-sok komplex logika
    }
}
