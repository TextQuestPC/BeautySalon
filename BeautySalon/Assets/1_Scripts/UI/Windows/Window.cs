using System;

namespace UI
{
    public abstract class Window : UIElement, IUIElement
    {
        public event Action<IUIElement> ClickCloseButton;

        private CloseButton buttonClose;

        public override void OnStart()
        {
            buttonClose = GetComponentInChildren<CloseButton>();
        }

        protected void OnClickButtonClose()
        {
            BeforeClickButtonClose();
            Hide();
            AfterClickButtonClose();
        }
    }
}
