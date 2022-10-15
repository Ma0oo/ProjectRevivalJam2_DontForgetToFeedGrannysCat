using System.Linq;
using Plugins.MaoUtility.DataManagers;
using Sirenix.OdinInspector;

namespace DefaultNamespace.ApartmentSystem
{
    public class RoomPartManager : DataManagerMonoBehByIntrerface<IRoomPart>
    {
        [Button]private void FindAll() => Monos = GetComponentsInChildren<IRoomPart>().ToList();
    }
}