using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetReady.Domain;

namespace GetReady.Tests
{
    [TestClass]
    public class GetReadyProcessorTests
    {
        [TestMethod]
        public void Input_HOT_8_6_4_2_1_7_NoCommas_ShouldBeSuccessful()
        {
            List<string> args = new List<string>();
            args.Add("HOT"); 
            args.Add("8");
            args.Add("6");
            args.Add("4");
            args.Add("2");
            args.Add("1");
            args.Add("7");

            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady(args.ToArray());

            Assert.IsTrue(result == "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house");
        }

        [TestMethod]
        public void Input_HOT_8_6_4_2_1_7_NoCommas_SingleString_ShouldBeSuccessful()
        {
            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady("HOT 8 6 4 2 1 7");

            Assert.IsTrue(result == "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house");
        }

        [TestMethod]
        public void Input_HOT_8_6_4_2_1_7_SingleString_ShouldBeSuccessful()
        {
            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady("HOT 8, 6, 4, 2, 1, 7");

            Assert.IsTrue(result == "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Input_HOT8_6_4_2_1_7_ShouldThrowException()
        {
            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady("HOT8, 6, 4, 2, 1, 7");
        }

        [TestMethod]
        public void Input_HOT_8_6_4_2_1_7_ShouldBeSuccessful()
        {
            List<string> args = new List<string>();
            args.Add("HOT");
            args.Add("8,");
            args.Add("6,");
            args.Add("4,");
            args.Add("2,");
            args.Add("1,");
            args.Add("7");

            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady(args.ToArray());

            Assert.IsTrue(result == "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house");
        }


        [TestMethod]
        public void Input_COLD_8_6_3_4_2_5_1_7_ShouldBeSuccessful()
        {
            List<string> args = new List<string>();
            args.Add("COLD");
            args.Add("8,");
            args.Add("6,");
            args.Add("3,");
            args.Add("4,");
            args.Add("2,");
            args.Add("5,");
            args.Add("1,");
            args.Add("7");

            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady(args.ToArray());

            Assert.IsTrue(result == "Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house");
        }

        [TestMethod]
        public void Input_HOT_8_6_6_ShouldFail()
        {
            List<string> args = new List<string>();
            args.Add("HOT");
            args.Add("8,");
            args.Add("6,");
            args.Add("6,");

            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady(args.ToArray());

            Assert.IsTrue(result == "Removing PJs, shorts, fail");
        }


        [TestMethod]
        public void Input_HOT_8_6_3_ShouldFail()
        {
            List<string> args = new List<string>();
            args.Add("HOT");
            args.Add("8,");
            args.Add("6,");
            args.Add("3,");

            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady(args.ToArray());

            Assert.IsTrue(result == "Removing PJs, shorts, fail");
        }

        [TestMethod]
        public void Input_COLD_8_6_3_4_2_5_7_ShouldFail()
        {
            List<string> args = new List<string>();
            args.Add("COLD");
            args.Add("8,");
            args.Add("6,");
            args.Add("3,");
            args.Add("4,");
            args.Add("2,");
            args.Add("5,");
            args.Add("7");

            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady(args.ToArray());

            Assert.IsTrue(result == "Removing PJs, pants, socks, shirt, hat, jacket, fail");
        }


        [TestMethod]
        public void Input_COLD_6_ShouldFail()
        {
            List<string> args = new List<string>();
            args.Add("COLD");
            args.Add("6,");

            var getReadyProcessor = GetReadyProcessorInstance();

            var result = getReadyProcessor.GetReady(args.ToArray());

            Assert.IsTrue(result == "fail");
        }

        [Ignore]
        [TestMethod]
        public void AvailableCommands_ShouldBeNonNullOrEmpty()
        {
            var getReadyProcessor = GetReadyProcessorInstance();

            var availableCommands = getReadyProcessor.AvailableCommands;

            Assert.IsNotNull(availableCommands);
            Assert.IsTrue(availableCommands.Any());
        }

        private GetReadyProcessor GetReadyProcessorInstance()
        {
            return new GetReadyProcessor();
        }
    }
}
