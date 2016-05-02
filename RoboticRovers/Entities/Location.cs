
namespace RoboticRovers.Entities
{
    /// <summary>Location of RoboticRover</summary>
    public class Location
    {
        /// <summary>Current x co-ordinate of Robotic Rover</summary>
        public int XCoordinate { get; set; }

        /// <summary>Current y co-ordinate of Robotic Rover</summary>
        public int YCoordinate { get; set; }

        /// <summary>Current direction of Robotic Rover</summary>
        public CompassDirection Direction { get; set; }
    }
}
