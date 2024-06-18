
using System;
using System.Windows.Forms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Design;

namespace Уравнения
{
    public partial class Form1 : Form
    {
        public double xt;
        public Form1()
        {
            InitializeComponent();
            textBox12.Text = "0";
            textBox11.Text = "10";
            textBox10.Text = "0";
            textBox9.Text = "10";
        }

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }
        private List<Point> pointsList = new List<Point>();


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBox1.SelectionStart == 0) {; }
            else
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBox3.SelectionStart == 0) {; }
            else
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                {
                    e.Handled = true;
                }
            }
        }



        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBox9.SelectionStart == 0) {; }
            else
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBox10.SelectionStart == 0) {; }
            else
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBox11.SelectionStart == 0) {; }
            else
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBox12.SelectionStart == 0) {; }
            else
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                {
                    e.Handled = true;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {


            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            chart1.Visible = true;
            chart1.Series.Clear(); chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());
            double xmin = Convert.ToDouble(textBox12.Text);
            double xmax = Convert.ToDouble(textBox11.Text);
            double ymin = Convert.ToDouble(textBox10.Text);
            double ymax = Convert.ToDouble(textBox9.Text);
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            chart1.ChartAreas[0].AxisX.Maximum = xmax; ;
            chart1.ChartAreas[0].AxisY.Minimum = ymin; ;
            chart1.ChartAreas[0].AxisY.Maximum = ymax; ;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 5;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 5;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();

            Series series = new Series();
            Series series1 = new Series();
            Series series2 = new Series();
            series.ChartType = SeriesChartType.Spline;
            series.Points.Clear();
            series1.ChartType = SeriesChartType.Spline;
            series1.Points.Clear();
            series.BorderWidth = 2;
            series2.ChartType = SeriesChartType.Spline;
            series2.Points.Clear();
            double step = Convert.ToDouble(textBox3.Text);
            double angle = Convert.ToDouble(textBox1.Text);
            double speedX,
                   speedY, 
                   x = 0, 
                   y = 0, 
                   speedXSup, 
                   speedYSup, 
                   c = 0.0075, 
                   g = 9.81,
                   mass = 120, 
                   massEnd = 15,
                   timeLostFuel = 10,
                   gazSpeed = 1800,
                   speedStart = 20, 
                   timeCur = 0, 
                   mt,
                   time = (mass - massEnd) / timeLostFuel;

            angle = angle * Math.PI / 180;
            speedX = speedStart * Math.Cos(angle);
            speedY = speedStart * Math.Sin(angle);
            while (y >= 0)
            {
                series.Points.AddXY(x / 1000, y / 1000);
                speedXSup = speedX;
                speedYSup = speedY;
                timeCur += step;
                if (timeCur <= time)
                {
                    mt = 120 - timeCur * timeLostFuel;
                    speedX += (timeLostFuel * gazSpeed * speedXSup / Math.Sqrt(speedXSup * speedXSup + speedYSup * speedYSup) - c * Math.Sqrt(speedXSup * speedXSup + speedYSup * speedYSup) * speedXSup) / mt * step;
                    speedY += (-g + (timeLostFuel * gazSpeed * speedYSup / Math.Sqrt(speedXSup * speedXSup + speedYSup * speedYSup) - c * Math.Sqrt(speedXSup * speedXSup + speedYSup * speedYSup) * speedYSup) / mt) * step;
        
                }
                else
                {
                    if (Math.Round(timeCur, 1) == time+step) xt = x / 1000;
                    speedX += (-c * Math.Sqrt(speedXSup * speedXSup + speedYSup * speedYSup) * speedXSup) / massEnd * step;
                    speedY += (-g - (c * Math.Sqrt(speedXSup * speedXSup + speedYSup * speedYSup) * speedYSup) / massEnd) * step;
                }
                x += speedX * step;
                y += speedY * step;

            }

            chart1.Series.Add(series);
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
