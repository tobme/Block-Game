using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BlockGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public List<Objects> ObjectList = new List<Objects>();
        public bool GameON = false;
        public int CurrentLvl = 4;
        SpriteFont VictoryText;
        Vector2 FontPos;
        GameState gameState = new GameState();

        string output = "Nu er Peor i Lump!";


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
        /// 

        public enum GameState
        {
            Menu,
            Game,
            Victory,
            Buttons,
            GameRules
        }

        public void Restart()
        {
            ObjectList.Clear();
            GameON = false;

            switch (CurrentLvl)
            {
                case 1:
                    Lvls.Lvl1(this, ObjectList);
                    break;
                case 2:
                    Lvls.Lvl2(this, ObjectList);
                    break;
                case 3:
                    Lvls.Lvl3(this, ObjectList);
                    break;
                case 4:
                    graphics.PreferredBackBufferHeight = 750;
                    graphics.PreferredBackBufferWidth = 650;
                    graphics.ApplyChanges();
                    Lvls.Lvl4(this, ObjectList);
                    break;
                case 5:
                    Lvls.Lvl5(this, ObjectList);
                    break;
                default:
                    gameState = GameState.Victory;
                    break;
            }
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            base.Initialize();

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 500;

            graphics.ApplyChanges();
            Restart();

            gameState = GameState.Menu;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            VictoryText = Content.Load<SpriteFont>("VictoryText");

         
            FontPos = new Vector2(300,300);


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (gameState == GameState.Menu)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameState = GameState.Game;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Back))
                    gameState = GameState.GameRules;
                else if (Mouse.GetState().X >= 368 && Mouse.GetState().X <= 464 && Mouse.GetState().Y >= 505 && Mouse.GetState().Y <= 593 && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    gameState = GameState.Buttons;
                }
            }
            else if (gameState == GameState.Buttons || gameState == GameState.GameRules)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    gameState = GameState.Menu;
                }
            }
            else if (gameState == GameState.Game)
            {
                for (int i = 0; i < ObjectList.Count(); i++)
                {
                    ObjectList[i].Update(ObjectList);
                }
            }

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (gameState == GameState.Menu)
            {
                spriteBatch.Draw(Content.Load<Texture2D>("startscreen"), new Rectangle(0, 0, 500, 600), Color.White);
            }
            else if (gameState == GameState.Game)
            {
                for (int i = 0; i < ObjectList.Count(); i++)
                {
                    ObjectList[i].Draw(spriteBatch);

                }
            }
            else if (gameState == GameState.Buttons)
            {
                spriteBatch.Draw(Content.Load<Texture2D>("buttonscreen"), new Rectangle(0, 0, 500, 600), Color.White);
            }
            else if (gameState == GameState.GameRules)
            {
                spriteBatch.Draw(Content.Load<Texture2D>("rulesscreen"), new Rectangle(0, 0, 500, 600), Color.White);
            }
            else
            {
                Vector2 FontOrigin = VictoryText.MeasureString(output) / 2;

                spriteBatch.DrawString(VictoryText, output, FontPos, Color.Black,
                    0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

                spriteBatch.Draw(Content.Load<Texture2D>("peor end"), new Rectangle(200, 350, 100, 100), Color.White);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
