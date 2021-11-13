using Crypthat.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Crypthat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        BlockChain blocks;

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedBlock = BlocksList.SelectedIndex;
            BlockContent.Text = blocks[selectedBlock].Data;


   
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBlock = BlocksList.SelectedIndex;
            if (selectedBlock is -1) { MessageBox.Show("Выберите блок!", "BitSY", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (blocks is null) { MessageBox.Show("Добавьте хоть один блок!", "BitSY", MessageBoxButton.OK, MessageBoxImage.Warning); return; }

            blocks.Insert(selectedBlock,BlockContent.Text);

            BlocksData.Text = blocks.ToString();


        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(BlockContent.Text)) { MessageBox.Show("Введите текст блока!", "BitSY", MessageBoxButton.OK, MessageBoxImage.Warning); return; }
            if (blocks is null)
            {
                blocks = new BlockChain(BlockContent.Text);
            }
            else
            {
                blocks.Add(BlockContent.Text);
            }
            BlocksList.Items.Add(blocks[^1].Data);


            BlockContent.Text = "";
            BlocksData.Text = blocks.ToString();

        }

        private void BlockContent_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                AddButton_Click(this, new RoutedEventArgs());
            }
        }
    }
}
