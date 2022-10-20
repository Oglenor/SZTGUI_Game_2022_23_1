using Core.Interfaces;
using System.Collections.Generic;

namespace Repository
{
    public interface IGameRepository
    {
        //Persist State
        void StoreGameModel(IGameModel gameModel);

        //Load State
        IGameModel GetModel(string path);
        IGameModel GetLastState();
        IEnumerable<IGameModel> GetAll();
    }
}