using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CitFileProcess
{
    /// <summary>
    /// 读取Cit文件帮助类
    /// </summary>
    public class CitFileHelper
    {
        #region 全局变量

        /// <summary>
        /// cit文件的文件头信息
        /// </summary>
        public DataHeadInfo dhi { get; set; }

        /// <summary>
        /// cit文件的通道定义信息
        /// </summary>
        public List<DataChannelInfo> dciL { get; set; }

        #endregion

        #region 文件头部分

        #region 获取cit 文件头 文件信息

        /// <summary>
        /// 读取cit文件头中的文件信息信息，并返回文件头信息结构体
        /// </summary>
        /// <param name="bDataInfo">文件头中包含文件信息的120个字节 </param>
        /// <returns>文件信息结构体</returns>
        private DataHeadInfo GetDataInfoHead(byte[] bDataInfo)
        {
            DataHeadInfo dhi = new DataHeadInfo(); 
            StringBuilder sbDataVersion = new StringBuilder();
            StringBuilder sbTrackCode = new StringBuilder();
            StringBuilder sbTrackName = new StringBuilder();
            StringBuilder sbTrain = new StringBuilder();
            StringBuilder sbDate = new StringBuilder();
            StringBuilder sbTime = new StringBuilder();

            dhi.iDataType = BitConverter.ToInt32(bDataInfo, 0);
            //1+20个字节，数据版本
            for (int i = 1; i <= (int)bDataInfo[DataHeadOffset.DataVersion]; i++)
            {
                sbDataVersion.Append(UnicodeEncoding.Default.GetString(bDataInfo, DataHeadOffset.DataVersion + i, 1));
            }
            //1+4个字节，线路代码
            for (int i = 1; i <= (int)bDataInfo[DataHeadOffset.TrackCode]; i++)
            {
                sbTrackCode.Append(UnicodeEncoding.Default.GetString(bDataInfo, DataHeadOffset.TrackCode + i, 1));
            }
            //1+20个字节，线路名
            for (int i = 1; i <= (int)bDataInfo[DataHeadOffset.TrackName]; i++, i++)
            {
                sbTrackName.Append(UnicodeEncoding.Default.GetString(bDataInfo, DataHeadOffset.TrackName + i, 1));
            }
            
            dhi.iDir = BitConverter.ToInt32(bDataInfo, DataHeadOffset.Dir);

            //1+20个字节，检测车号
            for (int i = 1; i <= (int)bDataInfo[DataHeadOffset.TrainCode]; i++)
            {
                sbTrain.Append(UnicodeEncoding.Default.GetString(bDataInfo, DataHeadOffset.TrainCode + i, 1));
            }
            //1+10个字节，检测日期
            for (int i = 1; i <= (int)bDataInfo[DataHeadOffset.Date]; i++)
            {
                sbDate.Append(UnicodeEncoding.Default.GetString(bDataInfo, DataHeadOffset.Date + i, 1));
            }
            //1+8个字节，检测时间
            for (int i = 1; i <= (int)bDataInfo[DataHeadOffset.Time]; i++)
            {
                sbTime.Append(UnicodeEncoding.Default.GetString(bDataInfo, DataHeadOffset.Time + i, 1));
            }

            dhi.iRunDir = BitConverter.ToInt32(bDataInfo, DataHeadOffset.RunDir);
            dhi.iKmInc = BitConverter.ToInt32(bDataInfo, DataHeadOffset.KmInc);
            dhi.fkmFrom = BitConverter.ToSingle(bDataInfo, DataHeadOffset.KmFrom);
            dhi.fkmTo = BitConverter.ToSingle(bDataInfo, DataHeadOffset.KmTo);
            dhi.iSmaleRate = BitConverter.ToInt32(bDataInfo, DataHeadOffset.SmaleRate);
            dhi.iChannelNumber = BitConverter.ToInt32(bDataInfo, DataHeadOffset.ChannelNumber);
            dhi.sDataVersion = sbDataVersion.ToString();
            dhi.sDate = DateTime.Parse(sbDate.ToString()).ToString("yyyy-MM-dd");
            dhi.sTime = DateTime.Parse(sbTime.ToString()).ToString("HH:mm:ss");
            dhi.sTrackCode = sbTrackCode.ToString();
            dhi.sTrackName = sbTrackName.ToString();
            dhi.sTrain = sbTrain.ToString();

            return dhi;
        }

        /// <summary>
        /// 查询CIT文件头信息--返回文件头信息结构体，同时dhi全局变量赋值
        /// </summary>
        /// <param name="sFile"></param>
        /// <returns>结构体</returns>
        public DataHeadInfo GetDataInfoHead(string sFile)
        {
            using (FileStream fs = new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BinaryReader br = new BinaryReader(fs, Encoding.Default))
                {
                    br.BaseStream.Position = 0;
                    dhi = GetDataInfoHead(br.ReadBytes(DataOffset.DataHeadLength));
                }
            }
            return dhi;
        }

        #endregion

        #region 获取cit 文件头 单个通道定义信息

        /// <summary>
        /// 获取单个通道定义信息
        /// </summary>
        /// <param name="bDataInfo">包含通道定义信息的字节数组</param>
        /// <param name="start">起始下标</param>
        /// <returns>通道定义信息结构体对象</returns>
        private DataChannelInfo GetChannelInfo(byte[] bDataInfo, int start)
        {
            DataChannelInfo dci = new DataChannelInfo();
            StringBuilder sUnit = new StringBuilder();

            dci.sID = BitConverter.ToInt32(bDataInfo, start);//通道起点为0，导致通道id取的都是第一个通道的id，把0改为start，
            dci.sNameEn = UnicodeEncoding.Default.GetString(bDataInfo, DataChannelOffset.NameEn + 1 + start, (int)bDataInfo[DataChannelOffset.NameEn + start]);
            dci.sNameCh = UnicodeEncoding.Default.GetString(bDataInfo, DataChannelOffset.NameCh + 1 + start, (int)bDataInfo[DataChannelOffset.NameCh + start]);
            for (int i = 1; i <= (int)bDataInfo[DataChannelOffset.Unit + start]; i++)
            {
                sUnit.Append(UnicodeEncoding.Default.GetString(bDataInfo, DataChannelOffset.Unit + i + start, 1));
            }
            dci.sUnit = sUnit.ToString();
            dci.fScale = BitConverter.ToSingle(bDataInfo, DataChannelOffset.Scale + start);
            dci.fOffset = BitConverter.ToSingle(bDataInfo, DataChannelOffset.Offset + start);

            return dci;
        }


        /// <summary>
        /// 查询CIT通道信息--返回通道定义结构体列表，同时dciL全局变量赋值
        /// 返回：通道定义信息结构体对象列表
        /// </summary>
        /// <param name="sFile">CIT文件名（全路径）</param>
        /// <returns>返回结构体</returns>
        public List<DataChannelInfo> GetDataChannelInfoHead(string sFile)
        {
            using (FileStream fs = new FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BinaryReader br = new BinaryReader(fs, Encoding.Default))
                {
                    br.BaseStream.Position = 0;
                    br.ReadBytes(DataOffset.DataHeadLength);
                    byte[] bChannelData = br.ReadBytes(dhi.iChannelNumber * DataOffset.DataChannelLength);
                    dciL = new List<DataChannelInfo>();
                    for (int i = 0; i < dhi.iChannelNumber * DataOffset.DataChannelLength; i += DataOffset.DataChannelLength)
                    {
                        DataChannelInfo dci = GetChannelInfo(bChannelData, i);
                        if (i == DataOffset.DataChannelLength)
                        {
                            dci.fScale = 4;
                        }
                        dciL.Add(dci);
                    }
                }
            }
            return dciL;
        }

        #endregion

        #region 获取cit 文件头 补充信息（附加信息）
        /// <summary>
        /// 获取补充信息（附加信息）,返回值是字节流，客户负责解析附加信息到具体的类型
        /// </summary>
        /// <param name="citFilePath"></param>
        /// <returns></returns>
        public byte[] GetExtraInfo(string citFilePath)
        {
            FileStream fs = new FileStream(citFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(fs, Encoding.Default);

            DataHeadInfo m_dhi = GetDataInfoHead(br.ReadBytes(DataOffset.DataHeadLength));
            br.BaseStream.Position = DataOffset.DataHeadLength + m_dhi.iChannelNumber * DataOffset.DataChannelLength;
            //br.ReadBytes(120);
            //br.ReadBytes(65 * m_dhi.iChannelNumber);
            byte[] extraByte = br.ReadBytes(BitConverter.ToInt32(br.ReadBytes(DataOffset.ExtraLength), 0));
            return extraByte;
        }

        #endregion

        #region 获取文件信息的指定字段信息

        /// <summary>
        /// 获取文件信息的文件类型
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>文件类型</returns>
        public int GetHeadDataType(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.iDataType;
        }

        /// <summary>
        /// 获取文件信息的文件版本号
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>文件版本号</returns>
        public string GetHeadDataVersion(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.sDataVersion;
        }

        /// <summary>
        /// 获取文件信息的线路代码，同PWMIS
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>线路代码，同PWMIS</returns>
        public string GetHeadTrackCode(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.sTrackCode;
        }

        /// <summary>
        /// 获取文件信息的线路名 英文最好
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>线路名 英文最好</returns>
        public string GetHeadTrackName(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.sTrackName;
        }

        /// <summary>
        /// 获取文件信息的行别：1上行、2下行、3单线
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>行别：1上行、2下行、3单线</returns>
        public int GetHeadDir(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.iDir;
        }

        /// <summary>
        /// 获取文件信息的检测车号，不足补空格
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>检测车号，不足补空格</returns>
        public string GetHeadTrain(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.sTrain;
        }

        /// <summary>
        /// 获取文件信息的检测日期：yyyy-MM-dd
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>检测日期：yyyy-MM-dd</returns>
        public string GetHeadDate(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.sDate;
        }

        /// <summary>
        /// 获取文件信息的检测起始时间：HH:mm:ss
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>检测起始时间：HH:mm:ss</returns>
        public string GetHeadTime(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.sTime;
        }

        /// <summary>
        /// 获取文件信息的检测方向，正0，反1
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>检测方向，正0，反1</returns>
        public int GetHeadRunDir(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.iRunDir;
        }

        /// <summary>
        /// 获取文件信息的增里程0，减里程1
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>增里程0，减里程1</returns>
        public int GetHeadKmInc(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.iKmInc;
        }

        /// <summary>
        /// 获取文件信息的开始里程
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>开始里程</returns>
        public float GetHeadKmFrom(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.fkmFrom;
        }

        /// <summary>
        /// 获取文件信息的结束里程，检测结束后更新
        /// </summary>
        /// <param name="citFile">结束里程，检测结束后更新</param>
        /// <returns></returns>
        public float GetHeadKmTo(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.fkmTo;
        }

        /// <summary>
        /// 获取文件信息的采样数，（距离采样>0, 时间采样<0）
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>采样数，（距离采样>0, 时间采样<0）</returns>
        public int GetHeadSmaleRate(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.iSmaleRate;
        }

        /// <summary>
        /// 获取文件信息的数据块中通道总数
        /// </summary>
        /// <param name="citFile"></param>
        /// <returns>数据块中通道总数</returns>
        public int GetHeadChannelNumber(string citFile)
        {
            DataHeadInfo headInfo = GetDataInfoHead(citFile);
            return headInfo.iChannelNumber;
        }

        #endregion

        #region 获取通道定义的指定字段信息

        /// <summary>
        /// 根据通道名称获取通道序号
        /// </summary>
        /// <param name="channelName">通道名称（中文或者英文）</param>
        /// <param name="channelList">通道定义信息结构体对象列表</param>
        /// <returns>通道序号</returns>
        public int GetChannelId(string channelName, List<DataChannelInfo> channelList)
        {
            int channelNumber = -1;
            for (int i = 0; i < channelList.Count; i++)
            {
                if ((channelList[i].sNameEn.Equals(channelName) || channelList[i].sNameCh.Equals(channelName)) && (channelName != ""))
                {
                    channelNumber = i + 1;
                    //channelNumber = channelList[i].sID;
                    break;
                }
            }

            return channelNumber;
        }

        /// <summary>
        /// 根据通道序号获取通道名称英文
        /// </summary>
        /// <param name="id">通道序号</param>
        /// <param name="channelList">通道定义信息结构体对象列表</param>
        /// <returns>通道名称英文</returns>
        public string GetChannelNameEn(int id, List<DataChannelInfo> channelList)
        {
            string channelName = "";
            if (channelList.Count >= id)
            {
                channelName = channelList[id - 1].sNameEn;
            }
            return channelName;
        }

        /// <summary>
        /// 根据通道序号获取通道名称中文
        /// </summary>
        /// <param name="id">通道序号</param>
        /// <param name="channelList">通道定义信息结构体对象列表</param>
        /// <returns>通道名称中文</returns>
        public string GetChannelNameCn(int id, List<DataChannelInfo> channelList)
        {
            string channelName = "";
            if (channelList.Count >= id)
            {
                channelName = channelList[id - 1].sNameCh;
            }
            return channelName;
        }

        /// <summary>
        /// 根据通道序号获取通道比例
        /// </summary>
        /// <param name="id">通道序号</param>
        /// <param name="channelList">通道定义信息结构体对象列表</param>
        /// <returns>通道比例</returns>
        public float GetChannelScale(int id, List<DataChannelInfo> channelList)
        {
            float channelScale = 0;
            if (channelList.Count >= id)
            {
                channelScale = channelList[id - 1].fScale;
            }
            return channelScale;
        }

        /// <summary>
        /// 根据通道英文名称获取通道比例
        /// </summary>
        /// <param name="enname">通道英文名称</param>
        /// <param name="channelList">通道定义信息结构体对象列表</param>
        /// <returns>通道比例</returns>
        public float GetChannelScale(string enname, List<DataChannelInfo> channelList)
        {
            float channelScale = 0;
            for (int i = 0; i < channelList.Count; i++)
            {
                if (channelList[i].sNameEn == enname)
                {
                    channelScale = channelList[i].fScale;
                    break;
                }
            }
            return channelScale;
        }

        /// <summary>
        /// 根据通道序号获取通道基准线
        /// </summary>
        /// <param name="id">通道序号</param>
        /// <param name="channelList">通道定义信息结构体对象列表</param>
        /// <returns>通道基准线</returns>
        public float GetChannelOffset(int id, List<DataChannelInfo> channelList)
        {
            float channelOffset = 0;
            if (channelList.Count >= id)
            {
                channelOffset = channelList[id - 1].fOffset;
            }
            return channelOffset;
        }

        /// <summary>
        /// 根据通道英文名称获取通道基准线
        /// </summary>
        /// <param name="enname">通道英文名称</param>
        /// <param name="channelList">通道定义信息结构体对象列表</param>
        /// <returns>通道基准线</returns>
        public float GetChannelOffset(string enname, List<DataChannelInfo> channelList)
        {
            float channelOffset = 0;
            for (int i = 0; i < channelList.Count; i++)
            {
                if (channelList[i].sNameEn == enname)
                {
                    channelOffset = channelList[i].fOffset;
                    break;
                }
            }
            return channelOffset;
        }

        /// <summary>
        /// 根据通道序号获取通道单位
        /// </summary>
        /// <param name="id">通道序号</param>
        /// <param name="channelList">通道定义信息结构体对象列表</param>
        /// <returns>通道单位</returns>
        public string GetChannelUnit(int id, List<DataChannelInfo> channelList)
        {
            string channelUnit = "";
            if (channelList.Count >= id)
            {
                channelUnit = channelList[id - 1].sUnit;
            }
            return channelUnit;
        }

        /// <summary>
        /// 根据通道英文名称获取通道单位
        /// </summary>
        /// <param name="enname">通道英文名称</param>
        /// <param name="channelList">通道定义信息结构体对象列表</param>
        /// <returns>通道单位</returns>
        public string GetChannelUnit(string enname, List<DataChannelInfo> channelList)
        {
            string channelUnit = "";
            for (int i = 0; i < channelList.Count; i++)
            {
                if (channelList[i].sNameEn == enname)
                {
                    channelUnit = channelList[i].sUnit;
                    break;
                }
            }
            return channelUnit;
        }

        #endregion

        #endregion

        #region 数据块部分

        #region 获取指定通道数据

        /// <summary>
        /// 获取指定通道数据--返回单精度浮点数
        /// </summary>
        /// <param name="sSourceFile">cit文件</param>
        /// <param name="iChannelNumber">通道号（从1开始的）</param>
        /// <returns>通道数据</returns>
        public float[] GetSingleChannelDataFloat(String citFilePath, int channelId)
        {
            try
            {
                FileStream fs = new FileStream(citFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = 0;
                br.ReadBytes(DataOffset.DataHeadLength);
                br.ReadBytes(DataOffset.DataChannelLength * dhi.iChannelNumber);
                br.ReadBytes(BitConverter.ToInt32(br.ReadBytes(DataOffset.ExtraLength), 0));
                int iChannelNumberSize = dhi.iChannelNumber * 2;
                byte[] b = new byte[iChannelNumberSize];
                long iArray = (br.BaseStream.Length - br.BaseStream.Position) / iChannelNumberSize;
                float[] fReturnArray = new float[iArray];
                for (int i = 0; i < iArray; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);
                    if (dhi.sDataVersion.StartsWith("3."))
                    {
                        b = ByteXORByte(b);
                    }

                    float fGL = (BitConverter.ToInt16(b, (channelId - 1) * 2) / dciL[channelId - 1].fScale + dciL[channelId - 1].fOffset);

                    fReturnArray[i] = fGL;
                }


                br.Close();
                fs.Close();

                return fReturnArray;

            }
            catch (Exception ex)
            {
                return new float[1];
            }
        }


        /// <summary>
        /// 获取指定通道数据
        /// </summary>
        /// <param name="sSourceFile">cit文件</param>
        /// <param name="iChannelNumber">通道号（从1开始的）</param>
        /// <returns>通道数据</returns>
        public double[] GetSingleChannelData(string sSourceFile, int iChannelNumber)
        {
            try
            {
                List<DataChannelInfo> m_dcil = GetDataChannelInfoHead(sSourceFile);

                FileStream fs = new FileStream(sSourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = 0;

                DataHeadInfo m_dhi = GetDataInfoHead(br.ReadBytes(DataOffset.DataHeadLength));

                br.ReadBytes(DataOffset.DataChannelLength * m_dhi.iChannelNumber);
                br.ReadBytes(BitConverter.ToInt32(br.ReadBytes(DataOffset.ExtraLength), 0));
                int iChannelNumberSize = m_dhi.iChannelNumber * 2;
                byte[] b = new byte[iChannelNumberSize];
                long iArray = (br.BaseStream.Length - br.BaseStream.Position) / iChannelNumberSize;
                double[] fReturnArray = new double[iArray];
                for (int i = 0; i < iArray; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);
                    if (m_dhi.sDataVersion.StartsWith("3."))
                    {
                        b = ByteXORByte(b);
                    }

                    double fGL = (BitConverter.ToInt16(b, (iChannelNumber - 1) * 2) / m_dcil[iChannelNumber - 1].fScale + m_dcil[iChannelNumber - 1].fOffset);

                    fReturnArray[i] = fGL;
                }


                br.Close();
                fs.Close();

                return fReturnArray;

            }
            catch (Exception ex)
            {
                return new double[1];
            }
        }

        /// <summary>
        /// 获取指定通道数据---指定范围内
        /// </summary>
        /// <param name="sSourceFile">cit文件</param>
        /// <param name="iChannelNumber">通道号（从1开始的）</param>
        /// <param name="startPos">起始文件指针</param>
        /// <param name="endPos">结束文件指针</param>
        /// <returns>通道数据</returns>
        public double[] GetSingleChannelData(string sSourceFile, int iChannelNumber, long startPos, long endPos)
        {
            try
            {
                List<DataChannelInfo> m_dcil = GetDataChannelInfoHead(sSourceFile);

                FileStream fs = new FileStream(sSourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = 0;

                DataHeadInfo m_dhi = GetDataInfoHead(br.ReadBytes(DataOffset.DataHeadLength));

                br.ReadBytes(DataOffset.DataChannelLength * m_dhi.iChannelNumber);
                br.ReadBytes(BitConverter.ToInt32(br.ReadBytes(DataOffset.ExtraLength), 0));
                int iChannelNumberSize = m_dhi.iChannelNumber * 2;
                byte[] b = new byte[iChannelNumberSize];

                br.BaseStream.Position = startPos;

                long iArray = (endPos - br.BaseStream.Position) / iChannelNumberSize;
                double[] fReturnArray = new double[iArray];
                for (int i = 0; i < iArray; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);
                    if (m_dhi.sDataVersion.StartsWith("3."))
                    {
                        b = ByteXORByte(b);
                    }

                    double fGL = (BitConverter.ToInt16(b, (iChannelNumber - 1) * 2) / m_dcil[iChannelNumber - 1].fScale + m_dcil[iChannelNumber - 1].fOffset);

                    fReturnArray[i] = fGL;
                }


                br.Close();
                fs.Close();

                return fReturnArray;

            }
            catch (Exception ex)
            {
                return new double[1];
            }
        }

        /// <summary>
        /// 根据二进制流和开始位置结束位置获取指定通道的数据
        /// </summary>
        /// <param name="br"></param>
        /// <param name="iChannelNumber">iChannelNumber从1开始计数</param>
        /// <param name="startPos">起始文件指针</param>
        /// <param name="endPos">结束文件指针</param>
        /// <returns>通道数据</returns>
        public double[] GetSingleChannelData(BinaryReader br, int iChannelNumber, long startPos, long endPos)
        {
            try
            {
                int iChannelNumberSize = dhi.iChannelNumber * 2;
                byte[] b = new byte[iChannelNumberSize];

                br.BaseStream.Position = startPos;

                long iArray = (endPos - br.BaseStream.Position) / iChannelNumberSize;
                double[] fReturnArray = new double[iArray];
                for (int i = 0; i < iArray; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);
                    if (dhi.sDataVersion.StartsWith("3."))
                    {
                        b = ByteXORByte(b);
                    }

                    double fGL = (BitConverter.ToInt16(b, (iChannelNumber - 1) * 2)
                                                                                     /

                                                                                     dciL[iChannelNumber - 1].fScale + dciL[iChannelNumber - 1].fOffset);

                    fReturnArray[i] = fGL;
                }
                return fReturnArray;

            }
            catch (Exception ex)
            {
                return new double[1];
            }
        }

        #endregion

        #region 获取cit文件中的所有公里标

        /// <summary>
        /// 获取cit文件中的所有公里标---注意：是cit文件里的
        /// </summary>
        /// <param name="citFilePath">cit文件名</param>
        /// <returns>cit文件中的里程--单位为公里</returns>
        public float[] GetMilesDataFloat(String citFilePath)
        {
            float[] retVal = null;

            DataHeadInfo m_dhi = GetDataInfoHead(citFilePath);
            dhi = m_dhi;
            try
            {
                FileStream fs = new FileStream(citFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs, Encoding.Default);
                br.BaseStream.Position = 0;
                br.ReadBytes(DataOffset.DataHeadLength);
                br.ReadBytes(DataOffset.DataChannelLength * m_dhi.iChannelNumber);
                br.ReadBytes(BitConverter.ToInt32(br.ReadBytes(DataOffset.ExtraLength), 0));
                int iChannelNumberSize = m_dhi.iChannelNumber * 2;
                byte[] b = new byte[iChannelNumberSize];
                long iArray = (br.BaseStream.Length - br.BaseStream.Position) / iChannelNumberSize;
                retVal = new float[iArray];
                for (int i = 0; i < iArray; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);
                    if (m_dhi.sDataVersion.StartsWith("3."))
                    {
                        b = ByteXORByte(b);
                    }

                    short km = BitConverter.ToInt16(b, 0);

                    short m = BitConverter.ToInt16(b, 2);
                    float fGL = km + (float)m / m_dhi.iSmaleRate / 1000;//单位为公里

                    retVal[i] = fGL;
                }


                br.Close();
                fs.Close();

            }
            catch (Exception ex)
            {

            }

            return retVal;
        }

        /// <summary>
        /// 获取cit文件中的所有公里标---注意：是cit文件里的
        /// </summary>
        /// <param name="citFilePath">cit文件名</param>
        /// <returns>cit文件中的里程--单位为公里</returns>
        public double[] GetMilesData(String citFilePath)
        {
            double[] retVal = null;

            DataHeadInfo m_dhi = GetDataInfoHead(citFilePath);
            dhi = m_dhi;

            FileStream fs = new FileStream(citFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(fs, Encoding.Default);
            br.BaseStream.Position = 0;
            br.ReadBytes(DataOffset.DataHeadLength);
            br.ReadBytes(DataOffset.DataChannelLength * m_dhi.iChannelNumber);
            br.ReadBytes(BitConverter.ToInt32(br.ReadBytes(DataOffset.ExtraLength), 0));
            int iChannelNumberSize = m_dhi.iChannelNumber * 2;
            byte[] b = new byte[iChannelNumberSize];
            long iArray = (br.BaseStream.Length - br.BaseStream.Position) / iChannelNumberSize;
            retVal = new double[iArray];
            for (int i = 0; i < iArray; i++)
            {
                b = br.ReadBytes(iChannelNumberSize);
                if (m_dhi.sDataVersion.StartsWith("3."))
                {
                    b = ByteXORByte(b);
                }

                short km = BitConverter.ToInt16(b, 0);

                short m = BitConverter.ToInt16(b, 2);
                float fGL = km + (float)m / m_dhi.iSmaleRate / 1000;//单位为公里

                retVal[i] = fGL;
            }


            br.Close();
            fs.Close();

            return retVal;
        }

        /// <summary>
        /// 根据指定的二进制流和开始位置、结束位置获取公里数据
        /// </summary>
        /// <param name="br"></param>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns>公里数据</returns>
        public double[] GetMilesData(BinaryReader br, long startPos, long endPos)
        {
            double[] retVal = null;
            try
            {
                int iChannelNumberSize = dhi.iChannelNumber * 2;
                byte[] b = new byte[iChannelNumberSize];

                br.BaseStream.Position = startPos;

                long iArray = (endPos - startPos) / iChannelNumberSize;
                retVal = new double[iArray];
                for (int i = 0; i < iArray; i++)
                {
                    b = br.ReadBytes(iChannelNumberSize);
                    if (dhi.sDataVersion.StartsWith("3."))
                    {
                        b = ByteXORByte(b);
                    }

                    short km = BitConverter.ToInt16(b, 0);
                    short m = BitConverter.ToInt16(b, 2);

                    //单位为公里
                    float fGL = km + (float)m / 1000;

                    retVal[i] = fGL;
                }

            }
            catch (Exception ex)
            {
                return new double[1];
            }

            return retVal;
        }

        #endregion

        #endregion

        #region 针对通道数据的解密算法
        /// <summary>
        /// 针对通道数据的解密算法
        /// </summary>
        /// <param name="b">通道原数据</param>
        /// <returns>解密之后的通道数据</returns>
        public static byte[] ByteXORByte(byte[] b)
        {
            for (int iIndex = 0; iIndex < b.Length; iIndex++)
            {
                b[iIndex] = (byte)(b[iIndex] ^ 128);
            }
            return b;
        }
        #endregion
    }
}
