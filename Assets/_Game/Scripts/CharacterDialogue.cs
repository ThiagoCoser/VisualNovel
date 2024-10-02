using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data.Common;


public class CharacterDialogue : MonoBehaviour
{

    // Variáveis públicas
    public int playerState;
    public Image _portrait;
    public Sprite portraitA;
    public Sprite portraitB;

    public GameObject NCP_01Avatar;

    public TextMeshProUGUI _dialogueText;
    public Button nextButton;

    public AudioSource textTypeSound;


    // public AudioClip som1;
    // public AudioClip som2;

    //private GameObject soundNext;

    private string[] sentences;
    private int index;

    private float typingSpeed = 0.03f;
    private bool canSpeed = true;


    private void Start()
    {
        // myAudio = gameObject.GetComponent<AudioSource>();

    }
    void OnEnable()

    {

        index = 0;
        UpdateDialogues();
        nextButton.onClick.AddListener(OnNextButtonClicked);

    }

    private void OnNextButtonClicked()
    {
        if (canSpeed == true)
        {
            StopAllCoroutines();
            _dialogueText.text = sentences[index];
            canSpeed = false;
        }
        else
        {
            //  myAudio.Play();
            //   GameObject.Find("soundNext").GetComponent<AudioSource>().Play();
            canSpeed = true;
            StopAllCoroutines();
            NextSentence();
        }
    }

    void OnDisable()
    {
        nextButton.onClick.RemoveListener(OnNextButtonClicked);
    }

    // private void Update()
    // {


    //     if (Input.GetButtonDown("Grab") && canSpeed == true)
    //     {
    //         StopAllCoroutines();
    //         _dialogueText.text = sentences[index];
    //         canSpeed = false;

    //     }

    //     else if (Input.GetButtonDown("Grab") && canSpeed == false)
    //     {
    //         GameObject.Find("soundNext").GetComponent<AudioSource>().Play();
    //         canSpeed = true;
    //         StopAllCoroutines();
    //         NextSentence();
    //     }
    // }


    IEnumerator Type()
    {

        //   myAudio.Play();
        _dialogueText.text = string.Empty;

        foreach (char letter in sentences[index].ToCharArray())
        {
            _dialogueText.text += letter;
            textTypeSound.Play();

            yield return new WaitForSeconds(typingSpeed);
        }

        canSpeed = false;
    }


    public void NextSentence()
    {

        if (index < sentences.Length - 1)
        {

            index++;

            _dialogueText.text = string.Empty;
            StopAllCoroutines();
            StartCoroutine(Type());
        }

        else
        {
            //END
            if (playerState == 0)
            {
                playerState = 1;
                index = 0;
                UpdateDialogues();
                // NextSentence();


            }

            else if (playerState == 1)
            {
                playerState = 2;
                _dialogueText.text = sentences[0];
                index = 0;
                gameObject.SetActive(false);
                NCP_01Avatar.SetActive(true);
                // UpdateDialogues();

            }

            else if (playerState == 2)
            {
                playerState = 3;
                _dialogueText.text = sentences[0];
                index = 0;
                gameObject.SetActive(false);
                // UpdateDialogues();

            }



        }
    }


    private void UpdateDialogues()
    {
        _dialogueText.text = string.Empty;
        _dialogueText.text = "";
        index = 0;

        if (playerState == 0)

        {
            _portrait.sprite = portraitA;
            //  myAudio.clip = som1;
            //  myAudio.Play();
            index = 0;
            sentences = new string[4];
            sentences[0] = "1.1 - Olá";
            sentences[1] = "1.2 - Isto é um teste";
            sentences[2] = "1.3 - Está funcionando";
            sentences[3] = "1.4 - Este é o final do primeiro bloco de texto. Irá chamar automaticamente o segundo bloco.";

            _dialogueText.text = sentences[0];
            StartCoroutine(Type());

        }

        else if (playerState == 1)
        {
            _portrait.sprite = portraitB;
            //  myAudio.clip = som2;
            // myAudio.Play();
            index = 0;
            sentences = new string[3];
            sentences[0] = "2-1. Isto é o segundo bloco de texto.";
            sentences[1] = "2-2 Que continua aqui.";
            sentences[2] = "2-3 No final eu irei sumir e chamar o primeiro NPC";

            _dialogueText.text = sentences[0];

            StartCoroutine(Type());

        }

        else if (playerState == 2)
        {

            //  myAudio.clip = som2;
            // myAudio.Play();
            index = 0;
            sentences = new string[3];

            if (GameData.goodKarma == 1)
            {
                _portrait.sprite = portraitB;
                sentences[0] = "Isto é o teste 3-1 de karma bom";
                sentences[1] = "Isto é o teste 3-2 de karma bom";
                sentences[2] = "Isto é o teste 3-3 de karma bom";
            }

            if (GameData.badKarma == 1)
            {
                _portrait.sprite = portraitA;
                sentences[0] = "Isto é o teste 3-1 de karma ruim";
                sentences[1] = "Isto é o teste 3-2 de karma ruim";
                sentences[2] = "Isto é o teste 3-3 de karma ruim";
            }


            _dialogueText.text = sentences[0];

            StartCoroutine(Type());

        }



    }
}
