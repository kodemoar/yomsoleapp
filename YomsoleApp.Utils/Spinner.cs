namespace YomsoleApp.Utils
{
    using static System.Console;

    public class Spinner
    {
        int pos;
        string[] sequences;

        public Spinner()
        {
            sequences = new[] { "-", "\\", "|", "/" };
        }

        public void Spin()
        {
            Write(sequences[++pos % 4]);
            SetCursorPosition(CursorLeft - 1, CursorTop);
        }
    }
}
