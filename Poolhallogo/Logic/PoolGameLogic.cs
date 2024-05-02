using Poolhall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poolhall.Logic
{
    public class PoolGameLogic
    {
        private List<Ball> balls;
        private object cueBall;
        private int tableWidth;
        private int tableHeight;
        private int cueBallRadius;
        private double pocketRadius;
        private double pocketOffsetX;
        private double pocketOffsetY;
        public PoolGameLogic(int width, int height, int radius) 
        {
            tableWidth = width;
            tableHeight = height;
            cueBallRadius = radius;

            balls = new List<Ball>();
        }
        public void SetPocketDimensions(double radius, double offsetX, double offsetY)
        {
            pocketRadius = radius;
            pocketOffsetX = offsetX;
            pocketOffsetY = offsetY;
        }
        PoolGameLogic gameLogic = new PoolGameLogic(800, 533, (int)(5.715 * 800 / 200));
        gameLogic.SetPocketDimensions(10, 50, 20);
        
        public void Rackballs()
        {
            double cueBallX = tableWidth / 2;
            double cueBallY = tableHeight - cueBallRadius * 2;  
            double firstBallX = tableWidth / 2;
            double firstBallY = tableHeight / 3;
        }

        public IEnumerable<Ball>? GetBalls()
        {
            return balls;
        }

        public void SimulateShot(double power, double direction, IEnumerable<Ball>? balls)
        {
            double angleInRadians = direction * Math.PI / 180;

            double cueBallVX = power * Math.Cos(angleInRadians);
            double cueBallVY = power * Math.Sin(angleInRadians);

            foreach (Ball ball in balls)
            {
                if (IsBallCollision((Ball)cueBall, ball))
                {
                    Ball castedCueBall = (Ball)cueBall;
                    double tempVX = cueBallVX;
                    castedCueBall.X = ball.X - castedCueBall.X;  
                    ball.X += cueBallVX;
                    cueBallVX = tempVX;

                    double tempVY = cueBallVY;
                    castedCueBall.Y = ball.Y - castedCueBall.Y;  
                    ball.Y += cueBallVY;
                    cueBallVY = tempVY;
                }
                ball.X += ball.dX;
                ball.Y += ball.dY;
                if (IsBallInPocket(ball))
                {
                    balls.Remove(ball);
                }
            }
            cueBallVX *= 0.9;  
            cueBallVY *= 0.9;
        }

        private bool IsBallCollision(Ball ball1, Ball ball2)
        {
            double distance = Math.Sqrt(Math.Pow(ball1.X - ball2.X, 2) + Math.Pow(ball1.Y - ball2.Y, 2));
            return distance < ball1.Radius + ball2.Radius;
        }

        private bool IsBallInPocket(Ball ball)
        {
            List<Circle> pockets = new List<Circle>()
  {
    new Circle(pocketRadius, pocketOffsetX, pocketOffsetY),
    new Circle(pocketRadius, tableWidth - pocketOffsetX, pocketOffsetY),
  };
            foreach (Circle pocket in pockets)
            {
                double distanceFromCenter = Math.Sqrt(Math.Pow(ball.X - pocket.X, 2) + Math.Pow(ball.Y - pocket.Y, 2));
                if (distanceFromCenter < ball.Radius + pocket.Radius)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
