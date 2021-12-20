using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class SR_RenderCamera : MonoBehaviour
{
    private bool isPerformingScreenGrab = false;
    private Texture2D destinationTexture;
    public int xOffset = 190;
    public int yOffset = 0;
    public int screenshotWidth = 500;
    public int screenshotHeight;
    public UnityEvent renderEvent;

    private int fileNumber = 0;


    private void Start()
    {
        screenshotHeight = Screen.height;
        destinationTexture = new Texture2D(screenshotWidth, screenshotHeight, TextureFormat.RGB24, false);

        Camera.onPostRender += OnPostRenderCallback;

    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPerformingScreenGrab = true;
        }
    }

    public void performScreenGrab()
    {
        isPerformingScreenGrab = true;
    }

    void OnPostRenderCallback(Camera cam)
    {
        if (isPerformingScreenGrab)
        {
            if (cam == Camera.main)
            {
                Rect regionToReadFrom = new Rect(xOffset, yOffset, screenshotWidth, screenshotHeight);
                int xPosToWriteTo = 0;
                int yPosToWriteTo = 0;
                bool updateMipMapsAutomatically = false;

                destinationTexture.ReadPixels(regionToReadFrom, xPosToWriteTo, yPosToWriteTo, updateMipMapsAutomatically);
                destinationTexture.Apply();

                var Bytes = destinationTexture.EncodeToPNG();
                string filename = "Assets/test" + fileNumber +".png";
                fileNumber++;
                Debug.Log(filename);
                File.WriteAllBytes(filename, Bytes);


                isPerformingScreenGrab = false;
                renderEvent.Invoke();
            }

        }
    }

}