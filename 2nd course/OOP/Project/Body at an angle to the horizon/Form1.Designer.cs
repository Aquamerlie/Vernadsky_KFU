
namespace Modelirovanie
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chartTr = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBoxVmax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWind = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxV0 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFi = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxdt = new System.Windows.Forms.TextBox();
            this.chartVt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartTr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVt)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chartTr
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTr.ChartAreas.Add(chartArea1);
            this.chartTr.Location = new System.Drawing.Point(37, 164);
            this.chartTr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartTr.Name = "chartTr";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "Series1";
            this.chartTr.Series.Add(series1);
            this.chartTr.Size = new System.Drawing.Size(490, 337);
            this.chartTr.TabIndex = 1;
            this.chartTr.Text = "chart1";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonStart.Location = new System.Drawing.Point(1052, 512);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(133, 43);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBoxVmax
            // 
            this.textBoxVmax.Location = new System.Drawing.Point(580, 23);
            this.textBoxVmax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxVmax.Name = "textBoxVmax";
            this.textBoxVmax.Size = new System.Drawing.Size(132, 22);
            this.textBoxVmax.TabIndex = 3;
            this.textBoxVmax.Text = "150";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(400, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 49);
            this.label1.TabIndex = 4;
            this.label1.Text = "Установившееся скорость";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxWind
            // 
            this.textBoxWind.Location = new System.Drawing.Point(580, 87);
            this.textBoxWind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxWind.Name = "textBoxWind";
            this.textBoxWind.Size = new System.Drawing.Size(132, 22);
            this.textBoxWind.TabIndex = 5;
            this.textBoxWind.Text = "-10";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(400, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ветер (\"-\")";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(23, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 49);
            this.label4.TabIndex = 8;
            this.label4.Text = "Начальная скорость";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxV0
            // 
            this.textBoxV0.Location = new System.Drawing.Point(191, 23);
            this.textBoxV0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxV0.Name = "textBoxV0";
            this.textBoxV0.Size = new System.Drawing.Size(132, 22);
            this.textBoxV0.TabIndex = 9;
            this.textBoxV0.Text = "750";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Location = new System.Drawing.Point(23, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Угол";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxFi
            // 
            this.textBoxFi.Location = new System.Drawing.Point(191, 89);
            this.textBoxFi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFi.Name = "textBoxFi";
            this.textBoxFi.Size = new System.Drawing.Size(132, 22);
            this.textBoxFi.TabIndex = 13;
            this.textBoxFi.Text = "45";
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonStop.Location = new System.Drawing.Point(1052, 562);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(133, 43);
            this.buttonStop.TabIndex = 14;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(884, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Шаг по времени";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxdt
            // 
            this.textBoxdt.Location = new System.Drawing.Point(1052, 50);
            this.textBoxdt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxdt.Name = "textBoxdt";
            this.textBoxdt.Size = new System.Drawing.Size(132, 22);
            this.textBoxdt.TabIndex = 0;
            this.textBoxdt.Text = "0.1";
            // 
            // chartVt
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVt.ChartAreas.Add(chartArea2);
            this.chartVt.Location = new System.Drawing.Point(580, 164);
            this.chartVt.Name = "chartVt";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Series1";
            this.chartVt.Series.Add(series2);
            this.chartVt.Size = new System.Drawing.Size(484, 341);
            this.chartVt.TabIndex = 15;
            this.chartVt.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(1193, 641);
            this.Controls.Add(this.chartVt);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textBoxFi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxV0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxVmax);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.chartTr);
            this.Controls.Add(this.textBoxdt);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Движение тела, брошенного под углом к горизонту с учётом ветра";
            ((System.ComponentModel.ISupportInitialize)(this.chartTr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTr;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBoxVmax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxV0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFi;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxdt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVt;
    }
}

