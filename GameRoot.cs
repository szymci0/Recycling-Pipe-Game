using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;

namespace RecyclingPipe
{
    public class GameRoot : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public const int _scWidth = 1280;
        public const int _scHeight = 720;

        Texture2D menu;
        Texture2D howto;
        Texture2D background;
        Texture2D pipe;
        Texture2D ekranPauzy;
        Texture2D ekranKoniec;

        Texture2D pauzaBtn;
        Texture2D zyciaT;

        SpriteFont gameFont;

        protected Song song;
        private SoundEffect plus;
        private SoundEffect minus;

        Texture2D bio1;
        Texture2D bio2;
        Texture2D bio3;

        Texture2D maku1;
        Texture2D maku2;
        Texture2D maku3;

        Texture2D plastik1;
        Texture2D plastik2;
        Texture2D plastik3;

        Texture2D szklo1;
        Texture2D szklo2;
        Texture2D szklo3;

        Texture2D poj_bio;
        Texture2D poj_plastik;
        Texture2D poj_maku;
        Texture2D poj_szklo;

        Texture2D przedmiot;

        MouseState mouseState;

        bool czyLosowacSmiec;
        string wynik;
        int gameState;

        int wybor;
        int wyborT;

        int zycia;
        int score;
        int przech;
        int x = 0;


        int mouseX = 0;
        int mouseY = 0;

        
        int trashY = 0;
        private int speed = 4;

        public GameRoot()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()                            
        //inicjalizacja stanu początkowego gry
        {
            _graphics.PreferredBackBufferWidth = _scWidth;
            _graphics.PreferredBackBufferHeight = _scHeight;
            _graphics.ApplyChanges();
            czyLosowacSmiec = true;
            gameState = 0;
            score = 0;
            przech = 15;
            zycia = 5;
            MediaPlayer.IsRepeating = true;
            base.Initialize();
        }

        protected override void LoadContent()                           
        // ładowanie wszelkich zawartości gry
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            menu = Content.Load<Texture2D>("menu2");
            background = Content.Load<Texture2D>("2");
            pipe = Content.Load<Texture2D>("pipe");
            howto = Content.Load<Texture2D>("howto");
            ekranPauzy = Content.Load<Texture2D>("ekranPauza2");
            ekranKoniec = Content.Load<Texture2D>("przegrana");

            zyciaT = Content.Load<Texture2D>("lifes");
            pauzaBtn = Content.Load<Texture2D>("pauza");

            gameFont = Content.Load<SpriteFont>("galleryFont");

            song = Content.Load<Song>("modern-beauty-downtempo-11252");
            plus = Content.Load<SoundEffect>("plusjeden");
            minus = Content.Load<SoundEffect>("minus1");

            poj_bio = Content.Load<Texture2D>("poj_bio");
            poj_plastik = Content.Load<Texture2D>("poj_plastik");
            poj_maku = Content.Load<Texture2D>("poj_maku");
            poj_szklo = Content.Load<Texture2D>("poj_szklo");

            bio1 = Content.Load<Texture2D>("bio1");
            bio2 = Content.Load<Texture2D>("bio2");
            bio3 = Content.Load<Texture2D>("bio3");

            plastik1 = Content.Load<Texture2D>("plastik1");
            plastik2 = Content.Load<Texture2D>("plastik2");
            plastik3 = Content.Load<Texture2D>("plastik3");

            maku1 = Content.Load<Texture2D>("maku1");
            maku2 = Content.Load<Texture2D>("maku2");
            maku3 = Content.Load<Texture2D>("maku3");

            szklo1 = Content.Load<Texture2D>("szklo1");
            szklo2 = Content.Load<Texture2D>("szklo2");
            szklo3 = Content.Load<Texture2D>("szklo3");

            MediaPlayer.Play(song);

        }


        protected override void Update(GameTime gameTime)       
        // aktualizowanie stanu gry co każdą klatkę 
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                Exit();

            mouseState = Mouse.GetState();
            // obiekt do przechowywania stanu myszy
            mouseX = mouseState.X;
            mouseY = mouseState.Y;

            if(gameState == 1 || gameState == 2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    gameState = -2;
                }
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (mouseX > 1180 && mouseX < 1280 && mouseY > 0 && mouseY < 100)   
                    {
                        gameState = -2;
                    }
                }
                // pauza klawiszem ESC lub myszką
            }

            switch (gameState)                                                                          
                /* gamestate =
                     0 - menu główne
                     1 - pierwszy poziom
                     2 - drugi poziom
                    -1 - samouczek
                    -2 - pauza
                    -3 - koniec żyć
                */
            {                                                                                           
                case 0:                                                                                 
                    przedmiot = plastik1;                                                               
                    if (mouseState.LeftButton == ButtonState.Pressed)                                   
                    {                                                                                   
                        if (mouseX > 265 && mouseX < 451 && mouseY > 248 && mouseY < 324)               
                        {
                            gameState = 1;
                        }
                        if (mouseX > 265 && mouseX < 746 && mouseY > 360 && mouseY < 436)
                        {
                            gameState = -1;
                        }
                        if (mouseX > 265 && mouseX < 505 && mouseY > 473 && mouseY < 549)
                        {
                            Exit();
                        }
                    }

                    break;
               
                case -1:
                    if(mouseState.LeftButton == ButtonState.Pressed )
                    {
                        if(mouseX > 541 && mouseX < 738 && mouseY > 593 && mouseY < 702)
                        {
                            gameState = 0;
                        }
                    }
                    break;

                case -2:
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        if (mouseX > 442 && mouseX < 792 && mouseY > 255 && mouseY < 360)
                        {
                            if (score < 15)
                            {
                                gameState = 1;
                            }

                            if(score > 15)
                            {
                                gameState = 2;
                            }                      
                        }
                        if (mouseX > 442 && mouseX < 792 && mouseY > 384 && mouseY < 489)
                        {
                            score = 0;
                            speed = 4;
                            przech = 15;
                            gameState = 1;
                            trashY = 0;
                            zycia = 5;
                        }
                            if (mouseX > 442 && mouseX < 792 && mouseY > 513 && mouseY < 618)
                        {
                            zycia = 5;
                            gameState = 0;
                        }
                    }
                    break;

                case -3:
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        if (mouseX > 442 && mouseX < 792 && mouseY > 384 && mouseY < 489)
                        {
                            score = 0;
                            speed = 4;
                            przech = 15;
                            gameState = 1;
                            trashY = 0;
                            zycia = 5;
                        }
                        if (mouseX > 442 && mouseX < 792 && mouseY > 513 && mouseY < 618)
                        {
                            zycia = 5;
                            trashY = 0;
                            score = 0;
                            speed = 4;
                            przech = 15;
                            gameState = 0;
                        }
                    }
                    break;

                case 1:
                    if (czyLosowacSmiec)
                    {
                        Random wyborSmiecia = new Random();
                        wybor = wyborSmiecia.Next(1, 4);            
                        // losowanie rodzaju odpadu
                        Random wyborTextury = new Random();
                        wyborT = wyborTextury.Next(1, 4);           
                        // losowanie tekstury dla danego rodzaju odpadu

                        switch (wybor)
                        {
                            case 1:
                                switch (wyborT)
                                {
                                    case 1:
                                        przedmiot = plastik1;
                                        break;
                                    case 2:
                                        przedmiot = plastik2;
                                        break;
                                    case 3:
                                        przedmiot = plastik3;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 2:
                                switch (wyborT)
                                {
                                    case 1:
                                        przedmiot = maku1;
                                        break;
                                    case 2:
                                        przedmiot = maku2;
                                        break;
                                    case 3:
                                        przedmiot = maku3;
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            case 3:
                                switch (wyborT)
                                {
                                    case 1:
                                        przedmiot = bio1;
                                        break;
                                    case 2:
                                        przedmiot = bio2;
                                        break;
                                    case 3:
                                        przedmiot = bio3;
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        czyLosowacSmiec = false;
                    }

                    x = mouseState.X;
                    trashY = trashY + speed;


                    if (trashY > 480)
                    // sprawdzenie czy odpad trafił do jakiegokolwiek pojemnika
                    {
                        zycia--;
                        minus.Play();

                        trashY = 0;
                        czyLosowacSmiec = true;
                    }
                    else
                    // sprawdzenie czy odpad trafil do dobrego pojemnika
                    {

                        if (wybor == 1 && trashY >= 460 && ((x > 128) && (x < 298)))
                        {
                            trashY = 0;
                            score++;

                            plus.Play();

                            czyLosowacSmiec = true;
                        }
                        if (wybor == 2 && trashY >= 460 && ((x > 554) && (x < 724)))
                        {
                            trashY = 0;
                            plus.Play();
                            score++;
                            czyLosowacSmiec = true;
                        }
                        if (wybor == 3 && trashY >= 460 && ((x > 982) && (x < 1152)))
                        {
                            trashY = 0;
                            plus.Play();
                            score++;
                            czyLosowacSmiec = true;
                        }

                    }
                    if (score > 15)
                    // warunek przejscia do kolejnego poziomu
                        gameState = 2;
                    break;

                case 2:
                    if (czyLosowacSmiec)
                    {
                        Random wyborSmiecia = new Random();
                        wybor = wyborSmiecia.Next(1, 5);
                        Random wyborTextury = new Random();
                        wyborT = wyborTextury.Next(1, 4);

                        switch (wybor)
                        {
                            case 1:
                                switch (wyborT)
                                {
                                    case 1:
                                        przedmiot = plastik1;
                                        break;
                                    case 2:
                                        przedmiot = plastik2;
                                        break;
                                    case 3:
                                        przedmiot = plastik3;
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 2:
                                switch (wyborT)
                                {
                                    case 1:
                                        przedmiot = maku1;
                                        break;
                                    case 2:
                                        przedmiot = maku2;
                                        break;
                                    case 3:
                                        przedmiot = maku3;
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 3:
                                switch (wyborT)
                                {
                                    case 1:
                                        przedmiot = bio1;
                                        break;
                                    case 2:
                                        przedmiot = bio2;
                                        break;
                                    case 3:
                                        przedmiot = bio3;
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 4:
                                switch (wyborT)
                                {
                                    case 1:
                                        przedmiot = szklo1;
                                        break;
                                    case 2:
                                        przedmiot = szklo2;
                                        break;
                                    case 3:
                                        przedmiot = szklo3;
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            default:
                                break;
                        }
                        czyLosowacSmiec = false;
                    }

                    x = mouseState.X;
                    trashY = trashY + speed;


                    if (trashY > 480)
                    {
                        zycia--;

                        minus.Play();

                        trashY = 0;
                        czyLosowacSmiec = true;
                    }
                    else
                    {

                        if (wybor == 1 && trashY >= 460 && ((x > 75) && (x < 245)))
                        {
                            trashY = 0;
                            plus.Play();
                            score++;
                            czyLosowacSmiec = true;
                        }
                        if (wybor == 2 && trashY >= 460 && ((x > 395) && (x < 565)))
                        {
                            trashY = 0;
                            plus.Play();
                            score++;
                            czyLosowacSmiec = true;
                        }
                        if (wybor == 3 && trashY >= 460 && ((x > 715) && (x < 885)))
                        {
                            trashY = 0;
                            plus.Play();
                            score++;
                            czyLosowacSmiec = true;
                        }
                        if (wybor == 4 && trashY >= 460 && ((x > 1035) && (x < 1205)))
                        {
                            trashY = 0;
                            plus.Play();
                            score++;
                            czyLosowacSmiec = true;
                        }                

                    }
                    break;

                default:
                    break;
            }
             
                if (score > przech + 15)                       
                // co 15 punktow zwieksza sie predkosc opadania odpadu
                {
                    przech = score;
                    speed += 1;
                }

            wynik = "WYNIK: " + score.ToString();
           
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        // rysowanie wszystkiego na ekranie
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            switch (gameState) 
            {
                case -3:
                    _spriteBatch.Begin();
                        _spriteBatch.Draw(ekranKoniec, new Vector2(0, 0), Color.White);
                    _spriteBatch.End();
                    break;
                case -2:
                    _spriteBatch.Begin();
                        _spriteBatch.Draw(ekranPauzy, new Vector2(0, 0), Color.White);
                    _spriteBatch.End();
                    break;

                case -1:
                    _spriteBatch.Begin();
                        _spriteBatch.Draw(howto, new Vector2(0, 0), Color.White);
                    _spriteBatch.End();
                    break;

                case 0:
                    _spriteBatch.Begin();
                        _spriteBatch.Draw(menu, new Vector2(0, 0), Color.White);
                    _spriteBatch.End();
                    break;

                case 1:
                    _spriteBatch.Begin();
                        _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                        _spriteBatch.Draw(przedmiot, new Vector2(x - 45, trashY), Color.White);
                        _spriteBatch.Draw(pipe, new Vector2(x - 100, 200 - 1299), Color.Red);

                        _spriteBatch.Draw(poj_plastik, new Vector2(128, 465), Color.White);
                        _spriteBatch.Draw(poj_maku, new Vector2(554, 465), Color.White);
                        _spriteBatch.Draw(poj_bio, new Vector2(980, 465), Color.White);

                        _spriteBatch.DrawString(gameFont, wynik, new Vector2(5, 5), Color.Black);
                        _spriteBatch.Draw(pauzaBtn, new Vector2(1180, 0), Color.White);
                    _spriteBatch.End();
                    break;

                case 2:
                    _spriteBatch.Begin();
                        _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                        _spriteBatch.Draw(przedmiot, new Vector2(x - 45, trashY), Color.White);
                        _spriteBatch.Draw(pipe, new Vector2(x - 100, 200 - 1299), Color.Red);

                        _spriteBatch.Draw(poj_plastik, new Vector2(75, 465), Color.White);
                        _spriteBatch.Draw(poj_maku, new Vector2(395, 465), Color.White);
                        _spriteBatch.Draw(poj_bio, new Vector2(715, 465), Color.White);
                        _spriteBatch.Draw(poj_szklo, new Vector2(1035, 465), Color.White);

                        _spriteBatch.DrawString(gameFont, wynik, new Vector2(5, 5), Color.Black);
                        _spriteBatch.Draw(pauzaBtn, new Vector2(1180, 0), Color.White);
                    _spriteBatch.End();
                    break;

                default:
                    break;
            }
            if (gameState == 1 || gameState == 2)
            {
                switch (zycia)
                {
                    case 5:
                        _spriteBatch.Begin();
                            _spriteBatch.Draw(zyciaT, new Vector2(5, 40),Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(25, 40), Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(45, 40), Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(65, 40), Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(85, 40), Color.White);
                        _spriteBatch.End();
                        break;
                    case 4:
                        _spriteBatch.Begin();
                            _spriteBatch.Draw(zyciaT, new Vector2(5, 40), Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(25, 40), Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(45, 40), Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(66, 40), Color.White);
                        _spriteBatch.End();
                        break;
                    case 3:
                        _spriteBatch.Begin();
                            _spriteBatch.Draw(zyciaT, new Vector2(5, 40), Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(25, 40), Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(45, 40), Color.White);
                        _spriteBatch.End();
                        break;
                    case 2:
                        _spriteBatch.Begin();
                            _spriteBatch.Draw(zyciaT, new Vector2(5, 40), Color.White);
                            _spriteBatch.Draw(zyciaT, new Vector2(25, 40), Color.White);
                        _spriteBatch.End();
                        break;
                    case 1:
                        _spriteBatch.Begin();
                            _spriteBatch.Draw(zyciaT, new Vector2(5, 40), Color.White);
                        _spriteBatch.End();
                        break;
                    case 0:
                        gameState = -3;
                        break;
                    default:
                        Exit();
                        break;
                }
            }

            base.Draw(gameTime);

        }

    }    

}
