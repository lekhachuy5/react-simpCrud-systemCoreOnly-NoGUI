using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeb.Models
{
    public interface IDataAccessProvider
    {
        void AddPatientRecord(Cus patient);
        void UpdatePatientRecord(Cus patient);
        void DeletePatientRecord(long id);
        Cus GetPatientSingleRecord(long id);
        List<Cus> GetPatientRecords();
    }
}
