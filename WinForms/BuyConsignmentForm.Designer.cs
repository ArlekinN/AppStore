namespace AppStore.WinForms
{
    partial class BuyConsignmentForm
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
            // BuyConsignmentForm
            // 
            ClientSize = new Size(547, 500);
            Controls.Add(buttonBack);
            Name = "BuyConsignmentForm";
            Text = "Покупка партии товаров";
            ResumeLayout(false);
        }

        private Button buttonBack;
    }
}