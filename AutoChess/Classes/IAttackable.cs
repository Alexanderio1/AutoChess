using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChess.Classes
{
    internal interface IAttackable
    {
        void TakeDamage(int damage, string damageType);
    }
}
