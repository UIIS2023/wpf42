using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalonLepote.Forme
{
    /// <summary>
    /// Interaction logic for FrmProizvod.xaml
    /// </summary>
    public partial class FrmProizvod : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmProizvod()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNaziv.Focus();
        }

        public FrmProizvod(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNaziv.Focus();
            this.red = red;
            this.azuriraj = azuriraj;
        }


        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@NazivProizvoda", SqlDbType.NVarChar).Value = txtNaziv.Text; 
                cmd.Parameters.Add("@CenaProizvoda", SqlDbType.Int).Value = txtCena.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblProizvod set NazivProizvoda = @NazivProizvoda, CenaProizvoda=@CenaProizvoda
                                        where ProizvodID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblProizvod(NazivProizvoda, CenaProizvoda)
                                    values (@NazivProizvoda, @CenaProizvoda)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrijednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Doslo je do greske prilikom konverzije podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
