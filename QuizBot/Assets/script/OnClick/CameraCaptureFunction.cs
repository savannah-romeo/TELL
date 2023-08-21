using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.iOS;
//using UnityEngine.Windows.WebCam;

public class CameraCaptureFunction : MonoBehaviour
 {
    //private PhotoCapture photoCaptureObject = null;
    //public Button capturePicture;

    private WebCamTexture webCamTexture;
    public Button capturePicture;

    private void Start()
    {
        capturePicture.onClick.AddListener(CapturePictureClicked);

        // Initialize the camera texture
        webCamTexture = new WebCamTexture();
        webCamTexture.Play();
    }

    void CapturePictureClicked()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            // Request camera permission
            Permission.RequestUserPermission(Permission.Camera);
            return;
        }

        CapturePhoto();
    }
    /* private void Start()
     {
         capturePicture.onClick.AddListener(capturePictureClicked);
     }
     void capturePictureClicked()
     {
         PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
     }
     void OnPhotoCaptureCreated(PhotoCapture captureObject)
     {
         photoCaptureObject = captureObject;

         Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();

         CameraParameters c = new CameraParameters();
         c.hologramOpacity = 0.0f;
         c.cameraResolutionWidth = cameraResolution.width;
         c.cameraResolutionHeight = cameraResolution.height;
         c.pixelFormat = CapturePixelFormat.BGRA32;

         captureObject.StartPhotoModeAsync(c, OnPhotoModeStarted);
     }
     void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
     {
         photoCaptureObject.Dispose();
         photoCaptureObject = null;
     }
     private void OnPhotoModeStarted(PhotoCapture.PhotoCaptureResult result)
     {
         if (result.success)
         {
             string filename = string.Format(@"CapturedImage{0}_n.jpg", Time.time);
             string filePath = System.IO.Path.Combine(Application.persistentDataPath, filename);

             //photoCaptureObject.TakePhotoAsync(filePath, PhotoCaptureFileOutputFormat.JPG, OnCapturedPhotoToDisk);
             photoCaptureObject.TakePhotoAsync(filePath, PhotoCaptureFileOutputFormat.JPG, photoCaptureResult =>
             {
                 OnCapturedPhotoToDisk(photoCaptureResult, filePath);
             });
         }
         else
         {
             Debug.LogError("Unable to start photo mode!");
         }
     }*/

    void CapturePhoto()
    {
        // Create a new Texture2D to store the captured image
        Texture2D photoTexture = new Texture2D(webCamTexture.width, webCamTexture.height);
        photoTexture.SetPixels(webCamTexture.GetPixels());
        photoTexture.Apply();

        // Convert the Texture2D to bytes (PNG format)
        byte[] imageBytes = photoTexture.EncodeToPNG();
        string base64Image = Convert.ToBase64String(imageBytes);

        // Save or process the captured image
        DataManager.individual_image_data[DataManager.globalTime - 1] = base64Image;

        Debug.Log("Saved Photo!");

        // Clean up
        Destroy(photoTexture);
    }
       /* void OnCapturedPhotoToDisk(PhotoCapture.PhotoCaptureResult result, string imagePath)
    {
        if (result.success)
        {

            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string base64Image = Convert.ToBase64String(imageBytes);
            DataManager.individual_image_data[DataManager.globalTime - 1] = base64Image;

            Debug.Log("Saved Photo to disk!");

            photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
        }
        else
        {
            Debug.Log("Failed to save Photo to disk");
        }
    }*/
}
