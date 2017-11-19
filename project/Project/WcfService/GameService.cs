﻿using System;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GameService" in both code and config file together.
    public class GameService : IGameService
    {
        private IGameController gameController = new GameController();
        public void JoinGame(int gameId, int profileId)
        {
            object callbackObj = OperationContext.Current.GetCallbackChannel<IGameCallBack>();
            IGameCallBack callback = (IGameCallBack)callbackObj;
            if (gameController.JoinGame(gameId, profileId, callback) == 1)
            {
                Profile user = gameController.FindGame(gameId).Player2;
                callback = (IGameCallBack)user.CallBack;
                callback.PlayerJoins(user.ProfileID);
                callback.Show(true);
            }
            else
            if (gameController.JoinGame(gameId, profileId, callback) == 2)
            {
                Profile user = gameController.FindGame(gameId).Player1;
                callback = (IGameCallBack)user.CallBack;
                callback.PlayerJoins(user.ProfileID);
                callback.Show(true);
            }
            else
            {
                callback.Show(false);
            }
        }

        public void LeaveGame(int gameId, int profileId)
        {
            if (gameController.LeaveGame(gameId, profileId) == 1)
            {
                Profile user = gameController.FindGame(gameId).Player1;
                IGameCallBack callback = (IGameCallBack)user.CallBack;
                callback.PlayerLeaves(user.ProfileID);
            }
            else
            if (gameController.LeaveGame(gameId, profileId) == 2)
            {
                Profile user = gameController.FindGame(gameId).Player2;
                IGameCallBack callback = (IGameCallBack)user.CallBack;
                callback.PlayerLeaves(user.ProfileID);
            }
        }

        public void MakeChoice(int gameId, int profileId, int choice)
        {
            Profile player1 = gameController.FindGame(gameId).Player1;
            Profile player2 = gameController.FindGame(gameId).Player2;
            IGameCallBack player1Callback = (IGameCallBack)player1.CallBack;
            IGameCallBack player2Callback = (IGameCallBack)player2.CallBack;

            player1Callback.Result(gameController.MakeChoice(gameId, profileId, choice));
            player2Callback.Result(gameController.MakeChoice(gameId, profileId, choice));

        }
    }
}