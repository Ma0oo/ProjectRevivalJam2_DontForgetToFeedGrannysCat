using System;
using DataGame;
using DataGame.Keys;
using Plugins.MaoUtility.DILocator.Atr;
using UnityEngine;

namespace Player.Input
{
    [DiMark]
    public class PlayerMoveInput : Plugins.MaoUtility.InputModule.Core.BaseClasses.Input
    {
        public event Action<Vector2> Move;
        public event Action<Vector2> Rotate;
        public event Action Jump;
        public event Action<bool> Crouch;
        public event Action<bool> Run;

        [DiInject] private DataProvider _dataProvider;
        private KeyConfig Keys => _dataProvider.DataSettingCurrent.Keys;
        
        private void Update()
        {
            if(UnityEngine.Input.GetKeyDown(Keys.Jump)) Jump?.Invoke();
            
            Vector2 dirMove = Vector2.zero;
            if ((UnityEngine.Input.GetKey(Keys.Left) && UnityEngine.Input.GetKey(Keys.Right)) || (!UnityEngine.Input.GetKey(Keys.Left) && !UnityEngine.Input.GetKey(Keys.Right))) dirMove.x = 0;
            else if (UnityEngine.Input.GetKey(Keys.Left)) dirMove.x = -1;
            else  dirMove.x = 1;
            
            if ((UnityEngine.Input.GetKey(Keys.Forward) && UnityEngine.Input.GetKey(Keys.Back)) || (!UnityEngine.Input.GetKey(Keys.Forward) && !UnityEngine.Input.GetKey(Keys.Back))) dirMove.y = 0;
            else if (UnityEngine.Input.GetKey(Keys.Forward)) dirMove.y = 1;
            else  dirMove.y = -1;
            
            Move?.Invoke(dirMove.normalized);
            
            Rotate?.Invoke(new Vector2(UnityEngine.Input.GetAxis("Mouse X"), UnityEngine.Input.GetAxis("Mouse Y")*-1));
            
            if(UnityEngine.Input.GetKeyDown(Keys.Crouch)) Crouch?.Invoke(true);
            if(UnityEngine.Input.GetKeyUp(Keys.Crouch)) Crouch?.Invoke(false);

            Run?.Invoke(UnityEngine.Input.GetKey(Keys.Run));
        }
    }
}
