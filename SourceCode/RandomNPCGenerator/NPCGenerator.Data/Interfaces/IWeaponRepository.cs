using RandomNPCGenerator.Models.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCGenerator.Data.Interfaces
{
    public interface IWeaponRepository
    {
        List<WeaponBase> GetAll();
        WeaponBase GetById(int param);
    }
}
