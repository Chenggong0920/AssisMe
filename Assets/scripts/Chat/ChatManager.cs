using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChatManager : MonoBehaviour
{
    [SerializeField]
    private AvatarChat avatarChatPrefab;

    [SerializeField]
    private PlayerChat playerChatPrefab;

    [SerializeField]
    private RectTransform chatHistoryParent;

    [SerializeField]
    private TMP_InputField playerChatInput;

    [SerializeField]
    private ScrollRect scrollRect;

    private void Start() {
        OnReceiveAIMessage("ハロー！{gpt_name}だよ！はじめまして{gpt_name}に名前つけてくれてありがとう。あなたの名前も教えてくれる?");
    }

    private void OnSendPlayerMessage(string message)
    {
        PlayerChat playerChat = Instantiate(playerChatPrefab, chatHistoryParent);
        playerChat.Init(message);

        UpdateContentSizeFitter(playerChat.GetComponent<RectTransform>());
        // ScrollToBottom();
    }

    private void OnSendPlayerImage(string path)
    {
        Debug.LogFormat("OnSendPlayerImage {0}", path);
        if (File.Exists(path))
        {
            Texture2D texture = null;
#if UNITY_EDITOR
            texture = new Texture2D(2, 2);
            byte[] imageData = File.ReadAllBytes(path);
            texture.LoadImage(imageData); // Automatically resizes the texture
#else
            texture = NativeGallery.LoadImageAtPath( path, 512 );
			if( texture == null )
			{
				Debug.Log( "Couldn't load texture from " + path );
				return;
			}
#endif

            Debug.Log("Load Image Success");

            PlayerChat playerChat = Instantiate(playerChatPrefab, chatHistoryParent);
            playerChat.Init(texture);

            Debug.Log("Instantiated Prefab");

            UpdateContentSizeFitter(playerChat.GetComponent<RectTransform>());
        }
        else
        {
            Debug.LogError("File path does not exist");
        }
    }

    private void OnReceiveAIMessage(string message)
    {
        AvatarChat avatarChat = Instantiate(avatarChatPrefab, chatHistoryParent);
        avatarChat.Init(message);

        UpdateContentSizeFitter(avatarChat.GetComponent<RectTransform>(), false);
    }

    public void OnSendClicked()
    {
        if (playerChatInput == null || playerChatInput.text.Length == 0)
            return;

        OnSendPlayerMessage(playerChatInput.text);
        playerChatInput.text = "";
    }

    public void OnUploadImageClicked()
    {
        PickImageFile((pickedFilePath) =>
        {
            if (!string.IsNullOrEmpty(pickedFilePath))
            {
                OnSendPlayerImage(pickedFilePath);
            }
            else
            {
                Debug.LogFormat("No file was selected");
            }
        });
    }

    void PickImageFile(Action<string> onFilePicked)
    {
#if UNITY_EDITOR
        var path = EditorUtility.OpenFilePanel("Select Image", "", "png,jpg,jpeg,bmp");
        onFilePicked(path);
#else
        // if (NativeFilePicker.IsFilePickerBusy())
        if (NativeGallery.IsMediaPickerBusy())
			onFilePicked.Invoke(null);

        // var extensions = new string[]{"png", "jpg", "jpeg", "bmp"};
        // for(var i = 0; i < extensions.Length; i ++)
        // {
        //     extensions[i] = NativeFilePicker.ConvertExtensionToFileType(extensions[i]);
        // }

        // NativeFilePicker.Permission permission = NativeFilePicker.PickFile( ( path ) =>
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
        {
            if( path == null )
            {
                Debug.Log( "Operation cancelled" );
                onFilePicked.Invoke(null);
            }
            else
            {
                Debug.Log( "Picked file: " + path );
                onFilePicked.Invoke(path);
            }
        }/*, extensions*/);

        Debug.Log( "Permission result: " + permission );
#endif
    }

    private void UpdateContentSizeFitter(RectTransform transform, bool scrollToBottom = true)
    {
        // First, force a layout rebuild
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform);

        // Now, force the ContentSizeFitter to update
        var fitters = transform.GetComponentsInChildren<ContentSizeFitter>();
        foreach(var fitter in fitters)
        {
            // fitter.SetLayoutHorizontal();
            fitter.SetLayoutVertical();
        }

        StartCoroutine(RefreshlayoutCoroutine(scrollToBottom));
    }

    IEnumerator RefreshlayoutCoroutine(bool scrollToBottom)
    {
        yield return null;
        // Force a layout rebuild
        LayoutRebuilder.ForceRebuildLayoutImmediate(chatHistoryParent);

        if (scrollToBottom)
            ScrollToBottom();
    }

    private void ScrollToBottom()
    {
        // Set the vertical scrollbar value to 0 (bottom)
        Canvas.ForceUpdateCanvases(); // Ensure layout is updated
        scrollRect.verticalNormalizedPosition = 0f; // Scroll to bottom
    }
}
