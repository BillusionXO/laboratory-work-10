using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsAppLab_2Task_
{
    public partial class Form1 : Form
    {
        private bool f_open;
        private bool f_save;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "None";
            label2.Text = "None";
            label3.Text = "";
            f_open = false;
            f_save = false; 
        }

        // Открытие файла
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
                f_open = true;
            }
            else
            {
                label1.Text = "None";
                f_open = f_save;
            }
        }

        // Сохранить файл
        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = saveFileDialog1.FileName;
                f_save = true;
            }
            else
            {
                label2.Text = "None";
                f_save = false;
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Проверка, выбраны ли файл-источник и файл-приемник
            if (!f_open) return;
            if (!f_save) return;

            FileStream fr = null; // fr - соответсвует файлу-источнику 
            FileStream fw = null; // fw - соответсвует файлу-приемнику

            int x;

            try
            {
                // Открываем файлы 
                fr = new FileStream(openFileDialog1.FileName, FileMode.Open);
                fw = new FileStream(openFileDialog1.FileName, FileMode.Open);

                // Копируем файлы побайтно
                x = fr.ReadByte();
                while (x != -1)
                {
                    fw.WriteByte((byte)x);
                    x = fr.ReadByte();
                }
                label3.Text = "OK!";
            }
            catch (IOException exc)
            {
                label3.Text = exc.Message; // Если возникла ошибка при копировании      
            }
            finally
            {
                // если все выполнено, то закрываем файлы
                if (fr != null) fr.Close();
                if (fw != null) fw.Close();
            }         
        }
    }
}
