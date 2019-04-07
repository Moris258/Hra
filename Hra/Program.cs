using System;

namespace Hra
{
    class Enemy
    {
        public int hp;
        public int def;
        public int mdef;
        public int atk;
        public string name;

        public Enemy(int _hp, int _def, int _mdef, int _atk, string _name)
        {
            hp = _hp;
            def = _def;
            mdef = _def;
            atk = _atk;
            name = _name;
        }

    }

    class Player
    {
        public int hp;
        public int def;
        public int atk;
        public int Int;
        public string name;

        public Player(int hp, int _def, int _Int, int _atk, string _name)
        {
            this.hp = hp;
            def = _def;
            Int = _Int;
            atk = _atk;
            name = _name;

        }

    }


    class Ability
    {
        public int type;
        public string name;

        public Ability(int _type, string _name)
        {
            type = _type;
            name = _name;

        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Random halp = new Random();

            string[,] plos = new string[5, 5];
            Console.WriteLine(plos.GetLength(0));






            Console.Write("Enter your name: ");
            string name = Convert.ToString(Console.ReadLine());
            /*
            Console.Write("Enter your HP between 75 and 125 pls: ");
            int hp = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your Defense between 10 and 30 pls: ");
            int def = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your Attack between 25 and 50 pls: ");
            int atk = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your Intelligence between 25 and 50 pls: ");
            int Int = Convert.ToInt32(Console.ReadLine());
            */
            int points = 0;
            int hp = 90;
            int atk = 30;
            int Int = 30;
            int def = 30;



            Console.WriteLine("Choose a stat to modify with 1-4.");
            while (points > 0)
            {
                Console.WriteLine("You have " + points + " points remaining.");
                Console.WriteLine("1. HP: " + hp + " \n2. Atk: " + atk + " \n3. Int: " + Int + " \n4. Def: " + def);
                int stat = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Choose to increase or decrease the stat with + or -");


                switch (stat)
                {
                    case 1:
                        hp = Stat(hp, points);
                        break;
                    case 2:
                        atk = Stat(atk, points);
                        break;

                    case 3:
                        Int = Stat(Int, points);
                        break;

                    case 4:
                        def = Stat(def, points);
                        break;

                }
                points = 230 - (hp + Int + atk + def);
            }


            Player player1 = new Player(hp, def, Int, atk, name);

            Ability slash = new Ability(0, "Slash");
            Ability fireball = new Ability(1, "Fireball");

            string[,] grid = Grid();
            int x = 1;
            int y = 1;
            while (grid[x, y] != ".")
            {
                x = halp.Next(1, grid.GetLength(0) - 1);
                y = halp.Next(1, grid.GetLength(0) - 1);
            }

            grid[x, y] = "P";

            int enemies = 0;
            while (player1.hp > 0)
            {
                Enemy cat = new Enemy(halp.Next(90, 110), halp.Next(15, 25), halp.Next(15, 25), halp.Next(35, 55), "Cat");
                int c = halp.Next(1, 11);
                int d = halp.Next(1, 11);
                while (grid[c, d] != ".")
                {
                    c = halp.Next(1, grid.GetLength(0) - 1);
                    d = halp.Next(1, grid.GetLength(0) - 1);
                }
                while ((c == x) & (d == y))
                {
                    c = halp.Next(1, grid.GetLength(0) - 1);
                }
                grid[c, d] = "C";
                Grid(grid);

                while (x != c || y != d)
                {
                    ConsoleKeyInfo move = Console.ReadKey();
                    if (move.KeyChar == 'w')
                    {
                        if (grid[x, y - 1] == "_")
                        {

                        }
                        else
                        {
                            y--;
                            grid[x, y] = "P";
                            grid[x, y + 1] = ".";
                            Console.WriteLine();
                            Grid(grid);
                            Console.Beep();
                        }


                    }
                    else if (move.KeyChar == 'a')
                    {
                        if (grid[x - 1, y] == "|")
                        {

                        }
                        else
                        {
                            x--;
                            grid[x, y] = "P";
                            grid[x + 1, y] = ".";
                            Console.WriteLine();
                            Grid(grid);
                            Console.Beep();
                        }
                    }
                    else if (move.KeyChar == 's')
                    {
                        if (grid[x, y + 1] == "_")
                        {

                        }
                        else
                        {
                            y++;
                            grid[x, y] = "P";
                            grid[x, y - 1] = ".";
                            Console.WriteLine();
                            Grid(grid);
                            Console.Beep();
                        }


                    }
                    else if (move.KeyChar == 'd')
                    {
                        if (grid[x + 1, y] == "|")
                        {

                        }
                        else if (grid[x + 1, y] == "&")
                        {
                            x++;
                            grid[x, y] = "P";
                            grid[x - 1, y] = ".";
                            grid = Grid2(grid, x, y);
                            Console.WriteLine();
                            Grid(grid);
                            Console.Beep();
                        }
                        else
                        {
                            x++;
                            grid[x, y] = "P";
                            grid[x - 1, y] = ".";

                            Console.WriteLine();
                            Grid(grid);
                            Console.Beep();
                        }
                    }
                    else
                    {

                    }

                }
                Console.Beep(3000, 300); Console.Beep(1000, 100); Console.Beep(2250, 300); Console.Beep(750, 100); Console.Beep(1500, 300); Console.Beep(500, 100); Console.Beep(750, 300); Console.Beep(3000, 300);
                System.Threading.Thread.Sleep(1000);
                while (cat.hp > 0 && player1.hp > 0)
                {
                    int turn = 1;
                    Console.WriteLine("Turn: " + turn);
                    Console.WriteLine(cat.name + " hp: " + cat.hp);
                    System.Threading.Thread.Sleep(500);
                    Console.WriteLine(player1.name + " hp: " + player1.hp);
                    System.Threading.Thread.Sleep(500);
                    Console.WriteLine("Abilities:\nQ:" + slash.name + "   ;   E:" + fireball.name);
                failsave:

                    ConsoleKeyInfo spell = Console.ReadKey();
                    if (spell.KeyChar == 'q')
                    {
                        Console.WriteLine("\n" + player1.name + " used Slash.");
                        System.Threading.Thread.Sleep(1000);
                        int damage = player1.atk + halp.Next(0, 6) - cat.def;
                        if (damage < 0) damage = 0;
                        cat.hp = cat.hp - damage;
                        Console.WriteLine("Cat suffered " + damage + "physical damage.");
                        Console.Beep();

                    }
                    else if (spell.KeyChar == 'e')
                    {
                        Console.WriteLine("\n" + player1.name + " used Fireball.");
                        System.Threading.Thread.Sleep(1000);
                        int damage = (player1.Int - 10) + halp.Next(0, 21) - cat.mdef;
                        if (damage < 0) damage = 0;
                        cat.hp = cat.hp - damage;
                        Console.WriteLine("Cat suffered " + damage + "magical damage.");
                        Console.Beep();
                    }
                    else
                    {
                        goto failsave;
                    }
                    System.Threading.Thread.Sleep(2000);
                    int endamage = (cat.atk - 5) + halp.Next(0, 11) - player1.def;
                    if (endamage < 0) endamage = 0;
                    player1.hp = player1.hp - endamage;
                    Console.WriteLine("Suffered " + endamage + "damage from Cat's attack.");
                    Console.Beep();
                    turn++;
                    System.Threading.Thread.Sleep(1000);



                }
                if (cat.hp <= 0 && player1.hp > 0)
                {
                    Console.WriteLine("You defeated the cat. Conglaturation.");
                    enemies++;
                    Console.WriteLine("Press any key to continue.");
                    Console.WriteLine();
                    Console.Beep(1000, 200); Console.Beep(2000, 200); Console.Beep(3000, 200);
                    Console.ReadKey();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("GAME OVER. You were defeated by the cat. RIP.");
                    Console.WriteLine("Press any key to continue.");
                    Console.Beep(3000, 200); Console.Beep(2000, 200); Console.Beep(1000, 200); Console.Beep(500, 200);
                    Console.ReadKey();
                }

            }
            Console.WriteLine("\nYou managed to defeat " + enemies + " enemies. The world thanks you for your endeavor.");

            Console.ReadKey();



        }

        /*public static string[,] Grid()
        {
            int width = 12;
            int height = 12;
            string[,] grid = new string[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (y == 0 || y == height - 1)
                    {
                        grid[x, y] = "_";
                    }
                    else if (x == 0 || x == width - 1)
                    {
                        grid[x, y] = "|";
                    }
                    else
                    {
                        grid[x, y] = ".";
                    }
                    
                    Console.Write(grid[x,y] + " ");
                }
                Console.WriteLine();
            }
            return grid;
        }*/

        public static string[,] Grid()
        {
            Random random = new Random();

            int width = random.Next(35, 62);
            int height = width;
            string[,] grid = new string[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    grid[x, y] = " ";

                }

            }
            int roomwidth = random.Next(7, 17);
            int roomheight = random.Next(7, 17);
            int placey = random.Next(0, height - roomheight);
            int placex = random.Next(0, width - roomwidth);

            for (int x = placex; x < placex + roomwidth; x++)
            {
                for (int y = placey; y < placey + roomheight; y++)
                {
                    if (y == placey || y == placey + roomheight - 1)
                    {
                        grid[x, y] = "_";
                    }
                    else if (x == placex || x == placex + roomwidth - 1)
                    {
                        grid[x, y] = "|";
                    }
                    else
                    {
                        grid[x, y] = ".";
                    }


                    Console.Write(grid[x, y] + " ");

                }
                Console.WriteLine();
            }
            grid[placex + roomwidth - 1, placey + 5] = "#";
            grid[placex + roomwidth + 0, placey + 5] = "#";
            grid[placex + roomwidth + 1, placey + 5] = "#";
            grid[placex + roomwidth + 2, placey + 5] = "#";
            grid[placex + roomwidth + 3, placey + 5] = "#";
            grid[placex + roomwidth + 4, placey + 5] = "&";
            /*Start:
            roomwidth = random.Next(7, 17);
            roomheight = random.Next(7, 17);
            placey = random.Next(0, height - roomheight);
            placex = random.Next(0, width - roomwidth);
            for (int x = placex; x < placex + roomwidth; x++)
            {
                for (int y = placey; y < placey + roomheight; y++)
                {
                    if (grid[x, y] != null)
                    {
                        goto Start;
                        
                    }
                }
                
            }
            for (int x = placex; x < placex + roomwidth; x++)
            {
                for (int y = placey; y < placey + roomheight; y++)
                {
                    if (y == placey || y == placey + roomheight - 1)
                    {
                        grid[x, y] = "_";
                    }
                    else if (x == placex || x == placex + roomwidth - 1)
                    {
                        grid[x, y] = "|";
                    }
                    else
                    {
                        grid[x, y] = ".";
                    }
                    Console.Write(grid[x, y] + " ");
                }
                Console.WriteLine();
            }
            */


            return grid;


        }

        public static string[,] Grid2(string[,] grid, int o, int p)
        {

            Random random = new Random();
            //Start:
            int roomwidth = random.Next(7, 8);
            int roomheight = random.Next(7, 8);
            int placey = p;
            int placex = o;

            /*for (int x = placex; x < placex + roomwidth; x++)
            {
                for (int y = placey; y < placey + roomheight; y++)
                {
                    if (grid[x, y] != null)
                    {
                        goto Start;
                    }
                }
            }*/
            for (int x = placex; x < placex + roomwidth; x++)
            {
                for (int y = placey; y < placey + roomheight; y++)
                {
                    if (y == placey || y == placey + roomheight - 1)
                    {
                        grid[x, y] = "_";
                    }
                    else if (x == placex || x == placex + roomwidth - 1)
                    {
                        grid[x, y] = "|";
                    }
                    else
                    {
                        grid[x, y] = ".";
                    }


                    Console.Write(grid[x, y] + " ");

                }
                Console.WriteLine();
            }

            return grid;
        }

        public static void Grid(string[,] coor)
        {
            int width = coor.GetLength(0);
            int height = coor.GetLength(1);


            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    Console.Write(coor[x, y] + " ");

                }
                Console.WriteLine();
            }



        }
        public static int Stat(int att, int points)
        {
            ConsoleKeyInfo oper = Console.ReadKey();
            if (oper.KeyChar == '+')
            {
                Console.WriteLine("\nChoose how much to increase attribute by.");
                int halp = Convert.ToInt32(Console.ReadLine());
                if (halp > points)
                {
                    Console.WriteLine("Sorry my dude, that's too much.");
                }
                else
                {

                    att = att + halp;
                }


            }
            else if (oper.KeyChar == '-')
            {
                Console.WriteLine("\nChoose how much to decrease attribute by.");
                int halp = Convert.ToInt32(Console.ReadLine());
                if (halp > points)
                {
                    Console.WriteLine("Sorry my dude, that's too much.");
                }
                else
                {

                    att = att - halp;
                }
            }
            else
            {

            }
            return att;

        }


    }
}