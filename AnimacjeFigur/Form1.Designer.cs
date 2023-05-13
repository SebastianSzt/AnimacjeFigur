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
            zapiszToolStripMenuItem = new ToolStripMenuItem();
            animacjaToolStripMenuItem = new ToolStripMenuItem();
            uruchomToolStripMenuItem = new ToolStripMenuItem();
            zatrzymajToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
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
            wczytajToolStripMenuItem.Enabled = false;
            wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            wczytajToolStripMenuItem.Size = new Size(115, 22);
            wczytajToolStripMenuItem.Text = "Wczytaj";
            wczytajToolStripMenuItem.Click += loadStatus;
            // 
            // zapiszToolStripMenuItem
            // 
            zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            zapiszToolStripMenuItem.Size = new Size(115, 22);
            zapiszToolStripMenuItem.Text = "Zapisz";
            zapiszToolStripMenuItem.Click += saveStatus;
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
            uruchomToolStripMenuItem.Click += timerStart;
            // 
            // zatrzymajToolStripMenuItem
            // 
            zatrzymajToolStripMenuItem.Enabled = false;
            zatrzymajToolStripMenuItem.Name = "zatrzymajToolStripMenuItem";
            zatrzymajToolStripMenuItem.Size = new Size(126, 22);
            zatrzymajToolStripMenuItem.Text = "Zatrzymaj";
            zatrzymajToolStripMenuItem.Click += timerStop;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(784, 384);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // timer1
            // 
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 411);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(200, 200);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Animacje Figur";
            ResizeEnd += checkPosition;
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
        private Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}