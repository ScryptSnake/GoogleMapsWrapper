using GoogleMapsWrapper.StaticMaps;
using GoogleMapsWrapper.Types;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Elements
{

    public class Path : GoogleMapElement
    {
        public int Weight { get; set; } //pixels
        public bool Geodesic { get; set; }
        public char? Label { get; set; }

        public ReadOnlyCollection<GpsCoordinate> Coordinates
        {
            get => new ReadOnlyCollection<GpsCoordinate>(coordinates); //readonly snapshot of the internal private collection.
        }
        private Collection<GpsCoordinate> coordinates;

        public Path(Collection<GpsCoordinate> Coordinates, string? Id = null, string? Name = null)
        {
            this.coordinates = Coordinates;
            this.Id= Id;
            this.Name= Name;

            //defaults:
            base.Color = Color.Red;
            Geodesic = false;
            Weight = 5;
        }

        public void AddCoordinate(GpsCoordinate coord)
        {
            //TODO:
        }

        public void RemoveCoordinate(GpsCoordinate coord)
        {
            //TODO:
        }
    }












}