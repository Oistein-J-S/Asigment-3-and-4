using System;

namespace SpaceSim
{
    public class SpaceObject
    {

        protected String name; // OK
        protected String orbits;// OK
        protected int objectRadius; //NA
        protected int orbitalRadius; //OK
        protected int orbitalPeriod; //OK
        protected int xPos;
        protected int yPos;

        // public SpaceObject(String name) {
        //     this.name = name;
        // }//END Creator1
        public SpaceObject(String name, String orbits, int objectRadius, int orbitalRadius, int orbitalPeriod)
        {
            this.name = name;
            this.orbits = orbits;
            this.objectRadius = objectRadius;
            this.orbitalRadius = orbitalRadius;
            this.orbitalPeriod = orbitalPeriod;
            xPos = orbitalRadius;
            yPos = 0;
    }//END Creator2

        //Setters
        public void setName(String name)
        {
            this.name = name;
        }
        public void setObjectRadius(int objectRadius)
        {
            this.objectRadius = objectRadius;
        }
        public void setOrbitalRadius(int orbitalRadius)
        {
            this.orbitalRadius = orbitalRadius;
        }
        public void setOrbitalPeriod(int orbitalPeriod)
        {
            this.orbitalPeriod = orbitalPeriod;
        }
        public void setXPos(int xPos)
        {
            this.xPos = xPos;
        }
        public void setYPos(int yPos)
        {
            this.yPos = yPos;
        }
        //Getters
        public String getName()
        {
            return this.name;
        }
        public int getObjectRadius()
        {
            return this.objectRadius;
        }
        public int getOrbitalRadius()
        {
            return this.orbitalRadius;
        }
        public int getOrbitalPeriod()
        {
            return this.orbitalPeriod;
        }
        public int getXPos()
        {
            return xPos;
        }
        public int getYPos()
        {
            return yPos;
        }

        public virtual int calculatePosition(int time)
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
        public Star(String name, String orbits, int objectRadius, int orbitalRadius, int orbitalPeriod) : base(name, name, objectRadius, 0, 0) { }
        public override void Draw()
        {
            Console.Write("Star :");
            base.Draw();
        }//END Draw
    }//END class Star

    public class Planet : SpaceObject
    {
        public Planet(String name, String orbits, int objectRadius, int orbitalRadius, int orbitalPeriod) : base(name, orbits, objectRadius, orbitalRadius, orbitalPeriod) { }
        public override void Draw()
        {
            Console.Write("Planet :");
            base.Draw();
        }//END Draw
    }//END class Planet

    public class Moon : SpaceObject
    {
        public Moon(String name, String orbits, int objectRadius, int orbitalRadius, int orbitalPeriod) : base(name, orbits, objectRadius, orbitalRadius, orbitalPeriod) { }
        public override void Draw()
        {
            Console.Write("Moon :");
            base.Draw();
        }//END Draw
    }//END class Moon

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(String name, String orbits, int objectRadius, int orbitalRadius, int orbitalPeriod) : base(name, orbits, objectRadius, orbitalRadius, orbitalPeriod) { }
        public override void Draw()
        {
            Console.Write("DwarfPlanet :");
            base.Draw();
        }//END Draw
    }//END class DwarfPlanet

}//END Namespace