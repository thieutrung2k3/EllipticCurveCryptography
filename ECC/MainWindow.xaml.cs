using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Words.NET;

namespace ECC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Values values;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtPlainText1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập bản rõ!!");
            }
            else
            {
                string s = txtPlainText1.Text;
                values = EllipticCurveCryptography.ToEncrypt(s);
                string en = "";
                foreach(EncryptedVersion ev in values.encryptedVersions)
                {
                    en += ev.ToString();
                }
                txtCipherText1.Text = en;
            }

        }

        private void btnMove_Click(object sender, RoutedEventArgs e)
        {
            txtCipherText2.Text = txtCipherText1.Text;
        }

        private void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            txtPlainText2.Text = EllipticCurveCryptography.ToDecrypt(values);
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word documents (*.docx)|*.docx|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    using (DocX document = DocX.Load(filePath))
                    {
                        string content = "";
                        foreach(var p in document.Paragraphs)
                        {
                            content += p.Text + "\n";
                        }
                        txtPlainText1.Text = content;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }

        }

        private void btnFile2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word documents (*.docx)|*.docx|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    using (DocX document = DocX.Load(filePath))
                    {
                        string content = "";
                        foreach (var p in document.Paragraphs)
                        {
                            content += p.Text + "\n";
                        }
                        txtCipherText2.Text = content;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
        }
    }
}