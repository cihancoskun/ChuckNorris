using RoboticRovers.Interfaces;

namespace RoboticRovers.Entities
{
    /// <summary>Robotic Rover</summary>
    public class RoboticRover : IRoboticRover
    {
        private Location _location;

        /// <summary>Location of Robotic Rover</summary>
        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        private IPlateau _plateau;

        /// <summary>Robotic Rover Constructor</summary>
        public RoboticRover(IPlateau plateau)
        {
            _plateau = plateau;
        }

        /// <summary>Change the direction of the robot</summary>
        public void Rotate(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (_location.Direction == CompassDirection.North)
                    {
                        _location.Direction = CompassDirection.West;
                        return;
                    }

                    _location.Direction = _location.Direction - 1;
                    break;
                case Direction.Right:
                    if (_location.Direction == CompassDirection.West)
                    {
                        _location.Direction = CompassDirection.North;
                        return;
                    }

                    _location.Direction = _location.Direction + 1;
                    break;
                default:
                    break;
            } 
        }

        /// <summary>Move the robot</summary>
        public void Move()
        {
            if ((_location.XCoordinate == _plateau.UpperRightXCoordinate && _location.Direction == CompassDirection.North)
                || (_location.YCoordinate == 0 && _location.Direction == CompassDirection.South)
                || (_location.YCoordinate == _plateau.UpperRightYCoordinate && _location.Direction == CompassDirection.East)
                || (_location.XCoordinate == 0 && _location.Direction == CompassDirection.West)
                )
            {
                //TODO: Err Msg
                return;
            }

            switch (_location.Direction)
            {
                case CompassDirection.North:
                    _location.YCoordinate++;
                    break;
                case CompassDirection.East:
                    _location.XCoordinate++;
                    break;
                case CompassDirection.South:
                    _location.YCoordinate--;
                    break;
                case CompassDirection.West:
                    _location.XCoordinate--;
                    break;
                default:
                    break;
            } 
        } 
    }
}
