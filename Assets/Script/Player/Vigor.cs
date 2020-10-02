using UnityEngine;
using UnityEngine.UI;

public class Vigor : MonoBehaviour
{
    public int vigorCount;
    float vigorTime;
    public Image[] lights = new Image[5];
    public int vigorCookTime = 1;
    public Text hwalgiValue;
    public GameManager gm;

    void Start()
    {
        vigorCount = 30;
        lights[0].color = new Color(1, 1, 1, 1);
    }

    void Update()
    {
        if (vigorCount > 0)
            vigorTime += Time.deltaTime * vigorCookTime * gm.worldTime;
        if (vigorTime > 1f)
        {
            vigorTime = 0f;
            vigorCount--;
        }
        hwalgiValue.text = vigorCount.ToString();
        lights[0].color = (vigorCount > 0) ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
        lights[1].color = (vigorCount > 19) ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
        lights[2].color = (vigorCount > 39) ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
        lights[3].color = (vigorCount > 59) ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
        lights[4].color = (vigorCount > 79) ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
    }

    public void VigorPlus()
    {
        if (vigorCount < 99)
            vigorCount++;
    }
}
