using UnityEngine;

namespace UIDemo
{
    public abstract class UIElement : MonoBehaviour
    {
        [HideInInspector]
        [SerializeField]
        protected RectTransform rectTransform;

        protected virtual void OnValidate()
        {
            if (!this.rectTransform)
                this.rectTransform = this.transform as RectTransform;
        }

        protected virtual void Initialize()
        {
        }

        private void Start()
        {
            Initialize();
        }

        public void SetActive(bool value)
        {
            this.gameObject.SetActive(value);
        }

        public void SetSize(Vector2 size)
        {
            if (this.rectTransform)
            {
                this.rectTransform.sizeDelta = size;
            }
        }
    }
}
