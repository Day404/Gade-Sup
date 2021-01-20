namespace Gade_Sup
{
    partial class frmDisplay
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
            this.lblMap = new System.Windows.Forms.Label();
            this.lblPStats = new System.Windows.Forms.Label();
            this.cmbTargets = new System.Windows.Forms.ComboBox();
            this.btnAtk = new System.Windows.Forms.Button();
            this.rtbStats = new System.Windows.Forms.RichTextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.cmbShopList = new System.Windows.Forms.ComboBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblShopList = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.btnIdle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMap.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.Location = new System.Drawing.Point(12, 9);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(51, 25);
            this.lblMap.TabIndex = 0;
            this.lblMap.Text = "Map";
            this.lblMap.Click += new System.EventHandler(this.lblMap_Click);
            // 
            // lblPStats
            // 
            this.lblPStats.AutoSize = true;
            this.lblPStats.Location = new System.Drawing.Point(285, 9);
            this.lblPStats.Name = "lblPStats";
            this.lblPStats.Size = new System.Drawing.Size(63, 13);
            this.lblPStats.TabIndex = 1;
            this.lblPStats.Text = "Player Stats";
            // 
            // cmbTargets
            // 
            this.cmbTargets.FormattingEnabled = true;
            this.cmbTargets.Location = new System.Drawing.Point(12, 264);
            this.cmbTargets.Name = "cmbTargets";
            this.cmbTargets.Size = new System.Drawing.Size(269, 21);
            this.cmbTargets.TabIndex = 2;
            // 
            // btnAtk
            // 
            this.btnAtk.Location = new System.Drawing.Point(12, 296);
            this.btnAtk.Name = "btnAtk";
            this.btnAtk.Size = new System.Drawing.Size(75, 23);
            this.btnAtk.TabIndex = 3;
            this.btnAtk.Text = "Attack";
            this.btnAtk.UseVisualStyleBackColor = true;
            this.btnAtk.Click += new System.EventHandler(this.btnAtk_Click);
            // 
            // rtbStats
            // 
            this.rtbStats.Location = new System.Drawing.Point(513, 24);
            this.rtbStats.Name = "rtbStats";
            this.rtbStats.Size = new System.Drawing.Size(246, 96);
            this.rtbStats.TabIndex = 4;
            this.rtbStats.Text = "";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(591, 206);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(513, 238);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 6;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(667, 238);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 7;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(591, 267);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // cmbShopList
            // 
            this.cmbShopList.FormattingEnabled = true;
            this.cmbShopList.Location = new System.Drawing.Point(513, 139);
            this.cmbShopList.Name = "cmbShopList";
            this.cmbShopList.Size = new System.Drawing.Size(121, 21);
            this.cmbShopList.TabIndex = 9;
            this.cmbShopList.SelectedIndexChanged += new System.EventHandler(this.cmbShopList_SelectedIndexChanged_1);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(513, 177);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 10;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(9, 248);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(43, 13);
            this.lblTarget.TabIndex = 11;
            this.lblTarget.Text = "Targets";
            // 
            // lblShopList
            // 
            this.lblShopList.AutoSize = true;
            this.lblShopList.Location = new System.Drawing.Point(510, 123);
            this.lblShopList.Name = "lblShopList";
            this.lblShopList.Size = new System.Drawing.Size(32, 13);
            this.lblShopList.TabIndex = 12;
            this.lblShopList.Text = "Shop";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(510, 8);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(53, 13);
            this.lblText.TabIndex = 13;
            this.lblText.Text = "Text Chat";
            // 
            // btnIdle
            // 
            this.btnIdle.Location = new System.Drawing.Point(591, 238);
            this.btnIdle.Name = "btnIdle";
            this.btnIdle.Size = new System.Drawing.Size(75, 23);
            this.btnIdle.TabIndex = 14;
            this.btnIdle.Text = "Idle";
            this.btnIdle.UseVisualStyleBackColor = true;
            this.btnIdle.Click += new System.EventHandler(this.btnIdle_Click);
            // 
            // frmDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIdle);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblShopList);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.cmbShopList);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.rtbStats);
            this.Controls.Add(this.btnAtk);
            this.Controls.Add(this.cmbTargets);
            this.Controls.Add(this.lblPStats);
            this.Controls.Add(this.lblMap);
            this.Name = "frmDisplay";
            this.Text = "Display";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.Label lblPStats;
        private System.Windows.Forms.ComboBox cmbTargets;
        private System.Windows.Forms.Button btnAtk;
        private System.Windows.Forms.RichTextBox rtbStats;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ComboBox cmbShopList;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblShopList;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Button btnIdle;
    }
}

