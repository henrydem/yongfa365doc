using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WordsMatching;


class UnCodeYongfa365 : UnCodebase
{
    //字符表 顺序为0..9,A..Z,a..z
    string[] CodeArray = new string[] {
"011110100001100001100001100001100001100001100001100001011110",//0
"00100111000010000100001000010000100001000010011111",//1
"011110100001000001000001000010000100001000010000100000111111",//2
"011110100001000001000001001110000001000001000001100001011110",//3
"000010000110001010001010010010100010111111000010000010000111",//4
"111111100000100000100000111110000001000001000001100001011110",//5
"001110010000100000100000101110110001100001100001100001011110",//6
"111111100001000010000010000100000100001000001000010000010000",//7
"011110100001100001100001011110100001100001100001100001011110",//8
"011110100001100001100001100011011101000001000001000010011100",//9
        };

    public UnCodeYongfa365(Bitmap pic)
        : base(pic)
    {
    }
    public UnCodeYongfa365(string url)
        : base(url)
    {
    }




    public Tuple<string, Bitmap[], List<string>> Get()
    {
        GrayByPixels(); //灰度处理
        GetPicValidByValue(128, 4); //得到有效空间
        Bitmap[] pics = GetSplitPics(4, 1);     //分割
        List<string> lst = new List<string>();
        if (pics.Length != 4)
        {
            return null; //分割错误
        }
        else  // 重新调整大小
        {
            pics[0] = GetPicValidByValue(pics[0], 128);
            pics[1] = GetPicValidByValue(pics[1], 128);
            pics[2] = GetPicValidByValue(pics[2], 128);
            pics[3] = GetPicValidByValue(pics[3], 128);
        }

        //http://www.codeproject.com/Articles/11157/An-improvement-on-capturing-similarity-between-str

        foreach (var item in pics)
        {
            lst.Add(GetSingleBmpCode(item, 128));
        }
        return new Tuple<string, Bitmap[], List<string>>(Calc(lst), pics, lst);


    }

    private string Calc(List<string> lst)
    {
        var str = "";
        foreach (var item in lst)
        {
            var dict2 = new Dictionary<int, float>();
            for (int i = 0; i < CodeArray.Length; i++)
            {
                var match = new MatchsMaker(item, CodeArray[i]);
                dict2.Add(i, match.Score);
            }

            var idx = dict2.First(p => p.Value == dict2.Max(x => x.Value)).Key;
            switch (idx)
            {
                case 10:
                    idx = 1;
                    break;
                case 11:
                case 12:
                    idx = 0;
                    break;
                default:
                    break;
            }

            str += idx;
        }
        return str;
    }


}

