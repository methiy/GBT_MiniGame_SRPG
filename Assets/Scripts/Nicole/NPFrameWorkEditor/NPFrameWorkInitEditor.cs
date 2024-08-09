using System.IO;
using UnityEditor;
using UnityEngine;

namespace NicoleFrameWork
{
    public class NPFrameWorkInitEditor 
    {
        [MenuItem("NicolePotterEditor/NPFrameWork/Initialize the folder")]
        public static void BinaryAutoInitData()
        {
            if (!Directory.Exists(Application.dataPath + "/ArtRes/Excel/"))
                Directory.CreateDirectory(Application.dataPath + "/ArtRes/Excel/");
            if (!Directory.Exists(Application.dataPath + "/StreamingAssets/"))
                Directory.CreateDirectory(Application.dataPath + "/StreamingAssets/");
            if (!Directory.Exists(Application.dataPath + "/Lua/"))
                Directory.CreateDirectory(Application.dataPath + "/Lua/");
            if (!Directory.Exists(Application.dataPath + "/Resources/UI/"))
                Directory.CreateDirectory(Application.dataPath + "/Resources/UI/");
            if (!Directory.Exists(Application.dataPath + "/Editor/ArtRes/music/"))
                Directory.CreateDirectory(Application.dataPath + "/Editor/ArtRes/music/");
            if (!Directory.Exists(Application.dataPath + "/Scripts/Game/"))
                Directory.CreateDirectory(Application.dataPath + "/Scripts/Game/");
            if (!Directory.Exists(Application.dataPath + "/Editor/ArtRes/sound/"))
                Directory.CreateDirectory(Application.dataPath + "/Editor/ArtRes/sound/");
            if (!Directory.Exists(Application.dataPath + "/Resources/Music/"))
                Directory.CreateDirectory(Application.dataPath + "/Resources/Music/");
            if (!Directory.Exists(Application.dataPath + "/Resources/Sound/"))
                Directory.CreateDirectory(Application.dataPath + "/Resources/Sound/");
            if (!Directory.Exists(Application.dataPath + "/ABRes/Json/"))
                Directory.CreateDirectory(Application.dataPath + "/ABRes/Json/");
            AssetDatabase.Refresh();
        }
    }
}

