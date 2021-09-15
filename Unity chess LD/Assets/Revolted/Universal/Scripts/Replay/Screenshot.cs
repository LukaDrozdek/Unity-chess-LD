using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Screenshot: MonoBehaviour
{

    private static Screenshot instance;

    private Camera myCamera;
    private bool takeScreenshotOnNextFrame;
    private int pictureNumber;
    private string pictureSaveName;
    private int folderSaveNumber;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    public void Start()
    {
        CreateFolder();
        pictureNumber = 0;
        folderSaveNumber = PlayerPrefs.GetInt("folderNumber");
        folderSaveNumber++;
        PlayerPrefs.SetInt("folderNumber", folderSaveNumber);
    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            pictureNumber++;
            pictureSaveName = ("/Resources/ImageFolderNumber " + folderSaveNumber + "/Camera" + pictureNumber + "Screenshot.png");
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + pictureSaveName, byteArray);
            Debug.Log("Saved CameraScreenshot.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }

    static void CreateFolder()
    {
        string guid = AssetDatabase.CreateFolder("Assets/Resources", "ImageFolderNumber");
    }
}
