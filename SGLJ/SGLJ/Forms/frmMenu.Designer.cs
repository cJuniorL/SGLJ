namespace SGLJ.Forms
{
    partial class frmMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.stpMenu = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpMenu
            // 
            this.stpMenu.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stpMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem});
            this.stpMenu.Location = new System.Drawing.Point(0, 0);
            this.stpMenu.Name = "stpMenu";
            this.stpMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.stpMenu.Size = new System.Drawing.Size(944, 33);
            this.stpMenu.TabIndex = 0;
            this.stpMenu.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cidadeToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.tipoDeProdutosToolStripMenuItem,
            this.vendedoresToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // cidadeToolStripMenuItem
            // 
            this.cidadeToolStripMenuItem.Name = "cidadeToolStripMenuItem";
            this.cidadeToolStripMenuItem.Size = new System.Drawing.Size(222, 30);
            this.cidadeToolStripMenuItem.Text = "Cidade";
            this.cidadeToolStripMenuItem.Click += new System.EventHandler(this.cidadeToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(222, 30);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(222, 30);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // tipoDeProdutosToolStripMenuItem
            // 
            this.tipoDeProdutosToolStripMenuItem.Name = "tipoDeProdutosToolStripMenuItem";
            this.tipoDeProdutosToolStripMenuItem.Size = new System.Drawing.Size(222, 30);
            this.tipoDeProdutosToolStripMenuItem.Text = "Tipo de Produtos";
            this.tipoDeProdutosToolStripMenuItem.Click += new System.EventHandler(this.tipoDeProdutosToolStripMenuItem_Click);
            // 
            // vendedoresToolStripMenuItem
            // 
            this.vendedoresToolStripMenuItem.Name = "vendedoresToolStripMenuItem";
            this.vendedoresToolStripMenuItem.Size = new System.Drawing.Size(222, 30);
            this.vendedoresToolStripMenuItem.Text = "Vendedores";
            this.vendedoresToolStripMenuItem.Click += new System.EventHandler(this.vendedoresToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 527);
            this.Controls.Add(this.stpMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.stpMenu;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.stpMenu.ResumeLayout(false);
            this.stpMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip stpMenu;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendedoresToolStripMenuItem;
    }
}