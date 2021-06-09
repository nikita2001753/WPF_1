using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //создаю репозиторий 
        Repository data;
        public MainWindow()
        {
            InitializeComponent();
            //заполняю репозиторий => воркеров и депортаменты
            data = Repository.CreateRepository();
            

            cbDepartment.ItemsSource = data.DepartmentsDb;

        }


        /// <summary>
        /// выводит на экран работников с id, как у выбранного департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listDbBView.ItemsSource = data.WorkersDb.Where(find);

        }

        //Workers arg это текущий элемент 

        /// <summary>
        /// возвращает работника с id, как у департамент
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool find(Workers arg)
        {     
                return arg.DepartamentId == (cbDepartment.SelectedItem as Department).DepartmentId;
        }

        /// <summary>
        /// Удаление работника в департаменте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Delette_Worker = (Workers)listDbBView.SelectedItem;
            data.WorkersDb.Remove(Delette_Worker);
        }

        /// <summary>
        /// сортировка по возрасту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listDbBView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
        }

        /// <summary>
        /// Сортировка по имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listDbBView.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }

        /// <summary>
        /// обновляет лист и работников 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cbDepartment.Items.Refresh();
            listDbBView.Items.Refresh();

        }

        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var Delette_Departament = (Department)cbDepartment.SelectedItem;


            for (int j = 0; j < data.WorkersDb.Count; j++)
            {

                if (Delette_Departament.DepartmentId == data.WorkersDb[j].DepartamentId)
                {
                    data.WorkersDb.Remove(data.WorkersDb[j]);
                }

            }
       
        }

        /// <summary>
        /// добавление работника в департамент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            data.WorkersDb.Add(new Workers (NameAdd.Text, Convert.ToInt32(AgeAdd.Text), Convert.ToInt32(DepAdd.Text) - 1));
        }

        /// <summary>
        /// Сериализация Работников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            data.SerializeWorker(NameXML_file.Text);
         
        }


        /// <summary>
        /// Десерилализация Работников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            data.DeserializeWorker(NameXML_file.Text);
        }


        /// <summary>
        /// Удалениме всех работников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            data.ClearWorkers();
        }

        /// <summary>
        /// Сериализация Работников в JAON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            data.SerializeWorkerJSON(NameJSON_file_Copy.Text);
        }

        /// <summary>
        /// Десериализация Работников в JAON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            data.DeserializeWorkerJSON(NameJSON_file_Copy.Text);
        }
    }
}
