using UnityEngine;
using UnityEditor;
using System.IO;

public class ProjectFolderGenerator : EditorWindow
{
    [MenuItem("Tools/Generate Project Folders")]
    public static void GenerateFolders()
    {
        string[] folders = new string[]
        {
            "Assets/Art",
            "Assets/Art/Characters",
            "Assets/Art/Characters/Player",
            "Assets/Art/Characters/Enemies",
            "Assets/Art/Environment",
            "Assets/Art/Environment/Tiles",
            "Assets/Art/Environment/Backgrounds",
            "Assets/Art/Environment/Decorations",
            "Assets/Art/UI",
            "Assets/Art/UI/Icons",
            "Assets/Art/UI/HUD",
            "Assets/Art/UI/Menus",
            "Assets/Art/Effects",
            "Assets/Art/Effects/Particles",
            "Assets/Art/Effects/Glow",
            "Assets/Art/Effects/Hit Effects",

            "Assets/Audio",
            "Assets/Audio/Music",
            "Assets/Audio/SFX",
            "Assets/Audio/Voice",

            "Assets/Prefabs",
            "Assets/Prefabs/Player",
            "Assets/Prefabs/Enemies",
            "Assets/Prefabs/Environment",
            "Assets/Prefabs/UI",
            "Assets/Prefabs/Checkpoints",
            "Assets/Prefabs/Interactables",

            "Assets/Scripts",
            "Assets/Scripts/Player",
            "Assets/Scripts/Enemies",
            "Assets/Scripts/Managers",
            "Assets/Scripts/UI",
            "Assets/Scripts/Systems",
            "Assets/Scripts/Utilities",

            "Assets/Scenes",
            "Assets/Scenes/Levels",
            "Assets/Scenes/Menus",

            "Assets/Settings",
            "Assets/Settings/Input",
            "Assets/Settings/Graphics",

            "Assets/Fonts",
            "Assets/Shaders",
            "Assets/Materials",
            "Assets/_Core"
        };

        int createdCount = 0;
        foreach (string folder in folders)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                createdCount++;
            }
        }

        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("✅ Folder Setup Complete",
            $"Tạo thành công {createdCount} thư mục mới!\n\nCấu trúc dự án đã được thiết lập hoàn chỉnh.",
            "OK");

        Debug.Log($"📁 Project folder structure generated successfully. ({createdCount} new folders)");
    }
}
