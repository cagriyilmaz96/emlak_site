using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class detay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null) // id varsa işlemleri yap
        {
            OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Server.MapPath("yonetim/data.accdb") + "");
            baglan.Open();

            OleDbCommand sorgu = new OleDbCommand("select * from ilan where id=" + Request.QueryString["id"].ToString() + "", baglan);
            OleDbDataReader oku = sorgu.ExecuteReader();
            oku.Read();
            Literal1.Text = "<table width=850><tr><td width=400><img width=400 height=375 src='C:/Users/dinyu/Desktop/emlak_site/emlak/yonetim/resim'" + oku["resim"].ToString() + "/></td><td><b>" + oku["ilan_adi"].ToString() + "</b> <br> Fiyat : " + oku["fiyat"].ToString() + " <br> <br> <u>Açıklama</u><br> " + oku["aciklama"].ToString() + " </td></tr></table>";
        }

        else Response.Redirect("default.aspx");  // id gelmezse anasayfaya yönlendir
    }
}