using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEditor;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    private GameUIManager _UIManager;
    [SerializeField]
    private MapController _map;
    [SerializeField]
    private SoundController _sound;


    private int _distance = 0;
    private bool _bestScore = false;
    private int _destroy = 0;
    private int _special = 0;
    private int _total = 0;
    private bool _x2Water = false;


    private bool _gameOver = false;
    private bool _openOverWasCalled = false;


    [SerializeField]
    private Material _skyboxDay;
    [SerializeField]
    private Transform _sun;

    [SerializeField]
    private Material _skyboxNight;
    [SerializeField]
    private Transform _moon;



    private void Awake()
    {
        _gameOver = false;
        _openOverWasCalled = false;


        long time = 0;
        bool isNetworkTime = TimeManager.GetNetworkTime(out time);

        if (TimeManager.IsHolliday(time) && isNetworkTime)
        {
            _sound.PlayMusic(SoundController.EMusicClip.HolidayMusic);
        }
        else
        {
            _sound.PlayMusic(SoundController.EMusicClip.Music);
        }


        SetSfxVolume(SaveLoadManager.Current.sfxVolume, true, true, false);
        SetMusicVolume(SaveLoadManager.Current.musicVolume, true, true);


        _UIManager.Over.OnQuitClicked += () =>
        {
            QuitMenu();
            _sound.PlaySFX(SoundController.ESFXClip.Click);
        };


        _UIManager.Pause.OnBackClicked += () =>
        {
            OpenGame();
            _sound.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Pause.OnQuitClicked += () =>
        {
            if (!_gameOver)
            {
                _gameOver = true;
                _map.Car.Kill();
                OpenOver(false);
            }
            _sound.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Pause.OnSfxVolumeChanged += (f) => SetSfxVolume(f, true, true, false);
        _UIManager.Pause.OnMusicVolumeChanged += (f) => SetMusicVolume(f, true, true);


        _UIManager.NewLife.OnUseToolBox += () =>
        {
            Inventory.InventoryObject toolBox = null;
            bool isToolBoxExist = SaveLoadManager.Current.inventoryObjects.TryGetClone(Inventory.ToolBox, out toolBox);
            if(isToolBoxExist)
            {
                toolBox.count = 1;
                SaveLoadManager.Current.inventoryObjects.Use(toolBox);

                _map.Destroy(50f);

                _gameOver = false;

                _map.Alive();
                OpenGame();
                _sound.PlaySFX(SoundController.ESFXClip.Click);
            }
            else
            {
                OpenOver();
            }
        };
        _UIManager.NewLife.OnUseFuel += () =>
        {
            Inventory.InventoryObject fuel = null;
            bool isFuelExist = SaveLoadManager.Current.inventoryObjects.TryGetClone(Inventory.Fuel, out fuel);
            if (isFuelExist)
            {
                fuel.count = 1;
                SaveLoadManager.Current.inventoryObjects.Use(fuel);

                _map.Destroy(50f);

                _gameOver = false;

                _map.FillUp();
                OpenGame();
                _sound.PlaySFX(SoundController.ESFXClip.Click);
            }
            else
            {
                OpenOver();
            }
        };
        _UIManager.NewLife.OnTimeYield += () =>
        {
            OpenOver(false);
        };


        _map.OnGameOver += () =>
        {
            if (!_gameOver)
            {
                _map.Destroy(50f);
                _gameOver = true;

                Inventory.InventoryObject toolBox = null;
                bool isToolBoxExist = SaveLoadManager.Current.inventoryObjects.TryGetClone(Inventory.ToolBox, out toolBox);
                Inventory.InventoryObject fuel = null;
                bool isFuelExist = SaveLoadManager.Current.inventoryObjects.TryGetClone(Inventory.Fuel, out fuel);

                if (_map.Car.Health <= 0f && isToolBoxExist && toolBox.count > 0)
                {
                    OpenNewLife(4f, true);
                }
                else if(_map.Car.Fuel <= 0f && _map.Car.Health > 0f && isFuelExist && fuel.count > 0)
                {
                    OpenNewLife(4f, false);
                }
                else
                {
                    OpenOver();
                }
            }
        };
        _map.OnAddWater += (c) => _UIManager.Game.SetAddWater(c);
        _map.SetUp(SaveLoadManager.Current.selectedCar, SaveLoadManager.Current.SelectedCarData);


        _UIManager.Game.OnPauseClicked += () =>
        {
            OpenPause();
            _sound.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Game.OnBrakePointerDown += () =>
        {
            _map.Car.Brake = true;
            _sound.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Game.OnBrakePointerUp += () =>
        {
            _map.Car.Brake = false;
        };
        _UIManager.Game.OnShootPointerDown += () =>
        {
            _map.Car.Gun.Shoot(true);
            _sound.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Game.OnShootPointerUp += () => _map.Car.Gun.Shoot(false);
        _UIManager.Game.OnLeftLineClicked += () =>
        {
            _map.Car.ChangeLineLeft(true);
            _sound.PlaySFX(SoundController.ESFXClip.Click);
        };
        _UIManager.Game.OnRightLineClicked += () =>
        {
            _map.Car.ChangeLineRight(true);
            _sound.PlaySFX(SoundController.ESFXClip.Click);
        };

        _UIManager.SetLanguage(SaveLoadManager.Current.language);
        OpenGame();
    }


    private void Update()
    {
        DateTime dt = DateTime.Now;
        float time = dt.Hour * 3600f + dt.Minute * 60f + dt.Second;

        if (time > 6f * 3600f && time < 21f * 3600f)
        {
            RenderSettings.skybox = _skyboxDay;

            _sun.gameObject.SetActive(true);
            _moon.gameObject.SetActive(false);
        }
        else
        {
            RenderSettings.skybox = _skyboxNight;

            _moon.gameObject.SetActive(true);
            _sun.gameObject.SetActive(false);
        }


        _UIManager.Game.SetDistance(_map.Car.Distance, SaveLoadManager.Current.bestScore);
        _UIManager.Game.SetHealth(_map.Car.Health, _map.Car.MaxHealth);
        _UIManager.Game.SetFuel(_map.Car.Fuel, _map.Car.MaxFuel);
        _UIManager.Game.SetBullets(_map.Car.Bullets, _map.Car.MaxBullets, _map.Car.Reload01);
    }



    private void OnApplicationQuit()
    {
        Quit(false);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            OpenPause();
        }
        else
        {
            OpenGame();
        }
    }



    private void SetSfxVolume(float value, bool speakers, bool uiAndSave, bool withOutMainSfx)
    {
        if (speakers)
            _sound.SetSfxVolume(value, withOutMainSfx);

        if (uiAndSave)
        {
            SaveLoadManager.Current.sfxVolume = value;
            _UIManager.Pause.SetSfxVolume(value);
        }
    }

    private void SetMusicVolume(float value, bool speakers, bool uiAndSave)
    {
        if (speakers)
            _sound.SetMusicVolume(value);

        if (uiAndSave)
        {
            SaveLoadManager.Current.musicVolume = value;
            _UIManager.Pause.SetMusicVolume(value);
        }
    }



    private void Quit(bool andLoadMain)
    {
        if (!_gameOver)
        {
            _gameOver = true;

            OpenOver();
            if (andLoadMain)
                QuitMenu();
        }
    }



    public void OpenGame()
    {
        SetSfxVolume(SaveLoadManager.Current.sfxVolume, true, false, false);

        _UIManager.OpenGame();
        Time.timeScale = 1f;
    }

    public void OpenPause()
    {
        _map.Car.Brake = false;
        _map.Car.Gun.Shoot(false);

        SetSfxVolume(0f, true, false, true);

        _UIManager.OpenPause();
        Time.timeScale = 0f;
    }

    public void OpenOver(bool wait = true)
    {
        if (_openOverWasCalled)
            return;

        _map.Car.Brake = false;
        _map.Car.Gun.Shoot(false);

        SetSfxVolume(0f, true, false, true);

        Time.timeScale = 1f;

        _distance = _map.Distance;
        _destroy = _map.WaterForDestroy;
        _special = _map.WaterForSpecial;
        _total = _distance + _destroy + _special;

        _x2Water = SaveLoadManager.Current.x3Gems;
        if (_x2Water)
            _total = _total * 2;

        bool bestScore = _distance > SaveLoadManager.Current.bestScore;
        if (bestScore)
        {
            SaveLoadManager.Current.bestScore = _distance;
        }


        SaveLoadManager.Current.gems += _total;
        SaveLoadManager.Save();


        StartCoroutine(OpenOverWait(_distance, _bestScore, _destroy, _special, _total, _x2Water, wait));
    }

    public void OpenNewLife(float time, bool toolBoxNoFuel)
    {
            SetSfxVolume(0f, true, false, true);
            StartCoroutine(OpenNewLifeWait(time, toolBoxNoFuel));
    }

    private IEnumerator OpenNewLifeWait(float time, bool toolBoxNoFuel)
    {
        _UIManager.Game.Hide();
        yield return new WaitForSeconds(3f);
        _UIManager.OpenNewLife();
        _UIManager.NewLife.SetUp(time, toolBoxNoFuel);
    }

    private IEnumerator OpenOverWait(int distance, bool bestScore, int destroy, int special, int total, bool x2Water, bool wait)
    {
        _UIManager.Game.Hide();

        yield return new WaitForSeconds(wait ? 2f : 0f);

        _UIManager.OpenOver();
        StartCoroutine(OverAnim(distance, bestScore, destroy, special, total, x2Water));
    }


    public void QuitMenu()
    {
        StopAllCoroutines();

        StartCoroutine(Quit(_distance, _bestScore, _destroy, _special, _total, _x2Water));
    }



    private IEnumerator OverAnim(int distance, bool bestScore, int destroy, int special, int total, bool x2Water)
    {
        _UIManager.Over.SetDistance(0, false);
        _UIManager.Over.SetDestroy(0);
        _UIManager.Over.SetSpecial(0);
        _UIManager.Over.SetTotal(0, false);


        yield return null;

        _sound.PlaySFX(SoundController.ESFXClip.OverNext);

        yield return null;

        float time = 1f;
        float delta = 0f;
        float add = distance * (Time.deltaTime / time);
        while (time > 0f && delta < distance)
        {
            delta += add;
            _UIManager.Over.SetDistance((int)delta, false);
            time -= Time.deltaTime;
            yield return null;
        }

        if (bestScore)
            _sound.PlaySFX(SoundController.ESFXClip.OverNext);

        yield return null;

        _UIManager.Over.SetDistance(distance, bestScore);

        yield return null;

        _sound.PlaySFX(SoundController.ESFXClip.OverNext);

        yield return null;

        time = 1f;
        delta = 0f;
        add = destroy * (Time.deltaTime / time);
        while (time > 0f && delta < destroy)
        {
            delta += add;
            _UIManager.Over.SetDestroy((int)delta);
            time -= Time.deltaTime;
            yield return null;
        }

        _UIManager.Over.SetDestroy(destroy);

        yield return null;

        _sound.PlaySFX(SoundController.ESFXClip.OverNext);

        yield return null;

        time = 1f;
        delta = 0f;
        add = special * (Time.deltaTime / time);
        while (time > 0f && delta < special)
        {
            delta += add;
            _UIManager.Over.SetSpecial((int)delta);
            time -= Time.deltaTime;
            yield return null;
        }

        _UIManager.Over.SetSpecial(special);

        yield return null;

        _sound.PlaySFX(SoundController.ESFXClip.OverNext);

        yield return null;

        time = 1f;
        delta = 0f;
        add = total * (Time.deltaTime / time);
        while (time > 0f && delta < total)
        {
            delta += add;
            _UIManager.Over.SetTotal((int)delta, false);
            time -= Time.deltaTime;
            yield return null;
        }

        if (x2Water)
            _sound.PlaySFX(SoundController.ESFXClip.OverNext);

        yield return null;

        _UIManager.Over.SetTotal(total, x2Water);
    }

    private IEnumerator Quit(int distance, bool bestScore, int destroy, int special, int total, bool x2Water)
    {
        _sound.PlaySFX(SoundController.ESFXClip.OverNext);
        yield return null;
        _UIManager.Over.SetDistance(distance, bestScore);

        _sound.PlaySFX(SoundController.ESFXClip.OverNext);
        yield return null;
        _UIManager.Over.SetDestroy(destroy);

        _sound.PlaySFX(SoundController.ESFXClip.OverNext);
        yield return null;
        _UIManager.Over.SetSpecial(special);

        _sound.PlaySFX(SoundController.ESFXClip.OverNext);
        yield return null;
        _UIManager.Over.SetTotal(total, x2Water);


        yield return new WaitForSeconds(0.05f);


        SoundController.Clear();
        Loading.ID = 1; //main scene
        SceneManager.LoadScene(0); // laoding scene
    }
}