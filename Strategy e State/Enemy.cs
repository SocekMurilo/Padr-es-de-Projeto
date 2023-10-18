using System.Drawing;
using System;

using Pamella;
public class Enemy
{
    public State State { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Angle { get; set; }
    public void Act()
    {
        this.State.Act();
    }

}
