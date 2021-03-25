using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        List<Point> m_lsPoints;
        private Bitmap openImg;
        //setting label's text
        public void SetLabel(int number, string text)
        {
            if (number == 10)
            {
                label10.Text = text;
            }
            else if (number == 11)
            {
                label11.Text = text;
            }
            else if (number == 12)
            {
                label12.Text = text;
            }

        }
        //setting label visibel
        public void SetLabelVisibel(int number, bool flag)
        {
            if (number == 10)
            {
                label10.Visible = flag;
            }
            else if (number == 11)
            {
                label11.Visible = flag;
            }
            else if (number == 12)
            {
                label12.Visible = flag;
            }
        }

        // setting picture boxes' image
        public void SetPictureBox(int number, Bitmap image)
        {
            if (number == 1)
            {
                pictureBox1.Image = image;
            }
            else if (number == 2)
            {
                pictureBox2.Image = image;
            }
            else if (number == 3)
            {
                pictureBox3.Image = image;
            }
            else if (number == 4)
            {
                pictureBox4.Image = image;
            }
        }
        //setting picture box visibel
        public void SetPictureBoxVisibel(int number, bool flag)
        {
            if (number == 2)
            {
                pictureBox2.Visible = flag;
            }
            else if (number == 3)
            {
                pictureBox3.Visible = flag;
            }
            else if (number == 4)
            {
                pictureBox4.Visible = flag;
            }
        }
        // setting charts' value
        public void SetChart(int number, int[] count)
        {
            for (int i = 0; i < 256; i++)
            {
                if (number == 1)
                    chart1.Series[0].Points.AddXY(i + 1, count[i]);
                else
                    chart2.Series[0].Points.AddXY(i + 1, count[i]);
            }
        }
        //setting charts visibel
        public void SetChartVisibel(int number, bool flag)
        {
            if (number == 1)
            {
                chart1.Visible = flag;
            }
            else if (number == 2)
            {
                chart2.Visible = flag;
            }
        }
        public Form1()
        {
            m_lsPoints = new List<Point>();
            InitializeComponent();
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Filter = "All Files|*.*|Bitmap Files(.bmp)|*.bmp|Jpeg File(.jpg)|*.jpg";
            // 選擇我們需要開檔的類型
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {//如果成功開檔
                openImg = new Bitmap(openFileDialog1.FileName);
                //宣告存取影像的 bitmap
                pictureBox1.Image = openImg;
                //讀取的影像展示到 pictureBox
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);
            if (openImg != null)
            {
                RGB_Extract extract = new RGB_Extract();
                Bitmap rImg, gImg, bImg;
                
                // extract R, G and B channel
                rImg = extract.R_Extract(openImg);
                gImg = extract.G_Extract(openImg);
                bImg = extract.B_Extract(openImg);

                if (rImg != null)
                {
                    SetLabel(10, "R channel");
                    SetPictureBox(2, rImg);

                    SetLabelVisibel(10, true);
                    SetPictureBoxVisibel(2, true);
                }
                else
                {
                    SetLabelVisibel(10, false);
                    SetPictureBoxVisibel(2, false);
                }
                if (gImg != null)
                {
                    SetLabel(11, "G channel");
                    SetPictureBox(3, gImg);

                    SetLabelVisibel(11, true);
                    SetPictureBoxVisibel(3, true);
                }
                else
                {
                    SetLabelVisibel(11, false);
                    SetPictureBoxVisibel(3, false);
                }
                if (bImg != null)
                {
                    SetLabel(12, "B channel");
                    SetPictureBox(4, bImg);

                    SetLabelVisibel(12, true);
                    SetPictureBoxVisibel(4, true);
                }
                else
                {
                    SetLabelVisibel(12, false);
                    SetPictureBoxVisibel(4, false);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);
            if (openImg != null)
            {
                Grayscale trans = new Grayscale();
                Bitmap grayImg = new Bitmap(openImg);
                // transform image to grayscale
                grayImg = trans.Transform(openImg);
                if (grayImg != null)
                {
                    SetLabel(10, "Grayscale");
                    SetPictureBox(2, grayImg);

                    SetLabelVisibel(10, true);
                    SetPictureBoxVisibel(2, true);
                }
                else
                {
                    SetLabelVisibel(10, false);
                    SetPictureBoxVisibel(2, false);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);
            if (openImg != null)
            {
                Filter filter = new Filter();
                Bitmap meanImg = new Bitmap(openImg);
                Bitmap medianImg = new Bitmap(openImg);

                // do mean filter
                meanImg = filter.Mean(openImg);
                // do median filter
                medianImg = filter.Median(openImg);

                if (meanImg != null)
                {
                    SetLabel(10, "Mean");
                    SetPictureBox(2, meanImg);

                    SetLabelVisibel(10, true);
                    SetPictureBoxVisibel(2, true);
                }
                else
                {
                    SetLabelVisibel(10, false);
                    SetPictureBoxVisibel(2, false);
                }
                if (medianImg != null)
                {
                    SetLabel(11, "Median");
                    SetPictureBox(3, medianImg);

                    SetLabelVisibel(11, true);
                    SetPictureBoxVisibel(3, true);
                }
                else
                {
                    SetLabelVisibel(11, false);
                    SetPictureBoxVisibel(3, false);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);
            if (openImg != null)
            {
                Histogram transform = new Histogram();
                int[] count = new int[256];
                int[] count2 = new int[256];
                Bitmap equalize = new Bitmap(openImg);

                // do histogram equalization
                count = transform.Origin_Value(openImg);
                count2 = transform.Equalize_Value(openImg);
                equalize = transform.Equalize(openImg);
               
                if (equalize != null)
                {
                    //show picture
                    SetLabel(10, "Equalize");
                    SetPictureBox(2, equalize);
                    // show histogram chart
                    SetChart(1, count);
                    SetChart(2, count2);

                    SetLabelVisibel(10, true);
                    SetPictureBoxVisibel(2, true);
                    SetChartVisibel(1, true);
                    SetChartVisibel(2, true);
                }
                else
                {
                    SetLabelVisibel(10, false);
                    SetPictureBoxVisibel(2, false);
                    SetChartVisibel(1, false);
                    SetChartVisibel(2, false);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);
            if (openImg != null)
            {
                Bitmap thresholdImg = new Bitmap(openImg);
                Thresholding trans = new Thresholding();

                // do thresholding
                thresholdImg = trans.Transform(openImg, hScrollBar1.Value);

                //show picture
                SetLabel(10, "Thresholding, Value = " + hScrollBar1.Value);
                SetPictureBox(2, thresholdImg);

                SetLabelVisibel(10, true);
                SetPictureBoxVisibel(2, true);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);
            if (openImg != null)
            {
                Sobel_Edge_Detect detect = new Sobel_Edge_Detect();
                Bitmap verticalImg = new Bitmap(openImg);
                Bitmap horizontalImg = new Bitmap(openImg);
                Bitmap combineImg = new Bitmap(openImg);

                // do edge detect
                verticalImg = detect.Vertical(openImg);
                horizontalImg = detect.Horizontal(openImg);
                combineImg = detect.Combine(openImg);

                if (verticalImg != null)
                {
                    SetLabel(10, "vertical");
                    SetPictureBox(2, verticalImg);

                    SetLabelVisibel(10, true);
                    SetPictureBoxVisibel(2, true);
                }
                else
                {
                    SetLabelVisibel(10, false);
                    SetPictureBoxVisibel(2, false);
                }
                if (horizontalImg != null)
                {
                    SetLabel(11, "horizontal");
                    SetPictureBox(3, horizontalImg);

                    SetLabelVisibel(11, true);
                    SetPictureBoxVisibel(3, true);
                }
                else
                {
                    SetLabelVisibel(11, false);
                    SetPictureBoxVisibel(3, false);
                }
                if (combineImg != null)
                {
                    SetLabel(12, "combine");
                    SetPictureBox(4, combineImg);

                    SetLabelVisibel(12, true);
                    SetPictureBoxVisibel(4, true);
                }
                else
                {
                    SetLabelVisibel(12, false);
                    SetPictureBoxVisibel(4, false);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);
            if (openImg != null)
            {
                Bitmap combineImg = new Bitmap(openImg);
                Bitmap thresholdImg = new Bitmap(openImg);
                Bitmap overlapImg = new Bitmap(openImg);
                Sobel_Edge_Detect detect = new Sobel_Edge_Detect();
                Overlap trans = new Overlap();

                combineImg = detect.Combine(openImg);
                thresholdImg = trans.Threshold(combineImg, hScrollBar2.Value);
                overlapImg = trans.Overlapping(openImg, thresholdImg);

                //show image
                if (thresholdImg != null)
                {
                    SetLabel(10, "threshold");
                    SetPictureBox(2, thresholdImg);

                    SetLabelVisibel(10, true);
                    SetPictureBoxVisibel(2, true);
                }
                else
                {
                    SetLabelVisibel(10, false);
                    SetPictureBoxVisibel(2, false);
                }
                if (combineImg != null)
                {
                    SetLabel(11, "combine");
                    SetPictureBox(3, combineImg);

                    SetLabelVisibel(11, true);
                    SetPictureBoxVisibel(3, true);
                }
                else
                {
                    SetLabelVisibel(11, false);
                    SetPictureBoxVisibel(3, false);
                }
                if (overlapImg != null)
                {
                    SetLabel(12, "overlap");
                    SetPictureBox(4, overlapImg);

                    SetLabelVisibel(12, true);
                    SetPictureBoxVisibel(4, true);
                }
                else
                {
                    SetLabelVisibel(12, false);
                    SetPictureBoxVisibel(4, false);
                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);
            
            
            if (openImg != null)
            {
                Bitmap rotateImg, stretchImg;
                //Bitmap inv_rotateImg, inv_stretchImg;
                Change_Form cf = new Change_Form();
                double degree, x_stretch, y_stretch;
                // get rotate degree
                if (textBox1.Text == "")
                    degree = 0;
                else
                    degree = Convert.ToDouble(textBox1.Text);

                // do rotate
                rotateImg = cf.Rotate(openImg, degree);

                // get stretch value
                if (textBox2.Text == "")
                    x_stretch = 1;
                else
                    x_stretch = Convert.ToDouble(textBox2.Text);

                if (textBox3.Text == "")
                    y_stretch = 1;
                else
                    y_stretch = Convert.ToDouble(textBox3.Text);

                // do stretch
                stretchImg = cf.Stretch(rotateImg, x_stretch, y_stretch);

                // do  invrotate
                //inv_rotateImg = cf.invRotate(openImg, degree);



                if (stretchImg != null)
                {
                    SetLabel(10, "rotate");
                    SetPictureBox(2, stretchImg);

                    SetLabelVisibel(10, true);
                    SetPictureBoxVisibel(2, true);
                }
                else
                {
                    SetLabelVisibel(10, false);
                    SetPictureBoxVisibel(2, false);
                }
                /***
                if (inv_rotateImg != null)
                {
                    SetLabel(11, "registered");
                    SetPictureBox(3, inv_rotateImg);

                    SetLabelVisibel(11, true);
                    SetPictureBoxVisibel(3, true);
                }
                else
                {
                    SetLabelVisibel(11, false);
                    SetPictureBoxVisibel(3, false);
                }
                ***/
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SetLabelVisibel(10, false);
            SetLabelVisibel(11, false);
            SetLabelVisibel(12, false);
            SetPictureBoxVisibel(1, false);
            SetPictureBoxVisibel(2, false);
            SetPictureBoxVisibel(3, false);
            SetPictureBoxVisibel(4, false);
            SetChartVisibel(1, false);
            SetChartVisibel(2, false);
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private string sType;//用来记录button的Name

        private void button11_Click(object sender, EventArgs e)
        {
            sType = "button11";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();//创建一个画板
            if (sType == "button11")
            {
                if (e.Button == MouseButtons.Left)
                {
                    g.FillEllipse(Brushes.Red, e.X, e.Y, 20, 20);
                    Point pt = new Point(e.X, e.Y);
                    m_lsPoints.Add(pt);
                }
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox2.CreateGraphics();//创建一个画板
            if (sType == "button11")
            {
                if (e.Button == MouseButtons.Left)
                {
                    g.FillEllipse(Brushes.Red, e.X, e.Y, 20, 20);
                    Point pt = new Point(e.X, e.Y);
                    m_lsPoints.Add(pt);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (openImg != null)
            {
                Bitmap inv_rotateImg;
                double degree, x_stretch, y_stretch;
                Change_Form cf = new Change_Form();

                // get rotate degree
                if (textBox1.Text == "")
                    degree = 0;
                else
                    degree = Convert.ToDouble(textBox1.Text);

                // get stretch value
                if (textBox2.Text == "")
                    x_stretch = 1;
                else
                    x_stretch = Convert.ToDouble(textBox2.Text);

                if (textBox3.Text == "")
                    y_stretch = 1;
                else
                    y_stretch = Convert.ToDouble(textBox3.Text);

                // do  invrotate
                inv_rotateImg = cf.invRotate(openImg, degree);
                
                if (inv_rotateImg != null)
                {
                    SetLabel(11, "registered");
                    SetPictureBox(3, inv_rotateImg);

                    SetLabelVisibel(11, true);
                    SetPictureBoxVisibel(3, true);
                }
                else
                {
                    SetLabelVisibel(11, false);
                    SetPictureBoxVisibel(3, false);
                }
            }
        }
    }
}
