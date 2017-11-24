using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehicleAcceleration.Classes;
using VehicleAcceleration.Common;
using VehicleAcceleration.Model;

namespace VehicleAcceleration.Forms.ReportPrint
{
    /// <summary>
    /// 生成日报（Excel）
    /// </summary>
    public partial class BuildReportExcel : Form
    {
        BasicInfoDAL basicDAL = new BasicInfoDAL();
        BoundaryLineDAL boundaryDal = new BoundaryLineDAL();

        public BuildReportExcel()
        {
            InitializeComponent();

            this.Load += new EventHandler(BuildReportExcel_Load);
        }

        void BuildReportExcel_Load(object sender, EventArgs e)
        {
            getLineName();

            BasicInfo basic = basicDAL.GetList().FirstOrDefault();
            if (basic != null)
            {
                this.txtRecordPerson.Text = basic.SurveyorName;
                this.cmbLineName.SelectedItem = basic.LineName;
            }
        }

        /// <summary>
        /// 执行确定按钮 生成日报 Excel
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
                string strSurveyorName=this.txtRecordPerson.Text.Trim();
                //BasicInfo basic = basicDAL.Get(strLineName);
                BasicInfo basic = basicDAL.Get(strLineName, strSurveyorName);

                ReplaceWordData data = new ReplaceWordData();
                if (basic != null)
                {
                    var line = basicDAL.getLine().Where(s => s.LineName == basic.LineName).FirstOrDefault();

                    string lineCnName = "";
                    if (line != null)
                        lineCnName = line.LineNameCn;

                    List<BoundaryLine> boundarylineList = boundaryDal.GetList(lineCnName.Substring(0, 2), basic.WalkType);
                    string bureauName = "";

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
                        table.LineName = lineCnName;
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
                    string targetPath = path + "\\files\\excel\\" + CommonHelper.GetFileNameWithOutExtension() + ".xls";
                    NOPIHelper helper = new NOPIHelper();
                    helper.CreateExcel(listTable, targetPath, "SheetName");
                }
                else
                {
                    MessageBox.Show("当前不存在这个条件");
                }

                MessageBox.Show("生成成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 取消生成日报 Excel 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 初始化控件

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

        #endregion
    }
}
