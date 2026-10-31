namespace Exercicios_POO_Tela
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
            lblDiscente = new Label();
            lblResponsavel = new Label();
            lblDisciplina = new Label();
            cmbDisciplina = new ComboBox();
            lblModalidade = new Label();
            cmbModalidade = new ComboBox();
            lblDuracao = new Label();
            numDuracao = new NumericUpDown();
            lblExtra = new Label();
            numExtra = new NumericUpDown();
            lblQuestoes = new Label();
            numQuestoes = new NumericUpDown();
            chkResumo = new CheckBox();
            btnRegistrar = new Button();
            btnNotificar = new Button();
            lblProgresso = new Label();
            progressBar1 = new ProgressBar();
            lblHistorico = new Label();
            listBoxHistorico = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numDuracao).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numExtra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuestoes).BeginInit();
            SuspendLayout();
            // 
            // lblDiscente
            // 
            lblDiscente.AutoSize = true;
            lblDiscente.Location = new Point(20, 15);
            lblDiscente.Name = "lblDiscente";
            lblDiscente.Size = new Size(52, 15);
            lblDiscente.TabIndex = 0;
            lblDiscente.Text = "Discente";
            // 
            // lblResponsavel
            // 
            lblResponsavel.AutoSize = true;
            lblResponsavel.Location = new Point(20, 40);
            lblResponsavel.Name = "lblResponsavel";
            lblResponsavel.Size = new Size(72, 15);
            lblResponsavel.TabIndex = 1;
            lblResponsavel.Text = "Responsável";
            // 
            // lblDisciplina
            // 
            lblDisciplina.AutoSize = true;
            lblDisciplina.Location = new Point(20, 78);
            lblDisciplina.Name = "lblDisciplina";
            lblDisciplina.Size = new Size(62, 15);
            lblDisciplina.TabIndex = 2;
            lblDisciplina.Text = "Disciplina:";
            // 
            // cmbDisciplina
            // 
            cmbDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDisciplina.FormattingEnabled = true;
            cmbDisciplina.Location = new Point(140, 75);
            cmbDisciplina.Name = "cmbDisciplina";
            cmbDisciplina.Size = new Size(380, 23);
            cmbDisciplina.TabIndex = 3;
            // 
            // lblModalidade
            // 
            lblModalidade.AutoSize = true;
            lblModalidade.Location = new Point(20, 113);
            lblModalidade.Name = "lblModalidade";
            lblModalidade.Size = new Size(74, 15);
            lblModalidade.TabIndex = 4;
            lblModalidade.Text = "Modalidade:";
            // 
            // cmbModalidade
            // 
            cmbModalidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModalidade.FormattingEnabled = true;
            cmbModalidade.Location = new Point(140, 110);
            cmbModalidade.Name = "cmbModalidade";
            cmbModalidade.Size = new Size(380, 23);
            cmbModalidade.TabIndex = 5;
            cmbModalidade.SelectedIndexChanged += cmbModalidade_SelectedIndexChanged;
            // 
            // lblDuracao
            // 
            lblDuracao.AutoSize = true;
            lblDuracao.Location = new Point(20, 148);
            lblDuracao.Name = "lblDuracao";
            lblDuracao.Size = new Size(87, 15);
            lblDuracao.TabIndex = 6;
            lblDuracao.Text = "Duração (min):";
            // 
            // numDuracao
            // 
            numDuracao.Location = new Point(140, 145);
            numDuracao.Maximum = new decimal(new int[] { 480, 0, 0, 0 });
            numDuracao.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDuracao.Name = "numDuracao";
            numDuracao.Size = new Size(100, 23);
            numDuracao.TabIndex = 7;
            numDuracao.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // lblExtra
            // 
            lblExtra.AutoSize = true;
            lblExtra.Location = new Point(20, 183);
            lblExtra.Name = "lblExtra";
            lblExtra.Size = new Size(105, 15);
            lblExtra.TabIndex = 8;
            lblExtra.Text = "Ciclos completos:";
            // 
            // numExtra
            // 
            numExtra.Location = new Point(140, 180);
            numExtra.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numExtra.Name = "numExtra";
            numExtra.Size = new Size(100, 23);
            numExtra.TabIndex = 9;
            // 
            // lblQuestoes
            // 
            lblQuestoes.AutoSize = true;
            lblQuestoes.Location = new Point(20, 218);
            lblQuestoes.Name = "lblQuestoes";
            lblQuestoes.Size = new Size(108, 15);
            lblQuestoes.TabIndex = 10;
            lblQuestoes.Text = "Total de questões:";
            // 
            // numQuestoes
            // 
            numQuestoes.Location = new Point(140, 215);
            numQuestoes.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuestoes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuestoes.Name = "numQuestoes";
            numQuestoes.Size = new Size(100, 23);
            numQuestoes.TabIndex = 11;
            numQuestoes.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // chkResumo
            // 
            chkResumo.AutoSize = true;
            chkResumo.Location = new Point(140, 217);
            chkResumo.Name = "chkResumo";
            chkResumo.Size = new Size(87, 19);
            chkResumo.TabIndex = 12;
            chkResumo.Text = "Fez resumo";
            chkResumo.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(20, 255);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(200, 32);
            btnRegistrar.TabIndex = 13;
            btnRegistrar.Text = "Registrar Estudo";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnNotificar
            // 
            btnNotificar.Location = new Point(320, 255);
            btnNotificar.Name = "btnNotificar";
            btnNotificar.Size = new Size(200, 32);
            btnNotificar.TabIndex = 14;
            btnNotificar.Text = "Notificar Responsável";
            btnNotificar.UseVisualStyleBackColor = true;
            btnNotificar.Click += btnNotificar_Click;
            // 
            // lblProgresso
            // 
            lblProgresso.AutoSize = true;
            lblProgresso.Location = new Point(20, 305);
            lblProgresso.Name = "lblProgresso";
            lblProgresso.Size = new Size(82, 15);
            lblProgresso.TabIndex = 15;
            lblProgresso.Text = "Meta semanal";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(20, 330);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(500, 24);
            progressBar1.TabIndex = 16;
            // 
            // lblHistorico
            // 
            lblHistorico.AutoSize = true;
            lblHistorico.Location = new Point(20, 370);
            lblHistorico.Name = "lblHistorico";
            lblHistorico.Size = new Size(121, 15);
            lblHistorico.TabIndex = 17;
            lblHistorico.Text = "Histórico de sessões:";
            // 
            // listBoxHistorico
            // 
            listBoxHistorico.FormattingEnabled = true;
            listBoxHistorico.HorizontalScrollbar = true;
            listBoxHistorico.Location = new Point(20, 395);
            listBoxHistorico.Name = "listBoxHistorico";
            listBoxHistorico.Size = new Size(500, 154);
            listBoxHistorico.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 570);
            Controls.Add(listBoxHistorico);
            Controls.Add(lblHistorico);
            Controls.Add(progressBar1);
            Controls.Add(lblProgresso);
            Controls.Add(btnNotificar);
            Controls.Add(btnRegistrar);
            Controls.Add(chkResumo);
            Controls.Add(numQuestoes);
            Controls.Add(lblQuestoes);
            Controls.Add(numExtra);
            Controls.Add(lblExtra);
            Controls.Add(numDuracao);
            Controls.Add(lblDuracao);
            Controls.Add(cmbModalidade);
            Controls.Add(lblModalidade);
            Controls.Add(cmbDisciplina);
            Controls.Add(lblDisciplina);
            Controls.Add(lblResponsavel);
            Controls.Add(lblDiscente);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Painel de Estudos";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numDuracao).EndInit();
            ((System.ComponentModel.ISupportInitialize)numExtra).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuestoes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDiscente;
        private Label lblResponsavel;
        private Label lblDisciplina;
        private ComboBox cmbDisciplina;
        private Label lblModalidade;
        private ComboBox cmbModalidade;
        private Label lblDuracao;
        private NumericUpDown numDuracao;
        private Label lblExtra;
        private NumericUpDown numExtra;
        private Label lblQuestoes;
        private NumericUpDown numQuestoes;
        private CheckBox chkResumo;
        private Button btnRegistrar;
        private Button btnNotificar;
        private Label lblProgresso;
        private ProgressBar progressBar1;
        private Label lblHistorico;
        private ListBox listBoxHistorico;
    }
}