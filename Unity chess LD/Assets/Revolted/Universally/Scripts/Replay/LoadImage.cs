using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadImage : MonoBehaviour
{

    [Header("Image")]
    public RawImage rawImage;

    [Header("Text")]
    public Text inputFieldRoundNumber;
    public Text inputFieldSpeed;
    public TextMeshProUGUI errorMSG;

    [Header("Object")]
    public GameObject ReplayPanel;
    public GameObject InputPanel;
    public GameObject automaticReplayIMG;
    public GameObject replaySpeedTurnOfOn;
    public GameObject manualChangePicturePanel;

    private bool isAutomatic;
    private int roundNumber;
    private int replaySpeed;
    private int pictureNumber;

    void Start()
    {
        ReplayPanel.SetActive(false);
        InputPanel.SetActive(true);
        isAutomatic = true;
    }
    public void StartReplay()
    {
        if (inputFieldRoundNumber.text == "")
        {
            errorMSG.text = "Round number is not set";
            return;
        }

        roundNumber = int.Parse(inputFieldRoundNumber.GetComponent<Text>().text);
        int maxRound = PlayerPrefs.GetInt("folderNumber");
        if (roundNumber > maxRound || roundNumber <= 0)
        {
            errorMSG.text = "Round number dont exist";
            return;
        }

        if (isAutomatic)
        {
            if (inputFieldSpeed.text == "" || int.Parse(inputFieldSpeed.GetComponent<Text>().text) <= 0)
            {
                errorMSG.text = "Round speed is not set";
                return;
            }
            replaySpeed = int.Parse(inputFieldSpeed.GetComponent<Text>().text);
        }

        InputPanel.SetActive(false);
        ReplayPanel.SetActive(true);
        AutomaticStartReplay();
    }

    public void AutomaticStart()
    {
        if (isAutomatic)
        {
            automaticReplayIMG.SetActive(false);
            manualChangePicturePanel.SetActive(true);
            isAutomatic = false;
            replaySpeedTurnOfOn.SetActive(false);

        }
        else
        {
            automaticReplayIMG.SetActive(true);
            manualChangePicturePanel.SetActive(false);
            isAutomatic = true;
            replaySpeedTurnOfOn.SetActive(true);

        }
    }

    public void AutomaticStartReplay()
    {
        pictureNumber++;
        PictureChange(pictureNumber);
        if (rawImage.texture == null)
        {
            EndOfReplay();
        }
        if (isAutomatic)
        {
            Invoke("AutomaticStartReplay", replaySpeed);
        }
    }

    public void PictureNext()
    {
        pictureNumber++;
        PictureChange(pictureNumber);
        if (rawImage.texture == null)
        {
            EndOfReplay();
        }
    }

    public void PicturePrevious()
    {
        pictureNumber--;
        PictureChange(pictureNumber);
        if (rawImage.texture == null)
        {
            EndOfReplay();
        }
    }

    public void PictureChange(int pictureNumber)
    {
        rawImage.texture = Resources.Load("ImageFolderNumber " + roundNumber + "/Camera" + pictureNumber + "Screenshot") as Texture2D;
    }

    public void EndOfReplay()
    {
        rawImage.texture = Resources.Load("ReplayOver") as Texture2D;
    }
}
