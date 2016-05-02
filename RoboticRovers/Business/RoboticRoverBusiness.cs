using RoboticRovers.Interfaces;
using RoboticRovers.Entities;
using RoboticRovers.Helpers;

namespace RoboticRovers.Business
{
    /// <summary>Do operations on the robot</summary>
    public class RoboticRoverBusiness
    {
        private IRoboticRover _roboticRover;

        /// <summary>RoboticRoverBusiness Constructor</summary>
        public RoboticRoverBusiness(IRoboticRover roboticRover)
        {
            _roboticRover = roboticRover;
        }

        /// <summary>Do operations on the robot</summary>
        public void DoActions(string actions)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                string currentAction = actions.Substring(i,1);

                if (currentAction == "M")
                {
                    this.Move();
                }
                else
                {
                    this.Rotate(currentAction.ToEnum<Direction>(true));
                }
            }
        }

        private void Move()
        {
            //TODO: Controls
            _roboticRover.Move();
        }

        private void Rotate(Direction direction)
        {
            //TODO: Controls
            _roboticRover.Rotate(direction);
        }
    }
}
