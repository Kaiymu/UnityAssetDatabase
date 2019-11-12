using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomPostprocessor : AssetPostprocessor
{
    // Before the texture is imported
    public void OnPreprocessTexture()
    {
        if (assetPath.Contains("feedback"))
        {
            string targetFolder = "Assets/Textures/Feedback/";
            string fileName = "feedback_test.png";

            var validateMoveAsset = AssetDatabase.ValidateMoveAsset(assetPath, targetFolder + fileName);

            // If it's an empty string, then no error occured.
            if (string.IsNullOrEmpty(validateMoveAsset))
            {
                AssetDatabase.MoveAsset(assetPath, targetFolder + fileName);
            }
        }
    }

    // After the texture is imported
    public void OnPostprocessTexture(Texture2D texture)
    {
        // Invert colors
        if (assetPath.Contains("_invert_color"))
        {
            for (int m = 0; m < texture.mipmapCount; m++)
            {
                Color[] c = texture.GetPixels(m);
                for (int i = 0; i < c.Length; i++)
                {
                    c[i].r = 1 - c[i].r;
                    c[i].g = 1 - c[i].g;
                    c[i].b = 1 - c[i].b;
                }
                texture.SetPixels(c, m);
            }
        }
    }
}