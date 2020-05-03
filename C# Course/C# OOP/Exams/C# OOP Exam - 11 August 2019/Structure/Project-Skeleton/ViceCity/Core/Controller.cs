using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using System.Linq;
using ViceCity.Models.Neghbourhoods;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        public IPlayer mainPlayer;
        private List<IGun> guns;
        private List<IPlayer> civilPlayers;
        private GangNeighbourhood hood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.guns = new List<IGun>();
            this.civilPlayers = new List<IPlayer>();
            this.hood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            switch (type)
            {
                case "Pistol":
                    {
                        Pistol pistol = new Pistol(name);
                        this.guns.Add(pistol);

                        return $"Successfully added {name} of type: {type}";
                    }
                case "Rifle":
                    {
                        Rifle rifle = new Rifle(name);
                        this.guns.Add(rifle);

                        return $"Successfully added {name} of type: {type}";
                    }
                default:
                    return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }
            else
            {
                if (name == "Vercetti")
                {
                    var weapon = this.guns[0];
                    this.mainPlayer.GunRepository.Add(weapon);
                    this.guns.Remove(weapon);

                    return $"Successfully added {weapon.Name} to the Main Player: Tommy Vercetti";
                }

                if (!this.civilPlayers.Any(x => x.Name == name))
                {
                    return "Civil player with that name doesn't exists!";
                }

                var player = civilPlayers.Where(x => x.Name == name).FirstOrDefault();
                var gun = this.guns[0];
                player.GunRepository.Add(gun);
                this.guns.Remove(gun);

                return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
            }
        }

        public string AddPlayer(string name)
        {
            CivilPlayer player = new CivilPlayer(name);
            this.civilPlayers.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var mainPlayerHealthBeforeFight = this.mainPlayer.LifePoints;
            var civilPlayersHealthBeforeFight = this.civilPlayers.Sum(p => p.LifePoints);

            this.hood.Action(this.mainPlayer, this.civilPlayers);

            if (mainPlayerHealthBeforeFight == this.mainPlayer.LifePoints &&
                civilPlayersHealthBeforeFight == this.civilPlayers.Sum(p => p.LifePoints))
            {
                return "Everything is okay!";
            }
            else
            {
                return "A fight happened:" + Environment.NewLine
                    + $"Tommy live points: {this.mainPlayer.LifePoints}!" + Environment.NewLine
                    + $"Tommy has killed: {this.civilPlayers.Where(p => !p.IsAlive).Count()} players!" + Environment.NewLine
                    + $"Left Civil Players: {this.civilPlayers.Where(p => p.IsAlive).Count()}!";
            }

        }
    }
}
