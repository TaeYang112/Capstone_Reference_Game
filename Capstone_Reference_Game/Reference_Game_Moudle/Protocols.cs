namespace Capstone_Reference_Game_Module
{

    public static class Protocols
    {
        // 클라이언트 -> 서버 
        public const byte C_KEY_INPUT = 1;
        public const byte C_LOCATION_SYNC = 2;
        public const byte C_RES_ID = 3;

        // 서버 -> 클라이언트 
        public const byte S_PING = 101;
        public const byte S_ERROR = 102;
        public const byte S_ENTER_OTHER_CLIENT = 103;
        public const byte S_REQ_ID = 104;

        
    }

}
