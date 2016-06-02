using System;
using System.Collections.Generic;
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


        private GetReadyProcessor GetReadyProcessorInstance()
        {
            return new GetReadyProcessor();
        }
    }
}
