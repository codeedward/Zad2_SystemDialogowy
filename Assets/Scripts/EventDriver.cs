// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.UI;

// public class EventDriver : MonoBehaviour
// {

//     public GameObject PannelToAttachButtons;
//     public Button ButtonPrefab;
//     public List<DialogOption> DialogOptions;

//     void Start()
//     {
//         foreach (var item in DialogOptions)
//         {
//             var dialogButton = Instantiate(ButtonPrefab) as Button;
//             dialogButton.GetComponentInChildren<Text>().text = item.Text;
//             dialogButton.onClick.AddListener(item.InvokeCallback);
//             dialogButton.transform.SetParent(PannelToAttachButtons.transform, false);

//             // if(item.Availability != null)
//             // foreach (var availability in dialog)
//             // {
//             //     bool test = item.Availability.Invoke<bool>();
//             // }
//         }
//     }
// }

// [System.Serializable]
// public class DialogOption {
//     public string Text;
//     public UnityEvent Reaction;

//     //public UnityEvent Availability;

//     public void InvokeCallback()
//     {
//         Reaction?.Invoke();
//     }
// }





// public class EventDriver : MonoBehaviour
// {

//     public GameObject PannelToAttachButtons;
//     public Button ButtonPrefab;
//     public List<DialogOption> DialogOptions;

//     void Start()
//     {
//         foreach (var item in DialogOptions)
//         {
//             var dialogButton = Instantiate(ButtonPrefab) as Button;
//             dialogButton.GetComponentInChildren<Text>().text = item.Text;
//             dialogButton.onClick.AddListener(item.InvokeCallback);
//             dialogButton.transform.SetParent(PannelToAttachButtons.transform, false);

//             // if(item.Availability != null)
//             // foreach (var availability in dialog)
//             // {
//             //     bool test = item.Availability.Invoke<bool>();
//             // }
//         }
//     }
// }















    