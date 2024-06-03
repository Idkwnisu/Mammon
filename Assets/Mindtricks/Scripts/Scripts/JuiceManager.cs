using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JuiceManager : MonoBehaviour
{
    public static JuiceManager Instance { get; private set; }
    public Color hitColor;
    public float hitTime;
    public float backTime;

    public Vector3 moveToTextEnemyHit;
    public Vector3 moveToTextPlayerHit;
    public float damageHitTime;
    public float damageHitTimePlayer;

    public TMP_Text damageText;
    public TMP_Text damageTextPlayer;
    public RectTransform lifeText;

    private Color transparent;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        transparent = new Color(0, 0, 0, 0);
    }


    public SpriteRenderer enemy;
    public Image wholeScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetEnemy(GameObject newEnemy)
    {
        enemy = newEnemy.GetComponent<SpriteRenderer>();
    }

    public void HitEnemy(int damage)
    {
        LeanTween.color(enemy.gameObject, hitColor, hitTime).setEase(LeanTweenType.easeInCubic);
        LeanTween.color(enemy.gameObject, Color.white, backTime).setEase(LeanTweenType.easeInExpo).setDelay(hitTime);

        damageText.gameObject.SetActive(true);
        damageText.alpha = 1;

        damageText.text = damage.ToString();
        damageText.transform.position = enemy.transform.position;
        LeanTween.move(damageText.gameObject, enemy.transform.position + moveToTextEnemyHit, damageHitTime).setEase(LeanTweenType.easeOutBounce);
        LeanTween.value(damageText.gameObject, updateCallbackDamageText, 1, 0, 0.5f).setDelay(damageHitTime).setOnComplete(DeactivateDamageText);
    }

    public void HitPlayer(int damage)
    {

        LeanTween.value(wholeScreen.gameObject, updateCallbackScreen, 0, 0.7f, hitTime).setEase(LeanTweenType.easeInCubic);
        LeanTween.value(wholeScreen.gameObject, updateCallbackScreen, 0.7f, 0, backTime).setEase(LeanTweenType.easeInExpo).setDelay(hitTime);

        damageTextPlayer.gameObject.SetActive(true);
        damageTextPlayer.alpha = 1;

        damageTextPlayer.text = damage.ToString();
        damageTextPlayer.transform.position = lifeText.transform.position;
        LeanTween.move(damageTextPlayer.gameObject, lifeText.transform.position + moveToTextPlayerHit, damageHitTimePlayer).setEase(LeanTweenType.easeOutBounce);
        LeanTween.value(damageTextPlayer.gameObject, updateCallbackDamageTextPlayer, 1, 0, 0.5f).setDelay(damageHitTime).setOnComplete(DeactivateDamageTextPlayer);
    }

    public void updateCallbackDamageText(float value)
    {
        damageText.alpha = value;
    }
    public void updateCallbackDamageTextPlayer(float value)
    {
        damageTextPlayer.alpha = value;
    }
    
    public void updateCallbackScreen(float value)
    {
        wholeScreen.color = new Color(wholeScreen.color.r, wholeScreen.color.g, wholeScreen.color.b,value);
    }

    public void DeactivateDamageText()
    {
        damageText.gameObject.SetActive(false);
    }
    public void DeactivateDamageTextPlayer()
    {
        damageTextPlayer.gameObject.SetActive(false);
    }

    public void ScaleJuice(CanvasGroup juiced, float time,float delay, float scale, System.Action onComplete, System.Action<float> onUpdate)
    {
        LeanTween.scale(juiced.gameObject, Vector3.one * scale, time).setDelay(delay).setEase(LeanTweenType.linear).setOnComplete(onComplete);
        LeanTween.alphaCanvas(juiced, 0, time / 3).setDelay(time / 3 * 2).setOnUpdate(onUpdate);
    }


}
