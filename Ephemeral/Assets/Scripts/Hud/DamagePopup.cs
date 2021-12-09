using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    private float dissapearTimer;
    private Color textColor;
    // Start is called before the first frame update

    void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }
    public static DamagePopup CreateDamagePopup(Vector3 position, int damageAmount)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.SetText(damageAmount);
        return damagePopup;
    }
    public static DamagePopup CreateDamagePopup(Vector3 position, int damageAmount, Color fontColor, int fontSize)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.SetText(damageAmount,fontColor,fontSize);
        return damagePopup;
    }
    public void SetText(int damage)
    {
        _textMeshPro.SetText(damage.ToString());
        textColor = _textMeshPro.color;
        dissapearTimer = 1f;
    }
    public void SetText(int damage,Color color, int fontSize)
    {
        _textMeshPro.SetText(damage.ToString());
        _textMeshPro.color = color;
        _textMeshPro.fontSize = fontSize;
        textColor = _textMeshPro.color;
        dissapearTimer = 1f;
    }

    private void Update()
    {
        float moveYSpeed = 0.2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        dissapearTimer -= Time.deltaTime;
        if(dissapearTimer < 0) //Fade out
        {
            float dissapearSpeed = 3f;
            textColor.a -= dissapearSpeed * Time.deltaTime;
            _textMeshPro.color = textColor;
            if (_textMeshPro.color.a <= 0) Destroy(gameObject);
        }

    }
}
