using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Network
{
    public delegate int kcp_output(IntPtr buf, int len, IntPtr kcp, IntPtr user);

    class KCP
    {

#if UNITY_IPHONE && !UNITY_EDITOR
        const string KcpDLL = "__Internal";
#else
        const string KcpDLL = "kcp";
#endif

        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ikcp_check(IntPtr kcp, uint current);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ikcp_create(uint conv, IntPtr user);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ikcp_flush(IntPtr kcp);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ikcp_getconv(IntPtr ptr);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ikcp_input(IntPtr kcp, byte[] data, long size);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ikcp_nodelay(IntPtr kcp, int nodelay, int interval, int resend, int nc);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ikcp_peeksize(IntPtr kcp);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ikcp_recv(IntPtr kcp, byte[] buffer, int len);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ikcp_release(IntPtr kcp);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ikcp_send(IntPtr kcp, byte[] buffer, int len);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ikcp_setminrto(IntPtr ptr, int minrto);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ikcp_setmtu(IntPtr kcp, int mtu);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ikcp_setoutput(IntPtr kcp, kcp_output output);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ikcp_update(IntPtr kcp, uint current);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ikcp_waitsnd(IntPtr kcp);
        [DllImport(KcpDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ikcp_wndsize(IntPtr kcp, int sndwnd, int rcvwnd);

        public static uint Check(IntPtr kcp, uint current)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_check(kcp, current);
        } 

        public static IntPtr Create(uint conv, IntPtr user)
        {
            return ikcp_create(conv, user);
        }

        public static void Flush(IntPtr kcp)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            ikcp_flush(kcp);
        }

        public static uint Getconv(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_getconv(ptr);
        }

        public static int Input(IntPtr kcp, byte[] data, int offset, int size)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_input(kcp, data, size);
        }

        public static int Nodelay(IntPtr kcp, int nodelay, int interval, int resend, int nc)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_nodelay(kcp, nodelay, interval, resend, nc);
        }

        public static int Peeksize(IntPtr kcp)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_peeksize(kcp);
        }

        public static int Recv(IntPtr kcp, byte[] buffer, int len)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_recv(kcp, buffer, len);
        }

        public static void Release(IntPtr kcp)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            ikcp_release(kcp);
        }

        public static int Send(IntPtr kcp, byte[] buffer, int len)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_send(kcp, buffer, len);
        }

        public static void Setminrto(IntPtr kcp, int minrto)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            ikcp_setminrto(kcp, minrto);
        }

        public static int Setmtu(IntPtr kcp, int mtu)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_setmtu(kcp, mtu);
        }

        public static void Setoutput(IntPtr kcp, kcp_output output)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            ikcp_setoutput(kcp, output);
        }

        public static void Update(IntPtr kcp, uint current)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            ikcp_update(kcp, current);
        }

        public static int Waitsnd(IntPtr kcp)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_waitsnd(kcp);
        }

        public static int Wndsize(IntPtr kcp, int sndwnd, int rcvwnd)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            return ikcp_wndsize(kcp, sndwnd, rcvwnd);
        }

        public static void Dispose(IntPtr kcp)
        {
            if (kcp == IntPtr.Zero)
            {
                throw new Exception($"kcp error, kcp point is zero");
            }
            Setoutput(kcp, null);
        }
    }
}




