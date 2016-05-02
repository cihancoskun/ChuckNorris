using RoboticRovers.Entities;

namespace RoboticRovers.Interfaces
{
    public interface IRoboticRover
    { 
        /// <summary>Current Location of Robotic Rover</summary>
        Location Location { get; set; }

        /// <summary>Change the direction of the robot</summary>
        void Rotate(Direction direction);

        /// <summary>Move the robot</summary>
        void Move();
    }
}
