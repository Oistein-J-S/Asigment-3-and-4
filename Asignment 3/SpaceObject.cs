using System;

namespace SpaceSim
{
    public class SpaceObject
    {

        protected String name; // OK
        protected SpaceObject orbits;// OK
        protected int objectRadius; //NA
        protected int orbitalRadius; //OK
        protected int orbitalPeriod; //OK
        protected int xPos;
        protected int yPos;

        // public SpaceObject(String name) {
        //     this.name = name;
        // }//END Creator1
        public SpaceObject(String name, SpaceObject orbits, int orbitalRadius, int orbitalPeriod, int objectRadius)
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
        public void SetObjectRadius(int objectRadius)
        {
            this.objectRadius = objectRadius;
        }
        public void SetOrbitalRadius(int orbitalRadius)
        {
            this.orbitalRadius = orbitalRadius;
        }
        public void SetOrbitalPeriod(int orbitalPeriod)
        {
            this.orbitalPeriod = orbitalPeriod;
        }
        public void SetXPos(int xPos)
        {
            this.xPos = xPos;
        }
        public void SetYPos(int yPos)
        {
            this.yPos = yPos;
        }
        //Getters
        public String GetName()
        {
            return this.name;
        }
        public int GetObjectRadius()
        {
            return this.objectRadius;
        }
        public int GetOrbitalRadius()
        {
            return this.orbitalRadius;
        }
        public int GetOrbitalPeriod()
        {
            return this.orbitalPeriod;
        }
        public int GetXPos()
        {
            return xPos;
        }
        public int GetYPos()
        {
            return yPos;
        }

        public virtual int CalculatePosition(int time)
        {
            int rest = time % orbitalPeriod; // remove multiple orbits
            double relativeTime = rest / orbitalPeriod; // find % value of completed orbit
            return (int)relativeTime*360; //multiply by 360 to find degrees moved.
        }//END calculatePosition

        public virtual void Draw()
        {
            Console.Write(name);
            Console.Write(", Orbits :" + orbits);
            Console.Write(", Radius :" + objectRadius);
            Console.Write(", Orbit" + orbitalRadius);
            Console.Write(", period" + orbitalPeriod);
            Console.Write(", Position: " + xPos + ", " + yPos );
            Console.WriteLine();
        }//END Draw
    }//END class SpaceObject

    public class Star : SpaceObject
    {
        public Star(String name, int objectRadius) : base(name, null, 0, 0, objectRadius) { }
        public override void Draw()
        {
            Console.Write("Star :");
            base.Draw();
        }//END Draw
    }//END class Star

    public class Planet : SpaceObject
    {
        public Planet(String name, SpaceObject orbits, int orbitalRadius, int orbitalPeriod, int objectRadius) : base(name, orbits, orbitalRadius, orbitalPeriod, objectRadius) { }
        public override void Draw()
        {
            Console.Write("Planet :");
            base.Draw();
        }//END Draw
    }//END class Planet

    public class Moon : SpaceObject
    {
        public Moon(String name, SpaceObject orbits, int orbitalRadius, int orbitalPeriod, int objectRadius) : base(name, orbits, orbitalRadius, orbitalPeriod, objectRadius) { }
        public override void Draw()
        {
            Console.Write("Moon :");
            base.Draw();
        }//END Draw
    }//END class Moon

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(String name, SpaceObject orbits, int orbitalRadius, int orbitalPeriod, int objectRadius) : base(name, orbits, orbitalRadius, orbitalPeriod, objectRadius) { }
        public override void Draw()
        {
            Console.Write("DwarfPlanet :");
            base.Draw();
        }//END Draw
    }//END class DwarfPlanet

}//END Namespace