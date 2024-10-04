using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Utilities
{
    /// <summary>
    /// A static class to encode a list of GPS coordinates using Google's polyline shortening encoding algorithm.
    /// </summary>
    public static class PolylineEncoder
    {
        public static string Encode(IList<GpsCoordinate> coordinates)
        {

            if (coordinates.Count < 2) { throw new GoogleMapsApiException("Invalid number of coordinates."); }

            StringBuilder encodedString = new StringBuilder();
            long prevLat = 0;
            long prevLng = 0;

            foreach (var coord in coordinates)
            {
                long lat = (long)(coord.Latitude * 1e5m);
                long lng = (long)(coord.Longitude * 1e5m);

                // Delta encoding
                long dLat = lat - prevLat;
                long dLng = lng - prevLng;

                // Encoding delta values
                encodedString.Append(EncodeValue(dLat));
                encodedString.Append(EncodeValue(dLng));

                prevLat = lat;
                prevLng = lng;
            }

            return encodedString.ToString();
        }

        private static string EncodeValue(long value)
        {
            // Zigzag encoding
            value = (value < 0) ? ~(value << 1) : (value << 1);

            // Encode each 5 bits
            StringBuilder encoded = new StringBuilder();
            while (value >= 0x20)
            {
                encoded.Append((char)((0x20 | (value & 0x1F)) + 63));
                value >>= 5;
            }
            encoded.Append((char)(value + 63));

            return encoded.ToString();
        }
    }

}
