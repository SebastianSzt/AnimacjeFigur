using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AnimacjeFigur
{
    [Serializable]
    [XmlInclude(typeof(Okrag))]
    [XmlInclude(typeof(Kwadrat))]
    [XmlInclude(typeof(Trojkat))]
    public class Figura : IFigura
    {
        [Description("Polozenie x")]
        public int posX;
        [Description("Polozenie y")]
        public int posY;
        [Description("Predkosc x")]
        public int vX;
        [Description("Predkosc y")]
        public int vY;
        [Description("Rozmiar figury")]
        public int size;
        [XmlIgnore]
        [Description("Kolor figury")]
        public Color color;

        [XmlElement("color")]
        public string ColorName
        {
            get { return color.Name; }
            set { color = Color.FromName(value); }
        }

        [NonSerialized]
        private Dictionary<string, string> dicField = new Dictionary<string, string>();
        [NonSerialized]
        private Dictionary<string, MemberInfo> dicMem = new Dictionary<string, MemberInfo>();

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (dicField == null)
                dicField = new Dictionary<string, string>();

            if (dicMem == null)
                dicMem = new Dictionary<string, MemberInfo>();
        }

        public Figura() { }

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

        public Figura(string[] line, int method)
        {
            if (method == 1)
            {
                posX = int.Parse(line[1]);
                posY = int.Parse(line[2]);
                vX = int.Parse(line[3]);
                vY = int.Parse(line[4]);
                size = int.Parse(line[5]);
                color = ColorTranslator.FromHtml("#" + line[6]);
            }
            else if (method == 2) 
            {
                foreach (string parameter in line)
                {
                    string[] fieldInfo = parameter.Split('\t');

                    Type type = Type.GetType(fieldInfo[2]);
                    if (type != null)
                    {
                        FieldInfo field = GetType().GetField(fieldInfo[3], BindingFlags.Public | BindingFlags.Instance);
                        if (field != null)
                        {
                            object value = Convert.ChangeType(fieldInfo[1], type);
                            field.SetValue(this, value);
                        }
                    }
                    else if (fieldInfo[2] == "System.Drawing.Color")
                    {
                        FieldInfo field = GetType().GetField(fieldInfo[3], BindingFlags.Public | BindingFlags.Instance);
                        if (field != null)
                        {
                            string[] parts = fieldInfo[1].Replace("Color [", "").Replace("]", "").Split(new[] { ',', '=' }, StringSplitOptions.RemoveEmptyEntries);
                            int.TryParse(parts[1].Trim(), out int a);
                            int.TryParse(parts[3].Trim(), out int r);
                            int.TryParse(parts[5].Trim(), out int g);
                            int.TryParse(parts[7].Trim(), out int b);
                            field.SetValue(this, Color.FromArgb(a, r, g, b));
                        }
                    }
                }
            }
        }

        public virtual void Draw(PaintEventArgs e) { }

        public virtual void Move(int width, int height) { }

        public void CheckPosition(int width, int height)
        {
            if (posX < 0)
            {
                posX = 0;
                vX = -vX;
            }
            else if (posX + size > width)
            {
                posX = width - size;
                vX = -vX;
            }

            if (posY < 0)
            {
                posY = 0;
                vY = -vY;
            }
            else if (posY + size > height)
            {
                posY = height - size;
                vY = -vY;
            }
        }

        public virtual void ParametersSave(StreamWriter writer)
        {
            writer.Write(GetType().FullName + " " + posX + " " + posY + " " + vX + " " + vY + " " + size + " " + color.Name);
        }

        public void MembersSave(StreamWriter writer)
        {
            PrepareMemberFields();
            writer.WriteLine();
            writer.WriteLine("Typ figury:\t" + GetType().FullName);
            writer.WriteLine("Długość słownika:\t" + dicField.Count);
            foreach (var element in dicField)
            {
                string description = element.Key;
                string value = element.Value;
                MemberInfo memberInfo = dicMem[element.Key];
                string typeName = memberInfo.MemberType.ToString();
                if (memberInfo is FieldInfo fieldInfo)
                {
                    Type fieldType = fieldInfo.FieldType;
                    typeName = fieldType.FullName;
                }
                writer.WriteLine($"{description}:\t{value}\t{typeName}\t{memberInfo.Name}");
            }
        }

        public void PrepareMemberFields()
        {
            dicField.Clear();
            dicMem.Clear();
            Type t = this.GetType();
            MemberInfo[] members = t.GetMembers(BindingFlags.Public | BindingFlags.Instance);

            foreach (MemberInfo mem in members)
            {
                object[] attributes = mem.GetCustomAttributes(true);
                if (attributes.Length != 0 && mem.MemberType.ToString() == "Field")
                {
                    string key = attributes.OfType<DescriptionAttribute>().FirstOrDefault()?.Description ?? string.Empty;
                    FieldInfo f = mem.ReflectedType.GetField(mem.Name, BindingFlags.Public | BindingFlags.Instance);
                    if (f == null)
                        continue;
                    object o = mem.ReflectedType.GetField(mem.Name, BindingFlags.Public | BindingFlags.Instance).GetValue(this);
                    if (o != null)
                        dicField.Add(key, mem.ReflectedType.GetField(mem.Name, BindingFlags.Public | BindingFlags.Instance).GetValue(this).ToString());
                    else
                        dicField.Add(key, "");
                    dicMem.Add(key, mem);
                }
            }
        }
    }
}