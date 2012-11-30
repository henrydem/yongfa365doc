using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Runtime.InteropServices;


class UnCodebase
{
    public Bitmap BmpObj, BmpSource;

    public UnCodebase(Bitmap pic)
    {
        BmpObj = new Bitmap(pic);    //转换为Format32bppRgb
    }
    public UnCodebase(string url)
    {
        var request = WebRequest.Create(url);
        using (var response = request.GetResponse())
        {
            using (var stream = response.GetResponseStream())
            {
                BmpSource = new Bitmap(stream, true);
                BmpObj = new Bitmap(BmpSource);
            }
        }
    }

    /// <summary>
    /// 根据RGB，计算灰度值
    /// </summary>
    /// <param name="posClr">Color值</param>
    /// <returns>灰度值，整型</returns>
    private int GetGrayNumColor(System.Drawing.Color posClr)
    {
        return (posClr.R * 19595 + posClr.G * 38469 + posClr.B * 7472) >> 16;
    }


    /// <summary>
    /// 灰度转换,逐点方式
    /// </summary>
    public void GrayByPixels()
    {
        for (int i = 0; i < BmpObj.Height; i++)
        {
            for (int j = 0; j < BmpObj.Width; j++)
            {
                int tmpValue = GetGrayNumColor(BmpObj.GetPixel(j, i));
                BmpObj.SetPixel(j, i, Color.FromArgb(tmpValue, tmpValue, tmpValue));
            }
        }
    }


    /// <summary>
    /// 去图形边框
    /// </summary>
    /// <param name="borderWidth"></param>
    public void ClearPicBorder(int borderWidth)
    {
        for (int i = 0; i < BmpObj.Height; i++)
        {
            for (int j = 0; j < BmpObj.Width; j++)
            {
                if (i < borderWidth || j < borderWidth || j > BmpObj.Width - 1 - borderWidth || i > BmpObj.Height - 1 - borderWidth)
                    BmpObj.SetPixel(j, i, Color.FromArgb(255, 255, 255));
            }
        }
    }


    /// <summary>
    /// 灰度转换,逐行方式
    /// </summary>
    public void GrayByLine()
    {
        Rectangle rec = new Rectangle(0, 0, BmpObj.Width, BmpObj.Height);
        BitmapData bmpData = BmpObj.LockBits(rec, ImageLockMode.ReadWrite, BmpObj.PixelFormat);// PixelFormat.Format32bppPArgb);
        //    bmpData.PixelFormat = PixelFormat.Format24bppRgb;
        IntPtr scan0 = bmpData.Scan0;
        int len = BmpObj.Width * BmpObj.Height;
        int[] pixels = new int[len];
        Marshal.Copy(scan0, pixels, 0, len);

        //对图片进行处理
        int GrayValue = 0;
        for (int i = 0; i < len; i++)
        {
            GrayValue = GetGrayNumColor(Color.FromArgb(pixels[i]));
            pixels[i] = (byte)(Color.FromArgb(GrayValue, GrayValue, GrayValue)).ToArgb();      //Color转byte
        }

        BmpObj.UnlockBits(bmpData);
    }


    /// <summary>
    /// 得到有效图形并调整为可平均分割的大小
    /// </summary>
    /// <param name="dgGrayValue">灰度背景分界值</param>
    /// <param name="CharsCount">有效字符数</param>
    /// <returns></returns>
    public void GetPicValidByValue(int dgGrayValue, int CharsCount)
    {
        int posx1 = BmpObj.Width; int posy1 = BmpObj.Height;
        int posx2 = 0; int posy2 = 0;
        for (int i = 0; i < BmpObj.Height; i++)      //找有效区
        {
            for (int j = 0; j < BmpObj.Width; j++)
            {
                int pixelValue = BmpObj.GetPixel(j, i).R;
                if (pixelValue < dgGrayValue)     //根据灰度值
                {
                    if (posx1 > j) posx1 = j;
                    if (posy1 > i) posy1 = i;

                    if (posx2 < j) posx2 = j;
                    if (posy2 < i) posy2 = i;
                };
            };
        };
        // 确保能整除
        int Span = CharsCount - (posx2 - posx1 + 1) % CharsCount;   //可整除的差额数
        if (Span < CharsCount)
        {
            int leftSpan = Span / 2;    //分配到左边的空列 ，如span为单数,则右边比左边大1
            if (posx1 > leftSpan)
                posx1 = posx1 - leftSpan;
            if (posx2 + Span - leftSpan < BmpObj.Width)
                posx2 = posx2 + Span - leftSpan;
        }
        //复制新图
        Rectangle cloneRect = new Rectangle(posx1, posy1, posx2 - posx1 + 1, posy2 - posy1 + 1);
        BmpObj = BmpObj.Clone(cloneRect, BmpObj.PixelFormat);
    }


    /// <summary>
    /// 得到有效图形,图形为类变量
    /// </summary>
    /// <param name="dgGrayValue">灰度背景分界值</param>
    /// <param name="CharsCount">有效字符数</param>
    /// <returns></returns>
    public void GetPicValidByValue(int dgGrayValue)
    {
        int posx1 = BmpObj.Width; int posy1 = BmpObj.Height;
        int posx2 = 0; int posy2 = 0;
        for (int i = 0; i < BmpObj.Height; i++)      //找有效区
        {
            for (int j = 0; j < BmpObj.Width; j++)
            {
                int pixelValue = BmpObj.GetPixel(j, i).R;
                if (pixelValue < dgGrayValue)     //根据灰度值
                {
                    if (posx1 > j) posx1 = j;
                    if (posy1 > i) posy1 = i;

                    if (posx2 < j) posx2 = j;
                    if (posy2 < i) posy2 = i;
                };
            };
        };
        //复制新图
        Rectangle cloneRect = new Rectangle(posx1, posy1, posx2 - posx1 + 1, posy2 - posy1 + 1);
        BmpObj = BmpObj.Clone(cloneRect, BmpObj.PixelFormat);
    }


    /// <summary>
    /// 得到有效图形,图形由外面传入
    /// </summary>
    /// <param name="dgGrayValue">灰度背景分界值</param>
    /// <param name="CharsCount">有效字符数</param>
    /// <returns></returns>
    public Bitmap GetPicValidByValue(Bitmap singlepic, int dgGrayValue)
    {
        int posx1 = singlepic.Width; int posy1 = singlepic.Height;
        int posx2 = 0; int posy2 = 0;
        for (int i = 0; i < singlepic.Height; i++)      //找有效区
        {
            for (int j = 0; j < singlepic.Width; j++)
            {
                int pixelValue = singlepic.GetPixel(j, i).R;
                if (pixelValue < dgGrayValue)     //根据灰度值
                {
                    if (posx1 > j) posx1 = j;
                    if (posy1 > i) posy1 = i;

                    if (posx2 < j) posx2 = j;
                    if (posy2 < i) posy2 = i;
                };
            };
        };
        //复制新图
        Rectangle cloneRect = new Rectangle(posx1, posy1, posx2 - posx1 + 1, posy2 - posy1 + 1);
        return singlepic.Clone(cloneRect, singlepic.PixelFormat);
    }


    /// <summary>
    /// 平均分割图片
    /// </summary>
    /// <param name="RowNum">水平上分割数</param>
    /// <param name="ColNum">垂直上分割数</param>
    /// <returns>分割好的图片数组</returns>
    public Bitmap[] GetSplitPics(int RowNum, int ColNum)
    {
        if (RowNum == 0 || ColNum == 0)
            return null;
        int singW = BmpObj.Width / RowNum;
        int singH = BmpObj.Height / ColNum;
        Bitmap[] PicArray = new Bitmap[RowNum * ColNum];

        Rectangle cloneRect;
        for (int i = 0; i < ColNum; i++)      //找有效区
        {
            for (int j = 0; j < RowNum; j++)
            {
                cloneRect = new Rectangle(j * singW, i * singH, singW, singH);
                PicArray[i * RowNum + j] = BmpObj.Clone(cloneRect, BmpObj.PixelFormat);//复制小块图
            }
        }
        return PicArray;
    }


    /// <summary>
    /// 返回灰度图片的点阵描述字串，1表示灰点，0表示背景
    /// </summary>
    /// <param name="singlepic">灰度图</param>
    /// <param name="dgGrayValue">背前景灰色界限</param>
    /// <returns></returns>
    public string GetSingleBmpCode(Bitmap singlepic, int dgGrayValue)
    {
        Color piexl;
        string code = "";
        for (int posy = 0; posy < singlepic.Height; posy++)
            for (int posx = 0; posx < singlepic.Width; posx++)
            {
                piexl = singlepic.GetPixel(posx, posy);
                if (piexl.R < dgGrayValue)    // Color.Black )
                    code = code + "1";
                else
                    code = code + "0";
            }
        return code;
    }
}
