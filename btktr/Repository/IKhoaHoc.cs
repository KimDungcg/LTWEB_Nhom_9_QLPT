using btktr.Models;

namespace btktr.Repository
{
    public interface IKhoaHoc
    {
       
       
            Khoahoc add(Khoahoc khoahocc);

            Khoahoc update(Khoahoc khoahocc);

            Khoahoc delete(string Makhoahocc);

            Khoahoc GetKhoahoc(string Makhoahocc);

            IEnumerable<Khoahoc> GetAllkhoahoc();


        }
    

}