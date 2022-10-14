using System;
using System.Collections.Generic;
using Plugins.MaoUtility.TestModul.Core;
using UltEvents;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.MaoUtility.TestModul.Views
{
    public class ViewTestSelectable : MonoBehaviour
    {
        [SerializeField] private Text _labelName;
        [SerializeField] private Text _labelState;
        [SerializeField] private Text _labelResult;
        [SerializeField] private Button _btnSelect;

        public event Action<ViewTestSelectable> Selectable;
        public event Action<TestContext.LogMes> AddNewLog;
        public event Action LogCleared;

        public UltEvent SelectInView;
        public UltEvent UnselectInView;
        
        public TestContext Test => _test;
        private TestContext _test;

        public IReadOnlyCollection<TestContext.LogMes> Logs => _logs;
        private List<TestContext.LogMes> _logs = new List<TestContext.LogMes>();

        public void Init(TestContext context)
        {
            _test = context;
            _labelName.text = context.NameTest;
            
            _btnSelect.onClick.AddListener(()=>Selectable?.Invoke(this));
            _test.StateChanged += SetState;
            _test.NewResultTest += SetResult;
            _test.Loged += OnLog;
            
            SetState();
            SetResult();
        }

        public void InvokeEventSelect(bool isSelect)
        {
            if(isSelect) SelectInView.Invoke();
            else UnselectInView.Invoke();
        }
        
        private void OnLog(TestContext.LogMes obj)
        {
            _logs.Add(obj);
            AddNewLog?.Invoke(obj);
        }

        private void SetResult()
        {
            _labelResult.text = "R:"+_test.Result.ToString();
            _labelResult.color = TestContext.GetColorResult(_test.Result);
        }

        private void SetState()
        {
            _labelState.text = "S:"+_test.State.ToString();
            _labelState.color = TestContext.GetColorState(_test.State);
        }

        public void ClearLogs()
        {
            _logs.Clear();
            LogCleared?.Invoke();
        }
    }
}