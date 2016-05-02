using System;
using RoboticRovers.Business;
using RoboticRovers.Entities;
using RoboticRovers.Helpers;

namespace RoboticRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] plateauCoordinates = Console.ReadLine().Split(' ');
            string[] firstRoboticRoverCoordinates = Console.ReadLine().Split(' ');
            string firstRoboticRoverActions = Console.ReadLine();
            string[] secondRoboticRoverCoordinates = Console.ReadLine().Split(' ');
            string secondRoboticRoverActions = Console.ReadLine();

            Plateau plateau = new Plateau()
            {
                UpperRightXCoordinate = Convert.ToInt16(plateauCoordinates[0]),
                UpperRightYCoordinate = Convert.ToInt16(plateauCoordinates[1])
            };

            RoboticRover[] roboticRover = new RoboticRover[2];

            roboticRover[0] = new RoboticRover(plateau);
            roboticRover[1] = new RoboticRover(plateau);
 
            roboticRover[0].Location = new Location()
            {
                XCoordinate = Convert.ToInt16(firstRoboticRoverCoordinates[0]),
                YCoordinate = Convert.ToInt16(firstRoboticRoverCoordinates[1]),
                Direction = firstRoboticRoverCoordinates[2].ToEnum<CompassDirection>(true)
            };

            roboticRover[1].Location = new Location()
            {
                XCoordinate = Convert.ToInt16(secondRoboticRoverCoordinates[0]),
                YCoordinate = Convert.ToInt16(secondRoboticRoverCoordinates[1]),
                Direction = secondRoboticRoverCoordinates[2].ToEnum<CompassDirection>(true)
            };
             
            RoboticRoverBusiness[] roboticRoverBusiness = new RoboticRoverBusiness[2];

            roboticRoverBusiness[0] = new RoboticRoverBusiness(roboticRover[0]);
            roboticRoverBusiness[1] = new RoboticRoverBusiness(roboticRover[1]);


            roboticRoverBusiness[0].DoActions(firstRoboticRoverActions);
            roboticRoverBusiness[1].DoActions(secondRoboticRoverActions);

            Console.Write(roboticRover[0].Location.XCoordinate + " ");
            Console.Write(roboticRover[0].Location.YCoordinate + " ");
            Console.WriteLine(roboticRover[0].Location.Direction.ToStringValue());

            Console.Write(roboticRover[1].Location.XCoordinate + " ");
            Console.Write(roboticRover[1].Location.YCoordinate + " ");
            Console.WriteLine(roboticRover[1].Location.Direction.ToStringValue());

            Console.ReadLine();
        }
    } 
}
