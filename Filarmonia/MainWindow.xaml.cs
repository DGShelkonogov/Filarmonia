using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Filarmonia
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window
    {
        public static SqlConnection connect = new SqlConnection("Data Source = HOME-PC ; Initial Catalog=Filarmonia; Integrated Security=True");

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "войти"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>


        private void Voiti_Click(object sender, RoutedEventArgs e)
        {
            
                connect.Open();
                SqlCommand c = new SqlCommand($@"SELECT [Login_],[Password_],Post_ID FROM [User] where [Login_]='{Login.Text}' and Password_='{Passw.Password}'", connect);
                SqlDataReader reader = c.ExecuteReader();
                if (reader.Read())
                {
                    int level = Convert.ToInt32(reader["Post_ID"].ToString());
                    if (reader.HasRows) // если есть данные
                    {

                        switch (level)
                        {
                            case 1:
                                {
                                    Window u = new MenuAdmin();
                                    this.Hide();
                                    u.Show();
                                    break;
                                }
                            case 2:
                                {

                                    Window u1 = new MenuActor();
                                    this.Hide();
                                    u1.Show();
                                    break;
                                }
                            case 3:
                                {

                                    Window u2 = new MenuOrganizator();
                                    this.Hide();
                                    u2.Show();
                                    break;
                                }

                            case 4:
                                {

                                    Window u3 = new MenuImpresario();
                                    this.Hide();
                                    u3.Show();
                                    break;
                                }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Сначала зарегистрируйте этого пользователя");
                }
                connect.Close();
            
        }
    }
}

