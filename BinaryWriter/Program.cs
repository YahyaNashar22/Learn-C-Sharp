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
    interface IGame
    {
        IGameObject GetGameObject(Guid id);
    }

    interface IGameObject
    {
        GameObjectType Type { get; }

        Guid Id { get; }
        void Save(BinaryWriter writer);
        void Load(IGame game, BinaryReader reader);
    }

    class Room : IGameObject
    {
        public GameObjectType Type { get { return GameObjectType.Room; } }
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Room(Guid id)
        {
            Id = id;
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Description);
        }

        public void Load(IGame game, BinaryReader reader)
        {
            Name = reader.ReadString();
            Description = reader.ReadString();
        }
    }

    class Player : IGameObject
    {
        public GameObjectType Type { get { return GameObjectType.Player; } }

        public Guid Id { get; private set; }

        public string Name { get; set; }
        public int Health { get; set; }

        public Room CurrentRoom { get; set; }

        public Player(Guid id)
        {
            Id = id;
        }

        public void Load(IGame game, BinaryReader reader)
        {
            Name = reader.ReadString();
            Health = reader.ReadInt32();
            var currentRoomId = new Guid(reader.ReadBytes(16));
            CurrentRoom = (Room)game.GetGameObject(currentRoomId);
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Health);
            writer.Write(CurrentRoom.Id.ToByteArray());
        }
    }

    class Enemy : IGameObject
    {
        public GameObjectType Type { get { return GameObjectType.Enemy;  } }
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public int Health { get; set; }

        public Enemy(Guid id)
        {
            Id = id;
        }
        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Health);
        }

        public void Load(IGame game, BinaryReader reader)
        {
            Name = reader.ReadString();
            Health = reader.ReadInt32();
        }
    }


    class Game: IGame
    {
        public Player Player { get; set; }
        public Dictionary<Guid, IGameObject> GameObjects { get; private set; }

        public Game()
        {
            GameObjects = new Dictionary<Guid, IGameObject>();
        }

        public void AddGameObject(IGameObject gameObject)
        {
            GameObjects.Add(gameObject.Id,gameObject);
        }

        public IGameObject GetGameObject(Guid id)
        {
            return GameObjects[id];
        }
    }


    class GamePersistence
    {
        public void SaveGame(string filename, Game game)
        {
            using (var bw = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate)))
            {
                bw.Write(game.GameObjects.Count);

                foreach (var gameObject in game.GameObjects.Values)
                {
                    bw.Write((int)gameObject.Type);
                    bw.Write(gameObject.Id.ToByteArray());
                }

                foreach (var gameObject in game.GameObjects.Values)
                {
                    gameObject.Save(bw);
                }
            }
        }

        public Game LoadGame(string filename)
        {
            var game = new Game();
            using (var br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                var gameObjects = new List<IGameObject>();

                var gameObjectCount = br.ReadInt32();
                for (var i = 0; i < gameObjectCount; i++)
                {

                    var type = (GameObjectType)br.ReadInt32();
                    var id = new Guid(br.ReadBytes(16));

                    IGameObject obj = null;

                    switch (type)
                    {
                        case GameObjectType.Room:
                            obj = new Room(id);
                            break;

                        case GameObjectType.Player:
                            game.Player = new Player(id);
                            obj = game.Player;
                            break;

                        case GameObjectType.Enemy:
                            obj = new Enemy(id);
                            break;
                    }
                    gameObjects.Add(obj);
                    game.AddGameObject(obj);
                }

                foreach (var gameObject in gameObjects)
                {
                    gameObject.Load(game, br);
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

            var room1 = new Room(Guid.NewGuid());
            room1.Name = "Room 1";
            room1.Description = "This is the description for room 1";

            var room2 = new Room(Guid.NewGuid());
            room2.Name = "Room 2";
            room2.Description = "This is the description for room 2";

            var player = new Player(Guid.NewGuid());
            player.Name = "yahya";
            player.Health = 100;

            var e1 = new Enemy(Guid.NewGuid());
            e1.Name = "Monstoros";
            e1.Health = 80;

            var e2 = new Enemy(Guid.NewGuid());
            e2.Name = "Quickiloss";
            e2.Health = 50;

            game.Player = player;
            game.Player.CurrentRoom = room1;

            game.AddGameObject(player);
            game.AddGameObject(room1);
            game.AddGameObject(room2);
            game.AddGameObject(e1);
            game.AddGameObject(e2);

            var persistence = new GamePersistence();
            persistence.SaveGame("game1.game", game);

            var loadedGame = persistence.LoadGame("game1.game");
            foreach (var gameObject in loadedGame.GameObjects.Values)
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
                    if (thePlayer.CurrentRoom != null)
                    {
                        Console.WriteLine($"{thePlayer.Name} is current in: {thePlayer.CurrentRoom.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{thePlayer.Name} is not in any room!");
                    }
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
