using UnityEngine;
using UnityEngine.UI;
public class EnergyMeter : MonoBehaviour
{
    Player player;
    RectTransform Rect;
    public float t;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Rect = GetComponent<RectTransform>();
        t = 0.0f;
    }
    void Update()
    {
        Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Lerp(Rect.sizeDelta.x, player.energy * 5f, t));
        t += 3f * Time.deltaTime;
        if(player.exhausted)
        {
            GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        else
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}