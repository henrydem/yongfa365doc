﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;


namespace SilverlightDB
{
    public partial class SilverlightDB
    {
        private static List<Country> _ALLCountry;
        public static List<Country> ALLCountry
        {
            get
            {
                if (_ALLCountry != null)
                {
                    return _ALLCountry;
                }

                var lst = _ALLCountry=new List<Country>();
                lst.Add(new Country { CountryID = 1, CountryName = "中國", CountryEnglishName = "China" });
                lst.Add(new Country { CountryID = 2, CountryName = "馬來西亞", CountryEnglishName = "Malaysia" });
                lst.Add(new Country { CountryID = 3, CountryName = "新加坡", CountryEnglishName = "Singapore" });
                lst.Add(new Country { CountryID = 4, CountryName = "泰國", CountryEnglishName = "Thailand" });
                lst.Add(new Country { CountryID = 5, CountryName = "阿爾巴尼亞", CountryEnglishName = "Albania " });
                lst.Add(new Country { CountryID = 6, CountryName = "阿爾及利亞", CountryEnglishName = "Algeria" });
                lst.Add(new Country { CountryID = 7, CountryName = "阿富汗", CountryEnglishName = "Afghanistan" });
                lst.Add(new Country { CountryID = 8, CountryName = "阿根廷", CountryEnglishName = "Argentina" });
                lst.Add(new Country { CountryID = 9, CountryName = "阿聯酋", CountryEnglishName = "United Arab Emirates" });
                lst.Add(new Country { CountryID = 10, CountryName = "埃及", CountryEnglishName = "Egypt" });
                lst.Add(new Country { CountryID = 11, CountryName = "埃塞俄比亞", CountryEnglishName = "Ethiopia" });
                lst.Add(new Country { CountryID = 12, CountryName = "愛爾蘭", CountryEnglishName = "Ireland" });
                lst.Add(new Country { CountryID = 13, CountryName = "安哥拉", CountryEnglishName = "Angola" });
                lst.Add(new Country { CountryID = 14, CountryName = "奧地利", CountryEnglishName = "Austria" });
                lst.Add(new Country { CountryID = 15, CountryName = "澳大利亞", CountryEnglishName = "Australia" });
                lst.Add(new Country { CountryID = 17, CountryName = "巴基斯坦", CountryEnglishName = "Pakistan" });
                lst.Add(new Country { CountryID = 18, CountryName = "巴拿馬", CountryEnglishName = "Panama" });
                lst.Add(new Country { CountryID = 19, CountryName = "巴西", CountryEnglishName = "Brazil" });
                lst.Add(new Country { CountryID = 20, CountryName = "保加利亞", CountryEnglishName = "Bulgaria" });
                lst.Add(new Country { CountryID = 21, CountryName = "比利時", CountryEnglishName = "Belgium" });
                lst.Add(new Country { CountryID = 22, CountryName = "冰島", CountryEnglishName = "Iceland" });
                lst.Add(new Country { CountryID = 23, CountryName = "波蘭", CountryEnglishName = "Poland" });
                lst.Add(new Country { CountryID = 24, CountryName = "玻利維亞", CountryEnglishName = "Bolivia" });
                lst.Add(new Country { CountryID = 25, CountryName = "布隆迪", CountryEnglishName = "Burundi" });
                lst.Add(new Country { CountryID = 26, CountryName = "朝鮮", CountryEnglishName = "Korea" });
                lst.Add(new Country { CountryID = 27, CountryName = "丹麥", CountryEnglishName = "Denmark" });
                lst.Add(new Country { CountryID = 28, CountryName = "德國", CountryEnglishName = "Germany" });
                lst.Add(new Country { CountryID = 29, CountryName = "多米尼加", CountryEnglishName = "Dominica" });
                lst.Add(new Country { CountryID = 30, CountryName = "俄羅斯", CountryEnglishName = "Rassia" });
                lst.Add(new Country { CountryID = 31, CountryName = "法國", CountryEnglishName = "France" });
                lst.Add(new Country { CountryID = 32, CountryName = "菲律賓", CountryEnglishName = "Philippines" });
                lst.Add(new Country { CountryID = 33, CountryName = "斐濟", CountryEnglishName = "Fiji" });
                lst.Add(new Country { CountryID = 34, CountryName = "芬蘭", CountryEnglishName = "Finland" });
                lst.Add(new Country { CountryID = 35, CountryName = "岡比亞", CountryEnglishName = "Gambia" });
                lst.Add(new Country { CountryID = 36, CountryName = "剛果（金）", CountryEnglishName = "Congo" });
                lst.Add(new Country { CountryID = 37, CountryName = "哥倫比亞", CountryEnglishName = "Colombia" });
                lst.Add(new Country { CountryID = 38, CountryName = "哥斯達黎加", CountryEnglishName = "Costa Rica" });
                lst.Add(new Country { CountryID = 39, CountryName = "古巴", CountryEnglishName = "Cuba" });
                lst.Add(new Country { CountryID = 40, CountryName = "圭亞那", CountryEnglishName = "Guyana " });
                lst.Add(new Country { CountryID = 41, CountryName = "海地", CountryEnglishName = "Haiti" });
                lst.Add(new Country { CountryID = 42, CountryName = "韓國", CountryEnglishName = "South Korea" });
                lst.Add(new Country { CountryID = 43, CountryName = "荷蘭", CountryEnglishName = "Netherlands" });
                lst.Add(new Country { CountryID = 44, CountryName = "洪都拉斯", CountryEnglishName = "Honduras" });
                lst.Add(new Country { CountryID = 45, CountryName = "吉布提", CountryEnglishName = "Djibouti JIB Djibouti (Republic) " });
                lst.Add(new Country { CountryID = 46, CountryName = "幾內亞", CountryEnglishName = "Guinea" });
                lst.Add(new Country { CountryID = 47, CountryName = "加拿大", CountryEnglishName = "Canada" });
                lst.Add(new Country { CountryID = 48, CountryName = "加納", CountryEnglishName = "Ghana" });
                lst.Add(new Country { CountryID = 49, CountryName = "加蓬", CountryEnglishName = "Gabon" });
                lst.Add(new Country { CountryID = 50, CountryName = "柬埔寨", CountryEnglishName = "Cambodia" });
                lst.Add(new Country { CountryID = 51, CountryName = "津巴布韋", CountryEnglishName = "Zimbabwe " });
                lst.Add(new Country { CountryID = 52, CountryName = "喀麥隆", CountryEnglishName = "Cameroon " });
                lst.Add(new Country { CountryID = 53, CountryName = "科威特", CountryEnglishName = "Kuwait" });
                lst.Add(new Country { CountryID = 54, CountryName = "肯尼亞", CountryEnglishName = "Kenya" });
                lst.Add(new Country { CountryID = 55, CountryName = "老撾", CountryEnglishName = "Laos" });
                lst.Add(new Country { CountryID = 56, CountryName = "黎巴嫩", CountryEnglishName = "Lebanon" });
                lst.Add(new Country { CountryID = 57, CountryName = "立陶宛", CountryEnglishName = "Lithuania" });
                lst.Add(new Country { CountryID = 59, CountryName = "利比里亞", CountryEnglishName = "Liberia" });
                lst.Add(new Country { CountryID = 60, CountryName = "利比亞", CountryEnglishName = "Libya" });
                lst.Add(new Country { CountryID = 61, CountryName = "盧森堡", CountryEnglishName = "Luxemburg" });
                lst.Add(new Country { CountryID = 62, CountryName = "盧旺達", CountryEnglishName = "Rwanda" });
                lst.Add(new Country { CountryID = 63, CountryName = "羅馬尼亞", CountryEnglishName = "Romania" });
                lst.Add(new Country { CountryID = 64, CountryName = "毛里求斯", CountryEnglishName = "Mauritius" });
                lst.Add(new Country { CountryID = 65, CountryName = "毛里塔尼亞", CountryEnglishName = "Mauritania" });
                lst.Add(new Country { CountryID = 66, CountryName = "美國", CountryEnglishName = "United States" });
                lst.Add(new Country { CountryID = 67, CountryName = "蒙古", CountryEnglishName = "Mongolia" });
                lst.Add(new Country { CountryID = 68, CountryName = "孟加拉國", CountryEnglishName = "Bangladesh" });
                lst.Add(new Country { CountryID = 69, CountryName = "秘魯", CountryEnglishName = "Peru" });
                lst.Add(new Country { CountryID = 70, CountryName = "緬甸", CountryEnglishName = "Myanmar" });
                lst.Add(new Country { CountryID = 71, CountryName = "摩洛哥", CountryEnglishName = "Morocco" });
                lst.Add(new Country { CountryID = 72, CountryName = "墨西哥", CountryEnglishName = "Mexico" });
                lst.Add(new Country { CountryID = 73, CountryName = "南非", CountryEnglishName = "South Africa" });
                lst.Add(new Country { CountryID = 74, CountryName = "尼泊爾", CountryEnglishName = "Nepal" });
                lst.Add(new Country { CountryID = 75, CountryName = "尼日利亞", CountryEnglishName = "Nigeria" });
                lst.Add(new Country { CountryID = 76, CountryName = "挪威", CountryEnglishName = "Norway" });
                lst.Add(new Country { CountryID = 77, CountryName = "葡萄牙", CountryEnglishName = "Portugal" });
                lst.Add(new Country { CountryID = 78, CountryName = "日本", CountryEnglishName = "Japan" });
                lst.Add(new Country { CountryID = 79, CountryName = "瑞典", CountryEnglishName = "Sweden" });
                lst.Add(new Country { CountryID = 80, CountryName = "瑞士", CountryEnglishName = "Switzerland" });
                lst.Add(new Country { CountryID = 81, CountryName = "塞浦路斯", CountryEnglishName = "Cyprus " });
                lst.Add(new Country { CountryID = 82, CountryName = "沙特阿拉伯", CountryEnglishName = "Saudi Arabia" });
                lst.Add(new Country { CountryID = 83, CountryName = "斯里蘭卡", CountryEnglishName = "SriLanka" });
                lst.Add(new Country { CountryID = 84, CountryName = "斯洛文尼亞", CountryEnglishName = "Slovenia " });
                lst.Add(new Country { CountryID = 85, CountryName = "蘇丹", CountryEnglishName = "Sudan" });
                lst.Add(new Country { CountryID = 87, CountryName = "坦桑尼亞", CountryEnglishName = "Tanzania" });
                lst.Add(new Country { CountryID = 88, CountryName = "突尼斯", CountryEnglishName = "Tunisia" });
                lst.Add(new Country { CountryID = 89, CountryName = "土耳其", CountryEnglishName = "Turkey" });
                lst.Add(new Country { CountryID = 90, CountryName = "危地馬拉", CountryEnglishName = "Guatemala " });
                lst.Add(new Country { CountryID = 91, CountryName = "委內瑞拉", CountryEnglishName = "Venezuela " });
                lst.Add(new Country { CountryID = 92, CountryName = "文萊", CountryEnglishName = "Brunei" });
                lst.Add(new Country { CountryID = 93, CountryName = "烏干達", CountryEnglishName = "Uganda" });
                lst.Add(new Country { CountryID = 94, CountryName = "烏拉圭", CountryEnglishName = "Uruguay" });
                lst.Add(new Country { CountryID = 95, CountryName = "西班牙", CountryEnglishName = "Spain" });
                lst.Add(new Country { CountryID = 96, CountryName = "希臘", CountryEnglishName = "Greece" });
                lst.Add(new Country { CountryID = 98, CountryName = "新西蘭", CountryEnglishName = "New Zealand" });
                lst.Add(new Country { CountryID = 99, CountryName = "匈牙利", CountryEnglishName = "Hungary" });
                lst.Add(new Country { CountryID = 100, CountryName = "敘利亞", CountryEnglishName = "Syria" });
                lst.Add(new Country { CountryID = 101, CountryName = "牙買加", CountryEnglishName = "Jamaica" });
                lst.Add(new Country { CountryID = 102, CountryName = "也門", CountryEnglishName = "Yemen" });
                lst.Add(new Country { CountryID = 103, CountryName = "伊拉克", CountryEnglishName = "Iraq" });
                lst.Add(new Country { CountryID = 104, CountryName = "伊朗", CountryEnglishName = "Iran" });
                lst.Add(new Country { CountryID = 105, CountryName = "以色列", CountryEnglishName = "Israel" });
                lst.Add(new Country { CountryID = 106, CountryName = "意大利", CountryEnglishName = "Italy" });
                lst.Add(new Country { CountryID = 107, CountryName = "印度", CountryEnglishName = "India" });
                lst.Add(new Country { CountryID = 108, CountryName = "印度尼西亞", CountryEnglishName = "Indonesia" });
                lst.Add(new Country { CountryID = 109, CountryName = "英國", CountryEnglishName = "United Kingdom" });
                lst.Add(new Country { CountryID = 110, CountryName = "約旦", CountryEnglishName = "Jordan" });
                lst.Add(new Country { CountryID = 111, CountryName = "越南", CountryEnglishName = "Vietnam" });
                lst.Add(new Country { CountryID = 112, CountryName = "贊比亞", CountryEnglishName = "Zambia" });
                lst.Add(new Country { CountryID = 114, CountryName = "乍得", CountryEnglishName = "Chad" });
                lst.Add(new Country { CountryID = 115, CountryName = "智利", CountryEnglishName = "Chile" });
                lst.Add(new Country { CountryID = 116, CountryName = "南斯拉夫", CountryEnglishName = "Yugoslavia" });
                lst.Add(new Country { CountryID = 118, CountryName = "巴林", CountryEnglishName = "Bahrain" });
                lst.Add(new Country { CountryID = 119, CountryName = "烏克蘭", CountryEnglishName = "Ukraine" });
                lst.Add(new Country { CountryID = 143, CountryName = "吉爾吉斯斯坦", CountryEnglishName = "Kyrghystan" });
                lst.Add(new Country { CountryID = 144, CountryName = "烏茲別克斯坦", CountryEnglishName = "Uzbekistan" });
                lst.Add(new Country { CountryID = 145, CountryName = "阿塞拜疆", CountryEnglishName = "Azerbaijian" });
                lst.Add(new Country { CountryID = 146, CountryName = "馬爾代夫", CountryEnglishName = "Maldives" });
                lst.Add(new Country { CountryID = 147, CountryName = "巴拉圭", CountryEnglishName = "Paraguay" });
                lst.Add(new Country { CountryID = 150, CountryName = "阿曼", CountryEnglishName = "Oman" });
                lst.Add(new Country { CountryID = 151, CountryName = "白俄羅斯", CountryEnglishName = "Belarus" });
                lst.Add(new Country { CountryID = 152, CountryName = "博茨瓦納", CountryEnglishName = "Botswana" });
                lst.Add(new Country { CountryID = 153, CountryName = "巴布亞新幾內亞", CountryEnglishName = "Papua New Guinea" });
                lst.Add(new Country { CountryID = 155, CountryName = "厄瓜多爾", CountryEnglishName = "Ecuador" });
                lst.Add(new Country { CountryID = 156, CountryName = "塞內加爾", CountryEnglishName = "Senegal" });
                lst.Add(new Country { CountryID = 157, CountryName = "莫桑比克", CountryEnglishName = "Mozambique" });
                lst.Add(new Country { CountryID = 158, CountryName = "尼日爾", CountryEnglishName = "Niger" });
                lst.Add(new Country { CountryID = 159, CountryName = "納米比亞", CountryEnglishName = "Namibia" });
                lst.Add(new Country { CountryID = 160, CountryName = "湯加", CountryEnglishName = "Tonga" });
                lst.Add(new Country { CountryID = 161, CountryName = "馬耳他", CountryEnglishName = "Malta" });
                lst.Add(new Country { CountryID = 162, CountryName = "捷克", CountryEnglishName = "Czech Republic" });
                lst.Add(new Country { CountryID = 163, CountryName = "卡塔爾", CountryEnglishName = "Qatar" });
                lst.Add(new Country { CountryID = 164, CountryName = "克羅地亞", CountryEnglishName = "Croatia" });
                lst.Add(new Country { CountryID = 166, CountryName = "愛沙尼亞", CountryEnglishName = "Estonia" });
                lst.Add(new Country { CountryID = 167, CountryName = "梵蒂岡", CountryEnglishName = "Vatican" });
                lst.Add(new Country { CountryID = 171, CountryName = "阿魯巴", CountryEnglishName = "Aruba" });
                lst.Add(new Country { CountryID = 174, CountryName = "塞舌爾", CountryEnglishName = "Seychelles" });
                lst.Add(new Country { CountryID = 175, CountryName = "亞美尼亞", CountryEnglishName = "ARMENIA" });
                lst.Add(new Country { CountryID = 176, CountryName = "哈薩克斯坦", CountryEnglishName = "Kazakhstan" });
                lst.Add(new Country { CountryID = 178, CountryName = "貝寧", CountryEnglishName = "BENIN" });
                lst.Add(new Country { CountryID = 179, CountryName = "科特迪瓦", CountryEnglishName = "Coted Ivoire" });
                lst.Add(new Country { CountryID = 180, CountryName = "格魯吉亞", CountryEnglishName = "GEORGIA" });
                lst.Add(new Country { CountryID = 181, CountryName = "蘇里南", CountryEnglishName = "SURINAME" });
                lst.Add(new Country { CountryID = 182, CountryName = "摩爾多瓦", CountryEnglishName = "Moldova" });
                lst.Add(new Country { CountryID = 183, CountryName = "塞爾維亞", CountryEnglishName = "Serbia" });
                lst.Add(new Country { CountryID = 184, CountryName = "厄立特里亞", CountryEnglishName = "ERITREA" });
                lst.Add(new Country { CountryID = 185, CountryName = "巴哈馬", CountryEnglishName = "Bahamas" });
                lst.Add(new Country { CountryID = 186, CountryName = "馬拉維", CountryEnglishName = "Malawi" });
                lst.Add(new Country { CountryID = 187, CountryName = "萊索托", CountryEnglishName = "Lesotho" });
                lst.Add(new Country { CountryID = 191, CountryName = "庫克群島", CountryEnglishName = "Cook Islands" });
                lst.Add(new Country { CountryID = 192, CountryName = "關島", CountryEnglishName = "Guam" });
                lst.Add(new Country { CountryID = 195, CountryName = "土庫曼斯坦", CountryEnglishName = "Turkmenstan" });
                lst.Add(new Country { CountryID = 196, CountryName = "斯威士蘭", CountryEnglishName = "SWAZILAND" });
                lst.Add(new Country { CountryID = 197, CountryName = "馬其頓共和國", CountryEnglishName = "Macedonia " });
                lst.Add(new Country { CountryID = 198, CountryName = "尼加拉瓜", CountryEnglishName = "NICARAGUA" });
                lst.Add(new Country { CountryID = 200, CountryName = "安道爾", CountryEnglishName = "Andorra" });
                lst.Add(new Country { CountryID = 201, CountryName = "安提瓜和巴布達", CountryEnglishName = "Antigua and barbuda" });
                lst.Add(new Country { CountryID = 202, CountryName = "巴巴多斯", CountryEnglishName = "Barbados" });
                lst.Add(new Country { CountryID = 205, CountryName = "巴勒斯坦", CountryEnglishName = "Palestine" });
                lst.Add(new Country { CountryID = 207, CountryName = "百慕大", CountryEnglishName = "Bermuda" });
                lst.Add(new Country { CountryID = 208, CountryName = "波多黎各", CountryEnglishName = "Puerto Rico" });
                lst.Add(new Country { CountryID = 209, CountryName = "波黑", CountryEnglishName = "Bosnia and Herzegovina" });
                lst.Add(new Country { CountryID = 210, CountryName = "伯利茲", CountryEnglishName = "Belize" });
                lst.Add(new Country { CountryID = 212, CountryName = "不丹", CountryEnglishName = "Bhutan" });
                lst.Add(new Country { CountryID = 213, CountryName = "布基納法索", CountryEnglishName = "Burkina Faso" });
                lst.Add(new Country { CountryID = 214, CountryName = "赤道幾內亞", CountryEnglishName = "Equatorial Guinea" });
                lst.Add(new Country { CountryID = 215, CountryName = "東帝汶", CountryEnglishName = "East Timor" });
                lst.Add(new Country { CountryID = 216, CountryName = "多哥", CountryEnglishName = "Togo" });
                lst.Add(new Country { CountryID = 217, CountryName = "多米尼克", CountryEnglishName = "Dominica" });
                lst.Add(new Country { CountryID = 219, CountryName = "佛得角", CountryEnglishName = "Cape Verde" });
                lst.Add(new Country { CountryID = 220, CountryName = "格林納達", CountryEnglishName = "Grenada" });
                lst.Add(new Country { CountryID = 221, CountryName = "基里巴斯", CountryEnglishName = "Kiribati" });
                lst.Add(new Country { CountryID = 222, CountryName = "幾內亞比紹", CountryEnglishName = "Guinea-bissau" });
                lst.Add(new Country { CountryID = 223, CountryName = "開曼群島", CountryEnglishName = "Cayman Islands" });
                lst.Add(new Country { CountryID = 224, CountryName = "科摩羅", CountryEnglishName = "Comoros" });
                lst.Add(new Country { CountryID = 225, CountryName = "拉脫維亞", CountryEnglishName = "Latvia" });
                lst.Add(new Country { CountryID = 226, CountryName = "列支敦士登", CountryEnglishName = "Liechtenstein" });
                lst.Add(new Country { CountryID = 227, CountryName = "馬達加斯加", CountryEnglishName = "Madagascar" });
                lst.Add(new Country { CountryID = 228, CountryName = "馬里", CountryEnglishName = "Mali" });
                lst.Add(new Country { CountryID = 229, CountryName = "馬紹爾群島", CountryEnglishName = "Marshall Islands" });
                lst.Add(new Country { CountryID = 230, CountryName = "密克羅尼西亞", CountryEnglishName = "Micronesia" });
                lst.Add(new Country { CountryID = 231, CountryName = "摩納哥", CountryEnglishName = "Monaco" });
                lst.Add(new Country { CountryID = 233, CountryName = "納米尼亞", CountryEnglishName = "Namibia" });
                lst.Add(new Country { CountryID = 234, CountryName = "瑙魯", CountryEnglishName = "Nauru" });
                lst.Add(new Country { CountryID = 236, CountryName = "紐埃（新西蘭屬）", CountryEnglishName = "Niue" });
                lst.Add(new Country { CountryID = 237, CountryName = "帕勞", CountryEnglishName = "Palau" });
                lst.Add(new Country { CountryID = 238, CountryName = "薩爾瓦多", CountryEnglishName = "El Salvador" });
                lst.Add(new Country { CountryID = 239, CountryName = "美屬薩摩亞", CountryEnglishName = "Samoa" });
                lst.Add(new Country { CountryID = 240, CountryName = "塞拉利昂", CountryEnglishName = "Sierra Leone" });
                lst.Add(new Country { CountryID = 242, CountryName = "圣多美和普林西比", CountryEnglishName = "Sao Tome and Principe" });
                lst.Add(new Country { CountryID = 243, CountryName = "圣基茨和尼維斯", CountryEnglishName = "Saint Kitts and Nevis" });
                lst.Add(new Country { CountryID = 244, CountryName = "圣盧西亞", CountryEnglishName = "Saint Lucia" });
                lst.Add(new Country { CountryID = 245, CountryName = "圣馬力諾", CountryEnglishName = "San Marino" });
                lst.Add(new Country { CountryID = 246, CountryName = "圣文森特和格林納丁斯", CountryEnglishName = "Saint Vincent and the Grenadines" });
                lst.Add(new Country { CountryID = 247, CountryName = "斯洛伐克", CountryEnglishName = "Slovakia" });
                lst.Add(new Country { CountryID = 248, CountryName = "所羅門群島", CountryEnglishName = "Solomon Islands" });
                lst.Add(new Country { CountryID = 249, CountryName = "索馬里", CountryEnglishName = "Somalia" });
                lst.Add(new Country { CountryID = 250, CountryName = "塔吉克斯坦", CountryEnglishName = "Tajikistan" });
                lst.Add(new Country { CountryID = 252, CountryName = "特立尼達和多巴哥", CountryEnglishName = "Trinidad and Tobago" });
                lst.Add(new Country { CountryID = 253, CountryName = "圖瓦盧", CountryEnglishName = "Tuvalu" });
                lst.Add(new Country { CountryID = 254, CountryName = "瓦努阿圖", CountryEnglishName = "Vanuatu" });
                lst.Add(new Country { CountryID = 256, CountryName = "中非", CountryEnglishName = "Central Africa Republic" });
                lst.Add(new Country { CountryID = 257, CountryName = "黑山", CountryEnglishName = "Montenegro" });
                lst.Add(new Country { CountryID = 259, CountryName = "荷屬安第列斯", CountryEnglishName = "Netherlands Antilles" });
                lst.Add(new Country { CountryID = 260, CountryName = "文萊達魯薩蘭國", CountryEnglishName = "Brunei Darussalam" });
                lst.Add(new Country { CountryID = 261, CountryName = "瓜德羅普島", CountryEnglishName = "Guadeloupe" });
                lst.Add(new Country { CountryID = 262, CountryName = "北馬里亞納群島", CountryEnglishName = "Northern Mariana Island" });
                lst.Add(new Country { CountryID = 263, CountryName = "新喀里多尼亞", CountryEnglishName = "New Caledonia" });
                lst.Add(new Country { CountryID = 264, CountryName = "玻利尼西亞", CountryEnglishName = "French Polynesia" });
                lst.Add(new Country { CountryID = 265, CountryName = "特克斯和凱科斯群島", CountryEnglishName = "Turks & Caicos Island" });

                return lst;
            }
        }
    }
}
