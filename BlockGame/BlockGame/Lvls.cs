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
    public static class Lvls
    {

        public static void Lvl1(Game1 game, List<Objects> Blockers)
        {
            int[,] field = {{1,1,0,1,1,1,1,1,1,1},
                          {0,0,0,0,1,1,1,0,0,0},
                          {0,0,0,0,1,1,1,0,0,0},
                          {0,0,0,0,0,0,1,0,0,0},
                          {0,0,0,0,1,0,0,0,0,0},
                          {0,0,0,0,1,1,1,0,0,0},
                          {1,1,1,1,1,1,1,0,0,0},
                          {0,0,0,0,1,1,1,0,0,0},
                          {0,0,0,0,1,1,1,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0}};
            MakeGround(game, Blockers, field);
            for (int i = 0; i < 5; i++)
            {
                Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(50 * i, 500, 50, 50), game, 1, false, true));
            }
            Blockers.Add(new Goal(game.Content.Load<Texture2D>("dabuss"), new Rectangle(100, 0, 100, 50), game));
            MakePlayers(game, Blockers);
        }
        public static void Lvl2(Game1 game, List<Objects> Blockers)
        {
            int[,] field ={{1,1,0,0,0,0,0,0,0,1},
                           {0,1,1,1,1,1,1,1,0,1},
                           {0,1,1,1,1,1,0,1,0,0},
                           {0,0,0,0,0,1,0,1,0,0},
                           {0,0,0,0,0,0,0,0,0,0},
                           {0,0,0,1,1,1,0,1,0,0},
                           {0,0,1,1,1,1,0,1,0,1},
                           {0,0,0,0,0,1,0,0,1,1},
                           {0,0,0,0,0,1,0,0,1,1},
                           {0,0,0,0,1,1,0,0,0,0}};
            MakeGround(game, Blockers, field);

            MakeLevers(game, Blockers);

            Blockers.Add(new Reverse(game.Content.Load<Texture2D>("TurnAround"), new Rectangle(0, 500, 50, 50), game, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(50, 500, 50, 50), game, 1, false, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(150, 500, 50, 50), game, 1, false, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(200, 500, 50, 50), game, 1, false, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(250, 500, 50, 50), game, 1, false, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(300, 500, 50, 50), game, 1, false, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(100, 500, 50, 50), game, true, true));


            Blockers.Add(new Goal(game.Content.Load<Texture2D>("tog"), new Rectangle(100, 0, 100, 50), game));
            MakePlayers(game, Blockers);



        }
        public static void Lvl3(Game1 game, List<Objects> Blockers)
        {
            int[,] field ={{0,0,0,1,0,1,1,1,1,1},
                          {1,1,0,0,0,1,1,1,0,0},
                          {1,1,0,0,0,1,0,1,0,0},
                          {0,1,1,1,0,0,0,1,0,0},
                          {0,0,1,1,2,0,1,1,0,0},
                          {0,0,1,1,0,0,1,1,0,0},
                          {0,1,1,1,0,0,0,0,0,0},
                          {0,1,1,1,0,0,1,1,0,0},
                          {0,0,0,1,0,0,0,0,0,0},
                          {0,0,0,0,0,0,1,1,0,0}};
            MakeGround(game, Blockers, field);
            MakeLevers(game, Blockers);


            Blockers.Add(new Reverse(game.Content.Load<Texture2D>("TurnAround"), new Rectangle(350, 500, 50, 50), game, true));
            Blockers.Add(new Reverse(game.Content.Load<Texture2D>("TurnAround"), new Rectangle(500, 500, 50, 50), game, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(400, 500, 50, 50), game, true, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(450, 500, 50, 50), game, true, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("multiarrow"), new Rectangle(0, 550, 50, 50), game, 1, true, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(200, 450, 50, 50), game, 1, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(200, 350, 50, 50), game, 2, false, false));


            List<int> ArrowSpak1Dir = new List<int>();
            List<int> ArrowSpak1CurrentDir = new List<int>();
            ArrowSpak1CurrentDir.Add(4);
            ArrowSpak1Dir.Add(3);
            List<Objects> ArrowSpak1 = new List<Objects>();
            ArrowSpak1.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(100, 0, 50, 50), game, 4, false, false));
            Blockers.Add(new Spak2(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), new Rectangle(400, 300, 50, 50), game, ArrowSpak1, ArrowSpak1Dir, ArrowSpak1CurrentDir));
            Blockers.AddRange(ArrowSpak1);

            for (int i = 0; i < 7; i++)
            {
                Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(50 * i, 500, 50, 50), game, 1, false, true)); 
            }
            Blockers.Add(new Goal(game.Content.Load<Texture2D>("tog2"), new Rectangle(0, 150, 50, 100), game));
            MakePlayers(game, Blockers);
        }
        public static void Lvl4(Game1 game, List<Objects> Blockers)
        {
            int[,] field ={{1,1,0,0,2,0,1,1,1,1,0,1,0},
                           {1,1,0,0,0,1,1,0,0,1,0,1,0},
                           {2,1,0,0,0,1,0,0,0,0,0,0,0},
                           {0,1,1,1,0,1,0,0,0,0,0,0,2},
                           {0,0,1,1,0,1,1,1,0,0,0,0,2},
                           {0,0,1,1,0,0,0,0,0,0,0,0,2},
                           {0,1,1,1,2,0,1,1,0,0,0,0,0},
                           {0,1,1,1,0,0,1,1,0,0,0,0,0},
                           {2,0,0,1,0,0,0,0,1,1,1,1,1},
                           {1,1,0,0,0,0,1,1,1,1,1,1,1},
                           {0,0,0,0,0,0,0,0,0,0,0,0,0},
                           {0,0,0,0,0,0,0,2,0,1,0,0,0},
                           {0,0,0,0,0,0,0,0,0,1,0,0,0}};

            MakeGround(game, Blockers, field);
            MakeLevers(game, Blockers);



            List<int> ArrowSpak1Dir = new List<int>();
            ArrowSpak1Dir.Add(4);
            List<Objects> ArrowSpak1 = new List<Objects>();
            List<int> ArrowSpak1Dir1 = new List<int>();
            ArrowSpak1Dir1.Add(2);
            ArrowSpak1.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(400, 100, 50, 50), game, 2, false, false));
            Blockers.Add(new Spak2(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), new Rectangle(50, 600, 50, 50), game, ArrowSpak1, ArrowSpak1Dir, ArrowSpak1Dir1));
            Blockers.AddRange(ArrowSpak1);

            List<int> ArrowSpak1Dir2 = new List<int>();
            ArrowSpak1Dir2.Add(4);
            List<Objects> ArrowSpak2 = new List<Objects>();
            List<int> ArrowSpakCurrentDir2 = new List<int>();
            ArrowSpakCurrentDir2.Add(1);
            ArrowSpak2.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(200, 600, 50, 50), game, 1, false, false));
            Blockers.Add(new Spak2(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), new Rectangle(300, 550, 50, 50), game, ArrowSpak2, ArrowSpak1Dir2, ArrowSpakCurrentDir2));
            Blockers.AddRange(ArrowSpak2);

            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(600, 300, 50, 50), game, 4, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(500, 300, 50, 50), game, 1, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(0, 600, 50, 50), game, 1, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(400, 550, 50, 50), game, 3, false, false));

            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(500, 250, 50, 50), game, 4, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(400, 300, 50, 50), game, 1, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(200, 250, 50, 50), game, 3, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(250, 250, 50, 50), game, 3, false, false));

            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(300, 650, 50, 50), game, true, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(350, 650, 50, 50), game, true, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(400, 650, 50, 50), game, true, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(450, 650, 50, 50), game, true, true));

            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("multiarrow"), new Rectangle(250, 650, 50, 50), game, 1, true, true));

            for (int i = 0; i < 4; i++)
            {
                Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(50 * i, 650, 50, 50), game, 1, false, true));
            }

            Blockers.Add(new Goal(game.Content.Load<Texture2D>("dabuss"), new Rectangle(100, 0, 100, 50), game));
            MakePlayers(game, Blockers);
        }
        public static void Lvl5(Game1 game, List<Objects> Blockers)
        {
            int[,] field ={{1,1,0,0,0,0,1,1,1,1,0,1,0},
                           {1,1,0,0,1,1,1,1,0,1,0,1,0},
                           {2,1,0,0,1,2,1,0,0,0,0,2,0},
                           {0,1,0,0,1,0,0,0,0,0,0,0,2},
                           {0,1,0,0,1,1,1,0,0,0,0,0,0},
                           {0,0,1,0,1,0,0,0,0,0,0,0,2},
                           {0,0,1,0,1,0,0,0,0,0,0,0,2},
                           {0,1,1,1,1,0,0,0,0,0,0,0,2},
                           {1,0,1,0,0,0,0,0,1,1,1,0,1},
                           {2,1,1,1,1,1,1,1,1,1,1,0,1},
                           {0,0,0,0,0,0,2,0,2,0,0,0,0},
                           {2,2,2,0,0,0,2,2,0,1,1,0,0},
                           {2,2,2,0,0,0,2,0,0,1,1,0,0}};
            MakeGround(game, Blockers, field);


            MakeLevers(game, Blockers);

            List<int> ArrowSpak1Dir = new List<int>();
            ArrowSpak1Dir.Add(3);
            List<Objects> ArrowSpak1 = new List<Objects>();
            List<int> ArrowSpak1Dir1 = new List<int>();
            ArrowSpak1Dir1.Add(2);
            ArrowSpak1.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(350, 500, 50, 50), game, 2, false, false));
            Blockers.Add(new Spak2(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), new Rectangle(550, 250, 50, 50), game, ArrowSpak1, ArrowSpak1Dir, ArrowSpak1Dir1));
            Blockers.AddRange(ArrowSpak1);

            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(50, 300, 50, 50), game, 4, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(200, 500, 50, 50), game, 4, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(450, 300, 50, 50), game, 1, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(550, 150, 50, 50), game, 4, false, false));
            Blockers.Add(new BrownBlock(game.Content.Load<Texture2D>("nubbe"), new Rectangle(150, 250, 50, 50), game, false, 0, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("nonstudsis"), new Rectangle(150, 300, 50, 50), game, true, false));

            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(100, 200, 50, 50), game, 1, false, false));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("nonepil"), new Rectangle(150, 200, 50, 50), game, 4, false, false));

            for (int i = 0; i < 6; i++)
            {
                Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(50 * i, 650, 50, 50), game, 1, false, true));
            }
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(150, 700, 50, 50), game, 1, false, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(200, 700, 50, 50), game, 1, false, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("pil"), new Rectangle(250, 700, 50, 50), game, 1, false, true));
            Blockers.Add(new Reverse(game.Content.Load<Texture2D>("TurnAround"), new Rectangle(350, 650, 50, 50), game, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(400, 650, 50, 50), game, true, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(450, 650, 50, 50), game, true, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(450, 700, 50, 50), game, true, true));
            Blockers.Add(new Studds(game.Content.Load<Texture2D>("studsis"), new Rectangle(500, 700, 50, 50), game, true, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("multiarrow"), new Rectangle(0, 700, 50, 50), game, 1, true, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("multiarrow"), new Rectangle(50, 700, 50, 50), game, 1, true, true));
            Blockers.Add(new Arrow(game.Content.Load<Texture2D>("multiarrow"), new Rectangle(100, 700, 50, 50), game, 1, true, true));

            Blockers.Add(new Goal(game.Content.Load<Texture2D>("lumphus"), new Rectangle(100, 150, 100, 50), game));
            MakePlayers(game, Blockers);
        }
        private static void MakeGround(Game1 game, List<Objects> Blockers, int[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 0)
                        Blockers.Add(new BrownBlock(game.Content.Load<Texture2D>("FloorPic"), new Rectangle(50 * j, 50 * i, 50, 50), game, true, 0, true));
                    else if (field[i, j] == 1)
                        Blockers.Add(new BrownBlock(game.Content.Load<Texture2D>("Gräs"), new Rectangle(50 * j, 50 * i, 50, 50), game, false, 0, true));
                    else
                        Blockers.Add(new BrownBlock(game.Content.Load<Texture2D>("noputable"), new Rectangle(50 * j, 50 * i, 50, 50), game, true, 0, false));
                }
            }
            Blockers.Add(new StartButton(game.Content.Load<Texture2D>("GoButton"), new Rectangle(450, 0, 50, 50), game, false));
            Blockers.Add(new RestartButton(game.Content.Load<Texture2D>("RestartButtonen"), new Rectangle(450, 50, 50, 50), game, false));
        }
        public static void MakeLevers(Game1 game, List<Objects> Blockers)
        {
            for (int i = 0; i < Blockers.Count; i++)
            {
                if (Blockers[i] is Spak)
                {
                    ((Spak)Blockers[i]).Changers.Clear();
                    Blockers.Remove(Blockers[i]);
                    i--;
                }
                else if (Blockers[i] is BrownBlock)
                {
                    if (((BrownBlock)Blockers[i]).ChangeAble != 0)
                    {
                        Blockers.Remove(Blockers[i]);
                        i--;
                    }
                }    
            }
            int InsertHere = 0;
            
            for (int i = 0; i < Blockers.Count; i++)
            {
                if (!(Blockers[i] is BrownBlock))
                {
                    InsertHere = i;
                    break;
                }
            }
            
            switch (game.CurrentLvl)
            {

                case 2:
                    List<Objects> Changers = new List<Objects>();
                    Changers.Add(new BrownBlock(game.Content.Load<Texture2D>("Gräs"), new Rectangle(200, 0, 50, 50), game, false, 1, true));
                    Changers.Add(new BrownBlock(game.Content.Load<Texture2D>("Gräs"), new Rectangle(250, 0, 50, 50), game, false, 1, true));
                    Changers.Add(new BrownBlock(game.Content.Load<Texture2D>("Gräs"), new Rectangle(250, 200, 50, 50), game, false, 1, true));
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(300, 200, 50, 50), game, Changers));
                    Blockers.InsertRange(InsertHere, Changers);

                    List<Objects> Changers2 = new List<Objects>();
                    Changers2.Add(new BrownBlock(game.Content.Load<Texture2D>("Gräs"), new Rectangle(200, 200, 50, 50), game, false, 1, true));
                    Changers2.Add(new BrownBlock(game.Content.Load<Texture2D>("Gräs"), new Rectangle(300, 0, 50, 50), game, false, 1, true));
                    Changers2.Add(new BrownBlock(game.Content.Load<Texture2D>("Gräs"), new Rectangle(0, 300, 50, 50), game, false, 1, true));
                    Changers2.Add(new BrownBlock(game.Content.Load<Texture2D>("Gräs"), new Rectangle(50, 300, 50, 50), game, false, 1, true));
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(150, 200, 50, 50), game, Changers2));
                    Blockers.InsertRange(InsertHere, Changers2);
                    break;
                case 3:
                    List<Objects> Spak1 = new List<Objects>();
                    Spak1.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(300, 300, 50, 50), game, false, 1, true));
                    Spak1.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(300, 400, 50, 50), game, false, 1, true));
                    Spak1.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(350, 300, 50, 50), game, false, 1, true));
                    Spak1.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(350, 400, 50, 50), game, false, 1, true));
                    Spak1.Add(new BrownBlock(game.Content.Load<Texture2D>("FloorPic"), new Rectangle(0, 350, 50, 50), game, false, 2, true));
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(200, 150, 50, 50), game, Spak1));
                    Blockers.InsertRange(InsertHere, Spak1);

                    List<Objects> Spak2 = new List<Objects>();
                    Spak2.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(0, 300, 50, 50), game, false, 1, true));
                    Spak2.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(0, 250, 50, 50), game, false, 1, true));
                    Spak2.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(300, 100, 50, 50), game, false, 1, true));
                    Spak2.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(300, 150, 50, 50), game, false, 1, true));
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(400, 400, 50, 50), game, Spak2));
                    Blockers.InsertRange(InsertHere, Spak2);
                    break;
                case 4:
            
                    List<Objects> Spak11 = new List<Objects>();
                    Spak11.Add(new BrownBlock(game.Content.Load<Texture2D>("FloorPic"), new Rectangle(350, 50, 50, 50), game, true, 2, true));
                    Spak11.Add(new BrownBlock(game.Content.Load<Texture2D>("FloorPic"), new Rectangle(350, 100, 50, 50), game, true, 2, true));
                    Spak11.Add(new BrownBlock(game.Content.Load<Texture2D>("FloorPic"), new Rectangle(350, 150, 50, 50), game, true, 2, true)); ;
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(0, 150, 50, 50), game, Spak11));
                    Blockers.InsertRange(InsertHere, Spak11);

                    List<Objects> Spak22 = new List<Objects>();
                    Spak22.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(300, 100, 50, 50), game, false, 1, true));
                    Spak22.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(300, 150, 50, 50), game, false, 1, true));
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(550, 600, 50, 50), game, Spak22));
                    Blockers.InsertRange(InsertHere, Spak22);

                    List<Objects> Spak3 = new List<Objects>();
                    Spak3.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(500, 550, 50, 50), game, false, 1, true));
                    Spak3.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(500, 600, 50, 50), game, false, 1, true)); ;
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(500, 100, 50, 50), game, Spak3));
                    Blockers.InsertRange(InsertHere, Spak3);
                    break;
                case 5:
 
                    List<Objects> Spak111 = new List<Objects>();
                    Spak111.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(550, 400, 50, 50), game, false, 1, true));
                    Spak111.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(550, 450, 50, 50), game, false, 1, true));
                    Spak111.Add(new BrownBlock(game.Content.Load<Texture2D>("FloorPic"), new Rectangle(150, 400, 50, 50), game, false, 2, true));
                    Spak111.Add(new BrownBlock(game.Content.Load<Texture2D>("FloorPic"), new Rectangle(200, 400, 50, 50), game, false, 2, true));
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(250, 500, 50, 50), game, Spak111));
                    Blockers.InsertRange(InsertHere, Spak111);

                    List<Objects> Spak222 = new List<Objects>();
                    Spak222.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(300, 150, 50, 50), game, false, 1, true));
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(50, 400, 50, 50), game, Spak222));
                    Blockers.InsertRange(InsertHere, Spak222);

                    List<Objects> Spak33 = new List<Objects>();
                    Spak33.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(250, 550, 50, 50), game, false, 1, true));
                    Spak33.Add(new BrownBlock(game.Content.Load<Texture2D>("gräs"), new Rectangle(250, 600, 50, 50), game, false, 1, true));
                    Blockers.Insert(InsertHere, new Spak(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), game.Content.Load<Texture2D>("gräs"), game.Content.Load<Texture2D>("FloorPic"), new Rectangle(250, 150, 50, 50), game, Spak33));
                    Blockers.InsertRange(InsertHere, Spak33);

                    break;
                default:
                    break;
                    
            }
             

        }
        public static void MakePlayers(Game1 game, List<Objects> Blockers)
        {
            for (int i = 0; i < Blockers.Count; i++)
            {
                if (Blockers[i] is Player || Blockers[i] is Spak3)
                {
                    Blockers.Remove(Blockers[i]);
                    i--;
                }
            }

    
            switch (game.CurrentLvl)
            {
                case 1:
                    Blockers.Add(new Player(game.Content.Load<Texture2D>("snubbeup"), game.Content.Load<Texture2D>("ManFight"), game.Content.Load<Texture2D>("Man"), game.Content.Load<Texture2D>("snubbeleft"), game.Content.Load<Texture2D>("snubbehopp"), new Rectangle(0, 450, 50, 50), game, true, 2, false, null));
                    break;
                case 2:
                    Blockers.Add(new Player(game.Content.Load<Texture2D>("snubbeup"), game.Content.Load<Texture2D>("ManFight"), game.Content.Load<Texture2D>("Man"), game.Content.Load<Texture2D>("snubbeleft"), game.Content.Load<Texture2D>("snubbehopp"), new Rectangle(0, 450, 50, 50), game, true, 2, false, null));
                    Blockers.Add(new Player(game.Content.Load<Texture2D>("snubbe2up"), game.Content.Load<Texture2D>("snubbe2right"), game.Content.Load<Texture2D>("snubbe2fram"), game.Content.Load<Texture2D>("snubbe2left"), game.Content.Load<Texture2D>("snubbe2hopp"), new Rectangle(450, 450, 50, 50), game, true, 4, false, null));
                    break;
                case 3:
                    Blockers.Add(new Player(game.Content.Load<Texture2D>("snubbeup"), game.Content.Load<Texture2D>("ManFight"), game.Content.Load<Texture2D>("Man"), game.Content.Load<Texture2D>("snubbeleft"), game.Content.Load<Texture2D>("snubbehopp"), new Rectangle(0, 450, 50, 50), game, true, 2, false, null));
                    Blockers.Add(new Player(game.Content.Load<Texture2D>("snubbe2up"), game.Content.Load<Texture2D>("snubbe2right"), game.Content.Load<Texture2D>("snubbe2fram"), game.Content.Load<Texture2D>("snubbe2left"), game.Content.Load<Texture2D>("snubbe2hopp"), new Rectangle(0, 0, 50, 50), game, true, 2, false, null));
                    break;
                case 4:
                    List<Player> PlayerList = new List<Player>();

                    Blockers.Add(new Player(game.Content.Load<Texture2D>("snubbeup"), game.Content.Load<Texture2D>("ManFight"), game.Content.Load<Texture2D>("Man"), game.Content.Load<Texture2D>("snubbeleft"), game.Content.Load<Texture2D>("snubbehopp"), new Rectangle(0, 550, 50, 50), game, true, 2, false, null));

                    Player Roby = new Player(game.Content.Load<Texture2D>("snubbe2up"), game.Content.Load<Texture2D>("snubbe2right"), game.Content.Load<Texture2D>("snubbe2fram"), game.Content.Load<Texture2D>("snubbe2left"), game.Content.Load<Texture2D>("snubbe2hopp"), new Rectangle(600, 600, 50, 50), game, true, 4, true, game.Content.Load<Texture2D>("snubbe2istol"));
                    PlayerList.Add(Roby);
                    Blockers.Add(new Spak3(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), new Rectangle(0, 200, 50, 50), game, PlayerList));
                    Blockers.Add(Roby);
                    Blockers.Add(new Player(game.Content.Load<Texture2D>("snubbe3up"), game.Content.Load<Texture2D>("snubbe3right"), game.Content.Load<Texture2D>("snubbe3front"), game.Content.Load<Texture2D>("snubbe3left"), game.Content.Load<Texture2D>("snubbe3hopp"), new Rectangle(600, 0, 50, 50), game, true, 3, false, null));
                    break;
                case 5:
                    List<Player> PlayerList2 = new List<Player>();
                    Blockers.Add(new Player(game.Content.Load<Texture2D>("snubbeup"), game.Content.Load<Texture2D>("ManFight"), game.Content.Load<Texture2D>("Man"), game.Content.Load<Texture2D>("snubbeleft"), game.Content.Load<Texture2D>("snubbehopp"), new Rectangle(300, 300, 50, 50), game, true, 4, false, null));
                    PlayerList2.Add(new Player(game.Content.Load<Texture2D>("snubbe2up"), game.Content.Load<Texture2D>("snubbe2right"), game.Content.Load<Texture2D>("snubbe2fram"), game.Content.Load<Texture2D>("snubbe2left"), game.Content.Load<Texture2D>("snubbe2hopp"), new Rectangle(600, 600, 50, 50), game, true, 4, true, game.Content.Load<Texture2D>("snubbe2istol")));
                    PlayerList2.Add(new Player(game.Content.Load<Texture2D>("snubbe3up"), game.Content.Load<Texture2D>("snubbe3right"), game.Content.Load<Texture2D>("snubbe3front"), game.Content.Load<Texture2D>("snubbe3left"), game.Content.Load<Texture2D>("snubbe3hopp"), new Rectangle(600, 0, 50, 50), game, true, 3, true, game.Content.Load<Texture2D>("snubbe3istol")));
                    Blockers.Add(new Spak3(game.Content.Load<Texture2D>("Spak1"), game.Content.Load<Texture2D>("Spak2"), new Rectangle(0, 250, 50, 50), game, PlayerList2));
                    Blockers.AddRange(PlayerList2);

                    Blockers.Add(new Player(game.Content.Load<Texture2D>("snubbe4up"), game.Content.Load<Texture2D>("snubbe4right"), game.Content.Load<Texture2D>("snubbe4front"), game.Content.Load<Texture2D>("snubbe4left"), game.Content.Load<Texture2D>("snubbe4hopp"), new Rectangle(0, 500, 50, 50), game, true, 2, false, null));
                    break;
                default:
                    break;
            }
        }


    }
}
