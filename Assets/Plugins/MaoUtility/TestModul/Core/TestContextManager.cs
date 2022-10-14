using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Plugins.MaoUtility.TestModul.Core
{
    public class TestContextManager : MonoBehaviour
    {
        public IReadOnlyCollection<TestContext> Testes => _tests;
        [SerializeField] private TestContext[] _tests;

        public void StartAll() => Testes.ForEach(x =>
        {
            x.EasyStopAndClear();
            x.EaseStartTest();
        });
        
        public void ArrangeAll() => Testes.ForEach(x =>
        {
            x.EasyStopAndClear();
            x.EastArrange();
        });
        
        public void StopAll() => Testes.ForEach(x => x.EasyStopAndClear());

        [Button] private void OnValidate() => _tests = FindObjectsOfType<TestContext>();
    }
}