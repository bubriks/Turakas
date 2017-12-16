using DataTier;

namespace BusinessTier.Interfaces
{
    public interface IGameController
    {
        /// <summary>
        /// Adds user to a game, creates a game if it does not exist yet
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="profileId"></param>
        /// <param name="callback"></param>
        /// <returns>-1 if person is in game already, 0 some error, 1 if it joined as player1, 2 if it joined as player2</returns>
        int JoinGame(int gameId, int profileId, object callback);

        /// <summary>
        /// Removes player from game, deletes game if there are no players in it
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="profileId"></param>
        /// <returns>-1 some error, 0 if game was deleted, 1 if player1 left, 2 if player2 left</returns>
        int LeaveGame(int gameId, int profileId);

        /// <summary>
        /// Saves players choice and returns result for the round
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="profileId"></param>
        /// <param name="choice"></param>
        /// <returns>-2 player2 needs to make choice, -1 player1 needs to make choice, 0 for tie, 1 for player1, 2 for player2</returns>
        int MakeChoice(int gameId, int profileId, int choice);

        Game FindGame(int gameId);
    }
}
