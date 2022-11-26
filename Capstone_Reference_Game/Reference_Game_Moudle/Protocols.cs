namespace Capstone_Reference_Game_Module
{

    public static class Protocols
    {
        // 클라이언트 -> 서버 
        public const byte REQ_LOGIN = 1;
        public const byte C_MSG = 10;



        // 서버 -> 클라이언트 
        public const byte S_PING = 101;
        public const byte S_ERROR = 102;
        public const byte S_MSG = 103;
        public const byte RES_LOGIN = 104;

        
    }

    public static class LoginResult
    {
        public const byte FAIL = 0;
        public const byte SUCCESS = 1;
    }

}
