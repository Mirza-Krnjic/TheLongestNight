using UnityEngine;

public class Donate : MonoBehaviour
{
    [SerializeField] string link;

    public void openLink()
    {
        Application.OpenURL(link);
    }
}
