using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VehicleAcceleration.Classes;
using VehicleAcceleration.Model;

namespace VehicleAcceleration.Forms.SystemMenu
{
    public partial class ParameterSet : Form
    {
        CalculaterParamter parameterCalc = new CalculaterParamter();
        ChannelFreqParamter paramterChannel = new ChannelFreqParamter();
        DeviationParameter paramterDeviation = new DeviationParameter();

        CalculaterParamterDAL paramterCalcDAL = new CalculaterParamterDAL();
        ChannelFreqParamterDAL paramterChannelDAL = new ChannelFreqParamterDAL();
        DeviationParameterDAL paramterDeviationDAL = new DeviationParameterDAL();

        public ParameterSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParameterSet_Load(object sender, EventArgs e)
        {
            EnableCalc(false);
            EnableChannel(false);
            EnableDeviation(false);
            LoadCalcParamter();
            LoadChannelParamter();
            LoadDeviationParamter();
        }

        

        /// <summary>
        /// 准备修改计算参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpdateCalc_Click(object sender, EventArgs e)
        {
            EnableCalc(true);
        }

        /// <summary>
        /// 保存修改后的计算参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OKCalc_Click(object sender, EventArgs e)
        {
            parameterCalc = paramterCalcDAL.GetList().FirstOrDefault();
            if (parameterCalc == null)
            {
                parameterCalc = new CalculaterParamter();
            }
            parameterCalc.ComputingTime = Convert.ToInt32(this.txt_ComputingTime.Text.Trim());
            parameterCalc.SamplingFrequency = Convert.ToInt32(this.txt_SamplingFrequency.Text.Trim());
            parameterCalc.EffectiveValueLength = Convert.ToInt32(this.txt_EffectiveValueLength.Text.Trim());
            parameterCalc.SamplingPoints = Convert.ToInt32(this.txt_SamplingPoints.Text.Trim());
            parameterCalc.SpeedGrade = Convert.ToInt32(this.txtSpeedGrade.Text.Trim());
            parameterCalc.MaxValueLength = Convert.ToInt32(this.txt_MaxValueLength.Text.Trim());
            parameterCalc.LowSpeedControlValue = Convert.ToInt32(this.txt_LowSpeedControlValue.Text.Trim());
            parameterCalc.LowSpeedControlRate = Convert.ToDouble(this.txt_LowSpeedControlRate.Text.Trim());

            bool isOk = paramterCalcDAL.Save(parameterCalc);
            if (isOk)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        /// <summary>
        /// 准备修改通道参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpdateChannel_Click(object sender, EventArgs e)
        {
            EnableChannel(true);
        }

        /// <summary>
        /// 保存修改后的通道参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OKChannel_Click(object sender, EventArgs e)
        {
            paramterChannel = paramterChannelDAL.GetList().FirstOrDefault();
            if (paramterChannel == null)
            {
                paramterChannel = new ChannelFreqParamter();
            }
            paramterChannel.LeftAxisVerticalLower = Convert.ToDouble(this.txt_LeftAxisVerticalLower.Text.Trim());
            paramterChannel.LeftAxisVerticalUpper = Convert.ToDouble(this.txt_LeftAxisVerticalUpper.Text.Trim());

            paramterChannel.RightAxisVerticalLower = Convert.ToDouble(this.txt_RightAxisVerticalLower.Text.Trim());
            paramterChannel.RightAxisVerticalUpper = Convert.ToDouble(this.txt_RightAxisVerticalUpper.Text.Trim());

            paramterChannel.LeftAxisHorizontalLower = Convert.ToDouble(this.txt_LeftAxisHorizontalLower.Text.Trim());
            paramterChannel.LeftAxisHorizontalUpper = Convert.ToDouble(this.txt_LeftAxisHorizontalUpper.Text.Trim());

            paramterChannel.FrameVerticalLower = Convert.ToDouble(this.txt_FrameVerticalLower.Text.Trim());
            paramterChannel.FrameVerticalUpper = Convert.ToDouble(this.txt_FrameVerticalUpper.Text.Trim());
            paramterChannel.FrameHorizontalLower = Convert.ToDouble(this.txt_FrameHorizontalLower.Text.Trim());
            paramterChannel.FrameHorizontalUpper = Convert.ToDouble(this.txt_FrameHorizontalUpper.Text.Trim());

            paramterChannel.BodyVerticalLower = Convert.ToDouble(this.txt_BodyVerticalLower.Text.Trim());
            paramterChannel.BodyVerticalUpper = Convert.ToDouble(this.txt_BodyVerticalUpper.Text.Trim());
            paramterChannel.BodyHorizontalLower = Convert.ToDouble(this.txt_BodyHorizontalLower.Text.Trim());
            paramterChannel.BodyHorizontalUpper = Convert.ToDouble(this.txt_BodyHorizontalUpper.Text.Trim());

            bool isok = paramterChannelDAL.Save(paramterChannel);
            if (isok)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }


        private void btn_UpdateDeviation_Click(object sender, EventArgs e)
        {
            EnableDeviation(true);
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            paramterDeviation = paramterDeviationDAL.GetDeviationParameterList().FirstOrDefault();
            if (paramterDeviation == null)
            {
                paramterDeviation = new DeviationParameter();
            }

            paramterDeviation.Value1_1 = Convert.ToDouble(this.txt1_1.Text.Trim());
            paramterDeviation.Value1_2 = Convert.ToDouble(this.txt1_2.Text.Trim());
            paramterDeviation.Value1_3 = Convert.ToDouble(this.txt1_3.Text.Trim());

            paramterDeviation.Value2_1 = Convert.ToDouble(this.txt2_1.Text.Trim());
            paramterDeviation.Value2_2 = Convert.ToDouble(this.txt2_2.Text.Trim());
            paramterDeviation.Value2_3 = Convert.ToDouble(this.txt2_3.Text.Trim());

            bool isok = paramterDeviationDAL.Save(paramterDeviation);
            if (isok)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }


        #region 私有方法

        /// <summary>
        /// 控制计算参数控件是否可用
        /// </summary>
        /// <param name="isEnable"></param>
        private void EnableCalc(bool isEnable)
        {
            this.txt_ComputingTime.Enabled = isEnable;
            this.txt_SamplingFrequency.Enabled = isEnable;
            this.txt_EffectiveValueLength.Enabled = isEnable;
            this.txt_SamplingPoints.Enabled = isEnable;
            //速度等级
            this.txtSpeedGrade.Enabled = isEnable;
            this.txt_MaxValueLength.Enabled = isEnable;
            this.txt_LowSpeedControlValue.Enabled = isEnable;
            this.txt_LowSpeedControlRate.Enabled = isEnable;
        }

        /// <summary>
        /// 控制通道参数控件是否可用
        /// </summary>
        /// <param name="isEnable"></param>
        private void EnableChannel(bool isEnable)
        {
            this.txt_LeftAxisVerticalLower.Enabled = isEnable;
            this.txt_LeftAxisVerticalUpper.Enabled = isEnable;

            this.txt_RightAxisVerticalLower.Enabled = isEnable;
            this.txt_RightAxisVerticalUpper.Enabled = isEnable;

            this.txt_LeftAxisHorizontalLower.Enabled = isEnable;
            this.txt_LeftAxisHorizontalUpper.Enabled = isEnable;

            this.txt_FrameVerticalLower.Enabled = isEnable;
            this.txt_FrameVerticalUpper.Enabled = isEnable;
            this.txt_FrameHorizontalLower.Enabled = isEnable;
            this.txt_FrameHorizontalUpper.Enabled = isEnable;

            this.txt_BodyVerticalLower.Enabled = isEnable;
            this.txt_BodyVerticalUpper.Enabled = isEnable;
            this.txt_BodyHorizontalLower.Enabled = isEnable;
            this.txt_BodyHorizontalUpper.Enabled = isEnable;
        }

        /// <summary>
        /// 控制偏差阀值参数控件是否可用
        /// </summary>
        /// <param name="isEnable"></param>
        private void EnableDeviation(bool isEnable)
        {
            this.txt1_1.Enabled = isEnable;
            this.txt1_2.Enabled = isEnable;
            this.txt1_3.Enabled = isEnable;

            this.txt2_1.Enabled = isEnable;
            this.txt2_2.Enabled = isEnable;
            this.txt2_3.Enabled = isEnable;
        }

        /// <summary>
        /// 加载计算参数
        /// </summary>
        private void LoadCalcParamter()
        {
            parameterCalc = paramterCalcDAL.GetList().FirstOrDefault();
            if (parameterCalc != null)
            {
                this.txt_ComputingTime.Text = parameterCalc.ComputingTime.ToString();
                this.txt_SamplingFrequency.Text = parameterCalc.SamplingFrequency.ToString();
                this.txt_EffectiveValueLength.Text = parameterCalc.EffectiveValueLength.ToString();
                this.txt_SamplingPoints.Text = parameterCalc.SamplingPoints.ToString();
                //速度等级
                this.txtSpeedGrade.Text = parameterCalc.SpeedGrade.ToString();
                this.txt_MaxValueLength.Text = parameterCalc.MaxValueLength.ToString();
                this.txt_LowSpeedControlValue.Text = parameterCalc.LowSpeedControlValue.ToString();
                this.txt_LowSpeedControlRate.Text = parameterCalc.LowSpeedControlRate.ToString();
            }
        }

        /// <summary>
        /// 加载通道参数
        /// </summary>
        private void LoadChannelParamter()
        {
            paramterChannel = paramterChannelDAL.GetList().FirstOrDefault();
            if (paramterChannel != null)
            {
                this.txt_LeftAxisVerticalLower.Text = paramterChannel.LeftAxisVerticalLower.ToString();
                this.txt_LeftAxisVerticalUpper.Text = paramterChannel.LeftAxisVerticalUpper.ToString();
                this.txt_LeftAxisHorizontalLower.Text = paramterChannel.LeftAxisHorizontalLower.ToString();
                this.txt_LeftAxisHorizontalUpper.Text = paramterChannel.LeftAxisHorizontalUpper.ToString();

                this.txt_RightAxisVerticalLower.Text = paramterChannel.RightAxisVerticalLower.ToString();
                this.txt_RightAxisVerticalUpper.Text = paramterChannel.RightAxisVerticalUpper.ToString();

                this.txt_FrameVerticalLower.Text = paramterChannel.FrameVerticalLower.ToString();
                this.txt_FrameVerticalUpper.Text = paramterChannel.FrameVerticalUpper.ToString();
                this.txt_FrameHorizontalLower.Text = paramterChannel.FrameHorizontalLower.ToString();
                this.txt_FrameHorizontalUpper.Text = paramterChannel.FrameHorizontalUpper.ToString();

                this.txt_BodyVerticalLower.Text = paramterChannel.BodyVerticalLower.ToString();
                this.txt_BodyVerticalUpper.Text = paramterChannel.BodyVerticalUpper.ToString();
                this.txt_BodyHorizontalLower.Text = paramterChannel.BodyHorizontalLower.ToString();
                this.txt_BodyHorizontalUpper.Text = paramterChannel.BodyHorizontalUpper.ToString();
            }
        }

        /// <summary>
        /// 加载偏差阀值参数
        /// </summary>
        private void LoadDeviationParamter()
        {
            paramterDeviation = paramterDeviationDAL.GetDeviationParameterList().FirstOrDefault();
            if (paramterDeviation != null)
            {
                this.txt1_1.Text = paramterDeviation.Value1_1.ToString();
                this.txt1_2.Text = paramterDeviation.Value1_2.ToString();
                this.txt1_3.Text = paramterDeviation.Value1_3.ToString();

                this.txt2_1.Text = paramterDeviation.Value2_1.ToString();
                this.txt2_2.Text = paramterDeviation.Value2_2.ToString();
                this.txt2_3.Text = paramterDeviation.Value2_3.ToString();
            }
        }

        #endregion

        

    }
}
