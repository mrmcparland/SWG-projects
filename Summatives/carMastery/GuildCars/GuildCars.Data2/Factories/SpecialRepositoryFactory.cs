using GuildCars.Data2.ADO;
using GuildCars.Data2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data2.Factories
{
    public class SpecialRepositoryFactory
    {
        public static ISpecialsRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new SpecialsRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}
