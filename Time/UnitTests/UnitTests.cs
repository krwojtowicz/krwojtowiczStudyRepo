using System;
using Time;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        #region Constructors 

        [TestMethod, TestCategory("Time Constructor")]
        public void Constructor_Time_default()
        {
            var time = new Time.Time();
            var defaultT = new Time.Time(0, 0, 0);
            Assert.AreEqual(defaultT, time);
        }

        [TestMethod, TestCategory("Time Constructor")]

        public void Constructor_h_m_s(byte h, byte m, byte s)
        {
            
        }
        #endregion
    }
}