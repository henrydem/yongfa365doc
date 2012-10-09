using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightExtensions
{

    public static class DataPagerExtension
    {
        /// <summary>
        /// 需要阻止PageIndexChanged，此方法要用到这个事件里
        /// </summary>
        /// <param name="dataPager"></param>
        /// <returns></returns>
        public static bool IsNeedStopPageIndexChanged(this DataPager dataPager)
        {
            if (dataPager.Tag != null)
            {
                return (bool)dataPager.Tag;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据itemCount获取新的PageIndex,因为可能存在新数据已经不存在此Index的情况
        /// </summary>
        /// <param name="dataPager"></param>
        /// <param name="itemCount"></param>
        /// <returns></returns>
        public static int GetNewPageIndex(this DataPager dataPager, int itemCount)
        {
            var newPageCount = Math.Max(1, (int)Math.Ceiling((double)(((double)itemCount) / ((double)dataPager.PageSize))));
            return Math.Max(0, Math.Min(newPageCount - 1, dataPager.PageIndex));
        }

        /// <summary>
        /// 绑定数据源，暂时没有理解SilverLight.DataPager分页方式的必要性，所以扩展一个，需要注意此扩展使用到了DataPager.Tag
        /// </summary>
        /// <param name="dataPager"></param>
        /// <param name="itemCount"></param>
        /// <param name="pageSize"></param>
        public static void BindSource(this DataPager dataPager, int itemCount)
        {

            var oldPageIndex = dataPager.PageIndex;
            var oldPageCount = dataPager.PageCount;
            var newPageCount = Math.Max(1, (int)Math.Ceiling((double)(((double)itemCount) / ((double)dataPager.PageSize))));

            //DataPager绑定数据了，新的分页总数没有变化，则不关注分页控件
            if (dataPager.Source != null && newPageCount == oldPageCount)
            {
                return;
            }

            //阻止绑定时触发PageIndexChanged;
            dataPager.Tag = true;

            var list = new List<int>(itemCount);
            for (int i = 0; i < itemCount; i++) list.Add(i);

            dataPager.Source = new PagedCollectionView(list);

            //换数据源了，PageIndex就得换，同时阻止触发PageIndexChanged;
            var newPageIndex = Math.Max(0, Math.Min(newPageCount - 1, oldPageIndex));
            dataPager.Tag = true;
            dataPager.PageIndex = newPageIndex;
            dataPager.Tag = null;

        }


    }
}
