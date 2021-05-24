using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    private Animator Anim;
    private GameObject Hair;

    public GameObject Zombie1;
    public GameObject Zombie2;
    public GameObject Zombie3;
    public GameObject Zombie4;

    public GameObject Zombie3Hair;
    public GameObject Zombie4Hair;

    public GameObject HairOnButton;
    public GameObject HairOffButton;

    public Slider RotateSlider;

    private float RotationValue = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Zombie1.gameObject.SetActive(true);
        Zombie2.gameObject.SetActive(false);
        Zombie3.gameObject.SetActive(false);
        Zombie4.gameObject.SetActive(false);
        StartCoroutine(SetAnimator());
    }

    // Update is called once per frame
    void Update()
    {
        Zombie1.gameObject.transform.Rotate(0, RotationValue, 0);
        Zombie2.gameObject.transform.Rotate(0, RotationValue, 0);
        Zombie3.gameObject.transform.Rotate(0, RotationValue, 0);
        Zombie4.gameObject.transform.Rotate(0, RotationValue, 0);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void RotateMe()
    {
        RotationValue = RotateSlider.value;

    }

    public void Zombie1On()
    {
        Zombie1.gameObject.SetActive(true);
        Zombie2.gameObject.SetActive(false);
        Zombie3.gameObject.SetActive(false);
        Zombie4.gameObject.SetActive(false);
        Anim = Zombie1.gameObject.GetComponent<Animator>();
        HairOnButton.gameObject.SetActive(false);
        HairOffButton.gameObject.SetActive(false);
    }

    public void Zombie2On()
    {
        Zombie1.gameObject.SetActive(false);
        Zombie2.gameObject.SetActive(true);
        Zombie3.gameObject.SetActive(false);
        Zombie4.gameObject.SetActive(false);
        Anim = Zombie2.gameObject.GetComponent<Animator>();
        HairOnButton.gameObject.SetActive(false);
        HairOffButton.gameObject.SetActive(false);
    }

    public void Zombie3On()
    {
        Zombie1.gameObject.SetActive(false);
        Zombie2.gameObject.SetActive(false);
        Zombie3.gameObject.SetActive(true);
        Zombie4.gameObject.SetActive(false);
        Anim = Zombie3.gameObject.GetComponent<Animator>();
        HairOnButton.gameObject.SetActive(true);
        HairOffButton.gameObject.SetActive(true);
        Hair = Zombie3Hair;
    }

    public void Zombie4On()
    {
        Zombie1.gameObject.SetActive(false);
        Zombie2.gameObject.SetActive(false);
        Zombie3.gameObject.SetActive(false);
        Zombie4.gameObject.SetActive(true);
        Anim = Zombie4.gameObject.GetComponent<Animator>();
        HairOnButton.gameObject.SetActive(true);
        HairOffButton.gameObject.SetActive(true);
        Hair = Zombie4Hair;
    }

    public void HairOn()
    {
        Hair.gameObject.SetActive(true);
    }

    public void HairOff()
    {
        Hair.gameObject.SetActive(false);
    }

    public void Idle()
    {
        Anim.SetTrigger("Idle");
    }

    public void Walk()
    {
        Anim.SetTrigger("Walk");
    }

    public void Death()
    {
        Anim.SetTrigger("Death");
    }

    public void Attack()
    {
        Anim.SetTrigger("Attack");
    }

    public void Shuffle()
    {
        Anim.SetTrigger("Shuffle");
    }

    public void Crawl()
    {
        Anim.SetTrigger("Crawl");
    }

    public void React()
    {
        Anim.SetTrigger("React");
    }

    public void Biting()
    {
        Anim.SetTrigger("Biting");
    }

    IEnumerator SetAnimator()
    {
        yield return new WaitForSeconds(1.0f);
        Anim = Zombie1.gameObject.GetComponent<Animator>();
        Anim.SetTrigger("Idle");
    }
}
