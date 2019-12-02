using System.Net;
using System.Net.Sockets;
using System.Text;
using Network;
using UnityEngine;
using System.Runtime.InteropServices;

namespace Assets.UnityTest.KCPTest
{
    public class KCPPlayer
    {
        public string LOG_TAG = "KCPPlayer";

        private KCPSocket m_Socket;
        private string m_Name;
        private int m_MsgId = 0;
        private IPEndPoint m_RemotePoint;

        public void Init(string name, int localPort, int remotePort,string netType,uint kcpKey)
        {

            //string str = "aa";

            //System.IntPtr init = Marshal.StringToHGlobalAnsi(str);

            //string ss = Marshal.PtrToStringAnsi(init);


            //Debug.Log("测试指针转字符串 -------------------------"+ ss);
            m_Name = name;
            LOG_TAG = "KCPPlayer[" + m_Name + "]";

            IPAddress ipa = IPAddress.Parse(IPManager.GetIP(ADDRESSFAM.IPv4));
            m_RemotePoint = new IPEndPoint(ipa, remotePort);

            m_Socket = new KCPSocket(localPort, kcpKey, netType, AddressFamily.InterNetwork);
            m_Socket.AddReceiveListener(KCPSocket.IPEP_Any, OnReceiveAny);
            m_Socket.AddReceiveListener(m_RemotePoint, OnReceive);

            Debug.Log("创建KCP测试端  Init  ----------------- ");
        }

        private void OnReceiveAny(byte[] buffer, int size, IPEndPoint remotePoint)
        {
            string str = Encoding.UTF8.GetString(buffer, 0, size);
            Debug.Log("OnReceiveAny() " + remotePoint + ":" + str);
        }

        private void OnReceive(byte[] buffer, int size, IPEndPoint remotePoint)
        {
            string str = Encoding.UTF8.GetString(buffer, 0, size);
            Debug.Log("OnReceive() " + remotePoint + ":" + str);
        }

        public void OnUpdate()
        {
            if (m_Socket != null)
            {
                m_Socket.Update();
            }
        }

        public void SendMessage(string message)
        {
            if (m_Socket != null)
            {
                m_MsgId++;
                m_Socket.SendTo(message, m_RemotePoint);
            }
        }
    }
}
