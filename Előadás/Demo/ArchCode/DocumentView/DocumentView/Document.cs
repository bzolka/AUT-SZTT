using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.ObserverDocView
{
    // Documentum ősosztály, vagyis a Observer minta Subject osztálya.
    // A minden dokumentumra/subject-re közös kódot tartalmazza, hogy
    // ne kelljen duplikálni. A mi példánkab csak egy leszármazott van, az
    // Exceldocument, de a gyakorlás keddvéért bevezettük ez az őst is.
    // Minimál implementáció, számos ellenőrzést elhagytunk (pl. Attach során
    // regisztrált-e már, Detach során regisztrálva van-e egyáltalán, stb.)
    class Document
    {
        List<IView> views = new List<IView>();

        // Beregisztrál egy új nézetet/observert.
        public void Attach(IView view)
        {
            views.Add(view);
        }

        // Kiregisztál egy nézetet/observert.
        public void Detach(IView view)
        {
            views.Remove(view);
        }

        // Szól az összes nézetnek (observernek), hogy frissítsék magukat.
        // Ez felel meg a subject Notify műveletének.
        protected void UpdateAllViews()
        {
            foreach (var v in views)
                v.Update();
        }
    }
}
