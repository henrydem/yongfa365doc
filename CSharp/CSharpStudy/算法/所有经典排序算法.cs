using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//from http://www.cnblogs.com/dreamof/archive/2009/05/05/1450058.html
namespace 算法
{
    class 所有经典排序算法
    {

    }

    //C#实现所有经典排序算法

    //选择排序
    class SelectionSorter
    {
        private int min;
        public void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }
                int t = arr[min];
                arr[min] = arr[i];
                arr[i] = t;
            }
        }
    }

    //冒泡排序

    class EbullitionSorter
    {
        public void Sort(int[] arr)
        {
            int i, j, temp;
            bool done = false;
            j = 1;
            while ((j < arr.Length) && (!done))//判断长度    
            {
                done = true;
                for (i = 0; i < arr.Length - j; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        done = false;
                        temp = arr[i];
                        arr[i] = arr[i + 1];//交换数据    
                        arr[i + 1] = temp;
                    }
                }
                j++;
            }
        }
    }

    //快速排序

    class QuickSorter
    {
        private void swap(ref int l, ref int r)
        {
            int temp = l;
            l = r;
            r = temp;
        }
        public void Sort(int[] list, int low, int high)
        {
            int pivot;//存储分支点    
            int l, r;
            int mid;
            if (high <= low)
                return;
            else if (high == low + 1)
            {
                if (list[low] > list[high])
                    swap(ref list[low], ref list[high]);
                return;
            }
            mid = (low + high) >> 1;
            pivot = list[mid];
            swap(ref list[low], ref list[mid]);
            l = low + 1;
            r = high;
            do
            {
                while (l <= r && list[l] < pivot)
                    l++;
                while (list[r] >= pivot)
                    r--;
                if (l < r)
                    swap(ref list[l], ref list[r]);
            } while (l < r);
            list[low] = list[r];
            list[r] = pivot;
            if (low + 1 < r)
                Sort(list, low, r - 1);
            if (r + 1 < high)
                Sort(list, r + 1, high);
        }
    }

    //插入排序 
    public class InsertionSorter
    {
        public void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int t = arr[i];
                int j = i;
                while ((j > 0) && (arr[j - 1] > t))
                {
                    arr[j] = arr[j - 1];//交换顺序    
                    --j;
                }
                arr[j] = t;
            }
        }
    }

    //希尔排序 

    public class ShellSorter
    {
        public void Sort(int[] arr)
        {
            int inc;
            for (inc = 1; inc <= arr.Length / 9; inc = 3 * inc + 1) ;
            for (; inc > 0; inc /= 3)
            {
                for (int i = inc + 1; i <= arr.Length; i += inc)
                {
                    int t = arr[i - 1];
                    int j = i;
                    while ((j > inc) && (arr[j - inc - 1] > t))
                    {
                        arr[j - 1] = arr[j - inc - 1];//交换数据    
                        j -= inc;
                    }
                    arr[j - 1] = t;
                }
            }
        }
    }

    public class 归并排序
    {
        /// <summary>
        /// 归并排序之归：归并排序入口
        /// </summary>
        /// <param name="data">无序的数组</param>
        /// <returns>有序数组</returns>
        /// <author>Lihua(www.zivsoft.com)</author>
        int[] Sort(int[] data)
        {
            //取数组中间下标
            int middle = data.Length / 2;
            //初始化临时数组let,right，并定义result作为最终有序数组
            int[] left = new int[middle], right = new int[middle], result = new int[data.Length];
            if (data.Length % 2 != 0)//若数组元素奇数个，重新初始化右临时数组
            {
                right = new int[middle + 1];
            }
            if (data.Length <= 1)//只剩下1 or 0个元数，返回，不排序
            {
                return data;
            }
            int i = 0, j = 0;
            foreach (int x in data)//开始排序
            {
                if (i < middle)//填充左数组
                {
                    left[i] = x;
                    i++;
                }
                else//填充右数组
                {
                    right[j] = x;
                    j++;
                }
            }
            left = Sort(left);//递归左数组
            right = Sort(right);//递归右数组
            result = Merge(left, right);//开始排序
            //this.Write(result);//输出排序,测试用(lihua debug)
            return result;
        }
        /// <summary>
        /// 归并排序之并:排序在这一步
        /// </summary>
        /// <param name="a">左数组</param>
        /// <param name="b">右数组</param>
        /// <returns>合并左右数组排序后返回</returns>
        int[] Merge(int[] a, int[] b)
        {
            //定义结果数组，用来存储最终结果
            int[] result = new int[a.Length + b.Length];
            int i = 0, j = 0, k = 0;
            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])//左数组中元素小于右数组中元素
                {
                    result[k++] = a[i++];//将小的那个放到结果数组
                }
                else//左数组中元素大于右数组中元素
                {
                    result[k++] = b[j++];//将小的那个放到结果数组
                }
            }
            while (i < a.Length)//这里其实是还有左元素，但没有右元素
            {
                result[k++] = a[i++];
            }
            while (j < b.Length)//右右元素，无左元素
            {
                result[k++] = b[j++];
            }
            return result;//返回结果数组
        }
    }


    public class 基数排序
    {
        //基数排序
        public int[] RadixSort(int[] ArrayToSort, int digit)
        {
            //low to high digit
            for (int k = 1; k <= digit; k++)
            {
                //temp array to store the sort result inside digit
                int[] tmpArray = new int[ArrayToSort.Length];
                //temp array for countingsort 
                int[] tmpCountingSortArray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                //CountingSort        
                for (int i = 0; i < ArrayToSort.Length; i++)
                {
                    //split the specified digit from the element 
                    int tmpSplitDigit = ArrayToSort[i] / (int)Math.Pow(10, k - 1) - (ArrayToSort[i] / (int)Math.Pow(10, k)) * 10;
                    tmpCountingSortArray[tmpSplitDigit] += 1;
                }
                for (int m = 1; m < 10; m++)
                {
                    tmpCountingSortArray[m] += tmpCountingSortArray[m - 1];
                }
                //output the value to result      
                for (int n = ArrayToSort.Length - 1; n >= 0; n--)
                {
                    int tmpSplitDigit = ArrayToSort[n] / (int)Math.Pow(10, k - 1) - (ArrayToSort[n] / (int)Math.Pow(10, k)) * 10;
                    tmpArray[tmpCountingSortArray[tmpSplitDigit] - 1] = ArrayToSort[n];
                    tmpCountingSortArray[tmpSplitDigit] -= 1;
                }
                //copy the digit-inside sort result to source array       
                for (int p = 0; p < ArrayToSort.Length; p++)
                {
                    ArrayToSort[p] = tmpArray[p];
                }
            }
            return ArrayToSort;
        }

    }

    public class 计数排序
    {
        /// <summary>
        /// counting sort
        /// </summary>
        /// <param name="arrayA">input array</param>
        /// <param name="arrange">the value arrange in input array</param>
        /// <returns></returns>
        public int[] CountingSort(int[] arrayA, int arrange)
        {
            //array to store the sorted result,  
            //size is the same with input array. 
            int[] arrayResult = new int[arrayA.Length];
            //array to store the direct value in sorting process   
            //include index 0;    
            //size is arrange+1;    
            int[] arrayTemp = new int[arrange + 1];
            //clear up the temp array    
            for (int i = 0; i <= arrange; i++)
            {
                arrayTemp[i] = 0;
            }
            //now temp array stores the count of value equal  
            for (int j = 0; j < arrayA.Length; j++)
            {
                arrayTemp[arrayA[j]] += 1;
            }
            //now temp array stores the count of value lower and equal  
            for (int k = 1; k <= arrange; k++)
            {
                arrayTemp[k] += arrayTemp[k - 1];
            }
            //output the value to result    
            for (int m = arrayA.Length - 1; m >= 0; m--)
            {
                arrayResult[arrayTemp[arrayA[m]] - 1] = arrayA[m];
                arrayTemp[arrayA[m]] -= 1;
            }
            return arrayResult;
        }
    }

    public class 小根堆排序
    {
        /// <summary>
        /// 小根堆排序
        /// </summary>
        /// <param name="dblArray"></param>
        /// <param name="StartIndex"></param>
        /// <returns></returns>

        private void HeapSort(ref double[] dblArray)
        {
            for (int i = dblArray.Length - 1; i >= 0; i--)
            {
                if (2 * i + 1 < dblArray.Length)
                {
                    int MinChildrenIndex = 2 * i + 1;
                    //比较左子树和右子树，记录最小值的Index
                    if (2 * i + 2 < dblArray.Length)
                    {
                        if (dblArray[2 * i + 1] > dblArray[2 * i + 2])
                            MinChildrenIndex = 2 * i + 2;
                    }
                    if (dblArray[i] > dblArray[MinChildrenIndex])
                    {


                        ExchageValue(ref dblArray[i], ref dblArray[MinChildrenIndex]);
                        NodeSort(ref dblArray, MinChildrenIndex);
                    }
                }
            }
        }

        /// <summary>
        /// 节点排序
        /// </summary>
        /// <param name="dblArray"></param>
        /// <param name="StartIndex"></param>

        private void NodeSort(ref double[] dblArray, int StartIndex)
        {
            while (2 * StartIndex + 1 < dblArray.Length)
            {
                int MinChildrenIndex = 2 * StartIndex + 1;
                if (2 * StartIndex + 2 < dblArray.Length)
                {
                    if (dblArray[2 * StartIndex + 1] > dblArray[2 * StartIndex + 2])
                    {
                        MinChildrenIndex = 2 * StartIndex + 2;
                    }
                }
                if (dblArray[StartIndex] > dblArray[MinChildrenIndex])
                {
                    ExchageValue(ref dblArray[StartIndex], ref dblArray[MinChildrenIndex]);
                    StartIndex = MinChildrenIndex;
                }
            }
        }

        /// <summary>
        /// 交换值
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        private void ExchageValue(ref double A, ref double B)
        {
            double Temp = A;
            A = B;
            B = Temp;
        }
    }
}
