using System;
using System.Collections.Generic;
using SpaceSim;

namespace Asignment_3
{
    public class Astronomy
    {
        public List<SpaceObject> SolarSystem { get; set; }
        List<String> file;
        FileReader reader = new FileReader();

        public Astronomy()
        {
            //Initialise SolarSystem
            SolarSystem = new List<SpaceObject>();
            //Read file
            file = reader.readFile("objectData.txt");
            //Create object list
            CreateObjects();
        } //End Creator

        public void DrawObjects()
        {

            foreach (SpaceObject obj in SolarSystem)
            {
                obj.Draw();
            }

            //Console.ReadLine();
        }//END DrawObjects

        // Find space object with given name
        private SpaceObject FindSpaceObject(String name)
        {
            foreach (SpaceObject obj in SolarSystem)
            {
                if (obj.Name == name) {
                    return obj;
                }
            }
            return null;
        }//END FindSpaceObject

        private void CreateObjects()
        {
            Tools tool = new Tools(); // TODO should be static?
            Boolean token = false;

            foreach (String obj in file)
            {
                String[] line = tool.words(obj);// get line        
                // To generalise the creation of spaceObjects less dependant on the structure of the data
                if (line.Length > 7)
                {
                    if (line[2] == "Sun") //if it orbits the sun
                    {
                        //is it a planet?
                        if (makeDouble(line[7]) > 2000) //TODO need better test
                        {
                            SolarSystem.Add(new Planet(line[0], FindSpaceObject(line[2]), makeDouble(line[3]), makeDouble(line[4]), makeDouble(line[7])));
                        }

                        else //otherwise dwarf planet or something else
                        {
                            SolarSystem.Add(new DwarfPlanet(line[0], FindSpaceObject(line[2]), makeDouble(line[3]), makeDouble(line[4]), makeDouble(line[7])));
                        }
                    }//END if Sun Orbit

                    else if (line[0] == "Sun") // if object is the sun
                    {
                        SolarSystem.Add(new Star(line[0], makeDouble(line[7])));
                        token = true;
                    }// END if Star

                    else if (token)// since now other objects, either moon or empty line
                    {
                        //Not an empty line
                        SolarSystem.Add(new Moon(line[0], FindSpaceObject(line[2]), makeDouble(line[3]), makeDouble(line[4]), makeDouble(line[7])));
                    }//END it's something else
                }//END empty line test
            }
        }//END GetObjects()

        //Nececary because system differating comma separator is a thing!
        //TODO, handle errors diferently
        private Double makeDouble(String inp)
        {
            Double result = 0;
            try
            {
                result = Convert.ToDouble(inp, System.Globalization.CultureInfo.InvariantCulture);
                //Console.WriteLine("Converted '{0}' to {1}.", inp, result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}' to a Double.", inp);
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is outside the range of a Double.", inp);
            }
            return result;

        }
    }//END class Astronomy
}//END Asignment_3