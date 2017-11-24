using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Test
{
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

                if (doc.Range.Bookmarks["wtname1"] != null)
                {
                    doc.Range.Bookmarks["wtname1"].Text = temp.SurveyDate;
                }

                #region 创建表格

                if (doc.Range.Bookmarks["table"] != null)
                {
                    doc.Range.Bookmarks["table"].Text = "表1-2 测点名称及缩写";
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
                    builder.Write("测点序号");
                    builder.InsertCell(); builder.Write("测点缩写");
                    builder.InsertCell(); builder.Write("测点名称");
                    builder.EndRow();

                    //builder.CellFormat.Shading.BackgroundPatternColor = Color.White;
                    if (temp.Records != null && temp.Records.Count > 0)
                    {
                        foreach (var item in temp.Records)
                        {
                            builder.InsertCell(); builder.Write(item.ID.ToString());
                            builder.InsertCell(); builder.Write(item.BureauName);
                            builder.InsertCell(); builder.Write(item.LineName);
                            builder.EndRow();
                        }
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
                }

                #endregion

                try
                {
                    doc.Save(TargetFilePath.ToString(), Aspose.Words.SaveFormat.Doc);
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
