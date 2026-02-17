using TMPro;
using UnityEngine;
using System.Collections;

public class PhotoCapture : MonoBehaviour
{
    public int filmCount = 10;
    public GameObject flashEffect;
    public TextMeshProUGUI counterText;
    public GameObject flashUI;
    public KeyCode switchKey = KeyCode.Tab;
    public GameObject presentWorld;
    public GameObject pastWorld;

    private bool isPresent = true;

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            SwitchTime();
        }

        if (Input.GetMouseButtonDown(0))
        {
            TakePhoto();
            if (flashUI != null)
            {
                StartCoroutine(FlashUICO());
            }
        }
    }

    void TakePhoto()
    {
        if (filmCount <= 0)
        {
            Debug.Log("Нет плёнки!");
            return;
        }

        filmCount--;
        if (counterText != null)
        {
            counterText.text = filmCount.ToString();
        }
        Debug.Log("Щёлк! Осталось: " + filmCount);

        if (flashEffect != null)
        {
            Instantiate(flashEffect, transform.position, transform.rotation);
        }
    }

    IEnumerator FlashUICO()
    {
        flashUI.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flashUI.SetActive(false);
    }

    void SwitchTime()
    {
        isPresent = !isPresent;
        presentWorld.SetActive(isPresent);
        pastWorld.SetActive(!isPresent);
        Debug.Log(isPresent ? "Настоящее" : "Прошлое");
    }
}