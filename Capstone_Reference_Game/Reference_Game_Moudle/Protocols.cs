namespace Capstone_Reference_Game_Module
{

    public static class Protocols
    {
        // 클라이언트 -> 서버 
        public const byte C_KEY_INPUT = 1;
        public const byte C_LOCATION_SYNC = 2;
        public const byte C_RES_ID = 3;
        public const byte C_ANSWER = 4;

        // 서버 -> 클라이언트 
        public const byte S_PING = 101;
        public const byte S_ERROR = 102;
        public const byte S_ENTER_OTHER_CLIENT = 103;
        public const byte S_REQ_ID = 104;
        public const byte S_USER_INFO = 105;
        public const byte S_USER_INFO_OTHER = 106;
        public const byte S_KEY_INPUT_OTHER = 107;
        public const byte S_LCATION_SYNC_OTHER = 108;
        public const byte S_GAME_INFO = 109;
        public const byte S_GAME_END = 110;
    }

    public static class Keyboard
    {
        public const byte LEFT = 0;
        public const byte RIGHT = 1;
        public const byte UP = 2;
        public const byte DOWN = 3;
    }

    public static class QuizTypes
    {
        public const byte OX_QUIZ = 0;
        public const byte MULTIPLE_QUIZ = 1;
    }
}
