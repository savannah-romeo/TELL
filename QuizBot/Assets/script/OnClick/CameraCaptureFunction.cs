
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
    public Button saveAndcloseButton;
    public Button retakeImageButton;
    public TMP_Text buttonStartStopText;
    private Texture defaultBackground;
    public RawImage background;
    private AspectRatioFitter aspectRatioFitter;
    public GameObject imageCapturePanel;

    private void Start()
    {
        
        startStopButton.onClick.AddListener(StartStopCam_Clicked);
        retakeImageButton.onClick.AddListener(StartStopCam_Clicked);
        capturePicture.onClick.AddListener(CapturePicture);
        imageUploadButton.onClick.AddListener(CapturePictureClicked);
        closeButton.onClick.AddListener(closeButtonListener);
        saveAndcloseButton.onClick.AddListener(closeButtonListener);

        // Initialize the camera texture
        //webCamTexture = new WebCamTexture();
        //webCamTexture.Play();
    }

    void closeButtonListener()
    {
        StopWebCam();
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

    private void Update()
    {
        if (camAvailable)
        {
            UpdateOrientation();
        }
    }

    private void UpdateOrientation()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            // Adjust the rotation of the texture based on the device orientation
            switch (Input.deviceOrientation)
            {
                case DeviceOrientation.Portrait:
                    background.rectTransform.localEulerAngles = new Vector3(0, 0, -90);
                    break;
                case DeviceOrientation.PortraitUpsideDown:
                    background.rectTransform.localEulerAngles = new Vector3(0, 0, 90);
                    break;
                case DeviceOrientation.LandscapeLeft:
                    background.rectTransform.localEulerAngles = new Vector3(0, 0, 0);
                    break;
                case DeviceOrientation.LandscapeRight:
                    background.rectTransform.localEulerAngles = new Vector3(0, 0, 180);
                    break;
                default:
                    background.rectTransform.localEulerAngles = new Vector3(0, 0, 0);
                    break;
            }
        }
    }

    /*public void StartStopCam_Clicked()
    {
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
    }*/

    public void StartStopCam_Clicked()
    {
        // Check if the camera is already running and stop it if necessary
        /*if (webCamTexture != null)
        {
            StopWebCam();
            camAvailable = false;
            buttonStartStopText.SetText("Start Camera");
        }
        else
        {*/
            WebCamDevice[] devices = WebCamTexture.devices;
            if (devices.Length == 0)
            {
                Debug.Log("No camera detected");
                return;
            }

        // Find a suitable camera (e.g., the back camera on a phone)
            bool isFrontFacing = true;
            for (int i = 0; i < devices.Length; i++)
            {
                if (!devices[i].isFrontFacing) // Prefer back-facing camera
                {
                    isFrontFacing = false;
                    webCamTexture = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                    break;
                }
            }

            if (webCamTexture == null)
            {
                Debug.Log("Back Camera unavailable");
                // If no back camera is found, default to the first available camera
                webCamTexture = new WebCamTexture(devices[0].name, Screen.width, Screen.height);
            }

            webCamTexture.Play();
            background.texture = webCamTexture;

            // Check if the selected camera is front-facing or back-facing
            //bool isFrontFacing = webCamTexture.deviceName != null && WebCamTexture.devices[0].isFrontFacing;

            // Flip the camera preview horizontally if it's the back-facing camera
            //background.rectTransform.localScale = new Vector3(isFrontFacing ? 1 : -1, -1, 1);

            background.rectTransform.localScale = new Vector3(1, 1, 1);

            // Adjust the rotation of the texture based on the device orientation
            UpdateOrientation();

            camAvailable = true;
            startStopButton.enabled = false;
            retakeImageButton.enabled = false;
            //buttonStartStopText.SetText("Stop Camera");
       // }
    }


    private void StopWebCam()
    {
        //background.texture = null;
        if (webCamTexture != null)
        {
            webCamTexture.Stop();
            webCamTexture = null;
            camAvailable = false;
        }
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
                retakeImageButton.enabled=true;
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
