using UnityEditor;
using UnityEngine;

namespace Ilumisoft.Editor.GameTemplate
{
    public class WindowDocumentationContent : WindowContent
    {
        public override void OnGUI()
        {
            GUILayout.Space(14);
            DrawHeadline("Get Started");

            GUILayout.BeginHorizontal();

            GUILayout.Label(new GUIContent("Documentation"));

            if (GUILayout.Button("Open", GUILayout.Width(100)))
            {
                AssetDatabase.OpenAsset(PackageInfo.Documentation);
            }

            GUILayout.EndHorizontal();
        }
    }
}