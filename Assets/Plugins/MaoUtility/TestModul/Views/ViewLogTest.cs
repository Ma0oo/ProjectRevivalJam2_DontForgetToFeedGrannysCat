using Plugins.MaoUtility.TestModul.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.MaoUtility.TestModul.Views
{
    public class ViewLogTest : MonoBehaviour
    {
        [SerializeField] private Text _label;
        [SerializeField] private Button _btn;
        
        private TestContext.LogMes _mes;

        public void Init(TestContext.LogMes mes)
        {
            _mes = mes;
            _label.text = $"{mes.Data.Hour}:{mes.Data.Minute}:{mes.Data.Second}\n{_mes.Message}";
            _label.color = TestContext.GetColorLog(mes.Type);
            _btn.onClick.AddListener(()=>_mes.Callback());
        }
    }
}