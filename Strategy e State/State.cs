using System;

public abstract class State
{
    public Enemy enemy;
    public State NextState { get; set; }
    public abstract void Act();
}

public class MovingState : State
{
    public float XTarget { get; set; }
    public float YTarget { get; set; }
    public override void Act()
    {
        var dTheta = XTarget - enemy.X;
        var dy = YTarget - enemy.Y;

        var mod = MathF.Sqrt(dTheta * dTheta + dy * dy);
        if (mod < 5)
        {
            this.enemy.State = NextState;
            return;
        }

        enemy.X += 100 * dTheta / mod / 30;
        enemy.Y += 100 * dy / mod / 30;
    }
}

public class RotateState : State
{
    public float AngleTarget { get; set; }
    public override void Act()
    {
        var dTheta = AngleTarget - enemy.Angle;

        if (dTheta < 0.05)
        {
            this.enemy.State = NextState;
            return;
        }

        enemy.Angle += 0.1f * MathF.Sign(dTheta);
    }
}
