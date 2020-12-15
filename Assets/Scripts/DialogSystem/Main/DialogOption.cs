using UnityEngine;

public delegate bool Availability();
public delegate void DialogAction();
public class DialogOption
{
    public string Text;
    public Availability IsAvaiable;
    public DialogAction Action;

    public DialogOption(string text, Availability availability, DialogAction dialogAction){
        Text = text;
        IsAvaiable = availability;
        Action = dialogAction;
    }
}