using TMPro;
using UnityEngine;

namespace UIDemo
{
    [DisallowMultipleComponent]
    public class UITextPanel : UIPanel
    {
        [Header("Content")]
        [SerializeField]
        protected TextMeshProUGUI text;

        [SerializeField]
        [Multiline]
        protected string content = "Text";

        [SerializeField]
        protected float fontSize = 20;

        [SerializeField]
        protected Color textColor = Color.black;

        protected override void OnValidate()
        {
            base.OnValidate();

            if (this.fontSize < 0)
                this.fontSize = 0;

            if (this.text)
            {
                this.text.color = this.textColor;
                this.text.fontSize = this.fontSize;
                SetContent(this.content);
            }
        }

        public void SetContent(string text)
        {
            this.text.text = text;
        }
    }
}
