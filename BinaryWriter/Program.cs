using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace BinaryWriterTryout
{
    interface IGameObject
    {
        void Save(BinaryWriter writer);
        void Load(BinaryReader reader);
    }
    class Room
    { 
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
        public string Name { get; set; }
        public int Health { get; set; }

        public void Load(BinaryReader reader)
        {
            Name= reader.ReadString();
            Health = reader.ReadInt32();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Health);
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

        public void AddGameObject (IGameObject room)
        {
            GameObjects.Add(room);
        }
    }

    
    class GamePersistence
    {
        public void SaveGame(string filename, Game game)
        {
            using (var bw = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate)))
            {
                bw.Write(game.Rooms.Count);

                foreach (var room in game.Rooms)
                {
                    room.Save(bw);
                }
            }
        }

        public Game LoadGame(string filename)
        {
            var game = new Game();
            using (var br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                var roomCount = br.ReadInt32();
                for (var i = 0; i < roomCount; i++)
                {
                    var room = new Room();
                    room.Load(br);

                    game.AddRoom(room);
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

            game.AddRoom(room1);
            game.AddRoom(room2);

            var persistence = new GamePersistence();
            persistence.SaveGame("game1.game", game);

            var loadedGame = persistence.LoadGame("game1.game");
            foreach (var room in loadedGame.Rooms)
            {
                Console.WriteLine($"Room: {room.Name}\nDescription: {room.Description}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
