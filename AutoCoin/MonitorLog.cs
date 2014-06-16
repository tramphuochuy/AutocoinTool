using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class MonitorLog : UserControl
    {

        Graphics graphics;
        private Bitmap bitmap = new Bitmap(100, 100);
        DataTable Data = new DataTable();
        public int MaxSpeed = 0;
        public double AvgSpeed = 0;
        List<string> ListNode = new List<string>();

        public string UserCode = "";
        public string Worker = "";

        public MonitorLog( )
        {
            InitializeComponent();
        }

        private void MonitorLog_Load(object sender, EventArgs e)
        {
            RefreshGraphic();
        }


        public void RefreshGraphic()
        {
            ListNode.Clear();
            float[] dashValues = { 5, 2, 15, 4 };
            Pen blackPen = new Pen(Color.Gray,DBase.FloatReturn(0.5));
            blackPen.DashPattern = dashValues;

            try
            {
                Data = DStatic.MonitorLog(UserCode,Worker, DateTime.Now, 5);
                MaxSpeed = DBase.IntReturn(Data.Compute("max(SPEED)", string.Empty));
                AvgSpeed = DBase.DoubleReturn(Data.Compute("avg(SPEED)", string.Empty));
        
                bitmap = new Bitmap(panGraphic.Width, panGraphic.Height);
                graphics = Graphics.FromImage(bitmap);

                //drawline
                //Drawline

                int X = lbStart.Location.X;
                int Y = lbStart.Location.Y;

                float W = 800;
                float H = 400;

                float pTime = W/1440;  // Y
                float pSpeed = H/MaxSpeed; // X

                graphics.DrawLine(DBase.PenGridline, X, Y , X, Y - 400 - 50 );
                graphics.DrawLine(DBase.PenGridline, X - 5 , Y - 400 - 50 + 5, X, Y - 400 - 50);
                graphics.DrawLine(DBase.PenGridline, X + 5, Y - 400 - 50 + 5, X, Y - 400 - 50);

                graphics.DrawLine(DBase.PenGridline, X, Y, X + 800 + 50, Y);
                graphics.DrawLine(DBase.PenGridline, X + 800 + 50 - 5 , Y - 5, X + 800 + 50, Y);
                graphics.DrawLine(DBase.PenGridline, X + 800 + 50 - 5, Y + 5, X + 800 + 50, Y);

                //AVG Speed & MaxSpeed
                graphics.DrawLine(blackPen, X, Y - DBase.IntReturn(pSpeed * AvgSpeed), X + 800 + 50, Y - DBase.IntReturn(pSpeed * AvgSpeed));
                graphics.DrawLine(blackPen, X, Y - DBase.IntReturn(pSpeed * MaxSpeed), X + 800 + 50, Y - DBase.IntReturn(pSpeed * MaxSpeed));
                
                Font drawFont = new Font("Arial",10,FontStyle.Regular);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                graphics.DrawString("Avg Speed = " + AvgSpeed.ToString() + " Kh/s", drawFont, drawBrush, new Point(X, Y - DBase.IntReturn(pSpeed * AvgSpeed) + 5));

              
                for (int i = 0; i < Data.Rows.Count - 1;i++ )
                {  
                    DataRow dr1 = Data.Rows[i];
                    double speed1 = DBase.DoubleReturn(dr1["SPEED"]);
                    int Time1 = DBase.IntReturn(dr1["TIME"]);

                    DataRow dr2 = Data.Rows[i+1];
                    double speed2 = DBase.DoubleReturn(dr2["SPEED"]);
                    int Time2 = DBase.IntReturn(dr2["TIME"]);

                    int PointSpeed1 = Y - DBase.IntReturn( pSpeed * speed1  );
                    int PointTime1 = X +  DBase.IntReturn( pTime * Time1  );

                    Point A = new Point( PointTime1,PointSpeed1 ) ;

                    int PointSpeed2 = Y - DBase.IntReturn( pSpeed * speed2  );
                    int PointTime2 = X +  DBase.IntReturn( pTime * Time2  );

                    Point B = new Point( PointTime2,PointSpeed2 ) ;

                    graphics.DrawLine(DBase.PenGridline,A,B);


                }


                panGraphic.BackgroundImage = bitmap;

            }
            catch (Exception ex)
            {
                DBase.ShowMessage(ex.ToString(), 100);
            }
        }

        private void cmsRefresh_Click(object sender, EventArgs e)
        {
           
            RefreshGraphic();
        }
    }
}
