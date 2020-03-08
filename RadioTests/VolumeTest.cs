using NUnit.Framework;
using RadioWPFApp;
namespace RadioTests
{
    public class VolumeTest
    {
        private Radio _radio;
        [SetUp]
        public void Setup()
        {
            _radio = new Radio();
            _radio.TurnOn();
        }

        [TestCase(0.0)]
        [TestCase(0.1)]
        [TestCase(0.2)]
        [TestCase(0.3)]
        [TestCase(0.4)]
        [TestCase(0.5)]
        [TestCase(0.6)]
        [TestCase(0.7)]
        [TestCase(0.8)]
        [TestCase(0.9)]
        [TestCase(1.0)]
        public void ChangeToValidVolumeTest(double newVolume)
        {
            _radio.Volume = newVolume;
            Assert.AreEqual(newVolume, _radio.Volume);
        }

        [TestCase(-0.8)]
        [TestCase(-2.0)]
        [TestCase(5.0)]
        public void ChangeToInvalidVolumeTest(double newVolume)
        {
            _radio.Volume = 0.5;

            _radio.Volume = newVolume;

            Assert.AreEqual(0.5, _radio.Volume);
        }
    }
}