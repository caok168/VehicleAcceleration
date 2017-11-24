using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dundas.Charting.WinControl;
using VehicleAcceleration.Classes;
using VehicleAcceleration.Model;

namespace VehicleAcceleration.UserControls
{
    public partial class PointChart : UserControl
    {
        private string DEFAULT_CHARTAREA_NAME = "Default";

        private static int typeGloble = 0;

        public List<Model.WaveDataResult> listResult;

        public PointChart()
        {
            InitializeComponent();

            this.Chart1.Click += new EventHandler(Chart1_Click);
            this.Chart1.GetToolTipText += new Dundas.Charting.WinControl.Chart.ToolTipEventHandler(Chart1_GetToolTipText);

            BaseVibChartInit();
        }

        /// <summary>
        /// 基类初始化
        /// </summary>
        private void BaseVibChartInit()
        {
            InitDefaultTitle();
            InitChartArea();
            InitLegend();
            this.Chart1.UI.Toolbar.Enabled = false;
        }


        #region Chart控件的点击与获取ToolTipText事件

        void Chart1_Click(object sender, EventArgs e)
        {

        }

        void Chart1_GetToolTipText(object sender, Dundas.Charting.WinControl.ToolTipEventArgs e)
        {

        }

        #endregion


        #region 外部调用方法

        /// <summary>
        /// 添加主标题
        /// </summary>
        /// <param name="wfName">风场名称</param>
        /// <param name="createTime">建立时间</param>
        public void ShowTitle(string wfName, string createTime)
        {
            Title tName = new Title();
            Title tTime = new Title();
            tName.Name = "tName";
            tTime.Name = "tTime";
            tName.Text = wfName;
            tName.Alignment = ContentAlignment.TopCenter;
            tName.Docking = Docking.Top;
            tName.DockInsideChartArea = false;
            tName.DockToChartArea = this.DEFAULT_CHARTAREA_NAME;
            tName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);

            tTime.Text = createTime;
            tTime.Alignment = ContentAlignment.TopCenter;
            tTime.DockInsideChartArea = false;
            tTime.DockToChartArea = this.DEFAULT_CHARTAREA_NAME;
            tTime.Docking = Docking.Top;
            if (this.Chart1.Titles.GetIndex(tName.Name) > 0)
            {
                this.Chart1.Titles.RemoveAt(this.Chart1.Titles.GetIndex(tName.Name));
            }
            if (this.Chart1.Titles.GetIndex(tTime.Name) > 0)
            {
                this.Chart1.Titles.RemoveAt(this.Chart1.Titles.GetIndex(tTime.Name));
            }
            this.Chart1.Titles.Add(tTime);
            this.Chart1.Titles.Add(tName);
            tName.Position.Auto = false;
            tName.Position.X = 50;
            //tName.
            //tTime.Position.Auto =  false;
        }

        #endregion


        #region 控件部分

        #region 初始化Title，配置属性

        private void InitDefaultTitle()
        {
            //Dundas.Charting.WinControl.Title title1 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.Title title2 = new Dundas.Charting.WinControl.Title();
            Dundas.Charting.WinControl.Title title3 = new Dundas.Charting.WinControl.Title();
            title2.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title2.Color = System.Drawing.Color.Blue;
            title2.Name = "Title1";
            title2.Position.Auto = true;
            title2.Text = "";
            title2.DockInsideChartArea = false;//
            title2.DockToChartArea = "Default";
            title2.Visible = true;

            title3.Alignment = System.Drawing.ContentAlignment.TopRight;
            title3.Color = System.Drawing.Color.Blue;
            title3.Name = "Title2";
            title3.Position.Auto = true;


            this.Chart1.Titles.Add(title2);
            this.Chart1.Titles.Add(title3);

        }
        /// <summary>
        /// 初始化标题
        /// </summary>
        private void InitTitle()
        {
            this.Chart1.Titles.Add(CreateTitle("title"));
        }
        /// <summary>
        /// 创建标题
        /// </summary>
        /// <param name="titleName">标题名称</param>
        /// <returns></returns>
        private Title CreateTitle(string titleName)
        {
            Dundas.Charting.WinControl.Title title = new Dundas.Charting.WinControl.Title();
            title.Name = titleName;// "title";
            title.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title.Font = new System.Drawing.Font("Trebuchet MS", 8F, System.Drawing.FontStyle.Regular);
            title.Color = System.Drawing.Color.Blue;
            title.Docking = Docking.Bottom;
            title.Text = "title Test";
            return title;
        }

        #endregion

        #region 第一步：创建ChartArea，并初始化，设置AxisX、AxisY、AxisX2、AxisY2
        /// <summary>
        /// InitChartArea:初始化图表区域chartArea1,设置AxisX、AxisY、AxisX2、AxisY2
        /// </summary>
        private void InitChartArea()
        {
            InitChartArea(DEFAULT_CHARTAREA_NAME);
        }
        /// <summary>
        /// InitChartArea:初始化图表区域chartArea
        /// </summary>
        /// <param name="chartAreaName">图表名称</param>
        private void InitChartArea(string chartAreaName)
        {
            this.Chart1.ChartAreas.Add(CreateChartArea(chartAreaName));
        }
        /// <summary>
        /// InitChartArea:初始化图表区域chartArea
        /// </summary>
        /// <param name="chartAreaName">图表名称</param>
        /// <returns></returns>
        private ChartArea CreateChartArea(string chartAreaName)
        {
            ChartArea chartArea1 = new ChartArea();


            #region 设置AxisX、AxisY、AxisX2、AxisY2
            //****************************
            //          设置AxisX
            //****************************
            //Set Grid Lines
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ////Enable X axis labels automatic fitting
            chartArea1.AxisX.LabelsAutoFit = false;


            chartArea1.AxisX.LineStyle = ChartDashStyle.Solid;
            chartArea1.AxisX.LineWidth = 1;
            chartArea1.AxisX.LineColor = Color.Black;

            // Set interval of X axis to zero, which represents an "Auto" value.
            chartArea1.AxisX.Interval = 0;
            // Use variable count algorithm to generate labels.
            chartArea1.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            // Set X axis automatic fitting style
            chartArea1.AxisX.LabelsAutoFitStyle = LabelsAutoFitStyle.DecreaseFont | LabelsAutoFitStyle.IncreaseFont | LabelsAutoFitStyle.WordWrap;
            //// AxisX.MajorGrid
            chartArea1.AxisX.MajorGrid.Enabled = true;
            chartArea1.AxisX.MajorGrid.LineColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            chartArea1.AxisX.MajorGrid.LineWidth = 1;
            //chartArea1.AxisX.MajorGrid.Interval = 1;
            chartArea1.AxisX.MajorGrid.LineStyle = ChartDashStyle.Dot;
            //// AxisX.MajorTickMark
            chartArea1.AxisX.MajorTickMark.Enabled = true;
            chartArea1.AxisX.MajorTickMark.LineColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            chartArea1.AxisX.MajorTickMark.LineWidth = 1;
            //chartArea1.AxisX.MajorTickMark.Interval = 1;
            chartArea1.AxisX.MajorTickMark.LineStyle = ChartDashStyle.Solid;
            chartArea1.AxisX.MajorTickMark.Style = TickMarkStyle.Outside;

            //// AxisX.MinorGrid
            chartArea1.AxisX.MinorGrid.Enabled = false;
            chartArea1.AxisX.MinorGrid.LineColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            chartArea1.AxisX.MinorGrid.LineStyle = ChartDashStyle.DashDotDot;
            //// AxisX.MinorTickMark
            chartArea1.AxisX.MinorTickMark.Enabled = false;


            //// Set AxisX ScrollBar
            chartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.AliceBlue;
            chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

            chartArea1.AxisX.Title = "AxisX";
            chartArea1.AxisX.TitleAlignment = StringAlignment.Center;

            chartArea1.AxisX.View.Zoomable = false;
            //****************************
            //          设置AxisY
            //****************************            
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelsAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelsAutoFitMinFontSize = 6;
            chartArea1.AxisY.LabelsAutoFit = true;
            chartArea1.AxisY.LineStyle = ChartDashStyle.Solid;
            chartArea1.AxisY.LineWidth = 1;
            chartArea1.AxisY.LineColor = Color.Red; //Color.Black;

            // Set interval of Y axis to zero, which represents an "Auto" value.
            chartArea1.AxisY.Interval = 0;
            // Use variable count algorithm to generate labels.
            chartArea1.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

            //// AxisY.MajorGrid
            chartArea1.AxisY.MajorGrid.Enabled = true;
            chartArea1.AxisY.MajorGrid.LineColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            chartArea1.AxisY.MajorGrid.LineWidth = 1;
            chartArea1.AxisY.MajorGrid.LineStyle = ChartDashStyle.Dot;
            //// AxisX.MajorTickMark
            chartArea1.AxisY.MajorTickMark.Enabled = true;
            chartArea1.AxisY.MajorTickMark.LineColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            chartArea1.AxisY.MajorTickMark.LineWidth = 1;
            chartArea1.AxisY.MajorTickMark.LineStyle = ChartDashStyle.Solid;
            chartArea1.AxisY.MajorTickMark.Style = TickMarkStyle.Outside;

            //// AxisX.MinorGrid
            chartArea1.AxisY.MinorGrid.Enabled = false;
            chartArea1.AxisY.MinorGrid.LineColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            chartArea1.AxisY.MinorGrid.LineStyle = ChartDashStyle.DashDotDot;
            //// AxisX.MinorTickMark
            chartArea1.AxisY.MinorTickMark.Enabled = false;


            //// Set AxisY ScrollBar
            chartArea1.AxisY.ScrollBar.BackColor = System.Drawing.Color.AliceBlue;
            chartArea1.AxisY.ScrollBar.ButtonColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisY.ScrollBar.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

            chartArea1.AxisY.Minimum = Double.NaN;
            chartArea1.AxisY.Maximum = Double.NaN;

            chartArea1.AxisY.Title = "AxisY";
            chartArea1.AxisY.TitleAlignment = StringAlignment.Center;

            chartArea1.AxisY.View.Zoomable = false;
            //****************************
            //          设置AxisY2
            //**************************** 


            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.LabelsAutoFitMaxFontSize = 8;
            chartArea1.AxisY2.LabelsAutoFitMinFontSize = 6;
            chartArea1.AxisY2.LabelsAutoFit = true;
            chartArea1.AxisY2.LineStyle = ChartDashStyle.Solid;
            chartArea1.AxisY2.LineWidth = 1;
            chartArea1.AxisY2.LineColor = Color.Blue; //Color.Black;

            // Set interval of Y axis to zero, which represents an "Auto" value.
            chartArea1.AxisY2.Interval = 0;
            // Use variable count algorithm to generate labels.
            chartArea1.AxisY2.IntervalAutoMode = IntervalAutoMode.VariableCount;


            //// AxisY.MajorGrid
            chartArea1.AxisY2.MajorGrid.Enabled = true;
            chartArea1.AxisY2.MajorGrid.LineColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            chartArea1.AxisY2.MajorGrid.LineWidth = 1;
            chartArea1.AxisY2.MajorGrid.LineStyle = ChartDashStyle.Dot;
            //// AxisX.MajorTickMark
            chartArea1.AxisY2.MajorTickMark.Enabled = true;
            chartArea1.AxisY2.MajorTickMark.LineColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            chartArea1.AxisY2.MajorTickMark.LineWidth = 1;
            chartArea1.AxisY2.MajorTickMark.LineStyle = ChartDashStyle.Solid;
            chartArea1.AxisY2.MajorTickMark.Style = TickMarkStyle.Outside;

            //// AxisX.MinorGrid
            chartArea1.AxisY2.MinorGrid.Enabled = false;
            chartArea1.AxisY2.MinorGrid.LineColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            chartArea1.AxisY2.MinorGrid.LineStyle = ChartDashStyle.DashDotDot;
            //// AxisX.MinorTickMark
            chartArea1.AxisY2.MinorTickMark.Enabled = false;


            //// Set AxisY ScrollBar
            chartArea1.AxisY2.ScrollBar.BackColor = System.Drawing.Color.AliceBlue;
            chartArea1.AxisY2.ScrollBar.ButtonColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisY2.ScrollBar.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

            chartArea1.AxisY2.Minimum = Double.NaN;
            chartArea1.AxisY2.Maximum = Double.NaN;

            chartArea1.AxisY2.Title = "AxisY2";
            chartArea1.AxisY2.TitleAlignment = StringAlignment.Center;

            #endregion


            #region 设置CursorX CursorY
            //****************************
            //     设置CursorX CursorY
            //****************************
            chartArea1.CursorX.LineStyle = Dundas.Charting.WinControl.ChartDashStyle.DashDot;
            chartArea1.CursorX.SelectionColor = System.Drawing.SystemColors.Highlight;
            //chartArea1.CursorX.UserEnabled = true;
            chartArea1.CursorY.LineStyle = Dundas.Charting.WinControl.ChartDashStyle.DashDot;
            chartArea1.CursorY.SelectionColor = System.Drawing.SystemColors.Highlight;
            //chartArea1.CursorY.UserEnabled = true;
            chartArea1.CursorY.Interval = 0.01;
            chartArea1.CursorX.Interval = 0.01;
            chartArea1.CursorX.AxisType = AxisType.Primary;
            #endregion

            #region  设置ChartArea属性
            chartArea1.AlignOrientation = ((Dundas.Charting.WinControl.AreaAlignOrientation)((Dundas.Charting.WinControl.AreaAlignOrientation.Vertical | Dundas.Charting.WinControl.AreaAlignOrientation.Horizontal)));
            chartArea1.Area3DStyle.WallWidth = 0;

            chartArea1.BackGradientEndColor = System.Drawing.SystemColors.Control;
            chartArea1.BackGradientType = Dundas.Charting.WinControl.GradientType.TopBottom;
            // Set Border Color
            chartArea1.BorderColor = Color.Black;
            // Set Border Style
            chartArea1.BorderStyle = ChartDashStyle.Solid;
            // Set Border Width
            chartArea1.BorderWidth = 1;
            // Set Shadow Offset
            chartArea1.ShadowOffset = 10;




            // Set Chart Area position
            chartArea1.Position.Auto = false;
            chartArea1.Position.X = 5;
            chartArea1.Position.Y = 10;
            chartArea1.Position.Width = 98;
            chartArea1.Position.Height = 80;

            // Set the plotting area position. Coordinates of a plotting 
            // area are relative to a chart area position.
            chartArea1.InnerPlotPosition.Auto = true;
            chartArea1.Name = chartAreaName;// "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            #endregion

            return chartArea1;

        }
        #endregion

        #region 第二步：创建Legend，初始化Legend，配置属性
        /// <summary>
        /// Legend:初始化图例说明Legend
        /// </summary>
        private void InitLegend()
        {
            InitLegend(this.DEFAULT_CHARTAREA_NAME);
        }
        /// <summary>
        /// Legend:初始化图例说明Legend
        /// </summary>
        /// <param name="legendName">名称</param>
        private void InitLegend(string legendName)
        {
            string dockToCharArea = "Default";
            this.Chart1.Legends.Add(CreateLegend(legendName, dockToCharArea));
        }
        /// <summary>
        /// Legend:初始化图例说明Legend
        /// </summary>
        /// <param name="legendName">名称</param>
        /// <param name="dockToCharArea">失效</param>
        /// <returns></returns>
        private Legend CreateLegend(string legendName, string dockToCharArea)
        {
            Legend legend1 = new Legend();
            //legend1.Title = "";
            legend1.Name = legendName;// "Default";
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.AutoFitText = true;
            legend1.Docking = Dundas.Charting.WinControl.LegendDocking.Top;
            legend1.BackColor = Color.Transparent;
            legend1.DockInsideChartArea = false;
            // legend1.DockToChartArea = dockToCharArea;// "Default";
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 6F, System.Drawing.FontStyle.Regular);
            //    legend1.Position.X = 90f;
            //    legend1.Position.Y = 10f;
            //    legend1.Position.Height = 20;
            //    legend1.Position.Width =20;
            ////    legend1.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Table;
            //    legend1.LegendStyle = Dundas.Charting.WinControl.LegendStyle.Row;
            //    legend1.Position.Auto = false;
            legend1.Enabled = true;
            return legend1;
        }
        #endregion

        #region 第四步：添加Series，配置属性
        /// <summary>
        /// Series:添加序列
        /// </summary>
        private void AddSeries()
        {
            //this.Chart1.Series.Remove(this.Chart1.Series[0]);
            this.Chart1.Series.Clear();
            this.Chart1.Legends.Clear();
            this.Chart1.ChartAreas.RemoveAt(0);
            //this.Chart1.ChartAreas.Clear();
            this.InitChartArea();
            this.InitLegend();


            Series series = Chart1.Series.Add("WAVE_DATA");
            series.ChartArea = "Default";
            series.Type = SeriesChartType.Point;
            series.BorderColor = Color.Red;
            //series.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series.ChartType = "Point"; //"Spline";
            series.LegendText = "散点数据";
            series.Name = "Default";
            Color[] colors = new Color[1];
            colors[0] = Color.Red;
            series.PaletteCustomColors = colors;
            series.Color = Color.Red;
            //series.PaletteCustomColors = new System.Drawing.Color[0];

            //是否显示图中每个点的值
            series.ShowLabelAsValue = false;
            //X轴的数据值类型
            series.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;

            //series.XValueIndexed = true;// = Dundas.Charting.WinControl.ChartValueTypes.Int;
            //Y轴的数据值类型
            series.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;

        }

        private void AddSeries(string yType)
        {
            try
            {
                //this.Chart1.Series.Remove(this.Chart1.Series[0]);
                //this.Chart1.Series.Clear();
                //this.Chart1.Legends.Clear();
                //this.Chart1.ChartAreas.RemoveAt(0);
                //this.Chart1.ChartAreas.Clear();
                //this.InitChartArea();
                //this.InitLegend();
                if (this.Chart1.Series.GetIndex("Default_" + yType) != -1)
                {
                    this.Chart1.Series.RemoveAt(this.Chart1.Series.GetIndex("Default_" + yType));
                }
                //string _ChartAreaName = "";
                //string _SeriesName = "";
                //string _SeriesType = "";
                //string _SeriesLegendText = "";
                bool _haveYType = false;
                foreach (Series _se in Chart1.Series)
                {
                    if (_se.Name.Contains("Default"))
                    {
                        _haveYType = true;
                        break;
                    }
                }
                Series series = Chart1.Series.Add("WAVE_DATA");
                series.ChartArea = "Default";
                series.Type = SeriesChartType.Line;//.Line;
                series.BorderColor = Color.Blue; //System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
                series.ChartType = "Line"; //"Spline";
                series.LegendText = yType;
                series.Name = "Default" + yType;
                Color[] colors=new Color[1];
                colors[0]=Color.Blue;
                series.PaletteCustomColors = colors;

                series.Color = Color.Blue;

                //是否显示图中每个点的值
                series.ShowLabelAsValue = false;
                //X轴的数据值类型
                series.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
                //series.XValueIndexed = true;// = Dundas.Charting.WinControl.ChartValueTypes.Int;
                //Y轴的数据值类型
                series.YValueType = Dundas.Charting.WinControl.ChartValueTypes.Double;
                if (_haveYType)
                {
                    series.YAxisType = Dundas.Charting.WinControl.AxisType.Secondary;
                    Chart1.ChartAreas[0].AxisY2.Title = yType;
                }
                else
                {
                    //Chart1.ChartAreas[0].AxisY.Title = yType;
                    //Chart1.ChartAreas[0].AxisX.Title = AxisTitleNameType.AxisX_SPEED_TRENDS;
                }
            }
            catch
            {
            }
        }

        ///<summary>
        /// 清理序列
        /// </summary>
        private void ClearSeries(SeriesCollection seriesCollection)
        {
            seriesCollection.Clear();
            //清理标题
            Chart1.Titles["Title1"].Text = "  ";
            Chart1.Titles["Title2"].Text = "  ";
            Chart1.ChartAreas["Default"].CursorX.Position = double.NaN;
            Chart1.ChartAreas["Default"].CursorY.Position = double.NaN;
        }
        /// <summary>
        /// 清理序列
        /// </summary>
        public void ClearPoints()
        {
            this.ClearSeries(this.Chart1.Series);
        }

        #endregion 结束 第四步：添加Series，配置属性

        #endregion


        #region 对外开放的接口

        /// <summary>
        /// 给CHART序列SERIES添加数据(参数为DOUBLE)
        /// </summary>
        /// <param name="xValues">X轴数据</param>
        /// <param name="yValues">Y轴数据</param>
        public void SetData(object[] xValues, double[] yValues)
        {
            ClearPoints();
            if (xValues != null && xValues.Length != 0 && yValues != null && yValues.Length != 0)
            {
                double[] _xVs = new double[xValues.Length];
                double _d = 0;
                double xMinValue = 0;
                double xMaxValue = 0;
                for (int i = 0; i < xValues.Length; i++)
                {
                    if (xValues[i] != null && double.TryParse(xValues[i].ToString(), out _d))
                    {
                        _xVs[i] = _d;
                    }
                }
                try
                {
                    xMinValue = _xVs.Min();
                    xMaxValue = _xVs.Max();
                }
                catch { }
                AddSeries();

                this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.IntervalType = DateTimeIntervalType.Number;
                this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.LabelStyle.Format = "N2";
                //this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.Interval = (xMaxValue - xMinValue) / _xVs.Length;
                Chart1.Series["Default"].XValueType = ChartValueTypes.Double;
                Chart1.Series["Default"].Points.DataBindXY(_xVs, yValues);
            }
        }

        public void SetData(object[] xValues, double[] yValues,double[] yValues2,string yType)
        {
            ClearPoints();
            if (xValues != null && xValues.Length != 0 && yValues != null && yValues.Length != 0)
            {
                double[] _xVs = new double[xValues.Length];
                double _d = 0;
                double xMinValue = 0;
                double xMaxValue = 0;
                for (int i = 0; i < xValues.Length; i++)
                {
                    if (xValues[i] != null && double.TryParse(xValues[i].ToString(), out _d))
                    {
                        _xVs[i] = _d;
                    }
                }
                try
                {
                    xMinValue = _xVs.Min();
                    xMaxValue = _xVs.Max();
                }
                catch { }
                AddSeries();

                AddSeries(yType);

                this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.IntervalType = DateTimeIntervalType.Number;
                this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.LabelStyle.Format = "N2";
                //this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.Interval = (xMaxValue - xMinValue) / _xVs.Length;
                Chart1.Series["Default"].XValueType = ChartValueTypes.Double;
                Chart1.Series["Default"].Points.DataBindXY(_xVs, yValues);

                Chart1.Series["Default" + yType].XValueType = ChartValueTypes.Double;
                Chart1.Series["Default" + yType].Points.DataBindXY(_xVs, yValues2);
            }
        }

        public void SetDataList(List<Model.WaveDataResult> list,int type,ref int tempType)
        {
            listResult = list;
            if (type == 1)
            {
                tempType = 1;
                FillData(listResult, RightMenuItemEnum.LeftAxisVertical_RmsValue);
            }
            else if (type == 2)
            {
                tempType = 2;
                FillData(listResult, RightMenuItemEnum.RightAxisVertical_RmsValue);
            }
            else if (type == 3)
            {
                tempType = 3;
                FillData(listResult, RightMenuItemEnum.LeftAxisHorizontal_RmsValue);
            }
            else if (type == 4)
            {
                tempType = 4;
                FillData(listResult, RightMenuItemEnum.LeftAxisVertical_PeakIndex);
            }
            else if (type == 5)
            {
                tempType = 5;
                FillData(listResult, RightMenuItemEnum.RightAxisVertical_PeakIndex);
            }
            else if (type == 6)
            {
                tempType = 6;
                FillData(listResult, RightMenuItemEnum.LeftAxisHorizontal_PeakIndex);
            }
            else if (type == 7)
            {
                tempType = 7;
                FillData(listResult, RightMenuItemEnum.FrameVertical_RmsValue);
            }
            else if (type == 8)
            {
                tempType = 8;
                FillData(listResult, RightMenuItemEnum.FrameHorizontal_RmsValue);
            }
            else if (type == 9)
            {
                tempType = 9;
                FillData(listResult, RightMenuItemEnum.BodyVertical_RmsValue);
            }
            else if (type == 10)
            {
                tempType = 10;
                FillData(listResult, RightMenuItemEnum.BodyHorizontal_RmsValue);
            }
            else
            {
                FillData(listResult, RightMenuItemEnum.LeftAxisVertical_RmsValue);
            }

            
        }

        private void FillData(List<Model.WaveDataResult> list,RightMenuItemEnum menuItem)
        {
            //横轴 最大值发生的里程
            string[] xvalues = new string[list.Count];
            //左竖轴 有效值，幅值，轨道冲击指数
            double[] yvalues = new double[list.Count];
            //右竖轴 平均速度
            double[] yvalues2 = new double[list.Count];

            string title = "左轴垂向";

            string ytitle = "有效值";

            string y2title = "速度(km/h)";

            switch (menuItem)
            {
                case RightMenuItemEnum.LeftAxisVertical_RmsValue:
                    {
                        list = list.OrderBy(s => s.LeftAxisVertical_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].LeftAxisVertical_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].LeftAxisVertical_RmsValue;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "左轴垂向";
                        ytitle = "有效值";
                        ytitle += "(m/s^2)";
                    }
                    break;
                case RightMenuItemEnum.LeftAxisVertical_PeakIndex:
                    {
                        list = list.OrderBy(s => s.LeftAxisVertical_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].LeftAxisVertical_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].LeftAxisVertical_PeakIndex;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "左轴垂向";
                        ytitle = "轨道冲击指数";
                    }
                    break;
                case RightMenuItemEnum.RightAxisVertical_RmsValue:
                    {
                        list = list.OrderBy(s => s.RightAxisVertical_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].RightAxisVertical_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].RightAxisVertical_RmsValue;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "右轴垂向";
                        ytitle = "有效值";
                        ytitle += "(m/s^2)";
                    }
                    break;
                case RightMenuItemEnum.RightAxisVertical_PeakIndex:
                    {
                        list = list.OrderBy(s => s.RightAxisVertical_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].RightAxisVertical_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].RightAxisVertical_PeakIndex;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "右轴垂向";
                        ytitle = "轨道冲击指数";
                    }
                    break;
                case RightMenuItemEnum.LeftAxisHorizontal_RmsValue:
                    {
                        list = list.OrderBy(s => s.LeftAxisHorizontal_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].LeftAxisHorizontal_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].LeftAxisHorizontal_RmsValue;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "左轴横向";
                        ytitle = "有效值";
                        ytitle += "(m/s^2)";
                    }
                    break;
                case RightMenuItemEnum.LeftAxisHorizontal_PeakIndex:
                    {
                        list = list.OrderBy(s => s.LeftAxisHorizontal_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].LeftAxisHorizontal_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].LeftAxisVertical_PeakIndex;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "左轴横向";
                        ytitle = "轨道冲击指数";
                    }
                    break;
                case RightMenuItemEnum.FrameVertical_RmsValue:
                    {
                        list = list.OrderBy(s => s.FrameVertical_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].FrameVertical_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].FrameVertical_RmsValue;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "构架垂向";
                        ytitle = "幅值";
                    }
                    break;
                case RightMenuItemEnum.FrameHorizontal_RmsValue:
                    {
                        list = list.OrderBy(s => s.FrameHorizontal_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].FrameHorizontal_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].FrameHorizontal_RmsValue;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "构架横向";
                        ytitle = "幅值";
                    }
                    break;
                case RightMenuItemEnum.BodyHorizontal_RmsValue:
                    {
                        list = list.OrderBy(s => s.BodyHorizontal_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].BodyHorizontal_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].BodyHorizontal_RmsValue;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "车体横向";
                        ytitle = "幅值";
                    }
                    break;
                case RightMenuItemEnum.BodyVertical_RmsValue:
                    {
                        list = list.OrderBy(s => s.BodyVertical_MaxValueMile).ToList();

                        for (int i = 0; i < list.Count; i++)
                        {
                            xvalues[i] = Math.Round(list[i].BodyVertical_MaxValueMile, 1).ToString();
                            yvalues[i] = list[i].BodyVertical_RmsValue;
                            yvalues2[i] = list[i].AvgSpeed;
                        }
                        title = "车体垂向";
                        ytitle = "幅值";
                    }
                    break;
                default:
                    break;
            }

            

            title += "区段指标最大值散点图";

            ShowTitle(title, "");

            SetData(xvalues, yvalues, yvalues2, "速度");

            SetAxis("里程(km)", ytitle, y2title);
        }


        /// <summary>
        /// 显示数据点标题
        /// </summary>
        /// <param name="dataPoint">数据点</param>
        private void ShowMsg(DataPoint dataPoint)
        {
            if (dataPoint.AxisLabel != null && dataPoint.AxisLabel != "")
            {
                this.Chart1.Titles["Title1"].Text = "X=" + dataPoint.AxisLabel + " ,Y=" + dataPoint.YValues[0].ToString() + " ";
            }
            //this.Chart1.Titles["Title1"].DockInsideChartArea = false;//
            else
            {
                this.Chart1.Titles["Title1"].Text = "X=" + dataPoint.XValue.ToString() + " ,Y=" + dataPoint.YValues[0].ToString() + " ";

            }//this.Chart1.Titles["Title1"].DockInsideChartArea = false;//
            //this.Chart1.Titles["Title1"].DockToChartArea = "Default";
        }
        /// <summary>
        /// 显示Title2信息附加转速
        /// </summary>
        /// <param name="speed">转速</param>
        private void ShowMsgTitle2(string speed)
        {
            this.Chart1.Titles["Title2"].Text = "Speed=" + speed;
            this.Chart1.Titles["Title2"].DockToChartArea = "Default";
        }

        /// <summary>
        /// 设置坐标轴
        /// </summary>
        /// <param name="xtitle">x标题</param>
        /// <param name="ytitle">y标题</param>
        public void SetAxis(string xtitle, string ytitle, double xMinValue, double xMaxValue, double yMinValue, double yMaxValue)
        {
            if (this.Chart1.ChartAreas != null)
            {
                if (this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME] != null)
                {
                    if (xtitle != null && xtitle.Length > 0)
                    {

                        this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.Title = xtitle;
                        this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.Minimum = xMinValue;
                        this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.Maximum = xMaxValue;


                        //if(this.Chart1.Series["Default"]!=null)
                        //    this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.Interval = (xMaxValue - xMinValue) / this.Chart1.Series["Default"].Points.Count;
                        //Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.RoundAxisValues();
                        //this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.LabelStyle.FontAngle = -90;
                    }
                    if (ytitle != null && ytitle.Length > 0)
                    {
                        this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisY.Title = ytitle;
                        this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisY.Minimum = yMinValue;
                        this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisY.Maximum = yMaxValue;
                    }
                }
            }
        }

        public void SetAxis(string xtitle, string ytitle, string y2title)
        {
            if (this.Chart1.ChartAreas != null)
            {
                if (this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME] != null)
                {
                    if (xtitle != null && xtitle.Length > 0)
                    {
                        this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisX.Title = xtitle;
                    }
                    if (ytitle != null && ytitle.Length > 0)
                    {
                        this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisY.Title = ytitle;
                    }
                    if (y2title != null && y2title.Length > 0)
                    {
                        this.Chart1.ChartAreas[this.DEFAULT_CHARTAREA_NAME].AxisY2.Title = y2title;
                    }
                }
            }
        }
        #endregion

        private void Chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show((Dundas.Charting.WinControl.Chart)sender, new Point(e.X, e.Y));
            }
        }

        static string filePath = System.Windows.Forms.Application.StartupPath + "\\db\\data\\" + "DataGJHX2016-10-19NO39.mdb";
        WaveDataResultDAL dataDal = new WaveDataResultDAL(filePath);

        private void 轴箱左垂有效值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 1;
            FillData(listResult, RightMenuItemEnum.LeftAxisVertical_RmsValue);
        }

        private void 轴箱右垂有效值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 2;
            FillData(listResult, RightMenuItemEnum.RightAxisVertical_RmsValue);
        }

        private void 轴箱左横有效值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 3;
            FillData(listResult, RightMenuItemEnum.LeftAxisHorizontal_RmsValue);
        }

        private void 轴箱左垂轨道冲击指数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 4;
            FillData(listResult, RightMenuItemEnum.LeftAxisVertical_PeakIndex);
        }

        private void 轴箱右垂轨道冲击指数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 5;
            FillData(listResult, RightMenuItemEnum.RightAxisVertical_PeakIndex);
        }

        private void 轴箱左横轨道冲击指数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 6;
            FillData(listResult, RightMenuItemEnum.LeftAxisHorizontal_PeakIndex);
        }

        private void 构架垂向幅值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 7;
            FillData(listResult, RightMenuItemEnum.FrameVertical_RmsValue);
        }

        private void 构架横向幅值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 8;
            FillData(listResult, RightMenuItemEnum.FrameHorizontal_RmsValue);
        }

        private void 车体垂向幅值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 9;
            FillData(listResult, RightMenuItemEnum.BodyVertical_RmsValue);
        }

        private void 车体横向幅值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            typeGloble = 10;
            FillData(listResult, RightMenuItemEnum.BodyHorizontal_RmsValue);
        }


        /// <summary>
        /// 截屏
        /// </summary>
        /// <returns>位图</returns>
        public Bitmap Screenshort()
        {

            int h = (int)(this.Height - this.Height * 0.1);
            int h1 = (int)(h * 0.1);
            int w = (int)(this.Width - this.Width * 0.1);
            int w1 = (int)(w * 0.1);
            Bitmap newBitMap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(newBitMap, new Rectangle(0, 0, this.Width, this.Height));
            /*截图*/
            //Bitmap rbitmap = new Bitmap(w, h - h1);
            //Graphics gr = Graphics.FromImage(rbitmap);

            //Rectangle sRectangle = new Rectangle(0, h1, w, h - h1);
            //Rectangle rRec = new Rectangle(0, 0, w - w1, h - h1);
            //gr.DrawImage(newBitMap, rRec, sRectangle, GraphicsUnit.Pixel);            
            //return rbitmap;
            return newBitMap;
        }

    }
}
