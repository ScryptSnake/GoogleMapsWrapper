namespace ExampleProject
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lbGeocodeRequests = new ListBox();
            label6 = new Label();
            tbGeocodeResponse = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tbGeocode = new TextBox();
            lbGeocodeResults = new ListBox();
            bGeocodeExecute = new Button();
            tabPage2 = new TabPage();
            bClearMarkers = new Button();
            cbConvertPolyline = new CheckBox();
            label12 = new Label();
            cbZoom = new ComboBox();
            panColor = new Panel();
            label11 = new Label();
            bAddMarker = new Button();
            label10 = new Label();
            lbMarkers = new ListBox();
            label9 = new Label();
            cbMapType = new ComboBox();
            bGenerateMap = new Button();
            label8 = new Label();
            lbStaticRequest = new ListBox();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            lbError = new Label();
            progBar = new ProgressBar();
            colorDialog1 = new ColorDialog();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.ItemSize = new Size(120, 25);
            tabControl1.Location = new Point(0, 43);
            tabControl1.MinimumSize = new Size(960, 593);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(984, 593);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Silver;
            tabPage1.Controls.Add(lbGeocodeRequests);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(tbGeocodeResponse);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(tbGeocode);
            tabPage1.Controls.Add(lbGeocodeResults);
            tabPage1.Controls.Add(bGeocodeExecute);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(976, 560);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "GeocodeApi";
            // 
            // lbGeocodeRequests
            // 
            lbGeocodeRequests.FormattingEnabled = true;
            lbGeocodeRequests.HorizontalScrollbar = true;
            lbGeocodeRequests.ItemHeight = 15;
            lbGeocodeRequests.Location = new Point(502, 297);
            lbGeocodeRequests.Name = "lbGeocodeRequests";
            lbGeocodeRequests.Size = new Size(420, 64);
            lbGeocodeRequests.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(502, 278);
            label6.Name = "label6";
            label6.Size = new Size(107, 13);
            label6.TabIndex = 10;
            label6.Text = "Api Request URI(s):";
            // 
            // tbGeocodeResponse
            // 
            tbGeocodeResponse.Location = new Point(502, 380);
            tbGeocodeResponse.Multiline = true;
            tbGeocodeResponse.Name = "tbGeocodeResponse";
            tbGeocodeResponse.ScrollBars = ScrollBars.Both;
            tbGeocodeResponse.Size = new Size(420, 167);
            tbGeocodeResponse.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(502, 364);
            label5.Name = "label5";
            label5.Size = new Size(94, 13);
            label5.TabIndex = 7;
            label5.Text = "Api Response(s):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(502, 23);
            label4.Name = "label4";
            label4.Size = new Size(47, 13);
            label4.TabIndex = 6;
            label4.Text = "Results:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(29, 23);
            label3.Name = "label3";
            label3.Size = new Size(362, 52);
            label3.TabIndex = 4;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(47, 143);
            label2.Name = "label2";
            label2.Size = new Size(143, 17);
            label2.TabIndex = 3;
            label2.Text = "Enter GPS Coordinates:";
            // 
            // tbGeocode
            // 
            tbGeocode.Location = new Point(47, 172);
            tbGeocode.Name = "tbGeocode";
            tbGeocode.Size = new Size(216, 23);
            tbGeocode.TabIndex = 2;
            // 
            // lbGeocodeResults
            // 
            lbGeocodeResults.FormattingEnabled = true;
            lbGeocodeResults.ItemHeight = 15;
            lbGeocodeResults.Location = new Point(502, 39);
            lbGeocodeResults.Name = "lbGeocodeResults";
            lbGeocodeResults.Size = new Size(420, 229);
            lbGeocodeResults.TabIndex = 1;
            // 
            // bGeocodeExecute
            // 
            bGeocodeExecute.BackColor = Color.LightSkyBlue;
            bGeocodeExecute.Location = new Point(47, 201);
            bGeocodeExecute.Name = "bGeocodeExecute";
            bGeocodeExecute.Size = new Size(216, 23);
            bGeocodeExecute.TabIndex = 0;
            bGeocodeExecute.Text = "Execute";
            bGeocodeExecute.UseVisualStyleBackColor = false;
            bGeocodeExecute.Click += bGeocodeExecute_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Gainsboro;
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Controls.Add(bClearMarkers);
            tabPage2.Controls.Add(cbConvertPolyline);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(cbZoom);
            tabPage2.Controls.Add(panColor);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(bAddMarker);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(lbMarkers);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(cbMapType);
            tabPage2.Controls.Add(bGenerateMap);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(lbStaticRequest);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(976, 560);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "StaticMapApi";
            // 
            // bClearMarkers
            // 
            bClearMarkers.Location = new Point(18, 481);
            bClearMarkers.Name = "bClearMarkers";
            bClearMarkers.Size = new Size(75, 23);
            bClearMarkers.TabIndex = 27;
            bClearMarkers.Text = "Clear";
            bClearMarkers.UseVisualStyleBackColor = true;
            bClearMarkers.Click += bClearMarkers_Click;
            // 
            // cbConvertPolyline
            // 
            cbConvertPolyline.AutoSize = true;
            cbConvertPolyline.Location = new Point(275, 363);
            cbConvertPolyline.Name = "cbConvertPolyline";
            cbConvertPolyline.Size = new Size(127, 19);
            cbConvertPolyline.TabIndex = 26;
            cbConvertPolyline.Text = "Convert to Polyline";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ActiveCaptionText;
            label12.Location = new Point(16, 134);
            label12.Name = "label12";
            label12.Size = new Size(39, 13);
            label12.TabIndex = 25;
            label12.Text = "Zoom:";
            // 
            // cbZoom
            // 
            cbZoom.FormattingEnabled = true;
            cbZoom.Location = new Point(16, 150);
            cbZoom.Name = "cbZoom";
            cbZoom.Size = new Size(109, 23);
            cbZoom.TabIndex = 24;
            // 
            // panColor
            // 
            panColor.BorderStyle = BorderStyle.FixedSingle;
            panColor.Location = new Point(40, 202);
            panColor.Name = "panColor";
            panColor.Size = new Size(26, 22);
            panColor.TabIndex = 23;
            panColor.DoubleClick += panColor_DoubleClick;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ActiveCaptionText;
            label11.Location = new Point(16, 186);
            label11.Name = "label11";
            label11.Size = new Size(77, 13);
            label11.TabIndex = 22;
            label11.Text = "Marker Color:";
            // 
            // bAddMarker
            // 
            bAddMarker.Location = new Point(170, 481);
            bAddMarker.Name = "bAddMarker";
            bAddMarker.Size = new Size(75, 23);
            bAddMarker.TabIndex = 20;
            bAddMarker.Text = "Add";
            bAddMarker.UseVisualStyleBackColor = true;
            bAddMarker.Click += bAddMarker_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.ActiveCaptionText;
            label10.Location = new Point(16, 240);
            label10.Name = "label10";
            label10.Size = new Size(75, 13);
            label10.TabIndex = 19;
            label10.Text = "Add Markers:";
            // 
            // lbMarkers
            // 
            lbMarkers.FormattingEnabled = true;
            lbMarkers.HorizontalScrollbar = true;
            lbMarkers.ItemHeight = 15;
            lbMarkers.Location = new Point(16, 256);
            lbMarkers.Name = "lbMarkers";
            lbMarkers.Size = new Size(229, 229);
            lbMarkers.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(16, 92);
            label9.Name = "label9";
            label9.Size = new Size(59, 13);
            label9.TabIndex = 17;
            label9.Text = "Map Type:";
            // 
            // cbMapType
            // 
            cbMapType.FormattingEnabled = true;
            cbMapType.Location = new Point(16, 108);
            cbMapType.Name = "cbMapType";
            cbMapType.Size = new Size(229, 23);
            cbMapType.TabIndex = 16;
            // 
            // bGenerateMap
            // 
            bGenerateMap.BackColor = Color.LightSkyBlue;
            bGenerateMap.Location = new Point(16, 519);
            bGenerateMap.Name = "bGenerateMap";
            bGenerateMap.Size = new Size(447, 23);
            bGenerateMap.TabIndex = 15;
            bGenerateMap.Text = "Generate Map";
            bGenerateMap.UseVisualStyleBackColor = false;
            bGenerateMap.Click += bGenerateMap_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(16, 18);
            label8.Name = "label8";
            label8.Size = new Size(285, 52);
            label8.TabIndex = 14;
            label8.Text = resources.GetString("label8.Text");
            // 
            // lbStaticRequest
            // 
            lbStaticRequest.FormattingEnabled = true;
            lbStaticRequest.HorizontalScrollbar = true;
            lbStaticRequest.ItemHeight = 15;
            lbStaticRequest.Location = new Point(482, 22);
            lbStaticRequest.Name = "lbStaticRequest";
            lbStaticRequest.Size = new Size(450, 64);
            lbStaticRequest.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(482, 3);
            label7.Name = "label7";
            label7.Size = new Size(107, 13);
            label7.TabIndex = 12;
            label7.Text = "Api Request URI(s):";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Gray;
            pictureBox1.Location = new Point(482, 92);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(450, 450);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("OCR A Extended", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(278, 17);
            label1.TabIndex = 1;
            label1.Text = "GoogleMapsWrapper  Demo App";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSteelBlue;
            panel1.Controls.Add(lbError);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 43);
            panel1.TabIndex = 4;
            // 
            // lbError
            // 
            lbError.AutoSize = true;
            lbError.BackColor = SystemColors.ActiveCaptionText;
            lbError.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbError.ForeColor = Color.IndianRed;
            lbError.Location = new Point(364, 15);
            lbError.Name = "lbError";
            lbError.Size = new Size(43, 13);
            lbError.TabIndex = 2;
            lbError.Text = "tbError";
            // 
            // progBar
            // 
            progBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            progBar.Location = new Point(12, 638);
            progBar.MarqueeAnimationSpeed = 30;
            progBar.Name = "progBar";
            progBar.Size = new Size(960, 15);
            progBar.Step = 15;
            progBar.Style = ProgressBarStyle.Marquee;
            progBar.TabIndex = 11;
            progBar.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(984, 654);
            Controls.Add(progBar);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "GoogleMapsWrapper by ScryptSnake";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Panel panel1;
        private TextBox tbGeocode;
        private ListBox lbGeocodeResults;
        private Button bGeocodeExecute;
        private Label label2;
        private Label label3;
        private Label lbError;
        private Label label4;
        private Label label5;
        private TextBox tbGeocodeResponse;
        private Label label6;
        private ProgressBar progBar;
        private ListBox lbGeocodeRequests;
        private PictureBox pictureBox1;
        private Button bGenerateMap;
        private Label label8;
        private ListBox lbStaticRequest;
        private Label label7;
        private ComboBox cbMapType;
        private Label label9;
        private ColorDialog colorDialog1;
        private Label label10;
        private ListBox lbMarkers;
        private Button bAddMarker;
        private Label label11;
        private Panel panColor;
        private Label label12;
        private ComboBox cbZoom;
        private CheckBox cbConvertPolyline;
        private Button bClearMarkers;
    }
}
