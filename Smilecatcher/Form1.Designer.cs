namespace Smilecatcher
{
    partial class Mainform
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
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.emojipicture = new System.Windows.Forms.PictureBox();
            this.buttonMemorizeface = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonMemorizesmile = new System.Windows.Forms.Button();
            this.buttonMemorizesad = new System.Windows.Forms.Button();
            this.checkBoxface = new System.Windows.Forms.CheckBox();
            this.checkBoxmouth = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emojipicture)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(0, 0);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(640, 360);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // emojipicture
            // 
            this.emojipicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.emojipicture.Location = new System.Drawing.Point(640, 0);
            this.emojipicture.Name = "emojipicture";
            this.emojipicture.Size = new System.Drawing.Size(256, 256);
            this.emojipicture.TabIndex = 4;
            this.emojipicture.TabStop = false;
            // 
            // buttonMemorizeface
            // 
            this.buttonMemorizeface.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonMemorizeface.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemorizeface.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMemorizeface.Location = new System.Drawing.Point(0, 360);
            this.buttonMemorizeface.Name = "buttonMemorizeface";
            this.buttonMemorizeface.Size = new System.Drawing.Size(208, 128);
            this.buttonMemorizeface.TabIndex = 6;
            this.buttonMemorizeface.Text = "Memorize new face";
            this.buttonMemorizeface.UseVisualStyleBackColor = false;
            this.buttonMemorizeface.Click += new System.EventHandler(this.buttonMemorizeface_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(208, 376);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(432, 44);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "me";
            // 
            // buttonMemorizesmile
            // 
            this.buttonMemorizesmile.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonMemorizesmile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemorizesmile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMemorizesmile.Location = new System.Drawing.Point(640, 360);
            this.buttonMemorizesmile.Name = "buttonMemorizesmile";
            this.buttonMemorizesmile.Size = new System.Drawing.Size(256, 64);
            this.buttonMemorizesmile.TabIndex = 8;
            this.buttonMemorizesmile.Text = "Memorize new smile";
            this.buttonMemorizesmile.UseVisualStyleBackColor = false;
            this.buttonMemorizesmile.Click += new System.EventHandler(this.buttonMemorizesmile_Click);
            // 
            // buttonMemorizesad
            // 
            this.buttonMemorizesad.BackColor = System.Drawing.Color.PeachPuff;
            this.buttonMemorizesad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMemorizesad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMemorizesad.Location = new System.Drawing.Point(640, 424);
            this.buttonMemorizesad.Name = "buttonMemorizesad";
            this.buttonMemorizesad.Size = new System.Drawing.Size(256, 64);
            this.buttonMemorizesad.TabIndex = 9;
            this.buttonMemorizesad.Text = "Memorize new sad";
            this.buttonMemorizesad.UseVisualStyleBackColor = false;
            this.buttonMemorizesad.Click += new System.EventHandler(this.buttonMemorizesad_Click);
            // 
            // checkBoxface
            // 
            this.checkBoxface.AutoSize = true;
            this.checkBoxface.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxface.Location = new System.Drawing.Point(216, 440);
            this.checkBoxface.Name = "checkBoxface";
            this.checkBoxface.Size = new System.Drawing.Size(174, 28);
            this.checkBoxface.TabIndex = 10;
            this.checkBoxface.Text = "Show face boxes";
            this.checkBoxface.UseVisualStyleBackColor = true;
            // 
            // checkBoxmouth
            // 
            this.checkBoxmouth.AutoSize = true;
            this.checkBoxmouth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxmouth.Location = new System.Drawing.Point(432, 440);
            this.checkBoxmouth.Name = "checkBoxmouth";
            this.checkBoxmouth.Size = new System.Drawing.Size(192, 28);
            this.checkBoxmouth.TabIndex = 11;
            this.checkBoxmouth.Text = "Show mouth boxes";
            this.checkBoxmouth.UseVisualStyleBackColor = true;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(896, 490);
            this.Controls.Add(this.checkBoxmouth);
            this.Controls.Add(this.checkBoxface);
            this.Controls.Add(this.buttonMemorizesad);
            this.Controls.Add(this.buttonMemorizesmile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonMemorizeface);
            this.Controls.Add(this.emojipicture);
            this.Controls.Add(this.imageBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Mainform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emojipicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.PictureBox emojipicture;
        private System.Windows.Forms.Button buttonMemorizeface;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonMemorizesmile;
        private System.Windows.Forms.Button buttonMemorizesad;
        private System.Windows.Forms.CheckBox checkBoxface;
        private System.Windows.Forms.CheckBox checkBoxmouth;
    }
}

