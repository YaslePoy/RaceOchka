using System.Numerics;
using Aspose.ThreeD.Entities;
using RaceOchka.ECS;

namespace RaceOchka
{
    internal class Program
    {
        static unsafe void Main(string[] args)
        {
            BigInteger X = new BigInteger();

            var snc = new Aspose.ThreeD.Scene(@"C:\Users\Mimm\Projects\BlenderProjects\cube.fbx");
            var c = snc.RootNode.GetEntity<Mesh>();
            snc.Save("cube.obj", Aspose.ThreeD.FileFormat.WavefrontOBJ);
            var cube = snc.Library[2].FindProperty("ControlPoints").Value;
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
