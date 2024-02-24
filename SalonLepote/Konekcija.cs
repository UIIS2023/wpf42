using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SalonLepote
{
    internal class Konekcija
    {
       public SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder()
            {
                DataSource = @"JOVANA\SQLEXPRESS08",
                InitialCatalog = "SalonLepote",
                IntegratedSecurity = true
            };

            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;

        }
    }
}
