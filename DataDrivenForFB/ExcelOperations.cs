using System.Data;
using System.IO;
using ExcelDataReader;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataDrivenForFB
{
    public class ExcelOperations
    {
        
        public DataTable ExcelData(string filename)
        {
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet set = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection dataTable = set.Tables;
            DataTable dataTable1 = dataTable["Sheet1"];
            return dataTable1;
        }

        static List<DataCollections> Datas = new List<DataCollections>();
        public void PopulateFromExcel(string filename)
        {
            
            DataTable dataTable = ExcelData(filename);
           
            for (int row=1; row<=dataTable.Rows.Count; row++)
            {
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    DataCollections collections = new DataCollections()
                    {

                        rownumber = row,
                        colname = dataTable.Columns[col].ColumnName,
                        colvalue = dataTable.Rows[row - 1][col].ToString()
                    };
                    Datas.Add(collections);
                }
            }
        }

        public string ReadData(int rowNumber, string ColumnName)
        {
            string data = (from colData in Datas where colData.colname == ColumnName && colData.rownumber == rowNumber select colData.colvalue).SingleOrDefault();
            return data.ToString();
        }
    }
}
