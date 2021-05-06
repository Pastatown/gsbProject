namespace gsbProject
{
    partial class Menu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnClo = new System.Windows.Forms.Button();
            this.btnVal = new System.Windows.Forms.Button();
            this.btnRem = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cboxName = new System.Windows.Forms.ComboBox();
            this.lboxFicheVis = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClo
            // 
            this.btnClo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClo.BackgroundImage")));
            this.btnClo.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClo.ForeColor = System.Drawing.Color.White;
            this.btnClo.Location = new System.Drawing.Point(12, 12);
            this.btnClo.Name = "btnClo";
            this.btnClo.Size = new System.Drawing.Size(398, 138);
            this.btnClo.TabIndex = 0;
            this.btnClo.Text = "Fiches clôturées";
            this.btnClo.UseVisualStyleBackColor = true;
            this.btnClo.Click += new System.EventHandler(this.btnClo_Click);
            // 
            // btnVal
            // 
            this.btnVal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVal.BackgroundImage")));
            this.btnVal.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVal.ForeColor = System.Drawing.Color.White;
            this.btnVal.Location = new System.Drawing.Point(12, 156);
            this.btnVal.Name = "btnVal";
            this.btnVal.Size = new System.Drawing.Size(398, 142);
            this.btnVal.TabIndex = 1;
            this.btnVal.Text = "Fiches validées";
            this.btnVal.UseVisualStyleBackColor = true;
            this.btnVal.Click += new System.EventHandler(this.btnVal_Click);
            // 
            // btnRem
            // 
            this.btnRem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRem.BackgroundImage")));
            this.btnRem.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRem.ForeColor = System.Drawing.Color.White;
            this.btnRem.Location = new System.Drawing.Point(12, 304);
            this.btnRem.Name = "btnRem";
            this.btnRem.Size = new System.Drawing.Size(398, 134);
            this.btnRem.TabIndex = 2;
            this.btnRem.Text = "Fiches remboursées";
            this.btnRem.UseVisualStyleBackColor = true;
            this.btnRem.Click += new System.EventHandler(this.btnRem_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(480, 30);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(288, 18);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Rechercher les fiches d\'un visiteur";
            // 
            // cboxName
            // 
            this.cboxName.FormattingEnabled = true;
            this.cboxName.Location = new System.Drawing.Point(498, 76);
            this.cboxName.Name = "cboxName";
            this.cboxName.Size = new System.Drawing.Size(245, 21);
            this.cboxName.TabIndex = 4;
            this.cboxName.SelectedValueChanged += new System.EventHandler(this.cboxName_SelectedValueChanged);
            // 
            // lboxFicheVis
            // 
            this.lboxFicheVis.BackColor = System.Drawing.Color.White;
            this.lboxFicheVis.FormattingEnabled = true;
            this.lboxFicheVis.Location = new System.Drawing.Point(498, 121);
            this.lboxFicheVis.Name = "lboxFicheVis";
            this.lboxFicheVis.Size = new System.Drawing.Size(245, 160);
            this.lboxFicheVis.TabIndex = 5;
            this.lboxFicheVis.Click += new System.EventHandler(this.lboxFicheVis_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(498, 304);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lboxFicheVis);
            this.Controls.Add(this.cboxName);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnRem);
            this.Controls.Add(this.btnVal);
            this.Controls.Add(this.btnClo);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Name = "Menu";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClo;
        private System.Windows.Forms.Button btnVal;
        private System.Windows.Forms.Button btnRem;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cboxName;
        private System.Windows.Forms.ListBox lboxFicheVis;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

