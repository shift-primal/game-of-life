public static class Log
{
    public static void Write(object msg) => File.AppendAllText("debug.log", $"{msg}\n");
}
