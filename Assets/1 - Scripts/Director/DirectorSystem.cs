using System.Collections.Generic;
using System.Linq;
using DataGame.Keys;
using DefaultNamespace.ApartmentSystem;
using DefaultNamespace.Cat;
using DefaultNamespace.PropSystem;
using DoorSystem;
using NoSystem;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.Utilities;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.Director
{
    [DiMark]
    public class DirectorSystem : MonoBehaviour
    {
        [DiInject] private PropFactory _propFactory;
        [DiInject] private ApartmentFactory _apartmentFactory;

        [SerializeField] private AudioSource _source;

        public Room[] GetRoomByMark(RoomMark[] marks)
        {
            return _apartmentFactory.App.Rooms.Where(x =>
            {
                var conainer = x.RoomParts.Get<RoomMarkContainer>();
                if (!conainer) return false;
                foreach (var roomMark in marks)
                    if (conainer.Contains(roomMark))
                        return true;
                return false;
            }).ToArray();
        }
        
        public Room GetRandomRoom() => _apartmentFactory.App.Rooms.GetRandom();

        public CatPoint[] GetCatPoint(CatPointMark[] marks)
        {
            var points = _apartmentFactory.App.GetAllRoomPart<CatPoint>();
            return points.Where(x =>
            {
                foreach (var mark in marks)
                    if (x.Marks.Contains(mark))
                        return true;
                return false;
            }).ToArray();
        }
        
        public CatPoint[] GetCatPointRoom(Room room)
        {
            var points = room.RoomParts.GetAll<CatPoint>();
            return points.Where(x =>
            {
                foreach (var mark in x.Marks)
                    if (x.Marks.Contains(mark))
                        return true;
                return false;
            }).ToArray();
        }
        
        public PropPoint GetRandomPropPoint(IEnumerable<PropPoint> points)=>points.GetRandom();
        
        public PropPoint[] GetPropPointsByMark(PropPointMark[] marks)
        {
            var points = _apartmentFactory.App.GetAllRoomPart<PropPoint>();
            return points.Where(x =>
            {
                foreach (var mark in marks)
                    if (x.Marks.Contains(mark))
                        return true;
                return false;
            }).ToArray();
        }
        
        public PropPoint[] GetPropPointsByMark(PropPointMark[] marks, Room rooms)
        {
            var points = rooms.RoomParts.GetAll<PropPoint>();
            return points.Where(x =>
            {
                foreach (var mark in marks)
                    if (x.Marks.Contains(mark))
                        return true;
                return false;
            }).ToArray();
        }
        
        // Events

        public void PlaySound(AudioClip clip, PropPoint point) => PlaySound(_source.Spawn(point.transform.position), clip);
        
        public void PlaySound(AudioSource source, AudioClip clip, PropPoint point) => PlaySound(source.Spawn(point.transform.position), clip);

        private void PlaySound(AudioSource source, AudioClip clip)
        {
            source.clip = clip;
            source.Play();
            CoroutineGame.Instance.Wait(clip.length, source.gameObject.DeleteGO);
        }

        public void MoveCat(CatUnit cat, CatPoint point) => cat.Parts.Get<CatMover>()?.Move(point);

        public void SetDoorBlock(Room room, bool isActive) => room.RoomParts.GetAll<Door>().ForEach(x => x.SetBlock(isActive));

        public void SetLightColor(Room room, Color color) => room.RoomParts.GetAll<RoomLight>().ForEach(x => x.SetColor(color));

        public void SetLightDefaultColor(Room room) => room.RoomParts.GetAll<RoomLight>().ForEach(x => x.ZeroColor());

        public void SetLightIntencityByNorman(Room room, float normal) => room.RoomParts.GetAll<RoomLight>().ForEach(x => x.SetNormalIntensity(normal));

        public Prop SpawnProp(Prop prop, PropPoint point) => _propFactory.Create(prop, point);

        public Prop SpawnPropRoom(Prop prop, Room room) => _propFactory.CreateInRandomPlaceRoom(prop, room);
        
        public Prop SpawnPropApp(Prop prop) => _propFactory.CreateInRandomPlaceApp(prop);
    }
}