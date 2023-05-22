using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

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

                figury[i] = (IFigura)Activator.CreateInstance(subclasses.ElementAt(index), new object[] { panel1.Width, panel1.Height });
            }

            if (File.Exists("save.txt"))
            {
                wczytajToolStripMenuItem.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (IFigura figura in figury)
            {
                figura.Draw(e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (IFigura figura in figury)
            {
                figura.Move(panel1.Width, panel1.Height);
            }
            panel1.Refresh();
        }

        private void timerStart(object sender, EventArgs e)
        {
            timer1.Start();
            uruchomToolStripMenuItem.Enabled = false;
            zatrzymajToolStripMenuItem.Enabled = true;
        }

        private void timerStop(object sender, EventArgs e)
        {
            timer1.Stop();
            zatrzymajToolStripMenuItem.Enabled = false;
            uruchomToolStripMenuItem.Enabled = true;
        }

        private void checkPosition(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                foreach (Figura figura in figury)
                {
                    figura.checkPosition(panel1.Width, panel1.Height);
                }
                panel1.Refresh();
            }
        }

        private void saveStatus(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("save.txt");

            writer.WriteLine(this.Width + " " + this.Height);
            writer.WriteLine(timer1.Enabled);
            writer.WriteLine(figury.Length);

            foreach (Figura figura in figury)
                figura.Save(writer);

            writer.Close();
            wczytajToolStripMenuItem.Enabled = true;

            //Serializacja
            Stream s = new FileStream("save_serialization.txt", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            foreach (Figura figura in figury)
                bf.Serialize(s, figura);
            s.Close();

            //xml json
        }

        private void loadStatus(object sender, EventArgs e)
        {
            /*StreamReader reader = new StreamReader("save.txt");

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
                    ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(string[]) });

                    if (constructor != null)
                    {
                        string[] figuraData = new string[int.Parse(reader.ReadLine().Split('\t')[1])];

                        for (int j = 0; j < figuraData.Length; j++)
                        {
                            figuraData[j] = reader.ReadLine();
                        }

                        IFigura figura = (IFigura)constructor.Invoke(new object[] { figuraData });

                        figury[i] = figura;
                    }
                }
            }

            reader.Close();

            panel1.Refresh();

            if (timer)
            {
                timer1.Start();
                uruchomToolStripMenuItem.Enabled = false;
                zatrzymajToolStripMenuItem.Enabled = true;
            }
            else
            {
                timer1.Stop();
                zatrzymajToolStripMenuItem.Enabled = false;
                uruchomToolStripMenuItem.Enabled = true;
            }*/

            Stream s = new FileStream("save_serialization.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            figury = new IFigura[10];
            for (int i = 0; i < 10; i++)
            {
                figury[i] = (Figura)bf.Deserialize(s);
            }

            panel1.Refresh();
        }
    }
}