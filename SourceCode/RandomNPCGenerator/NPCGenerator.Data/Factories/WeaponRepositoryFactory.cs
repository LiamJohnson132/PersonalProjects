using NPCGenerator.Data.Equipment;
using NPCGenerator.Data.Interfaces;
using RandomNPCGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCGenerator.Data.Factories
{
    public static class WeaponRepositoryFactory
    {
        public static IWeaponRepository GetRepository(RaceSize size)
        {
            if (size == RaceSize.Small)
            {
                return new WeaponSmallRepository();
            }
            else //if (size == RaceSize.Medium) //uncomment when Large implemented
            {
                return new WeaponMediumRepository();
            };
        }
    }
}
