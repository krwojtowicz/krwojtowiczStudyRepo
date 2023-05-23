using System;
using Time;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod, TestCategory("Time Constructor")]
        public void Time_Constructor_Default()
        {
            var expectedTime = new Time.Time(0, 0, 0);

            var time = new Time.Time();

            Assert.AreEqual(expectedTime, time);
        }

        [DataTestMethod, TestCategory("Time Constructor")]
        [DataRow(12, 30, 45)]
        [DataRow(0, 0, 0)]
        [DataRow(23, 59, 59)]
        public void Time_Constructor_WithValidValues(byte hour, byte minute, byte second)
        {
            var expectedTime = new Time.Time(hour, minute, second);

            var time = new Time.Time(hour, minute, second);

            Assert.AreEqual(expectedTime, time);
        }

        [DataTestMethod, TestCategory("Time Constructor")]
        [DataRow(24, 0, 0)]
        [DataRow(0, 60, 0)]
        [DataRow(0, 0, 60)]
        public void Time_Constructor_WithInvalidValues(byte hour, byte minute, byte second)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Time.Time(hour, minute, second));
        }

        [TestMethod, TestCategory("Time Comparison")]
        public void Time_Comparison_Equal()
        {
            var time1 = new Time.Time(12, 30, 45);
            var time2 = new Time.Time(12, 30, 45);

            Assert.AreEqual(time1, time2);
        }

        [TestMethod, TestCategory("Time Comparison")]
        public void Time_Comparison_LessThan()
        {
            var time1 = new Time.Time(10, 0, 0);
            var time2 = new Time.Time(12, 30, 45);

            Assert.IsTrue(time1 < time2);
        }

        [TestMethod, TestCategory("Time Comparison")]
        public void Time_Comparison_GreaterThan()
        {
            var time1 = new Time.Time(15, 45, 30);
            var time2 = new Time.Time(12, 30, 45);

            Assert.IsTrue(time1 > time2);
        }

    }

    [TestClass]
    public class TimePeriodTests
    {
        [TestMethod, TestCategory("TimePeriod Constructor")]
        public void TimePeriod_Constructor_Default()
        {
            var expectedTimePeriod = new TimePeriod(0);

            var timePeriod = new TimePeriod();

            Assert.AreEqual(expectedTimePeriod, timePeriod);
        }

        [DataTestMethod, TestCategory("TimePeriod Constructor")]
        [DataRow(2, 30, 45)]
        [DataRow(0, 0, 0)]
        [DataRow(23, 59, 59)]
        public void TimePeriod_Constructor_WithValidValues(int hours, int minutes, int seconds)
        {
            var expectedTimePeriod = new TimePeriod(hours, minutes, seconds);

            var timePeriod = new TimePeriod(hours, minutes, seconds);

            Assert.AreEqual(expectedTimePeriod, timePeriod);
        }

        [DataTestMethod, TestCategory("TimePeriod Constructor")]
        [DataRow(-1, 0, 0)]
        [DataRow(0, -1, 0)]
        [DataRow(0, 0, -1)]
        public void TimePeriod_Constructor_WithInvalidValues(int hours, int minutes, int seconds)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new TimePeriod(hours, minutes, seconds));
        }

        [TestMethod, TestCategory("TimePeriod Addition")]
        public void TimePeriod_Addition_Valid()
        {
            var timePeriod1 = new TimePeriod(2, 30, 45);
            var timePeriod2 = new TimePeriod(1, 15, 30);
            var expectedTimePeriod = new TimePeriod(3, 46, 15);

            var result = timePeriod1 + timePeriod2;

            Assert.AreEqual(expectedTimePeriod, result);
        }

        [TestMethod, TestCategory("TimePeriod Addition")]
        public void TimePeriod_Addition_Overflow()
        {
            var timePeriod1 = new TimePeriod(23, 59, 59);
            var timePeriod2 = new TimePeriod(0, 1, 2);
            var expectedTimePeriod = new TimePeriod(24, 1, 1);

            var result = timePeriod1 + timePeriod2;

            Assert.AreEqual(expectedTimePeriod, result);
        }

        [TestMethod, TestCategory("TimePeriod Subtraction")]
        public void TimePeriod_Subtraction_Valid()
        {
            var timePeriod1 = new TimePeriod(5, 30, 0);
            var timePeriod2 = new TimePeriod(2, 15, 0);
            var expectedTimePeriod = new TimePeriod(3, 15, 0);

            var result = timePeriod1 - timePeriod2;

            Assert.AreEqual(expectedTimePeriod, result);
        }

        [TestMethod, TestCategory("TimePeriod Subtraction")]
        public void TimePeriod_Subtraction_Underflow()
        {
            var timePeriod1 = new TimePeriod(2, 30, 0);
            var timePeriod2 = new TimePeriod(3, 0, 1);

            Assert.ThrowsException<ArgumentException>(() => timePeriod1 - timePeriod2);
        }
    }
}