using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

    public partial class MenuUser : Window
    {

        
        public static SqlConnection connect = new SqlConnection("Data Source = HOME-PC ; Initial Catalog=Filarmonia; Integrated Security=True");

        public MenuUser()
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

                SqlCommand command = new SqlCommand("SELECT ID_User, Surname_user  AS 'Фамилия', Name_user 'Имя', Middle_name_user 'Отчество', Password_ 'Пароль', Login_ 'Логин', Name_post  AS 'Должность' from [User] join Post on ID_Post=Post_ID ", connect);

                DataTable datatbl = new DataTable();

                datatbl.Load(command.ExecuteReader());

                dg1.ItemsSource = datatbl.DefaultView;


                SqlCommand command4 = new SqlCommand("SELECT ID_Post, Name_post from Post", connect);

                DataTable datatbl4 = new DataTable();

                datatbl4.Load(command4.ExecuteReader());

                Post.ItemsSource = datatbl4.DefaultView;
                Post.DisplayMemberPath = "Name_post";
                Post.SelectedValuePath = "ID_Post";

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

                    SqlCommand command1 = new SqlCommand("SELECT ID_User, Surname_user  AS 'Фамилия', Name_user 'Имя', Middle_name_user 'Отчество', Password_ 'Пароль', Login_ 'Логин', Name_post  AS 'Должность' from [User] join Post on ID_Post=Post_ID  where (Surname_user like '" + Poisk1.Text + "%') or (Name_user like '" + Poisk1.Text + "%') or (Middle_name_user like '" + Poisk1.Text + "%') or (Password_ like '" + Poisk1.Text + "%') or (Login_ like '" + Poisk1.Text + "%') or (Name_post like '" + Poisk1.Text + "%')  ", connect);
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

            Surname_user.Text = row["Фамилия"].ToString();

            Name_user.Text = row["Имя"].ToString();

            Otch_user.Text = row["Отчество"].ToString();

            Passw.Text = row["Пароль"].ToString();

            Login.Text = row["Логин"].ToString();

            Post.Text = row["Должность"].ToString();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Назад"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin ter = new MenuAdmin();
            this.Close();
            ter.Show();
        }


        /// <summary>
        /// Обработчик нажатия кнопки "Удалить"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem == null) { MessageBox.Show("Выберите поле которое хотите удалить"); return; }

            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand Del = new SqlCommand("User_Delete", connect);

                Del.CommandType = CommandType.StoredProcedure;

                Del.Parameters.AddWithValue("ID_User", (int)row["ID_User"]);

                Del.ExecuteNonQuery();


            }

            catch (SqlException ex)

            {

                MessageBox.Show("Нельзя удалить данную строку так как она используется в другой таблице");

            }

            finally

            {

                connect.Close();

                Window_Loaded(sender, e);

            }
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Изменить"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (dg1.SelectedItem == null) { MessageBox.Show("Выберите поле которое хотите изменить"); return; }
            if (Surname_user.Text == "" || Name_user.Text == "" || Passw.Text == "" || Login.Text == "" || Post.SelectedValue == null) { MessageBox.Show("Все поля должны быть заполненными"); return; }
            Regex reg = new Regex(@"[0-9]");
            if (reg.IsMatch(Name_user.Text)) { MessageBox.Show("Нельзя вводить числа в поле Имя"); return; }
            if (reg.IsMatch(Surname_user.Text)) { MessageBox.Show("Нельзя вводить числа в поле Фамилия"); return; }
            if (reg.IsMatch(Otch_user.Text)) { MessageBox.Show("Нельзя вводить числа в поле Отчество"); return; }

            try

            {

                connect.Open();
                DataRowView row = (DataRowView)dg1.SelectedItem;
                SqlCommand Upd = new SqlCommand("User_Update", connect);

                Upd.CommandType = CommandType.StoredProcedure;

                Upd.Parameters.AddWithValue("@ID_User", (int)row["ID_User"]);

                Upd.Parameters.AddWithValue("@Surname_user ", Surname_user.Text);

                Upd.Parameters.AddWithValue("@Name_user ", Name_user.Text);

                Upd.Parameters.AddWithValue("@Middle_name_user ", Otch_user.Text);

                Upd.Parameters.AddWithValue("@Password_ ", Passw.Text);

                Upd.Parameters.AddWithValue("@Login_ ", Login.Text);

                Upd.Parameters.AddWithValue("@Post_ID", Post.SelectedValue);

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
        /// Обработчик нажатия кнопки "Добавить"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Surname_user.Text == "" || Name_user.Text == "" || Passw.Text == "" || Login.Text == "" || Post.SelectedValue == null) { MessageBox.Show("Все поля должны быть заполненными"); return; }
            Regex reg = new Regex(@"[0-9]");
            if (reg.IsMatch(Name_user.Text)) { MessageBox.Show("Нельзя вводить числа в поле Имя"); return; }
            if (reg.IsMatch(Surname_user.Text)) { MessageBox.Show("Нельзя вводить числа в поле Фамилия"); return; }
            if (reg.IsMatch(Otch_user.Text)) { MessageBox.Show("Нельзя вводить числа в поле Отчество"); return; }

            try

            {

                connect.Open();

                SqlCommand add = new SqlCommand("User_Insert", connect);

                add.CommandType = CommandType.StoredProcedure;

                add.Parameters.AddWithValue("@Surname_user ", Surname_user.Text);

                add.Parameters.AddWithValue("@Name_user ", Name_user.Text);

                add.Parameters.AddWithValue("@Middle_name_user ", Otch_user.Text);

                add.Parameters.AddWithValue("@Password_ ", Passw.Text);

                add.Parameters.AddWithValue("@Login_ ", Login.Text);

                add.Parameters.AddWithValue("@Post_ID", Post.SelectedValue);

                add.ExecuteNonQuery();

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
        /// Обработчик нажатия кнопки "Добавить новую должность"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Add_Post_Click(object sender, RoutedEventArgs e)
        {
            Post ter = new Post();
            this.Close();
            ter.Show();
        }
    }
}
