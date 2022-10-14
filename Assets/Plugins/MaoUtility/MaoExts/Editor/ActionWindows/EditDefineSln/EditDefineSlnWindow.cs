using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.MaoUtility.MaoExts.Editor.ActionWindows.EditDefineSln
{
    public class EditDefineSlnWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset DefineElement;
        [SerializeField] private VisualTreeAsset Main;

        // HasAssets_ODIN
        // HasAssets_LeanTransition
        // HasAssets_UltEvents
        // HasAssets_Animacer
        // HasAssets_DoTween
        private const string OdinDef = "HasAssets_ODIN";
        private const string LeanDef = "HasAssets_LeanTransition";
        private const string UltEventsDef = "HasAssets_UltEvents";
        private const string AnimacerDef = "HasAssets_Animacer";
        private const string DoTweenDef = "HasAssets_DoTween";
        
        private List<string> DefinesList => new List<string>(){OdinDef, LeanDef, UltEventsDef, AnimacerDef, DoTweenDef};

        private List<CodeDefine> _defines;
        private static BuildTargetGroup _buildTarget = BuildTargetGroup.Standalone;
        
        [MenuItem("Mao Tools/Change Define Sln")]
        private static void ShowWindow()
        {
            var window = GetWindow<EditDefineSlnWindow>();
            window.titleContent = new GUIContent("Setting Define");
            window.Show();
            window.maxSize = new Vector2(470, 260);
            window.position.Set(window.position.x, window.position.y, 455, 244);
        }
        
        public void CreateGUI()
        {
            _defines = new List<CodeDefine>();
            var main = Main.Instantiate();
            main.Q<Button>("Refresh_Btn").clicked += () => _defines.ForEach(x => x.UpdateView(GetDefineFromSetting()));
            main.Q<Button>("Applay_Btn").clicked += () =>
            {
                var strs = GetDefineFromSetting();
                _defines.ForEach(x=>strs=x.Change(strs));
                PlayerSettings.SetScriptingDefineSymbolsForGroup(_buildTarget, strs);
                _defines.ForEach(x=>x.UpdateView(GetDefineFromSetting()));
            };
            var enumF = main.Q<EnumField>("EnumTargetGroup");
            enumF.Init(_buildTarget);
            enumF.RegisterCallback<ChangeEvent<Enum>>(x=>_buildTarget =  (BuildTargetGroup)x.newValue);

            rootVisualElement.Add(main);
            DefinesList.ForEach(x =>
            {
                var newDefine = new CodeDefine(x, DefineElement.Instantiate());
                newDefine.Updated += () => newDefine.UpdateView(GetDefineFromSetting());
                newDefine.UpdateView(GetDefineFromSetting());
                _defines.Add(newDefine);
                rootVisualElement.Add(newDefine);
            });
        }

        private string[] GetDefineFromSetting()
        {
            PlayerSettings.GetScriptingDefineSymbolsForGroup(_buildTarget, out var r);
            return r;
        }

        private class CodeDefine : VisualElement
       {
           private Button _btn;
           private Label _changeLabel;
           private bool _isChange;
           private string _define;

           public event Action Updated;

           public CodeDefine(string define, VisualElement defineTree)
           {
               defineTree.Q<Label>("DefineName").text = define;
               _define = define;
               _btn = defineTree.Q<Button>("Change_Btn");
               _changeLabel = defineTree.Q<Label>("Change_Label");
               _btn.clicked += () =>
               {
                   _isChange = !_isChange;
                   Updated.Invoke();
               };
               Add(defineTree);
           }

           public string[] Change(string[] defines)
           {
               if (_isChange == false) return defines;
               _isChange = false;
               if (defines.Contains(_define)) return defines.Except(new[] {_define}).ToArray();
               else return defines.Append(_define).ToArray();
           }
           
           public void UpdateView(string[] currentDefine)
           {
               if (currentDefine.Contains(_define))
               {
                   _btn.text = "Is On";
                   _btn.style.backgroundColor = new Color(0.31f, 0.89f, 0.11f);
               }
               else
               {
                   _btn.text = "Is Off";
                   _btn.style.backgroundColor = new Color(0.89f, 0.07f, 0.09f);
               }
               if (_isChange)
               {
                   _changeLabel.text = "To Change";
               }
               else
               {
                   _changeLabel.text = "";
               }
           }
       }
    }
}