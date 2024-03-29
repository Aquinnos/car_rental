namespace car_rental
{
    partial class glowna
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.guzik_rejstracja = new System.Windows.Forms.Button();
            this.Tytul = new System.Windows.Forms.Label();
            this.oferty = new System.Windows.Forms.Button();
            this.profil = new System.Windows.Forms.Button();
            this.panel_glowny = new System.Windows.Forms.Panel();
            this.Panel_oferty = new System.Windows.Forms.Panel();
            this.button_powrot = new System.Windows.Forms.Button();
            this.oferty_listbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_login = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_haslo_logowanie = new System.Windows.Forms.TextBox();
            this.textBox_login_logowanie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.przejscie_do_rejstracji = new System.Windows.Forms.Button();
            this.panel_rejstracja = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.logi_rejstracja = new System.Windows.Forms.TextBox();
            this.haslo_rejstracja = new System.Windows.Forms.TextBox();
            this.powrot_do_login = new System.Windows.Forms.Button();
            this.potwierdzenie_rejstracji = new System.Windows.Forms.Button();
            this.Wyszukiwarka = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel_profil = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_glowny.SuspendLayout();
            this.Panel_oferty.SuspendLayout();
            this.panel_login.SuspendLayout();
            this.panel_rejstracja.SuspendLayout();
            this.panel_profil.SuspendLayout();
            this.SuspendLayout();
            // 
            // guzik_rejstracja
            // 
            this.guzik_rejstracja.Location = new System.Drawing.Point(485, 104);
            this.guzik_rejstracja.Name = "guzik_rejstracja";
            this.guzik_rejstracja.Size = new System.Drawing.Size(123, 30);
            this.guzik_rejstracja.TabIndex = 0;
            this.guzik_rejstracja.Text = "Login/Rejstracja";
            this.guzik_rejstracja.UseVisualStyleBackColor = true;
            this.guzik_rejstracja.Click += new System.EventHandler(this.Login_rejstracja_Click);
            // 
            // Tytul
            // 
            this.Tytul.AutoSize = true;
            this.Tytul.Location = new System.Drawing.Point(482, 58);
            this.Tytul.Name = "Tytul";
            this.Tytul.Size = new System.Drawing.Size(126, 16);
            this.Tytul.TabIndex = 1;
            this.Tytul.Text = "STRONA GLÓWNA";
            // 
            // oferty
            // 
            this.oferty.Location = new System.Drawing.Point(485, 155);
            this.oferty.Name = "oferty";
            this.oferty.Size = new System.Drawing.Size(123, 35);
            this.oferty.TabIndex = 3;
            this.oferty.Text = "Oferty";
            this.oferty.UseVisualStyleBackColor = true;
            this.oferty.Click += new System.EventHandler(this.oferty_Click);
            // 
            // profil
            // 
            this.profil.Location = new System.Drawing.Point(485, 205);
            this.profil.Name = "profil";
            this.profil.Size = new System.Drawing.Size(123, 28);
            this.profil.TabIndex = 4;
            this.profil.Text = "Profil";
            this.profil.UseVisualStyleBackColor = true;
            this.profil.Click += new System.EventHandler(this.profil_Click);
            // 
            // panel_glowny
            // 
            this.panel_glowny.Controls.Add(this.Tytul);
            this.panel_glowny.Controls.Add(this.guzik_rejstracja);
            this.panel_glowny.Controls.Add(this.oferty);
            this.panel_glowny.Controls.Add(this.profil);
            this.panel_glowny.Location = new System.Drawing.Point(-7, -37);
            this.panel_glowny.Name = "panel_glowny";
            this.panel_glowny.Size = new System.Drawing.Size(1151, 634);
            this.panel_glowny.TabIndex = 5;
            // 
            // Panel_oferty
            // 
            this.Panel_oferty.Controls.Add(this.label8);
            this.Panel_oferty.Controls.Add(this.Wyszukiwarka);
            this.Panel_oferty.Controls.Add(this.button_powrot);
            this.Panel_oferty.Controls.Add(this.oferty_listbox);
            this.Panel_oferty.Controls.Add(this.label1);
            this.Panel_oferty.Location = new System.Drawing.Point(-4, -17);
            this.Panel_oferty.Name = "Panel_oferty";
            this.Panel_oferty.Size = new System.Drawing.Size(1136, 578);
            this.Panel_oferty.TabIndex = 6;
            // 
            // button_powrot
            // 
            this.button_powrot.Location = new System.Drawing.Point(39, 516);
            this.button_powrot.Name = "button_powrot";
            this.button_powrot.Size = new System.Drawing.Size(85, 43);
            this.button_powrot.TabIndex = 2;
            this.button_powrot.Text = "powrot";
            this.button_powrot.UseVisualStyleBackColor = true;
            this.button_powrot.Click += new System.EventHandler(this.powrot_Click);
            // 
            // oferty_listbox
            // 
            this.oferty_listbox.FormattingEnabled = true;
            this.oferty_listbox.ItemHeight = 16;
            this.oferty_listbox.Items.AddRange(new object[] {
            "tutaj wprowadzić listę z ofertami"});
            this.oferty_listbox.Location = new System.Drawing.Point(675, 229);
            this.oferty_listbox.Name = "oferty_listbox";
            this.oferty_listbox.Size = new System.Drawing.Size(319, 228);
            this.oferty_listbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "oferty";
            // 
            // panel_login
            // 
            this.panel_login.Controls.Add(this.przejscie_do_rejstracji);
            this.panel_login.Controls.Add(this.button2);
            this.panel_login.Controls.Add(this.textBox_haslo_logowanie);
            this.panel_login.Controls.Add(this.textBox_login_logowanie);
            this.panel_login.Controls.Add(this.label4);
            this.panel_login.Controls.Add(this.label3);
            this.panel_login.Controls.Add(this.label2);
            this.panel_login.Location = new System.Drawing.Point(0, 0);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(1132, 590);
            this.panel_login.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(35, 485);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 43);
            this.button2.TabIndex = 5;
            this.button2.Text = "powrot";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.powrot_Click);
            // 
            // textBox_haslo_logowanie
            // 
            this.textBox_haslo_logowanie.Location = new System.Drawing.Point(669, 239);
            this.textBox_haslo_logowanie.Name = "textBox_haslo_logowanie";
            this.textBox_haslo_logowanie.Size = new System.Drawing.Size(179, 22);
            this.textBox_haslo_logowanie.TabIndex = 4;
            // 
            // textBox_login_logowanie
            // 
            this.textBox_login_logowanie.Location = new System.Drawing.Point(655, 114);
            this.textBox_login_logowanie.Name = "textBox_login_logowanie";
            this.textBox_login_logowanie.Size = new System.Drawing.Size(194, 22);
            this.textBox_login_logowanie.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(668, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "haslo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "logowanie";
            // 
            // przejscie_do_rejstracji
            // 
            this.przejscie_do_rejstracji.Location = new System.Drawing.Point(712, 467);
            this.przejscie_do_rejstracji.Name = "przejscie_do_rejstracji";
            this.przejscie_do_rejstracji.Size = new System.Drawing.Size(213, 61);
            this.przejscie_do_rejstracji.TabIndex = 6;
            this.przejscie_do_rejstracji.Text = "zarejstruj się";
            this.przejscie_do_rejstracji.UseVisualStyleBackColor = true;
            this.przejscie_do_rejstracji.Click += new System.EventHandler(this.przejscie_do_rejstracji_Click);
            // 
            // panel_rejstracja
            // 
            this.panel_rejstracja.Controls.Add(this.potwierdzenie_rejstracji);
            this.panel_rejstracja.Controls.Add(this.powrot_do_login);
            this.panel_rejstracja.Controls.Add(this.haslo_rejstracja);
            this.panel_rejstracja.Controls.Add(this.logi_rejstracja);
            this.panel_rejstracja.Controls.Add(this.label7);
            this.panel_rejstracja.Controls.Add(this.label6);
            this.panel_rejstracja.Controls.Add(this.label5);
            this.panel_rejstracja.Location = new System.Drawing.Point(0, 0);
            this.panel_rejstracja.Name = "panel_rejstracja";
            this.panel_rejstracja.Size = new System.Drawing.Size(1137, 582);
            this.panel_rejstracja.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Rejstracja";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(652, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "ustaw login";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(652, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "ustaw haslo";
            // 
            // logi_rejstracja
            // 
            this.logi_rejstracja.Location = new System.Drawing.Point(658, 146);
            this.logi_rejstracja.Name = "logi_rejstracja";
            this.logi_rejstracja.Size = new System.Drawing.Size(121, 22);
            this.logi_rejstracja.TabIndex = 3;
            // 
            // haslo_rejstracja
            // 
            this.haslo_rejstracja.Location = new System.Drawing.Point(657, 247);
            this.haslo_rejstracja.Name = "haslo_rejstracja";
            this.haslo_rejstracja.Size = new System.Drawing.Size(121, 22);
            this.haslo_rejstracja.TabIndex = 4;
            // 
            // powrot_do_login
            // 
            this.powrot_do_login.Location = new System.Drawing.Point(34, 489);
            this.powrot_do_login.Name = "powrot_do_login";
            this.powrot_do_login.Size = new System.Drawing.Size(114, 34);
            this.powrot_do_login.TabIndex = 5;
            this.powrot_do_login.Text = "powrot";
            this.powrot_do_login.UseVisualStyleBackColor = true;
            this.powrot_do_login.Click += new System.EventHandler(this.powrot_do_login_Click);
            // 
            // potwierdzenie_rejstracji
            // 
            this.potwierdzenie_rejstracji.Location = new System.Drawing.Point(804, 473);
            this.potwierdzenie_rejstracji.Name = "potwierdzenie_rejstracji";
            this.potwierdzenie_rejstracji.Size = new System.Drawing.Size(174, 55);
            this.potwierdzenie_rejstracji.TabIndex = 6;
            this.potwierdzenie_rejstracji.Text = "zarejstruj się";
            this.potwierdzenie_rejstracji.UseVisualStyleBackColor = true;
            // 
            // Wyszukiwarka
            // 
            this.Wyszukiwarka.Location = new System.Drawing.Point(115, 163);
            this.Wyszukiwarka.Name = "Wyszukiwarka";
            this.Wyszukiwarka.Size = new System.Drawing.Size(164, 22);
            this.Wyszukiwarka.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(112, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Wyszukiwarka";
            // 
            // panel_profil
            // 
            this.panel_profil.Controls.Add(this.button1);
            this.panel_profil.Controls.Add(this.label12);
            this.panel_profil.Controls.Add(this.listBox1);
            this.panel_profil.Controls.Add(this.label11);
            this.panel_profil.Controls.Add(this.label10);
            this.panel_profil.Controls.Add(this.label9);
            this.panel_profil.Location = new System.Drawing.Point(0, 0);
            this.panel_profil.Name = "panel_profil";
            this.panel_profil.Size = new System.Drawing.Size(1139, 587);
            this.panel_profil.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Profil";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Nazwa użytkownika";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(599, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Historia";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "tutaj wstawic historie wypożyczonych aut użytkownika"});
            this.listBox1.Location = new System.Drawing.Point(598, 146);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(380, 244);
            this.listBox1.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 250);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 4;
            this.label12.Text = "Dane";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 480);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "powrot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.powrot_Click);
            // 
            // glowna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 554);
            this.Controls.Add(this.panel_profil);
            this.Controls.Add(this.panel_glowny);
            this.Controls.Add(this.Panel_oferty);
            this.Controls.Add(this.panel_rejstracja);
            this.Controls.Add(this.panel_login);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "glowna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wypożyczalnia_samochodowa";
            this.panel_glowny.ResumeLayout(false);
            this.panel_glowny.PerformLayout();
            this.Panel_oferty.ResumeLayout(false);
            this.Panel_oferty.PerformLayout();
            this.panel_login.ResumeLayout(false);
            this.panel_login.PerformLayout();
            this.panel_rejstracja.ResumeLayout(false);
            this.panel_rejstracja.PerformLayout();
            this.panel_profil.ResumeLayout(false);
            this.panel_profil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button guzik_rejstracja;
        private System.Windows.Forms.Label Tytul;
        private System.Windows.Forms.Button oferty;
        private System.Windows.Forms.Button profil;
        private System.Windows.Forms.Panel panel_glowny;
        private System.Windows.Forms.Panel Panel_oferty;
        private System.Windows.Forms.Button button_powrot;
        private System.Windows.Forms.ListBox oferty_listbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_haslo_logowanie;
        private System.Windows.Forms.TextBox textBox_login_logowanie;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button przejscie_do_rejstracji;
        private System.Windows.Forms.Panel panel_rejstracja;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox haslo_rejstracja;
        private System.Windows.Forms.TextBox logi_rejstracja;
        private System.Windows.Forms.Button powrot_do_login;
        private System.Windows.Forms.Button potwierdzenie_rejstracji;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Wyszukiwarka;
        private System.Windows.Forms.Panel panel_profil;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBox1;
    }
}

