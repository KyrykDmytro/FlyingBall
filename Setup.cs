using System.Drawing;

namespace FlyingBall
{
    public class Setup
    {
        public readonly Color BackgroundColor;
        public readonly Color BallColor;
        public readonly int BallSize;
        public readonly int BallSpeed;

        public Setup(Color backgroundColor, Color ballColor, int ballSize, int ballSpeed)
        {
            BackgroundColor = backgroundColor;
            BallColor = ballColor;
            BallSize = ballSize;
            BallSpeed = ballSpeed;
        }
    }
}
