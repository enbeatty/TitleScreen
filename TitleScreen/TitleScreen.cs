using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TitleScreen
{
    public class TitleScreen : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _tree;
        private Flower[] _flower;
        private Texture2D _rock;
        private Cloud _cloud;
        private Texture2D _background;
        private SpriteFont _pixelUltima;

        public TitleScreen()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _background = Content.Load<Texture2D>("background");
            _flower = new Flower[]
            {
                new Flower() {Position = new Vector2(50, 300), Direction= Direction.Left},
                new Flower() {Position = new Vector2(230, 390), Direction= Direction.Left},
                new Flower() {Position = new Vector2(130, 400), Direction= Direction.Left},
                new Flower() {Position = new Vector2(185, 370), Direction= Direction.Left}
            };
            _rock = Content.Load<Texture2D>("rock");
            _tree = Content.Load<Texture2D>("tree");
            _cloud = new Cloud() { Position = new Vector2(750, 10) };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (var flower in _flower) flower.LoadContent(Content);
            _cloud.LoadContent(Content);
            _pixelUltima = Content.Load<SpriteFont>("pixel_ultima");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var flower in _flower) flower.Update(gameTime);
            _cloud.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, new Vector2(0, -50), null, Color.White, 0f, new Vector2(0, 0), .45f, SpriteEffects.None, 0);
            _spriteBatch.Draw(_rock, new Vector2(25, 370), null, Color.White, 0f, new Vector2(0, 0), .25f, SpriteEffects.None, 0);
            foreach (var flower in _flower)
            {
                flower.Draw(gameTime, _spriteBatch);
            }
            _cloud.Draw(gameTime, _spriteBatch);
            _spriteBatch.Draw(_tree, new Vector2(400, 0), null, Color.White, 0f, new Vector2(0, 0), .33f, SpriteEffects.None, 0);
            _spriteBatch.Draw(_rock, new Vector2(570, 370), null, Color.White, 0f, new Vector2(0, 0), .33f, SpriteEffects.None, 0);
            _spriteBatch.DrawString(_pixelUltima, "Welcome", new Vector2(315, 100), Color.Black);
            _spriteBatch.DrawString(_pixelUltima, "Press ESC to exit", new Vector2(250, 150), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}