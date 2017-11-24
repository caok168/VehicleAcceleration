using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    class CITDataProcess
{
    //文件头定义
    public class Header
	{
	    // 文件头中的各个域
	}
	
	// 通道定义
	public class ChannelDef
	{
	    // 通道定义中的各个域
	}
	
	//公里标
	public class WaveMeter
	{
	    public float mKm;
		public float mMeter;
		// cit文件中每个通道组，都是以km, m 两个通道开始
	    public long mFilePosition = 0;
		public float GetMeter()
		{
		    
		}
		public string GetMeterString()
		{
		    // 比如： "500.123"
		}
	}
	
	private class DataOffset
	{
	    // 文件头偏移位置
	    static int msHeaderOffset = 0;
		// 文件类型数据偏移位置
		static int msDataTypeOffset = 0;
		// 文件版本号数据偏移位置
		static int msDataVersionOffset = 4;
		// 线路代码数据偏移位置
		static int msTrackCodeOffset = 25;
		// 线路名数据偏移位置
		static int msTrackNameOffset = 30;
		// 行别数据偏移位置
		static int msDirOffset = 51;
		// 检测车号数据偏移位置
		static int msTrainCodeOffset = 55;
		// 检测日期数据偏移位置
		static int msDateOffset = 76;
		// 检测起始时间数据偏移位置
		static int msTimeOffset = 87;
		// 检测方向数据偏移位置
		static int msRunDirOffset = 96;
		// 增减里程数据偏移位置
		static int msKmIncOffset = 100;
		// 开始里程数据偏移位置
		static int msKmFromOffset = 104;
		// 结束里程数据偏移位置
		static int msKmToOffset = 108;
		// 采样频率数据偏移位置
		static int msSmaleRateOffset = 112;
		// 通道个数数据偏移位置
		static int msChannelNumberOffset = 116;
		// 通道定义数据偏移位置
		static int msChannelDefOffset = 120;
	}
	
	
	private int GetExtraInfoOffset()
	{
        // offset = 文件头（120字节） + 通道定义 （65 * channel number ）
	}
	
	private int GetDataOffset()
	{
	    // offset = 文件头（120字节） + 通道定义 （65 * channel number ） + 附加信息 （a信息长度（4字节）+ b信息本身（长度由a确定））
 	}
	
	public Header GetHeader(string citfile){}
	public bool WriteHeader(string citfile, Header h){}
	
	
	public int GetDataType(string citfile)
	{
	    // 打开文件
		// 设置文件流指针到数据对应的偏移位置
		// 解析数据
		// 关闭文件
		// 返回值
	}
	public bool WriteDataType(string citfile，int type){}
	
	public string GetDataVersion(string citfile){}
	public bool WriteDataVersion(string citfile, string version){}
	
	public string GetTrackCode(string citfile){}	
	public bool WriteTrackCode(string citfile, string code){}
	
	public string GetTrackName(string citfile){}	
	public bool WriteTrackName(string citfile,string name){}
	
	public int GetDir(string citfile){}	
	public bool WriteDir(string citfile, int dir){}
	
	public string GetTrainCode(string citfile){}	
	public bool WriteTrainCode(string citfile, string code){}
	
	public string GetDate(string citfile){}	
	public bool WriteDate(string citfile, string date){}
	
	public string GetTime(string citfile){}	
	public bool WriteTime(string citfile, string time){}
	
	public int GetRunDir(string citfile){}	
	public bool WriteRunDir(string citfile,int rundir){}
	
	public int GetKmInc(string citfile){}	
	public bool WriteKmInc(string citfile,int kminc){}
	
	public float GetKmFrom(string citfile){}	
	public bool GetKmFrom(string citfile, float kmfrom){}
	
	public float GetKmTo(string citfile){}	
	public bool WriteKmTo(string citfile, float kmto){}
	
	public int GetSmaleRate(string citfile){}	
	public bool WriteSmaleRate(string citfile, int rate){}
	
	// 通道数目可以获取，但是不能写入
	public int GetChannelNumber(string citfile){}
	
	
	// 获取所有channel的定义信息
	public List<ChannelDef> GetChannelDefs()
	{
	    // 这里要注意：通道id如果直接从文件中获取，可能得到错误的值（创建cit文件时可能写入错误的值）
		// 所以，channel id需要单独计数，计数从1开始，1，2，3，4......
	}
	
	// 获取附加信息，返回值是字节流，客户负责解析附加信息到具体的类型
	public byte[] GetExtraInfo(){}
	
	public int GetChannelId(string channelname, List<ChannelDef> channellist)
	{
	    // channelname:中文或者英文都可以
	}
	
	// 
	public string GetChannelNameEn(int id, List<ChannelDef> channellist){}
	public string GetChannelNameCh(int id, List<ChannelDef> channellist){}
	
	public float GetChannleScale(int id, List<ChannelDef> channellist){}
	public float GetChannelScale(string enname, List<ChannelDef> channellist)
	{
	    //enname 为英文名，代码中除了注释，尽量少出现中文字符 
	}
	
	public float GetChannelOffset(int id, List<ChannelDef> channellist){}
	public float GetChannelOffset(string enname, List<ChannelDef> channellist){}
	
	public float GetChannelUnit(int id, List<ChannelDef> channellist){}
	public float GetChannelUnit(string enname, List<ChannelDef> channellist){}
	
	// 得到文件中的里程信息
	public List<WaveMeter> GetWaveMeter(string file){}
	
	public WaveMeter GetStartWaveMeter(string file){}
	public WaveMeter GetEndWaveMeter(string file){}
	
	public double[] GetChannelDataInRange(string file, int channelid, long startpos, long endpos){}
	public double[] GetChannelDataInRange(string file, string channelenname, long startpos, long endpos){}
	
	public double[] GetChannelDataInRange(string file, int channelid, WaveMeter startmile, WaveMeter endmile){}
	public double[] GetChannelDataInRange(string file, string channelenname, WaveMeter startmile, WaveMeter endmile){}
	
	public double[] GetChannelData(string file, int channelid){}
	public double[] GetChannelData(string file, string channelenname){}
	
	public static byte[] ByteXORByte(byte[] b)
    {
            for (int iIndex = 0; iIndex < b.Length; iIndex++)
            {
                b[iIndex] = (byte)(b[iIndex] ^ 128);
            }
            return b;
    }
	
}














































































}
