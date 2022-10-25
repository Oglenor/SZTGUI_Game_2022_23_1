using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IGameRepository
    {
        //Persist State
        void StoreGameModel(IGameModel gameModel);

        //Load State
        IGameModel GetModel(string fileName);
        IGameModel GetLastState();
        IEnumerable<IGameModel> GetAll();
    }
}
