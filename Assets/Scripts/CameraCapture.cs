using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CameraCapture : MonoBehaviour
{
    // Reference to your UI Button
    public Button captureButton;
    public GameObject photoOp;
    public GameObject wellDone;
    public RawImage rawImage;


    private void Start()
    {
        // Ensure the button is linked and setup the listener
        if (captureButton != null)
        {
            captureButton.onClick.AddListener(TakePicture);
        }
    }

    public void TakePicture()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        // Wait for the end of the frame to ensure the UI has been updated
        yield return new WaitForEndOfFrame();

        // Create a temporary RenderTexture
        RenderTexture tempRT = new RenderTexture(Screen.width, 2000, 24);
        Camera mainCamera = Camera.main; 
        mainCamera.targetTexture = tempRT;

        // Create a texture the size of the screen
        Texture2D screenTexture = new Texture2D(Screen.width, 1300, TextureFormat.RGB24, false);

        // Render the camera to the temporary render texture
        mainCamera.Render();
        RenderTexture.active = tempRT;

        // Read screen contents into the texture
        screenTexture.ReadPixels(new Rect(0, 0, Screen.width, 1300), 0, 0);
        screenTexture.Apply();

        // Reset the camera's target texture
        mainCamera.targetTexture = null;
        RenderTexture.active = null;

        // Destroy the temporary render texture
        Destroy(tempRT);

        // Display the captured texture on a UI RawImage
        rawImage.texture = screenTexture;
        // rawImage.SetNativeSize();

        // Encode texture into PNG
        // byte[] imageBytes = screenTexture.EncodeToPNG();

        // Save the image to the device (you might need to adjust the path for your needs)
        // string filePath = Path.Combine(Application.persistentDataPath, "capturedImage.png");
        // File.WriteAllBytes(filePath, imageBytes);

        ForwardUI();
    }

    private void ForwardUI()
    {
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        yield return new WaitForSeconds(2f);
        photoOp.SetActive(false);
        wellDone.SetActive(true);
    }

}
