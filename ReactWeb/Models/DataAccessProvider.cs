using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWeb.Models
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgresqlContext _context;

        public DataAccessProvider(PostgresqlContext context)
        {
            _context = context;
        }

        public void AddPatientRecord(Cus patient)
        {
            _context.Cus.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatientRecord(Cus patient)
        {
            _context.Cus.Update(patient);
            _context.SaveChanges();
        }

        public void DeletePatientRecord(long id)
        {
            var entity = _context.Cus.FirstOrDefault(t => t.Id == id);
            _context.Cus.Remove(entity);
            _context.SaveChanges();
        }

        public Cus GetPatientSingleRecord(long id)
        {
            return _context.Cus.FirstOrDefault(t => t.Id == id);
        }

        public List<Cus> GetPatientRecords()
        {
            return _context.Cus.ToList();
        }
    }
}
