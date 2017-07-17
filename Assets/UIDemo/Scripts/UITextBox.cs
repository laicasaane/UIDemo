using UnityEngine;
using UnityEngine.UI;

namespace UIDemo
{
    [RequireComponent(typeof(Image))]
    [DisallowMultipleComponent]
    public class UITextBox : UIText
    {
        [HideInInspector]
        [SerializeField]
        protected Image image;

        [Header("Image")]
        [SerializeField]
        protected Color background;

        protected override void OnValidate()
        {
            base.OnValidate();

            if (!this.image)
                this.image = GetComponent<Image>();

            if (this.image)
            {
                this.image.color = this.background;
            }
        }
    }
}
