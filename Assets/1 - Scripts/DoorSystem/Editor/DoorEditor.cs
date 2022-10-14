using Plugins.MaoUtility.MaoExts.Editor;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace DoorSystem.Editor
{
    [CustomEditor(typeof(DoorEdit))]
    public class DoorEditor : UnityEditor.Editor
    {
        private DoorEdit _target;
        private Door[] _doors=new Door[0];

        private void OnEnable()
        {
            _target = (DoorEdit)target;
            DoorConfig.ShowAllwaysGizmos = true;
            FindAllDoors();
        }

        private void OnDisable()
        {
            DoorConfig.ShowAllwaysGizmos = false;
        }

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Update list all doors")) FindAllDoors();
        }

        private void FindAllDoors()
        {
            var stage = StageUtility.GetCurrentStage() as PrefabStage;
            if (stage) _doors = stage.prefabContentsRoot.GetComponentsInChildren<Door>();
            else _doors = FindObjectsOfType<Door>();
        }

        private void OnSceneGUI()
        {
            var config = DoorConfig.Instance;
            for (var i = 0; i < _doors.Length; i++)
            {
                if (_doors[i] == null)
                {
                    FindAllDoors();
                    break;
                }

                if (_doors[i] != _target.Door)
                {
                    MaoExtEditor.Button3D(_doors[i].transform.position,
                        Handles.SphereHandleCap, 
                        config.ColorSelect, 
                        config.SizeSelect,
                        () =>
                        {
                            Selection.activeObject = _doors[i];
                        });
                }
                if (_doors[i] != _target.Door && _doors[i] != _target.Door.ConnectDoor)
                {
                    MaoExtEditor.Button3D(_doors[i].transform.position+Vector3.up*config.HHandler, 
                        Handles.CubeHandleCap, 
                        config.ColorEditorBtnConnect, 
                        config.SizeEditBtn, 
                        () =>
                        {
                            var otherDoor = _doors[i];
                            _target.Door.Connect(otherDoor);
                            EditorUtility.SetDirty(_target.Door);
                            EditorUtility.SetDirty(otherDoor);
                        });
                }
                else if(_doors[i] == _target.Door.ConnectDoor)
                {
                    MaoExtEditor.Button3D(_doors[i].transform.position+Vector3.up*config.HHandler,
                        Handles.CubeHandleCap,
                        config.ColorEditorBtnDisconnect,
                        config.SizeEditBtn,
                        () =>
                        {
                            var preConnect = _target.Door.ConnectDoor;
                            _target.Door.Disconect();
                            EditorUtility.SetDirty(_target.Door);
                            EditorUtility.SetDirty(preConnect);
                        });
                }
            }
        }
    }
}