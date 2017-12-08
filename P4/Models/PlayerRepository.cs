using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace P4.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<Player> players = new List<Player>();
        String path = AppDomain.CurrentDomain.BaseDirectory + @"players.txt";
        private int ID = 0;

        public PlayerRepository()
        {
            players = new List<Player>();
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            players = new List<Player>();
            Player player;
            ID = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    ID++;
                    player = new Player();
                    String[] temp = line.Split(',');

                    player.ID = ID;
                    player.Registration_ID = temp[0];
                    player.Player_name = temp[1];
                    player.Team_name = temp[2];
                    player.Date_of_birth = Convert.ToDateTime(temp[3]);

                    players.Add(player);
                }
                sr.Close();
            }
            return players;
        }

        public Player GetPlayerInfo(int id)
        {
            return players.Find(p => p.ID == id);
        }

        public void DeletePlayer(int id)
        {
            players.RemoveAll(p => p.ID == id);
            WriteAllPlayers(players);
        }

        public Player PlayerRegistration(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }
            player.ID = ID++;
            players.Add(player);
            WriteAllPlayers(players);
            return player;
        }

        public bool PlayerUpdate(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException("player");
            }            
            if (player.ID <= 0)
            {
                return false;
            }

            Player old_player = new Player();

            foreach (Player p in players)
            {
                if (p.ID.Equals(player.ID))
                {
                    old_player = p;
                }
            }

            if (player.Player_name == null)
            {
                player.Player_name = old_player.Player_name;
            }
            if (player.Registration_ID == null)
            {
                player.Registration_ID = old_player.Registration_ID;
            }
            if (player.Team_name == null)
            {
                player.Team_name = old_player.Team_name;
            }
            if (player.Date_of_birth.Equals(new DateTime()))
            {
                player.Date_of_birth = old_player.Date_of_birth;
            }

            players.Remove(old_player);
            players.Add(player);
            WriteAllPlayers(players);
            return true;
        }

        public void WriteAllPlayers(IEnumerable<Player> players)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Player player in players)
                {
                    sw.WriteLine(player.Registration_ID + "," + player.Player_name + "," + player.Team_name + "," + player.Date_of_birth);
                }
                sw.Close();
            }
        }
    }
}