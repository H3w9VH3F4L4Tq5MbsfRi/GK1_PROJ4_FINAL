using FastBitmapLib;
using System;
using System.Globalization;
using System.Numerics;
using System.Windows.Forms;

namespace GK1_PROJ4_FINAL
{
    public partial class Form : System.Windows.Forms.Form
    {
        private List<Figure> figures;
        private Bitmap drawArea;
        private Color canvasColor = Color.White;
        private bool dayNightReverse = false;
        private bool terminate;
        private Vector3 stationaryCamera = new Vector3(0.00001F, 0.00001F, -11);
        private static Vector3 cameraTarget = new Vector3(0, 0, 0);
        private static Vector3 cameraVector = new Vector3(0, -1, -1);
        private const int maxVerticies = 3;
        private float pov = 1.047197176756411F;
        private static (int x, int y, int z) light = (0, 0, 10);
        private static Vector3 lightColor = new Vector3(1, 1, 1);
        private static Vector3 vv = new Vector3(0, 0, 1);
        private float currAngle = 0;
        private const float angleStep = 0.1F;
        private float dddd = 0;
        private int colorStep = 2;
        public Form()
        {
            InitializeComponent();
            figures = new List<Figure>();
            terminate = false;
            drawArea = new Bitmap(canvas.Size.Width, canvas.Size.Height);
            canvas.Image = drawArea;
            using (Graphics g = Graphics.FromImage(drawArea))
                g.Clear(canvasColor);
            loadFiles();
            launchKernel();
        }
        private void optionsRbutton_Click(object sender, EventArgs e)
        {
            ((RadioButton)sender).Checked = !((RadioButton)sender).Checked;
        }
        private void loadFiles()
        {
            //Random r = new Random();
            processFile(System.IO.Path.GetFullPath(@"..\..\..\") + "figures\\cone.obj", Color.Blue, 1, 1, 1);
            processFile(System.IO.Path.GetFullPath(@"..\..\..\") + "figures\\crystal.obj", Color.Red, 1, 1, 1);
            processFile(System.IO.Path.GetFullPath(@"..\..\..\") + "figures\\cube.obj", Color.Yellow, 1, 1, 1);
            processFile(System.IO.Path.GetFullPath(@"..\..\..\") + "figures\\sphere.obj", Color.Purple, 1, 1, 1);
            processFile(System.IO.Path.GetFullPath(@"..\..\..\") + "figures\\torus.obj", Color.Cyan, 1, 1, 1);
            processFile(System.IO.Path.GetFullPath(@"..\..\..\") + "figures\\pyramid.obj", Color.Green, 1, 1, 1);
        }
        private bool processFile(string path, Color c, double ks, double kd, double m)
        {
            string[] parts;
            string[] parts2;
            float x = 0;
            float y = 0;
            float z = 0;
            int v = 0;
            int vn = 0;
            figures.Add(new Figure(c, (float)ks, (float)kd, m >= 0.01 ? (float)(m * 100) : 1));
            int indx = figures.Count - 1;

            try
            {
                foreach (string line in File.ReadLines(path))
                {
                    parts = line.Split(' ');

                    switch (parts[0])
                    {
                        case "v":
                            {
                                x = float.Parse(parts[1], CultureInfo.InvariantCulture);
                                y = float.Parse(parts[2], CultureInfo.InvariantCulture);
                                z = float.Parse(parts[3], CultureInfo.InvariantCulture);
                                figures[indx].vertices.Add(new Vertex(x, y, z));
                                break;
                            }
                        case "vn":
                            {
                                x = float.Parse(parts[1], CultureInfo.InvariantCulture);
                                y = float.Parse(parts[2], CultureInfo.InvariantCulture);
                                z = float.Parse(parts[3], CultureInfo.InvariantCulture);
                                figures[indx].normals.Add(new Vector3(x, y, z));
                                break;
                            }
                        case "f":
                            {
                                figures[indx].polygons.Add(new Polygon());
                                for (int i = 1; i < parts.Length; i++)
                                {
                                    parts2 = parts[i].Split('/');
                                    v = int.Parse(parts2[0], CultureInfo.InvariantCulture) - 1;
                                    vn = int.Parse(parts2[2], CultureInfo.InvariantCulture) - 1;
                                    figures[indx].vertices[v].normal = figures[indx].normals[vn];
                                    figures[indx].polygons[figures[indx].polygons.Count - 1].verticies.Add(figures[indx].vertices[v]);
                                }
                                break;
                            }
                        default:
                            {
                                // exeption maybe?
                                break;
                            }
                    }
                }

                if (figures[indx].vertices.Count > 0 && figures[indx].normals.Count > 0 && figures[indx].polygons.Count > 0)
                    return true;
                else
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Unable to load provided .obj file.", "Exeption while loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void launchKernel()
        {
            Thread t = new Thread(new ThreadStart(animation));
            t.Start();
        }
        private void animation()
        {
            Thread.Sleep(1000);

            while (!terminate)
                if (animationRbutton.Checked)
                {
                    if(dayNightRbutton.Checked)
                    {
                        if (!dayNightReverse)
                        {
                            canvasColor = Color.FromArgb(canvasColor.A, canvasColor.R - colorStep, canvasColor.G - colorStep, canvasColor.B - colorStep);
                            if (canvasColor.R < colorStep)
                                dayNightReverse = true;
                        }
                        else
                        {
                            canvasColor = Color.FromArgb(canvasColor.A, canvasColor.R + colorStep, canvasColor.G + colorStep, canvasColor.B + colorStep);
                            if (canvasColor.R + colorStep > 255)
                                dayNightReverse= false;
                        }
                    }
                    dddd = dddd + 0.1F;
                    currAngle = (float)(currAngle % (2 * Math.PI));
                    repaint();
                }  
                
            return;
        }
        private void repaint()
        {
            List<Figure> figuresMod = new List<Figure>();

            Matrix4x4 modelMatrix = Matrix4x4.CreateRotationX(0);
            Matrix4x4 viewMatrix = Matrix4x4.CreateLookAt(stationaryCamera, cameraTarget, cameraVector);
            Matrix4x4 projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(pov, (float)canvas.Width / (float)canvas.Height, 1, 9999999);

            for (int i = 0; i < figures.Count - 1; i++)
            {
                figuresMod.Add(new Figure(figures[i].col, figures[i].ks, figures[i].kd, figures[i].m));

                foreach (var pe in figures[i].polygons)
                {
                    Polygon p = calcViewPolygon(pe, modelMatrix, viewMatrix, projectionMatrix);

                    bool outOfBounds = false;
                    foreach (var v in p.verticies)
                        if (v.x < 0 || v.x >= canvas.Width || v.y < 0 || v.y >= canvas.Height)
                        {
                            outOfBounds = true;
                            break;
                        }
                    if (outOfBounds)
                        continue;

                    figuresMod[i].polygons.Add(p);
                }
            }

            figuresMod.Add(new Figure(figures[figures.Count - 1].col, figures[figures.Count - 1].ks, figures[figures.Count - 1].kd, figures[figures.Count - 1].m));
            Matrix4x4 modelMatrix2 = Matrix4x4.CreateTranslation(new Vector3(-dddd, dddd, 0));

            foreach (var pe in figures[figures.Count - 1].polygons)
            {
                Polygon p = calcViewPolygon(pe, modelMatrix2, viewMatrix, projectionMatrix);

                bool outOfBounds = false;
                foreach (var v in p.verticies)
                    if (v.x < 0 || v.x >= canvas.Width || v.y < 0 || v.y >= canvas.Height)
                    {
                        outOfBounds = true;
                        break;
                    }
                if (outOfBounds)
                    continue;

                figuresMod[figures.Count - 1].polygons.Add(p);
            }

            calcCoefficiantsMod(figuresMod);

            using (var fastbitmap = drawArea.FastLock())
            {
                fastbitmap.Clear(canvasColor);

                float[,] zBuffor = new float[canvas.Width, canvas.Height];
                for (int i = 0; i < canvas.Width; i++)
                    for (int j = 0; j < canvas.Height; j++)
                        zBuffor[i, j] = float.MaxValue;

                for (int i = 0; i < figuresMod.Count; i++)
                    foreach (var p in figuresMod[i].polygons)
                        fillpolygon(p, fastbitmap, figuresMod[i].coefs, zBuffor, figuresMod[i].col, figuresMod[i].ks, figuresMod[i].kd, figuresMod[i].m);
            }

            {
                //sosnowskij bypass
                canvas.Invalidate();
                if (this.IsHandleCreated)
                    try
                    {
                        canvas.Invoke((MethodInvoker)delegate
                        {
                            if (canvas.IsDisposed) return;
                            canvas.Update();
                        });
                    }
                    catch { }
                else
                    canvas.Update();
            }
        }
        private Polygon calcViewPolygon(Polygon p, Matrix4x4 modelMatrix, Matrix4x4 viewMatrix, Matrix4x4 projectionMatrix)
        {
            Polygon exitPolygon = new Polygon();

            foreach (var v in p.verticies)
            {
                Vector4 newV = Vector4.Transform(v.coords, modelMatrix);
                newV = Vector4.Transform(newV, viewMatrix);
                newV = Vector4.Transform(newV, projectionMatrix);
                Vertex vv = new Vertex((canvas.Width / 2) * (newV.X / newV.W + 1), (canvas.Height / 2) * (newV.Y / newV.W + 1), newV.Z / newV.W);
                Vector3 newNormal = Vector3.TransformNormal(v.normal, modelMatrix);
                vv.normal = newNormal;
                exitPolygon.verticies.Add(vv);
            }

            return exitPolygon;
        }
        private void calcCoefficiantsMod(List<Figure> figuresMod)
        {
            for (int indx = 0; indx < figuresMod.Count; indx++)
            {
                figuresMod[indx].coefs = new float[canvas.Size.Width, canvas.Size.Height, maxVerticies];

                foreach (var p in figuresMod[indx].polygons)
                {
                    SortedDictionary<int, List<Edge>> et = new SortedDictionary<int, List<Edge>>();
                    List<Edge> aet = new List<Edge>();

                    for (int i = 0; i < p.verticies.Count; i++)
                    {
                        int inext = (i + 1 == p.verticies.Count) ? 0 : i + 1;
                        if (Math.Abs(p.verticies[inext].y - p.verticies[i].y) != 0)
                        {
                            var ed = new Edge(p.verticies[i], p.verticies[inext]);
                            if (!et.ContainsKey(ed.ymin))
                                et.Add(ed.ymin, new List<Edge>());
                            et[ed.ymin].Add(ed);
                        }
                    }

                    var curY = et.First().Key;
                    while (et.Count > 0 || aet.Count > 0)
                    {
                        if (et.Count > 0)
                            if (curY == et.First().Key)
                            {
                                foreach (var e in et.First().Value)
                                    aet.Add(e);
                                et.Remove(curY);
                                aet.Sort((p, q) => xComparator(p, q));
                            }
                        for (int i = 0; i < aet.Count;)
                        {
                            if (aet[i].ymax == curY)
                                aet.RemoveAt(i);
                            else
                                i++;
                        }

                        for (int i = 0; i + 1 < aet.Count;)
                        {
                            int x1 = (int)aet[i].x;
                            int x2 = (int)aet[i + 1].x;
                            int xMax = Math.Max(x1, x2);
                            int xMin = Math.Min(x1, x2);

                            for (int j = xMin; j <= xMax; j++)
                            {
                                // actuall baricenter calculations
                                if (maxVerticies != 3)
                                    throw new Exception("Generalisation not implemented");

                                float area = 0;

                                for (int k = 0; k < p.verticies.Count; k++)
                                {
                                    int kNext = (k + 1 == p.verticies.Count) ? 0 : k + 1;
                                    int kkNext = (kNext + 1 == p.verticies.Count) ? 0 : kNext + 1;
                                    float a = calcLength(p.verticies[k].x, p.verticies[k].y, p.verticies[kNext].x, p.verticies[kNext].y);
                                    float b = calcLength(p.verticies[kNext].x, p.verticies[kNext].y, j, curY);
                                    float c = calcLength(j, curY, p.verticies[k].x, p.verticies[k].y);
                                    float pe = (a + b + c) / 2;
                                    figuresMod[indx].coefs[j, curY, kkNext] = (float)(Math.Sqrt(pe * (pe - a) * (pe - b) * (pe - c)));
                                    area += figuresMod[indx].coefs[j, curY, kkNext];
                                }

                                if (area > 0)
                                    for (int k = 0; k < maxVerticies; k++)
                                        figuresMod[indx].coefs[j, curY, k] = (float)(figuresMod[indx].coefs[j, curY, k] / area);
                            }
                            aet[i].x += aet[i].d;
                            aet[i + 1].x += aet[i + 1].d;
                            i += 2;
                        }
                        curY++;
                    }
                }
            }
        }
        private Vector3 normaliseVector(Vector3 normal)
        {
            float len = (float)Math.Sqrt(normal.X * normal.X + normal.Y * normal.Y + normal.Z * normal.Z);
            normal.X /= len;
            normal.Y /= len;
            normal.Z /= len;
            return normal;
        }
        private static int xComparator(Edge e1, Edge e2)
        {
            if (e1.x < e2.x) return -1;
            else if (e1.x > e2.x) return 1;
            else return 0;
        }
        private float vectorLength(Vector3 vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Z * vector.Z + vector.Z * vector.Z);
        }
        private void calculateAndPaintColor(Polygon p, int x, int y, FastBitmap f, float[,,] coefs, Color col, float ks, float kd, float m)
        {
            Vector3 vector = new Vector3();
            float z = 0;

            for (int i = 0; i < p.verticies.Count; i++)
            {
                vector.X += coefs[x, y, i] * p.verticies[i].normal.X;
                vector.Y += coefs[x, y, i] * p.verticies[i].normal.Y;
                vector.Z += coefs[x, y, i] * p.verticies[i].normal.Z;
                z += coefs[x, y, i] * p.verticies[i].z;
            }

            Vector3 n = normaliseVector(vector);
            Vector3 l = normaliseVector(new Vector3(light.x - x, light.y - y, light.z - z));
            float cosNL = n.X * l.X + n.Y * l.Y + n.Z * l.Z;
            if (cosNL < 0)
                cosNL = 0;
            Color color = col;
            Vector3 colorV = new Vector3((float)color.R / 256, (float)color.G / 256, (float)color.B / 256);
            Vector3 r = new Vector3(2 * cosNL * n.X - l.X, 2 * cosNL * n.Y - l.Y, 2 * cosNL * n.Z - l.Z);
            float cosVR = (vv.X * r.X + vv.Y * r.Y + vv.Z * r.Z) / vectorLength(vv) / vectorLength(r);
            if (cosVR < 0)
                cosVR = 0;
            Vector3 finalColor = new Vector3();
            float coe = (float)(kd * cosNL + ks * Math.Pow(cosVR, m));
            finalColor.X = lightColor.X * colorV.X * coe * 256;
            finalColor.Y = lightColor.Y * colorV.Y * coe * 256;
            finalColor.Z = lightColor.Z * colorV.Z * coe * 256;
            Color colorF = new Color();
            colorF = Color.FromArgb((byte)255, (byte)finalColor.X, (byte)finalColor.Y, (byte)finalColor.Z);
            f.SetPixel(x, y, colorF);
        }
        private void fillpolygon(Polygon p, FastBitmap f, float[,,] coefs, float[,] zBuffor, Color col, float ks, float kd, float m)
        {
            SortedDictionary<int, List<Edge>> et = new SortedDictionary<int, List<Edge>>();
            List<Edge> aet = new List<Edge>();
            Vector3[] colors = new Vector3[maxVerticies];

            for (int i = 0; i < p.verticies.Count; i++)
            {
                int inext = (i + 1 == p.verticies.Count) ? 0 : i + 1;
                if (Math.Abs(p.verticies[inext].y - p.verticies[i].y) != 0)
                {
                    var ed = new Edge(p.verticies[i], p.verticies[inext]);
                    if (!et.ContainsKey(ed.ymin))
                        et.Add(ed.ymin, new List<Edge>());
                    et[ed.ymin].Add(ed);
                }
                if (gouraudsShadingRbutton.Checked)
                {
                    Vector3 n = normaliseVector(p.verticies[i].normal);
                    Vector3 l = normaliseVector(new Vector3(light.x - p.verticies[i].x, light.y - p.verticies[i].y, light.z - p.verticies[i].z));
                    float cosNL = n.X * l.X + n.Y * l.Y + n.Z * l.Z;
                    if (cosNL < 0)
                        cosNL = 0;
                    Color color = col;
                    Vector3 colorV = new Vector3((float)color.R / 256, (float)color.G / 256, (float)color.B / 256);
                    Vector3 r = new Vector3(2 * cosNL * n.X - l.X, 2 * cosNL * n.Y - l.Y, 2 * cosNL * n.Z - l.Z);
                    float cosVR = (vv.X * r.X + vv.Y * r.Y + vv.Z * r.Z) / vectorLength(vv) / vectorLength(r);
                    if (cosVR < 0)
                        cosVR = 0;
                    float coe = (float)(kd * cosNL + ks * Math.Pow(cosVR, m));
                    colors[i].X = lightColor.X * colorV.X * coe * 256;
                    colors[i].Y = lightColor.Y * colorV.Y * coe * 256;
                    colors[i].Z = lightColor.Z * colorV.Z * coe * 256;
                }
            }

            var curY = et.First().Key;
            while (et.Count > 0 || aet.Count > 0)
            {
                if (et.Count > 0)
                    if (curY == et.First().Key)
                    {
                        foreach (var e in et.First().Value)
                            aet.Add(e);
                        et.Remove(curY);
                        aet.Sort((p, q) => xComparator(p, q));
                    }
                for (int i = 0; i < aet.Count;)
                {
                    if (aet[i].ymax == curY)
                        aet.RemoveAt(i);
                    else
                        i++;
                }

                for (int i = 0; i + 1 < aet.Count;)
                {
                    int x1 = (int)aet[i].x;
                    int x2 = (int)aet[i + 1].x;
                    int xMax = Math.Max(x1, x2);
                    int xMin = Math.Min(x1, x2);

                    for (int j = xMin; j <= xMax; j++)
                    {
                        float z = 0;
                        for (int k = 0; k < p.verticies.Count; k++)
                        {
                            z += coefs[j, curY, k] * p.verticies[k].z;
                        }
                        if (z <= zBuffor[j, curY])
                        {
                            if (phongsShadingRbutton.Checked)
                                calculateAndPaintColor(p, j, curY, f, coefs, col, ks, kd, m);
                            else
                            {
                                Vector3 finalColor = new Vector3(0, 0, 0);
                                for (int k = 0; k < p.verticies.Count; k++)
                                {
                                    finalColor.X += coefs[j, curY, k] * colors[k].X;
                                    finalColor.Y += coefs[j, curY, k] * colors[k].Y;
                                    finalColor.Z += coefs[j, curY, k] * colors[k].Z;
                                }
                                Color colorF = new Color();
                                colorF = Color.FromArgb((byte)255, (byte)finalColor.X, (byte)finalColor.Y, (byte)finalColor.Z);
                                f.SetPixel(j, curY, colorF);
                            }
                            zBuffor[j, curY] = z;
                        }
                    }
                    aet[i].x += aet[i].d;
                    aet[i + 1].x += aet[i + 1].d;
                    i += 2;
                }
                curY++;
            }
        }
        private float calcLength(float x1, float y1, float x2, float y2)
        {
            return (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            terminate = true;
        }
    }
    public class Vertex
    {
        public Vector4 coords;
        public float x { get => coords.X; set => coords.X = value; }
        public float y { get => coords.Y; set => coords.Y = value; }
        public float z { get => coords.Z; set => coords.Z = value; }
        public Vector3 normal;

        public Vertex(float x, float y, float z)
        {
            this.coords = new Vector4(x, y, z, 1);
            this.normal = new Vector3();
        }
    }
    public class Polygon
    {
        public List<Vertex> verticies;
        public Polygon()
        {
            this.verticies = new List<Vertex>();
        }
    }
    public class Edge
    {
        public float x;
        public int ymax;
        public float d;
        public int ymin;

        public Edge(Vertex v1, Vertex v2)
        {
            if (v1.y < v2.y)
            {
                ymin = (int)v1.y;
                ymax = (int)v2.y;
                x = (int)v1.x;
            }
            else
            {
                ymin = (int)v2.y;
                ymax = (int)v1.y;
                x = (int)v2.x;
            }

            d = (v2.x - v1.x) / (v2.y - v1.y);
        }
    }
    public class Figure
    {
        public List<Polygon> polygons;
        public List<Vertex> vertices;
        public List<Vector3> normals;
        public float[,,] coefs;
        public Color col;
        public float ks;
        public float kd;
        public float m;

        public Figure(Color c, float ks, float kd, float m)
        {
            this.polygons = new List<Polygon>();
            this.vertices = new List<Vertex>();
            this.normals = new List<Vector3>();
            this.coefs = new float[0, 0, 0];
            this.col = c;
            this.m = m;
            this.ks = ks;
            this.kd = kd;
        }
    }
}