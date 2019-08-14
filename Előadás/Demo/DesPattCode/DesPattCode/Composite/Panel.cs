using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Composite
{
    // Egy összetett (kompozit) alakzat, mely  grafikus
    // alakzatokat tartalmaz és ezeket jeleníti meg. 
    // Nem csak elemi alakzatokat tartalmazhat, hanem 
    // összetett Panel objektumokat is!
    class Panel : IGraphic
    {
        // Tartalmazott alakzatok listája
        List<IGraphic> graphics = new List<IGraphic>();
        
        // A panel beágyazásának mélysége. A minta szempontjából
        // semmi jelentősége, csak a megjelenítést segíti
        // szemléletesebbé tenni.
        static int indentLevel = 0;

        // Megjeleníti a tartalmazott alakzatokat
        // A minta szempontjából a lényeg két sor: minden
        // tartalmazott graphics objektumra meghívja a Draw()-t
        // A többi kód csak azt szolgálja, hogy a panelnek 
        // legyen "kerete", illetve annak függvényében, hogy
        // milyen mélyen van beágyazva más panelokba 
        // (indentLevel), annyival bentebb húzva kezdi a 
        // tartalmazott elemek megjelenítését (így szemléletesebb
        // a megjelenítés).
        public void Draw()
        {
            try
            {
                
                writeIndented("Panel");
                indentLevel++;

                foreach (var g in graphics)
                {
                    // Ez nem szép, a demónkban "megteszi"
                    if (!(g is Panel)) 
                        writeIndent();

                    g.Draw();
                }
                
            }
            finally
            {
                indentLevel--;
                // writeIndented("-------------------------");
            }
        }

        void writeIndented(string text)
        {
            writeIndent();
            Console.WriteLine(text);
        }

        void writeIndent()
        {
            Console.Write(new string(' ', indentLevel * 4));
        }

        #region Műveletek a tartalmazott elemek kezelésésre

        public void Add(IGraphic g)
        {
            graphics.Add(g);
        }

        public void Remove(IGraphic g)
        {
            graphics.Remove(g);
        }

        public IGraphic GetChild(int index)
        {
            return graphics[index];
        }

        #endregion
    }
}
