namespace GK1_PROJ4_FINAL
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cameraGbox = new System.Windows.Forms.GroupBox();
            this.camera3Rbutton = new System.Windows.Forms.RadioButton();
            this.camera2Rbutton = new System.Windows.Forms.RadioButton();
            this.camera1Rbutton = new System.Windows.Forms.RadioButton();
            this.shadingGbox = new System.Windows.Forms.GroupBox();
            this.phongsShadingRbutton = new System.Windows.Forms.RadioButton();
            this.gouraudsShadingRbutton = new System.Windows.Forms.RadioButton();
            this.solidShadingRbutton = new System.Windows.Forms.RadioButton();
            this.optionsGbox = new System.Windows.Forms.GroupBox();
            this.dayNightRbutton = new System.Windows.Forms.RadioButton();
            this.fogRbutton = new System.Windows.Forms.RadioButton();
            this.tremorRbutton = new System.Windows.Forms.RadioButton();
            this.animationRbutton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.cameraGbox.SuspendLayout();
            this.shadingGbox.SuspendLayout();
            this.optionsGbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.canvas);
            this.splitContainer.Panel1MinSize = 753;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel);
            this.splitContainer.Size = new System.Drawing.Size(982, 753);
            this.splitContainer.SplitterDistance = 753;
            this.splitContainer.TabIndex = 0;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(753, 753);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.cameraGbox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.shadingGbox, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.optionsGbox, 0, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(225, 753);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // cameraGbox
            // 
            this.cameraGbox.AutoSize = true;
            this.cameraGbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cameraGbox.Controls.Add(this.camera3Rbutton);
            this.cameraGbox.Controls.Add(this.camera2Rbutton);
            this.cameraGbox.Controls.Add(this.camera1Rbutton);
            this.cameraGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraGbox.Location = new System.Drawing.Point(3, 3);
            this.cameraGbox.Name = "cameraGbox";
            this.cameraGbox.Size = new System.Drawing.Size(219, 116);
            this.cameraGbox.TabIndex = 0;
            this.cameraGbox.TabStop = false;
            this.cameraGbox.Text = "Camera";
            // 
            // camera3Rbutton
            // 
            this.camera3Rbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.camera3Rbutton.AutoSize = true;
            this.camera3Rbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.camera3Rbutton.Location = new System.Drawing.Point(3, 83);
            this.camera3Rbutton.Name = "camera3Rbutton";
            this.camera3Rbutton.Size = new System.Drawing.Size(213, 30);
            this.camera3Rbutton.TabIndex = 2;
            this.camera3Rbutton.Text = "Moving, FPP";
            this.camera3Rbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.camera3Rbutton.UseVisualStyleBackColor = true;
            // 
            // camera2Rbutton
            // 
            this.camera2Rbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.camera2Rbutton.AutoSize = true;
            this.camera2Rbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.camera2Rbutton.Location = new System.Drawing.Point(3, 53);
            this.camera2Rbutton.Name = "camera2Rbutton";
            this.camera2Rbutton.Size = new System.Drawing.Size(213, 30);
            this.camera2Rbutton.TabIndex = 1;
            this.camera2Rbutton.Text = "Still, following object";
            this.camera2Rbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.camera2Rbutton.UseVisualStyleBackColor = true;
            // 
            // camera1Rbutton
            // 
            this.camera1Rbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.camera1Rbutton.AutoSize = true;
            this.camera1Rbutton.Checked = true;
            this.camera1Rbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.camera1Rbutton.Location = new System.Drawing.Point(3, 23);
            this.camera1Rbutton.Name = "camera1Rbutton";
            this.camera1Rbutton.Size = new System.Drawing.Size(213, 30);
            this.camera1Rbutton.TabIndex = 0;
            this.camera1Rbutton.TabStop = true;
            this.camera1Rbutton.Text = "Still, observing scene";
            this.camera1Rbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.camera1Rbutton.UseVisualStyleBackColor = true;
            // 
            // shadingGbox
            // 
            this.shadingGbox.AutoSize = true;
            this.shadingGbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.shadingGbox.Controls.Add(this.phongsShadingRbutton);
            this.shadingGbox.Controls.Add(this.gouraudsShadingRbutton);
            this.shadingGbox.Controls.Add(this.solidShadingRbutton);
            this.shadingGbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shadingGbox.Location = new System.Drawing.Point(3, 125);
            this.shadingGbox.Name = "shadingGbox";
            this.shadingGbox.Size = new System.Drawing.Size(219, 116);
            this.shadingGbox.TabIndex = 1;
            this.shadingGbox.TabStop = false;
            this.shadingGbox.Text = "Shading mode";
            // 
            // phongsShadingRbutton
            // 
            this.phongsShadingRbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.phongsShadingRbutton.AutoSize = true;
            this.phongsShadingRbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.phongsShadingRbutton.Location = new System.Drawing.Point(3, 83);
            this.phongsShadingRbutton.Name = "phongsShadingRbutton";
            this.phongsShadingRbutton.Size = new System.Drawing.Size(213, 30);
            this.phongsShadingRbutton.TabIndex = 2;
            this.phongsShadingRbutton.Text = "Phong\'s shading";
            this.phongsShadingRbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.phongsShadingRbutton.UseVisualStyleBackColor = true;
            // 
            // gouraudsShadingRbutton
            // 
            this.gouraudsShadingRbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.gouraudsShadingRbutton.AutoSize = true;
            this.gouraudsShadingRbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.gouraudsShadingRbutton.Location = new System.Drawing.Point(3, 53);
            this.gouraudsShadingRbutton.Name = "gouraudsShadingRbutton";
            this.gouraudsShadingRbutton.Size = new System.Drawing.Size(213, 30);
            this.gouraudsShadingRbutton.TabIndex = 1;
            this.gouraudsShadingRbutton.Text = "Gouraud\'s shading";
            this.gouraudsShadingRbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gouraudsShadingRbutton.UseVisualStyleBackColor = true;
            // 
            // solidShadingRbutton
            // 
            this.solidShadingRbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.solidShadingRbutton.AutoSize = true;
            this.solidShadingRbutton.Checked = true;
            this.solidShadingRbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.solidShadingRbutton.Location = new System.Drawing.Point(3, 23);
            this.solidShadingRbutton.Name = "solidShadingRbutton";
            this.solidShadingRbutton.Size = new System.Drawing.Size(213, 30);
            this.solidShadingRbutton.TabIndex = 0;
            this.solidShadingRbutton.TabStop = true;
            this.solidShadingRbutton.Text = "Solid shading";
            this.solidShadingRbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.solidShadingRbutton.UseVisualStyleBackColor = true;
            // 
            // optionsGbox
            // 
            this.optionsGbox.AutoSize = true;
            this.optionsGbox.Controls.Add(this.dayNightRbutton);
            this.optionsGbox.Controls.Add(this.fogRbutton);
            this.optionsGbox.Controls.Add(this.tremorRbutton);
            this.optionsGbox.Controls.Add(this.animationRbutton);
            this.optionsGbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsGbox.Location = new System.Drawing.Point(3, 247);
            this.optionsGbox.Name = "optionsGbox";
            this.optionsGbox.Size = new System.Drawing.Size(219, 146);
            this.optionsGbox.TabIndex = 2;
            this.optionsGbox.TabStop = false;
            this.optionsGbox.Text = "Options";
            // 
            // dayNightRbutton
            // 
            this.dayNightRbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.dayNightRbutton.AutoCheck = false;
            this.dayNightRbutton.AutoSize = true;
            this.dayNightRbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.dayNightRbutton.Location = new System.Drawing.Point(3, 113);
            this.dayNightRbutton.Name = "dayNightRbutton";
            this.dayNightRbutton.Size = new System.Drawing.Size(213, 30);
            this.dayNightRbutton.TabIndex = 6;
            this.dayNightRbutton.Text = "Day-night transition";
            this.dayNightRbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dayNightRbutton.UseVisualStyleBackColor = true;
            this.dayNightRbutton.Click += new System.EventHandler(this.optionsRbutton_Click);
            // 
            // fogRbutton
            // 
            this.fogRbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.fogRbutton.AutoCheck = false;
            this.fogRbutton.AutoSize = true;
            this.fogRbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.fogRbutton.Location = new System.Drawing.Point(3, 83);
            this.fogRbutton.Name = "fogRbutton";
            this.fogRbutton.Size = new System.Drawing.Size(213, 30);
            this.fogRbutton.TabIndex = 5;
            this.fogRbutton.Text = "Fog";
            this.fogRbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fogRbutton.UseVisualStyleBackColor = true;
            this.fogRbutton.Click += new System.EventHandler(this.optionsRbutton_Click);
            // 
            // tremorRbutton
            // 
            this.tremorRbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.tremorRbutton.AutoCheck = false;
            this.tremorRbutton.AutoSize = true;
            this.tremorRbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.tremorRbutton.Location = new System.Drawing.Point(3, 53);
            this.tremorRbutton.Name = "tremorRbutton";
            this.tremorRbutton.Size = new System.Drawing.Size(213, 30);
            this.tremorRbutton.TabIndex = 4;
            this.tremorRbutton.Text = "Tremor";
            this.tremorRbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tremorRbutton.UseVisualStyleBackColor = true;
            this.tremorRbutton.Click += new System.EventHandler(this.optionsRbutton_Click);
            // 
            // animationRbutton
            // 
            this.animationRbutton.Appearance = System.Windows.Forms.Appearance.Button;
            this.animationRbutton.AutoCheck = false;
            this.animationRbutton.AutoSize = true;
            this.animationRbutton.Checked = true;
            this.animationRbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.animationRbutton.Location = new System.Drawing.Point(3, 23);
            this.animationRbutton.Name = "animationRbutton";
            this.animationRbutton.Size = new System.Drawing.Size(213, 30);
            this.animationRbutton.TabIndex = 3;
            this.animationRbutton.TabStop = true;
            this.animationRbutton.Text = "Animation";
            this.animationRbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.animationRbutton.UseVisualStyleBackColor = true;
            this.animationRbutton.Click += new System.EventHandler(this.optionsRbutton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3D scene renderer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.cameraGbox.ResumeLayout(false);
            this.cameraGbox.PerformLayout();
            this.shadingGbox.ResumeLayout(false);
            this.shadingGbox.PerformLayout();
            this.optionsGbox.ResumeLayout(false);
            this.optionsGbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer;
        private PictureBox canvas;
        private TableLayoutPanel tableLayoutPanel;
        private GroupBox cameraGbox;
        private RadioButton camera3Rbutton;
        private RadioButton camera2Rbutton;
        private RadioButton camera1Rbutton;
        private GroupBox shadingGbox;
        private RadioButton phongsShadingRbutton;
        private RadioButton gouraudsShadingRbutton;
        private RadioButton solidShadingRbutton;
        private GroupBox optionsGbox;
        private RadioButton dayNightRbutton;
        private RadioButton fogRbutton;
        private RadioButton tremorRbutton;
        private RadioButton animationRbutton;
    }
}