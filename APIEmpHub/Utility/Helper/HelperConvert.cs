using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIEmpHub.Utility.Helper
{
    public class HelperConvert
    {
        #region Method
        public static String ConvertToString(Object obj)
        {
            String strTemp = String.Empty;
            try
            {
                if (obj == null)
                {
                    strTemp = "";
                }
                else
                {
                    strTemp = obj.ToString().Trim();
                }
            }
            catch
            {
                throw new Exception("HelperConvert.ConvertToString()");
            }
            return strTemp;
        }
        public static Boolean ConvertToBoolean(Object obj)
        {
            Boolean blnTemp = false;
            try
            {
                blnTemp = (Boolean)obj;
            }
            catch
            {
                return false;
            }
            return blnTemp;
        }
        public static Decimal ConvertToDecimal(Object obj)
        {
            Decimal dblTemp = 0;

            if(obj == null) { return dblTemp;  }
            try
            {
                dblTemp = decimal.Parse(obj.ToString());
            }
            catch
            {
            }
            return dblTemp;
        }
        public static int ConvertToInt(Object obj)
        {
            int intTemp = 0;

            if (obj == null) { return intTemp; }
            try
            {
                intTemp = int.Parse(obj.ToString());
            }
            catch
            {
            }
            return intTemp;
        }
        public static DateTime ConvertToDate(Object obj)
        {
            DateTime dtTemp = DateTime.Now;
            try
            {
                dtTemp = DateTime.Parse(obj.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dtTemp;
        }
        public static DateTime ConvertToDate(Object obj, String format)
        {
            DateTime dtTemp = DateTime.Now;
            try
            {
                DateTime.TryParseExact(obj.ToString(), format, CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out dtTemp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dtTemp;
        }
        public static String ConvertToDate103(Object obj)
        {
            String strTemp = String.Empty;
            try
            {
                try
                {
                    DateTime dt = DateTime.Now;
                    dt = DateTime.ParseExact(obj.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                    strTemp = dt.ToString("dd/MM/yyyy", new CultureInfo("en-US"));
                }
                catch
                {
                    DateTime dt = DateTime.Now;
                    //dt = DateTime.Parse(obj.ToString(), CultureInfo.CreateSpecificCulture("en-US"));
                    dt = DateTime.Parse(obj.ToString());
                    strTemp = dt.ToString("dd/MM/yyyy", new CultureInfo("en-US"));
                }
            }
            catch
            {
            }
            return strTemp;
        }
        public static String ConvertToDate112(Object obj)
        {
            String strTemp = String.Empty;
            if (obj != null)
            {
                try
                {
                    try
                    {
                        DateTime dt = DateTime.Now;
                        dt = DateTime.ParseExact(obj.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        strTemp = dt.ToString("yyyyMMdd", new CultureInfo("en-US"));
                    }
                    catch
                    {
                        DateTime dt = DateTime.Now;
                        //dt = DateTime.Parse(obj.ToString(), CultureInfo.CreateSpecificCulture("en-US"));
                        dt = DateTime.Parse(obj.ToString());
                        strTemp = dt.ToString("yyyyMMdd", new CultureInfo("en-US"));
                    }
                }
                catch (Exception ex)
                {
                    return strTemp;
                }
            }
            return strTemp;
        }

        //public static Image ConvertToImage(string base64String)
        //{
        //    byte[] imageBytes = Convert.FromBase64String(base64String);

        //    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

        //    ms.Write(imageBytes, 0, imageBytes.Length);

        //    return Image.FromStream(ms, true);
        //}

        public static DataTable ConvertToDataTable<T>(List<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }
        private static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                // HERE IS WHERE THE ERROR IS THROWN FOR NULLABLE TYPES
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }
        #endregion
    }
}
