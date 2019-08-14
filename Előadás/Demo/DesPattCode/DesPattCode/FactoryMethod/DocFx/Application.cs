using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.FactoryMethod.DocFx
{
    // Keretrendszer alkalmazás ősosztály, az alkalmazásfejlesztőnek
    // ebből kell származtatni.
    abstract class Application
    {
        // A megnyitott dokuemntumok listája
        List<Document> documents = new List<Document>();

        // Amikor a felhasználó kiválasztja az „Open” menüelemet, a keretrendszer
        // meghívja az Application osztály OpenDocument műveletét
        public void OpenDocument()
        {
            // Útvonal bekérése felhasználótól
            // ...

            // A keretrendszer Application osztálya nem tudja, hogy milyen konkrét 
            // dokumentum osztályt kell létrehoznia, nem ismeri a típusát (csak azt 
            // tudja, hogy mikor kell létrehozni)
            // A konkrét Document leszármazott típus minden alkalmazás esetében más
            // A példánkban ez a TextDocument osztály, mely a keretrendszer megírásakor
            // jó eséllyel még nem is létezik, lehet más cég is írja.
            // Így az OpenDocument törzsébe nem írhatták be a keretrendszer készítői,
            // a „new TextDocument()” sort a példányosításhoz:
            // doc = new TextDocument();

            // Ez már jó, a new helyett egy CreateDocument absztrakt függvényt hívunk
            // a példányosításhoz.
            // Az alkalmazásfejlesztőnek le kell származtatnia az Application osztályból
            // (példánkban TextEditorApplication osztály), ebben felül kell definiálnia 
            // a CreateDocument műveletet úgy, hogy a TextDocument osztályból adjon
            // vissza egy objektumot.

            var doc = CreateDocument();
            documents.Add(doc);
            doc.Load();
        }

        // Ez a factory method (gyártó metódus), az alkalmazásfejlesztőnek a leszármazott
        // osztályban ebben kell példányosítania egy Document leszármazott objektumot és 
        // visszatérnie vele.
        protected abstract Document CreateDocument();
    }
}
