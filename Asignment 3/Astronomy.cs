using System;
using System.Collections.Generic;
using SpaceSim;

namespace Asignment_3
{
    public class Astronomy
    {
        List<SpaceObject> solarSystemManual;
        List<SpaceObject> solarSystem;
        List<String> file;
        FileReader reader = new FileReader();

        public Astronomy()
        {
            //Initialise SolarSystem
            solarSystem = new List<SpaceObject>();
            //Read file
            file = reader.readFile("objectData.txt");
            //Create object list
            CreateObjects();
        } //End Creator

        public void DrawObjects()
        {

            foreach (SpaceObject obj in solarSystem)
            {
                obj.Draw();
            }

            Console.ReadLine();
        }//END DrawObjects

        // Find space object with given name
        private SpaceObject FindSpaceObject(String name)
        {
            foreach (SpaceObject obj in solarSystem)
            {
                if (obj.GetName() == name) {
                    return obj;
                }
            }
            return null;
        }//END FindSpaceObject

        private void CreateObjects()
        {
            Tools tool = new Tools(); // TODO should be static?
            

            foreach (String obj in file)
            {
                String[] line = tool.words(obj);// get line
                Boolean token = false;
                // To generalise the creation of spaceObjects less dependant on the structure of the data
                if (line.Length > 7)
                {
                    if (line[2] == "Sun") //if it orbits the sun
                    {
                        //is it a planet?
                        if (Int32.Parse(line[7]) > 20000) //TODO need better test
                        {
                            solarSystem.Add(new Planet(line[0], FindSpaceObject(line[2]), Int32.Parse(line[3]), Int32.Parse(line[4]), Int32.Parse(line[7])));
                        }

                        else //otherwise dwarf planet or something else
                        {
                            solarSystem.Add(new DwarfPlanet(line[0], FindSpaceObject(line[2]), Int32.Parse(line[3]), Int32.Parse(line[4]), Int32.Parse(line[7])));
                        }
                    }//END if Sun Orbit

                    else if (line[0] == "Sun") // if object is the sun
                    {
                        solarSystem.Add(new Star(line[0], Int32.Parse(line[7])));
                        token = true;
                    }// END if Star

                    else if (token)// since now other objects, either moon or empty line
                    {
                        //Not an empty line
                        solarSystem.Add(new Moon(line[0], FindSpaceObject(line[2]), Int32.Parse(line[3]), Int32.Parse(line[4]), Int32.Parse(line[7])));
                    }//END it's something else
                }//END empty line test
            }
        }//END GetObjects()

    }//END class Astronomy
}//END Asignment_3