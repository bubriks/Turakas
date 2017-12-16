using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataTier;

namespace WcfService
{
    [ServiceContract(CallbackContract = typeof(IGameCallBack))]
    public interface IGameService
    {
        [OperationContract(IsOneWay = true)]
        void JoinGame(int gameId, int profileId);

        [OperationContract(IsOneWay = true)]
        void LeaveGame(int gameId, int profileId);

        [OperationContract(IsOneWay = true)]
        void MakeChoice(int gameId, int profileId, int choice);

    }

    public interface IGameCallBack
    {
        [OperationContract(IsOneWay = true)]
        void PlayerJoins(int id, string name);

        [OperationContract(IsOneWay = true)]
        void PlayerLeaves();

        [OperationContract(IsOneWay = true)]
        void Result(int result);

        [OperationContract(IsOneWay = true)]
        void Show(bool result);
    }
}
