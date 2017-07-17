using UnityEngine;
using UnityEngine.UI;
using ExtendedLibrary.Events;
using TMPro;

namespace UIDemo
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CanvasGroup))]
    public class UIDialog : UITextPanel
    {
        [Header("Dialog")]
        [SerializeField]
        protected DialogType type = DialogType.CancelOK;

        [Header("Buttons")]
        [SerializeField]
        protected UITextButton cancelButton;

        [SerializeField]
        protected UITextButton okButton;

        [SerializeField]
        protected LayoutElement buttonLayout;

        [SerializeField]
        protected HorizontalLayoutGroup buttonGroup;

        [SerializeField]
        protected HorizontalAlignment buttonAlign = HorizontalAlignment.Center;

        [SerializeField]
        protected Vector2 buttonSize = new Vector2(100f, 30f);

        [SerializeField]
        protected bool expandButtonWidth = true;

        [SerializeField]
        protected ExtendedEvent onCancel;

        [SerializeField]
        protected ExtendedEvent onOK;

        public ExtendedEvent OnCancel
        {
            get { return this.onCancel; }
        }

        public ExtendedEvent OnOK
        {
            get { return this.onOK; }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            SetCancelActive(false);
            SetOKActive(false);
            ApplyType(this.type);

            if (this.buttonLayout)
            {
                this.buttonLayout.minHeight = this.buttonSize.y;
            }

            if (this.buttonGroup)
            {
                switch (this.buttonAlign)
                {
                    case HorizontalAlignment.Left:
                        this.buttonGroup.childAlignment = TextAnchor.MiddleLeft;
                        break;

                    case HorizontalAlignment.Right:
                        this.buttonGroup.childAlignment = TextAnchor.MiddleRight;
                        break;

                    case HorizontalAlignment.Center:
                        this.buttonGroup.childAlignment = TextAnchor.MiddleCenter;
                        break;
                }

                this.buttonGroup.childControlWidth = this.expandButtonWidth;
                this.buttonGroup.childForceExpandWidth = this.expandButtonWidth;
            }
        }

        protected void SetCancelActive(bool value)
        {
            if (this.cancelButton)
                this.cancelButton.SetActive(value);
        }

        protected void SetOKActive(bool value)
        {
            if (this.okButton)
                this.okButton.SetActive(value);
        }

        protected void ApplyType(DialogType type)
        {
            switch (type)
            {
                case DialogType.Cancel:
                    SetCancelActive(true);
                    break;

                case DialogType.OK:
                    SetOKActive(true);
                    break;

                case DialogType.CancelOK:
                    SetCancelActive(true);
                    SetOKActive(true);
                    break;
            }
        }

        protected override void Initialize()
        {
            base.Initialize();

            if (this.cancelButton)
            {
                this.cancelButton.OnClick.RemoveAll();
                this.cancelButton.OnClick.AddListener(this.onCancel.Invoke);
                this.cancelButton.OnClick.AddListener(Hide);
            }

            if (this.okButton)
            {
                this.okButton.OnClick.RemoveAll();
                this.okButton.OnClick.AddListener(this.onOK.Invoke);
                this.okButton.OnClick.AddListener(Hide);
            }
        }

        public void Open(string content = null, DialogType type = DialogType.CancelOK, ExtendedDelegate onCancel = null, ExtendedDelegate onOK = null)
        {
            if (!string.IsNullOrEmpty(content))
                SetContent(content);

            if (this.type != type)
            {
                ApplyType(type);
            }

            this.onCancel.AddListener(onCancel);
            this.onOK.AddListener(onOK);

            Show();
        }

#if UNITY_EDITOR
        protected override void Update()
        {
            base.Update();

            if (!Application.isPlaying)
            {
                if (!this.expandButtonWidth)
                {
                    if (this.cancelButton)
                        this.cancelButton.SetSize(this.buttonSize);

                    if (this.okButton)
                        this.okButton.SetSize(this.buttonSize);
                }
            }
        }
#endif
    }

    public enum DialogType
    {
        Cancel, OK, CancelOK
    }
}