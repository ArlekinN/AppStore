namespace AppStore.WinForms
{
    partial class SearchStoreCheapestProductForm
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
            // SearchStoreCheapestProductForm
            // 
            ClientSize = new Size(547, 500);
            Controls.Add(buttonBack);
            Name = "SearchStoreCheapestProductForm";
            Text = "Поиск магазина с самым дешевым продуктом";
            ResumeLayout(false);
        }

        private Button buttonBack;
        
    }
}