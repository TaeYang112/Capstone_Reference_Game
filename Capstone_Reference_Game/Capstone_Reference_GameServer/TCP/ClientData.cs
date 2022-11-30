﻿using System.Net.Sockets;

// -----------------
// ----- 서버 ------
// -----------------

namespace Capstone_Reference_GameServer.TCP
{
    // 클라이언트를 표현하는 클래스
    public class ClientData
    {
        // TCP 통신에서 TcpServer에 대응되는 클라이언트 객체
        public TcpClient client { get; set; }

        // 메시지를 받을 때 사용하는 버퍼
        public byte[] byteData { get; set; }                                                

        public int Key { get; set; }

        public ClientData(TcpClient client)
        {
            this.client = client;
            byteData = new byte[5];
        }

        ~ClientData()
        {
            client.Close();
            client.Dispose();
        }
    }
}
