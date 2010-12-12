using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.net.Demo
{
    public partial class RepeaterInRepeater : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            List<HotelFacilityEntity> list = new List<HotelFacilityEntity>() 
            {
                new HotelFacilityEntity(){ FacilityName="会议厅", FacilityTypeName="宾馆服务项目"},
                new HotelFacilityEntity(){ FacilityName="免费停车场", FacilityTypeName="宾馆服务项目"},
                new HotelFacilityEntity(){ FacilityName="前台贵重物品保险柜", FacilityTypeName="宾馆服务项目"},
                new HotelFacilityEntity(){ FacilityName="免费旅游交通图(可赠送)", FacilityTypeName="宾馆服务项目"},
                new HotelFacilityEntity(){ FacilityName="票务服务", FacilityTypeName="宾馆服务项目"},
                new HotelFacilityEntity(){ FacilityName="行李存放服务", FacilityTypeName="宾馆服务项目"},
                new HotelFacilityEntity(){ FacilityName="洗衣服务", FacilityTypeName="宾馆服务项目"},
                new HotelFacilityEntity(){ FacilityName="邮政服务", FacilityTypeName="宾馆服务项目"},
                new HotelFacilityEntity(){ FacilityName="叫醒服务", FacilityTypeName="宾馆服务项目"},


                new HotelFacilityEntity(){ FacilityName="中餐厅", FacilityTypeName="宾馆餐饮设施"},
                new HotelFacilityEntity(){ FacilityName="咖啡厅", FacilityTypeName="宾馆餐饮设施"},
                new HotelFacilityEntity(){ FacilityName="酒吧", FacilityTypeName="宾馆餐饮设施"},
                new HotelFacilityEntity(){ FacilityName="大堂吧", FacilityTypeName="宾馆餐饮设施"},
                new HotelFacilityEntity(){ FacilityName="限时送餐服务", FacilityTypeName="宾馆餐饮设施"},


                new HotelFacilityEntity(){ FacilityName="国内长途电话", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="国际长途电话", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="中央空调", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="浴室化妆放大镜", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="24小时热水", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="免费洗漱用品", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="浴衣", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="独立浴缸和淋浴", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="吹风机", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="拖鞋", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="独立写字台", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="电热水壶", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="咖啡壶/茶壶", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="迷你酒吧", FacilityTypeName="客房设施和服务"},
                new HotelFacilityEntity(){ FacilityName="小冰箱", FacilityTypeName="客房设施和服务"},
            };
            //酒店设备
            var facility = from f in list
                           group f by f.FacilityTypeName into d
                           select d;

            ;
            repOut.DataSource = facility;
            repOut.DataBind();
        }

        /// <summary>
        /// 外层Repeater绑定到，激发事件，绑定内部控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void repOut_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater repeater = e.Item.FindControl("repIn") as Repeater;
                var temp = e.Item.DataItem as IGrouping<String, HotelFacilityEntity>;
                var query = from c in temp
                            select c;
                repeater.DataSource = query.ToList();
                repeater.DataBind();
            }
        }



    }

    public class HotelFacilityEntity
    {
        public string FacilityName { get; set; }

        public string FacilityTypeName { get; set; }

    }
}