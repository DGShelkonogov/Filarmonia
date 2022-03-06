using System;
using System.Collections.Generic;
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
  
    public partial class MenuAdmin : Window
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Меню пользователей"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void User_Click(object sender, RoutedEventArgs e)
        {
            MenuUser ter = new MenuUser();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню характеристик сооружений"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Xaracter_Click(object sender, RoutedEventArgs e)
        {
            XaracterSoorugen ter = new XaracterSoorugen();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню типов сооружений"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Type_Soorugen_Click(object sender, RoutedEventArgs e)
        {
            TypeSoorugen ter = new TypeSoorugen();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню списка характеристик"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Spisok_Xaracter_Click(object sender, RoutedEventArgs e)
        {
            SpisokSoorugen ter = new SpisokSoorugen();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню сооружений"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Soorugen_Click(object sender, RoutedEventArgs e)
        {
            Soorugen ter = new Soorugen();
            this.Close();
            ter.Show();
        }
    }
}
