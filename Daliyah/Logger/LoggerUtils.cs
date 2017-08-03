using System.ComponentModel;

namespace Daliyah.Logger
{
    public static class LoggerUtils
    {
        public static string CheckLogType(LogType type)
        {
            string msgtype;
            switch (type)
            {
                case LogType.Log:
                    msgtype = "Log";
                    break;

                case LogType.Warn:
                    msgtype = "Warn";
                    break;

                case LogType.Error:
                    msgtype = "Error";
                    break;

                default:
                    throw new InvalidEnumArgumentException($@"Invalid logtype passed. {type}");
            }
            return msgtype;
        }
    }
}