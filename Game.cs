using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Game
    {
        const int mapWidth = 20;
        const int mapHeight = 10;
        Room[,] rooms = new Room[mapWidth, mapHeight];
        Player player = new Player("John", 100, 20);
        List<Being> Fightroom = new List<Being>();
       
        private int xOgre;
        private int yOgre;
        private int xGiant;
        private int yGiant;
        private int xWeapon;
        private int yWeapon;
        private int xPotion;
        private int yPotion;


        public void Start()
        {
            CreateMap();
            do
            {
                Console.Clear();
                EntityPosition();
                DisplayPlayerInfo();              
                DisplayMap();
                AskForCommand();

            } while (player.Health > 0);// Så länge spelaren lever
        }

        private void CreateMap()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Room room = new Room();
                    rooms[x, y] = room;
                }
            }
            Random rnd = new Random();
            this.xOgre = rnd.Next(0, mapWidth);
            this.yOgre = rnd.Next(0, mapHeight);
            this.xGiant = rnd.Next(0, mapWidth);
            this.yGiant = rnd.Next(0, mapHeight);
            this.xWeapon = rnd.Next(0, mapWidth);
            this.yWeapon = rnd.Next(0, mapHeight);
            this.xPotion = rnd.Next(0, mapWidth);
            this.yPotion = rnd.Next(0, mapHeight);

            rooms[xOgre, yOgre].MonsterInRoom = new Ogre("Ogre", 40, 20); // Lägger till ett Monster
            rooms[xGiant, yGiant].MonsterInRoom = new Giant("Giant", 40, 20);
                          
            rooms[xWeapon, yWeapon].ItemInRoom = new Weapon("Sword", 30); // Lägger till ett Item
            rooms[xPotion, yPotion].ItemInRoom = new Potion("Health", 25);
        }

        private void VarRand()
        {

        }

        private void PlayerFight()
        {
            Fightroom.Add(player);
            do
            {
                Fightroom[0].Fight(Fightroom[0], Fightroom[1]);
            } while ((Fightroom[0].Health > 0));
        }

        private void EntityPosition()
        {
            if (((player.X == xWeapon) && (player.Y == yWeapon)) && (rooms[xWeapon, yWeapon].ItemInRoom != null))
            {
                player.PlayerItems.Add(rooms[xWeapon, yWeapon].ItemInRoom);
                player.AttackStrength += rooms[xWeapon, yWeapon].ItemInRoom.Value;
                rooms[xWeapon, yWeapon].ItemInRoom = null;
            }
            else if (((player.X == xPotion) && (player.Y == yPotion)) && (rooms[xPotion, yPotion].ItemInRoom != null))
            {
                player.PlayerItems.Add(rooms[xPotion, yPotion].ItemInRoom);
                player.Health += rooms[xPotion, yPotion].ItemInRoom.Value;
                rooms[xPotion, yPotion].ItemInRoom = null;
            }
            else if (((player.X == xOgre) && (player.Y == yOgre)) && (rooms[xOgre, yOgre].MonsterInRoom != null))   
            {
                if (rooms[xOgre, yOgre].MonsterInRoom.Symbol == "O")
                {
                    Fightroom.Add(rooms[xOgre, yOgre].MonsterInRoom);
                    PlayerFight();
                    rooms[xOgre, yOgre].MonsterInRoom = null;
                }
                Fightroom.Clear();
            }
            else if (((player.X == xGiant) && (player.Y == yGiant)) && (rooms[xGiant, yGiant].MonsterInRoom != null))
            {   
                if (rooms[xGiant, yGiant].MonsterInRoom.Symbol == "G")
                {
                    Fightroom.Add(rooms[xGiant, yGiant].MonsterInRoom);
                    PlayerFight();
                    rooms[xGiant, yGiant].MonsterInRoom = null;
                }
                Fightroom.Clear();
            }
        }

        private void DisplayOgreInfo()
        {
            if (rooms[xOgre, yOgre].MonsterInRoom != null)
            {
                Console.WriteLine("Ogre: " + "Health:" + rooms[xOgre, yOgre].MonsterInRoom.Health + " - " + "Dmg:" + rooms[xOgre, yOgre].MonsterInRoom.AttackStrength);
            }
            
        }

        private void DisplayGiantInfo()
        {
            if (rooms[xGiant, yGiant].MonsterInRoom != null)
            {
                Console.WriteLine("Giant: " + "Health:" + rooms[xGiant, yGiant].MonsterInRoom.Health + " - " + "Dmg:" + rooms[xGiant, yGiant].MonsterInRoom.AttackStrength);
            }
        }

        private void DisplayPlayerInfo()
        {
            Console.WriteLine("Player: " + "Health:" + player.Health + " - " + "Dmg:" + player.AttackStrength);
            DisplayOgreInfo();
            DisplayGiantInfo();
            if (player.PlayerItems.Count >= 1)
            { 
                Console.WriteLine("Inventory:");
                int itemPosition = 0;
                do
                {
                    Console.WriteLine(player.PlayerItems[itemPosition].Name + " " + player.PlayerItems[itemPosition].Value);
                    itemPosition++;
                } while (itemPosition < player.PlayerItems.Count);
            }
        }

        private void DisplayMap()
        {
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    Room room = rooms[x, y];

                    if (player.X == x && player.Y == y)
                        Console.Write(player.Symbol);
                    else if (room.MonsterInRoom != null)
                        Console.Write(room.MonsterInRoom.Symbol);
                    else if (room.ItemInRoom != null)
                        Console.Write(room.ItemInRoom.Symbol);
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        private void AskForCommand()
        {
            Console.WriteLine("Enter movement");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (player.X != 0)
                        player.X--;
                    break;
                case ConsoleKey.RightArrow:
                    if (player.X != (mapWidth - 1))
                        player.X++;
                    break;
                case ConsoleKey.UpArrow:
                    if (player.Y != 0)
                        player.Y--;
                    break;
                case ConsoleKey.DownArrow:
                    if (player.Y != (mapHeight - 1))
                        player.Y++;
                    break;
            }     
        }
    }
}