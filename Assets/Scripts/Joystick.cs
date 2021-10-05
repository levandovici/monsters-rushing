using UnityEngine.UI;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField]
    private Image _circle;
    [SerializeField]
    private Image _outerCircle;
    [SerializeField]
    private float _maxDistance = 150f;

    [SerializeField, Range(0f, 1f)]
    private float _xScreenZoneAt;
    [SerializeField, Range(0f, 1f)]
    private float _xScreenZoneTo;
    [SerializeField, Range(0f, 1f)]
    private float _yScreenZoneAt;
    [SerializeField, Range(0f, 1f)]
    private float _yScreenZoneTo;

    private Vector3 _startPos;
    private bool _started = false;
    private int _id = -1;
    private Vector2 _lastDir = Vector2.zero;

    private Vector2 _screenSize = Vector2.zero;
    private Vector2 _halfScreenSize = Vector2.zero;



    private void Awake()
    {
        Reset();
    }

    private void OnDisable()
    {
        Reset();
    }

    private void Update()
    {
        if (_id == -1)
        {
            int count = Input.touchCount;
            for (int i = 0; i < count; i++)
            {
                Touch t = Input.GetTouch(i);

                Vector3 uiPos = UIPosition(t.position);

                if (InZone(uiPos))
                {
                    _id = i;

                    _startPos = uiPos;

                    SetCirclePos(_startPos);
                    SetOuterPos(_startPos);

                    _circle.enabled = true;
                    _outerCircle.enabled = true;
                    _started = true;

                    break;
                }
            }
        }

        if (_id != -1 && Input.touchCount <= 0)
            Reset();

        if(_id != -1)
            switch (Input.GetTouch(_id).phase)
            {
                case TouchPhase.Ended:
                    Reset();
                    break;

                case TouchPhase.Canceled:
                    Reset();
                    break;

                case TouchPhase.Moved:
                    Vector2 direction = Vector2.ClampMagnitude(UIPosition(Input.GetTouch(_id).position) - _startPos, _maxDistance);
                    SetCirclePos(_startPos + new Vector3(direction.x, direction.y, 0f));
                    break;
            }
    }



    public Vector2 Direction()
    {
        if (_started && _id != -1)
        {
            Vector3 mousePos = UIPosition(Input.GetTouch(_id).position);
            mousePos.x = Mathf.Clamp(mousePos.x, _startPos.x - _maxDistance, _startPos.x + _maxDistance);
            mousePos.y = Mathf.Clamp(mousePos.y, _startPos.y - _maxDistance, _startPos.y + _maxDistance);

            Vector2 dir = mousePos - _startPos;
            dir /= _maxDistance;
            _lastDir = dir;
            return dir;

        }
        else return _lastDir;
    }



    private bool InZone(Vector3 uiPosition)
    {
        if (uiPosition.x > GetScreenSize().x * _xScreenZoneAt - GetHalfScreenSize().x &&
            uiPosition.x < GetScreenSize().x * _xScreenZoneTo - GetHalfScreenSize().x)
        {
            if (uiPosition.y > GetScreenSize().y * _yScreenZoneAt - GetHalfScreenSize().y &&
            uiPosition.y < GetScreenSize().y * _yScreenZoneTo - GetHalfScreenSize().y)
            {
                return true;
            }
        }

        return false;
    } 

    private Vector3 UIPosition(Vector3 mousePos)
    {
        mousePos.z = 0f;
        mousePos -= new Vector3(GetHalfScreenSize().x, GetHalfScreenSize().y, 0f);

        return mousePos;
    }


    private Vector2 GetScreenSize()
    {
        if (_screenSize == Vector2.zero)
            _screenSize = new Vector2(Screen.width, Screen.height);

        return _screenSize;
    }

    private Vector2 GetHalfScreenSize()
    {
        if (_halfScreenSize == Vector2.zero)
            _halfScreenSize = GetScreenSize() * 0.5f;

        return _halfScreenSize;
    }


    private void SetCirclePos(Vector2 pos)
    {
        _circle.rectTransform.localPosition = pos;
    }

    private void SetOuterPos(Vector2 pos)
    {
        _outerCircle.rectTransform.localPosition = pos;
    }


    private void Reset()
    {
        _circle.enabled = false;
        _outerCircle.enabled = false;
        _started = false;
        _id = -1;
    }
} 