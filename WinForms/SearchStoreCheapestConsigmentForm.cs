using AppStore.BLL;
using AppStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AppStore.WinForms
{
    public partial class SearchStoreCheapestConsigmentForm : Form
    {
        private MainForm _mainForm;
        private int textBoxCount = 1;
        private bool isError = false;
        public SearchStoreCheapestConsigmentForm(MainForm mainForm)
        {
            InitializeComponent();
            LoadDataProduct("1");
            _mainForm = mainForm;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }
        private void LoadDataProduct(string i)
        {
            string nameComboBoxProduct = $"comboBoxProduct{i}";
            var comboBox = this.Controls.Find($"comboBoxProduct{i}", true).FirstOrDefault() as ComboBox;
            comboBox.Items.Clear();
            ProductService productService = new ProductService();
            List<string> products = productService.ShowUniqProducts();
            foreach (string product in products)
            {
                comboBox.Items.Add(product);
            }
        }

        private void ButtonAddField_Click(object sender, EventArgs e)
        {
            textBoxCount += 1;
            ComboBox comboBox1 = new ComboBox
            {
                Name = $"comboBoxProduct{textBoxCount}",
                Location = new System.Drawing.Point(12, 124 + (textBoxCount - 1) * 37),
                Size = new Size(151, 27)
            };
            this.Controls.Add(comboBox1);
            LoadDataProduct(textBoxCount.ToString());

            TextBox textBox2 = new TextBox
            {
                Name = $"textBoxAmount{textBoxCount}",
                Location = new System.Drawing.Point(216, 124 + (textBoxCount - 1) * 37),
                Size = new Size(125, 27)
            };
            Label labelError = new Label
            {
                Name = $"labelErrorType{textBoxCount}",
                Location = new System.Drawing.Point(403, 124 + (textBoxCount - 1) * 37),
                ForeColor = Color.Red,
                Text = "Ошибка типа данных",
                Size = new Size(157, 20)
            };
            labelError.Visible = false;
            this.Controls.Add(textBox2);
            this.Controls.Add(labelError);
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            isError = false;
            labelResult.Visible = false;
            List<Consigment> consigments = new List<Consigment>();
            string product, amount;
            var productFields = this.Controls.OfType<ComboBox>()
                .Where(tb => tb.Name.StartsWith("comboBoxProduct"))
                .OrderBy(tb => tb.Name);

            var amountFields = this.Controls.OfType<TextBox>()
                .Where(tb => tb.Name.StartsWith("textBoxAmount"))
                .OrderBy(tb => tb.Name);

            var errorFields = this.Controls.OfType<Label>()
                .Where(tb => tb.Name.StartsWith("labelErrorType"))
                .OrderBy(tb => tb.Name);
            for (int i = 0; i < errorFields.Count(); i++)
            {
                var label = this.Controls.Find($"labelErrorType{i + 1}", true).FirstOrDefault() as Label;
                label.Visible = false;
            }
            for (int i = 0; i < productFields.Count(); i++)
            {
                try
                {
                    product = productFields.ElementAt(i).Text;
                    amount = amountFields.ElementAt(i).Text;
                    if (!string.IsNullOrEmpty(product) && !string.IsNullOrEmpty(amount))
                    {
                        consigments.Add(new Consigment
                        {
                            Product = product,
                            Price = 0,
                            Amount = Convert.ToInt32(amount)
                        });
                    }
                    else
                    {
                        var label = this.Controls.Find($"labelErrorType{i + 1}", true).FirstOrDefault() as Label;
                        label.Text = "Пустое значение";
                        label.Visible = true;
                        isError = true;
                    }
                }
                catch
                {
                    var label = this.Controls.Find($"labelErrorType{i + 1}", true).FirstOrDefault() as Label;
                    label.Text = "Ошибка типа данных";
                    label.Visible = true;
                    isError = true;
                }
            }
            if (consigments.Count != 0 && !isError)
            {
                AvailabilityService availabilityService = new AvailabilityService();
                string store = availabilityService.SearchStoreCheapestConsigment(consigments);
                if (string.IsNullOrEmpty(store))
                {
                    labelResult.Text = "Нет такой партии";
                    labelResult.ForeColor = Color.Red;
                    labelResult.Visible = true;
                }
                else
                {
                    labelResult.Text = store;
                    labelResult.ForeColor = Color.Lime;
                    labelResult.Visible = true;
                }
            }
        }
    }
}
