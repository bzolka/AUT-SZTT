using System;
using System.Collections.Generic;
using System.Text;

namespace DesPattCode.Intro
{

    enum CompressionAlg { Zip, Zip7, Rar };

    // Konstruktorban átadjuk enum paraméterként, milyen tömörítő algoritmust
    // szeretnénk, ezt eltároljuk egy tagváltozóban(compressionAlg)
    // Ezen tagváltozó alapján választjuk ki később a tömörítő algoritmust.
    // Problémák:
    // 1. A megoldás nem bővíthető könnyen új algoritmussal
    // A DataProcessor2 osztályba be van égetve, milyen algoritmusokat ismer.
    // Ha újat szeretnék bevezetni, a DataProcessor2 kódját módosítani kell.
    // Ezt követően pedig újra kell tesztelni az osztályt.
    // Olyan bővíthetőségi megoldást keresünk, mely NEM igényli a DataProcessor2
    // módosítását új algoritmus bevezetésekor.
    // A megoldás majd a STRATEGY tervezési minta alkalmazása lesz,
    // később/rövidesen visszatérünk rá.
    class DataProcessor2
    {
        // ...

        CompressionAlg compressionAlg;

        public DataProcessor(CompressionAlg compressionAlg)
        {
            this.compressionAlg = compressionAlg;
        }

        public void Run()
        {
            byte[] inputData;
            while ((inputData = readData()) != null)
            {
                byte[] compressedData = compressData(inputData);
                processCompressedData(compressedData);
            }
        }

        byte[] readData() { /* adat olvasása hálózatról */   }
        void processCompressedData(byte[] data) { /* tömörített adat feldolgozása */; }


        byte[] compressData(byte[] data)
        {
            switch (compressionAlg)
            {
                case CompressionAlg.Zip:
                    return compressUsingZip(data);
                case CompressionAlg.Zip7:
                    return compressUsingZip7(data);
                case CompressionAlg.Rar:
                    return compressUsingRar(data);
            }
        }

        byte[] compressUsingZip(byte[] data) { /* adattömörítés zip alg. */ }
        byte[] compressUsingZip7(byte[] data) { /* adattömörítés 7zip alg. */ }
        byte[] compressUsingRar(byte[] data) { /* adattömörítés rar alg. */ }

    }
}
