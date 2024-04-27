using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsWrapper.Types;

namespace TestProject
{
    public class GoogleMapsWrapperTests
    {
        public readonly record struct TestCase(string Text, decimal Latitude, decimal Longitude);

        public static IReadOnlyList<TestCase> TestCases { get; } = new TestCase[]
        {
        new TestCase("41.40338, 2.17403", 41.40338m,  2.17403m),
        new TestCase("46, 22", 46, 22),
        };

        [Test]
        [TestCaseSource(nameof(TestCases))] //indicate to the compiler we want to use TestCases property as case source (list)
        public void CoordinatesShouldParse(TestCase testCase)
        {
            Assert.That(GpsCoordinate.TryParse(testCase.Text, out _), Is.True);
        }
        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void CoordinatesHaveCorrectValues(TestCase testCase)
        {

            Assert.That(GpsCoordinate.TryParse(testCase.Text, out var result), Is.True);
            Assert.That(result.Latitude, Is.EqualTo(testCase.Latitude));
            Assert.That(result.Longitude, Is.EqualTo(testCase.Longitude));
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void ToStringOutputIsCorrect(TestCase testCase)
        {
            Assert.That(GpsCoordinate.TryParse(testCase.Text, out var result), Is.True);
        }

    }
}
