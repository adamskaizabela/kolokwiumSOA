using Newbay.DTOIZAADA;
using Newbay.ModelsIZAADA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newbay.DALIZAADA.Repositories
{
    public interface IWingRepository : IBaseRepository<WingDB, Wing>
    {

    }

    public class WingRepository : BaseRepository<WingDB, Wing>, IWingRepository
    {
        protected override string ConnectionPath { get { return @"C:\Wings"; } }

        public override Wing FromDBToModel(WingDB dbModel) => dbModel == null ?
           null :
           new Wing() { Id = dbModel.Id, Name = dbModel.Name, Power = dbModel.Power, Shield = dbModel.Shield };

        public override WingDB FromModelToDB(Wing model) => model == null ?
            null :
            new WingDB() { Id = model.Id, Name = model.Name, Power = model.Power, Shield = model.Shield };
    }
}
