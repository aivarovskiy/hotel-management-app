namespace KursDb
{
    partial class Form2
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
            this.ins = new System.Windows.Forms.Button();
            this.upd = new System.Windows.Forms.Button();
            this.del = new System.Windows.Forms.Button();
            this.query = new System.Windows.Forms.Button();
            this.log_out = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ins
            // 
            this.ins.Location = new System.Drawing.Point(12, 12);
            this.ins.Name = "ins";
            this.ins.Size = new System.Drawing.Size(398, 43);
            this.ins.TabIndex = 0;
            this.ins.Text = "Insert";
            this.ins.UseVisualStyleBackColor = true;
            this.ins.Click += new System.EventHandler(this.ins_Click);
            // 
            // upd
            // 
            this.upd.Location = new System.Drawing.Point(12, 61);
            this.upd.Name = "upd";
            this.upd.Size = new System.Drawing.Size(398, 43);
            this.upd.TabIndex = 1;
            this.upd.Text = "Update";
            this.upd.UseVisualStyleBackColor = true;
            this.upd.Click += new System.EventHandler(this.upd_Click);
            // 
            // del
            // 
            this.del.Location = new System.Drawing.Point(12, 110);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(398, 43);
            this.del.TabIndex = 2;
            this.del.Text = "Delete";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.del_Click);
            // 
            // query
            // 
            this.query.Location = new System.Drawing.Point(12, 159);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(398, 43);
            this.query.TabIndex = 3;
            this.query.Text = "Query";
            this.query.UseVisualStyleBackColor = true;
            this.query.Click += new System.EventHandler(this.query_Click);
            // 
            // log_out
            // 
            this.log_out.Location = new System.Drawing.Point(12, 208);
            this.log_out.Name = "log_out";
            this.log_out.Size = new System.Drawing.Size(398, 43);
            this.log_out.TabIndex = 5;
            this.log_out.Text = "Log Out";
            this.log_out.UseVisualStyleBackColor = true;
            this.log_out.Click += new System.EventHandler(this.log_out_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 263);
            this.Controls.Add(this.log_out);
            this.Controls.Add(this.query);
            this.Controls.Add(this.del);
            this.Controls.Add(this.upd);
            this.Controls.Add(this.ins);
            this.Name = "Form2";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ins;
        private System.Windows.Forms.Button upd;
        private System.Windows.Forms.Button del;
        private System.Windows.Forms.Button query;
        private System.Windows.Forms.Button log_out;
    }
}