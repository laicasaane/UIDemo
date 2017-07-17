using UnityEngine;
using TMPro;

namespace UIDemo
{
    [DisallowMultipleComponent]
    public class UITextInput : UITextBox
    {
        [Header("Input")]
        [SerializeField]
        protected TMP_InputField inputField;

        [SerializeField]
        protected TextMeshProUGUI placeholder;

        [Multiline]
        [SerializeField]
        protected string maskContent;

        public string Content
        {
            get { return this.inputField.text; }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            if (this.inputField)
            {
                this.inputField.text = this.content;
                this.inputField.pointSize = this.fontSize;
            }

            if (this.placeholder)
            {
                this.placeholder.text = this.maskContent;
                this.placeholder.color = this.textColor;
            }
        }

        public override void SetContent(string content)
        {
            this.inputField.text = content;
            this.onSetContent.Invoke();
        }
    }
}
