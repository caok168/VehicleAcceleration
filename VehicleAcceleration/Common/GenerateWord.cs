using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VehicleAcceleration.Model;

namespace VehicleAcceleration.Common
{
    /// <summary>
    /// 创建Word一般类
    /// </summary>
    public class GenerateWord
    {
        #region 定义

        /// <summary>
        /// 文档模板路径
        /// </summary>
        private string TemplateFilePath;
        /// <summary>
        /// 文档生成目标路径
        /// </summary>
        private object TargetFilePath;



        Aspose.Words.Document doc;
        Aspose.Words.DocumentBuilder builder;

        #endregion

        #region 格式设置
        //标题格式设置
        object Heading1 = "标题 1";
        object Heading3 = "标题 3";
        object Heading4 = "标题 4";
        /// <summary>
        /// 黑体
        /// </summary>
        string HeadingFontName = "黑体";
        string _bodyStyle = "正文";
        /// <summary>
        /// 仿宋_GB2312
        /// </summary>
        string _BodyFontName = "仿宋_GB2312";
        string EnAndNumFontName = "Arial";
        /// <summary>
        /// 仿宋
        /// </summary>
        string FontName_FangSong = "仿宋";

        /// <summary>
        /// 字号小五用于标题
        /// </summary>
        float fontSize_LFive = 9;
        /// <summary>
        /// 字号小四，
        /// </summary>
        float fontSize_LFour = 12;
        float fontSize_Four = 14;

        //字号 五号  2015-02-03 ck
        double fontSize_Five = 10.5;

        #endregion

        public GenerateWord(string tempPath, string tarPath)
        {
            TemplateFilePath = tempPath;
            TargetFilePath = tarPath;
        }

        /// <summary>
        /// 生成指定信息的Word文档
        /// </summary>
        /// <param name="temp"></param>
        public void OverWriteWord(ReplaceWordData temp)
        {
            try
            {
                if (temp == null)
                    return;
                if (!CreateWord())
                {
                    throw new Exception("模板文档不存在。路径：" + TemplateFilePath);
                }
                doc = new Aspose.Words.Document(TargetFilePath.ToString());
                builder = new Aspose.Words.DocumentBuilder(doc);

                #region 基础数据

                if (doc.Range.Bookmarks["SurveyRegion"] != null)
                {
                    doc.Range.Bookmarks["SurveyRegion"].Text = temp.SurveyRegion;
                }

                if (doc.Range.Bookmarks["SurveyDate"] != null)
                {
                    doc.Range.Bookmarks["SurveyDate"].Text = temp.SurveyDate;
                }

                if (doc.Range.Bookmarks["SurveyDirection"] != null)
                {
                    doc.Range.Bookmarks["SurveyDirection"].Text = temp.SurveyDirection;
                }

                if (doc.Range.Bookmarks["RunDirection"] != null)
                {
                    doc.Range.Bookmarks["RunDirection"].Text = temp.RunDirection;
                }

                if (doc.Range.Bookmarks["LineName"] != null)
                {
                    doc.Range.Bookmarks["LineName"].Text = temp.LineNameCn;
                }

                if (doc.Range.Bookmarks["LineName1"] != null)
                {
                    doc.Range.Bookmarks["LineName1"].Text = temp.LineNameCn;
                }

                if (doc.Range.Bookmarks["ActualMile"] != null)
                {
                    doc.Range.Bookmarks["ActualMile"].Text = temp.ActualMile;
                }

                if (doc.Range.Bookmarks["ActualMile1"] != null)
                {
                    doc.Range.Bookmarks["ActualMile1"].Text = temp.ActualMile;
                }

                if (doc.Range.Bookmarks["MileMore200"] != null)
                {
                    doc.Range.Bookmarks["MileMore200"].Text = temp.MileMore200;
                }

                if (doc.Range.Bookmarks["SurveyResult"] != null)
                {
                    doc.Range.Bookmarks["SurveyResult"].Text = temp.SurveyResult;
                }

                if (doc.Range.Bookmarks["RecordPerson"] != null)
                {
                    doc.Range.Bookmarks["RecordPerson"].Text = temp.RecordPerson;
                }

                if (doc.Range.Bookmarks["CheckPerson"] != null)
                {
                    doc.Range.Bookmarks["CheckPerson"].Text = temp.CheckPerson;
                }

                #endregion

                #region 创建表格

                int levelA = 0;
                    int levelB = 0;
                    int levelC = 0;

                if (doc.Range.Bookmarks["table"] != null)
                {
                    //doc.Range.Bookmarks["table"].Text = "表1-2 测点名称及缩写";
                    builder.MoveToBookmark("table");
                    builder.StartTable();
                    builder.InsertCell();
                    builder.CellFormat.Borders.LineStyle = Aspose.Words.LineStyle.Single;
                    builder.CellFormat.Borders.LineWidth = 1;
                    //builder.CellFormat.Shading.BackgroundPatternColor = Color.LightGray;
                    builder.CellFormat.VerticalAlignment = Aspose.Words.Tables.CellVerticalAlignment.Center;
                    builder.Font.Name = _BodyFontName;
                    builder.Font.Size = fontSize_Five;
                    builder.Font.Bold = false;
                    builder.CellFormat.HorizontalMerge = Aspose.Words.Tables.CellMerge.None;
                    builder.Write("序号");
                    builder.InsertCell(); builder.Write("局名");
                    builder.InsertCell(); builder.Write("线名");
                    builder.InsertCell(); builder.Write("里程");
                    builder.InsertCell(); builder.Write("轴箱加速度测试内容");
                    builder.InsertCell(); builder.Write("有效值/峰值(m/s~2)");
                    builder.InsertCell(); builder.Write("轨道冲击指数");
                    builder.InsertCell(); builder.Write("偏差等级");
                    builder.InsertCell(); builder.Write("速度(km/h)");
                    builder.InsertCell(); builder.Write("线型");
                    builder.InsertCell(); builder.Write("备注");
                    builder.EndRow();

                    //builder.CellFormat.Shading.BackgroundPatternColor = Color.White;

                    if (temp.Records != null && temp.Records.Count > 0)
                    {
                        var aaa = temp.Records.GroupBy(s => s.Miles).ToList();

                        int rowNum = 1;

                        foreach (var item in aaa)
                        {
                            int num = 0;
                            int length = item.Count();

                            #region 判断LevelA、LevelB、LevelC的个数

                            int tempLevelA = 0;
                            int tempLevelB = 0;
                            int tempLevelC = 0;

                            foreach (var item1 in item)
                            {
                                if (item1.DeviationGrade == "A")
                                {
                                    tempLevelA = 1;
                                }
                                if (item1.DeviationGrade == "B")
                                {
                                    tempLevelB = 1;
                                }
                                if (item1.DeviationGrade == "C")
                                {
                                    tempLevelC = 1;
                                }
                            }

                            if (tempLevelC != 0)
                            {
                                levelC++;
                            }
                            else if (tempLevelC == 0 && tempLevelB != 0)
                            {
                                levelB++;
                            }
                            else
                            {
                                levelA++;
                            }

                            #endregion

                            foreach (var item1 in item)
                            {
                                if (length > 1)
                                {
                                    #region 多个表格合并的情况

                                    if (num == 0)
                                    {
                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.First;
                                        //builder.Write(item1.ID.ToString());
                                        builder.Write(rowNum.ToString());

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.First;
                                        builder.Write(item1.BureauName);

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.First;
                                        builder.Write(temp.LineNameCn);

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.First;
                                        builder.Write(item1.Miles.ToString("F3"));

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.ChannelName);

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.RmsOrPeakValue.ToString("F2"));

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.TrackImpactIndex.ToString("F2"));

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.DeviationGrade);

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.Speed.ToString());

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.LineType);

                                        builder.InsertCell(); 
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.Remark);
                                        builder.EndRow();
                                    }
                                    else
                                    {
                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.Previous;

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.Previous;

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.Previous;

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.Previous;

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.ChannelName);

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.RmsOrPeakValue.ToString("F2"));

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.TrackImpactIndex.ToString("F2"));

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.DeviationGrade);

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.Speed.ToString());

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.LineType);

                                        builder.InsertCell();
                                        builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                        builder.Write(item1.Remark);
                                        builder.EndRow();
                                    }

                                    #endregion
                                }
                                else
                                {
                                    #region 单个表格

                                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                    builder.InsertCell();
                                    builder.Write(rowNum.ToString());
                                    //builder.Write(item1.ID.ToString());
                                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                    builder.InsertCell(); builder.Write(item1.BureauName);
                                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                    builder.InsertCell(); builder.Write(temp.LineNameCn);
                                    builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;
                                    builder.InsertCell(); builder.Write(item1.Miles.ToString("F3"));
                                    builder.InsertCell(); builder.Write(item1.ChannelName);
                                    builder.InsertCell(); builder.Write(item1.RmsOrPeakValue.ToString("F2"));
                                    builder.InsertCell(); builder.Write(item1.TrackImpactIndex.ToString("F2"));
                                    builder.InsertCell(); builder.Write(item1.DeviationGrade);
                                    builder.InsertCell(); builder.Write(item1.Speed.ToString());
                                    builder.InsertCell(); builder.Write(item1.LineType);
                                    builder.InsertCell(); builder.Write(item1.Remark);
                                    builder.EndRow();

                                    #endregion
                                }

                                num++;
                            }
                            builder.CellFormat.VerticalMerge = Aspose.Words.Tables.CellMerge.None;

                            rowNum++;
                        }

                        //foreach (var item in temp.Records)
                        //{
                        //    builder.InsertCell(); builder.Write(item.ID.ToString());
                        //    builder.InsertCell(); builder.Write(item.BureauName);
                        //    builder.InsertCell(); builder.Write(temp.LineNameCn);
                        //    builder.InsertCell(); builder.Write(item.Miles.ToString());
                        //    builder.InsertCell(); builder.Write(item.ChannelName);
                        //    builder.InsertCell(); builder.Write(item.RmsOrPeakValue.ToString());
                        //    builder.InsertCell(); builder.Write(item.TrackImpactIndex.ToString());
                        //    builder.InsertCell(); builder.Write(item.DeviationGrade);
                        //    builder.InsertCell(); builder.Write(item.Speed.ToString());
                        //    builder.InsertCell(); builder.Write(item.LineType);
                        //    builder.InsertCell(); builder.Write(item.Remark);
                        //    builder.EndRow();
                        //}
                    }

                    builder.EndTable();
                }

                #endregion

                #region 插入图片

                if (doc.Range.Bookmarks["img"] != null)
                {
                    if (temp.PointImage != null)
                    {
                        try
                        {
                            doc.Range.Bookmarks["img"].Text = "测点分布图";
                            Aspose.Words.DocumentBuilder builderImg = new Aspose.Words.DocumentBuilder(doc);
                            builderImg.MoveToBookmark("img");
                            builderImg.InsertImage(temp.PointImage, 450, 250);
                        }
                        catch { }
                    }

                    //doc.Range.Bookmarks["img"].Text = "测点分布图";
                    Aspose.Words.DocumentBuilder builderImg1 = new Aspose.Words.DocumentBuilder(doc);
                    builderImg1.MoveToBookmark("img");
                    //插入图片
                    if (File.Exists(temp.ImageUrl1))
                    {
                        builderImg1.InsertImage(temp.ImageUrl1, 450, 250);
                    }

                    builderImg1.MoveToBookmark("img2");
                    //插入图片
                    if (File.Exists(temp.ImageUrl2))
                    {
                        builderImg1.InsertImage(temp.ImageUrl2, 450, 250);
                    }

                    builderImg1.MoveToBookmark("img3");
                    //插入图片
                    if (File.Exists(temp.ImageUrl3))
                    {
                        builderImg1.InsertImage(temp.ImageUrl3, 450, 250);
                    }
                }

                #endregion

                #region 结论

                if (doc.Range.Bookmarks["CountA"] != null)
                {
                    //doc.Range.Bookmarks["CountA"].Text = temp.CountA.ToString();
                    doc.Range.Bookmarks["CountA"].Text = levelA.ToString();
                }
                if (doc.Range.Bookmarks["CountB"] != null)
                {
                    //doc.Range.Bookmarks["CountB"].Text = temp.CountB.ToString();
                    doc.Range.Bookmarks["CountB"].Text = levelB.ToString();
                }
                if (doc.Range.Bookmarks["CountC"] != null)
                {
                    //doc.Range.Bookmarks["CountC"].Text = temp.CountC.ToString();
                    doc.Range.Bookmarks["CountC"].Text = levelC.ToString();
                }

                #endregion

                try
                {
                    doc.Save(TargetFilePath.ToString(), Aspose.Words.SaveFormat.Docx);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        #region 私有方法

        /// <summary>
        /// 生成word文档
        /// </summary>
        /// <returns></returns>
        private bool CreateWord()
        {
            try
            {
                bool res = false;
                if (!File.Exists(TemplateFilePath.ToString()))
                {
                    return res;
                }
                if (TargetFilePath == null)
                    return res;
                if (File.Exists(TargetFilePath.ToString()))
                {
                    File.Delete(TargetFilePath.ToString());
                }
                if (!Directory.Exists(Path.GetDirectoryName(TargetFilePath.ToString())))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(TargetFilePath.ToString()));
                }
                File.Copy(TemplateFilePath, TargetFilePath.ToString());
                if (!File.Exists(TargetFilePath.ToString()))
                {
                    throw new Exception("创建文档失败！");
                }
                else
                {
                    res = true;
                }
                return res;
            }
            catch (Exception e1)
            {
                throw new Exception("文档正在使用中，请联系管理员解决。路径：" + TargetFilePath.ToString());
            }
        }

        #endregion
    }
}
