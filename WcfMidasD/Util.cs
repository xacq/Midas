using System;
using System.Collections.Generic;
using System.Data;

namespace WcfMidasD
{
    public static class Util
    {

        public static DataSet ToDataSet<T>(this IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                t.Columns.Add(propInfo.Name, propInfo.PropertyType.BaseType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null);
                }
                t.Rows.Add(row);
            }
            return ds;
        }

        public static List<string> ToListString<T>(this T list)
        {
            Type elementType = typeof(T);
            List<string> info = new List<string>();

            //go through each property on T and add each value to the table
            if (list != null)
                foreach (var propInfo in elementType.GetProperties())
                {
                    var value = propInfo.GetValue(list);
                    info.Add(value != null ? value.ToString() : string.Empty);
                }
            return info;
        }

    }
}