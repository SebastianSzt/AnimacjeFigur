using System.ComponentModel;
using System.Reflection;

namespace AnimacjeFigur
{
    internal class Figura : IFigura
    {
        [Description("Polozenie x")]
        protected int posX;
        [Description("Polozenie y")]
        protected int posY;
        [Description("Predkosc x")]
        protected int vX;
        [Description("Predkosc y")]
        protected int vY;
        [Description("Rozmiar figury")]
        protected int size;
        [Description("Kolor figury")]
        protected Color color;

        public Figura(int width, int height)
        {
            Random random = new Random();

            size = random.Next(50, 100);
            posX = random.Next(0, width - size);
            posY = random.Next(0, height - size);
            while (vX >= -1 && vX <= 1)
                vX = random.Next(-15, 15);
            while (vY >= -1 && vY <= 1)
                vY = random.Next(-15, 15);
            color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        public Figura(string[] line)
        {
            posX = int.Parse(line[1]);
            posY = int.Parse(line[2]);
            vX = int.Parse(line[3]);
            vY = int.Parse(line[4]);
            size = int.Parse(line[5]);
            color = ColorTranslator.FromHtml("#" + line[6]);
        }

        public virtual void Draw(PaintEventArgs e) { }

        public virtual void Move(int width, int height) { }

        public void checkPosition(int width, int height)
        {
            if (posX + vX < 0)
            {
                posX = 0;
                vX = -vX;
            }
            else if (posX + size + vX > width)
            {
                posX = width - size;
                vX = -vX;
            }

            if (posY + vY < 0)
            {
                posY = 0;
                vY = -vY;
            }
            else if (posY + size + vY > height)
            {
                posY = height - size;
                vY = -vY;
            }
        }

        public virtual void Save(StreamWriter writer)
        {
            writer.Write(GetType().FullName + " " + posX + " " + posY + " " + vX + " " + vY + " " + size + " " + color.Name);
            PrzygotujPola();
        }

        protected Dictionary<string, string> dicField = new Dictionary<string, string>();
        protected Dictionary<string, MemberInfo> dicMem = new Dictionary<string, MemberInfo>();

        protected void PrzygotujPola()
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
                    object o = mem.ReflectedType.GetField(mem.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
                    if (o != null)
                        dicField.Add(key, mem.ReflectedType.GetField(mem.Name).GetValue(this).ToString());
                    else
                        dicField.Add(key, "");

                    dicMem.Add(key, mem);
                }
            }
        }
    }
}