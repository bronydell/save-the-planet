using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestDirectionHitter
    {
        private Vector2 treshold = new Vector2(0.2f, 0.2f);

        // A Test behaves as an ordinary method
        [Test]
        public void TestDirectionHitterSimplePasses()
        {
            var test = WrongDirection(new Vector2(5, 5), new Vector2(-5, -4.5f));
            Assert.IsTrue(test);
        }

        private bool WrongDirection(Vector2 dir, Vector2 obstacle)
        {
            var composition = dir.normalized + obstacle.normalized;
            return composition.x < treshold.x && composition.y < treshold.y;
        }
    }
}
