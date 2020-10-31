using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private Transform _ground;
    [SerializeField] private Player _player;
    [SerializeField] private float _scaleX;
    [SerializeField] private float _scaleY;

    private RawImage _image;
    private float _imagePositionX;
    private float _imagePositionY;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imagePositionX = _player.transform.position.x / _scaleX;
        _imagePositionY = (_player.transform.position.y - _ground.position.y) / _scaleY;

        _image.uvRect = new Rect(_imagePositionX, _imagePositionY, _image.uvRect.width, _image.uvRect.height);
    }
}
