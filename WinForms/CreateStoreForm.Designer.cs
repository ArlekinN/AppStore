namespace AppStore.WinForms
{
    partial class CreateStoreForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            buttonBack = new Button();
            labelNameStore = new Label();
            textBoxNameStore = new TextBox();
            textBoxAddressStore = new TextBox();
            labelAddressStore = new Label();
            buttonCreateStore = new Button();
            labelResultCreating = new Label();
            SuspendLayout();
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(422, 12);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(94, 29);
            buttonBack.TabIndex = 0;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += Back_Click;
            // 
            // labelNameStore
            // 
            labelNameStore.AutoSize = true;
            labelNameStore.Location = new Point(22, 21);
            labelNameStore.Name = "labelNameStore";
            labelNameStore.Size = new Size(147, 20);
            labelNameStore.TabIndex = 1;
            labelNameStore.Text = "Название магазина";
            // 
            // textBoxNameStore
            // 
            textBoxNameStore.Location = new Point(175, 21);
            textBoxNameStore.Name = "textBoxNameStore";
            textBoxNameStore.Size = new Size(125, 27);
            textBoxNameStore.TabIndex = 2;
            // 
            // textBoxAddressStore
            // 
            textBoxAddressStore.Location = new Point(175, 72);
            textBoxAddressStore.Name = "textBoxAddressStore";
            textBoxAddressStore.Size = new Size(125, 27);
            textBoxAddressStore.TabIndex = 3;
            // 
            // labelAddressStore
            // 
            labelAddressStore.AutoSize = true;
            labelAddressStore.Location = new Point(22, 75);
            labelAddressStore.Name = "labelAddressStore";
            labelAddressStore.Size = new Size(121, 20);
            labelAddressStore.TabIndex = 4;
            labelAddressStore.Text = "Адрес магазина";
            // 
            // buttonCreateStore
            // 
            buttonCreateStore.Location = new Point(22, 137);
            buttonCreateStore.Name = "buttonCreateStore";
            buttonCreateStore.Size = new Size(147, 29);
            buttonCreateStore.TabIndex = 5;
            buttonCreateStore.Text = "Создать магазин";
            buttonCreateStore.UseVisualStyleBackColor = true;
            buttonCreateStore.Click += ButtonCreateStore_Click;
            // 
            // labelResultCreating
            // 
            labelResultCreating.AutoSize = true;
            labelResultCreating.BackColor = SystemColors.Control;
            labelResultCreating.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelResultCreating.ForeColor = Color.Lime;
            labelResultCreating.Location = new Point(192, 137);
            labelResultCreating.Name = "labelResultCreating";
            labelResultCreating.Size = new Size(84, 25);
            labelResultCreating.TabIndex = 6;
            labelResultCreating.Text = "Успешно";
            labelResultCreating.Visible = false; ;
            // 
            // CreateStoreForm
            // 
            ClientSize = new Size(600, 500);
            Controls.Add(labelResultCreating);
            Controls.Add(buttonCreateStore);
            Controls.Add(labelAddressStore);
            Controls.Add(textBoxAddressStore);
            Controls.Add(textBoxNameStore);
            Controls.Add(labelNameStore);
            Controls.Add(buttonBack);
            Name = "CreateStoreForm";
            Text = "Создание магазина";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button buttonBack;
        private Label labelNameStore;
        private TextBox textBoxNameStore;
        private TextBox textBoxAddressStore;
        private Label labelAddressStore;
        private Button buttonCreateStore;
        private Label labelResultCreating;
    }
}