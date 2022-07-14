using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatController : MonoBehaviour {


    public TMP_InputField chatInputField;

    public TMP_Text chatDisplayOutput;

    public Scrollbar chatScrollbar;

    void OnEnable()
    {
        chatInputField.onSubmit.AddListener(AddToChatOutput);
    }

    void OnDisable()
    {
        chatInputField.onSubmit.RemoveListener(AddToChatOutput);
    }


    void AddToChatOutput(string newText)
    {
        // Clear Input Field
        chatInputField.text = string.Empty;

        var timeNow = System.DateTime.Now;

        string formattedInput = "[<#FFFF80>" + timeNow.Hour.ToString("d2") + ":" + timeNow.Minute.ToString("d2") + ":" + timeNow.Second.ToString("d2") + "</color>] " + newText;

        if (chatDisplayOutput != null)
        {
            // No special formatting for first entry
            // Add line feed before each subsequent entries
            if (chatDisplayOutput.text == string.Empty)
                chatDisplayOutput.text = formattedInput;
            else
                chatDisplayOutput.text += "\n" + formattedInput;
        }

        // Keep Chat input field active
        chatInputField.ActivateInputField();

        // Set the scrollbar to the bottom when next text is submitted.
        chatScrollbar.value = 0;
    }

}
