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
        public void JoinGame(int gameId, int profileId)
        {
            object callbackObj = OperationContext.Current.GetCallbackChannel<IGameCallBack>();
            IGameCallBack callback = (IGameCallBack)callbackObj;

            if (gameController.JoinGame(gameId, profileId, callbackObj) != -1)
            {
                Game game = gameController.FindGame(gameId);
                Profile user = game.Player1;
                Profile user1 = game.Player2;

                if (user1 != null)
                {
                    callback.PlayerJoins(user1.ProfileID, user1.Nickname);
                }
                else
                {
                    callback.PlayerJoins(user.ProfileID, user.Nickname);
                }

                if (user != null && user1 != null)
                {
                    callback = (IGameCallBack)user.CallBack;
                    callback.PlayerJoins(user1.ProfileID, user1.Nickname);

                    callback = (IGameCallBack)user1.CallBack;
                    callback.PlayerJoins(user.ProfileID, user.Nickname);
                }

                callback.Show(true);
            }
            else
            {
                callback.Show(false);
            }
        }

        public void LeaveGame(int gameId, int profileId)
        {
            Game game = gameController.FindGame(gameId);
            Profile user = game.Player1;
            Profile user1 = game.Player2;

            if (gameController.LeaveGame(gameId, profileId) == 1 && user1 != null)
            {
                IGameCallBack callback = (IGameCallBack)user.CallBack;
                callback.PlayerLeaves();
            }
            else
            if (gameController.LeaveGame(gameId, profileId) == 2 && user != null)
            {
                IGameCallBack callback = (IGameCallBack)user.CallBack;
                callback.PlayerLeaves();
            }
        }

        public void MakeChoice(int gameId, int profileId, int choice)
        {
            Game game = gameController.FindGame(gameId);
            Profile user = game.Player1;
            Profile user1 = game.Player2;

            int result = gameController.MakeChoice(gameId, profileId, choice);
            switch (result)
            {
                case -2: //player2 did not make a choice
                    if (user != null)
                    {
                        IGameCallBack player1Callback = (IGameCallBack)user.CallBack;
                        player1Callback.Result(-2);
                    }
                    if (user1 != null)
                    {
                        IGameCallBack player2Callback = (IGameCallBack)user1.CallBack;
                        player2Callback.Result(-1);
                    }
                    break;
                case -1: //player1 did not make a choice if (player1 != null)
                    {
                        IGameCallBack player1Callback = (IGameCallBack)user.CallBack;
                        player1Callback.Result(-1);
                    }
                    if (user1 != null)
                    {
                        IGameCallBack player2Callback = (IGameCallBack)user1.CallBack;
                        player2Callback.Result(-2);
                    }
                    break;
                case 1: //player1 won
                    if (user != null)
                    {
                        IGameCallBack player1Callback = (IGameCallBack)user.CallBack;
                        player1Callback.Result(1);
                    }
                    if (user1 != null)
                    {
                        IGameCallBack player2Callback = (IGameCallBack)user1.CallBack;
                        player2Callback.Result(2);
                    }
                    break;
                case 2: //player2 won
                    if (user != null)
                    {
                        IGameCallBack player1Callback = (IGameCallBack)user.CallBack;
                        player1Callback.Result(2);
                    }
                    if (user1 != null)
                    {
                        IGameCallBack player2Callback = (IGameCallBack)user1.CallBack;
                        player2Callback.Result(1);
                    }
                    break;
                default: //tie
                    if (user != null)
                    {
                        IGameCallBack player1Callback = (IGameCallBack)user.CallBack;
                        player1Callback.Result(result);
                    }
                    if (user1 != null)
                    {
                        IGameCallBack player2Callback = (IGameCallBack)user1.CallBack;
                        player2Callback.Result(result);
                    }
                    break;
            }
        }
    }
}
