using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardApp.DataLayer
{
    public class PositionService
    {


        private SQLrepository SQLrepository;

        public PositionService()
        {
            SQLrepository = new SQLrepository();
        }

        public List<Position> GetPosition()
        {
            var query = SQLrepository.getPositionConstant;

            using (var connection = SQLrepository.GetConnection())
            {
                connection.Open();

                return connection.Query<Position>(query).ToList();
            }
        }


        public double getPortfolioValue(decimal account_id)
        {
            var postionList = GetPosition();

            var filtered = new List<Position>();

            foreach (var position in postionList)
            {
                if (position.account_id == account_id)
                {
                    filtered.Add(position);
                }
            }

            var Priceservice = new PriceService();
            List<Price> PriceList = Priceservice.getPrice();

            var portfoliodict = new Dictionary<double, double>();
            double sum = 0;

            foreach (var positionf in filtered)
            {
                foreach (var price in PriceList)
                {
                    if (positionf.security_id == price.security_id)
                    {
                        portfoliodict.Add(positionf.security_id, positionf.quantity * price.latest);
                    }
                }
            }

            foreach (var item in portfoliodict)
            {
                sum += item.Value;
            }
            return  Math.Round(sum);
        }



        public Dictionary<string, double> getWeigth(decimal account_id)
        {


            var posList = GetPosition();
            var filtered = new List<Position>();
            var Prservice = new PriceService();
            List<Price> PrList = Prservice.getPrice();
            var portfoliovalue = getPortfolioValue(account_id);
            var securityservice = new SecurityService();
            List<Security> secList = securityservice.getSecurity();
            var weigthdict = new Dictionary<string, double>();

            foreach (var position in posList)
            {
                if (position.account_id == account_id)
                {
                    filtered.Add(position);
                }
            }

            //calculate stock value
            foreach (var positionf in filtered)
            {
                foreach (var price in PrList)
                {
                    foreach (var security in secList.Distinct())
                    {
                        if (positionf.security_id == price.security_id && price.security_id == security.security_id)
                        {
                            weigthdict.Add(security.symbol, (positionf.quantity * price.latest) / portfoliovalue * 100);
                        }
                    }
                }
            }



            return weigthdict;


        }

        public Dictionary< string, double>  getTopHolding(decimal account_id)
        {
           
            var topdict = new Dictionary<string, double>();
            var weigthstock = getWeigth( account_id);
           
            foreach ( var weigth in weigthstock)

            {
                if(weigth.Value > 10)
                {
                    topdict.Add(weigth.Key, Math.Round (weigth.Value,2));
                }
            }
           
            return topdict;
        }



        public Dictionary<string,double> getStockReturn(decimal account_id)
        { 
            var priceservice = new PriceService();
            List<Price> pricelist = priceservice.getPrice();
            var securityeservice = new SecurityService();
            List<Security> securitylist = securityeservice.getSecurity();
            var stockdict= new Dictionary<string, double>();
            var positionList = GetPosition();
            var filtered_p = new List<Position>();
            foreach (var posit in positionList)
            {
                if (posit.account_id == account_id)
                {
                    filtered_p.Add(posit);
                }
            }
            foreach (var position in filtered_p) {
                foreach (var price in pricelist) {
                    foreach (var security in securitylist.Distinct())
                    {
                        if (price.security_id == security.security_id && price.security_id ==  position.security_id)
                        {
                            stockdict.Add(security.symbol, (price.latest - price.opening) / price.opening);
                        }
                    }

                }
            }

           
            return stockdict;
        }
         




        public double getTotalStockReturn (decimal account_id)
        {
            var stockreturn = getStockReturn(account_id);
             double sum = 0;

            foreach (var item in stockreturn)
            {
                sum += item.Value;
            }
            return Math.Round(sum,4);



        }




    }
}

   
    
    
    
    
 













    

       



    


