using System;
using FlowCanvas;
using Plugins.MaoUtility.LuaScript;
using Plugins.MaoUtility.SceneFlow;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.ScenesLogic.Game
{
    public class NightControl : SceneLogic
    {
        [SerializeField] private FlowScriptController _controller;

        public void Init(FlowScript flowScript) => _controller.StartBehaviour(flowScript);

        public void OnInited() => _controller.CallFunction("OnInited");
    }
}