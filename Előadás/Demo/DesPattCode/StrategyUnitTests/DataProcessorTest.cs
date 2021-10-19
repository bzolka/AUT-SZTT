using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesPattCode.Strategy;

namespace StrategyUnitTests
{

    // Pár egyszerű tesztet végez a DataProcessor-ra vonatkozóan.
    // A DataProcessor akkor lenne igazán unit tesztelhető, ha a
    // readData művelete is ki lenne szervezve egy stratégiába.
    // Mivel ez nem tehető meg jelenleg, a tesztjeink lassúak, meg
    // kell várni a teljes feldolgozást.
    [TestClass]
    public class DataProcessorTest
    {
        // Ellenőrizzük, hogy a DataProcessor a compression strategy
        // InitCompression műveletét csak egyszer hívja.
        [TestMethod]
        public void Test_InitCompression_CalledOnce()
        {
            // Előkészítés
            var compressionStrat = new CallCounterCompressionStrategy();
            var processor = new DataProcessor(
               compressionStrat,
               new NonCancellableCancellationStrategy()
               );

            // Futtatás
            processor.Run();

            // Ellenőrzés
            Assert.AreEqual(1, compressionStrat.InitCompressionCount);

        }

        // Ellenőrizzük, hogy a DataProcessor a compression strategy
        // CloseCompression műveletét csak egyszer hívja.
        [TestMethod]
        public void Test_CloseCompression_CalledOnce()
        {
            // Előkészítés
            var compressionStrat = new CallCounterCompressionStrategy();
            var processor = new DataProcessor(
               compressionStrat,
               new NonCancellableCancellationStrategy()
               );

            // Futtatás
            processor.Run();

            // Ellenőrzés
            Assert.AreEqual(1, compressionStrat.CloseCompressionCount);
        }

        // Ellenőrizzük, hogy a DataProcessor a compression strategy
        // InitCompression műveletét a CloseCompression művelet előtt hívja.
        [TestMethod]
        public void Test_InitCalledBeforeCloseCompression()
        {
            // Előkészítés
            var compressionStrat = new CallCounterCompressionStrategy();
            var processor = new DataProcessor(
               compressionStrat,
               new NonCancellableCancellationStrategy()
               );

            // Futtatás
            processor.Run();

            // Ellenőrzés
            Assert.IsTrue(compressionStrat.InitCompressionCalled_Before_CloseCompressionCount);
        }
    }
}
