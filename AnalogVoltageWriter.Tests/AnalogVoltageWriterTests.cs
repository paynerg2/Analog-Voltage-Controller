using System;
using AnalogVoltageController.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NationalInstruments.DAQmx;

namespace AnalogVoltageController.Tests
{
    [TestClass]
    public class AnalogVoltageWriterTests
    {
        [TestMethod]
        public void Initialize_ShouldNotBeNull()
        {
            //Arrange
            IVoltageWriter writer = new AnalogVoltageWriter();
            string physicalChannelName = "Dev1/Ao0";

            //Act
            Task writerTask = writer.Initialize(physicalChannelName);

            //Assert
            Assert.IsNotNull(writerTask);
        }

        [TestMethod]
        public void Initialize_ShouldProduceOneAOChannel()
        {
            //Arrange
            IVoltageWriter writer = new AnalogVoltageWriter();
            string physicalChannelName = "Dev1/Ao0";

            //Act
            Task writerTask = writer.Initialize(physicalChannelName);

            //Assert
            Assert.AreEqual(1, writerTask.AOChannels.Count);
        }
    }
}
