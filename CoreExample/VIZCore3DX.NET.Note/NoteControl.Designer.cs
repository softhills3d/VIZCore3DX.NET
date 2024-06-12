namespace VIZCore3DX.NET.Note
{
    partial class NoteControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteControl));
            this.listViewNotes = new System.Windows.Forms.ListView();
            this.imageListNoteType = new System.Windows.Forms.ImageList(this.components);
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnShown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewNotes
            // 
            this.listViewNotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnType,
            this.columnText,
            this.columnShown});
            this.listViewNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewNotes.FullRowSelect = true;
            this.listViewNotes.HideSelection = false;
            this.listViewNotes.Location = new System.Drawing.Point(0, 0);
            this.listViewNotes.Name = "listViewNotes";
            this.listViewNotes.Size = new System.Drawing.Size(346, 599);
            this.listViewNotes.SmallImageList = this.imageListNoteType;
            this.listViewNotes.TabIndex = 0;
            this.listViewNotes.UseCompatibleStateImageBehavior = false;
            this.listViewNotes.View = System.Windows.Forms.View.Details;
            this.listViewNotes.SelectedIndexChanged += new System.EventHandler(this.listViewNotes_SelectedIndexChanged);
            this.listViewNotes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewNotes_MouseDoubleClick);
            // 
            // imageListNoteType
            // 
            this.imageListNoteType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListNoteType.ImageStream")));
            this.imageListNoteType.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListNoteType.Images.SetKeyName(0, "NOTESURFACE_16x16.png");
            this.imageListNoteType.Images.SetKeyName(1, "NOTE3D_16x16.png");
            this.imageListNoteType.Images.SetKeyName(2, "NOTE2D_16x16.png");
            // 
            // columnType
            // 
            this.columnType.Text = "타입";
            // 
            // columnText
            // 
            this.columnText.Text = "텍스트";
            this.columnText.Width = 160;
            // 
            // columnShown
            // 
            this.columnShown.Text = "가시화";
            this.columnShown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnShown.Width = 50;
            // 
            // NoteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewNotes);
            this.Name = "NoteControl";
            this.Size = new System.Drawing.Size(346, 599);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewNotes;
        private System.Windows.Forms.ImageList imageListNoteType;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnText;
        private System.Windows.Forms.ColumnHeader columnShown;
    }
}
