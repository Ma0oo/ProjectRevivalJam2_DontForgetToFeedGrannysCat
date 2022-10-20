using System.Linq;
using DefaultNamespace.Cat.InitData;
using DefaultNamespace.ScenesLogic.Game;
using DefaultNamespace.ScenesLogic.Game.GameLose;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.MonoBehsGameHelper.ValueContainers;
using Plugins.MaoUtility.SceneFlow;
using UnityEngine;

namespace DefaultNamespace.Cat.HungerSystem
{
    [DiMark]
    public class CatHunger : MonoBehaviour, IHungerControl, ICatPart, IInitGameDataCat
    {
        public IValueContainer<float> Stat => _valueContainer;
        [SerializeField] private FloatValueContainer _valueContainer;
        [SerializeField] private DataHunger _dataHunger;
        [SerializeField] private LoseGameComponent _loseGameComponent;
        private GameTime _time;

        [DiInject]private void Init(OwnerSceneLogic ownerSceneLogic) => _time = ownerSceneLogic.Get<GameTime>();

        private void Start()
        {
            _valueContainer.SetMin(()=>0);
            _valueContainer.SetMax(()=>_dataHunger.CountFeed);
            _valueContainer.Current = _dataHunger.CountFeed;
        }

        private void Update()
        {
            _valueContainer.Current -= Time.deltaTime * _dataHunger.SpeedDownInSecond * (_time.enabled ? 1 : 0);
            if (_valueContainer.Current <= _valueContainer.Min)
            {
                _loseGameComponent.Lose();
                enabled = false;
            }
        }

        [System.Serializable]
        public class DataHunger : InitCatGameData
        {
            [Min(0)] public float CountFeed;
            public float SpeedDownInSecond;
        }

        public void Init(InitCatGameData[] datas)
        {
            var r =datas.FirstOrDefault(x => x is DataHunger) as DataHunger;
            if(r==null) return;
            _dataHunger = r;
            Start();
        }
    }
}