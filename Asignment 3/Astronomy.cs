using System;
using System.Collections.Generic;
using SpaceSim;

namespace assignment3
{
    public class Astronomy
    {
        List<SpaceObject> solarSystemManual;
        List<SpaceObject> solarSystem;

        public Astronomy()
        {
            //List<SpaceObject> solarSystemManual = new List<SpaceObject> {
            solarSystemManual = new List<SpaceObject> {
            new Star("Sun", null, 1000, 0, 0),
            new Planet("Mercury", "Sun", 100, 1100, 10),
            new Planet("Venus", "Sun", 100, 1100, 10),
            new Planet("Terra", "Sun", 100, 1100, 10),
            new Moon("The Moon", "Terra", 100, 1100, 10),
            new Planet("Mars", "Sun", 100, 1100, 10),
            new Moon("Phobos", "Mars", 100, 1100, 10),
            new Moon("Deimos", "mars", 100, 1100, 10),
            new DwarfPlanet("Ceres", "Sun", 100, 1100, 10),
            new Planet("Jupiter", "Sun", 100, 1100, 10),
            new Moon("IO", "Jupiter", 100, 1100, 10),
            }; //END List

            solarSystem = new List<SpaceObject>
            {
            };//END List
        } //End Creator

        public void getObjects()
        {

        }//END getObjects()

        public void drawObjects()
        {

            foreach (SpaceObject obj in solarSystemManual)
            {
                obj.Draw();
            }

            Console.ReadLine();
        }

        //private

    }//END class Astronomy
}