using System;
using System.Collections.Generic;
using System.Text;



namespace DesPattCode.Intro
{
    // Csak zip algoritmust támogat
    class DataProcessor
    {
        // ...

        // Ciklusban beolvassa, tömöríti, majd feldolgozza a tömörített adatokat
        public void Run()
        {
            byte[] inputData;
            while ( (inputData = readData()) != null) {
                byte[] compressedData = compressData(inputData);
                processCompressedData(compressedData);
            }
        }

        byte[] readData() { /* adat olvasása hálózatról  */   }
        
        byte[] compressData(byte[] data) { /* adattömörítés zip algoritmussal */  }

        void  processCompressedData(byte[] data) { /* tömörített adat feldolgozása */; }
    }
}
