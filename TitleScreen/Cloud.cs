using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TitleScreen
{
    public class Cloud
    {
        private Texture2D texture;

        private double directionTimer;

        /// <summary>
        /// The position of the cloud
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Loads the cloud sprite texture
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("cloud");
        }

        /// <summary>
        /// Updates the cloud sprite to fly in a pattern
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public void Update(GameTime gameTime)
        {
            //Update direction timer
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //If the Cloud leaves screen fully have it appear on other side.
            if (directionTimer > .05)
            {
                if(Position.X < -450)
                {
                    Position.X = 780;
                }
                Position += new Vector2(-1, 0);
                directionTimer -= .05;
            }

        }

        /// <summary>
        /// Draws the animated cloud sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, new Vector2(0, 0), .45f, SpriteEffects.None, 0);

        }
    }
}
