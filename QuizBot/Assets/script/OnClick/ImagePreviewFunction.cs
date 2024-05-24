
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

public class ImagePreviewFunction : MonoBehaviour
 {
    //private PhotoCapture photoCaptureObject = null;
    //public Button capturePicture;
    public int ind;
    public Button previewImageButton;
    public Button closeButton;
    public GameObject previewImagePanel;
    public RawImage rawImage;

    private void Start()
    {

        previewImageButton.onClick.AddListener(previewImageClicked);
        closeButton.onClick.AddListener(closeButtonListener);

        // Initialize the camera texture
        //webCamTexture = new WebCamTexture();
        //webCamTexture.Play();
    }

    void closeButtonListener()
    {
        previewImagePanel.gameObject.SetActive(false);
    }

    void previewImageClicked()
    {
        previewImagePanel.gameObject.SetActive(true);
        //defaultBackground = background.texture;
        byte[] imageBytes = Convert.FromBase64String(DataManager.individual_image_data[ind]);
        //var fileContent = new ByteArrayContent(fileBytes);
        //byte[] imageBytes = File.ReadAllBytes(DataManager.individual_image_data[ind]);

        // Create a new Texture2D
        Texture2D loadedTexture = new Texture2D(2, 2); // You can adjust the size as needed

        // Load the image bytes into the Texture2D
        loadedTexture.LoadImage(imageBytes);
        rawImage.texture = loadedTexture;
        
    }

}
