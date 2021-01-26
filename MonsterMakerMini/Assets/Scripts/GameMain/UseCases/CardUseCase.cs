using System.Collections;
using UnityEngine;

public class CardUseCase : MonoBehaviour
{
    [SerializeField] private float rotateAngle = 1;
    // Start is called before the first frame update
    private Vector3 _angles;
    private CardView _cardView;
    private bool _isStopCoin = false;
    void Start()
    {
        _angles = new Vector3(rotateAngle, 0, 0);
        _cardView = GetComponent<CardView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(TurnCard());
        }
    }

    private void CoTurnCard()
    {
        StartCoroutine(TurnCard());
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator TurnCard()
    {
        var counter = 0;
        while (counter < 90)
        {
            counter += (int)rotateAngle;
            transform.Rotate(_angles);
            yield return null;
        }

        transform.Rotate(new Vector3(180,0,0));
        _cardView.ChangeSprite();
        counter = 0;
        while (counter < 90)
        {
            counter += (int)rotateAngle;
            transform.Rotate(_angles);
            yield return null;
        }
    }
}
