using UnityEngine;



public class EnemyController : MonoBehaviour
{
    private Material _material;

    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        UIController._changeColor += ChangeColor;
    }

    public void ChangeColor()
    {
        Color newColor = new Color(
            UnityEngine.Random.Range(0,1f),
            UnityEngine.Random.Range(0,1f),
            UnityEngine.Random.Range(0,1f));
        _material.color = newColor;
    }
}
