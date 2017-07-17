using UnityEngine;
using UnityEngine.UI;
using ExtendedLibrary.Events;

namespace UIDemo
{
    [DisallowMultipleComponent]
    public class UITextButton : UITextBox
    {
        [Header("Button")]
        [SerializeField]
        protected Button button;

        [SerializeField]
        protected ExtendedEvent onClick;

        public ExtendedEvent OnClick
        {
            get { return this.onClick; }
        }

        protected override void Initialize()
        {
            if (this.button)
            {
                this.button.onClick.RemoveAllListeners();
                this.button.onClick.AddListener(this.onClick.Invoke);
            }
        }
    }
}