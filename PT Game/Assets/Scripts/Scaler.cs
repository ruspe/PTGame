using UnityEngine;
using enableGame;

public class Scaler : MonoBehaviour
{
    public egFloat scaleMultiplier = 1.0f;
    //public egFloat RotationZ = 0.0f;

    [SerializeField]
    private GameObject Paddle;

    void Awake()
    {
        Paddle = this.gameObject;
        VariableHandler.Instance.Register(ParameterStrings.SCALE, scaleMultiplier);
        //VariableHandler.Instance.Register(ParameterStrings.ROTATION_Z, RotationZ);
    }
    
    // Update is called once per frame
    void Update()
    {
        Paddle.transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, scaleMultiplier);
        //Paddle.transform.rotation = Quaternion.Euler(0, 0, RotationZ);
    }
}
