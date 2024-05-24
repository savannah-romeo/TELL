
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.iOS;
//using UnityEngine.Windows.WebCam;

public class CameraCaptureFunction : MonoBehaviour
 {
    //private PhotoCapture photoCaptureObject = null;
    //public Button capturePicture;
    private bool camAvailable;
    private WebCamTexture webCamTexture;
    public Button capturePicture;
    public Button startStopButton;
    public Button imageUploadButton;
    public Button closeButton;
    public TMP_Text buttonStartStopText;
    private Texture defaultBackground;
    public RawImage background;
    private AspectRatioFitter aspectRatioFitter;
    public GameObject imageCapturePanel;

    private void Start()
    {
        
        startStopButton.onClick.AddListener(StartStopCam_Clicked);
        capturePicture.onClick.AddListener(CapturePicture);
        imageUploadButton.onClick.AddListener(CapturePictureClicked);
        closeButton.onClick.AddListener(closeButtonListener);

        // Initialize the camera texture
        //webCamTexture = new WebCamTexture();
        //webCamTexture.Play();
    }

    void closeButtonListener()
    {
        imageCapturePanel.gameObject.SetActive(false);
    }

    void CapturePictureClicked()
    {
        imageCapturePanel.gameObject.SetActive(true);
        defaultBackground = background.texture;

        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            // Request camera permission
            Application.RequestUserAuthorization(UserAuthorization.WebCam);
            return;
        }

    }

    /*private void Update()
    {
        if (camAvailable)
        {
            float ratio = (float) webCamTexture.width / (float)webCamTexture.height;
            aspectRatioFitter.aspectRatio = ratio;
            float scaleY = webCamTexture.videoVerticallyMirrored ? -1f:1f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
            int orient = -webCamTexture.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0f, 0f, orient);

        }
    }*/
    public void StartStopCam_Clicked()
    {
        /*if (webCamTexture != null) // Stop the camera
        {
            StopWebCam();
            camAvailable = false;
            buttonStartStopText.SetText("Start Camera");
            //startStopText.text = "Start Camera";
        }
        else // Start the camera
        {*/
            WebCamDevice[] devices = WebCamTexture.devices;

            for (int i = 0; i < devices.Length; i++)
            {
                webCamTexture = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
            webCamTexture.Play();
            background.texture = webCamTexture;
            camAvailable = true;
            startStopButton.enabled = false;


           // buttonStartStopText.SetText("Stop Camera");
           //}
    }

    private void StopWebCam()
    {
        //background.texture = null;
        webCamTexture.Stop();
        webCamTexture = null;
    }

    void CapturePicture()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            Texture2D capturedTexture = new Texture2D(webCamTexture.width, webCamTexture.height);
            capturedTexture.SetPixels(webCamTexture.GetPixels());
            capturedTexture.Apply();

            // Convert the Texture2D to bytes (PNG format)
            byte[] imageBytes = capturedTexture.EncodeToPNG();
            // You can now save or process the image bytes as needed
            string base64Image = Convert.ToBase64String(imageBytes);
            DataManager.individual_image_data[DataManager.globalTime - 1] = base64Image;

            if (webCamTexture != null) // Stop the camera
            {
                background.texture = webCamTexture;
                StopWebCam();
                camAvailable = false;
                startStopButton.enabled = true;
                //buttonStartStopText.SetText("Start Camera");
                //startStopText.text = "Start Camera";
            }

            // Clean up
            Destroy(capturedTexture);
        }
        else
        {
            Debug.LogError("Camera is not active.");
        }
    }

}
