using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private GameObject _dialogueUI;

    internal static DialogueManager Instance;
    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue() {
        yield return new WaitForSecondsRealtime(5.0f);

        _dialogueUI.SetActive(true);

        yield return new WaitForSecondsRealtime(15.0f);

        _dialogueUI.SetActive(false);
    }


    internal void WarnPlayerDialogue() {
        StartCoroutine(ChangeDialogue());
    }

    internal IEnumerator ChangeDialogue() {

        _dialogueUI.SetActive(true);

        _dialogueText.SetText("You have been spotted...quickly neutralize the enemy before they get to you.");
        yield return new WaitForSecondsRealtime(2.5f);

        _dialogueUI.SetActive(false);
    }
}
