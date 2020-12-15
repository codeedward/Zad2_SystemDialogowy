using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TalkableObject : MonoBehaviour
{
    public GameObject PannelToAttachButtons;
    public Button ButtonPrefab;
    public List<DialogOption> DialogOptions = new List<DialogOption>();
    public abstract void Init();

    void Start()
    {
        Init();
        DrawDialogOptions();
    }

    void DrawDialogOptions()
    {
        foreach (var item in DialogOptions)
        {
            var dialogButton = Instantiate(ButtonPrefab) as Button;
            var dialogText = dialogButton.GetComponentInChildren<Text>();
            var dialogImage = dialogButton.GetComponent<Image>();

            if(dialogText != null && dialogImage != null)
            {
                dialogText.text = item.Text;
                dialogButton.onClick.AddListener(()=>item.Action());
                dialogButton.enabled = item.IsAvaiable();
                dialogImage.color = item.IsAvaiable() ? Color.green : Color.red;
                dialogButton.transform.SetParent(PannelToAttachButtons.transform, false);
            }
        }
    }
}