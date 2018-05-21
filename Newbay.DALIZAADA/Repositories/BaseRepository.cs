using LiteDB;
using Newbay.DTOIZAADA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newbay.DALIZAADA.Repositories
{
    public interface IBaseRepository<DBModel, ServiceModel>
           where DBModel : IObjWithId
           where ServiceModel : class
    {
        ServiceModel GetById(int id);

        List<ServiceModel> GetAll();

        int Create(ServiceModel model);

        void Update(ServiceModel model);

        void Delete(int id);

        DBModel FromModelToDB(ServiceModel model);

        ServiceModel FromDBToModel(DBModel dbModel);
    }

    public abstract class BaseRepository<DBModel, ServiceModel> : IBaseRepository<DBModel, ServiceModel>
        where DBModel : IObjWithId
        where ServiceModel : class
    {
        protected abstract string ConnectionPath { get; }

   

        public ServiceModel GetById(int id) => MakeOperation((db, rep) => FromDBToModel(rep.FindById(id)));

        public List<ServiceModel> GetAll() => MakeOperation((db, rep) => rep.FindAll().Select(FromDBToModel).ToList());

        public int Create(ServiceModel model)
        {
            return MakeOperation((db, rep) =>
            {
                var dbObject = FromModelToDB(model);
                rep.Insert(dbObject);
                return dbObject.Id;
            });
        }

        public void Update(ServiceModel model) => MakeOperation((db, rep) => rep.Update(FromModelToDB(model)));

        public void Delete(int id) => MakeOperation((db, rep) => rep.Delete(id));

        public abstract ServiceModel FromDBToModel(DBModel dbModel);

        public abstract DBModel FromModelToDB(ServiceModel model);

    


        protected virtual void MakeOperation(Action<LiteDatabase, LiteCollection<DBModel>> action)
        {
            using (var db = new LiteDatabase(ConnectionPath))
            {
                var repository = db.GetCollection<DBModel>();
                action(db, repository);
            }
        }

        protected virtual TResult MakeOperation<TResult>(Func<LiteDatabase, LiteCollection<DBModel>, TResult> func)
        {
            using (var db = new LiteDatabase(ConnectionPath))
            {
                var repository = db.GetCollection<DBModel>();
                return func(db, repository);
            }
        }

    }
}
