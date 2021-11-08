using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using GrainMaster.Models;

public class PortFolio
{
    public static string CreatePortFolio(PortFolioModel portFolioModel)
    {
        try
        {
            DBHelper db = new DBHelper();
            List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@stock_name",portFolioModel.StockName.ToString()),
                    new SqlParameter("@Quantity",portFolioModel.Quantity.ToString()),
                    new SqlParameter("@price",portFolioModel.Price.ToString()),
                    new SqlParameter("@date",Convert.ToDateTime(portFolioModel.Date)),
                    new SqlParameter("@UserID",Convert.ToString(UserLogic.LoggedUser.Email)),
                    new SqlParameter("@UserName",Convert.ToString(UserLogic.LoggedUser.Name))
                };
            db.ExecuteNonQuery("procPortFolio", parameters, CommandType.StoredProcedure);
            return "1";
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }
    public static CombinedPortFolioModel GetByID()
    {
        CombinedPortFolioModel portFolioRecords = new CombinedPortFolioModel();
        List<PortFolioModel> lst = new List<PortFolioModel>();
       
        DBHelper db = new DBHelper();

        List<SqlParameter> parameters = new List<SqlParameter> {new SqlParameter("@UserID",Convert.ToString(UserLogic.LoggedUser.Email)) };

        DataSet ds =  db.ExecuteDataSet("select stock_name,Quantity,price,date from tblPortFolio where UserID = @UserID", parameters, CommandType.Text);
        if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                PortFolioModel _portFolioRecord = new PortFolioModel
                {
                    StockName = Convert.ToString(row["stock_name"]),
                    Quantity = Convert.ToString(row["Quantity"]),
                    Price = Convert.ToString(row["price"]),
                    Date = Convert.ToDateTime(row["date"]),
                };
                lst.Add(_portFolioRecord);
            }           
        }
        if (lst.Count > 0)
            portFolioRecords.PortFolioList = lst;
        return portFolioRecords;
    }
    public static CombinedPortFolioModel GetAll()
    {
        CombinedPortFolioModel portFolioRecords = new CombinedPortFolioModel();
        List<PortFolioModel> lst = new List<PortFolioModel>();

        DBHelper db = new DBHelper();

        DataSet ds = db.ExecuteDataSet("select ID,stock_name,Quantity,price,date from tblPortFolio", null, CommandType.Text);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                PortFolioModel _portFolioRecord = new PortFolioModel
                {
                    ID = Convert.ToInt32(row["ID"]),
                    StockName = Convert.ToString(row["stock_name"]),
                    Quantity = Convert.ToString(row["Quantity"]),
                    Price = Convert.ToString(row["price"]),
                    Date = Convert.ToDateTime(row["date"]),
                };
                lst.Add(_portFolioRecord);
            }
        }
        if (lst.Count > 0)
            portFolioRecords.PortFolioList = lst;
        return portFolioRecords;
    }

    public static List<StockDetail> GetStock()
    {
        List<StockDetail> stockDetails = new List<StockDetail>();

        DBHelper db = new DBHelper();

        DataSet ds = db.ExecuteDataSet("select ID, Name from tblStock", null, CommandType.Text);
        if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                StockDetail stockDetail = new StockDetail
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Name = Convert.ToString(row["Name"]),
                };
                stockDetails.Add(stockDetail);
            }
        }
        return stockDetails;
    }
}