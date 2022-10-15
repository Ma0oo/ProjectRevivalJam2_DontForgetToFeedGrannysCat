using DefaultNamespace.ApartmentSystem;
using Player.Controlls;
using UnityEngine;

namespace DefaultNamespace.Player
{
    public class PlayerSpawnPoint : MonoBehaviour, IRoomPart
    {
        public void Set(PlayerUnit unit)
        {
            var rot = transform.eulerAngles;
            rot.x = rot.z = 0;
            unit.Parts.Get<CameraPlayerController>().enabled = false;
            unit.transform.eulerAngles = rot;
            unit.transform.position = transform.position;
            unit.Parts.Get<CameraPlayerController>().enabled = true;
        }
    }
}