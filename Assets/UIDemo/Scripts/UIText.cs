using UnityEngine;
using TMPro;
using ExtendedLibrary.Events;

namespace UIDemo
{
    [DisallowMultipleComponent]
    public class UIText : UIElement
    {
        [SerializeField]
        protected TextMeshProUGUI text;

        [SerializeField]
        [Multiline]
        protected string content = "Text";

        [SerializeField]
        protected float fontSize = 20;

        [SerializeField]
        protected Color textColor = Color.black;

        [SerializeField]
        protected ExtendedEvent onSetContent;

        public ExtendedEvent OnSetContent
        {
            get { return this.onSetContent; }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            if (this.fontSize < 0)
                this.fontSize = 0;

            if (this.text)
            {
                this.text.color = this.textColor;
                this.text.text = this.content;
                this.text.fontSize = this.fontSize;
            }
        }

        public virtual void SetContent(string content)
        {
            this.text.text = content;
            this.onSetContent.Invoke();
        }
    }
}
