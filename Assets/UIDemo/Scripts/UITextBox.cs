using UnityEngine;
using UnityEngine.UI;

namespace UIDemo
{
    [RequireComponent(typeof(Image))]
    [DisallowMultipleComponent]
    public class UITextBox : UIText
    {
        [Header("Image")]
        [SerializeField]
        protected Image image;

        [SerializeField]
        protected Color background;

        protected override void OnValidate()
        {
            base.OnValidate();

            if (this.image)
            {
                this.image.color = this.background;
            }
        }
    }
}
