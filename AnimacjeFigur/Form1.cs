using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace AnimacjeFigur
{
    public partial class Form1 : Form
    {
        IFigura[] figury = new IFigura[10];

        public Form1()
        {
            InitializeComponent();

            var subclasses = Assembly.GetAssembly(typeof(Figura)).GetTypes().Where(t => t.IsSubclassOf(typeof(Figura)));

            Random random = new Random();
            for (int i = 0; i < figury.Length; i++)
            {
                int index = random.Next(subclasses.Count());

                figury[i] = (IFigura)Activator.CreateInstance(subclasses.ElementAt(index), new object[] { panel.Width, panel.Height });
            }

            if (File.Exists("save1.txt"))
            {
                wczytajParametramiToolStripMenuItem.Enabled = true;
            }
            if (File.Exists("save2.txt"))
            {
                wczytajMemberToolStripMenuItem.Enabled = true;
            }
            if (File.Exists("save3.txt") && File.Exists("save3.bin"))
            {
                wczytajSerializacj¹Binarn¹ToolStripMenuItem.Enabled = true;
            }
            if (File.Exists("save4.txt") && File.Exists("save4.xml"))
            {
                wczytajSerializacj¹XMLToolStripMenuItem.Enabled = true;
            }
            if (File.Exists("save5.txt") && File.Exists("save5.json"))
            {
                wczytajSerializacj¹JSONToolStripMenuItem.Enabled = true;
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            foreach (IFigura figura in figury)
            {
                figura.Draw(e);
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            foreach (IFigura figura in figury)
            {
                figura.Move(panel.Width, panel.Height);
            }
            panel.Refresh();
        }

        private void TimerStart(object sender, EventArgs e)
        {
            timer.Start();
            uruchomToolStripMenuItem.Enabled = false;
            zatrzymajToolStripMenuItem.Enabled = true;
        }

        private void TimerStop(object sender, EventArgs e)
        {
            timer.Stop();
            zatrzymajToolStripMenuItem.Enabled = false;
            uruchomToolStripMenuItem.Enabled = true;
        }

        private void CheckPosition(object sender, EventArgs e)
        {
            if (timer.Enabled == false)
            {
                foreach (Figura figura in figury)
                {
                    figura.CheckPosition(panel.Width, panel.Height);
                }
                panel.Refresh();
            }
        }

        private void ParametersSave(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("save1.txt");

            writer.WriteLine(this.Width + " " + this.Height);
            writer.WriteLine(timer.Enabled);
            writer.WriteLine(figury.Length);

            foreach (Figura figura in figury)
                figura.ParametersSave(writer);

            writer.Close();

            wczytajParametramiToolStripMenuItem.Enabled = true;
        }

        private void ParametersLoad(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("save1.txt");

            string[] line = reader.ReadLine().Split(' ');
            this.Width = int.Parse(line[0]);
            this.Height = int.Parse(line[1]);
            bool timer = bool.Parse(reader.ReadLine());
            int ammount = int.Parse(reader.ReadLine());
            figury = new IFigura[ammount];

            for (int i = 0; i < ammount; i++)
            {
                line = reader.ReadLine().Split(' ');
                figury[i] = (IFigura)Activator.CreateInstance(Type.GetType(line[0]), new object[] { line, 1 });
            }

            reader.Close();

            panel.Refresh();

            if (timer)
            {
                this.timer.Start();
                uruchomToolStripMenuItem.Enabled = false;
                zatrzymajToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.timer.Stop();
                zatrzymajToolStripMenuItem.Enabled = false;
                uruchomToolStripMenuItem.Enabled = true;
            }
        }

        private void MembersSave(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("save2.txt");

            writer.WriteLine(this.Width + " " + this.Height);
            writer.WriteLine(timer.Enabled);
            writer.WriteLine(figury.Length);

            foreach (Figura figura in figury)
                figura.MembersSave(writer);

            writer.Close();

            wczytajMemberToolStripMenuItem.Enabled = true;
        }

        private void MembersLoad(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("save2.txt");

            string[] line = reader.ReadLine().Split(' ');
            this.Width = int.Parse(line[0]);
            this.Height = int.Parse(line[1]);
            bool timer = bool.Parse(reader.ReadLine());
            int ammount = int.Parse(reader.ReadLine());
            figury = new IFigura[ammount];

            for (int i = 0; i < ammount; i++)
            {
                reader.ReadLine();
                string className = reader.ReadLine().Split('\t')[1];
                Type type = Type.GetType(className);
                if (type != null)
                {
                    ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(string[]), typeof(int) });
                    if (constructor != null)
                    {
                        line = new string[int.Parse(reader.ReadLine().Split('\t')[1])];
                        for (int j = 0; j < line.Length; j++)
                        {
                            line[j] = reader.ReadLine();
                        }
                        IFigura figura = (IFigura)constructor.Invoke(new object[] { line, 2 });
                        figury[i] = figura;
                    }
                }
            }

            reader.Close();

            panel.Refresh();

            if (timer)
            {
                this.timer.Start();
                uruchomToolStripMenuItem.Enabled = false;
                zatrzymajToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.timer.Stop();
                zatrzymajToolStripMenuItem.Enabled = false;
                uruchomToolStripMenuItem.Enabled = true;
            }
        }

        private void BinarySerializationSave(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("save3.txt");

            writer.WriteLine(this.Width + " " + this.Height);
            writer.WriteLine(timer.Enabled);
            writer.WriteLine(figury.Length);

            writer.Close();

            Stream stream = new FileStream("save3.bin", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            foreach (Figura figura in figury)
                formatter.Serialize(stream, figura);

            stream.Close();

            wczytajSerializacj¹Binarn¹ToolStripMenuItem.Enabled = true;
        }

        private void BinarySerializationLoad(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("save3.txt");

            string[] line = reader.ReadLine().Split(' ');
            this.Width = int.Parse(line[0]);
            this.Height = int.Parse(line[1]);
            bool timer = bool.Parse(reader.ReadLine());
            int ammount = int.Parse(reader.ReadLine());
            figury = new IFigura[ammount];

            reader.Close();

            Stream stream = new FileStream("save3.bin", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            for (int i = 0; i < ammount; i++)
            {
                figury[i] = (Figura)formatter.Deserialize(stream);
            }

            stream.Close();

            panel.Refresh();

            if (timer)
            {
                this.timer.Start();
                uruchomToolStripMenuItem.Enabled = false;
                zatrzymajToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.timer.Stop();
                zatrzymajToolStripMenuItem.Enabled = false;
                uruchomToolStripMenuItem.Enabled = true;
            }
        }

        private void XMLSerializationSave(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("save4.txt");

            writer.WriteLine(this.Width + " " + this.Height);
            writer.WriteLine(timer.Enabled);
            writer.WriteLine(figury.Length);

            writer.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(Figura[]), new XmlRootAttribute("Figury"));
            FileStream fileStream = new FileStream("save4.xml", FileMode.Create);

            Figura[] figuraArray = figury.OfType<Figura>().ToArray();

            serializer.Serialize(fileStream, figuraArray);

            fileStream.Close();

            wczytajSerializacj¹XMLToolStripMenuItem.Enabled = true;
        }

        private void XMLSerializationLoad(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("save4.txt");

            string[] line = reader.ReadLine().Split(' ');
            this.Width = int.Parse(line[0]);
            this.Height = int.Parse(line[1]);
            bool timer = bool.Parse(reader.ReadLine());
            int amount = int.Parse(reader.ReadLine());

            reader.Close();

            XmlSerializer serializer = new XmlSerializer(typeof(Figura[]), new XmlRootAttribute("Figury"));
            FileStream fileStream = new FileStream("save4.xml", FileMode.Open);

            Figura[] figuraArray = (Figura[])serializer.Deserialize(fileStream);

            fileStream.Close();

            figury = new IFigura[amount];
            for (int i = 0; i < amount; i++)
            {
                string colorText = "#" + figuraArray[i].color.Name;
                figuraArray[i].color = ColorTranslator.FromHtml(colorText);
                figury[i] = figuraArray[i];
            }

            panel.Refresh();

            if (timer)
            {
                this.timer.Start();
                uruchomToolStripMenuItem.Enabled = false;
                zatrzymajToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.timer.Stop();
                zatrzymajToolStripMenuItem.Enabled = false;
                uruchomToolStripMenuItem.Enabled = true;
            }
        }

        //Do obs³ugi tej funkcji potrzebna jest biblioteka Newtonsoft.Json
        private void JSONSerializationSave(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("save5.txt");

            writer.WriteLine(this.Width + " " + this.Height);
            writer.WriteLine(timer.Enabled);
            writer.WriteLine(figury.Length);

            writer.Close();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string jsonData = JsonConvert.SerializeObject(figury, settings);
            File.WriteAllText("save5.json", jsonData);

            wczytajSerializacj¹JSONToolStripMenuItem.Enabled = true;
        }

        private void JSONSerializationLoad(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("save5.txt");

            string[] line = reader.ReadLine().Split(' ');
            this.Width = int.Parse(line[0]);
            this.Height = int.Parse(line[1]);
            bool timerEnabled = bool.Parse(reader.ReadLine());
            int amount = int.Parse(reader.ReadLine());

            reader.Close();

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string jsonData = File.ReadAllText("save5.json");
            IFigura[] figuraArray = JsonConvert.DeserializeObject<IFigura[]>(jsonData, settings);

            figury = new IFigura[amount];
            for (int i = 0; i < amount; i++)
            {
                if (figuraArray[i] is Figura figura)
                {
                    string colorText = "#" + figura.color.Name;
                    figura.color = ColorTranslator.FromHtml(colorText);
                    figury[i] = figura;
                }
            }

            panel.Refresh();

            if (timerEnabled)
            {
                this.timer.Start();
                uruchomToolStripMenuItem.Enabled = false;
                zatrzymajToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.timer.Stop();
                zatrzymajToolStripMenuItem.Enabled = false;
                uruchomToolStripMenuItem.Enabled = true;
            }
        }
    }
}