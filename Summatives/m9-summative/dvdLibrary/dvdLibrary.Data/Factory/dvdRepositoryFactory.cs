using dvdLibrary.Data.ADO;
using dvdLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdLibrary.Data.Factory
{
    public static class dvdRepositoryFactory
    {
        public static IdvdRepository GetRepository()
        {
            switch(Settings.GetRepositoryType())
            {
                case "ADO":
                    return new dvdRepositoryADO();

                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
