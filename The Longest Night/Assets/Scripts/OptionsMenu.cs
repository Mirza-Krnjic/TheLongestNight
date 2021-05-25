using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject VisualPanel;
    [SerializeField] GameObject SoundPanel;
    [SerializeField] GameObject HelpPanel;
    [SerializeField] GameObject DifficultyPanel;
    [SerializeField] GameObject BackToMenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = true;
        //Time.timeScale = 0;

        VisualPanel.gameObject.SetActive(true);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Visuals()
    {
        VisualPanel.gameObject.SetActive(true);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Sounds()
    {
        VisualPanel.gameObject.SetActive(false);
        SoundPanel.gameObject.SetActive(true);
        HelpPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Help()
    {
        VisualPanel.gameObject.SetActive(false);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(true);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void Difficulty()
    {
        VisualPanel.gameObject.SetActive(false);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(true);
        BackToMenuPanel.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        VisualPanel.gameObject.SetActive(false);
        SoundPanel.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(false);
        DifficultyPanel.gameObject.SetActive(false);
        BackToMenuPanel.gameObject.SetActive(true);
    }
}
