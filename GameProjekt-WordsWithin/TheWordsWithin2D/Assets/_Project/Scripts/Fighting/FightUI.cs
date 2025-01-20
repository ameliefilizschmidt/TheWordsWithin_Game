using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FightUI : MonoBehaviour
{
    public TextMeshProUGUI top;
    public TextMeshProUGUI win;
    public TextMeshProUGUI loose;

    public GameObject neighbour;
    public GameObject mom;
    public GameObject police;
    public GameObject barkeeper;

    public GameObject self;

    public GameObject NPC;

    public GameObject BF;

    public SpriteRenderer changeThis;

    private void Start()
    {
        switch (Savefile.topText)
        {
            case "NeighbourTopText":
                top.text = "Dein Nachbar möchte seine Gegenstände zurück";
                win.text = "Niemals!";
                loose.text = "Ok";
                neighbour.SetActive(true);
                break;
            case "MutterTopText":
                top.text = "Du versuchst die Mutter zu überzeugen";
                win.text = "Vertrau mir";
                loose.text = "Egal...";
                mom.SetActive(true);;
                break;
            case "PoliceTopText":
                top.text = "Du versuchst die Polizei zu überzeugen";
                win.text = "Lasst mich!";
                loose.text = "Nein!";
                police.SetActive(true);
                break;
            case "WayPoliceTopText":
                top.text = "Du versuchst die Polizei zu überzeugen";
                win.text = "Hau ab!";
                loose.text = "Ich gehe...";
                police.SetActive(true);;
                break;
            case "BarTopText":
                top.text = "Barkeeper: Sieh deinen Fehler doch ein!";
                win.text = "Nein!";
                loose.text = "Ok...";
                barkeeper.SetActive(true);;
                break;
            case "Self":
                top.text = "Stimmt etwas nicht mit mir?";
                win.text = "Nein!";
                loose.text = "Vielleicht...";
                self.SetActive(true);;
                break;
            case "NPC":
                top.text = "Hau ab!";
                win.text = "Selber!";
                loose.text = "Okay...";
                NPC.SetActive(true);;
                break;
            case "BF":
                top.text = "Lass sie in Ruhe!";
                win.text = "Niemals!";
                loose.text = "Okay...";
                BF.SetActive(true);;
                break;
        }
    }
}
