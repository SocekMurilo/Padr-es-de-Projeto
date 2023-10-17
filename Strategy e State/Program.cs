using System.Drawing;

using Pamella;

App.Open<Joguin>();

public class Enemy
{
    public State State { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
}

public abstract class state
{
    protected Enemy enemy;

} 

public class Joguin : View
{
    protected override void OnStart(IGraphics g)
    {
        enemy1 = new Enemy();
        enemy1.X = 400;
        enemy1.Y = 270;


        g.SubscribeKeyDownEvent(key => 
        {
            if (key == Input.Escape)
                App.Close();
        });
    }
    protected override void OnRender(IGraphics g)
    {
        g.Clear(Color.DarkGreen);

        g.FillRectangle(
            emeny1.X -15, enemy.Y -15,
            30, 30, Brushes.Yellow
        );

        g.fillPolygon(
            new PointF[] {
                new PointF(0,0),
                new PointF(0,0),
                new PointF(0,0)
            }, Brushes.YellowGreen
        );
    }
}