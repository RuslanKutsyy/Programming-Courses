using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {


            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            else
            {
                attackPlayer = AddBonusHealthPoints(attackPlayer);
                enemyPlayer = AddBonusHealthPoints(enemyPlayer);

                if (attackPlayer is Beginner)
                {
                    attackPlayer.Health += 40;

                    foreach (var card in attackPlayer.CardRepository.Cards)
                    {
                        card.DamagePoints += 30;
                    }
                }

                if (enemyPlayer is Beginner)
                {
                    enemyPlayer.Health += 40;

                    foreach (var card in enemyPlayer.CardRepository.Cards)
                    {
                        card.DamagePoints += 30;
                    }
                }

                while (true)
                {
                    int damage = 0;

                    foreach (var card in attackPlayer.CardRepository.Cards)
                    {
                        damage += card.DamagePoints;
                    }

                    if (damage > enemyPlayer.Health)
                    {
                        damage = enemyPlayer.Health;
                    }

                    enemyPlayer.TakeDamage(damage);

                    if (enemyPlayer.IsDead)
                    {
                        break;
                    }
                    damage = 0;

                    foreach (var card in enemyPlayer.CardRepository.Cards)
                    {
                        damage += card.DamagePoints;
                    }

                    if (damage > attackPlayer.Health)
                    {
                        damage = attackPlayer.Health;
                    }
                    attackPlayer.TakeDamage(damage);

                    if (attackPlayer.IsDead)
                    {
                        break;
                    }
                }
            }

        }

        private IPlayer AddBonusHealthPoints(IPlayer player)
        {
            foreach (var card in player.CardRepository.Cards)
            {
                player.Health += card.HealthPoints;
            }

            return player;
        }
    }
}
