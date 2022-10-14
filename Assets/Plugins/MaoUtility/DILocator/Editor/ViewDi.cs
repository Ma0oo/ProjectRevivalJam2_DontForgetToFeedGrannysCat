using System;
using System.Collections.Generic;
using System.Linq;
using Plugins.MaoUtility.DILocator.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Plugins.MaoUtility.DILocator.Editor
{
    public class ViewDi : EditorWindow
    {
        [SerializeField] private VisualTreeAsset MainWindow;
        [SerializeField] private VisualTreeAsset Border;
        [SerializeField] private VisualTreeAsset HeaderDi;
        [SerializeField] private VisualTreeAsset TypeName;
        
        [MenuItem("Mao Tools/View Di")]
        private static void ShowWindow()
        {
            if (!Application.isPlaying)
            {
                Debug.Log("View Di может быть открыт только в игре");
                return;
            }
            
            var window = GetWindow<ViewDi>();
            window.titleContent = new GUIContent("Di List");
            window.Show();
            window.maxSize = new Vector2(480, 600);
            var windowPosition = window.position;
            windowPosition.size = new Vector2(465, 575);
            windowPosition.position = new Vector2(200, 100);
            window.position = windowPosition;
        }

        public void CreateGUI()
        {
            var main = MainWindow.Instantiate();
            main.Q<Button>("RefreshBtn").clicked += () => InitMain(main);
            InitMain(main);
            rootVisualElement.Add(main);
        }

        private VisualElement InitMain(TemplateContainer main)
        {
            var contentMain = main.Q<ScrollView>("ContentScrool").contentContainer;
            contentMain.hierarchy.Clear();

            var dis = GetAllDI(DI.Instance);
            foreach (var dataDi in dis)
            {
                contentMain.Add(CreateHeaderDi(dataDi));
                contentMain.Add(Border.Instantiate());
            }

            return main;
        }

        private VisualElement CreateHeaderDi(DataDi dataDi)
        {
            var header = HeaderDi.Instantiate();
            header.Q<Label>("NameBox").text = dataDi.id.ToString() + $" / ({dataDi.id.GetType().Name})";
            var content = header.Q<ScrollView>("Content");
            var btn = header.Q<Button>("ShowHide_Btn");
            btn.clickable.clicked += () =>
            {
                if (content.style.display == DisplayStyle.Flex)
                {
                    btn.text = "In Hide";
                    content.style.display = DisplayStyle.None;
                }
                else
                {
                    btn.text = "In Show";
                    content.style.display = DisplayStyle.Flex;
                }
            };
            
            foreach (var dataKey in dataDi.di.Data.Keys)
            {
                content.Add(CreateTypeName(dataKey, dataDi.di.Data[dataKey]));
                content.Add(Border.Instantiate());
            }

            return header;
        }

        private VisualElement CreateTypeName(Type dataKey, DI.DictIdObj dictIdObj)
        {
            var result = TypeName.Instantiate();
            result.Q<Label>("TypeLabel").text = dataKey.Name;
            result.Q<Label>("CountLabel").text = $": in count - {dictIdObj.Keys.Count.ToString()}";
            var content = result.Q<ScrollView>("Content");
            foreach (var key in dictIdObj.Keys)
            {
                var newCOntent = new Label($"{key.ToString()}: ({key.GetType().Name})");
                content.Add(newCOntent);
            }

            return result;
        }

        private List<DataDi> GetAllDI(DI instance)
        {
            var result = new List<DataDi>();
            var unSaw = new List<DataDi>();
            unSaw.Add(new DataDi(instance, "Main"));

            while (unSaw.Count>0)
            {
                var fisrt = unSaw.First();
                unSaw.Remove(fisrt);
                result.Add(fisrt);
                var dictDI = fisrt.di.Data.GerIfHas(typeof(DI));
                if (dictDI != null)
                {
                    foreach (var keyValuePair in dictDI)
                    {
                        unSaw.Add(new DataDi((DI)keyValuePair.Value, keyValuePair.Key));   
                    }
                }
            }
            return result;
        }
        
        private class DataDi
        {
            public DI di;
            public object id;

            public DataDi(DI d, object i)
            {
                di = d;
                id = i;
            }
        }
    }
}