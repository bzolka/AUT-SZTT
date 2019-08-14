using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.ObserverDocView
{
    // A nézetek közös őse, implementálja az IView interfészt.
    // Azért vezettük be, hogy ide tudjuk tenni a minden nézetre közös
    // kódot, ne kellje az TableView, ColumnChartView, stb. osztályokban
    // kézzel duplikálni.
    abstract class ViewBase : IView
    {
        // A minta egyik alappillére: a nézetnek (observer) van egy hivatkozása
        // a dokumentumára. Ezen keresztül kérdezi le a dokumentum adatai (pl. megjelenítés
        // során), illetve ezen keresztül tudja a dokumentum (subject) állapotát
        // megváltoztatni.
        protected readonly ExcelDocument document;

        // Konstruktorban megkapja a dokumentumot, be is regisztrál hozzá.
        protected ViewBase(ExcelDocument doc)
        {
            document = doc;
            doc.Attach(this);
        }

        // Az implementált IView interfész Update műveletének megvalósítása
        // Ez hívódik mindig, amikor változik a dokumentum (subject) állapota.
        // Jelen példában egyetlen teendőnk van: újrarajzoljuk az adott nézetet
        public void Update()
        {
            Draw();
        }

        // Kirajzolja a nézetet. A megvalósítás nézet típus függő, így ez itt absztrakt.
        public abstract void Draw();
    }
}
