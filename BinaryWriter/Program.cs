using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace BinaryWriterTryout
{

    enum GameObjectType
    {
        Room,
        Player,
        Enemy
    }

    interface IGameObject
    {
        GameObjectType Type { get; }
        void Save(BinaryWriter writer);
        void Load(BinaryReader reader);
    }
    class Room : IGameObject
    {
        public GameObjectType Type { get { return GameObjectType.Room; } }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Description);
        }

        public void Load(BinaryReader reader)
        {
            Name = reader.ReadString();
            Description = reader.ReadString();
        }
    }

    class Player : IGameObject
    {
        public GameObjectType Type { get { return GameObjectType.Player; } }

        public string Name { get; set; }
        public int Health { get; set; }

        public void Load(BinaryReader reader)
        {
            Name = reader.ReadString();
            Health = reader.ReadInt32();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Health);
        }
    }

    class Enemy : IGameObject
    {
        public GameObjectType Type { get { return GameObjectType.Enemy;  } }
        public string Name { get; set; }
        public int Health { get; set; }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Health);
        }

        public void Load(BinaryReader reader)
        {
            Name = reader.ReadString();
            Health = reader.ReadInt32();
        }
    }


    class Game
    {
        public Player Player { get; set; }
        public List<IGameObject> GameObjects { get; private set; }

        public Game()
        {
            GameObjects = new List<IGameObject>();
        }

        public void AddGameObject(IGameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }
    }


    class GamePersistence
    {
        public void SaveGame(string filename, Game game)
        {
            using (var bw = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate)))
            {
                bw.Write(game.GameObjects.Count);

                foreach (var gameObject in game.GameObjects)
                {
                    bw.Write((int)gameObject.Type);
                    gameObject.Save(bw);
                }
            }
        }

        public Game LoadGame(string filename)
        {
            var game = new Game();
            using (var br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                var gameObjectCount = br.ReadInt32();
                for (var i = 0; i < gameObjectCount; i++)
                {
                    var type = (GameObjectType)br.ReadInt32();

                    IGameObject obj = null;

                    switch (type)
                    {
                        case GameObjectType.Room:
                            obj = new Room();
                            break;

                        case GameObjectType.Player:
                            game.Player = new Player();
                            obj = game.Player;
                            break;

                        case GameObjectType.Enemy:
                            obj = new Enemy();
                            break;
                    }
                    obj.Load(br);
                    game.AddGameObject(obj);
                }
            }
            return game;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            var room1 = new Room();
            room1.Name = "Room 1";
            room1.Description = "This is the description for room 1";

            var room2 = new Room();
            room2.Name = "Room 2";
            room2.Description = "This is the description for room 2";

            var player = new Player();
            player.Name = "yahya";
            player.Health = 100;

            var e1 = new Enemy();
            e1.Name = "Monstoros";
            e1.Health = 80;

            var e2 = new Enemy();
            e2.Name = "Quickiloss";
            e2.Health = 50;

            game.Player = player;

            game.AddGameObject(player);
            game.AddGameObject(room1);
            game.AddGameObject(room2);
            game.AddGameObject(e1);
            game.AddGameObject(e2);

            var persistence = new GamePersistence();
            persistence.SaveGame("game1.game", game);

            var loadedGame = persistence.LoadGame("game1.game");
            foreach (var gameObject in loadedGame.GameObjects)
            {
                var room = gameObject as Room;
                if (room != null)
                {
                    Console.WriteLine($"Room: {room.Name}\nDescription: {room.Description}");
                    Console.WriteLine();
                }

                var thePlayer = gameObject as Player;
                if (thePlayer != null)
                {
                    Console.WriteLine($"Player Name: {thePlayer.Name}");
                    Console.WriteLine($"Player Health: {thePlayer.Health}%");
                    Console.WriteLine();
                }

                var enemy = gameObject as Enemy;
                if (enemy != null)
                {
                    Console.WriteLine($"Enemy Name: {enemy.Name}");
                    Console.WriteLine($"Enemy Health: {enemy.Health}%");
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
