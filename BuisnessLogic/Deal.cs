using GrainMaster.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GrainMaster.BuisnessLogic
{
    public class Deal
    {
        public static DealRoot Get()
        {
            DealRoot dealRoot = new DealRoot();
            try
            {
                DBHelper db = new DBHelper();

                string[] sparr = new[] { "sp_OnlyBuy", "sp_OnlySell", "sp_BuyGTSell", "sp_SellGtBuy" };

                

                foreach (string spname in sparr)
                {
                    DataSet ds =  db.ExecuteDataSet(spname, null, CommandType.StoredProcedure);
                    if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        List<DealModel> listModel = new List<DealModel>();
                        List<DealData> listData = new List<DealData>();
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if (spname.ToString() == "sp_OnlyBuy" || spname.ToString() == "sp_OnlySell")
                            {
                                listModel.Add(new DealModel()
                                {
                                    Company = Convert.ToString(row["company"]),
                                    Quantity = Convert.ToString(row["Total Quantity"]),
                                    TranDate = Convert.ToDateTime(row["trnasactionDate"]).ToString("dd-MM-yyy"),
                                });
                            }
                            else
                            {
                                listData.Add(new DealData
                                {
                                    Company = Convert.ToString(row["company"]),
                                    TotalBuyQuantity = Convert.ToString(row["TotalBuyQuantity"]),
                                    TotalSellQuantity = Convert.ToString(row["TotalSellQuantity"]),
                                    TransactionDate = Convert.ToDateTime(row["trnasactionDate"]).ToString("dd-MM-yyy"),
                                }) ;
                            }

                            if (spname.ToString() == "sp_OnlyBuy")
                                dealRoot.OnlyBuy = listModel;
                            else if (spname.ToString() == "sp_OnlySell")
                                dealRoot.OnlySell = listModel;
                            else if (spname.ToString() == "sp_BuyGTSell")
                                dealRoot.BuyGTSell = listData;
                            else if(spname.ToString() == "sp_SellGtBuy")
                                dealRoot.SellGTBuy = listData;

                        }
                       
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dealRoot;
        }
    }
}