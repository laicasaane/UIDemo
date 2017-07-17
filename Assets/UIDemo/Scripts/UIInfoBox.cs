using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIDemo
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    public class UIInfoBox : UITextPanel
    {
        [Header("Header")]
        [SerializeField]
        protected TextMeshProUGUI header;

        [SerializeField]
        [Multiline]
        protected string title = "Title";

        [SerializeField]
        protected float titleFontSize = 20;

        [SerializeField]
        protected Color titleColor = Color.black;

        [Header("Image")]
        [SerializeField]
        protected Image headerImage;

        [SerializeField]
        protected Image textImage;

        [SerializeField]
        protected Color titleBackground = Color.grey;

        [SerializeField]
        protected Color contentBackground = Color.white;

        protected override void OnValidate()
        {
            base.OnValidate();

            if (this.titleFontSize < 0)
                this.titleFontSize = 0;

            if (this.header)
            {
                this.header.fontSize = this.titleFontSize;
                this.header.color = this.titleColor;
                SetTitle(this.title);
            }

            if (this.headerImage)
            {
                this.headerImage.color = this.titleBackground;
            }

            if (this.textImage)
            {
                this.textImage.color = this.contentBackground;
            }
        }

        public void SetTitle(string title)
        {
            this.header.text = title;
        }
    }
}
