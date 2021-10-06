
namespace StampaPass
{
    partial class StampaPass
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBadge = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cognome = new System.Windows.Forms.ColumnHeader();
            this.nome = new System.Windows.Forms.ColumnHeader();
            this.badge = new System.Windows.Forms.ColumnHeader();
            this.status = new System.Windows.Forms.ColumnHeader();
            this.btnStampa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "Pass Ristorante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Badge";
            // 
            // txtBadge
            // 
            this.txtBadge.Location = new System.Drawing.Point(59, 10);
            this.txtBadge.Name = "txtBadge";
            this.txtBadge.Size = new System.Drawing.Size(264, 23);
            this.txtBadge.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cognome,
            this.nome,
            this.badge,
            this.status});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(13, 39);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(940, 501);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // cognome
            // 
            this.cognome.Text = "Cognome";
            // 
            // nome
            // 
            this.nome.Text = "Nome";
            // 
            // badge
            // 
            this.badge.Text = "Badge";
            // 
            // status
            // 
            this.status.Text = "Status";
            // 
            // btnStampa
            // 
            this.btnStampa.Location = new System.Drawing.Point(878, 9);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(75, 23);
            this.btnStampa.TabIndex = 3;
            this.btnStampa.Text = "Stampa";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.button1_Click);
            // 
            // StampaPass
            // 
            this.AcceptButton = this.btnStampa;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 552);
            this.Controls.Add(this.btnStampa);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtBadge);
            this.Controls.Add(this.label1);
            this.Name = "StampaPass";
            this.Text = "Check-in ospiti";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBadge;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader cognome;
        private System.Windows.Forms.ColumnHeader nome;
        private System.Windows.Forms.ColumnHeader badge;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.Button btnStampa;
    }
}

