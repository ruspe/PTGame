using UnityEngine;
using enableGame;

public class BallScaler : MonoBehaviour
{
    public egFloat scaleMultiplier = 1.0f;

    [SerializeField]
    private GameObject Projectile;

    void Awake()
    {   
        Projectile = this.gameObject;
        VariableHandler.Instance.Register(ParameterStrings.SIZE, scaleMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        Projectile.transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, scaleMultiplier);
    }
}
