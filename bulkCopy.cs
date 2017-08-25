
 /// <summary>  
        //    /// 将dataset写进数据库 
        //    /// </summary>  
public void WriteIntoDataBase(DataTable dt)  
{  
    SqlConnection myConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbBaseDatabase"].ConnectionString);  
    myConn.Open();  
    SqlBulkCopy bulkCopy = new SqlBulkCopy(myConn);  
    bulkCopy.BatchSize = 10000;  //批大小
    bulkCopy.BulkCopyTimeout = 60;  
    bulkCopy.DestinationTableName = "test";//目标表  
    for (int i = 0; i < dt.Columns.Count; i++)  
    {  
        string columnName = dt.Columns[i].ColumnName;  
        bulkCopy.ColumnMappings.Add(columnName, columnName);  
    }  
    bulkCopy.WriteToServer(dt);  
    //myConn.Close();  
    myConn.Dispose();  
}  