using RoboticRovers.Interfaces; 

namespace RoboticRovers.Entities
{
    /// <summary>Plateau</summary>
    public class Plateau : IPlateau
    {
        /// <summary>UpperRight X Coordinate of Plateau</summary>
        public int UpperRightXCoordinate { get; set; }

        /// <summary>UpperRight Y Coordinate of Plateau</summary>
        public int UpperRightYCoordinate { get; set; } 
    }
}
