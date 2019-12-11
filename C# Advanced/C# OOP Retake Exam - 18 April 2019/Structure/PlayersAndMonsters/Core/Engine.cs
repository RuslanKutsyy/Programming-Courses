using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Contracts
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IManagerController managerController = new ManagerController();

            while (true)
            {
                string data = Console.ReadLine();

                if (data == "Exit")
                {
                    break;
                }

                var cmdData = data.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = cmdData[0];

                try
                {
                    switch (cmd)
                    {
                        case "AddPlayer":
                            {
                                string playerType = cmdData[1];
                                string playerUsername = cmdData[2];
                                Console.WriteLine(managerController.AddPlayer(playerType, playerUsername));
                                break;
                            }
                        case "AddCard":
                            {
                                string cardType = cmdData[1];
                                string cardName = cmdData[2];
                                Console.WriteLine(managerController.AddCard(cardType, cardName));
                                break;
                            }
                        case "AddPlayerCard":
                            {
                                string username = cmdData[1];
                                string cardName = cmdData[2];
                                Console.WriteLine(managerController.AddPlayerCard(username, cardName));
                                break;
                            }
                        case "Fight":
                            {
                                string attackUser = cmdData[1];
                                string enemy = cmdData[2];
                                Console.WriteLine(managerController.Fight(attackUser, enemy));
                                break;
                            }
                        case "Report":
                            {
                                Console.WriteLine(managerController.Report());
                                break;
                            }

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
