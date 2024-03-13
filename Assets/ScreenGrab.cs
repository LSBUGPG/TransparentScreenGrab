using System.Collections;
using UnityEngine;

public class ScreenGrab : MonoBehaviour
{
    public RenderTexture source;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CaptureScreen());
        }
    }

    IEnumerator CaptureScreen()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(source.width, source.height, TextureFormat.RGBA32, false);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = source;
        texture.ReadPixels(new Rect(0, 0, source.width, source.height), 0, 0);
        texture.Apply();
        byte[] bytes = texture.EncodeToPNG();
        System.IO.File.WriteAllBytes("ScreenShot.png", bytes);
        RenderTexture.active = previous;
    }
}
