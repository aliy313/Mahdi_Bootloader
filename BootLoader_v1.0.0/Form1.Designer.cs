namespace BootLoader_v1._0._0
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_com = new System.Windows.Forms.Label();
            this.prgrs_progress = new System.Windows.Forms.ProgressBar();
            this.ckb_bootlockbit_app_read = new System.Windows.Forms.CheckBox();
            this.grp_lockbits = new System.Windows.Forms.GroupBox();
            this.ckb_lockbit_read_write = new System.Windows.Forms.CheckBox();
            this.btn_lock_write = new System.Windows.Forms.Button();
            this.btn_lock_read = new System.Windows.Forms.Button();
            this.ckb_lockbit_write = new System.Windows.Forms.CheckBox();
            this.ckb_bootlockbit_boot_write = new System.Windows.Forms.CheckBox();
            this.ckb_bootlockbit_boot_read = new System.Windows.Forms.CheckBox();
            this.ckb_bootlockbit_app_write = new System.Windows.Forms.CheckBox();
            this.grp_fusebits = new System.Windows.Forms.GroupBox();
            this.btn_fuse_read = new System.Windows.Forms.Button();
            this.ckb_fusebit_h1 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_h2 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_h3 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_h4 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_h5 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_h6 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_h7 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_h8 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_l1 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_l2 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_l3 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_l4 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_l5 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_l6 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_l7 = new System.Windows.Forms.CheckBox();
            this.ckb_fusebit_l8 = new System.Windows.Forms.CheckBox();
            this.grp_flash = new System.Windows.Forms.GroupBox();
            this.btn_open_flash = new System.Windows.Forms.Button();
            this.btn_save_flash = new System.Windows.Forms.Button();
            this.txt_open_path_flash = new System.Windows.Forms.TextBox();
            this.txt_save_path_flash = new System.Windows.Forms.TextBox();
            this.btn_flash_erase = new System.Windows.Forms.Button();
            this.btn_flash_verify = new System.Windows.Forms.Button();
            this.btn_flash_write = new System.Windows.Forms.Button();
            this.btn_flash_read = new System.Windows.Forms.Button();
            this.lbl_mcu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grp_mcu = new System.Windows.Forms.GroupBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.grp_eeprom = new System.Windows.Forms.GroupBox();
            this.btn_eeprom_erase = new System.Windows.Forms.Button();
            this.btn_eeprom_verify = new System.Windows.Forms.Button();
            this.btn_eeprom_write = new System.Windows.Forms.Button();
            this.txt_open_path_eeprom = new System.Windows.Forms.TextBox();
            this.btn_eeprom_read = new System.Windows.Forms.Button();
            this.txt_save_path_eeprom = new System.Windows.Forms.TextBox();
            this.btn_open_eeprom = new System.Windows.Forms.Button();
            this.btn_save_eeprom = new System.Windows.Forms.Button();
            this.grp_power = new System.Windows.Forms.GroupBox();
            this.btn_sleep = new System.Windows.Forms.Button();
            this.btn_reset_app = new System.Windows.Forms.Button();
            this.ckb_auto_reset_after_write_flash = new System.Windows.Forms.CheckBox();
            this.ckb_erase_flash_before_write_flash = new System.Windows.Forms.CheckBox();
            this.ckb_lock_app_read_after_read_flash = new System.Windows.Forms.CheckBox();
            this.ckb_lock_app_write_after_write_flash = new System.Windows.Forms.CheckBox();
            this.ckb_erase_e2prom_before_write_flash = new System.Windows.Forms.CheckBox();
            this.ckb_verify_after_flash_write = new System.Windows.Forms.CheckBox();
            this.ckb_ignore_lockbits_while_write_flash = new System.Windows.Forms.CheckBox();
            this.tab_settings = new System.Windows.Forms.TabControl();
            this.tab_flash = new System.Windows.Forms.TabPage();
            this.lbl_file_type_flash = new System.Windows.Forms.Label();
            this.cmb_file_type_flash = new System.Windows.Forms.ComboBox();
            this.ckb_auto_reset_after_read_flash = new System.Windows.Forms.CheckBox();
            this.tab_e2prom = new System.Windows.Forms.TabPage();
            this.ckb_ignore_0xFF_for_e2prom_erase = new System.Windows.Forms.CheckBox();
            this.ckb_ignore_oxFF_for_e2prom_write = new System.Windows.Forms.CheckBox();
            this.ckb_ignore_0xFF_for_e2prom_read = new System.Windows.Forms.CheckBox();
            this.lbl_file_type_e2prom = new System.Windows.Forms.Label();
            this.cmb_file_type_e2prom = new System.Windows.Forms.ComboBox();
            this.ckb_auto_reset_after_e2prom_write = new System.Windows.Forms.CheckBox();
            this.ckb_auto_reset_after_e2prom_read = new System.Windows.Forms.CheckBox();
            this.ckb_erase_e2prom_before_write_e2prom = new System.Windows.Forms.CheckBox();
            this.tab_connection = new System.Windows.Forms.TabPage();
            this.ckb_ignore_buildnumber = new System.Windows.Forms.CheckBox();
            this.lbl_stopbits = new System.Windows.Forms.Label();
            this.cmb_stopbits = new System.Windows.Forms.ComboBox();
            this.lbl_parity = new System.Windows.Forms.Label();
            this.cmb_parity = new System.Windows.Forms.ComboBox();
            this.lbl_timeout = new System.Windows.Forms.Label();
            this.cmb_timeout = new System.Windows.Forms.ComboBox();
            this.lbl_baudrate = new System.Windows.Forms.Label();
            this.cmb_baudrate = new System.Windows.Forms.ComboBox();
            this.lbl_port = new System.Windows.Forms.Label();
            this.cmb_port = new System.Windows.Forms.ComboBox();
            this.tab_logs = new System.Windows.Forms.TabPage();
            this.btn_save_log_to_file = new System.Windows.Forms.Button();
            this.btn_clear_logs = new System.Windows.Forms.Button();
            this.lbl_log_level = new System.Windows.Forms.Label();
            this.cmb_log_level = new System.Windows.Forms.ComboBox();
            this.tab_backup_restore = new System.Windows.Forms.TabPage();
            this.btn_save_now = new System.Windows.Forms.Button();
            this.btn_export_settings = new System.Windows.Forms.Button();
            this.lbl_save_mode_settings = new System.Windows.Forms.Label();
            this.cmb_save_mode_settings = new System.Windows.Forms.ComboBox();
            this.btn_restore_default_settings = new System.Windows.Forms.Button();
            this.btn_import_settings = new System.Windows.Forms.Button();
            this.tab_about = new System.Windows.Forms.TabPage();
            this.lbl_thanks = new System.Windows.Forms.Label();
            this.lbl_compile_time = new System.Windows.Forms.Label();
            this.lbl_mcu_code = new System.Windows.Forms.Label();
            this.lbl_client_app = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_bootloader_author = new System.Windows.Forms.Label();
            this.lbl_bootloader_name_version = new System.Windows.Forms.Label();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.grp_lockbits.SuspendLayout();
            this.grp_fusebits.SuspendLayout();
            this.grp_flash.SuspendLayout();
            this.grp_mcu.SuspendLayout();
            this.grp_eeprom.SuspendLayout();
            this.grp_power.SuspendLayout();
            this.tab_settings.SuspendLayout();
            this.tab_flash.SuspendLayout();
            this.tab_e2prom.SuspendLayout();
            this.tab_connection.SuspendLayout();
            this.tab_logs.SuspendLayout();
            this.tab_backup_restore.SuspendLayout();
            this.tab_about.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_status
            // 
            this.lbl_status.BackColor = System.Drawing.Color.White;
            this.lbl_status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_status.Font = new System.Drawing.Font("Unispace", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_status.ForeColor = System.Drawing.Color.White;
            this.lbl_status.Location = new System.Drawing.Point(18, 12);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(109, 79);
            this.lbl_status.TabIndex = 0;
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_com
            // 
            this.lbl_com.BackColor = System.Drawing.Color.White;
            this.lbl_com.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_com.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_com.ForeColor = System.Drawing.Color.Green;
            this.lbl_com.Location = new System.Drawing.Point(42, 97);
            this.lbl_com.Name = "lbl_com";
            this.lbl_com.Size = new System.Drawing.Size(59, 26);
            this.lbl_com.TabIndex = 1;
            this.lbl_com.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prgrs_progress
            // 
            this.prgrs_progress.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.prgrs_progress.Location = new System.Drawing.Point(12, 129);
            this.prgrs_progress.Name = "prgrs_progress";
            this.prgrs_progress.Size = new System.Drawing.Size(493, 23);
            this.prgrs_progress.Step = 1;
            this.prgrs_progress.TabIndex = 2;
            // 
            // ckb_bootlockbit_app_read
            // 
            this.ckb_bootlockbit_app_read.AutoSize = true;
            this.ckb_bootlockbit_app_read.Enabled = false;
            this.ckb_bootlockbit_app_read.Location = new System.Drawing.Point(100, 18);
            this.ckb_bootlockbit_app_read.Name = "ckb_bootlockbit_app_read";
            this.ckb_bootlockbit_app_read.Size = new System.Drawing.Size(77, 19);
            this.ckb_bootlockbit_app_read.TabIndex = 4;
            this.ckb_bootlockbit_app_read.Text = "App Read";
            this.ckb_bootlockbit_app_read.UseVisualStyleBackColor = true;
            this.ckb_bootlockbit_app_read.Click += new System.EventHandler(this.ckb_bootlockbit_app_read_Click);
            // 
            // grp_lockbits
            // 
            this.grp_lockbits.Controls.Add(this.ckb_lockbit_read_write);
            this.grp_lockbits.Controls.Add(this.btn_lock_write);
            this.grp_lockbits.Controls.Add(this.btn_lock_read);
            this.grp_lockbits.Controls.Add(this.ckb_lockbit_write);
            this.grp_lockbits.Controls.Add(this.ckb_bootlockbit_boot_write);
            this.grp_lockbits.Controls.Add(this.ckb_bootlockbit_boot_read);
            this.grp_lockbits.Controls.Add(this.ckb_bootlockbit_app_write);
            this.grp_lockbits.Controls.Add(this.ckb_bootlockbit_app_read);
            this.grp_lockbits.Location = new System.Drawing.Point(511, 240);
            this.grp_lockbits.Name = "grp_lockbits";
            this.grp_lockbits.Size = new System.Drawing.Size(351, 74);
            this.grp_lockbits.TabIndex = 5;
            this.grp_lockbits.TabStop = false;
            this.grp_lockbits.Text = "LockBits";
            // 
            // ckb_lockbit_read_write
            // 
            this.ckb_lockbit_read_write.AutoSize = true;
            this.ckb_lockbit_read_write.Enabled = false;
            this.ckb_lockbit_read_write.Location = new System.Drawing.Point(6, 43);
            this.ckb_lockbit_read_write.Name = "ckb_lockbit_read_write";
            this.ckb_lockbit_read_write.Size = new System.Drawing.Size(80, 19);
            this.ckb_lockbit_read_write.TabIndex = 6;
            this.ckb_lockbit_read_write.Text = "No Action";
            this.ckb_lockbit_read_write.UseVisualStyleBackColor = true;
            // 
            // btn_lock_write
            // 
            this.btn_lock_write.Enabled = false;
            this.btn_lock_write.Location = new System.Drawing.Point(270, 41);
            this.btn_lock_write.Name = "btn_lock_write";
            this.btn_lock_write.Size = new System.Drawing.Size(75, 23);
            this.btn_lock_write.TabIndex = 24;
            this.btn_lock_write.Text = "Write";
            this.btn_lock_write.UseVisualStyleBackColor = true;
            this.btn_lock_write.Click += new System.EventHandler(this.btn_bootlock_write_Click);
            // 
            // btn_lock_read
            // 
            this.btn_lock_read.Enabled = false;
            this.btn_lock_read.Location = new System.Drawing.Point(270, 15);
            this.btn_lock_read.Name = "btn_lock_read";
            this.btn_lock_read.Size = new System.Drawing.Size(75, 23);
            this.btn_lock_read.TabIndex = 23;
            this.btn_lock_read.Text = "Read";
            this.btn_lock_read.UseVisualStyleBackColor = true;
            this.btn_lock_read.Click += new System.EventHandler(this.btn_lock_read_Click);
            // 
            // ckb_lockbit_write
            // 
            this.ckb_lockbit_write.AutoSize = true;
            this.ckb_lockbit_write.Enabled = false;
            this.ckb_lockbit_write.Location = new System.Drawing.Point(6, 18);
            this.ckb_lockbit_write.Name = "ckb_lockbit_write";
            this.ckb_lockbit_write.Size = new System.Drawing.Size(80, 19);
            this.ckb_lockbit_write.TabIndex = 5;
            this.ckb_lockbit_write.Text = "Read Only";
            this.ckb_lockbit_write.UseVisualStyleBackColor = true;
            // 
            // ckb_bootlockbit_boot_write
            // 
            this.ckb_bootlockbit_boot_write.AutoSize = true;
            this.ckb_bootlockbit_boot_write.Enabled = false;
            this.ckb_bootlockbit_boot_write.Location = new System.Drawing.Point(183, 44);
            this.ckb_bootlockbit_boot_write.Name = "ckb_bootlockbit_boot_write";
            this.ckb_bootlockbit_boot_write.Size = new System.Drawing.Size(82, 19);
            this.ckb_bootlockbit_boot_write.TabIndex = 7;
            this.ckb_bootlockbit_boot_write.Text = "Boot Write";
            this.ckb_bootlockbit_boot_write.UseVisualStyleBackColor = true;
            // 
            // ckb_bootlockbit_boot_read
            // 
            this.ckb_bootlockbit_boot_read.AutoSize = true;
            this.ckb_bootlockbit_boot_read.Enabled = false;
            this.ckb_bootlockbit_boot_read.Location = new System.Drawing.Point(183, 18);
            this.ckb_bootlockbit_boot_read.Name = "ckb_bootlockbit_boot_read";
            this.ckb_bootlockbit_boot_read.Size = new System.Drawing.Size(80, 19);
            this.ckb_bootlockbit_boot_read.TabIndex = 6;
            this.ckb_bootlockbit_boot_read.Text = "Boot Read";
            this.ckb_bootlockbit_boot_read.UseVisualStyleBackColor = true;
            // 
            // ckb_bootlockbit_app_write
            // 
            this.ckb_bootlockbit_app_write.AutoSize = true;
            this.ckb_bootlockbit_app_write.Enabled = false;
            this.ckb_bootlockbit_app_write.Location = new System.Drawing.Point(100, 44);
            this.ckb_bootlockbit_app_write.Name = "ckb_bootlockbit_app_write";
            this.ckb_bootlockbit_app_write.Size = new System.Drawing.Size(79, 19);
            this.ckb_bootlockbit_app_write.TabIndex = 5;
            this.ckb_bootlockbit_app_write.Text = "App Write";
            this.ckb_bootlockbit_app_write.UseVisualStyleBackColor = true;
            this.ckb_bootlockbit_app_write.Click += new System.EventHandler(this.ckb_bootlockbit_app_write_Click);
            // 
            // grp_fusebits
            // 
            this.grp_fusebits.BackColor = System.Drawing.Color.AliceBlue;
            this.grp_fusebits.Controls.Add(this.btn_fuse_read);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_h1);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_h2);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_h3);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_h4);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_h5);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_h6);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_h7);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_h8);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_l1);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_l2);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_l3);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_l4);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_l5);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_l6);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_l7);
            this.grp_fusebits.Controls.Add(this.ckb_fusebit_l8);
            this.grp_fusebits.Location = new System.Drawing.Point(511, 12);
            this.grp_fusebits.Name = "grp_fusebits";
            this.grp_fusebits.Size = new System.Drawing.Size(351, 222);
            this.grp_fusebits.TabIndex = 5;
            this.grp_fusebits.TabStop = false;
            this.grp_fusebits.Text = "FuseBits";
            // 
            // btn_fuse_read
            // 
            this.btn_fuse_read.Enabled = false;
            this.btn_fuse_read.Location = new System.Drawing.Point(270, 96);
            this.btn_fuse_read.Name = "btn_fuse_read";
            this.btn_fuse_read.Size = new System.Drawing.Size(75, 23);
            this.btn_fuse_read.TabIndex = 6;
            this.btn_fuse_read.Text = "Read";
            this.btn_fuse_read.UseVisualStyleBackColor = true;
            this.btn_fuse_read.Click += new System.EventHandler(this.btn_fuse_read_Click);
            // 
            // ckb_fusebit_h1
            // 
            this.ckb_fusebit_h1.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_h1.Enabled = false;
            this.ckb_fusebit_h1.Location = new System.Drawing.Point(143, 196);
            this.ckb_fusebit_h1.Name = "ckb_fusebit_h1";
            this.ckb_fusebit_h1.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_h1.TabIndex = 22;
            this.ckb_fusebit_h1.Text = "FuseBit_h1";
            this.ckb_fusebit_h1.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_h2
            // 
            this.ckb_fusebit_h2.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_h2.Enabled = false;
            this.ckb_fusebit_h2.Location = new System.Drawing.Point(143, 171);
            this.ckb_fusebit_h2.Name = "ckb_fusebit_h2";
            this.ckb_fusebit_h2.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_h2.TabIndex = 18;
            this.ckb_fusebit_h2.Text = "FuseBit_h2";
            this.ckb_fusebit_h2.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_h3
            // 
            this.ckb_fusebit_h3.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_h3.Enabled = false;
            this.ckb_fusebit_h3.Location = new System.Drawing.Point(143, 146);
            this.ckb_fusebit_h3.Name = "ckb_fusebit_h3";
            this.ckb_fusebit_h3.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_h3.TabIndex = 21;
            this.ckb_fusebit_h3.Text = "FuseBit_h3";
            this.ckb_fusebit_h3.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_h4
            // 
            this.ckb_fusebit_h4.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_h4.Enabled = false;
            this.ckb_fusebit_h4.Location = new System.Drawing.Point(143, 121);
            this.ckb_fusebit_h4.Name = "ckb_fusebit_h4";
            this.ckb_fusebit_h4.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_h4.TabIndex = 20;
            this.ckb_fusebit_h4.Text = "FuseBit_h4";
            this.ckb_fusebit_h4.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_h5
            // 
            this.ckb_fusebit_h5.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_h5.Enabled = false;
            this.ckb_fusebit_h5.Location = new System.Drawing.Point(143, 96);
            this.ckb_fusebit_h5.Name = "ckb_fusebit_h5";
            this.ckb_fusebit_h5.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_h5.TabIndex = 16;
            this.ckb_fusebit_h5.Text = "FuseBit_h5";
            this.ckb_fusebit_h5.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_h6
            // 
            this.ckb_fusebit_h6.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_h6.Enabled = false;
            this.ckb_fusebit_h6.Location = new System.Drawing.Point(143, 71);
            this.ckb_fusebit_h6.Name = "ckb_fusebit_h6";
            this.ckb_fusebit_h6.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_h6.TabIndex = 19;
            this.ckb_fusebit_h6.Text = "FuseBit_h6";
            this.ckb_fusebit_h6.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_h7
            // 
            this.ckb_fusebit_h7.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_h7.Enabled = false;
            this.ckb_fusebit_h7.Location = new System.Drawing.Point(143, 46);
            this.ckb_fusebit_h7.Name = "ckb_fusebit_h7";
            this.ckb_fusebit_h7.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_h7.TabIndex = 17;
            this.ckb_fusebit_h7.Text = "FuseBit_h7";
            this.ckb_fusebit_h7.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_h8
            // 
            this.ckb_fusebit_h8.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_h8.Enabled = false;
            this.ckb_fusebit_h8.Location = new System.Drawing.Point(143, 22);
            this.ckb_fusebit_h8.Name = "ckb_fusebit_h8";
            this.ckb_fusebit_h8.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_h8.TabIndex = 15;
            this.ckb_fusebit_h8.Text = "FuseBit_h8";
            this.ckb_fusebit_h8.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_l1
            // 
            this.ckb_fusebit_l1.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_l1.Enabled = false;
            this.ckb_fusebit_l1.Location = new System.Drawing.Point(6, 196);
            this.ckb_fusebit_l1.Name = "ckb_fusebit_l1";
            this.ckb_fusebit_l1.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_l1.TabIndex = 14;
            this.ckb_fusebit_l1.Text = "FuseBit_l1";
            this.ckb_fusebit_l1.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_l2
            // 
            this.ckb_fusebit_l2.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_l2.Enabled = false;
            this.ckb_fusebit_l2.Location = new System.Drawing.Point(6, 171);
            this.ckb_fusebit_l2.Name = "ckb_fusebit_l2";
            this.ckb_fusebit_l2.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_l2.TabIndex = 8;
            this.ckb_fusebit_l2.Text = "FuseBit_l2";
            this.ckb_fusebit_l2.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_l3
            // 
            this.ckb_fusebit_l3.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_l3.Enabled = false;
            this.ckb_fusebit_l3.Location = new System.Drawing.Point(6, 146);
            this.ckb_fusebit_l3.Name = "ckb_fusebit_l3";
            this.ckb_fusebit_l3.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_l3.TabIndex = 13;
            this.ckb_fusebit_l3.Text = "FuseBit_l3";
            this.ckb_fusebit_l3.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_l4
            // 
            this.ckb_fusebit_l4.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_l4.Enabled = false;
            this.ckb_fusebit_l4.Location = new System.Drawing.Point(6, 121);
            this.ckb_fusebit_l4.Name = "ckb_fusebit_l4";
            this.ckb_fusebit_l4.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_l4.TabIndex = 12;
            this.ckb_fusebit_l4.Text = "FuseBit_l4";
            this.ckb_fusebit_l4.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_l5
            // 
            this.ckb_fusebit_l5.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_l5.Enabled = false;
            this.ckb_fusebit_l5.Location = new System.Drawing.Point(6, 96);
            this.ckb_fusebit_l5.Name = "ckb_fusebit_l5";
            this.ckb_fusebit_l5.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_l5.TabIndex = 7;
            this.ckb_fusebit_l5.Text = "FuseBit_l5";
            this.ckb_fusebit_l5.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_l6
            // 
            this.ckb_fusebit_l6.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_l6.Enabled = false;
            this.ckb_fusebit_l6.Location = new System.Drawing.Point(6, 71);
            this.ckb_fusebit_l6.Name = "ckb_fusebit_l6";
            this.ckb_fusebit_l6.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_l6.TabIndex = 8;
            this.ckb_fusebit_l6.Text = "FuseBit_l6";
            this.ckb_fusebit_l6.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_l7
            // 
            this.ckb_fusebit_l7.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_l7.Enabled = false;
            this.ckb_fusebit_l7.Location = new System.Drawing.Point(6, 46);
            this.ckb_fusebit_l7.Name = "ckb_fusebit_l7";
            this.ckb_fusebit_l7.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_l7.TabIndex = 7;
            this.ckb_fusebit_l7.Text = "FuseBit_l7";
            this.ckb_fusebit_l7.UseVisualStyleBackColor = false;
            // 
            // ckb_fusebit_l8
            // 
            this.ckb_fusebit_l8.BackColor = System.Drawing.Color.AliceBlue;
            this.ckb_fusebit_l8.Enabled = false;
            this.ckb_fusebit_l8.Location = new System.Drawing.Point(6, 22);
            this.ckb_fusebit_l8.Name = "ckb_fusebit_l8";
            this.ckb_fusebit_l8.Size = new System.Drawing.Size(118, 19);
            this.ckb_fusebit_l8.TabIndex = 6;
            this.ckb_fusebit_l8.Text = "FuseBit_l8";
            this.ckb_fusebit_l8.UseVisualStyleBackColor = false;
            // 
            // grp_flash
            // 
            this.grp_flash.Controls.Add(this.btn_open_flash);
            this.grp_flash.Controls.Add(this.btn_save_flash);
            this.grp_flash.Controls.Add(this.txt_open_path_flash);
            this.grp_flash.Controls.Add(this.txt_save_path_flash);
            this.grp_flash.Controls.Add(this.btn_flash_erase);
            this.grp_flash.Controls.Add(this.btn_flash_verify);
            this.grp_flash.Controls.Add(this.btn_flash_write);
            this.grp_flash.Controls.Add(this.btn_flash_read);
            this.grp_flash.Location = new System.Drawing.Point(414, 320);
            this.grp_flash.Name = "grp_flash";
            this.grp_flash.Size = new System.Drawing.Size(448, 138);
            this.grp_flash.TabIndex = 23;
            this.grp_flash.TabStop = false;
            this.grp_flash.Text = "Flash";
            // 
            // btn_open_flash
            // 
            this.btn_open_flash.Location = new System.Drawing.Point(6, 80);
            this.btn_open_flash.Name = "btn_open_flash";
            this.btn_open_flash.Size = new System.Drawing.Size(51, 23);
            this.btn_open_flash.TabIndex = 32;
            this.btn_open_flash.Text = "Open";
            this.btn_open_flash.UseVisualStyleBackColor = true;
            this.btn_open_flash.Click += new System.EventHandler(this.btn_open_flash_Click);
            // 
            // btn_save_flash
            // 
            this.btn_save_flash.Location = new System.Drawing.Point(6, 22);
            this.btn_save_flash.Name = "btn_save_flash";
            this.btn_save_flash.Size = new System.Drawing.Size(51, 23);
            this.btn_save_flash.TabIndex = 31;
            this.btn_save_flash.Text = "Save";
            this.btn_save_flash.UseVisualStyleBackColor = true;
            this.btn_save_flash.Click += new System.EventHandler(this.btn_save_flash_Click);
            // 
            // txt_open_path_flash
            // 
            this.txt_open_path_flash.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_open_path_flash.Enabled = false;
            this.txt_open_path_flash.Location = new System.Drawing.Point(69, 80);
            this.txt_open_path_flash.Name = "txt_open_path_flash";
            this.txt_open_path_flash.Size = new System.Drawing.Size(289, 23);
            this.txt_open_path_flash.TabIndex = 30;
            // 
            // txt_save_path_flash
            // 
            this.txt_save_path_flash.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_save_path_flash.Enabled = false;
            this.txt_save_path_flash.Location = new System.Drawing.Point(69, 23);
            this.txt_save_path_flash.Name = "txt_save_path_flash";
            this.txt_save_path_flash.Size = new System.Drawing.Size(289, 23);
            this.txt_save_path_flash.TabIndex = 29;
            // 
            // btn_flash_erase
            // 
            this.btn_flash_erase.Enabled = false;
            this.btn_flash_erase.Location = new System.Drawing.Point(367, 109);
            this.btn_flash_erase.Name = "btn_flash_erase";
            this.btn_flash_erase.Size = new System.Drawing.Size(75, 23);
            this.btn_flash_erase.TabIndex = 28;
            this.btn_flash_erase.Text = "Erase";
            this.btn_flash_erase.UseVisualStyleBackColor = true;
            this.btn_flash_erase.Click += new System.EventHandler(this.btn_flash_erase_Click);
            // 
            // btn_flash_verify
            // 
            this.btn_flash_verify.Enabled = false;
            this.btn_flash_verify.Location = new System.Drawing.Point(367, 51);
            this.btn_flash_verify.Name = "btn_flash_verify";
            this.btn_flash_verify.Size = new System.Drawing.Size(75, 23);
            this.btn_flash_verify.TabIndex = 27;
            this.btn_flash_verify.Text = "Verify";
            this.btn_flash_verify.UseVisualStyleBackColor = true;
            this.btn_flash_verify.Click += new System.EventHandler(this.btn_flash_verify_Click);
            // 
            // btn_flash_write
            // 
            this.btn_flash_write.Enabled = false;
            this.btn_flash_write.Location = new System.Drawing.Point(367, 80);
            this.btn_flash_write.Name = "btn_flash_write";
            this.btn_flash_write.Size = new System.Drawing.Size(75, 23);
            this.btn_flash_write.TabIndex = 26;
            this.btn_flash_write.Text = "Write";
            this.btn_flash_write.UseVisualStyleBackColor = true;
            this.btn_flash_write.Click += new System.EventHandler(this.btn_flash_write_Click);
            // 
            // btn_flash_read
            // 
            this.btn_flash_read.Enabled = false;
            this.btn_flash_read.Location = new System.Drawing.Point(367, 22);
            this.btn_flash_read.Name = "btn_flash_read";
            this.btn_flash_read.Size = new System.Drawing.Size(75, 23);
            this.btn_flash_read.TabIndex = 25;
            this.btn_flash_read.Text = "Read";
            this.btn_flash_read.UseVisualStyleBackColor = true;
            this.btn_flash_read.Click += new System.EventHandler(this.btn_flash_read_Click);
            // 
            // lbl_mcu
            // 
            this.lbl_mcu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_mcu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_mcu.Enabled = false;
            this.lbl_mcu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_mcu.Location = new System.Drawing.Point(14, 24);
            this.lbl_mcu.Name = "lbl_mcu";
            this.lbl_mcu.Size = new System.Drawing.Size(114, 23);
            this.lbl_mcu.TabIndex = 0;
            this.lbl_mcu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Chip";
            // 
            // grp_mcu
            // 
            this.grp_mcu.Controls.Add(this.btn_connect);
            this.grp_mcu.Controls.Add(this.label1);
            this.grp_mcu.Controls.Add(this.lbl_mcu);
            this.grp_mcu.Location = new System.Drawing.Point(322, 12);
            this.grp_mcu.Name = "grp_mcu";
            this.grp_mcu.Size = new System.Drawing.Size(183, 100);
            this.grp_mcu.TabIndex = 25;
            this.grp_mcu.TabStop = false;
            this.grp_mcu.Text = "MCU";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(48, 68);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(80, 23);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // grp_eeprom
            // 
            this.grp_eeprom.Controls.Add(this.btn_eeprom_erase);
            this.grp_eeprom.Controls.Add(this.btn_eeprom_verify);
            this.grp_eeprom.Controls.Add(this.btn_eeprom_write);
            this.grp_eeprom.Controls.Add(this.txt_open_path_eeprom);
            this.grp_eeprom.Controls.Add(this.btn_eeprom_read);
            this.grp_eeprom.Controls.Add(this.txt_save_path_eeprom);
            this.grp_eeprom.Controls.Add(this.btn_open_eeprom);
            this.grp_eeprom.Controls.Add(this.btn_save_eeprom);
            this.grp_eeprom.Location = new System.Drawing.Point(414, 464);
            this.grp_eeprom.Name = "grp_eeprom";
            this.grp_eeprom.Size = new System.Drawing.Size(448, 142);
            this.grp_eeprom.TabIndex = 26;
            this.grp_eeprom.TabStop = false;
            this.grp_eeprom.Text = "EEprom";
            // 
            // btn_eeprom_erase
            // 
            this.btn_eeprom_erase.Enabled = false;
            this.btn_eeprom_erase.Location = new System.Drawing.Point(367, 108);
            this.btn_eeprom_erase.Name = "btn_eeprom_erase";
            this.btn_eeprom_erase.Size = new System.Drawing.Size(75, 23);
            this.btn_eeprom_erase.TabIndex = 37;
            this.btn_eeprom_erase.Text = "Erase";
            this.btn_eeprom_erase.UseVisualStyleBackColor = true;
            this.btn_eeprom_erase.Click += new System.EventHandler(this.btn_eeprom_erase_Click);
            // 
            // btn_eeprom_verify
            // 
            this.btn_eeprom_verify.Enabled = false;
            this.btn_eeprom_verify.Location = new System.Drawing.Point(367, 50);
            this.btn_eeprom_verify.Name = "btn_eeprom_verify";
            this.btn_eeprom_verify.Size = new System.Drawing.Size(75, 23);
            this.btn_eeprom_verify.TabIndex = 36;
            this.btn_eeprom_verify.Text = "Verify";
            this.btn_eeprom_verify.UseVisualStyleBackColor = true;
            this.btn_eeprom_verify.Click += new System.EventHandler(this.btn_eeprom_verify_Click);
            // 
            // btn_eeprom_write
            // 
            this.btn_eeprom_write.Enabled = false;
            this.btn_eeprom_write.Location = new System.Drawing.Point(367, 79);
            this.btn_eeprom_write.Name = "btn_eeprom_write";
            this.btn_eeprom_write.Size = new System.Drawing.Size(75, 23);
            this.btn_eeprom_write.TabIndex = 35;
            this.btn_eeprom_write.Text = "Write";
            this.btn_eeprom_write.UseVisualStyleBackColor = true;
            this.btn_eeprom_write.Click += new System.EventHandler(this.btn_eeprom_write_Click);
            // 
            // txt_open_path_eeprom
            // 
            this.txt_open_path_eeprom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_open_path_eeprom.Enabled = false;
            this.txt_open_path_eeprom.Location = new System.Drawing.Point(69, 80);
            this.txt_open_path_eeprom.Name = "txt_open_path_eeprom";
            this.txt_open_path_eeprom.Size = new System.Drawing.Size(289, 23);
            this.txt_open_path_eeprom.TabIndex = 33;
            // 
            // btn_eeprom_read
            // 
            this.btn_eeprom_read.Enabled = false;
            this.btn_eeprom_read.Location = new System.Drawing.Point(367, 22);
            this.btn_eeprom_read.Name = "btn_eeprom_read";
            this.btn_eeprom_read.Size = new System.Drawing.Size(75, 23);
            this.btn_eeprom_read.TabIndex = 34;
            this.btn_eeprom_read.Text = "Read";
            this.btn_eeprom_read.UseVisualStyleBackColor = true;
            this.btn_eeprom_read.Click += new System.EventHandler(this.btn_eeprom_read_Click);
            // 
            // txt_save_path_eeprom
            // 
            this.txt_save_path_eeprom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_save_path_eeprom.Enabled = false;
            this.txt_save_path_eeprom.Location = new System.Drawing.Point(69, 23);
            this.txt_save_path_eeprom.Name = "txt_save_path_eeprom";
            this.txt_save_path_eeprom.Size = new System.Drawing.Size(289, 23);
            this.txt_save_path_eeprom.TabIndex = 30;
            // 
            // btn_open_eeprom
            // 
            this.btn_open_eeprom.Location = new System.Drawing.Point(6, 79);
            this.btn_open_eeprom.Name = "btn_open_eeprom";
            this.btn_open_eeprom.Size = new System.Drawing.Size(51, 23);
            this.btn_open_eeprom.TabIndex = 33;
            this.btn_open_eeprom.Text = "Open";
            this.btn_open_eeprom.UseVisualStyleBackColor = true;
            this.btn_open_eeprom.Click += new System.EventHandler(this.btn_open_eeprom_Click);
            // 
            // btn_save_eeprom
            // 
            this.btn_save_eeprom.Location = new System.Drawing.Point(6, 22);
            this.btn_save_eeprom.Name = "btn_save_eeprom";
            this.btn_save_eeprom.Size = new System.Drawing.Size(51, 23);
            this.btn_save_eeprom.TabIndex = 32;
            this.btn_save_eeprom.Text = "Save";
            this.btn_save_eeprom.UseVisualStyleBackColor = true;
            this.btn_save_eeprom.Click += new System.EventHandler(this.btn_save_eeprom_Click);
            // 
            // grp_power
            // 
            this.grp_power.Controls.Add(this.btn_sleep);
            this.grp_power.Controls.Add(this.btn_reset_app);
            this.grp_power.Location = new System.Drawing.Point(225, 12);
            this.grp_power.Name = "grp_power";
            this.grp_power.Size = new System.Drawing.Size(91, 100);
            this.grp_power.TabIndex = 38;
            this.grp_power.TabStop = false;
            this.grp_power.Text = "Power";
            // 
            // btn_sleep
            // 
            this.btn_sleep.Enabled = false;
            this.btn_sleep.Location = new System.Drawing.Point(6, 56);
            this.btn_sleep.Name = "btn_sleep";
            this.btn_sleep.Size = new System.Drawing.Size(80, 23);
            this.btn_sleep.TabIndex = 39;
            this.btn_sleep.Text = "Sleep";
            this.btn_sleep.UseVisualStyleBackColor = true;
            this.btn_sleep.Click += new System.EventHandler(this.btn_sleep_Click);
            // 
            // btn_reset_app
            // 
            this.btn_reset_app.Enabled = false;
            this.btn_reset_app.Location = new System.Drawing.Point(6, 27);
            this.btn_reset_app.Name = "btn_reset_app";
            this.btn_reset_app.Size = new System.Drawing.Size(80, 23);
            this.btn_reset_app.TabIndex = 39;
            this.btn_reset_app.Text = "Reset App";
            this.btn_reset_app.UseVisualStyleBackColor = true;
            this.btn_reset_app.Click += new System.EventHandler(this.btn_reset_app_Click);
            // 
            // ckb_auto_reset_after_write_flash
            // 
            this.ckb_auto_reset_after_write_flash.AutoSize = true;
            this.ckb_auto_reset_after_write_flash.Enabled = false;
            this.ckb_auto_reset_after_write_flash.Location = new System.Drawing.Point(6, 6);
            this.ckb_auto_reset_after_write_flash.Name = "ckb_auto_reset_after_write_flash";
            this.ckb_auto_reset_after_write_flash.Size = new System.Drawing.Size(143, 19);
            this.ckb_auto_reset_after_write_flash.TabIndex = 6;
            this.ckb_auto_reset_after_write_flash.Text = "Auto Reset After Write";
            this.ckb_auto_reset_after_write_flash.UseVisualStyleBackColor = true;
            // 
            // ckb_erase_flash_before_write_flash
            // 
            this.ckb_erase_flash_before_write_flash.AutoSize = true;
            this.ckb_erase_flash_before_write_flash.Enabled = false;
            this.ckb_erase_flash_before_write_flash.Location = new System.Drawing.Point(179, 6);
            this.ckb_erase_flash_before_write_flash.Name = "ckb_erase_flash_before_write_flash";
            this.ckb_erase_flash_before_write_flash.Size = new System.Drawing.Size(145, 19);
            this.ckb_erase_flash_before_write_flash.TabIndex = 8;
            this.ckb_erase_flash_before_write_flash.Text = "Erase Flash Befor Write";
            this.ckb_erase_flash_before_write_flash.UseVisualStyleBackColor = true;
            // 
            // ckb_lock_app_read_after_read_flash
            // 
            this.ckb_lock_app_read_after_read_flash.AutoSize = true;
            this.ckb_lock_app_read_after_read_flash.Enabled = false;
            this.ckb_lock_app_read_after_read_flash.Location = new System.Drawing.Point(6, 81);
            this.ckb_lock_app_read_after_read_flash.Name = "ckb_lock_app_read_after_read_flash";
            this.ckb_lock_app_read_after_read_flash.Size = new System.Drawing.Size(163, 19);
            this.ckb_lock_app_read_after_read_flash.TabIndex = 9;
            this.ckb_lock_app_read_after_read_flash.Text = "Lock App Read After Read";
            this.ckb_lock_app_read_after_read_flash.UseVisualStyleBackColor = true;
            // 
            // ckb_lock_app_write_after_write_flash
            // 
            this.ckb_lock_app_write_after_write_flash.AutoSize = true;
            this.ckb_lock_app_write_after_write_flash.Enabled = false;
            this.ckb_lock_app_write_after_write_flash.Location = new System.Drawing.Point(6, 56);
            this.ckb_lock_app_write_after_write_flash.Name = "ckb_lock_app_write_after_write_flash";
            this.ckb_lock_app_write_after_write_flash.Size = new System.Drawing.Size(167, 19);
            this.ckb_lock_app_write_after_write_flash.TabIndex = 11;
            this.ckb_lock_app_write_after_write_flash.Text = "Lock App Write After Write";
            this.ckb_lock_app_write_after_write_flash.UseVisualStyleBackColor = true;
            // 
            // ckb_erase_e2prom_before_write_flash
            // 
            this.ckb_erase_e2prom_before_write_flash.AutoSize = true;
            this.ckb_erase_e2prom_before_write_flash.Enabled = false;
            this.ckb_erase_e2prom_before_write_flash.Location = new System.Drawing.Point(179, 31);
            this.ckb_erase_e2prom_before_write_flash.Name = "ckb_erase_e2prom_before_write_flash";
            this.ckb_erase_e2prom_before_write_flash.Size = new System.Drawing.Size(165, 19);
            this.ckb_erase_e2prom_before_write_flash.TabIndex = 12;
            this.ckb_erase_e2prom_before_write_flash.Text = "Erase E2prom Before Write";
            this.ckb_erase_e2prom_before_write_flash.UseVisualStyleBackColor = true;
            // 
            // ckb_verify_after_flash_write
            // 
            this.ckb_verify_after_flash_write.AutoSize = true;
            this.ckb_verify_after_flash_write.Enabled = false;
            this.ckb_verify_after_flash_write.Location = new System.Drawing.Point(179, 56);
            this.ckb_verify_after_flash_write.Name = "ckb_verify_after_flash_write";
            this.ckb_verify_after_flash_write.Size = new System.Drawing.Size(115, 19);
            this.ckb_verify_after_flash_write.TabIndex = 13;
            this.ckb_verify_after_flash_write.Text = "Verify After Write";
            this.ckb_verify_after_flash_write.UseVisualStyleBackColor = true;
            // 
            // ckb_ignore_lockbits_while_write_flash
            // 
            this.ckb_ignore_lockbits_while_write_flash.AutoSize = true;
            this.ckb_ignore_lockbits_while_write_flash.Enabled = false;
            this.ckb_ignore_lockbits_while_write_flash.Location = new System.Drawing.Point(179, 81);
            this.ckb_ignore_lockbits_while_write_flash.Name = "ckb_ignore_lockbits_while_write_flash";
            this.ckb_ignore_lockbits_while_write_flash.Size = new System.Drawing.Size(181, 19);
            this.ckb_ignore_lockbits_while_write_flash.TabIndex = 14;
            this.ckb_ignore_lockbits_while_write_flash.Text = "Ignore LockBits (Debug Only)";
            this.ckb_ignore_lockbits_while_write_flash.UseVisualStyleBackColor = true;
            // 
            // tab_settings
            // 
            this.tab_settings.Controls.Add(this.tab_flash);
            this.tab_settings.Controls.Add(this.tab_e2prom);
            this.tab_settings.Controls.Add(this.tab_connection);
            this.tab_settings.Controls.Add(this.tab_logs);
            this.tab_settings.Controls.Add(this.tab_backup_restore);
            this.tab_settings.Controls.Add(this.tab_about);
            this.tab_settings.Location = new System.Drawing.Point(12, 158);
            this.tab_settings.Name = "tab_settings";
            this.tab_settings.SelectedIndex = 0;
            this.tab_settings.Size = new System.Drawing.Size(493, 156);
            this.tab_settings.TabIndex = 16;
            // 
            // tab_flash
            // 
            this.tab_flash.Controls.Add(this.lbl_file_type_flash);
            this.tab_flash.Controls.Add(this.cmb_file_type_flash);
            this.tab_flash.Controls.Add(this.ckb_auto_reset_after_write_flash);
            this.tab_flash.Controls.Add(this.ckb_ignore_lockbits_while_write_flash);
            this.tab_flash.Controls.Add(this.ckb_auto_reset_after_read_flash);
            this.tab_flash.Controls.Add(this.ckb_verify_after_flash_write);
            this.tab_flash.Controls.Add(this.ckb_erase_flash_before_write_flash);
            this.tab_flash.Controls.Add(this.ckb_erase_e2prom_before_write_flash);
            this.tab_flash.Controls.Add(this.ckb_lock_app_read_after_read_flash);
            this.tab_flash.Controls.Add(this.ckb_lock_app_write_after_write_flash);
            this.tab_flash.Location = new System.Drawing.Point(4, 24);
            this.tab_flash.Name = "tab_flash";
            this.tab_flash.Padding = new System.Windows.Forms.Padding(3);
            this.tab_flash.Size = new System.Drawing.Size(485, 128);
            this.tab_flash.TabIndex = 0;
            this.tab_flash.Text = "Flash W/R";
            this.tab_flash.UseVisualStyleBackColor = true;
            // 
            // lbl_file_type_flash
            // 
            this.lbl_file_type_flash.AutoSize = true;
            this.lbl_file_type_flash.Location = new System.Drawing.Point(388, 5);
            this.lbl_file_type_flash.Name = "lbl_file_type_flash";
            this.lbl_file_type_flash.Size = new System.Drawing.Size(52, 15);
            this.lbl_file_type_flash.TabIndex = 16;
            this.lbl_file_type_flash.Text = "File Type";
            // 
            // cmb_file_type_flash
            // 
            this.cmb_file_type_flash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_file_type_flash.Enabled = false;
            this.cmb_file_type_flash.FormattingEnabled = true;
            this.cmb_file_type_flash.Items.AddRange(new object[] {
            "Hex"});
            this.cmb_file_type_flash.Location = new System.Drawing.Point(354, 24);
            this.cmb_file_type_flash.Name = "cmb_file_type_flash";
            this.cmb_file_type_flash.Size = new System.Drawing.Size(121, 23);
            this.cmb_file_type_flash.TabIndex = 15;
            // 
            // ckb_auto_reset_after_read_flash
            // 
            this.ckb_auto_reset_after_read_flash.AutoSize = true;
            this.ckb_auto_reset_after_read_flash.Enabled = false;
            this.ckb_auto_reset_after_read_flash.Location = new System.Drawing.Point(6, 31);
            this.ckb_auto_reset_after_read_flash.Name = "ckb_auto_reset_after_read_flash";
            this.ckb_auto_reset_after_read_flash.Size = new System.Drawing.Size(141, 19);
            this.ckb_auto_reset_after_read_flash.TabIndex = 7;
            this.ckb_auto_reset_after_read_flash.Text = "Auto Reset After Read";
            this.ckb_auto_reset_after_read_flash.UseVisualStyleBackColor = true;
            // 
            // tab_e2prom
            // 
            this.tab_e2prom.Controls.Add(this.ckb_ignore_0xFF_for_e2prom_erase);
            this.tab_e2prom.Controls.Add(this.ckb_ignore_oxFF_for_e2prom_write);
            this.tab_e2prom.Controls.Add(this.ckb_ignore_0xFF_for_e2prom_read);
            this.tab_e2prom.Controls.Add(this.lbl_file_type_e2prom);
            this.tab_e2prom.Controls.Add(this.cmb_file_type_e2prom);
            this.tab_e2prom.Controls.Add(this.ckb_auto_reset_after_e2prom_write);
            this.tab_e2prom.Controls.Add(this.ckb_auto_reset_after_e2prom_read);
            this.tab_e2prom.Controls.Add(this.ckb_erase_e2prom_before_write_e2prom);
            this.tab_e2prom.Location = new System.Drawing.Point(4, 24);
            this.tab_e2prom.Name = "tab_e2prom";
            this.tab_e2prom.Padding = new System.Windows.Forms.Padding(3);
            this.tab_e2prom.Size = new System.Drawing.Size(485, 128);
            this.tab_e2prom.TabIndex = 1;
            this.tab_e2prom.Text = "E2prom W/R";
            this.tab_e2prom.UseVisualStyleBackColor = true;
            // 
            // ckb_ignore_0xFF_for_e2prom_erase
            // 
            this.ckb_ignore_0xFF_for_e2prom_erase.AutoSize = true;
            this.ckb_ignore_0xFF_for_e2prom_erase.Enabled = false;
            this.ckb_ignore_0xFF_for_e2prom_erase.Location = new System.Drawing.Point(155, 56);
            this.ckb_ignore_0xFF_for_e2prom_erase.Name = "ckb_ignore_0xFF_for_e2prom_erase";
            this.ckb_ignore_0xFF_for_e2prom_erase.Size = new System.Drawing.Size(181, 19);
            this.ckb_ignore_0xFF_for_e2prom_erase.TabIndex = 22;
            this.ckb_ignore_0xFF_for_e2prom_erase.Text = "Ignore 0xFF For E2prom Erase";
            this.ckb_ignore_0xFF_for_e2prom_erase.UseVisualStyleBackColor = true;
            // 
            // ckb_ignore_oxFF_for_e2prom_write
            // 
            this.ckb_ignore_oxFF_for_e2prom_write.AutoSize = true;
            this.ckb_ignore_oxFF_for_e2prom_write.Enabled = false;
            this.ckb_ignore_oxFF_for_e2prom_write.Location = new System.Drawing.Point(155, 31);
            this.ckb_ignore_oxFF_for_e2prom_write.Name = "ckb_ignore_oxFF_for_e2prom_write";
            this.ckb_ignore_oxFF_for_e2prom_write.Size = new System.Drawing.Size(182, 19);
            this.ckb_ignore_oxFF_for_e2prom_write.TabIndex = 21;
            this.ckb_ignore_oxFF_for_e2prom_write.Text = "Ignore 0xFF For E2prom Write";
            this.ckb_ignore_oxFF_for_e2prom_write.UseVisualStyleBackColor = true;
            // 
            // ckb_ignore_0xFF_for_e2prom_read
            // 
            this.ckb_ignore_0xFF_for_e2prom_read.AutoSize = true;
            this.ckb_ignore_0xFF_for_e2prom_read.Enabled = false;
            this.ckb_ignore_0xFF_for_e2prom_read.Location = new System.Drawing.Point(155, 6);
            this.ckb_ignore_0xFF_for_e2prom_read.Name = "ckb_ignore_0xFF_for_e2prom_read";
            this.ckb_ignore_0xFF_for_e2prom_read.Size = new System.Drawing.Size(180, 19);
            this.ckb_ignore_0xFF_for_e2prom_read.TabIndex = 20;
            this.ckb_ignore_0xFF_for_e2prom_read.Text = "Ignore 0xFF For E2prom Read";
            this.ckb_ignore_0xFF_for_e2prom_read.UseVisualStyleBackColor = true;
            // 
            // lbl_file_type_e2prom
            // 
            this.lbl_file_type_e2prom.AutoSize = true;
            this.lbl_file_type_e2prom.Location = new System.Drawing.Point(388, 5);
            this.lbl_file_type_e2prom.Name = "lbl_file_type_e2prom";
            this.lbl_file_type_e2prom.Size = new System.Drawing.Size(52, 15);
            this.lbl_file_type_e2prom.TabIndex = 19;
            this.lbl_file_type_e2prom.Text = "File Type";
            // 
            // cmb_file_type_e2prom
            // 
            this.cmb_file_type_e2prom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_file_type_e2prom.Enabled = false;
            this.cmb_file_type_e2prom.FormattingEnabled = true;
            this.cmb_file_type_e2prom.Items.AddRange(new object[] {
            "Mhd"});
            this.cmb_file_type_e2prom.Location = new System.Drawing.Point(354, 24);
            this.cmb_file_type_e2prom.Name = "cmb_file_type_e2prom";
            this.cmb_file_type_e2prom.Size = new System.Drawing.Size(121, 23);
            this.cmb_file_type_e2prom.TabIndex = 18;
            // 
            // ckb_auto_reset_after_e2prom_write
            // 
            this.ckb_auto_reset_after_e2prom_write.AutoSize = true;
            this.ckb_auto_reset_after_e2prom_write.Enabled = false;
            this.ckb_auto_reset_after_e2prom_write.Location = new System.Drawing.Point(6, 6);
            this.ckb_auto_reset_after_e2prom_write.Name = "ckb_auto_reset_after_e2prom_write";
            this.ckb_auto_reset_after_e2prom_write.Size = new System.Drawing.Size(143, 19);
            this.ckb_auto_reset_after_e2prom_write.TabIndex = 14;
            this.ckb_auto_reset_after_e2prom_write.Text = "Auto Reset After Write";
            this.ckb_auto_reset_after_e2prom_write.UseVisualStyleBackColor = true;
            // 
            // ckb_auto_reset_after_e2prom_read
            // 
            this.ckb_auto_reset_after_e2prom_read.AutoSize = true;
            this.ckb_auto_reset_after_e2prom_read.Enabled = false;
            this.ckb_auto_reset_after_e2prom_read.Location = new System.Drawing.Point(6, 31);
            this.ckb_auto_reset_after_e2prom_read.Name = "ckb_auto_reset_after_e2prom_read";
            this.ckb_auto_reset_after_e2prom_read.Size = new System.Drawing.Size(141, 19);
            this.ckb_auto_reset_after_e2prom_read.TabIndex = 15;
            this.ckb_auto_reset_after_e2prom_read.Text = "Auto Reset After Read";
            this.ckb_auto_reset_after_e2prom_read.UseVisualStyleBackColor = true;
            // 
            // ckb_erase_e2prom_before_write_e2prom
            // 
            this.ckb_erase_e2prom_before_write_e2prom.AutoSize = true;
            this.ckb_erase_e2prom_before_write_e2prom.Enabled = false;
            this.ckb_erase_e2prom_before_write_e2prom.Location = new System.Drawing.Point(6, 56);
            this.ckb_erase_e2prom_before_write_e2prom.Name = "ckb_erase_e2prom_before_write_e2prom";
            this.ckb_erase_e2prom_before_write_e2prom.Size = new System.Drawing.Size(121, 19);
            this.ckb_erase_e2prom_before_write_e2prom.TabIndex = 16;
            this.ckb_erase_e2prom_before_write_e2prom.Text = "Erase Before Write";
            this.ckb_erase_e2prom_before_write_e2prom.UseVisualStyleBackColor = true;
            // 
            // tab_connection
            // 
            this.tab_connection.Controls.Add(this.ckb_ignore_buildnumber);
            this.tab_connection.Controls.Add(this.lbl_stopbits);
            this.tab_connection.Controls.Add(this.cmb_stopbits);
            this.tab_connection.Controls.Add(this.lbl_parity);
            this.tab_connection.Controls.Add(this.cmb_parity);
            this.tab_connection.Controls.Add(this.lbl_timeout);
            this.tab_connection.Controls.Add(this.cmb_timeout);
            this.tab_connection.Controls.Add(this.lbl_baudrate);
            this.tab_connection.Controls.Add(this.cmb_baudrate);
            this.tab_connection.Controls.Add(this.lbl_port);
            this.tab_connection.Controls.Add(this.cmb_port);
            this.tab_connection.Location = new System.Drawing.Point(4, 24);
            this.tab_connection.Name = "tab_connection";
            this.tab_connection.Size = new System.Drawing.Size(485, 128);
            this.tab_connection.TabIndex = 2;
            this.tab_connection.Text = "Connection";
            this.tab_connection.UseVisualStyleBackColor = true;
            // 
            // ckb_ignore_buildnumber
            // 
            this.ckb_ignore_buildnumber.AutoSize = true;
            this.ckb_ignore_buildnumber.Location = new System.Drawing.Point(216, 72);
            this.ckb_ignore_buildnumber.Name = "ckb_ignore_buildnumber";
            this.ckb_ignore_buildnumber.Size = new System.Drawing.Size(264, 19);
            this.ckb_ignore_buildnumber.TabIndex = 10;
            this.ckb_ignore_buildnumber.Text = "Ignore BuildNumber Mismatch (Debug Only)";
            this.ckb_ignore_buildnumber.UseVisualStyleBackColor = true;
            // 
            // lbl_stopbits
            // 
            this.lbl_stopbits.AutoSize = true;
            this.lbl_stopbits.Location = new System.Drawing.Point(216, 44);
            this.lbl_stopbits.Name = "lbl_stopbits";
            this.lbl_stopbits.Size = new System.Drawing.Size(50, 15);
            this.lbl_stopbits.TabIndex = 9;
            this.lbl_stopbits.Text = "StopBits";
            // 
            // cmb_stopbits
            // 
            this.cmb_stopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_stopbits.FormattingEnabled = true;
            this.cmb_stopbits.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmb_stopbits.Location = new System.Drawing.Point(290, 41);
            this.cmb_stopbits.Name = "cmb_stopbits";
            this.cmb_stopbits.Size = new System.Drawing.Size(121, 23);
            this.cmb_stopbits.TabIndex = 8;
            // 
            // lbl_parity
            // 
            this.lbl_parity.AutoSize = true;
            this.lbl_parity.Location = new System.Drawing.Point(216, 15);
            this.lbl_parity.Name = "lbl_parity";
            this.lbl_parity.Size = new System.Drawing.Size(37, 15);
            this.lbl_parity.TabIndex = 7;
            this.lbl_parity.Text = "Parity";
            // 
            // cmb_parity
            // 
            this.cmb_parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_parity.FormattingEnabled = true;
            this.cmb_parity.Items.AddRange(new object[] {
            "Disabled",
            "Even",
            "Odd"});
            this.cmb_parity.Location = new System.Drawing.Point(290, 12);
            this.cmb_parity.Name = "cmb_parity";
            this.cmb_parity.Size = new System.Drawing.Size(121, 23);
            this.cmb_parity.TabIndex = 6;
            // 
            // lbl_timeout
            // 
            this.lbl_timeout.AutoSize = true;
            this.lbl_timeout.Location = new System.Drawing.Point(12, 73);
            this.lbl_timeout.Name = "lbl_timeout";
            this.lbl_timeout.Size = new System.Drawing.Size(53, 15);
            this.lbl_timeout.TabIndex = 5;
            this.lbl_timeout.Text = "TimeOut";
            // 
            // cmb_timeout
            // 
            this.cmb_timeout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_timeout.FormattingEnabled = true;
            this.cmb_timeout.Items.AddRange(new object[] {
            "50ms",
            "100ms",
            "500ms",
            "1s",
            "2s",
            "5s",
            "10s"});
            this.cmb_timeout.Location = new System.Drawing.Point(86, 70);
            this.cmb_timeout.Name = "cmb_timeout";
            this.cmb_timeout.Size = new System.Drawing.Size(121, 23);
            this.cmb_timeout.TabIndex = 4;
            // 
            // lbl_baudrate
            // 
            this.lbl_baudrate.AutoSize = true;
            this.lbl_baudrate.Location = new System.Drawing.Point(12, 44);
            this.lbl_baudrate.Name = "lbl_baudrate";
            this.lbl_baudrate.Size = new System.Drawing.Size(57, 15);
            this.lbl_baudrate.TabIndex = 3;
            this.lbl_baudrate.Text = "BaudRate";
            // 
            // cmb_baudrate
            // 
            this.cmb_baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_baudrate.FormattingEnabled = true;
            this.cmb_baudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "76800",
            "115200",
            "230400",
            "250000",
            "500000",
            "1000000"});
            this.cmb_baudrate.Location = new System.Drawing.Point(86, 41);
            this.cmb_baudrate.Name = "cmb_baudrate";
            this.cmb_baudrate.Size = new System.Drawing.Size(121, 23);
            this.cmb_baudrate.TabIndex = 2;
            // 
            // lbl_port
            // 
            this.lbl_port.AutoSize = true;
            this.lbl_port.Location = new System.Drawing.Point(12, 15);
            this.lbl_port.Name = "lbl_port";
            this.lbl_port.Size = new System.Drawing.Size(29, 15);
            this.lbl_port.TabIndex = 1;
            this.lbl_port.Text = "Port";
            // 
            // cmb_port
            // 
            this.cmb_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_port.FormattingEnabled = true;
            this.cmb_port.Items.AddRange(new object[] {
            "First Port",
            "Second Port",
            "Third Port",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cmb_port.Location = new System.Drawing.Point(86, 12);
            this.cmb_port.Name = "cmb_port";
            this.cmb_port.Size = new System.Drawing.Size(121, 23);
            this.cmb_port.TabIndex = 0;
            // 
            // tab_logs
            // 
            this.tab_logs.Controls.Add(this.btn_save_log_to_file);
            this.tab_logs.Controls.Add(this.btn_clear_logs);
            this.tab_logs.Controls.Add(this.lbl_log_level);
            this.tab_logs.Controls.Add(this.cmb_log_level);
            this.tab_logs.Location = new System.Drawing.Point(4, 24);
            this.tab_logs.Name = "tab_logs";
            this.tab_logs.Size = new System.Drawing.Size(485, 128);
            this.tab_logs.TabIndex = 3;
            this.tab_logs.Text = "Logs";
            this.tab_logs.UseVisualStyleBackColor = true;
            // 
            // btn_save_log_to_file
            // 
            this.btn_save_log_to_file.AutoSize = true;
            this.btn_save_log_to_file.Location = new System.Drawing.Point(16, 95);
            this.btn_save_log_to_file.Name = "btn_save_log_to_file";
            this.btn_save_log_to_file.Size = new System.Drawing.Size(76, 25);
            this.btn_save_log_to_file.TabIndex = 8;
            this.btn_save_log_to_file.Text = "Save to File";
            this.btn_save_log_to_file.UseVisualStyleBackColor = true;
            this.btn_save_log_to_file.Click += new System.EventHandler(this.btn_save_log_to_file_Click);
            // 
            // btn_clear_logs
            // 
            this.btn_clear_logs.AutoSize = true;
            this.btn_clear_logs.Location = new System.Drawing.Point(16, 58);
            this.btn_clear_logs.Name = "btn_clear_logs";
            this.btn_clear_logs.Size = new System.Drawing.Size(75, 25);
            this.btn_clear_logs.TabIndex = 7;
            this.btn_clear_logs.Text = "Clear Logs";
            this.btn_clear_logs.UseVisualStyleBackColor = true;
            this.btn_clear_logs.Click += new System.EventHandler(this.btn_clear_logs_Click);
            // 
            // lbl_log_level
            // 
            this.lbl_log_level.AutoSize = true;
            this.lbl_log_level.Location = new System.Drawing.Point(16, 16);
            this.lbl_log_level.Name = "lbl_log_level";
            this.lbl_log_level.Size = new System.Drawing.Size(57, 15);
            this.lbl_log_level.TabIndex = 3;
            this.lbl_log_level.Text = "Log Level";
            // 
            // cmb_log_level
            // 
            this.cmb_log_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_log_level.FormattingEnabled = true;
            this.cmb_log_level.Items.AddRange(new object[] {
            "User",
            "Debug",
            "Development",
            "ALL"});
            this.cmb_log_level.Location = new System.Drawing.Point(90, 13);
            this.cmb_log_level.Name = "cmb_log_level";
            this.cmb_log_level.Size = new System.Drawing.Size(121, 23);
            this.cmb_log_level.TabIndex = 2;
            // 
            // tab_backup_restore
            // 
            this.tab_backup_restore.Controls.Add(this.btn_save_now);
            this.tab_backup_restore.Controls.Add(this.btn_export_settings);
            this.tab_backup_restore.Controls.Add(this.lbl_save_mode_settings);
            this.tab_backup_restore.Controls.Add(this.cmb_save_mode_settings);
            this.tab_backup_restore.Controls.Add(this.btn_restore_default_settings);
            this.tab_backup_restore.Controls.Add(this.btn_import_settings);
            this.tab_backup_restore.Location = new System.Drawing.Point(4, 24);
            this.tab_backup_restore.Name = "tab_backup_restore";
            this.tab_backup_restore.Size = new System.Drawing.Size(485, 128);
            this.tab_backup_restore.TabIndex = 4;
            this.tab_backup_restore.Text = "Backup/Restore";
            this.tab_backup_restore.UseVisualStyleBackColor = true;
            // 
            // btn_save_now
            // 
            this.btn_save_now.Location = new System.Drawing.Point(395, 22);
            this.btn_save_now.Name = "btn_save_now";
            this.btn_save_now.Size = new System.Drawing.Size(80, 25);
            this.btn_save_now.TabIndex = 43;
            this.btn_save_now.Text = "Save Now";
            this.btn_save_now.UseVisualStyleBackColor = true;
            this.btn_save_now.Click += new System.EventHandler(this.btn_save_now_Click);
            // 
            // btn_export_settings
            // 
            this.btn_export_settings.Location = new System.Drawing.Point(10, 22);
            this.btn_export_settings.Name = "btn_export_settings";
            this.btn_export_settings.Size = new System.Drawing.Size(101, 25);
            this.btn_export_settings.TabIndex = 42;
            this.btn_export_settings.Text = "Export Settings";
            this.btn_export_settings.UseVisualStyleBackColor = true;
            this.btn_export_settings.Click += new System.EventHandler(this.btn_save_settings_Click);
            // 
            // lbl_save_mode_settings
            // 
            this.lbl_save_mode_settings.AutoSize = true;
            this.lbl_save_mode_settings.Location = new System.Drawing.Point(141, 26);
            this.lbl_save_mode_settings.Name = "lbl_save_mode_settings";
            this.lbl_save_mode_settings.Size = new System.Drawing.Size(65, 15);
            this.lbl_save_mode_settings.TabIndex = 41;
            this.lbl_save_mode_settings.Text = "Save Mode";
            // 
            // cmb_save_mode_settings
            // 
            this.cmb_save_mode_settings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_save_mode_settings.FormattingEnabled = true;
            this.cmb_save_mode_settings.Items.AddRange(new object[] {
            "Load Default Every Time",
            "Only When Tap SaveButton",
            "Before Exit The Program"});
            this.cmb_save_mode_settings.Location = new System.Drawing.Point(212, 22);
            this.cmb_save_mode_settings.Name = "cmb_save_mode_settings";
            this.cmb_save_mode_settings.Size = new System.Drawing.Size(160, 23);
            this.cmb_save_mode_settings.TabIndex = 40;
            // 
            // btn_restore_default_settings
            // 
            this.btn_restore_default_settings.Location = new System.Drawing.Point(10, 95);
            this.btn_restore_default_settings.Name = "btn_restore_default_settings";
            this.btn_restore_default_settings.Size = new System.Drawing.Size(101, 25);
            this.btn_restore_default_settings.TabIndex = 25;
            this.btn_restore_default_settings.Text = "Restore Default";
            this.btn_restore_default_settings.UseVisualStyleBackColor = true;
            this.btn_restore_default_settings.Click += new System.EventHandler(this.btn_restore_default_settings_Click);
            // 
            // btn_import_settings
            // 
            this.btn_import_settings.Location = new System.Drawing.Point(10, 58);
            this.btn_import_settings.Name = "btn_import_settings";
            this.btn_import_settings.Size = new System.Drawing.Size(101, 25);
            this.btn_import_settings.TabIndex = 24;
            this.btn_import_settings.Text = "Import Settings";
            this.btn_import_settings.UseVisualStyleBackColor = true;
            this.btn_import_settings.Click += new System.EventHandler(this.btn_load_settings_Click);
            // 
            // tab_about
            // 
            this.tab_about.Controls.Add(this.lbl_thanks);
            this.tab_about.Controls.Add(this.lbl_compile_time);
            this.tab_about.Controls.Add(this.lbl_mcu_code);
            this.tab_about.Controls.Add(this.lbl_client_app);
            this.tab_about.Controls.Add(this.lbl_email);
            this.tab_about.Controls.Add(this.lbl_bootloader_author);
            this.tab_about.Controls.Add(this.lbl_bootloader_name_version);
            this.tab_about.Location = new System.Drawing.Point(4, 24);
            this.tab_about.Name = "tab_about";
            this.tab_about.Size = new System.Drawing.Size(485, 128);
            this.tab_about.TabIndex = 5;
            this.tab_about.Text = "About";
            this.tab_about.UseVisualStyleBackColor = true;
            // 
            // lbl_thanks
            // 
            this.lbl_thanks.Location = new System.Drawing.Point(7, 81);
            this.lbl_thanks.Name = "lbl_thanks";
            this.lbl_thanks.Size = new System.Drawing.Size(475, 47);
            this.lbl_thanks.TabIndex = 7;
            this.lbl_thanks.Text = "Thanks To \"Reza Sepas Yar\" And \"Yadollah Mehrizi\" For AVR Complete Refrence Book " +
    "(Libraries) And Also Thanks To AVR Freaks And StackOverFlow For Answer My Questi" +
    "ons";
            // 
            // lbl_compile_time
            // 
            this.lbl_compile_time.AutoSize = true;
            this.lbl_compile_time.Location = new System.Drawing.Point(7, 58);
            this.lbl_compile_time.Name = "lbl_compile_time";
            this.lbl_compile_time.Size = new System.Drawing.Size(180, 15);
            this.lbl_compile_time.TabIndex = 6;
            this.lbl_compile_time.Text = "Compiled at 2023/jan/3  1:20 AM";
            // 
            // lbl_mcu_code
            // 
            this.lbl_mcu_code.AutoSize = true;
            this.lbl_mcu_code.Location = new System.Drawing.Point(208, 58);
            this.lbl_mcu_code.Name = "lbl_mcu_code";
            this.lbl_mcu_code.Size = new System.Drawing.Size(268, 15);
            this.lbl_mcu_code.TabIndex = 5;
            this.lbl_mcu_code.Text = "MCU Code : Compiled With CodeVisionAVR v3.14";
            // 
            // lbl_client_app
            // 
            this.lbl_client_app.AutoSize = true;
            this.lbl_client_app.Location = new System.Drawing.Point(208, 37);
            this.lbl_client_app.Name = "lbl_client_app";
            this.lbl_client_app.Size = new System.Drawing.Size(250, 15);
            this.lbl_client_app.TabIndex = 4;
            this.lbl_client_app.Text = "Client App : Compiled With Visual Studio 2022";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(208, 14);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(267, 15);
            this.lbl_email.TabIndex = 3;
            this.lbl_email.Text = "Email For Report Bugs : imgoingin20@gmail.com";
            // 
            // lbl_bootloader_author
            // 
            this.lbl_bootloader_author.AutoSize = true;
            this.lbl_bootloader_author.Location = new System.Drawing.Point(7, 37);
            this.lbl_bootloader_author.Name = "lbl_bootloader_author";
            this.lbl_bootloader_author.Size = new System.Drawing.Size(97, 15);
            this.lbl_bootloader_author.TabIndex = 1;
            this.lbl_bootloader_author.Text = "By Unknown_313";
            // 
            // lbl_bootloader_name_version
            // 
            this.lbl_bootloader_name_version.AutoSize = true;
            this.lbl_bootloader_name_version.Location = new System.Drawing.Point(7, 14);
            this.lbl_bootloader_name_version.Name = "lbl_bootloader_name_version";
            this.lbl_bootloader_name_version.Size = new System.Drawing.Size(194, 15);
            this.lbl_bootloader_name_version.TabIndex = 0;
            this.lbl_bootloader_name_version.Text = "Mahdi Boot Loader v1.1.0 (Build 12)";
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(12, 320);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_log.ShortcutsEnabled = false;
            this.txt_log.Size = new System.Drawing.Size(396, 286);
            this.txt_log.TabIndex = 17;
            this.txt_log.WordWrap = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(874, 610);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.tab_settings);
            this.Controls.Add(this.grp_power);
            this.Controls.Add(this.grp_eeprom);
            this.Controls.Add(this.grp_mcu);
            this.Controls.Add(this.grp_flash);
            this.Controls.Add(this.grp_fusebits);
            this.Controls.Add(this.grp_lockbits);
            this.Controls.Add(this.prgrs_progress);
            this.Controls.Add(this.lbl_com);
            this.Controls.Add(this.lbl_status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mahdi BootLoader Public Release v1.1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.grp_lockbits.ResumeLayout(false);
            this.grp_lockbits.PerformLayout();
            this.grp_fusebits.ResumeLayout(false);
            this.grp_flash.ResumeLayout(false);
            this.grp_flash.PerformLayout();
            this.grp_mcu.ResumeLayout(false);
            this.grp_mcu.PerformLayout();
            this.grp_eeprom.ResumeLayout(false);
            this.grp_eeprom.PerformLayout();
            this.grp_power.ResumeLayout(false);
            this.tab_settings.ResumeLayout(false);
            this.tab_flash.ResumeLayout(false);
            this.tab_flash.PerformLayout();
            this.tab_e2prom.ResumeLayout(false);
            this.tab_e2prom.PerformLayout();
            this.tab_connection.ResumeLayout(false);
            this.tab_connection.PerformLayout();
            this.tab_logs.ResumeLayout(false);
            this.tab_logs.PerformLayout();
            this.tab_backup_restore.ResumeLayout(false);
            this.tab_backup_restore.PerformLayout();
            this.tab_about.ResumeLayout(false);
            this.tab_about.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Label lbl_status;
        public Label lbl_com;
        public ProgressBar prgrs_progress;
        public CheckBox ckb_bootlockbit_app_read;
        public CheckBox ckb_fusebit_l8;
        public Button btn_fuse_read;
        public CheckBox ckb_fusebit_h1;
        public CheckBox ckb_fusebit_h2;
        public CheckBox ckb_fusebit_h3;
        public CheckBox ckb_fusebit_h4;
        public CheckBox ckb_fusebit_h5;
        public CheckBox ckb_fusebit_h6;
        public CheckBox ckb_fusebit_h7;
        public CheckBox ckb_fusebit_h8;
        public CheckBox ckb_fusebit_l1;
        public CheckBox ckb_fusebit_l2;
        public CheckBox ckb_fusebit_l3;
        public CheckBox ckb_fusebit_l4;
        public CheckBox ckb_fusebit_l5;
        public CheckBox ckb_fusebit_l6;
        public CheckBox ckb_fusebit_l7;
        public Button btn_lock_write;
        public Button btn_lock_read;
        public CheckBox ckb_bootlockbit_boot_write;
        public CheckBox ckb_bootlockbit_boot_read;
        public CheckBox ckb_bootlockbit_app_write;
        public Button btn_flash_erase;
        public Button btn_flash_verify;
        public Button btn_flash_write;
        public Button btn_flash_read;
        public Button btn_open_flash;
        public Button btn_save_flash;
        public TextBox txt_open_path_flash;
        public TextBox txt_save_path_flash;
        public Label lbl_mcu;
        public CheckBox ckb_lockbit_read_write;
        public CheckBox ckb_lockbit_write;
        public Button btn_eeprom_erase;
        public Button btn_eeprom_verify;
        public Button btn_eeprom_write;
        public TextBox txt_open_path_eeprom;
        public Button btn_eeprom_read;
        public TextBox txt_save_path_eeprom;
        public Button btn_open_eeprom;
        public Button btn_save_eeprom;
        public CheckBox ckb_auto_reset_after_write_flash;
        public CheckBox ckb_erase_flash_before_write_flash;
        public CheckBox ckb_lock_app_read_after_read_flash;
        public CheckBox ckb_lock_app_write_after_write_flash;
        public CheckBox ckb_erase_e2prom_before_write_flash;
        public CheckBox ckb_verify_after_flash_write;
        public CheckBox ckb_ignore_lockbits_while_write_flash;
        public TabControl tab_settings;
        public TabPage tab_flash;
        public TabPage tab_e2prom;
        public TabPage tab_connection;
        public TabPage tab_logs;
        public TabPage tab_backup_restore;
        public CheckBox ckb_auto_reset_after_e2prom_write;
        public CheckBox ckb_auto_reset_after_e2prom_read;
        public CheckBox ckb_erase_e2prom_before_write_e2prom;
        public CheckBox ckb_auto_reset_after_read_flash;
        public CheckBox ckb_ignore_buildnumber;
        public Button btn_save_log_to_file;
        public Button btn_clear_logs;
        public TextBox txt_log;
        public Button btn_restore_default_settings;
        public Button btn_import_settings;
        public Button btn_export_settings;
        public CheckBox ckb_ignore_0xFF_for_e2prom_erase;
        public CheckBox ckb_ignore_oxFF_for_e2prom_write;
        public CheckBox ckb_ignore_0xFF_for_e2prom_read;
        public Button btn_save_now;
        public GroupBox grp_lockbits;
        public GroupBox grp_fusebits;
        public GroupBox grp_flash;
        public Label label1;
        public GroupBox grp_mcu;
        public Button btn_connect;
        public GroupBox grp_eeprom;
        public GroupBox grp_power;
        public Button btn_sleep;
        public Button btn_reset_app;
        public Label lbl_file_type_flash;
        public ComboBox cmb_file_type_flash;
        public Label lbl_file_type_e2prom;
        public ComboBox cmb_file_type_e2prom;
        public Label lbl_timeout;
        public ComboBox cmb_timeout;
        public Label lbl_baudrate;
        public ComboBox cmb_baudrate;
        public Label lbl_port;
        public ComboBox cmb_port;
        public Label lbl_stopbits;
        public ComboBox cmb_stopbits;
        public Label lbl_parity;
        public ComboBox cmb_parity;
        public Label lbl_log_level;
        public ComboBox cmb_log_level;
        public TabPage tab_about;
        public Label lbl_save_mode_settings;
        public ComboBox cmb_save_mode_settings;
        public Label lbl_bootloader_author;
        public Label lbl_bootloader_name_version;
        public Label lbl_email;
        public Label lbl_compile_time;
        public Label lbl_mcu_code;
        public Label lbl_client_app;
        public Label lbl_thanks;
    }
}