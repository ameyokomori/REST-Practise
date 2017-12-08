using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4.Models
{
    interface IPlayerRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerInfo(int id);
        void DeletePlayer(int id);
        Player PlayerRegistration(Player player);
        bool PlayerUpdate(Player player);
        void WriteAllPlayers(IEnumerable<Player> players);
    }
}
