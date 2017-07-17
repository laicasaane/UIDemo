using UnityEngine;
using ExtendedLibrary.Events;

namespace UIDemo
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    public class UIPanel : UIElement
    {
        [HideInInspector]
        [SerializeField]
        protected CanvasGroup canvasGroup;

        [SerializeField]
        protected bool hiddenByDefault = true;

        [SerializeField]
        protected ExtendedEvent onShow;

        [SerializeField]
        protected ExtendedEvent onHide;

        public ExtendedEvent OnShow
        {
            get { return this.onShow; }
        }

        public ExtendedEvent OnHide
        {
            get { return this.onHide; }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            if (!this.canvasGroup)
                this.canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            this.canvasGroup.alpha = 1f;
            this.canvasGroup.blocksRaycasts = true;
            this.canvasGroup.interactable = true;

            this.onShow.Invoke();
        }

        public void Hide()
        {
            this.canvasGroup.alpha = 0;
            this.canvasGroup.blocksRaycasts = false;
            this.canvasGroup.interactable = false;

            this.onHide.Invoke();
        }

#if UNITY_EDITOR
        protected virtual void Update()
        {
            if (!Application.isPlaying)
            {
                if (this.hiddenByDefault)
                    Hide();
                else
                    Show();
            }
        }
#endif
    }
}