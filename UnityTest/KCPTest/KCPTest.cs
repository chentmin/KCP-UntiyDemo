using UnityEngine;

namespace Assets.UnityTest.KCPTest
{
    public class KCPTest:MonoBehaviour
    {
        private KCPPlayer p1, p2;

        void Awake()
        {
            //Debuger.EnableLog = true;

            //Debug.Log("Awake()");

            p1 = new KCPPlayer();
            p1.Init("Player1", 18888, 19999,"client",1);

            p2 = new KCPPlayer();
            p2.Init("Player2", 19999, 18888,"server",2);
            
        }

        void Update()
        {
            p1.OnUpdate();
            p2.OnUpdate();
        }

        void OnGUI()
        {
            if (GUILayout.Button("Player1 SendMessage"))
            {
                p1.SendMessage("Hello");
            }

            if (GUILayout.Button("Player2 SendMessage"))
            {
                p2.SendMessage("Hi");
            }
        }
    }

}

