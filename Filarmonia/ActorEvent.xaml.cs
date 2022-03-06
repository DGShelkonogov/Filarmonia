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
    /// Логика взаимодействия для ActorEvent.xaml
    /// </summary>
    public partial class ActorEvent : Window
    {
        public static SqlConnection connect = new SqlConnection("Data Source = HOME-PC ; Initial Catalog=Filarmonia; Integrated Security=True");

        public ActorEvent()
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

                SqlCommand command = new SqlCommand("SELECT ID_Ever, Time_ever AS 'Время', Venue AS 'Место', Date_ever AS 'Дата', Name_Cultural_building AS 'Культурное сооружение', Surname_user AS 'Фамилия пользователя', Surname_actor AS 'Фамилия артиста' from [Ever] join [Cultural_building] on ID_Cultural_building=Cultural_building_ID join [User] on ID_User=User_ID join [Actor] on ID_Actor=Actor_ID", connect);

                DataTable datatbl = new DataTable();

                datatbl.Load(command.ExecuteReader());

                dg1.ItemsSource = datatbl.DefaultView;

                SqlCommand command4 = new SqlCommand("SELECT ID_Cultural_building, Name_Cultural_building AS 'Культурное сооружение' from Cultural_building", connect);

                DataTable datatbl4 = new DataTable();

                datatbl4.Load(command4.ExecuteReader());

                Soorugen.ItemsSource = datatbl4.DefaultView;
                Soorugen.DisplayMemberPath = "Культурное сооружение";
                Soorugen.SelectedValuePath = "ID_Cultural_building";




                SqlCommand command31 = new SqlCommand("SELECT ID_User,Surname_user AS 'Фамилия пользователя' from [User]", connect);

                DataTable datatbl31 = new DataTable();

                datatbl31.Load(command31.ExecuteReader());

                User.ItemsSource = datatbl31.DefaultView;
                User.DisplayMemberPath = "Фамилия пользователя";
                User.SelectedValuePath = "ID_User";



                SqlCommand command41 = new SqlCommand("SELECT ID_Actor,Surname_actor AS 'Фамилия артиста'  from Actor", connect);

                DataTable datatbl41 = new DataTable();

                datatbl41.Load(command41.ExecuteReader());

                Actor.ItemsSource = datatbl41.DefaultView;
                Actor.DisplayMemberPath = "Фамилия артиста";
                Actor.SelectedValuePath = "ID_Actor";



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

                    SqlCommand command1 = new SqlCommand("SELECT ID_Ever, Time_ever AS 'Время', Venue AS 'Место', Date_ever AS 'Дата', Name_Cultural_building AS 'Культурное сооружение', Surname_user AS 'Фамилия пользователя', Surname_actor AS 'Фамилия артиста' from [Ever] join [Cultural_building] on ID_Cultural_building=Cultural_building_ID join [User] on ID_User=User_ID join [Actor] on ID_Actor=Actor_ID  where (Time_ever like '" + Poisk1.Text + "%') or (Venue like '" + Poisk1.Text + "%') or (Date_ever like '" + Poisk1.Text + "%') or (Name_Cultural_building like '" + Poisk1.Text + "%') or (Surname_user like '" + Poisk1.Text + "%') or (Surname_actor like '" + Poisk1.Text + "%')  ", connect);
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
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MenuImpresario ter = new MenuImpresario();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Изменить артиста"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>

        private void ChangeActor_Click(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem == null) { MessageBox.Show("Выберите поле которое хотите изменить"); return; }
            if (Time.Text == "" || Mesto.Text == "" || Date.Text == "" || Soorugen.SelectedValue == null || User.SelectedValue == null || Actor.SelectedValue == null) { MessageBox.Show("Все поля должны быть заполненными"); return; }


            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand Upd = new SqlCommand("Ever_Update", connect);

                Upd.CommandType = CommandType.StoredProcedure;

                Upd.Parameters.AddWithValue("@ID_Ever", (int)row["ID_Ever"]);

                Upd.Parameters.AddWithValue("@Time_ever ", Time.Text);

                Upd.Parameters.AddWithValue("@Venue ", Mesto.Text);

                Upd.Parameters.AddWithValue("@Date_ever ", Date.Text);

                Upd.Parameters.AddWithValue("@Cultural_building_ID", Soorugen.SelectedValue);

                Upd.Parameters.AddWithValue("@User_ID", User.SelectedValue);

                Upd.Parameters.AddWithValue("@Actor_ID", Actor.SelectedValue);

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

        /// <summary>
        /// Обработчик вывода данных в датагрид
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>

        private void dg1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg1.SelectedItem == null) return;



            DataRowView row = (DataRowView)dg1.SelectedItem;

            Time.Text = row["Время"].ToString();

            Mesto.Text = row["Место"].ToString();

            Date.Text = row["Дата"].ToString();

            Soorugen.Text = row["Культурное сооружение"].ToString();

            User.Text = row["Фамилия пользователя"].ToString();

            Actor.Text = row["Фамилия артиста"].ToString();

        }
    }
}
