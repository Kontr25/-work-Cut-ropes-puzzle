using UnityEngine;
using UnityEngine.UI;

public class Blob : MonoBehaviour
{
    [SerializeField] private Image _img;
    private int _number;

    public void Number(int i)
    {
        _number = i;
        if (PlayerPrefs.GetInt("Creatives") == 0)
        {
            if (i == 0) _img.color = new Color(144 / 255.0f, 255 / 255.0f, 138 / 255.0f, 255f);
            else if (i == 1) _img.color = new Color(255 / 255.0f, 197 / 255.0f, 52 / 255.0f, 255f);
            else if (i == 2) _img.color = new Color(255 / 255.0f, 138 / 255.0f, 242 / 255.0f, 255f);
            else if (i == 3) _img.color = new Color(156 / 255.0f, 138 / 255.0f, 255 / 255.0f, 255f);
            else if (i == 4) _img.color = new Color(255 / 255.0f, 113 / 255.0f, 107 / 255.0f, 255f);
            else if (i == 5) _img.color = new Color(74 / 255.0f, 248f / 255.0f, 239 / 255.0f, 255f);
            else if (i == 6) _img.color = new Color(86 / 255.0f, 88 / 255.0f, 220 / 255.0f, 255f);
        }
        else
        {
            if (i == 0) _img.color = new Color(255 / 255.0f, 100 / 255.0f, 88 / 255.0f, 255f);
            else if (i == 1) _img.color = new Color(133 / 255.0f, 133 / 255.0f, 133 / 255.0f, 255f);
            else if (i == 2) _img.color = new Color(53 / 255.0f, 173 / 255.0f, 238 / 255.0f, 255f);
            else if (i == 3) _img.color = new Color(52 / 255.0f, 200 / 255.0f, 255 / 255.0f, 255f);
            else if (i == 4) _img.color = new Color(113 / 255.0f, 248 / 255.0f, 67 / 255.0f, 255f);
            else if (i == 5) _img.color = new Color(113 / 255.0f, 248f / 255.0f, 67 / 255.0f, 255f);
            else if (i == 6) _img.color = new Color(255 / 255.0f, 66 / 255.0f, 65 / 255.0f, 255f);
        }
    }
}
