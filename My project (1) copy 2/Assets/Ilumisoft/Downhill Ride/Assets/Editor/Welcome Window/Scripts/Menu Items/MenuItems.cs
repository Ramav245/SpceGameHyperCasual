using UnityEditor;
using UnityEngine;

namespace Ilumisoft.Editor.GameTemplate
{
    public static class MenuItems
    {
        [MenuItem(Config.MenuItems.PathOpenWindow)]
        static void OpenPackageUtility()
        {
            WelcomeWindow.CreateWindow();
        }

        [MenuItem(Config.MenuItems.PathRate)]
        static void Rate()
        {
            var bundleInfo = ScriptableObjectUtility.Find<PackageInfo>();

            if(bundleInfo != null)
            {
                Application.OpenURL(bundleInfo.AssetStoreURL + "#reviews");
            }
        }
    }
}