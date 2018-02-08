using System;
using System.Collections.Generic;
using SpaceSim;

namespace Asignment_3
{
    public class Astronomy
    {
        List<SpaceObject> solarSystemManual;
        List<String> solarSystem;
        List<String> solarSystem2;
        fileReader reader = new fileReader();

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

            solarSystem = reader.readFile("objectData.txt");
        } //End Creator

        public void createObjects()
        {
            Tools tool = new Tools();
            foreach(String obj in solarSystem)
            {
                //Console.WriteLine(tool.words(obj).Length);
            }

           
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