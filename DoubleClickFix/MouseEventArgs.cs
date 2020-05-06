namespace DoubleClickFix
{
    public class MouseEventArgs
    {
        public bool IsBlocked { get; set; }
        public uint Timestamp { get; set; }
        public uint TimeDiff { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Win32.MouseInputNotification MouseEvent { get; set; }
    }
}
