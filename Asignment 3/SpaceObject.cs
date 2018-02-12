using System;

namespace SpaceSim
{
    public class SpaceObject
    {

        private String name; // OK
        private SpaceObject orbits;// OK
        private double objectRadius { get; set; } //NA
        public double logObjectRadius { get; set; }
        public double orbitalRadius { get; set; } //OK
        private double orbitalPeriod { get; set; } //OK
        private String color { get; set; }
        public double xPos {  get; set; }
        public double yPos {  get; set; }
        private double xPosScaled { get; set; }
        private double yPosScaled { get; set; }

    
        public double OrbitalPeriod { get => orbitalPeriod; set => orbitalPeriod = value; }
        public double OrbitalRadius { get => orbitalRadius; set => orbitalRadius = value; }
        public double ObjectRadius { get => objectRadius; set => objectRadius = value; }
        public SpaceObject Orbits { get => orbits; set => orbits = value; }
        public string Name { get => name; set => name = value; }
        public string Color { get => color; set => color = value; }

        // public SpaceObject(String name) {
        //     this.name = name;
        // }//END Creator1
        public SpaceObject(String name, SpaceObject orbits, double orbitalRadius, double orbitalPeriod, double objectRadius)
        {
            this.Name = name;
            this.Orbits = orbits;
            this.OrbitalRadius = orbitalRadius;
            this.OrbitalPeriod = orbitalPeriod;
            this.ObjectRadius = objectRadius;
            this.logObjectRadius = Math.Log10(objectRadius)*10;
            xPos = 0;
            yPos = 0;
            CalculatePosition(0);
        }//END Creator2

    public virtual void CalculatePosition(double time)
        {
                xPos = orbitalRadius +
                (int)(Math.Cos(time * orbitalPeriod * Math.PI / 180) * orbitalRadius);
                yPos = orbitalRadius +
                (int)(Math.Sin(time * orbitalPeriod * Math.PI / 180) * orbitalRadius);

                yPosScaled = Math.Log10(orbitalRadius) +
                (int)(Math.Sin(time * orbitalPeriod * Math.PI / 180) * Math.Log10(orbitalRadius));
                xPosScaled = Math.Log10(orbitalRadius) +
                (int)(Math.Cos(time * orbitalPeriod * Math.PI / 180) * Math.Log10(orbitalRadius));
            /*
                            double rest = time % OrbitalPeriod; // remove multiple orbits
                        double relativeTime = rest / OrbitalPeriod; // find % value of completed orbit 
                        double orbitalDegrees = (double)relativeTime * 360; //multiply by 360 to find degrees moved.
                        orbitalDegrees = orbitalDegrees * (Math.PI / 180); //Convert degrees to radians
                        XPos = OrbitalRadius * Math.Sin(orbitalDegrees); //Calculate updated x position
                        YPos = OrbitalRadius * Math.Cos(orbitalDegrees); //Calculate updated y position.
                        XPosScaled = logOrbitalRadius * Math.Sin(orbitalDegrees); //Calculate updated virtual x coord
                        YPosScaled = logOrbitalRadius * Math.Cos(orbitalDegrees); //Calculate updated virtual y coord
                                                                     //x = cos
                                                                     //y = sin
            */
        }//END calculatePosition




        public virtual void Draw()
        {
            Console.Write(", Radius:" + ObjectRadius + "km");
            Console.Write(", Orbit:" + OrbitalRadius + "000 km");
            Console.Write(", periode:" + OrbitalPeriod + "days");
            Console.Write(", Position: " + xPos + ", " + yPos );
            Console.WriteLine();
        }//END Draw
    }//END class SpaceObject

    public class Star : SpaceObject
    {
        public Star(String name, double objectRadius) : base(name, null, 0, 0, objectRadius) { }
        public override void Draw()
        {
            Console.Write("Star: ");
            Console.Write(Name);
            base.Draw();
        }//END Draw
    }//END class Star

    public class Planet : SpaceObject
    {
        public Planet(String name, SpaceObject orbits, double orbitalRadius, double orbitalPeriod, double objectRadius) : base(name, orbits, orbitalRadius, orbitalPeriod, objectRadius) { }
        public override void Draw()
        {
            Console.Write("Planet: ");
            Console.Write(Name);
            Console.Write(" Orbits:" + Orbits.Name);
            base.Draw();
        }//END Draw
    }//END class Planet

    public class Moon : SpaceObject
    {
        public Moon(String name, SpaceObject orbits, double orbitalRadius, double orbitalPeriod, double objectRadius) : base(name, orbits, orbitalRadius, orbitalPeriod, objectRadius) { }
        public override void Draw()
        {
            Console.Write("Moon: ");
            Console.Write(Name);
            Console.Write(" Orbits:" + Orbits.Name);
            base.Draw();
        }//END Draw
    }//END class Moon

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(String name, SpaceObject orbits, double orbitalRadius, double orbitalPeriod, double objectRadius) : base(name, orbits, orbitalRadius, orbitalPeriod, objectRadius) { }
        public override void Draw()
        {
            Console.Write("DwarfPlanet: ");
            Console.Write(Name);
            Console.Write(" Orbits:" + Orbits.Name);
            base.Draw();
        }//END Draw
    }//END class DwarfPlanet

}//END Namespace