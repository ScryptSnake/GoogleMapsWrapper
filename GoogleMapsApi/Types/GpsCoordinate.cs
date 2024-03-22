using System.Globalization;

namespace GoogleMapsWrapper.Types
{
    public readonly struct GpsCoordinate : IEquatable<GpsCoordinate>, IFormattable
    {

        //Constructor
        public GpsCoordinate(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public decimal Latitude { get; }
        public decimal Longitude { get; }

        public override string ToString()
            => ToString(null, null);

        public static GpsCoordinate Parse(string s)
        {
            if (TryParse(s, out var result))
                return result;
            throw new FormatException();
        }

        public static bool TryParse(string? s, out GpsCoordinate result)
            => TryParse(s.AsSpan(), out result);

        public static bool TryParse(ReadOnlySpan<char> s, out GpsCoordinate result)
        {
            result = default;
            if (s.IsEmpty)
                return false;
            var splitIndex = s.IndexOf(',');
            if (splitIndex < 0)
                return false;
            var latitudeString = s.Slice(0, splitIndex).Trim();
            var longitudeString = s.Slice(splitIndex + 1).Trim();
            if (!decimal.TryParse(latitudeString, CultureInfo.InvariantCulture, out var latitude))
                return false;
            if (!decimal.TryParse(longitudeString, CultureInfo.InvariantCulture, out var longitude))
                return false;
            result = new(latitude, longitude);
            return true;
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format is not null)
                throw new NotImplementedException();
            return $"{Latitude}, {Longitude}";
        }

        public bool Equals(GpsCoordinate other)
            => Latitude == other.Latitude && Longitude == other.Longitude;
        public override bool Equals(object? obj)
            => obj is GpsCoordinate other && Equals(other);
        public override int GetHashCode() => HashCode.Combine(Latitude, Longitude);
        public static bool operator ==(GpsCoordinate left, GpsCoordinate right)
            => left.Equals(right);
        public static bool operator !=(GpsCoordinate left, GpsCoordinate right)
            => !left.Equals(right);
    }
}