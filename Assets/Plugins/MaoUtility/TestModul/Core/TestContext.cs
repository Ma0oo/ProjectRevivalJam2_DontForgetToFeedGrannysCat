using System;
using Plugins.MaoUtility.MaoExts.Static;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.MaoUtility.TestModul.Core
{
    public abstract class TestContext : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _timeToCheck;
        [SerializeField] private Transform _pointCamera;

        public virtual string NameTest => GetType().Name;

        public abstract string Description { get; }

        public StateTest State => _state;
        private StateTest _state;
        
        public ResultTest Result => _result;
        private ResultTest _result = ResultTest.NotStart;
        
        public event Action<LogMes> Loged;
        public event Action StateChanged;
        public event Action NewResultTest;

        private void Awake()
        {
            _state = StateTest.NoneStart;
            OnAwake();
        }

        protected abstract void OnAwake();
        
        public void EaseStartTest()
        {
            if (_state == StateTest.InProgress)
            {
                Log(new LogMes("Тест уже запущен").SetType(LogType.System));
                return;
            }

            var arrangeResult = Arrange();
            if (!arrangeResult)
            {
                Log(new LogMes("Подготовка прошла с ошибкой").SetType(LogType.Error));
                return;
            }
            
            ChangeState(StateTest.InProgress);
            ChangeResult(ResultTest.InProgress);
            StartTest();
            
            CoroutineGame.Instance.Wait(_timeToCheck,
                () =>
                {
                    if (_state == StateTest.InProgress)
                    {
                        Log(new LogMes($"Тест не был завершен за {_timeToCheck} " +
                                       $"секунд, возможно ошибка").SetType(LogType.Waring));
                        EasyStopAndClear();
                    }
                });
        }

        protected abstract void StartTest();

        public void EasyStopAndClear()
        {
            if(_state!=StateTest.InProgress) return;
            ChangeState(StateTest.NoneStart);
            ChangeResult(ResultTest.Abort);
            StopAndClear();
        }

        public bool EastArrange()
        {
            ChangeResult(ResultTest.NotStart);
            ChangeState(StateTest.NoneStart);
            return Arrange();
        }
        
        protected abstract bool Arrange();

        protected abstract void StopAndClear();

        public void SetCamera() => SetCamera(Camera.main);
        
        [Button]
        private void SetCamera(Camera camera)
        {
            camera.transform.position = _pointCamera.transform.position;
            camera.transform.eulerAngles = _pointCamera.transform.eulerAngles;
        }

        protected void Log(LogMes logMes) => Loged?.Invoke(logMes);
        
        protected void ChangeState(StateTest state)
        {
            var pre = _state;
            _state = state;
            Log(new LogMes($"Состояние сеста изменено с {pre} на {_state}").SetType(LogType.System));
            StateChanged?.Invoke();
        }

        protected void ChangeResult(ResultTest result)
        {
            var pre = _result;
            _result = result;
            Log(new LogMes($"Рузльтат теста изменено с {pre} на {_state}").SetType(LogType.System));
            NewResultTest?.Invoke();
        }

        public class LogMes
        {
            public LogType Type { get; private set; }
            public string Message { get; private set; }
            public DateTime Data { get; private set; }

            public Action Callback => _callbalk ??= new Action(() => { });
            private Action _callbalk;
            
            public LogMes(string mes)
            {
                Message = mes;
                Type = LogType.Info;
                Data = DateTime.Now;
                _callbalk = null;
            }

            public LogMes SetType(LogType t) => Fluid(()=>Type = t);
            
            public LogMes SetCallback(Action t) => Fluid(()=>_callbalk = t);
            
            private LogMes Fluid(Action call)
            {
                call();
                return this;
            }
        }

        public static Color GetColorLog(LogType result)
        {
            switch (result)
            {
                case LogType.Info: return Color.white;
                case LogType.Good: return Color.green; 
                case LogType.Waring: return Color.yellow; 
                case LogType.Error: return Color.red;
                case LogType.System: return new Color(0.19f, 0.19f, 0.19f);
            }
            return Color.black;
        }

        public static Color GetColorResult(ResultTest result)
        {
            switch (result)
            {
                case ResultTest.Error: return Color.red;
                case ResultTest.Complete: return Color.green;
                case ResultTest.InProgress: return Color.yellow;
                case ResultTest.Abort: return new Color(0.4f, 0f, 0f);
                case ResultTest.NotStart: return Color.gray;
                
            }
            return Color.black;
        }
        
        public static Color GetColorState(StateTest result)
        {
            switch (result)
            {
                case StateTest.NoneStart: return new Color(0.32f, 0.32f, 0.32f);
                case StateTest.InProgress: return Color.yellow;
                case StateTest.Complete: return Color.green;
            }
            return Color.black;
        }
        
        public enum StateTest
        {
            NoneStart, InProgress, Complete
        }
        
        public enum ResultTest
        {
            Error, Complete, InProgress, Abort, NotStart
        }

        public enum LogType
        {
            Info, Good, Waring, Error, System
        }
    }
}