using System;
using System.Drawing;

using Pamella;
public class Joguin : View
{
    Enemy enemy1;

    protected override void OnStart(IGraphics g)
    {
        enemy1 = new Enemy();
        enemy1.X = 200;
        enemy1.Y = 200;

        var builder = new StateBuilder();
        builder
            .SetEnemy(enemy1)
            .AddMovingState(400, 200)
            .AddRotateState(MathF.PI / 2)
            .AddMovingState(400, 200)
            .AddRotateState(MathF.PI)
            .AddMovingState(400, 600)
            .AddRotateState(MathF.PI * 2)
            .AddMovingState(800, 800)
            .AddRotateState(MathF.PI  + 2)
            .Build();

        g.SubscribeKeyDownEvent(key =>
        {
            if (key == Input.Escape)
                App.Close();
        });
        AlwaysInvalidateMode();
    }

    protected override void OnFrame(IGraphics g)
    {
        enemy1.Act();
    }
    protected override void OnRender(IGraphics g)
    {
        g.Clear(Color.DarkGreen);

        g.FillRectangle(
            enemy1.X - 15, enemy1.Y - 15,
            30, 30, Brushes.Blue
        );

        var cos = MathF.Cos(enemy1.Angle);
        var sin = MathF.Sin(enemy1.Angle);

        g.FillPolygon(
            new PointF[] {
                new PointF(enemy1.X, enemy1.Y),
                new PointF(
                    enemy1.X + 250 * cos - 50 * sin,
                    enemy1.Y + 250 * sin + 50 * cos),
                new PointF(
                    enemy1.X + 250 * cos + 50 * sin,
                    enemy1.Y + 250 * sin - 50 * cos),
            }, Brushes.Yellow
        );
    }
}
