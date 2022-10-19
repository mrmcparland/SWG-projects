 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dvdLibrary.Models.tables;
using dvdLibrary.Models.queries;


namespace dvdLibrary.Data.Interfaces
{
    public interface IdvdRepository
    {
        List<dvdRequest> GetDvds();
        dvdRequest GetbyId(int dvdId);
        dvdRequest GetByTitle(string title);
        dvdRequest GetByDirector(string director);
        List<dvdRequest> GetByRating(string rating);
        void insert(dvdRequest dvd);
        void update(dvdRequest dvd);
        void delete(int dvdId);
        
    }
}
