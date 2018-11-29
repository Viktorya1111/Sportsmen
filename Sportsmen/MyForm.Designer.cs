namespace Sportsmen
{
    partial class MyForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Start = new System.Windows.Forms.Button();
            this.injury = new System.Windows.Forms.TextBox();
            this.Input = new System.Windows.Forms.Button();
            this.speed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(472, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 0;
            this.Start.Text = "start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // injury
            // 
            this.injury.Location = new System.Drawing.Point(472, 128);
            this.injury.Name = "injury";
            this.injury.Size = new System.Drawing.Size(75, 20);
            this.injury.TabIndex = 3;
            this.injury.Text = "0,02";
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(472, 70);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(75, 23);
            this.Input.TabIndex = 4;
            this.Input.Text = "input";
            this.Input.UseVisualStyleBackColor = true;
            this.Input.Click += new System.EventHandler(this.Input_Click);
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(472, 165);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(75, 20);
            this.speed.TabIndex = 5;
            this.speed.Text = "0,5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(470, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Injury Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Speed";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 330);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.injury);
            this.Controls.Add(this.Start);
            this.Name = "MyForm";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox injury;
        private System.Windows.Forms.Button Input;
        private System.Windows.Forms.TextBox speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

