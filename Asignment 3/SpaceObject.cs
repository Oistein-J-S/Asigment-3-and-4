using System;

namespace SpaceSim
{
    public class SpaceObject
    {

        protected String name; // OK
        protected SpaceObject orbits;// OK
        protected double objectRadius; //NA
        protected double orbitalRadius; //OK
        protected double orbitalPeriod; //OK
        protected double xPos;
        protected double yPos;

        // public SpaceObject(String name) {
        //     this.name = name;
        // }//END Creator1
        public SpaceObject(String name, SpaceObject orbits, double orbitalRadius, double orbitalPeriod, double objectRadius)
        {
            this.name = name;
            this.orbits = orbits;
            this.orbitalRadius = orbitalRadius;
            this.orbitalPeriod = orbitalPeriod;
            this.objectRadius = objectRadius;
            xPos = orbitalRadius;
            yPos = 0;
    }//END Creator2

        //Setters
        public void SetName(String name)
        {
            this.name = name;
        }
        public void SetObjectRadius(double objectRadius)
        {
            this.objectRadius = objectRadius;
        }
        public void SetOrbitalRadius(double orbitalRadius)
        {
            this.orbitalRadius = orbitalRadius;
        }
        public void SetOrbitalPeriod(double orbitalPeriod)
        {
            this.orbitalPeriod = orbitalPeriod;
        }
        public void SetXPos(double xPos)
        {
            this.xPos = xPos;
        }
        public void SetYPos(double yPos)
        {
            this.yPos = yPos;
        }
        //Getters
        public String GetName()
        {
            return this.name;
        }
        public double GetObjectRadius()
        {
            return this.objectRadius;
        }
        public double GetOrbitalRadius()
        {
            return this.orbitalRadius;
        }
        public double GetOrbitalPeriod()
        {
            return this.orbitalPeriod;
        }
        public double GetXPos()
        {
            return xPos;
        }
        public double GetYPos()
        {
            return yPos;
        }

        public virtual double CalculatePosition(double time)
        {
            double rest = time % orbitalPeriod; // remove multiple orbits
            double relativeTime = rest / orbitalPeriod; // find % value of completed orbit 
            double orbitalDegrees = (double)relativeTime * 360; //multiply by 360 to find degrees moved.
            orbitalDegrees = orbitalDegrees * (Math.PI / 180); //Convert degrees to radians
            xPos = orbitalRadius * Math.Sin(orbitalDegrees); //Calculate updated x position
            yPos = orbitalRadius * Math.Cos(orbitalDegrees); //Calculate updated y position.
            //x = cos
            //y = sin
        }//END calculatePosition

        public virtual void Draw()
        {
            Console.Write(", Radius:" + objectRadius + "km");
            Console.Write(", Orbit:" + orbitalRadius + "000 km");
            Console.Write(", periode:" + orbitalPeriod + "days");
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
            Console.Write(name);
            base.Draw();
        }//END Draw
    }//END class Star

    public class Planet : SpaceObject
    {
        public Planet(String name, SpaceObject orbits, double orbitalRadius, double orbitalPeriod, double objectRadius) : base(name, orbits, orbitalRadius, orbitalPeriod, objectRadius) { }
        public override void Draw()
        {
            Console.Write("Planet: ");
            Console.Write(name);
            Console.Write(" Orbits:" + orbits.GetName());
            base.Draw();
        }//END Draw
    }//END class Planet

    public class Moon : SpaceObject
    {
        public Moon(String name, SpaceObject orbits, double orbitalRadius, double orbitalPeriod, double objectRadius) : base(name, orbits, orbitalRadius, orbitalPeriod, objectRadius) { }
        public override void Draw()
        {
            Console.Write("Moon: ");
            Console.Write(name);
            Console.Write(" Orbits:" + orbits.GetName());
            base.Draw();
        }//END Draw
    }//END class Moon

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(String name, SpaceObject orbits, double orbitalRadius, double orbitalPeriod, double objectRadius) : base(name, orbits, orbitalRadius, orbitalPeriod, objectRadius) { }
        public override void Draw()
        {
            Console.Write("DwarfPlanet: ");
            Console.Write(name);
            Console.Write(" Orbits:" + orbits.GetName());
            base.Draw();
        }//END Draw
    }//END class DwarfPlanet

}//END Namespace