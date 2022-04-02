using General;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoManager<Player, PlayerManager>
    {
        public override void Init()
        {
            obj = Object.FindObjectOfType<Player>();
            base.Init();
        }

        public int GetSpecificItemCount(ObjectType type)
        {
            return obj.Inventory.GetCountSpecificItem(type);
        }
    }
}
