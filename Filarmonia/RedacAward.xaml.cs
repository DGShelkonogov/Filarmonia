using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Filarmonia
{
    /// <summary>
    /// Логика взаимодействия для RedacAward.xaml
    /// </summary>
    public partial class RedacAward : Window
    {
        public static SqlConnection connect = new SqlConnection("Data Source = HOME-PC ; Initial Catalog=Filarmonia; Integrated Security=True");

        public RedacAward()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик вывода данных из базы данных в окно
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        public void Window_Loaded(object sender, RoutedEventArgs e)

        {

            try

            {

                connect.Open();

                SqlCommand command = new SqlCommand("SELECT ID_Actor, Surname_actor  AS 'Фамилия артиста', Name_actor 'Имя артиста', Middle_name_actor 'Отчество артиста', Name_award  AS 'Награда' from Actor join Awarding on ID_award=award_ID ", connect);

                DataTable datatbl = new DataTable();

                datatbl.Load(command.ExecuteReader());

                dg1.ItemsSource = datatbl.DefaultView;


                SqlCommand command4 = new SqlCommand("SELECT ID_award, Name_award as 'Награда' from Awarding", connect);

                DataTable datatbl4 = new DataTable();

                datatbl4.Load(command4.ExecuteReader());

                Award.ItemsSource = datatbl4.DefaultView;
                Award.DisplayMemberPath = "Награда";
                Award.SelectedValuePath = "ID_award";

            }

            catch (SqlException ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                connect.Close();

            }


        }
        /// <summary>
        /// Обработчик нажатия кнопки "Найти"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        int g = 0;
        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            {
                if (g == 0)
                {

                    SqlCommand command1 = new SqlCommand("SELECT ID_Actor, Surname_actor  AS 'Фамилия артиста', Name_actor 'Имя артиста', Middle_name_actor 'Отчество артиста', Name_award  AS 'Награда' from Actor join Awarding on ID_award=award_ID where (Surname_actor like '" + Poisk1.Text + "%') or (Name_actor like '" + Poisk1.Text + "%') or (Middle_name_actor like '" + Poisk1.Text + "%') or (Name_award like '" + Poisk1.Text + "%') ", connect);
                    connect.Open();


                    DataTable datatbl1 = new DataTable();
                    datatbl1.Load(command1.ExecuteReader());
                    dg1.ItemsSource = datatbl1.DefaultView;
                    connect.Close();
                    g = 1;
                }
                else
                {
                    Window_Loaded(sender, e);
                    g = 0;
                }
            }
        }
        /// <summary>
        /// Обработчик вывода данных в датагрид
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg1.SelectedItem == null) return;



            DataRowView row = (DataRowView)dg1.SelectedItem;

            Surname.Text = row["Фамилия артиста"].ToString();

            Name.Text = row["Имя артиста"].ToString();

            Otchestvo.Text = row["Отчество артиста"].ToString();

            Award.Text = row["Награда"].ToString();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MenuOrganizator ter = new MenuOrganizator();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Изменить награды"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void ChangeAward_Click(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem == null) { MessageBox.Show("Выберите поле которое хотите изменить"); return; }
            if (Surname.Text == "" || Name.Text == "" || Otchestvo.Text == "" || Award.SelectedValue == null) { MessageBox.Show("Все поля должны быть заполненными"); return; }


            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand Upd = new SqlCommand("Actor_Update", connect);

                Upd.CommandType = CommandType.StoredProcedure;

                Upd.Parameters.AddWithValue("@ID_Actor", (int)row["ID_Actor"]);


                Upd.Parameters.AddWithValue("@Surname_actor ", Surname.Text);

                Upd.Parameters.AddWithValue("@Name_actor ", Name.Text);

                Upd.Parameters.AddWithValue("@Middle_name_actor ", Otchestvo.Text);

                Upd.Parameters.AddWithValue("@award_ID", Award.SelectedValue);

                Upd.ExecuteNonQuery();

            }

            catch (SqlException ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                connect.Close();

                Window_Loaded(sender, e);

            }

        }
    }
}
