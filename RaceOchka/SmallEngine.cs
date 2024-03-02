using System.Numerics;
using System.Runtime.InteropServices;
using RaceOchka.Video;

namespace RaceOchka;

public class SmallEngine
{
    private const string Library =
        @"C:\Users\Mimm\Projects\VisualStudioProjects\RaceOchka\x64\Release\SmallEngine.dll";

    [DllImport(Library)]
    public static extern int Add(int a, int b);

    [DllImport(Library)]
    public static extern void InitWindow(uint width, uint height);

    [DllImport(Library)]
    public static extern void Start();

    [DllImport(Library)]
    public static extern void Close();

    [DllImport(Library)]
    public static extern int GetWindowCloseState();

    [DllImport(Library)]
    public static extern void PollWindowEvents();

    [DllImport(Library)]
    public static extern void Draw();

    [DllImport(Library)]
    public static extern void SetMainRenderTexture([In] [Out] byte[] data, int width, int height);

    [DllImport(Library)]
    public static extern void SetViewSettings(Vector3 from, Vector3 to, Vector3 up, Vector3 sun);

    [DllImport(Library)]
    public static extern void UpdateMainRenderTexture([In] [Out] byte[] data, int width, int height);

    [DllImport(Library)]
    public static extern void SetMeshShaderData([In] [Out] RenderSurface[] polygons, uint surfaceCount);

    [DllImport(Library)]
    public static extern void UpdateKeyboardState();

    [DllImport(Library)]
    public static extern bool IsKeyPressed(int key);

    [DllImport(Library)]
    public static extern bool IsKeyReleased(int key);

    [DllImport(Library)]
    public static extern bool IsKeyDown(int key);

    [DllImport(Library)]
    public static extern bool IsKeyUp(int key);
}