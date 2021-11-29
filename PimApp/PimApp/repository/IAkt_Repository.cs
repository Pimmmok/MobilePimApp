using System.Collections.Generic;

namespace PimApp
{
    interface IAkt_Repository
    {
        List<Akt> GetList();

        Akt Get(int id);

        List<Akt> GetByNameOrg(string name);

        int Delete(int id);

        int Save(Akt entity);
    }
}
