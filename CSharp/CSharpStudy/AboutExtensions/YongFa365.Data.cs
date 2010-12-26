using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;
//扩展方法：Extension Methods http://msdn.microsoft.com/zh-cn/library/bb383977.aspx


//TODO:此扩展没有验证过需要时再研究，考虑缓存会快点
namespace YongFa365.Data
{
    //from:http://www.cnblogs.com/livexy/archive/2010/09/01/1815330.html
    #region IDataReaderExtensionMethods
    public static class IDataReaderExtensionMethods
    {
        //最快和直接循环差不多
        public static List<TResult> ToList<TResult>(this IDataReader dr, bool isClose) where TResult : class, new()
        {
            IDataReaderEntityBuilder<TResult> eblist = IDataReaderEntityBuilder<TResult>.CreateBuilder(dr);
            List<TResult> list = new List<TResult>();
            if (dr == null) return list;
            while (dr.Read()) list.Add(eblist.Build(dr));
            if (isClose) { dr.Close(); dr.Dispose(); dr = null; }
            return list;
        }
        public static List<TResult> ToList<TResult>(this IDataReader dr) where TResult : class, new()
        {
            return dr.ToList<TResult>(true);
        }

        //也慢
        public static List<TResult> ToList2<TResult>(this IDataReader dr, bool isClose) where TResult : class, new()
        {
            List<TResult> oblist = new List<TResult>();
            if (dr == null) return oblist;

            List<string> drColumns = new List<string>();
            int len = dr.FieldCount;
            for (int j = 0; j < len; j++) drColumns.Add(dr.GetName(j).Trim());

            List<PropertyInfo> prlist = new List<PropertyInfo>();
            Type t = typeof(TResult);
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (drColumns.IndexOf(p.Name) != -1) prlist.Add(p); });

            while (dr.Read())
            {
                TResult ob = new TResult();
                prlist.ForEach(p => { if (dr[p.Name] != DBNull.Value) p.SetValue(ob, dr[p.Name], null); });
                oblist.Add(ob);
            }
            if (isClose) { dr.Close(); dr.Dispose(); dr = null; }
            return oblist;
        }
        public static List<TResult> ToList2<TResult>(this IDataReader dr) where TResult : class, new()
        {
            return dr.ToList2<TResult>(true);
        }

        //最慢
        public static List<TResult> ToList3<TResult>(this IDataReader dr, bool isClose) where TResult : class, new()
        {
            List<TResult> list = new List<TResult>();
            if (dr == null) return list;
            int len = dr.FieldCount;

            while (dr.Read())
            {
                TResult info = new TResult();
                for (int j = 0; j < len; j++)
                {
                    if (dr[j] == null || string.IsNullOrEmpty(dr[j].ToString())) continue;
                    info.GetType().GetProperty(dr.GetName(j).Trim()).SetValue(info, dr[j], null);
                }
                list.Add(info);
            }
            if (isClose) { dr.Close(); dr.Dispose(); dr = null; }
            return list;
        }
        public static List<TResult> ToList3<TResult>(this IDataReader dr) where TResult : class, new()
        {
            return dr.ToList3<TResult>(true);
        }
    }


    public class IDataReaderEntityBuilder<TEntity>
    {
        private static readonly MethodInfo getValueMethod = typeof(IDataRecord).GetMethod("get_Item", new Type[] { typeof(int) });
        private static readonly MethodInfo isDBNullMethod = typeof(IDataRecord).GetMethod("IsDBNull", new Type[] { typeof(int) });
        private delegate TEntity Load(IDataRecord dataRecord);

        private Load handler;
        private IDataReaderEntityBuilder() { }
        public TEntity Build(IDataRecord dataRecord)
        {
            return handler(dataRecord);
        }
        public static IDataReaderEntityBuilder<TEntity> CreateBuilder(IDataRecord dataRecord)
        {
            IDataReaderEntityBuilder<TEntity> dynamicBuilder = new IDataReaderEntityBuilder<TEntity>();
            DynamicMethod method = new DynamicMethod("DynamicCreateEntity", typeof(TEntity), new Type[] { typeof(IDataRecord) }, typeof(TEntity), true);
            ILGenerator generator = method.GetILGenerator();
            LocalBuilder result = generator.DeclareLocal(typeof(TEntity));
            generator.Emit(OpCodes.Newobj, typeof(TEntity).GetConstructor(Type.EmptyTypes));
            generator.Emit(OpCodes.Stloc, result);
            for (int i = 0; i < dataRecord.FieldCount; i++)
            {
                PropertyInfo propertyInfo = typeof(TEntity).GetProperty(dataRecord.GetName(i));
                Label endIfLabel = generator.DefineLabel();
                if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
                {
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    generator.Emit(OpCodes.Callvirt, isDBNullMethod);
                    generator.Emit(OpCodes.Brtrue, endIfLabel);
                    generator.Emit(OpCodes.Ldloc, result);
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    generator.Emit(OpCodes.Callvirt, getValueMethod);
                    generator.Emit(OpCodes.Unbox_Any, dataRecord.GetFieldType(i));
                    generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());
                    generator.MarkLabel(endIfLabel);
                }
            }
            generator.Emit(OpCodes.Ldloc, result);
            generator.Emit(OpCodes.Ret);
            dynamicBuilder.handler = (Load)method.CreateDelegate(typeof(Load));
            return dynamicBuilder;
        }
    }
    #endregion

    #region DataTableExtensionMethods
    public static class DataTableExtensionMethods
    {
        //最快和直接循环差不多
        public static List<TResult> ToList<TResult>(this DataTable dt) where TResult : class, new()
        {
            List<TResult> list = new List<TResult>();
            if (dt == null) return list;
            DataTableEntityBuilder<TResult> eblist = DataTableEntityBuilder<TResult>.CreateBuilder(dt.Rows[0]);
            foreach (DataRow info in dt.Rows) list.Add(eblist.Build(info));
            dt.Dispose(); dt = null;
            return list;
        }

        //也慢
        public static List<TResult> ToList2<TResult>(this DataTable dt) where TResult : class, new()
        {
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            Type t = typeof(TResult);
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            List<TResult> oblist = new List<TResult>();

            foreach (DataRow row in dt.Rows)
            {
                TResult ob = new TResult();
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                oblist.Add(ob);
            }
            return oblist;
        }

        //最慢
        public static List<TResult> ToList3<TResult>(this DataTable dt) where TResult : class, new()
        {
            List<TResult> list = new List<TResult>();
            if (dt == null) return list;
            int len = dt.Rows.Count;

            for (int i = 0; i < len; i++)
            {
                TResult info = new TResult();
                foreach (DataColumn dc in dt.Rows[0].Table.Columns)
                {
                    if (dt.Rows[i][dc.ColumnName] == null || string.IsNullOrEmpty(dt.Rows[i][dc.ColumnName].ToString())) continue;
                    info.GetType().GetProperty(dc.ColumnName).SetValue(info, dt.Rows[i][dc.ColumnName], null);
                }
                list.Add(info);
            }
            dt.Dispose(); dt = null;
            return list;
        }
    }

    public class DataTableEntityBuilder<TEntity>
    {
        private static readonly MethodInfo getValueMethod = typeof(DataRow).GetMethod("get_Item", new Type[] { typeof(int) });
        private static readonly MethodInfo isDBNullMethod = typeof(DataRow).GetMethod("IsNull", new Type[] { typeof(int) });
        private delegate TEntity Load(DataRow dataRecord);

        private Load handler;
        private DataTableEntityBuilder() { }

        public TEntity Build(DataRow dataRecord)
        {
            return handler(dataRecord);
        }
        public static DataTableEntityBuilder<TEntity> CreateBuilder(DataRow dataRecord)
        {
            DataTableEntityBuilder<TEntity> dynamicBuilder = new DataTableEntityBuilder<TEntity>();
            DynamicMethod method = new DynamicMethod("DynamicCreateEntity", typeof(TEntity), new Type[] { typeof(DataRow) }, typeof(TEntity), true);
            ILGenerator generator = method.GetILGenerator();
            LocalBuilder result = generator.DeclareLocal(typeof(TEntity));
            generator.Emit(OpCodes.Newobj, typeof(TEntity).GetConstructor(Type.EmptyTypes));
            generator.Emit(OpCodes.Stloc, result);

            for (int i = 0; i < dataRecord.ItemArray.Length; i++)
            {
                PropertyInfo propertyInfo = typeof(TEntity).GetProperty(dataRecord.Table.Columns[i].ColumnName);
                Label endIfLabel = generator.DefineLabel();
                if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
                {
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    generator.Emit(OpCodes.Callvirt, isDBNullMethod);
                    generator.Emit(OpCodes.Brtrue, endIfLabel);
                    generator.Emit(OpCodes.Ldloc, result);
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldc_I4, i);
                    generator.Emit(OpCodes.Callvirt, getValueMethod);
                    generator.Emit(OpCodes.Unbox_Any, propertyInfo.PropertyType);
                    generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());
                    generator.MarkLabel(endIfLabel);
                }
            }
            generator.Emit(OpCodes.Ldloc, result);
            generator.Emit(OpCodes.Ret);
            dynamicBuilder.handler = (Load)method.CreateDelegate(typeof(Load));
            return dynamicBuilder;
        }
    }

    #endregion
}
