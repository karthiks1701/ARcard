﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class assetcreate : MonoBehaviour
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.StrictMode, BuildTarget.Android);
    }
}