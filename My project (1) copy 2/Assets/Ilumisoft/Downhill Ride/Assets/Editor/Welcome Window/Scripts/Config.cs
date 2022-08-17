using System;
using UnityEngine;

namespace Ilumisoft.Editor.GameTemplate
{
    public static class Config
    {
        /// <summary>
        /// Menu Items Configuration
        /// </summary>
        public static class MenuItems
        {
            public const string PathOpenWindow = "Game Template/Welcome";
            public const string PathRate = "Game Template/Rate";
        }

        /// <summary>
        /// Session Configuration
        /// </summary>
        public static class Session
        {
            public const string Key = "Ilumisoft.WelcomeWindow.HasBeenShown";
        }

        /// <summary>
        /// Window Configuration
        /// </summary>
        public static class Window
        {
            public const string Title = "Welcome";
            public static readonly Vector2 Size = new Vector2(400, 700);

            public static Type[] Content = new Type[]
            {
                typeof(WindowHeaderContent),
                typeof(WindowDocumentationContent),
                typeof(WindowPackageListContent),
                typeof(WindowSupportContent),
                typeof(WindowFooterContent),
            };
        }
    }
}