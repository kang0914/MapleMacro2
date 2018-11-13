using System;
using System.Windows.Forms;
using MapleMacro2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapleMacro2.Tests
{
    [TestClass]
    public class KeysHelperUnitTest
    {
        [TestMethod]
        public void KeyCodeToPrettyPrint()
        {
            // 준비

            // 작업
            var result = KeysHelper.KeysToPrettyPrint(Keys.A);
            var result1 = KeysHelper.KeysToPrettyPrint(Keys.A | Keys.Control);
            var result2 = KeysHelper.KeysToPrettyPrint(Keys.A | Keys.Alt | Keys.Control);
            var result3 = KeysHelper.KeysToPrettyPrint(Keys.A | Keys.Shift);

            // 확인
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void GetModifiers()
        {
            // 준비

            // 작업
            var result = KeysHelper.GetModifiers(Keys.A);
            var result1 = KeysHelper.GetModifiers(Keys.A | Keys.Control);
            var result2 = KeysHelper.GetModifiers(Keys.A | Keys.Alt | Keys.Control);
            var result3 = KeysHelper.GetModifiers(Keys.A | Keys.Shift);

            // 확인
            Assert.IsTrue(result != null);
        }

        [TestMethod]
        public void ClearModifiers()
        {
            // 준비

            // 작업
            var result = KeysHelper.ClearModifiers(Keys.A);
            var result1 = KeysHelper.ClearModifiers(Keys.A | Keys.Control);
            var result2 = KeysHelper.ClearModifiers(Keys.A | Keys.Alt | Keys.Control);
            var result3 = KeysHelper.ClearModifiers(Keys.A | Keys.Shift);

            // 확인
            Assert.IsTrue(result != null);
        }
    }
}
