using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using dvdLibrary.Data.ADO;
using dvdLibrary.Models.tables;
using System.Data.SqlClient;
using System.Configuration;
using dvdLibrary.Data.Interfaces;
using dvdLibrary.Models.queries;

namespace dvdLibrary.Tests.integrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "dbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        [Test]
        public void canLoadDVDs()
        {
            var repo = new dvdRepositoryADO();

            var dvds = repo.GetDvds();

            Assert.AreEqual(5, dvds.Count);

            Assert.AreEqual("Bladerunner 2049", dvds[0].dvdTitle);

            Assert.AreEqual("Denis Villanueve", dvds[0].dvdDirector);
        }
        [Test]
        public void canLoadDvd()
        {
            var repo = new dvdRepositoryADO();
            var dvd = repo.GetbyId(1);

            Assert.IsNotNull(dvd);

            Assert.AreEqual(1, dvd.dvdId);

            Assert.AreEqual("Bladerunner 2049", dvd.dvdTitle);
            Assert.AreEqual("Denis Villanueve", dvd.dvdDirector);
            Assert.AreEqual("R", dvd.dvdRating);
            Assert.AreEqual(2017, dvd.dvdReleaseYear);
            Assert.AreEqual("more human than too human", dvd.notes);
        }
        [Test]
        public void NotFoundDvdReturnsNull()
        {
            var repo = new dvdRepositoryADO();
            var dvd = repo.GetbyId(100000);

            Assert.IsNull(dvd);
        }
        [Test]
        public void CanAddDvd()
        {
            dvdRequest dvdToAdd = new dvdRequest();
            var repo = new dvdRepositoryADO();

            dvdToAdd.dvdTitle = "Batman Begins";
            dvdToAdd.dvdDirector = "Christopher Nolan";
            dvdToAdd.dvdRating = "G";
            dvdToAdd.dvdReleaseYear = 2005;
            dvdToAdd.notes = "Katie Holmes > Maggie G.";

            repo.insert(dvdToAdd);
            Assert.AreEqual(6, dvdToAdd.dvdId);
        }
        [Test]
        public void CanUpdateDvd()
        {
            dvdRequest dvdToAdd = new dvdRequest();
            var repo = new dvdRepositoryADO();

            dvdToAdd.dvdTitle = "Batman Begins";
            dvdToAdd.dvdDirector = "Christopher Nolan";
            dvdToAdd.dvdRating = "G";
            dvdToAdd.dvdReleaseYear = 2005;
            dvdToAdd.notes = "Katie Holmes > Maggie G.";

            repo.insert(dvdToAdd);
            
            dvdToAdd.dvdTitle = "The Dark Knight";
            dvdToAdd.dvdDirector = "David Lynch";
            dvdToAdd.dvdRating = "R";
            dvdToAdd.dvdReleaseYear = 2008;
            dvdToAdd.notes = "The one with the clown";

            repo.update(dvdToAdd);

            var updatedDvd = repo.GetbyId(6);

            Assert.AreEqual("The Dark Knight", updatedDvd.dvdTitle);
            Assert.AreEqual("David Lynch", updatedDvd.dvdDirector);
            Assert.AreEqual("R",updatedDvd.dvdRating);
            Assert.AreEqual(2008,updatedDvd.dvdReleaseYear);
            Assert.AreEqual("The one with the clown", updatedDvd.notes);
        }
        [Test]
        public void canDeleteDvd()
        {
            dvdRequest dvdToAdd = new dvdRequest();
            var repo = new dvdRepositoryADO();

            dvdToAdd.dvdTitle = "Batman Begins";
            dvdToAdd.dvdDirector = "Christopher Nolan";
            dvdToAdd.dvdRating = "G";
            dvdToAdd.dvdReleaseYear = 2005;
            dvdToAdd.notes = "Katie Holmes > Maggie G.";

            repo.insert(dvdToAdd);

            var loaded = repo.GetbyId(6);
            Assert.IsNotNull(loaded);

            repo.delete(6);
            loaded= repo.GetbyId(6);

            Assert.IsNull(loaded);
        }
    }
}
