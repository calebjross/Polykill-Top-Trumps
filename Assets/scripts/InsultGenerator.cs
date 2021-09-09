using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InsultGenerator : MonoBehaviour
{
    [SerializeField]
    Text theComputerSaid;
    [SerializeField]
    Text insultText;
    [SerializeField]
    Text than;
    [SerializeField]
    Text nameText;
    [SerializeField]
    Text destroyText;

    AudioSource audioSource;

    public bool playAudio = false;

    public int randomInsult;
    public int randomName;

    List<string> insults = new List<string>();
    List<string> names = new List<string>();

    float timer = 8f;
    public bool text1 = false;
    public bool text2 = false;
    public bool text3 = false;
    public bool text4 = false;
    public bool text5 = false;

    // Start is called before the first frame update
    void Awake()
    {

        audioSource = GetComponent<AudioSource>();

        //insults
        insults.Add("smell worse");
        insults.Add("are uglier");
        insults.Add("are weaker");
        insults.Add("are worse at Fortnite");
        insults.Add("are a worse fisherman");
        insults.Add("cry more");
        insults.Add("have less friends");
        insults.Add("smell only slightly worse");
        insults.Add("high-five worse");
        insults.Add("are stupider");
        insults.Add("have a worse game collection");
        insults.Add("are less funny");
        insults.Add("are worse at sports");
        insults.Add("are less mammal-like");
        insults.Add("type worse");
        insults.Add("laugh more annoyingly");
        insults.Add("have uglier shoes");
        insults.Add("will never be cooler");
        insults.Add("are less fashionable");
        insults.Add("have a stupider face");

        //name
        names.Add("Blink");
        names.Add("Briz");
        names.Add("Burgerchamp");
        names.Add("calebjross");
        names.Add("Dylan");
        names.Add("Hashbrown Bear");
        names.Add("Hungry Bill");
        names.Add("HYPEMAN");
        names.Add("Jake");
        names.Add("jay");
        names.Add("Jeffrey");
        names.Add("Musty");
        names.Add("PamD");
        names.Add("PeteePuff");
        names.Add("qx");
        names.Add("Josh");
        names.Add("Round2Gaming");
        names.Add("Senior Diego");
        names.Add("SNESdrunk");
        names.Add("Trav");
    }

    private void Start()
    {
        randomInsult = Random.Range(0, insults.Count);
        randomName = Random.Range(0, names.Count);

        //stop menu music
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 7f && text1 == false)
        {
            theComputerSaid.text = "The Computer Said You";
            PlayAudio();
            text1 = true;
        }
        if (timer <= 6f && text2 == false)
        {
            insultText.text = insults[randomInsult].ToString();
            PlayAudio();
            text2 = true;
        }
        if (timer <= 5f && text3 == false)
        {
            than.text = "than";
            PlayAudio();
            text3 = true;
        }
        if (timer <= 4f && text4 == false)
        {
            PlayAudio();
            nameText.text = names[randomName].ToString();
            text4 = true;
        }
        if (timer <= 2f && text5 == false)
        {
            PlayAudio();
            destroyText.text = "Destroy the Computer";
            text5 = true;
        }
        if (timer <= 0f)
        {
            SceneManager.LoadScene(2);
        }
    }
    void PlayAudio()
    { 
     audioSource.Play(); 
    }
}
