using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Reflection;

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

        private void loadStatus(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("save.txt");
            string[] line = reader.ReadLine().Split(' ');
            this.Width = int.Parse(line[0]);
            this.Height = int.Parse(line[1]);
            int ammount = int.Parse(reader.ReadLine());
            figury = new IFigura[ammount];

            for (int i = 0; i < ammount; i++)
            {
                line = reader.ReadLine().Split(' ');
                figury[i] = (IFigura)Activator.CreateInstance(Type.GetType(line[0]), new object[] { line });
            }

            panel1.Refresh();

            if (bool.Parse(reader.ReadLine()))
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
            }


            reader.Close();
        }

        private void saveStatus(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("save.txt");
            writer.WriteLine(this.Width + " " + this.Height);
            writer.WriteLine(figury.Length);
            foreach (Figura figura in figury)
                figura.Save(writer);
            writer.WriteLine(timer1.Enabled);
            writer.Close();
            wczytajToolStripMenuItem.Enabled = true;
            PrzygotujPola();
        }


        private Dictionary<string, string> dicField = new Dictionary<string, string>();
        private Dictionary<string, MemberInfo> dicMem = new Dictionary<string, MemberInfo>();

        private void PrzygotujPola()
        {
            Type t = this.GetType();
            MemberInfo[] members = t.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            dicField.Clear();
            dicMem.Clear();

            foreach (MemberInfo mem in members)
            {
                object[] attributes = mem.GetCustomAttributes(true);

                if (attributes.Length != 0 && mem.MemberType.ToString() == "Field")
                {
                    string key = "";
                    foreach (object attribute in attributes)
                    {
                        //Console.Write("   {0} ", attribute.ToString());
                        DescriptionAttribute da = attribute as DescriptionAttribute;
                        if (da != null)
                            key = da.Description;
                    }
                    FieldInfo f = mem.ReflectedType.GetField(mem.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (f == null)
                        continue;
                    object o = mem.ReflectedType.GetField(mem.Name).GetValue(this);
                    if (o != null)
                        dicField.Add(key, mem.ReflectedType.GetField(mem.Name).GetValue(this).ToString());
                    else
                        dicField.Add(key, "");

                    dicMem.Add(key, mem);
                }
            }
        }

        public void Save()
        {
            StreamWriter file = new StreamWriter("test.txt");
            PrzygotujPola();
        }
    }
}