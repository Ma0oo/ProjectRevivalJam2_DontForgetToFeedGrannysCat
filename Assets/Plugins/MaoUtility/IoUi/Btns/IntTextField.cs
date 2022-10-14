using System;
using TMPro;
using UnityEngine;

namespace Plugins.MaoUtility.IoUi.Btns
{
    public class IntTextField : IOBtn<int>
    {
        public override event Action<int, IOBtn<int>> Updated;

        [SerializeField] private TMP_InputField _inputField;
        
        public override void SetWithoutEvent(int value) 
            => _inputField.SetTextWithoutNotify(value.ToString());

        public override void Init(Func<int> get, Action<int> set)
        {
            SetWithoutEvent(get());
            _inputField.onValidateInput = Validate;
            _inputField.onValueChanged.AddListener(x =>
            {
                if (Int32.TryParse(x, out var r))
                {
                    set(r);
                    SetWithoutEvent(get());
                    Updated?.Invoke(get(), this);
                };
            });
        }

        private char Validate(string text, int charindex, char addedchar)
        {
            bool isNumber = addedchar == '0';
            return char.IsNumber(addedchar) ? addedchar : '\0';
        }
    }
}