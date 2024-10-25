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
        if (File.Exists(path))
        {
            byte[] imageData = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData); // Automatically resizes the texture

            PlayerChat playerChat = Instantiate(playerChatPrefab, chatHistoryParent);
            playerChat.Init(texture);

            UpdateContentSizeFitter(playerChat.GetComponent<RectTransform>());
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
        string path = OpenFileBrowser();
        if (!string.IsNullOrEmpty(path))
        {
            OnSendPlayerImage(path);
        }
    }

    string OpenFileBrowser()
    {
        string filePath = null;
#if UNITY_EDITOR
        filePath = EditorUtility.OpenFilePanel("Select Image", "", "png,jpg,jpeg,bmp");
#else
        // var pngFileType = NativeFilePicker.ConvertExtensionToFileType( "png" );
        // var jpgFileType = NativeFilePicker.ConvertExtensionToFileType( "jpg" );
        // var jpegFileType = NativeFilePicker.ConvertExtensionToFileType( "jpeg" );
        // var bmpFileType = NativeFilePicker.ConvertExtensionToFileType( "bmp" );
        NativeFilePicker.PickFile((path) =>
        {
            filePath = path;
        }, "png,jpg,jpeg,bmp");
#endif
        return filePath; // Note: filePath will be set asynchronously
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
