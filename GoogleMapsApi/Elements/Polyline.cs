
using GoogleMapsWrapper.Types;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsWrapper.Elements
{

    public class Polyline : GoogleMapElement
    {
        public int Weight { get; set; } //pixels
        public bool Geodesic { get; set; }
        public char? Label { get; set; }

        public ReadOnlyCollection<GpsCoordinate> Coordinates
        {
            get => new ReadOnlyCollection<GpsCoordinate>(coordinates);

        }
        private IList<GpsCoordinate> coordinates;

        public Polyline(IList<GpsCoordinate> Coordinates, string? Id = null, string? Name = null)
        {
            this.coordinates = Coordinates;
            this.Id = Id;
            this.Name = Name;

            //defaults:
            this.Color = Color.Yellow;
            Geodesic = false;
            Weight = 5;
        }



        public void AddCoordinate(GpsCoordinate coordinate)
        {
            coordinates.Add(coordinate);
        }

        public void AddCoordinate(string coordinate)
        {
            var coord = GpsCoordinate.Parse(coordinate);
            coordinates.Add(coord);
        }

        public void InsertCoordinate(GpsCoordinate coordinate, int index)
        {
            coordinates.Insert(index, coordinate);
        }

        public void RemoveCoordinate(GpsCoordinate coordinate)
        {
            coordinates.Remove(coordinate);
            //note: this may remove duplicate values. IList uses the Equals operator to determine qualification for removal. 
        }
        public void RemoveCoordinate(int index)
        {
            coordinates.RemoveAt(index);
        }

        /// <summary>
        /// Returns true if the object contains 2 or more coordinates.
        /// </summary>
        public bool IsEmpty()
        {
            if (this.coordinates.Count >1) return false; return true;
        }

        public override string ToString()
        {
            return string.Join(';', this.Coordinates);
        }




    }












}