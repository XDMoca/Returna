using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableEntity : MonoBehaviour, IInteractable {

    [SerializeField]
    private string[] Dialogue;

    public Queue<string> GetDialogue()
    {
        Queue<string> dialogue = new Queue<string>();
        foreach (string sentence in Dialogue)
        {
            dialogue.Enqueue(sentence);
        }
        return dialogue;
    }
}
