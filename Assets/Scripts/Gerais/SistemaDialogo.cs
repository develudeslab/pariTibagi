using UnityEngine;

public enum STATE {
    DISABLED,
    WAITING,
    TYPING
}

public class SistemaDialogo : MonoBehaviour {

    public DialogueData dialogueData;

    int currentText = 0;
    bool finished = false;

    AnimacaoTexto typeText;

    STATE state;

    void Awake() {

        typeText = FindObjectOfType<AnimacaoTexto>();

        typeText.TypeFinished = OnTypeFinishe;

    }

    void Start() {
        state = STATE.DISABLED;
        Next();
    }
   
    public void Next() {


        typeText.fullText = dialogueData.talkScript[currentText++].text;

        if(currentText == dialogueData.talkScript.Count) finished = true;

        typeText.StartTyping();
        state = STATE.TYPING;

    }

    void OnTypeFinishe() {
        state = STATE.WAITING;
    }
}