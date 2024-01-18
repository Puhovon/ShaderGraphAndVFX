using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject disolver;
    [SerializeField, Range(0.01f, 0.1f)] private float disolveStep;

    private Renderer _characterRenderer;
    private bool _isDisolved = false;
    private bool _isTimerSet = false;
    private static readonly int Alpha = Shader.PropertyToID("_Alpha");

    private void Start()
    {
        _characterRenderer = disolver.GetComponent<Renderer>();
        if (_characterRenderer.material.GetFloat(Alpha) != 1)
        {
            _characterRenderer.material.SetFloat(Alpha, 1);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (_isTimerSet)
                StopAllCoroutines();
            
            StartCoroutine(!_isDisolved ? Disolve(_characterRenderer.material) : UnDisolve(_characterRenderer.material));
            _isDisolved = !_isDisolved;
        }
    }

    private IEnumerator Disolve(Material mat)
    {
        _isTimerSet = true;
        float alpha = mat.GetFloat(Alpha);
        while (alpha > 0)
        {
            alpha = mat.GetFloat(Alpha);
            yield return new WaitForSeconds(0.1f);
            mat.SetFloat(Alpha, alpha -= disolveStep);
        }
        _isTimerSet = false;
    }

    private IEnumerator UnDisolve(Material mat)
    {
        _isTimerSet = true;
        float alpha = mat.GetFloat(Alpha);
        while (alpha < 1)
        {
            alpha = mat.GetFloat(Alpha);
            yield return new WaitForSeconds(0.1f);
            mat.SetFloat(Alpha, alpha += disolveStep);
        }

        _isTimerSet = false;
    }
}
