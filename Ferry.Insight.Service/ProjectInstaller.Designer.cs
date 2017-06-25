namespace Ferry.Insight.Service
{
    partial class ProjectInstaller
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
            this.InsightFerryServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.InsightFerryServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // InsightFerryServiceProcessInstaller
            // 
            this.InsightFerryServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.InsightFerryServiceProcessInstaller.Password = null;
            this.InsightFerryServiceProcessInstaller.Username = null;
            // 
            // InsightFerryServiceInstaller
            // 
            this.InsightFerryServiceInstaller.Description = "Gravity Software Tools - Insight Import Ferry Service";
            this.InsightFerryServiceInstaller.DisplayName = "Gravity Tools - Insight Import Service";
            this.InsightFerryServiceInstaller.ServiceName = "Gravity Tools - Insight Import Service";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.InsightFerryServiceProcessInstaller,
            this.InsightFerryServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller InsightFerryServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller InsightFerryServiceInstaller;
    }
}