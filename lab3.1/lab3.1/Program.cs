using System;

namespace lab31
{
    class Dispenser
    {
        private static Dispenser instanse;
        private Dispenser()
        {
            chips = new List<Chip>();
            playGround = new PlayGround(100);
        }
        public static Dispenser GetInstanse()
        {
            if (instanse == null)
            {
                instanse = new Dispenser();
            }
            return instanse;
        }
        // -------------------------
        private readonly PlayGround playGround;
        private readonly List<Chip> chips;
        public PlayGround GetPlayGround()
        {
            return playGround;
        }
        public List<Chip> GetChips()
        {
            return chips;
        }

        public void CreateChips(int quantity) 
        {
            for (int i = 0; i < quantity; i++)
            {
                chips.Add(new Chip(chips.Count));
            }
        }
    }

    class Chip
    {
        public int Id { get; private set; }
        public Chip(int id)
        {
            Id = id;
        }
    }

    class PlayGround 
    {
        public int Size { get; private set; }

        public PlayGround(int size)
        {
            Size = size;
        }
    }
    class Program
    { 
    static void Main()
        {
            Console.WriteLine("Write the amount of players");
            int players = Convert.ToInt32(Console.ReadLine());
            Dispenser i1 = Dispenser.GetInstanse();
            i1.CreateChips(players);
            var chips = i1.GetChips();
            var pg = i1.GetPlayGround();
            Console.WriteLine($"You have got {chips.Count} chips and 1 Playground size of {pg.Size}");

        }
    }
}