using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using P4.Models;

namespace P4.Controllers
{
    public class PlayerController : ApiController
    {
        static readonly IPlayerRepository repository = new PlayerRepository();

        public IEnumerable<Player> GetAllPlayers()
        {
            return repository.GetAllPlayers();
        }

        public Player GetPlayer(int id)
        {
            Player player = repository.GetPlayerInfo(id);
            return player;
        }

        public IEnumerable<Player> GetPlayersByRegistrationID(string Registration_ID)
        {
            IEnumerable<Player> players = repository.GetAllPlayers();
            List<Player> results = new List<Player>();
            foreach (Player p in players)
            {
                if (p.Registration_ID.Equals(Registration_ID))
                {
                    results.Add(p);
                }
            }
            return results;
        }

        public IEnumerable<Player> GetPlayersByPlayerName(string Player_name)
        {
            IEnumerable<Player> players = repository.GetAllPlayers();
            List<Player> results = new List<Player>();
            foreach (Player p in players)
            {
                if (p.Player_name.Equals(Player_name))
                {
                    results.Add(p);
                }
            }
            return results;
        }

        public IEnumerable<Player> GetPlayersByTeamName(string Team_name)
        {
            IEnumerable<Player> players = repository.GetAllPlayers();
            List<Player> results = new List<Player>();
            foreach (Player p in players)
            {
                if (p.Team_name.Equals(Team_name))
                {
                    results.Add(p);
                }
            }
            return results;
        }

        public Player PostPlayer(Player player)
        {
            Player newPlayer = repository.PlayerRegistration(player);
            return newPlayer;
        }

        public void DeletePlayer(int id)
        {
            repository.DeletePlayer(id);
        }

        public void DeletePlayerByTeam(String Team_name)
        {
            IEnumerable<Player> players = repository.GetAllPlayers();
            List<Player> results = players.ToList<Player>();
            foreach (Player p in players)
            {
                if (p.Team_name.Equals(Team_name))
                {
                    results.Remove(p);
                }
            }
            repository.WriteAllPlayers(results);
        }

        public void PutPlayer(int id, Player player)
        {
            player.ID = id;
            if (!repository.PlayerUpdate(player))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
