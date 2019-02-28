using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;


namespace Sprint0
{

    class CommandQuit : ICommand
    {
        private Game1 myGame;

        public CommandQuit(Game1 game)
        {
            this.myGame = game;
        }

        public void Execute()
        {
            this.myGame.Exit();
        }
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ArrayList controllerList;
        public ISprite Mario { get; set; }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            controllerList = new ArrayList();
            GamepadController gamePadState = new GamepadController(PlayerIndex.One);
            KeyboardController keyboardState = new KeyboardController();

            keyboardState.Register(Keys.Q, new CommandQuit(this));
            keyboardState.Register(Keys.W, new CommandStatic(this));
            keyboardState.Register(Keys.E, new CommandAnimated(this));
            keyboardState.Register(Keys.R, new CommandDead(this));
            keyboardState.Register(Keys.T, new CommandRunning(this));

            gamePadState.Register(Buttons.Start, new CommandQuit(this));
            gamePadState.Register(Buttons.A, new CommandStatic(this));
            gamePadState.Register(Buttons.B, new CommandAnimated(this));
            gamePadState.Register(Buttons.X, new CommandDead(this));
            gamePadState.Register(Buttons.Y, new CommandRunning(this));

            controllerList.Add(keyboardState);
            controllerList.Add(gamePadState);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D image = Content.Load<Texture2D>("mario");
            Mario = new StaticMario(image, 1, 10);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            Mario.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Mario.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
