using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MS.Internal.Mita.Foundation;
using MS.Internal.Mita.Logging;
using MS.Internal.Mita.Localization;
using MS.Internal.Mita.Modeling;
using MS.Internal.Mita.Foundation.Controls;
using MS.Internal.Mita.Foundation.Waiters;
using System.Configuration;

namespace Common.UITestFramework.UIMaps
{
    public class LoginWindow
    {
        public LoginWindow()
        {
            UIObject root = UIObject.Root.Descendants.Find(UICondition.CreateFromId("ShellForm"));
            this.parent = this.WaitToFind<UIObject>(root.Descendants.TryFind, UICondition.CreateFromId("FacebookWinformBrowser"));

            if (!ExistNotHai)
            {
                Email = new Edit(this.WaitToFind<UIObject>(
                    this.WaitToFindMultiple(
                        parent.Descendants,
                        UICondition.CreateFromName("Email:")).TryFind,
                    UICondition.Create("@ControlType=Edit")));
            }

            Password = new Edit(this.WaitToFind<UIObject>(
                this.WaitToFindMultiple(
                    parent.Descendants,
                    UICondition.CreateFromName("Password:")).TryFind,
                UICondition.Create("@ControlType=Edit")));

            LoginButton = new Button(this.WaitToFind<UIObject>(
                this.WaitToFindMultiple(
                    parent.Descendants,
                    UICondition.CreateFromName("Log In")).TryFind,
                UICondition.Create("@ControlType=Button")));

            CancelButton = new Button(this.WaitToFind<UIObject>(
                this.WaitToFindMultiple(
                    parent.Descendants,
                    UICondition.CreateFromName("Cancel")).TryFind,
                UICondition.Create("@ControlType=Button")));
        }

        public Edit Email { get; private set; }
        public Edit Password { get; private set; }
        public Button LoginButton { get; private set; }
        public Button CancelButton { get; private set; }

        public bool ExistNotHai
        {
            get
            {
                try
                {
                    WaitToFindMultiple(
                        parent.Descendants,
                        UICondition.CreateFromName("Not Hai?"));
                }
                catch (UIObjectNotFoundException)
                {
                    return false;
                }
                return true;
            }
        }
        private UIObject parent;

        public bool Login(string email, string password)
        {
            bool existNotHai = ExistNotHai;
            if (!existNotHai)
            {
                this.Email.SetValue(email);
            }
            this.Password.SetValue(password);
            this.LoginButton.Click();
            return existNotHai;
        }

        public delegate bool TryFindHandler<I>(UICondition condition, out I element);

        public I WaitToFind<I>(TryFindHandler<I> finder, UICondition condition) where I : MS.Internal.Mita.Foundation.UIObject
        {
            return WaitToFind<I>(finder, condition, null);
        }

        public I WaitToFind<I>(TryFindHandler<I> finder, UICondition condition, UIObject button) where I : MS.Internal.Mita.Foundation.UIObject
        {
            I element;
            int retryTimes = 200;
            System.Threading.Thread.Sleep(200);
            while (!finder(condition, out element) && (retryTimes--) != 0)
            {
                if (button != null)
                {
                    button.Click();
                }
                System.Threading.Thread.Sleep(200);
            }
            if (retryTimes == 0)
            {
                throw new UIObjectNotFoundException("Fail to find indicated element in polling&retry mechanism!");
            }
            return element;
        }

        public UICollection<I> WaitToFindMultiple<I>(UICollection<I> unSearchCollection, UICondition findCondition) where I : MS.Internal.Mita.Foundation.UIObject
        {
            UICollection<I> resultCollection;
            int retryTimes = 200;
            System.Threading.Thread.Sleep(200);
            while ((resultCollection = unSearchCollection.FindMultiple(findCondition)).Count == 0 && (retryTimes--) != 0)
            {
                System.Threading.Thread.Sleep(200);
            }
            if (retryTimes == 0 || resultCollection == null || resultCollection.Count == 0)
            {
                throw new UIObjectNotFoundException("Fail to find indicated element in polling&retry mechanism!");
            }
            return resultCollection;
        }
    }
}
