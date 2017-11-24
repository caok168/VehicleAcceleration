using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehicleAcceleration.Common;
using VehicleAcceleration.Model;
using VehicleAcceleration.Classes;
using VehicleAcceleration.Forms.WaveFormProcessing;

namespace VehicleAcceleration.Forms.ReportPrint
{
    /// <summary>
    /// 生成日报（Word）
    /// </summary>
    public partial class BuildReportWord : Form
    {
        BasicInfoDAL basicDAL = new BasicInfoDAL();

        BoundaryLineDAL boundaryDal = new BoundaryLineDAL();

        public BuildReportWord()
        {
            InitializeComponent();

            this.Load += new EventHandler(BuildReportWord_Load);
        }

        void BuildReportWord_Load(object sender, EventArgs e)
        {
            LoadData();

            BasicInfo basic = basicDAL.GetList().FirstOrDefault();
            if (basic != null)
            {
                this.txtRecordPerson.Text = basic.SurveyorName;
                this.cmbLineName.SelectedItem = basic.LineName;
                this.cmbDirection.SelectedItem = basic.RunDirection;
                this.cmbSurveyDirection.SelectedItem = basic.SurveyDirection;
            }
        }

        /// <summary>
        /// 确定按钮 生成日报Word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath;
                string fileFullPath = path + "\\db\\data\\" + CommonHelper.GetFileName();

                string strLineName = this.cmbLineName.SelectedItem.ToString();
                string strRunDirection = this.cmbDirection.SelectedItem.ToString();
                string strSurveyDirection = this.cmbSurveyDirection.SelectedItem.ToString();
                string strSurveyName = this.txtRecordPerson.Text.Trim();
                //BasicInfo basic = basicDAL.Get(strLineName, strRunDirection, strSurveyDirection);
                BasicInfo basic = basicDAL.Get(strLineName, strSurveyName, strRunDirection, strSurveyDirection);

                ReplaceWordData data = new ReplaceWordData();
                if (basic != null)
                {
                    data.SurveyRegion = "";

                    data.LineName = basic.LineName;

                    data.LineNameCn = "";
                    List<Line> lineList = basicDAL.getLine();
                    var line = lineList.Where(s => s.LineName == data.LineName).FirstOrDefault();
                    if (line != null)
                    {
                        data.LineNameCn = line.LineNameCn;
                    }

                    List<BoundaryLine> boundarylineList = boundaryDal.GetList(data.LineNameCn.Substring(0, 2), basic.WalkType);
                    string bureauName = "";

                    data.RunDirection = basic.RunDirection;
                    data.SurveyDate = basic.RunDate;
                    data.SurveyDirection = basic.SurveyDirection;
                    data.SurveyVehicleVersion = basic.SurveyVehicleVersion;

                    WaveDataResultDAL waveDal = new WaveDataResultDAL(fileFullPath);


                    data.ActualMile = basic.ActualMile.ToString("F2");
                    data.MileMore200 = basic.MileMore200.ToString("F2");

                    //data.ActualMile = Math.Round(waveDal.GetActualMile(), 2).ToString();
                    //var wavelist = waveDal.GetList();

                    //data.MileMore200 = Math.Round((wavelist.Where(s => s.StartMile > 200).Count() / wavelist.Count) * Convert.ToDouble(data.ActualMile), 2).ToString();

                    data.SurveyResult = this.rtxtResult.Text.ToString();

                    OverValueDataResultDAL overValueDal = new OverValueDataResultDAL(fileFullPath);

                    List<DeviationTable> listTable = new List<DeviationTable>();

                    List<OverValueDataResult> listOverResult = overValueDal.GetListOrder();
                    for (int i = 0; i < listOverResult.Count; i++)
                    {
                        DeviationTable table = new DeviationTable();
                        table.AccTestContent = "";

                        var boundary = boundarylineList.Where(s => s.STARTMILE < listOverResult[i].Mile && s.ENDMILE > listOverResult[i].Mile).FirstOrDefault();
                        if (boundary != null)
                        {
                            bureauName = boundary.路局;
                        }
                        table.BureauName = bureauName;
                        table.DeviationGrade = listOverResult[i].OverLevel;
                        table.ID = i + 1;
                        table.LineType = listOverResult[i].OverType;
                        table.Miles = listOverResult[i].Mile;
                        table.Remark = "";
                        table.RmsOrPeakValue = listOverResult[i].OverValueRms;
                        table.Speed = listOverResult[i].Speed;
                        table.TrackImpactIndex = listOverResult[i].OverValuePeak;
                        table.ChannelName = listOverResult[i].ChannelName + "加";

                        listTable.Add(table);
                    }

                    data.Records = listTable;

                    data.RecordPerson = this.txtRecordPerson.Text.Trim();
                    data.CheckPerson = "";

                    data.CountA = listOverResult.Where(s => s.OverLevel == "A").Count();
                    data.CountB = listOverResult.Where(s => s.OverLevel == "B").Count();
                    data.CountC = listOverResult.Where(s => s.OverLevel == "C").Count();
                }
                else
                {
                    MessageBox.Show("检测线路" + strLineName + "的检测数据没找到，无法生成报告");
                }

                string templatePath = path + "\\files\\加速度日报模板.docx";
                string targetPath = path + "\\files\\word\\" + CommonHelper.GetFileNameWithOutExtension() + ".docx";


                string imageFileName = fileFullPath.Substring(fileFullPath.LastIndexOf("\\") + 1);
                imageFileName = "轴箱左垂" + imageFileName.Replace("mdb", "jpg");
                string imageFilePath = System.Windows.Forms.Application.StartupPath + "\\files\\images\\" + imageFileName;

                ScatterDiagram sd = new ScatterDiagram(fileFullPath, imageFilePath,1);
                sd.Show(this.Owner);

                data.ImageUrl1 = imageFilePath;

                imageFilePath = imageFilePath.Replace("轴箱左垂", "轴箱右垂");
                sd = new ScatterDiagram(fileFullPath, imageFilePath,2);
                sd.Show(this.Owner);

                data.ImageUrl2 = imageFilePath;

                imageFilePath = imageFilePath.Replace("轴箱右垂", "轴箱左横");
                sd = new ScatterDiagram(fileFullPath, imageFilePath, 3);
                sd.Show(this.Owner);

                data.ImageUrl3 = imageFilePath;

                GenerateWord word = new GenerateWord(templatePath, targetPath);
                word.OverWriteWord(data);

                MessageBox.Show("生成成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 取消 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region 获取基本信息

        private void LoadData()
        {
            getRunDirection();
            getLineName();
            getSurveyDirection();
        }

        /// <summary>
        /// 获取运行方向
        /// </summary>
        private void getRunDirection()
        {
            this.cmbDirection.Items.Clear();
            List<string> list = basicDAL.getRunDirection();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmbDirection.Items.Add(list[i]);
            }

            this.cmbDirection.SelectedIndex = 0;
        }


        /// <summary>
        /// 获取线路名
        /// </summary>
        private void getLineName()
        {
            this.cmbLineName.Items.Clear();
            List<string> list = basicDAL.getLineName();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmbLineName.Items.Add(list[i]);
            }

            this.cmbLineName.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取检测方向
        /// </summary>
        private void getSurveyDirection()
        {
            this.cmbSurveyDirection.Items.Clear();
            List<string> list = basicDAL.getSurveyDirection();
            for (int i = 0; i < list.Count; i++)
            {
                this.cmbSurveyDirection.Items.Add(list[i]);
            }

            this.cmbSurveyDirection.SelectedIndex = 0;
        }

        #endregion
    }
}
