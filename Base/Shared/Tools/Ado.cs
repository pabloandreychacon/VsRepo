using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tools
{
    public class Ado
    {
        public static int ExecuteSql(string pConnection, string pSql)
        {
            // el strSql debe venir completo por ahora, en una versìon posterior pueden venir los paràmetros en un array
            //Clipboard.SetText(pSql);
            using (var connection = new SqlConnection(pConnection))
            {
                using (var cmd = new SqlCommand(pSql, connection))
                {
                    connection.Open();
                    var Records = cmd.ExecuteNonQuery();
                    return Records;
                }
            }
        }

        public static DataTable CreateDataTable(string pConnection, string pSql, string pTableName)
        {
            // crea un Data//Table sin Dataset
            //Clipboard.SetText(pSql);
            using (var dataAdapter = new SqlDataAdapter(pSql, pConnection) { MissingSchemaAction = MissingSchemaAction.AddWithKey })
            {
                using (var currentDataTable = new DataTable())
                {
                    dataAdapter.Fill(currentDataTable);
                    return currentDataTable;
                }
            }
        }

        public static DataTable CreateAddDataTable(string pConnection, string pSql, DataSet pDataSetName, string pTableName)
        {
            // crea un datatable el dataset debe ser creado previamente y  pasado como parametro
            //Clipboard.SetText(pSql);
            using (var dataAdapter = new SqlDataAdapter(pSql, pConnection))
            {
                using (var newDataTable = new DataTable(pTableName))
                {
                    dataAdapter.Fill(pDataSetName, pTableName);
                    return newDataTable;
                }
            }
        }

        public static DataSet CreateAddDataTableToDataSet(string pConnection, string pSql, string pDataSetName, string pTableName)
        {
            // crea un dataset con datatable
            //Clipboard.SetText(pSql);
            using (var currentDataSet = new DataSet
            {
                Locale = System.Globalization.CultureInfo.InvariantCulture,
                DataSetName = pDataSetName
            })
            {
                using (var dataAdapter = new SqlDataAdapter(pSql, pConnection))
                {
                    dataAdapter.Fill(currentDataSet, pTableName);
                    return currentDataSet;
                }
            }
        }

        public static SqlDataReader CreateDataReader(string pConnection, string pSql)
        {
            // el strSql debe venir completo por ahora, en una versìon posterior pueden venir los paràmetros en un array
            //Clipboard.SetText(pSql);
            //using (var connection = new SqlConnection(pConnection))
            //{
            var connection = new SqlConnection(pConnection);
            //using (var cmd = new SqlCommand(pSql, connection))
            //{
            var cmd = new SqlCommand(pSql, connection);
            connection.Open();
            //using (var results = cmd.ExecuteReader())
            //{
            //    return results;
            //}
            var results = cmd.ExecuteReader();
            return results;
            //}
            //}
        }

        public static object ExecuteScalar(string pConnection, string pSql)
        {
            // el strSql debe venir completo por ahora, en una versìon posterior pueden venir los paràmetros en un array
            //Clipboard.SetText(pSql);
            using (var connection = new SqlConnection(pConnection))
            {
                using (var cmd = new SqlCommand(pSql, connection))
                {
                    connection.Open();
                    var records = cmd.ExecuteScalar();
                    return records;
                }
            }
        }

        /* sql commands  */
        public static bool CountRecords(string pTableName, string pConnection)
        {
            var hasRecords = false;
            var countCommand = "SELECT COUNT(*) FROM ";
            countCommand += pTableName.Trim();
            var countRecords = ExecuteScalar(pConnection, countCommand);
            if ((int)countRecords > 0) hasRecords = true;
            return hasRecords;
        }

        public static DataTable CreateDataTable<T>(IEnumerable<T> list) where T : class
        {
            var dt = list.AsDataTable();
            return dt;
        }

    }
}
