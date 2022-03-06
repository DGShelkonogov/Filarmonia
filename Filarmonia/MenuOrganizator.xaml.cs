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
    /// <summary>
    /// Логика взаимодействия для MenuOrganizator.xaml
    /// </summary>
    public partial class MenuOrganizator : Window
    {
        public MenuOrganizator()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню мероприятий"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Ever_M_Click(object sender, RoutedEventArgs e)
        {
            Ever ter = new Ever();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню наград"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Award_Click(object sender, RoutedEventArgs e)
        {
            Award ter = new Award();
            this.Close();
            ter.Show();
        }
        /// <summary>
        /// Обработчик нажатия кнопки "Меню актеров"
        /// </summary>
        /// <param name="sender"> параметр, в котором находится ссылка на объект инициатор события </param>
        /// <param name="e"> экземпляр класса для перенаправления событий </param>
        private void Actor_M_Click(object sender, RoutedEventArgs e)
        {
            RedacAward ter = new RedacAward();
            this.Close();
            ter.Show();
        }
    }
}
