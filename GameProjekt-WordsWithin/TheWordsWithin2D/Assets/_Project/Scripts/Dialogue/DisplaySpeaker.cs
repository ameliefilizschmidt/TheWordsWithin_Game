using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;
using Image = UnityEngine.UI.Image;

public class DisplaySpeaker : MonoBehaviour
{
    public Sprite main;
    public Sprite barkeeper;
    public Sprite girl;
    public Sprite mum;
    public Sprite neighbour;
    public Sprite police;
    public Sprite police2;
    public Sprite bf;
    public Sprite bf2;
    public Sprite empty;

    private void setSprite(Sprite sprite)
    {
        gameObject.GetComponent<Image>().sprite = sprite;
    }

    
    [YarnCommand("setEmpty")]
    public void setEmpty()
    {
        setSprite(empty);
    }
    
    [YarnCommand("setMain")]
    public void setMain()
    {
        setSprite(main);
    }
    
    [YarnCommand("setNeighbour")]
    public void setNeighbour()
    {
        setSprite(neighbour);
    }
    
    [YarnCommand("setBarkeeper")]
    public void setBarkeeper()
    {
        setSprite(barkeeper);
    }
    
    [YarnCommand("setMum")]
    public void setMum()
    {
        setSprite(mum);
    }
    
    [YarnCommand("setPolice")]
    public void setPolice()
    {
        setSprite(police);
    }
    
    [YarnCommand("setGirl")]
    public void setGirl()
    {
        setSprite(girl);
    }
    
    [YarnCommand("setBF")]
    public void setBF()
    {
        setSprite(bf);
    }
    
    [YarnCommand("setBF2")]
    public void setBF2()
    {
        setSprite(bf2);
    }
}
