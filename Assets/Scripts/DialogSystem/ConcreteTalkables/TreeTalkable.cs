using UnityEngine;
public class TreeTalkable : TalkableObject
{    
    public PlayerStats PlayerStats;

    public TreeTalkable(){
        //if(PlayerStats == null) enabled = false;
    }
    public override void Init()
    {
        var option1 = new DialogOption(
            "Take potion", 
            ()=>{return true;}, 
            ()=>{Debug.Log("Health added");});

        var option2 = new DialogOption(
            "Take super potion (only if strenght higher than 40)", 
            ()=>{return PlayerStats.Strength > 40;}, 
            ()=>{Debug.Log("Health added");});

        var option3 = new DialogOption(
            "Take super-duper potion (only if strenght higher than 70)", 
            ()=>{return PlayerStats.Strength > 70;}, 
            ()=>{Debug.Log("Health added");});

        DialogOptions.Add(option1);
        DialogOptions.Add(option2);
        DialogOptions.Add(option3);
    }
}