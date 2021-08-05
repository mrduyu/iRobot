namespace iRobot.Planet
{
    public class Surface : ISurface
    {
        private int SurfaceHeight;
        private int SurfaceWidth;
        public void Create(int height, int width)
        {
            SurfaceHeight = height;
            SurfaceWidth = width;
        }
        public int GetSurfaceHeight() { return SurfaceHeight; }

        public int GetSurfaceWidth() { return SurfaceWidth; }
    }
}
