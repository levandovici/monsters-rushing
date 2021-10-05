using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vocabulary;

public class GameUIManager : MonoBehaviour
{
    [SerializeField]
    private GameUIPanel _game;
    [SerializeField]
    private PauseUIPanel _pause;
    [SerializeField]
    private OverUIPanel _over;
    [SerializeField]
    private NewLifeUIPanel _newLife;



    public GameUIPanel Game => _game;

    public PauseUIPanel Pause => _pause;

    public OverUIPanel Over => _over;

    public NewLifeUIPanel NewLife => _newLife;



    public void OpenGame()
    {
        _game.Show();
        _pause.Hide();
        _over.Hide();
        _newLife.Hide();
    }

    public void OpenPause()
    {
        _pause.Show();
        _game.Hide();
        _over.Hide();
        _newLife.Hide();
    }

    public void OpenOver()
    {
        _over.Show();
        _game.Hide();
        _pause.Hide();
        _newLife.Hide();
    }

    public void OpenNewLife()
    {
        _newLife.Show();
        _game.Hide();
        _pause.Hide();
        _over.Hide();
    }



    public void SetLanguage(SystemLanguage language)
    {
        _game.SetLanguage(language);
        _pause.SetLanguage(language);
        _over.SetLanguage(language);

        _pause.SetTitle(Words.GetWord(Word.pause, language));
        _newLife.SetTitle(Words.GetWord(Word.continue_for, language));
        _over.SetTitle(Words.GetWord(Word.game_over, language));
    }
}