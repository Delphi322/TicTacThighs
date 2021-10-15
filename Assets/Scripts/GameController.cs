using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{

    public Text[] bL;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public GameObject startInfo;

    private string pS;
    private int moveCount;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(false);
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < bL.Length; i++)
        {
            bL[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void SetStartingSide(string startingSide)
    {
        pS = startingSide;
        if (pS == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }

        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    public string GetPlayerSide()
    {
        return pS;
    }

    public void EndTurn()
    {
        moveCount++;

        //horizontal 

        if (bL[0].text == pS && bL[1].text == pS && bL[2].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[1].text == pS && bL[2].text == pS && bL[3].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[4].text == pS && bL[5].text == pS && bL[6].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[5].text == pS && bL[6].text == pS && bL[7].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[8].text == pS && bL[9].text == pS && bL[10].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[9].text == pS && bL[10].text == pS && bL[11].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[12].text == pS && bL[13].text == pS && bL[14].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[13].text == pS && bL[14].text == pS && bL[15].text == pS)
        {
            GameOver(pS);
        }

        //vertical

        else if (bL[0].text == pS && bL[4].text == pS && bL[8].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[4].text == pS && bL[8].text == pS && bL[12].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[1].text == pS && bL[5].text == pS && bL[9].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[5].text == pS && bL[9].text == pS && bL[13].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[2].text == pS && bL[6].text == pS && bL[10].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[6].text == pS && bL[10].text == pS && bL[14].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[3].text == pS && bL[7].text == pS && bL[11].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[7].text == pS && bL[11].text == pS && bL[15].text == pS)
        {
            GameOver(pS);
        }

        //diagonal

        else if (bL[0].text == pS && bL[5].text == pS && bL[10].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[5].text == pS && bL[10].text == pS && bL[15].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[1].text == pS && bL[6].text == pS && bL[11].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[4].text == pS && bL[9].text == pS && bL[14].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[3].text == pS && bL[6].text == pS && bL[9].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[6].text == pS && bL[9].text == pS && bL[12].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[2].text == pS && bL[5].text == pS && bL[8].text == pS)
        {
            GameOver(pS);
        }
        else if (bL[7].text == pS && bL[10].text == pS && bL[13].text == pS)
        {
            GameOver(pS);
        }
        else if (moveCount >= 16)
        {
            GameOver("draw");
        }
        else
        {
            ChangeSides();
        }
    }

    void ChangeSides()
    {
        pS = (pS == "X") ? "O" : "X";
        if (pS == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
            SetPlayerColorsInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restartButton.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);

        for (int i = 0; i < bL.Length; i++)
        {
            bL[i].text = "";
        }
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < bL.Length; i++)
        {
            bL[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetPlayerColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}