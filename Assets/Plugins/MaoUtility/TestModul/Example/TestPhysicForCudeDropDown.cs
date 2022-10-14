using Plugins.MaoUtility.TestModul.Core;
using UltEvents;
using UnityEngine;

namespace Plugins.MaoUtility.TestModul.Example
{
    public class TestPhysicForCudeDropDown : TestContext
    {
        [SerializeField] private Transform _startPosition;
        [SerializeField] private Rigidbody _cube;
        [SerializeField] private TriggerEvents3D _trigger;

        public override string NameTest => "Проверка физики для кубика";
        public override string Description => "Куб за N времени должен успеть долететь до пола, чтобы пройти тест";

        protected override void OnAwake() => SetCube();

        protected override bool Arrange()
        {
            _trigger.TriggerEnterEvent.DynamicCalls -= OnEnter;
            _trigger.TriggerEnterEvent.DynamicCalls += OnEnter;
            SetCube();
            return true;
        }

        protected override void StartTest()
        {
            _cube.isKinematic = false;
        }

        protected override void StopAndClear()
        {
            SetCube();
            _trigger.TriggerEnterEvent.DynamicCalls -= OnEnter;
            ChangeState(StateTest.NoneStart);
        }

        private void OnEnter(Collider obj)
        {
            Log(new LogMes("Куб упал").SetCallback(LogConsole).SetType(LogType.Info));
            Log(new LogMes("Тест пройден").SetCallback(LogConsole).SetType(LogType.Good));
            ChangeResult(ResultTest.Complete);
            ChangeState(StateTest.Complete);
        }

        private void LogConsole() => Debug.Log("Да, на меня можно кликать");

        private void SetCube()
        {
            _cube.transform.position = _startPosition.position;
            _cube.transform.rotation = _startPosition.rotation;
            _cube.isKinematic = true;
        }
    }
}