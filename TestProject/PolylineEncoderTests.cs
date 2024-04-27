using GoogleMapsWrapper.Exceptions;
using GoogleMapsWrapper.Types;
using GoogleMapsWrapper.Utilities;
namespace TestProject
{


    [TestFixture] //Indicates this is a container for like tests.
    public class PolylineEncoderTests
    {
        [SetUp] //Indicates this method should be ran before any tests.
        public void Setup()
        {
        }

        [Test] //Indicates this block of code should be tested.
        public void EncodePolyline_WithLessThanTwoCoordinates_ShouldThrow()
        {
            IList<GpsCoordinate> coordinates = new List<GpsCoordinate>();
            coordinates.Add(new GpsCoordinate(41.903830m, -77.440093m));

            Assert.Throws<GoogleMapsApiException>(() => PolylineEncoder.Encode(coordinates));
        }


        [Test]
        public void EncodePolyline_WithVerifiedOutput_ShouldBeEqual()
        {
            IList<GpsCoordinate> coordinates = new List<GpsCoordinate>();
            coordinates.Add(new GpsCoordinate(41.903830m, -77.440093m));
            coordinates.Add(new GpsCoordinate(45.503830m, -75.410093m));
            coordinates.Add(new GpsCoordinate(45.903830m, -73.460093m));

            const string expectedValue = "}iw~Fp_twM_c~TonkK_cmAoz{J"; //acquired from Google's interactive encoding utility.

            Assert.That(PolylineEncoder.Encode(coordinates), Is.EqualTo(expectedValue));
        }

    }
}