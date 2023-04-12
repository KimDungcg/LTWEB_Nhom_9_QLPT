using btktr.Models;

namespace btktr.Repository
{
    public class KhoahocRepon : IKhoaHoc
    {
        private readonly MovieWebContext _context;

        public KhoahocRepon(MovieWebContext context)
        {
            _context = context;
        }
        public Khoahoc add(Khoahoc khoahocc)
        {
            _context.Khoahocs.Add(khoahocc);
            _context.SaveChanges();
            return khoahocc;
        }

        

        public Khoahoc delete(string Makhoahocc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Khoahoc> GetAllkhoahoc()
        {
            return _context.Khoahocs;
        }

       

        public Khoahoc GetKhoahoc(string Makhoahocc)
        {
            return _context.Khoahocs.Find(Makhoahocc);
        }

        public Khoahoc update(Khoahoc khoahocc)
        {
            _context.Update(khoahocc);
            _context.SaveChanges();
            return khoahocc;
        }

      
    }
}
