using System.Collections.Generic;
using Plugins.MaoUtility.DILocator.Atr;
using Plugins.MaoUtility.InputModule.AutoSub;
using Plugins.MaoUtility.InputModule.Core;
using Plugins.MaoUtility.MaoExts.Static;
using Plugins.MaoUtility.TestModul.Core;
using Plugins.MaoUtility.TestModul.Ext;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.MaoUtility.TestModul.Views
{
    [DiMark]
    public class ViewTestContextManager : MonoBehaviour
    {
        [Header("Btns")]
        [SerializeField] private Button _btnStart;
        [SerializeField] private Button _btnStop;
        [SerializeField] private Button _btnArrange;
        
        [SerializeField] private Button _btnStartAll;
        [SerializeField] private Button _btnStopAll;
        [SerializeField] private Button _btnArrangeAll;
        [SerializeField] private Button _btnClearConsole;
        
        [Header("Points")]
        [SerializeField] private Transform _pointBtns;
        [SerializeField] private Transform _pointLogs;
        [SerializeField] private Text _labelDescription;

        [Header("View")]
        [SerializeField] private ViewLogTest _logPrefab;
        [SerializeField] private ViewTestSelectable _viewPrefab;

        [DiInject] private TestContextManager _testContext;
        [DiInject] private InputManager _inputManager;

        private ViewTestSelectable _current;
        private List<ViewTestSelectable> _all = new List<ViewTestSelectable>();
        
        private List<ViewLogTest> _logs = new List<ViewLogTest>();

        private void Start()
        {
            _btnStartAll.onClick.AddListener(()=>_testContext.StartAll());
            _btnStopAll.onClick.AddListener(()=>_testContext.StopAll());
            _btnStart.onClick.AddListener(()=>_current?.Test.EaseStartTest());
            _btnStop.onClick.AddListener(()=>_current?.Test.EasyStopAndClear());
            _btnArrange.onClick.AddListener(()=>_current?.Test.EastArrange());
            _btnArrangeAll.onClick.AddListener(()=>_testContext.ArrangeAll());
            _btnClearConsole.onClick.AddListener(()=>_current?.ClearLogs());
            _testContext.Testes.ForEach(SpawnView);
            _labelDescription.text = "No select test";

            new SubInputClass<InputOfTest>(RegInput, UnregInput, _inputManager).SubscribeAction(true);
        }

        private void RegInput(InputOfTest obj) => obj.ChangeState += OnChangeState;

        private void OnChangeState() => gameObject.SetActive(!gameObject.activeSelf);

        private void UnregInput(InputOfTest obj) => obj.ChangeState -= OnChangeState;

        private void SpawnView(TestContext obj)
        {
            _all.Add(_viewPrefab
                .Spawn(_pointBtns)
                .With(x => x.Init(obj))
                .With(x=>x.Selectable+=OnSelect)
                .With(x=>x.LogCleared+=SpawnNewLog));
        }

        private void OnSelect(ViewTestSelectable obj)
        {
            if (_current)
            {
                _current.AddNewLog -= OnNewLog;
                _logs.ForEach(x => x.DeleteGO());
                _logs.Clear();
                _current.InvokeEventSelect(false);
            }
            _current = obj;
            if (_current)
            {
                _current.AddNewLog += OnNewLog;
                _current.Logs.ForEach(OnNewLog);
                _labelDescription.text = _current.Test.Description;
                _current.Test.SetCamera();
                _current.InvokeEventSelect(true);
            }
        }

        private void SpawnNewLog()
        {
            _logs.ForEach(x => x.DeleteGO());
            _logs.Clear();
            _current?.Logs.ForEach(OnNewLog);
        }
        
        private void OnNewLog(TestContext.LogMes obj) => _logs.Add(_logPrefab.Spawn(_pointLogs).With(x=>x.Init(obj)));
    }
}