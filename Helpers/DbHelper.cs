using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace AdoNetReflector.DbHelper
{
    public static class Helper
    {

        public static IEnumerable<T> LoadClassFromSQLDataReader<T>(this SqlDataReader dr) where T : class
        {
            object myClass = Activator.CreateInstance(typeof(T))??throw new ArgumentNullException();
            Type typeOfClass = myClass.GetType();

            List<T> list = new List<T>();
            if (dr.HasRows)
            {


                while (dr.Read())
                {

                    myClass = Activator.CreateInstance(typeof(T))??throw new ArgumentNullException();
                    for (int columnIndex = 0; columnIndex <= dr.FieldCount - 1; columnIndex++)
                    {            //Get the name of the column           
                        string columnName = dr.GetName(columnIndex);
                        //Check if a property exists that matches that name.         
                        PropertyInfo propertyInfo = typeOfClass.GetProperty(columnName);

                        if (propertyInfo != null)
                        {
                            //Set the value to the value in the SqlDataReader 
                            if (propertyInfo.PropertyType == typeof(string) && dr.IsDBNull(columnIndex))
                                propertyInfo.SetValue(myClass, string.Empty);
                            else if (propertyInfo.PropertyType == typeof(DateTime?) && dr.IsDBNull(columnIndex))
                                propertyInfo.SetValue(myClass, null);
                            else if (propertyInfo.PropertyType == typeof(bool?) && dr.IsDBNull(columnIndex))
                                propertyInfo.SetValue(myClass, null);
                            else if (propertyInfo.PropertyType == typeof(int?) && dr.IsDBNull(columnIndex))
                                propertyInfo.SetValue(myClass, null);
                            else propertyInfo.SetValue(myClass, dr.GetValue(columnIndex));
                        }
                    }
                    list.Add((T)myClass);
                }

                IEnumerable<T> vs = list;
                return vs;
            }

            else { return null; }
        }
        public static async Task<IEnumerable<T>> LoadClassFromSQLDataReaderAsync<T>(this SqlDataReader dr) where T : class
        {
            object myClass = Activator.CreateInstance(typeof(T))??throw new ArgumentNullException();
            Type typeOfClass = myClass.GetType();

            List<T> list = new List<T>();
            if (dr.HasRows)
            {


                while (await dr.ReadAsync())
                {

                    myClass = Activator.CreateInstance(typeof(T)) ??throw new ArgumentNullException();
                    for (int columnIndex = 0; columnIndex <= dr.FieldCount - 1; columnIndex++)
                    {            //Get the name of the column           
                        string columnName = dr.GetName(columnIndex);
                        //Check if a property exists that matches that name.         
                        PropertyInfo propertyInfo = typeOfClass.GetProperty(columnName);

                        if (propertyInfo != null)
                        {
                            //Set the value to the value in the SqlDataReader 
                            if (propertyInfo.PropertyType == typeof(string) && dr.IsDBNull(columnIndex))
                                propertyInfo.SetValue(myClass, string.Empty);
                            else if (propertyInfo.PropertyType == typeof(DateTime?) && dr.IsDBNull(columnIndex))
                                propertyInfo.SetValue(myClass, null);
                            else if (propertyInfo.PropertyType == typeof(bool?) && dr.IsDBNull(columnIndex))
                                propertyInfo.SetValue(myClass, null);
                            else if (propertyInfo.PropertyType == typeof(int?) && dr.IsDBNull(columnIndex))
                                propertyInfo.SetValue(myClass, null);
                            else propertyInfo.SetValue(myClass, dr.GetValue(columnIndex));
                        }
                    }
                    list.Add((T)myClass);
                }

                IEnumerable<T> vs = list;
                return vs;
            }

            else { return null; }
        }

    }

}
