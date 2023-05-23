namespace AnimacjeFigur
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            plikToolStripMenuItem = new ToolStripMenuItem();
            wczytajToolStripMenuItem = new ToolStripMenuItem();
            wczytajParametramiToolStripMenuItem = new ToolStripMenuItem();
            wczytajMemberToolStripMenuItem = new ToolStripMenuItem();
            wczytajSerializacjąBinarnąToolStripMenuItem = new ToolStripMenuItem();
            wczytajSerializacjąXMLToolStripMenuItem = new ToolStripMenuItem();
            wczytajSerializacjąJSONToolStripMenuItem = new ToolStripMenuItem();
            zapiszToolStripMenuItem = new ToolStripMenuItem();
            zapiszParametramiToolStripMenuItem = new ToolStripMenuItem();
            zapiszMemberToolStripMenuItem = new ToolStripMenuItem();
            zapiszSerializacjąBinarnąToolStripMenuItem = new ToolStripMenuItem();
            zapiszSerializacjąXMLToolStripMenuItem = new ToolStripMenuItem();
            zapiszSerializacjąJSONToolStripMenuItem = new ToolStripMenuItem();
            animacjaToolStripMenuItem = new ToolStripMenuItem();
            uruchomToolStripMenuItem = new ToolStripMenuItem();
            zatrzymajToolStripMenuItem = new ToolStripMenuItem();
            panel = new Panel();
            timer = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { plikToolStripMenuItem, animacjaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(784, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            plikToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { wczytajToolStripMenuItem, zapiszToolStripMenuItem });
            plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            plikToolStripMenuItem.Size = new Size(38, 20);
            plikToolStripMenuItem.Text = "Plik";
            // 
            // wczytajToolStripMenuItem
            // 
            wczytajToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { wczytajParametramiToolStripMenuItem, wczytajMemberToolStripMenuItem, wczytajSerializacjąBinarnąToolStripMenuItem, wczytajSerializacjąXMLToolStripMenuItem, wczytajSerializacjąJSONToolStripMenuItem });
            wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            wczytajToolStripMenuItem.Size = new Size(180, 22);
            wczytajToolStripMenuItem.Text = "Wczytaj";
            // 
            // wczytajParametramiToolStripMenuItem
            // 
            wczytajParametramiToolStripMenuItem.Enabled = false;
            wczytajParametramiToolStripMenuItem.Name = "wczytajParametramiToolStripMenuItem";
            wczytajParametramiToolStripMenuItem.Size = new Size(217, 22);
            wczytajParametramiToolStripMenuItem.Text = "Wczytaj parametrami";
            wczytajParametramiToolStripMenuItem.Click += ParametersLoad;
            // 
            // wczytajMemberToolStripMenuItem
            // 
            wczytajMemberToolStripMenuItem.Enabled = false;
            wczytajMemberToolStripMenuItem.Name = "wczytajMemberToolStripMenuItem";
            wczytajMemberToolStripMenuItem.Size = new Size(217, 22);
            wczytajMemberToolStripMenuItem.Text = "Wczytaj member";
            wczytajMemberToolStripMenuItem.Click += MembersLoad;
            // 
            // wczytajSerializacjąBinarnąToolStripMenuItem
            // 
            wczytajSerializacjąBinarnąToolStripMenuItem.Enabled = false;
            wczytajSerializacjąBinarnąToolStripMenuItem.Name = "wczytajSerializacjąBinarnąToolStripMenuItem";
            wczytajSerializacjąBinarnąToolStripMenuItem.Size = new Size(217, 22);
            wczytajSerializacjąBinarnąToolStripMenuItem.Text = "Wczytaj serializacją binarną";
            wczytajSerializacjąBinarnąToolStripMenuItem.Click += BinarySerializationLoad;
            // 
            // wczytajSerializacjąXMLToolStripMenuItem
            // 
            wczytajSerializacjąXMLToolStripMenuItem.Enabled = false;
            wczytajSerializacjąXMLToolStripMenuItem.Name = "wczytajSerializacjąXMLToolStripMenuItem";
            wczytajSerializacjąXMLToolStripMenuItem.Size = new Size(217, 22);
            wczytajSerializacjąXMLToolStripMenuItem.Text = "Wczytaj serializacją XML";
            wczytajSerializacjąXMLToolStripMenuItem.Click += XMLSerializationLoad;
            // 
            // wczytajSerializacjąJSONToolStripMenuItem
            // 
            wczytajSerializacjąJSONToolStripMenuItem.Enabled = false;
            wczytajSerializacjąJSONToolStripMenuItem.Name = "wczytajSerializacjąJSONToolStripMenuItem";
            wczytajSerializacjąJSONToolStripMenuItem.Size = new Size(217, 22);
            wczytajSerializacjąJSONToolStripMenuItem.Text = "Wczytaj serializacją JSON";
            wczytajSerializacjąJSONToolStripMenuItem.Click += JSONSerializationLoad;
            // 
            // zapiszToolStripMenuItem
            // 
            zapiszToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { zapiszParametramiToolStripMenuItem, zapiszMemberToolStripMenuItem, zapiszSerializacjąBinarnąToolStripMenuItem, zapiszSerializacjąXMLToolStripMenuItem, zapiszSerializacjąJSONToolStripMenuItem });
            zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            zapiszToolStripMenuItem.Size = new Size(180, 22);
            zapiszToolStripMenuItem.Text = "Zapisz";
            // 
            // zapiszParametramiToolStripMenuItem
            // 
            zapiszParametramiToolStripMenuItem.Name = "zapiszParametramiToolStripMenuItem";
            zapiszParametramiToolStripMenuItem.Size = new Size(209, 22);
            zapiszParametramiToolStripMenuItem.Text = "Zapisz parametrami";
            zapiszParametramiToolStripMenuItem.Click += ParametersSave;
            // 
            // zapiszMemberToolStripMenuItem
            // 
            zapiszMemberToolStripMenuItem.Name = "zapiszMemberToolStripMenuItem";
            zapiszMemberToolStripMenuItem.Size = new Size(209, 22);
            zapiszMemberToolStripMenuItem.Text = "Zapisz member";
            zapiszMemberToolStripMenuItem.Click += MembersSave;
            // 
            // zapiszSerializacjąBinarnąToolStripMenuItem
            // 
            zapiszSerializacjąBinarnąToolStripMenuItem.Name = "zapiszSerializacjąBinarnąToolStripMenuItem";
            zapiszSerializacjąBinarnąToolStripMenuItem.Size = new Size(209, 22);
            zapiszSerializacjąBinarnąToolStripMenuItem.Text = "Zapisz serializacją binarną";
            zapiszSerializacjąBinarnąToolStripMenuItem.Click += BinarySerializationSave;
            // 
            // zapiszSerializacjąXMLToolStripMenuItem
            // 
            zapiszSerializacjąXMLToolStripMenuItem.Name = "zapiszSerializacjąXMLToolStripMenuItem";
            zapiszSerializacjąXMLToolStripMenuItem.Size = new Size(209, 22);
            zapiszSerializacjąXMLToolStripMenuItem.Text = "Zapisz serializacją XML";
            zapiszSerializacjąXMLToolStripMenuItem.Click += XMLSerializationSave;
            // 
            // zapiszSerializacjąJSONToolStripMenuItem
            // 
            zapiszSerializacjąJSONToolStripMenuItem.Name = "zapiszSerializacjąJSONToolStripMenuItem";
            zapiszSerializacjąJSONToolStripMenuItem.Size = new Size(209, 22);
            zapiszSerializacjąJSONToolStripMenuItem.Text = "Zapisz serializacją JSON";
            zapiszSerializacjąJSONToolStripMenuItem.Click += JSONSerializationSave;
            // 
            // animacjaToolStripMenuItem
            // 
            animacjaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { uruchomToolStripMenuItem, zatrzymajToolStripMenuItem });
            animacjaToolStripMenuItem.Name = "animacjaToolStripMenuItem";
            animacjaToolStripMenuItem.Size = new Size(69, 20);
            animacjaToolStripMenuItem.Text = "Animacja";
            // 
            // uruchomToolStripMenuItem
            // 
            uruchomToolStripMenuItem.Name = "uruchomToolStripMenuItem";
            uruchomToolStripMenuItem.Size = new Size(126, 22);
            uruchomToolStripMenuItem.Text = "Uruchom";
            uruchomToolStripMenuItem.Click += TimerStart;
            // 
            // zatrzymajToolStripMenuItem
            // 
            zatrzymajToolStripMenuItem.Enabled = false;
            zatrzymajToolStripMenuItem.Name = "zatrzymajToolStripMenuItem";
            zatrzymajToolStripMenuItem.Size = new Size(126, 22);
            zatrzymajToolStripMenuItem.Text = "Zatrzymaj";
            zatrzymajToolStripMenuItem.Click += TimerStop;
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.BackColor = SystemColors.ActiveCaptionText;
            panel.Location = new Point(0, 27);
            panel.Name = "panel";
            panel.Size = new Size(784, 384);
            panel.TabIndex = 1;
            panel.Paint += Panel_Paint;
            // 
            // timer
            // 
            timer.Interval = 50;
            timer.Tick += TimerTick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 411);
            Controls.Add(panel);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(200, 200);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Animacje Figur";
            ResizeEnd += CheckPosition;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem plikToolStripMenuItem;
        private ToolStripMenuItem wczytajToolStripMenuItem;
        private ToolStripMenuItem zapiszToolStripMenuItem;
        private ToolStripMenuItem animacjaToolStripMenuItem;
        private ToolStripMenuItem uruchomToolStripMenuItem;
        private ToolStripMenuItem zatrzymajToolStripMenuItem;
        private Panel panel;
        private System.Windows.Forms.Timer timer;
        private ToolStripMenuItem zapiszParametramiToolStripMenuItem;
        private ToolStripMenuItem zapiszMemberToolStripMenuItem;
        private ToolStripMenuItem wczytajParametramiToolStripMenuItem;
        private ToolStripMenuItem wczytajMemberToolStripMenuItem;
        private ToolStripMenuItem zapiszSerializacjąBinarnąToolStripMenuItem;
        private ToolStripMenuItem wczytajSerializacjąBinarnąToolStripMenuItem;
        private ToolStripMenuItem zapiszSerializacjąXMLToolStripMenuItem;
        private ToolStripMenuItem zapiszSerializacjąJSONToolStripMenuItem;
        private ToolStripMenuItem wczytajSerializacjąXMLToolStripMenuItem;
        private ToolStripMenuItem wczytajSerializacjąJSONToolStripMenuItem;
    }
}