using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;
using BusinessTier;
using BusinessTier.Interfaces;

namespace WcfService
{
    public class GameService : IGameService
    {
        private IGameController gameController = new GameController();

        /// <summary>
        /// Add player to game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="profileId"></param>
        public void JoinGame(int gameId, int profileId)
        {
            //Create callback object to RPSForm
            object callbackObj = OperationContext.Current.GetCallbackChannel<IGameCallBack>();
            IGameCallBack callback = (IGameCallBack)callbackObj;
            //add player to game
            int joinResult = gameController.JoinGame(gameId, profileId, callbackObj);

            if (joinResult != -1) //if player joined
            {
                Game game = gameController.FindGame(gameId); //find the game player joined
                //get plyers in the game
                Profile player1 = game.Player1;
                Profile player2 = game.Player2;

                if (joinResult == 2) //if they joined as player2
                {
                    callback.PlayerJoins(player2.ProfileID, player2.Nickname); //callback RPSForm with the details
                    callback.Show(true); //callback RPSForm to show on screen
                }
                else
                {
                    callback.PlayerJoins(player1.ProfileID, player1.Nickname);
                    callback.Show(true);
                }

                if (player1 != null && player2 != null) //if both players are in game
                {
                    //norify each of them, of the others info
                    callback = (IGameCallBack)player1.CallBack;
                    callback.PlayerJoins(player2.ProfileID, player2.Nickname);

                    callback = (IGameCallBack)player2.CallBack;
                    callback.PlayerJoins(player1.ProfileID, player1.Nickname);
                }

            }
            else
            {
                callback.Show(false); //make RPSForm close
            }
        }

        /// <summary>
        /// Remove player from game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="profileId"></param>
        public void LeaveGame(int gameId, int profileId)
        {
            Game game = gameController.FindGame(gameId); //find the game
            //get players in the game
            Profile player1 = game.Player1;
            Profile player2 = game.Player2;
            int leaveResult = gameController.LeaveGame(gameId, profileId); //remove player from game

            if (leaveResult == 1 && player2 != null) //if the removed player was player1 and there is still a player2
            {
                //callback RPSForm that palyer1 left
                IGameCallBack callback = (IGameCallBack)player2.CallBack;
                callback.PlayerLeaves();
            }
            else
            if (leaveResult == 2 && player1 != null) //if the removed player was player2 and there is still a player1
            {
                //callback RPSForm that player2 left
                IGameCallBack callback = (IGameCallBack)player1.CallBack;
                callback.PlayerLeaves();
            }
        }

        /// <summary>
        /// Secure player's choice and callback RPSForm of the result
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="profileId"></param>
        /// <param name="choice"></param>
        public void MakeChoice(int gameId, int profileId, int choice)
        {
            Game game = gameController.FindGame(gameId);
            Profile player1 = game.Player1;
            Profile player2 = game.Player2;

            int result = gameController.MakeChoice(gameId, profileId, choice);
            switch (result)
            {
                case -2: //player2 did not make a choice
                    if (player1 != null) //if there is still a player1
                    {
                        //callback RPSForm
                        IGameCallBack player1Callback = (IGameCallBack)player1.CallBack;
                        player1Callback.Result(-2);
                    }
                    if (player2 != null) //if there is still a player2
                    {
                        IGameCallBack player2Callback = (IGameCallBack)player2.CallBack;
                        player2Callback.Result(-1);
                    }
                    break;
                case -1: //player1 did not make a choice 
                    if (player1 != null)
                    {
                        IGameCallBack player1Callback = (IGameCallBack)player1.CallBack;
                        player1Callback.Result(-1);
                    }
                    if (player2 != null)
                    {
                        IGameCallBack player2Callback = (IGameCallBack)player2.CallBack;
                        player2Callback.Result(-2);
                    }
                    break;
                case 1: //player1 won
                    if (player1 != null)
                    {
                        IGameCallBack player1Callback = (IGameCallBack)player1.CallBack;
                        player1Callback.Result(1);
                    }
                    if (player2 != null)
                    {
                        IGameCallBack player2Callback = (IGameCallBack)player2.CallBack;
                        player2Callback.Result(2);
                    }
                    break;
                case 2: //player2 won
                    if (player1 != null)
                    {
                        IGameCallBack player1Callback = (IGameCallBack)player1.CallBack;
                        player1Callback.Result(2);
                    }
                    if (player2 != null)
                    {
                        IGameCallBack player2Callback = (IGameCallBack)player2.CallBack;
                        player2Callback.Result(1);
                    }
                    break;
                default: //tie
                    if (player1 != null)
                    {
                        IGameCallBack player1Callback = (IGameCallBack)player1.CallBack;
                        player1Callback.Result(result);
                    }
                    if (player2 != null)
                    {
                        IGameCallBack player2Callback = (IGameCallBack)player2.CallBack;
                        player2Callback.Result(result);
                    }
                    break;
            }
        }
    }
}
