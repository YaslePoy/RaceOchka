namespace RaceOchka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SmallEngine.SetMainRenderTexture([255, 255, 255, 255], 1, 1);
            SmallEngine.InitWindow(1920, 1080);
            SmallEngine.Start();
            while (SmallEngine.GetWindowCloseState() == 0)
            {
                SmallEngine.UpdateKeyboardState();
                SmallEngine.PollWindowEvents();
                if (SmallEngine.IsKeyDown((int)GLFWKeys.Escape))
                {
                    SmallEngine.Close();
                    break;
                }
                SmallEngine.Draw();
            }
        }
    }
}
