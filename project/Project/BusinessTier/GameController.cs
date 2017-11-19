﻿using BusinessTier.Interfaces;
using DataTier;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessTier
{
    public class GameController : IGameController
    {
        private IProfileController profileController;
        private static List<Game> games = new List<Game>();

        public GameController()
        {
            profileController = new ProfileController();
        }

        public int JoinGame(int gameId, int profileId, object callback)
        {
            try
            {
                Game game = FindGame(gameId);
                lock (game)
                {

                    if (game.Player1.ProfileID != profileId)//person isnt in game
                    {
                        Profile user = profileController.ReadProfile(profileId.ToString(), 1);//gets the user from database
                        user.CallBack = callback;//adds callback object to it
                        game.Player1 = user;//adds user to list
                        return 1;//joined
                    }
                    else
                        if (game.Player2.ProfileID != profileId)
                    {
                        Profile user = profileController.ReadProfile(profileId.ToString(), 1);//gets the user from database
                        user.CallBack = callback;//adds callback object to it
                        game.Player2 = user;//adds user to list
                        return 2;//joined
                    }
                    else
                        return -1;//person is in game already
                }
            }
            catch (Exception)//Game isnt in games list
            {
                try
                {
                    lock (games)
                    {
                        Game game = new Game { GameId = games.Last().GameId + 1 }; //creates new game
                        Profile user = profileController.ReadProfile(profileId.ToString(), 1);//gets user from database
                        user.CallBack = callback;//adds callback object to it
                        game.Player1 = user; //add player to game
                        games.Add(game);//adds game to games list
                        return 1;//joined
                    }
                }
                catch (Exception)//catches exeption if something went wrong
                {
                    return 0;
                }
            }
        }

        public int LeaveGame(int gameId, int profileId)
        {
            try
            {
                Game game = FindGame(gameId);//looks for existing game
                lock (game)
                {
                    if (game.Player1.ProfileID == profileId)
                    {
                        game.Player1 = null;
                        return 1;
                    }
                    else
                    if (game.Player2.ProfileID == profileId)
                    {
                        game.Player2 = null;
                        return 2;
                    }

                    if (game.Player1 == null && game.Player2 == null)
                    {
                        lock (games)
                        {
                            games.Remove(game);
                            return 0;
                        }
                    }
                    return -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int MakeChoice(int gameId, int profileId, int choice)
        {
            Game game = FindGame(gameId);
            lock (game)
            {
                if (game.Player1.ProfileID == profileId)
                {
                    game.Choice1 = choice;
                }
                else
                {
                    game.Choice2 = choice;
                }

                if (game.Choice1 != -1 && game.Choice2 != -1) //if both players made a choice
                {
                    if ((game.Choice1 == 0 && game.Choice2 == 2) || (game.Choice1 == 1 && game.Choice2 == 0) || (game.Choice1 == 2 && game.Choice2 == 0)) // player1 wins
                        return 1;
                    else
                        if (game.Choice1 == game.Choice2) //tie
                        return 0;
                    else
                        return 2;

                }
                else
                    return -1; //not all players made a choice
            }
        }

        public Game FindGame(int gameId)
        {
            Game game = games.Find(
            delegate (Game g)
            {
                return g.GameId == gameId;
            }
            );
            return game;
        }
    }
}
