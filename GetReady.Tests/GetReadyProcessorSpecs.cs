using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetReady.Domain;

namespace GetReady.Tests
{
    [TestClass]
    public class GetReadyProcessorSpecs
    {
        [TestMethod]
        public void Successful_Result_For_Input_HOT_8_6_4_2_1_7_No_Commas()
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
        public void Successful_Result_For_Input_HOT_8_6_4_2_1_7()
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
        public void Successful_Result_For_Input_COLD_8_6_3_4_2_5_1_7()
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
        public void Failure_Result_For_Input_HOT_8_6_6()
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
        public void Failure_Result_For_Input_HOT_8_6_3()
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
        public void Failure_Result_For_Input_COLD_8_6_3_4_2_5_7()
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
        public void Failure_Result_For_Input_COLD_6()
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
