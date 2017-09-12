using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TakePhotoScript : MonoBehaviour {

    public void OnClickTakePhotos()
    {
        StartCoroutine(UploadPNG());

    }
        // Take a shot immediately
        /*IEnumerator Start() {
            UploadPNG();
            yield return null;
        }*/

    IEnumerator UploadPNG()
    {
        // We should only read the screen buffer after rendering is complete
        yield return new WaitForEndOfFrame();

        // Create a texture the size of the screen, RGB24 format
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        //debug tex
        //Debug.Log("text created");

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);

        // For testing purposes, also write to a file in the project folder
        //File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
        //File.WriteAllBytes("Internal shared storage" + "/SavedScreen.png", bytes);
        yield return null;
    }
}
