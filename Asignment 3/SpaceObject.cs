using System;

namespace SpaceSim
{
    public class SpaceObject
    {

        private String name; // OK
        private SpaceObject orbits;// OK
        private double objectRadius; //NA
        private double orbitalRadius; //OK
        private double orbitalPeriod; //OK
        private String color;
        private double xPos;
        private double yPos;

        public double YPos { get => yPos; set => yPos = value; }
        public double XPos { get => xPos; set => xPos = value; }
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
            XPos = orbitalRadius;
            YPos = 0;
    }//END Creator2

    public virtual void CalculatePosition(double time)
        {
            double rest = time % OrbitalPeriod; // remove multiple orbits
            double relativeTime = rest / OrbitalPeriod; // find % value of completed orbit 
            double orbitalDegrees = (double)relativeTime * 360; //multiply by 360 to find degrees moved.
            orbitalDegrees = orbitalDegrees * (Math.PI / 180); //Convert degrees to radians
            XPos = OrbitalRadius * Math.Sin(orbitalDegrees); //Calculate updated x position
            YPos = OrbitalRadius * Math.Cos(orbitalDegrees); //Calculate updated y position.
            //x = cos
            //y = sin
        }//END calculatePosition

        public virtual void Draw()
        {
            Console.Write(", Radius:" + ObjectRadius + "km");
            Console.Write(", Orbit:" + OrbitalRadius + "000 km");
            Console.Write(", periode:" + OrbitalPeriod + "days");
            Console.Write(", Position: " + XPos + ", " + YPos );
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