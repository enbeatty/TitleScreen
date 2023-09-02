using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitleScreen
{
    public enum Direction
    {
        Left,
        MiddleUp,
        MiddleDown,
        Top
    }

    public class Flower
    {
        private Texture2D texture;

        private double animationTimer;

        private short animationFrame = 0;

        /// <summary>
        /// The direction of the flower
        /// </summary>
        public Direction Direction;

        /// <summary>
        /// The position of the flower
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Loads the flower sprite texture
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("flower");
        }

        /// <summary>
        /// Updates the flower sprite to animate in a pattern
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Draws the animated flower sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Update animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //Update animation frame
            if (animationTimer > 0.37)
            {
                switch (Direction)
                {
                    case Direction.Left:
                        Direction = Direction.MiddleUp;
                        animationFrame = 1;
                        break;
                    case Direction.MiddleUp:
                        Direction = Direction.Top;
                        animationFrame = 2;
                        break;
                    case Direction.Top:
                        Direction = Direction.MiddleDown;
                        animationFrame = 1;
                        break;
                    case Direction.MiddleDown:
                        Direction = Direction.Left;
                        animationFrame = 0;
                        break;
                }
                animationTimer -= 0.37;
            }

            //Draw the sprite
            var source = new Rectangle(animationFrame * 128, 0, 128, 126);
            spriteBatch.Draw(texture, Position, source, Color.White, 0f, new Vector2(0, 0), .45f, SpriteEffects.None, 0);
        }
    }
}
